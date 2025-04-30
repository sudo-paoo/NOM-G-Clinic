Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PatientDetails
    Public patientID As String

    Private Sub PatientDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.ItemSize = New Size(TabControl1.Width \ TabControl1.TabCount - 2, 30)
        If Not String.IsNullOrEmpty(patientID) Then
            LoadPatientData()
        Else
            MessageBox.Show("No patient ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub LoadPatientData()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim query As String = "
            SELECT 
                p.first_name, 
                p.middle_name, 
                p.last_name, 
                p.age, 
                p.civil_status, 
                p.first_baby, 
                p.address, 
                p.last_menstrual_period, 
                p.next_checkup, 
                p.assigned_ob,
                CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS doctor_name
            FROM 
                patient p
            LEFT JOIN 
                doctor d ON p.assigned_ob = d.doctor_id
            WHERE 
                p.patient_id = @patientID"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@patientID", patientID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Display patient name (without middle name)
                            lblName.Text = $"{reader("first_name")} {reader("last_name")}"

                            ' Display age
                            lblAge.Text = reader("age").ToString()

                            ' Display civil status (capitalize first letter)
                            Dim civilStatus As String = reader("civil_status").ToString()
                            lblCivilStatus.Text = If(String.IsNullOrEmpty(civilStatus), "Unknown",
                                                    civilStatus.Substring(0, 1).ToUpper() & civilStatus.Substring(1))

                            ' Display first baby (convert from integer to Yes/No)
                            Dim firstBabyVal As Integer = Convert.ToInt32(reader("first_baby"))
                            lblFirstBaby.Text = If(firstBabyVal = 1, "Yes", "No")

                            ' Display address
                            lblAddress.Text = reader("address").ToString()

                            ' Display last menstrual period date
                            Dim lastMenstrualDate As DateTime
                            If DateTime.TryParse(reader("last_menstrual_period").ToString(), lastMenstrualDate) Then
                                lblLastMenstrual.Text = lastMenstrualDate.ToString("MMMM dd, yyyy")

                                ' Calculate and display gestational age (weeks and days)
                                Dim gestationalAge As TimeSpan = DateTime.Now - lastMenstrualDate
                                Dim totalDays As Integer = gestationalAge.Days
                                Dim weeks As Integer = totalDays \ 7
                                Dim days As Integer = totalDays Mod 7
                                lblGestationalAge.Text = $"{weeks} weeks, {days} days"
                            Else
                                lblLastMenstrual.Text = "Not available"
                                lblGestationalAge.Text = "Not available"
                            End If

                            ' Display next checkup date (or "None" if not available)
                            If Not reader.IsDBNull(reader.GetOrdinal("next_checkup")) Then
                                Dim nextCheckupDate As DateTime = Convert.ToDateTime(reader("next_checkup"))
                                ' Only show upcoming checkups
                                If nextCheckupDate >= DateTime.Today Then
                                    lblNextCheckup.Text = nextCheckupDate.ToString("MMMM dd, yyyy")
                                Else
                                    lblNextCheckup.Text = "None"
                                End If
                            Else
                                lblNextCheckup.Text = "None"
                            End If

                            ' Display assigned OB (with "Dr." prefix)
                            If Not reader.IsDBNull(reader.GetOrdinal("doctor_name")) Then
                                lblAssignedOB.Text = reader("doctor_name").ToString()
                            Else
                                lblAssignedOB.Text = "Not assigned"
                            End If
                        Else
                            MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Close()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading patient data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Try
            LoadRecentAppointments()
        Catch ex As Exception
            Dim errorLabel As New Label With {
                .Text = "Error loading recent appointments",
                .Font = New Font("Verdana", 10, FontStyle.Italic),
                .ForeColor = Color.Red,
                .AutoSize = True
            }
            flowRecentAppointments.Controls.Add(errorLabel)
        End Try
        Try
            ' Set up and populate the appointments grid view
            SetupAppointmentsDataGrid()
            PopulateAppointmentsDataGrid()

            ' Your existing call to load recent appointments
            LoadRecentAppointments()
        Catch ex As Exception
            MessageBox.Show("Error loading patient data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRecentAppointments()
        flowRecentAppointments.Controls.Clear()
        If String.IsNullOrEmpty(patientID) Then
            Return
        End If
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim query As String = "
    SELECT 
        a.appointment_id,
        DATE_FORMAT(a.appointment_date, '%h:%i %p') AS AppointmentTime,
        DATE_FORMAT(a.appointment_date, '%b %d, %Y') AS AppointmentDate,
        CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS DoctorName,
        a.reason_for_visit AS Reason,
        a.status AS Status
    FROM 
        appointment_table a
    LEFT JOIN 
        doctor d ON a.doctor_id = d.doctor_id
    WHERE 
        a.patient_id = @patientID
    ORDER BY 
        a.appointment_date DESC
    LIMIT 3"

        ' Create a connection and command
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                ' Add parameter for patient ID
                command.Parameters.AddWithValue("@patientID", patientID)

                Try
                    ' Open the connection
                    connection.Open()

                    ' Execute the query and read the data
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim hasAppointments As Boolean = False

                        While reader.Read()
                            hasAppointments = True

                            ' Extract appointment data
                            Dim appointmentTime As String = reader("AppointmentTime").ToString()
                            Dim reason As String = reader("Reason").ToString()
                            Dim doctorName As String = reader("DoctorName").ToString()

                            Dim appointmentPanel As New Panel With {
                                .BackColor = Color.White,
                                .Size = New Size(flowRecentAppointments.Width - 20, 50),
                                .Margin = New Padding(0, 5, 0, 5),
                                .Padding = New Padding(10),
                                .BorderStyle = BorderStyle.None
                            }

                            ' Create patient name label
                            Dim nameLabel As New Label With {
                                .Text = lblName.Text,
                                .Location = New Point(10, 5),
                                .AutoSize = True,
                                .Font = New Font("Verdana", 9, FontStyle.Bold),
                                .TextAlign = ContentAlignment.MiddleLeft
                            }
                            appointmentPanel.Controls.Add(nameLabel)

                            ' Add appointment time and reason
                            Dim timeReasonLabel As New Label With {
                                .Text = $"{appointmentTime} - {reason}",
                                .Location = New Point(10, 25),
                                .Size = New Size(300, 20),
                                .Font = New Font("Verdana", 9),
                                .TextAlign = ContentAlignment.MiddleLeft
                            }
                            appointmentPanel.Controls.Add(timeReasonLabel)

                            ' Add doctor name on the right side
                            Dim doctorLabel As New Label With {
                                .Text = doctorName,
                                .AutoSize = True,
                                .Font = New Font("Verdana", 9, FontStyle.Bold),
                                .TextAlign = ContentAlignment.MiddleRight,
                                .ForeColor = Color.FromArgb(60, 60, 60)
                            }
                            ' Calculate position to align to far right
                            doctorLabel.Location = New Point(appointmentPanel.Width - doctorLabel.PreferredWidth - 15, 15)
                            appointmentPanel.Controls.Add(doctorLabel)

                            ' Add a separator line at the bottom
                            Dim linePanel As New Panel With {
                                .BackColor = Color.FromArgb(240, 240, 240),
                                .Size = New Size(appointmentPanel.Width - 20, 1),
                                .Location = New Point(10, appointmentPanel.Height - 1)
                            }
                            appointmentPanel.Controls.Add(linePanel)

                            ' Add the panel to the flow layout
                            flowRecentAppointments.Controls.Add(appointmentPanel)
                        End While

                        ' If no appointments, display a message
                        If Not hasAppointments Then
                            Dim noAppointmentsLabel As New Label With {
                                .Text = "No recent appointments found.",
                                .AutoSize = False,
                                .Size = New Size(flowRecentAppointments.Width - 20, 40),
                                .Font = New Font("Verdana", 10, FontStyle.Italic),
                                .ForeColor = Color.Gray,
                                .TextAlign = ContentAlignment.MiddleCenter
                            }
                            flowRecentAppointments.Controls.Add(noAppointmentsLabel)
                        End If
                    End Using
                Catch ex As Exception
                    Dim errorLabel As New Label With {
                        .Text = "Error loading appointments: " & ex.Message,
                        .AutoSize = False,
                        .Size = New Size(flowRecentAppointments.Width - 20, 40),
                        .Font = New Font("Verdana", 10),
                        .ForeColor = Color.Red,
                        .TextAlign = ContentAlignment.MiddleCenter
                    }
                    flowRecentAppointments.Controls.Add(errorLabel)
                End Try
            End Using
        End Using
    End Sub
    Private Sub flowRecentAppointments_Resize(sender As Object, e As EventArgs) Handles flowRecentAppointments.Resize
        For Each ctrl As Control In flowRecentAppointments.Controls
            If TypeOf ctrl Is Panel Then
                Dim panel As Panel = DirectCast(ctrl, Panel)
                panel.Width = flowRecentAppointments.Width - 20
                For Each childCtrl As Control In panel.Controls
                    If TypeOf childCtrl Is Label AndAlso childCtrl.Font.Bold AndAlso childCtrl.Left > 50 Then
                        childCtrl.Location = New Point(panel.Width - childCtrl.Width - 15, childCtrl.Top)
                    ElseIf TypeOf childCtrl Is Panel Then
                        childCtrl.Width = panel.Width - 20
                    End If
                Next
            End If
        Next
    End Sub

    ' Add this method to set up the dgvAppointments grid
    Private Sub SetupAppointmentsDataGrid()
        ' Configure the DataGridView
        dgvAppointments.AllowUserToAddRows = False
        dgvAppointments.AllowUserToDeleteRows = False
        dgvAppointments.ReadOnly = True
        dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAppointments.MultiSelect = False
        dgvAppointments.BackgroundColor = Color.White
        dgvAppointments.BorderStyle = BorderStyle.None
        dgvAppointments.RowHeadersVisible = False
        dgvAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvAppointments.GridColor = Color.LightGray
        dgvAppointments.ColumnHeadersVisible = True

        ' Set column header style
        dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvAppointments.ColumnHeadersHeight = 40
        dgvAppointments.ColumnHeadersDefaultCellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
        dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvAppointments.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        ' Row height and padding
        dgvAppointments.RowTemplate.Height = 50
        dgvAppointments.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
        dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Disable column and row resizing
        dgvAppointments.AllowUserToResizeColumns = False
        dgvAppointments.AllowUserToResizeRows = False

        ' Enable scrollbars when needed
        dgvAppointments.ScrollBars = ScrollBars.Vertical

        ' Set columns mode
        dgvAppointments.AutoGenerateColumns = False
        dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Clear any existing columns
        dgvAppointments.Columns.Clear()

        ' Add columns to match your example
        Dim dateColumn As New DataGridViewTextBoxColumn()
        dateColumn.HeaderText = "Date"
        dateColumn.Name = "Date"
        dateColumn.MinimumWidth = 120
        dateColumn.FillWeight = 20
        dgvAppointments.Columns.Add(dateColumn)

        Dim typeColumn As New DataGridViewTextBoxColumn()
        typeColumn.HeaderText = "Type"
        typeColumn.Name = "Type"
        typeColumn.MinimumWidth = 120
        typeColumn.FillWeight = 20
        dgvAppointments.Columns.Add(typeColumn)

        Dim doctorColumn As New DataGridViewTextBoxColumn()
        doctorColumn.HeaderText = "Doctor"
        doctorColumn.Name = "Doctor"
        doctorColumn.MinimumWidth = 120
        doctorColumn.FillWeight = 20
        dgvAppointments.Columns.Add(doctorColumn)

        Dim notesColumn As New DataGridViewTextBoxColumn()
        notesColumn.HeaderText = "Notes"
        notesColumn.Name = "Notes"
        notesColumn.MinimumWidth = 220
        notesColumn.FillWeight = 40
        dgvAppointments.Columns.Add(notesColumn)

        ' Add handler for cell formatting
        AddHandler dgvAppointments.CellFormatting, AddressOf dgvAppointments_CellFormatting
    End Sub

    Private Sub dgvAppointments_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        ' Apply custom styling to cells
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvAppointments.Rows(e.RowIndex)

            ' Style for date column
            If e.ColumnIndex = dgvAppointments.Columns("Date").Index AndAlso e.Value IsNot Nothing Then
                e.CellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
            End If

            ' Style for Doctor column
            If e.ColumnIndex = dgvAppointments.Columns("Doctor").Index AndAlso e.Value IsNot Nothing Then
                e.CellStyle.ForeColor = Color.FromArgb(60, 60, 140)  ' Dark blue color for doctor names
            End If
        End If
    End Sub

    Private Sub PopulateAppointmentsDataGrid()
        ' Clear any existing rows
        dgvAppointments.Rows.Clear()

        If String.IsNullOrEmpty(patientID) Then
            Return
        End If

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
    SELECT 
        DATE_FORMAT(a.appointment_date, '%b %d, %Y') AS AppointmentDate,
        a.reason_for_visit AS Type,
        CONCAT('Dr. ', d.last_name) AS Doctor,
        a.notes AS Notes
    FROM 
        appointment_table a
    LEFT JOIN 
        doctor d ON a.doctor_id = d.doctor_id
    WHERE 
        a.patient_id = @patientID
    ORDER BY 
        a.appointment_date DESC"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@patientID", patientID)

                Try
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If Not reader.HasRows Then
                            dgvAppointments.Rows.Add("No appointments found", "", "", "")
                            dgvAppointments.Rows(0).DefaultCellStyle.ForeColor = Color.Gray
                            dgvAppointments.Rows(0).DefaultCellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Italic)
                            Return
                        End If

                        While reader.Read()
                            Dim appointmentDate As String = reader("AppointmentDate").ToString()
                            Dim appointmentType As String = reader("Type").ToString()
                            Dim doctorName As String = reader("Doctor").ToString()
                            Dim notes As String = If(reader.IsDBNull(reader.GetOrdinal("Notes")), "", reader("Notes").ToString())
                            dgvAppointments.Rows.Add(appointmentDate, appointmentType, doctorName, notes)
                        End While
                    End Using

                Catch ex As Exception
                    MessageBox.Show("Error loading appointment data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

End Class
