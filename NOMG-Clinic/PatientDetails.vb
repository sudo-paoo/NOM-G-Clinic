Imports MySql.Data.MySqlClient

Public Class PatientDetails
    Public patientID As String

    Private Sub PatientDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.ItemSize = New Size(TabControl1.Width \ TabControl1.TabCount - 2, 30)
        If Not String.IsNullOrEmpty(patientID) Then
            LoadPatientData()

            If Not String.IsNullOrEmpty(lblName.Text) Then
                lblAppointments.Text = $"All appointments for {lblName.Text}"
                lblBillings.Text = $"All billing records for {lblName.Text}"
                lblConsultationDetails.Text = $"All consultation details for {lblName.Text}"
            End If
        Else
            MessageBox.Show("No patient ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Try
            ConsultationSetupDataGrid()
            PopulateConsultationDetailsDataGrid()
        Catch ex As Exception
            MessageBox.Show("Error loading consultation details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                p.flu_vac,
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
                            ' Display patient name
                            lblName.Text = $"{reader("first_name")} {reader("last_name")}"

                            ' Display age
                            lblAge.Text = reader("age").ToString()

                            ' Display civil status
                            Dim civilStatus As String = reader("civil_status").ToString()
                            lblCivilStatus.Text = If(String.IsNullOrEmpty(civilStatus), "Unknown",
                                                    civilStatus.Substring(0, 1).ToUpper() & civilStatus.Substring(1))

                            ' Display first baby
                            Dim firstBabyVal As Integer = Convert.ToInt32(reader("first_baby"))
                            lblFirstBaby.Text = If(firstBabyVal = 1, "Yes", "No")

                            ' Display address
                            lblAddress.Text = reader("address").ToString()

                            ' Display last menstrual period date
                            Dim lastMenstrualDate As DateTime
                            If DateTime.TryParse(reader("last_menstrual_period").ToString(), lastMenstrualDate) Then
                                lblLastMenstrual.Text = lastMenstrualDate.ToString("MMMM dd, yyyy")

                                ' Calculate and display gestational age
                                Dim gestationalAge As TimeSpan = DateTime.Now - lastMenstrualDate
                                Dim totalDays As Integer = gestationalAge.Days
                                Dim weeks As Integer = totalDays \ 7
                                Dim days As Integer = totalDays Mod 7
                                lblGestationalAge.Text = $"{weeks} weeks, {days} days"
                            Else
                                lblLastMenstrual.Text = "Not available"
                                lblGestationalAge.Text = "Not available"
                            End If

                            ' Display next checkup date
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

                            ' Display assigned OB
                            If Not reader.IsDBNull(reader.GetOrdinal("doctor_name")) Then
                                lblAssignedOB.Text = reader("doctor_name").ToString()
                            Else
                                lblAssignedOB.Text = "Not assigned"
                            End If

                            ' Check flu vaccination status
                            Dim fluVacStatus As Boolean = False
                            If Not reader.IsDBNull(reader.GetOrdinal("flu_vac")) Then
                                fluVacStatus = Convert.ToInt32(reader("flu_vac")) = 1
                            End If

                            If fluVacStatus Then
                                lblHsFluVac.Text = "Vaccinated"
                                lblHsFluVac.ForeColor = Color.Green
                            Else
                                lblHsFluVac.Text = "Not Vaccinated"
                                lblHsFluVac.ForeColor = Color.Red
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

            ' Set up and populate the billings grid view
            BillingSetupDataGrid()
            BillingPopulateDataGrid()

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

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@patientID", patientID)

                Try
                    connection.Open()

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

    ' Setup dgvAppointments grid
    Private Sub SetupAppointmentsDataGrid()
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

        dgvAppointments.AllowUserToResizeColumns = False
        dgvAppointments.AllowUserToResizeRows = False

        dgvAppointments.ScrollBars = ScrollBars.Vertical

        dgvAppointments.AutoGenerateColumns = False
        dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvAppointments.Columns.Clear()

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

        AddHandler dgvAppointments.CellFormatting, AddressOf dgvAppointments_CellFormatting
    End Sub

    Private Sub dgvAppointments_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvAppointments.Rows(e.RowIndex)

            If e.ColumnIndex = dgvAppointments.Columns("Date").Index AndAlso e.Value IsNot Nothing Then
                e.CellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
            End If

            If e.ColumnIndex = dgvAppointments.Columns("Doctor").Index AndAlso e.Value IsNot Nothing Then
                e.CellStyle.ForeColor = Color.FromArgb(60, 60, 140)
            End If
        End If
    End Sub

    ' Populate dgvAppointments
    Private Sub PopulateAppointmentsDataGrid()
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

    ' Setup dgvBillings
    Private Sub BillingSetupDataGrid()
        dgvBillings.AllowUserToAddRows = False
        dgvBillings.AllowUserToDeleteRows = False
        dgvBillings.ReadOnly = True
        dgvBillings.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBillings.MultiSelect = False
        dgvBillings.BackgroundColor = Color.White
        dgvBillings.BorderStyle = BorderStyle.None
        dgvBillings.RowHeadersVisible = False
        dgvBillings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvBillings.GridColor = Color.LightGray
        dgvBillings.ColumnHeadersVisible = True

        dgvBillings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvBillings.ColumnHeadersHeight = 40
        dgvBillings.ColumnHeadersDefaultCellStyle.Font = New Font(dgvBillings.Font, FontStyle.Bold)
        dgvBillings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvBillings.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgvBillings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        dgvBillings.RowTemplate.Height = 60
        dgvBillings.RowTemplate.MinimumHeight = 60

        dgvBillings.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dgvBillings.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvBillings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
        dgvBillings.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvBillings.AllowUserToResizeColumns = False
        dgvBillings.AllowUserToResizeRows = False

        dgvBillings.ScrollBars = ScrollBars.Vertical

        dgvBillings.AutoGenerateColumns = False
        dgvBillings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvBillings.Columns.Clear()

        Dim dateColumn As New DataGridViewTextBoxColumn()
        dateColumn.HeaderText = "Date"
        dateColumn.Name = "Date"
        dateColumn.MinimumWidth = 100
        dateColumn.FillWeight = 15
        dgvBillings.Columns.Add(dateColumn)

        Dim quantityColumn As New DataGridViewTextBoxColumn()
        quantityColumn.HeaderText = "Quantity"
        quantityColumn.Name = "Quantity"
        quantityColumn.MinimumWidth = 80
        quantityColumn.FillWeight = 10
        quantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBillings.Columns.Add(quantityColumn)

        Dim itemsColumn As New DataGridViewTextBoxColumn()
        itemsColumn.HeaderText = "Items"
        itemsColumn.Name = "Items"
        itemsColumn.MinimumWidth = 150
        itemsColumn.FillWeight = 35
        itemsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        itemsColumn.DefaultCellStyle.Padding = New Padding(5, 10, 5, 10)
        itemsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
        dgvBillings.Columns.Add(itemsColumn)

        Dim totalColumn As New DataGridViewTextBoxColumn()
        totalColumn.HeaderText = "Total"
        totalColumn.Name = "Total"
        totalColumn.MinimumWidth = 100
        totalColumn.FillWeight = 15
        dgvBillings.Columns.Add(totalColumn)

        Dim statusColumn As New DataGridViewTextBoxColumn()
        statusColumn.HeaderText = "Status"
        statusColumn.Name = "Status"
        statusColumn.MinimumWidth = 80
        statusColumn.FillWeight = 15
        dgvBillings.Columns.Add(statusColumn)

        AddHandler dgvBillings.CellFormatting, AddressOf dgvBillings_CellFormatting
        AddHandler dgvBillings.DataBindingComplete, AddressOf dgvBillings_DataBindingComplete
    End Sub

    ' Populate the dgvBillings
    Private Sub BillingPopulateDataGrid()
        dgvBillings.Rows.Clear()

        If String.IsNullOrEmpty(patientID) Then
            Return
        End If

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
SELECT 
    b.billing_id AS BillingID,
    DATE_FORMAT(b.date, '%b %d, %Y') AS Date, 
    b.items AS Items, 
    b.item_names AS ItemNames,
    b.total_amount AS Total, 
    b.status AS Status
FROM 
    billing b
WHERE 
    b.patient_id = @patientID
ORDER BY 
    b.date DESC"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@patientID", patientID)
                Try
                    connection.Open()

                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    For Each row As DataRow In dataTable.Rows
                        Dim formattedItems As String = FormatItemNames(row("ItemNames").ToString())

                        Dim rowIndex As Integer = dgvBillings.Rows.Add(
                row("Date"),
                row("Items"),
                formattedItems,
                String.Format("₱{0:N2}", Convert.ToDecimal(row("Total"))),
                row("Status"))

                        dgvBillings.Rows(rowIndex).Tag = row("BillingID").ToString()
                    Next

                    ' Ensure rows are properly sized after populating
                    dgvBillings.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)

                    ' If no data found
                    If dgvBillings.Rows.Count = 0 Then
                        dgvBillings.Rows.Add("No billing records", "", "No billing records found for this patient", "", "")
                        dgvBillings.Rows(0).DefaultCellStyle.ForeColor = Color.Gray
                        dgvBillings.Rows(0).DefaultCellStyle.Font = New Font(dgvBillings.Font, FontStyle.Italic)
                    End If

                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching billing data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' Format item names from JSON
    Private Function FormatItemNames(jsonString As String) As String
        If String.IsNullOrEmpty(jsonString) Then
            Return ""
        End If

        Try
            If jsonString.Trim() = "[2]" OrElse System.Text.RegularExpressions.Regex.IsMatch(jsonString.Trim(), "^\[\d+\]$") Then
                Return "Unknown Items"
            End If

            Dim items As List(Of Dictionary(Of String, Object))

            Try
                items = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(jsonString)
            Catch ex As Exception
                Dim sanitizedJson As String = jsonString.Trim()

                If Not sanitizedJson.StartsWith("[") Then
                    sanitizedJson = "[" & sanitizedJson & "]"
                End If

                items = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(sanitizedJson)
            End Try

            Dim formattedItemsList As New List(Of String)

            For Each item In items
                Dim itemName As String = If(item.ContainsKey("item_name"), item("item_name").ToString(), "")
                Dim quantity As Integer = 0

                If item.ContainsKey("quantity") Then
                    Integer.TryParse(item("quantity").ToString(), quantity)
                End If

                If Not String.IsNullOrEmpty(itemName) AndAlso quantity > 0 Then
                    formattedItemsList.Add($"{itemName} x {quantity}")
                ElseIf Not String.IsNullOrEmpty(itemName) Then
                    formattedItemsList.Add(itemName)
                End If
            Next

            Return String.Join(Environment.NewLine, formattedItemsList)

        Catch ex As Exception
            Console.WriteLine("Error parsing JSON item names: " & ex.Message)
            Return "Error parsing items"
        End Try
    End Function

    Private Sub dgvBillings_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        dgvBillings.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)

        If dgvBillings.DisplayedRowCount(True) < dgvBillings.RowCount Then
            dgvBillings.PerformLayout()
        End If
    End Sub

    Private Sub dgvBillings_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBillings.Rows(e.RowIndex)

            If e.ColumnIndex = dgvBillings.Columns("Status").Index Then
                Dim status As String = row.Cells(e.ColumnIndex).Value.ToString()

                If status.Equals("Paid", StringComparison.OrdinalIgnoreCase) Then
                    row.Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                ElseIf status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase) Then
                    row.Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    ' Setup dgvConsultationDetails
    Private Sub ConsultationSetupDataGrid()
        dgvConsultationDetails.AllowUserToAddRows = False
        dgvConsultationDetails.AllowUserToDeleteRows = False
        dgvConsultationDetails.ReadOnly = True
        dgvConsultationDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvConsultationDetails.MultiSelect = False
        dgvConsultationDetails.BackgroundColor = Color.White
        dgvConsultationDetails.BorderStyle = BorderStyle.None
        dgvConsultationDetails.RowHeadersVisible = False
        dgvConsultationDetails.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvConsultationDetails.GridColor = Color.LightGray
        dgvConsultationDetails.ColumnHeadersVisible = True

        dgvConsultationDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvConsultationDetails.ColumnHeadersHeight = 40
        dgvConsultationDetails.ColumnHeadersDefaultCellStyle.Font = New Font(dgvConsultationDetails.Font, FontStyle.Bold)
        dgvConsultationDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvConsultationDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgvConsultationDetails.RowTemplate.Height = 50
        dgvConsultationDetails.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvConsultationDetails.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
        dgvConsultationDetails.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvConsultationDetails.AllowUserToResizeColumns = False
        dgvConsultationDetails.AllowUserToResizeRows = False

        dgvConsultationDetails.ScrollBars = ScrollBars.Vertical

        dgvConsultationDetails.AutoGenerateColumns = False
        dgvConsultationDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvConsultationDetails.Columns.Clear()

        Dim idColumn As New DataGridViewTextBoxColumn()
        idColumn.HeaderText = "ID"
        idColumn.Name = "ConsultationID"
        idColumn.Visible = False
        dgvConsultationDetails.Columns.Add(idColumn)

        Dim dateColumn As New DataGridViewTextBoxColumn()
        dateColumn.HeaderText = "Date"
        dateColumn.Name = "Date"
        dateColumn.MinimumWidth = 120
        dateColumn.FillWeight = 20
        dgvConsultationDetails.Columns.Add(dateColumn)

        Dim doctorColumn As New DataGridViewTextBoxColumn()
        doctorColumn.HeaderText = "Doctor"
        doctorColumn.Name = "Doctor"
        doctorColumn.MinimumWidth = 120
        doctorColumn.FillWeight = 20
        dgvConsultationDetails.Columns.Add(doctorColumn)

        Dim diagnosisColumn As New DataGridViewTextBoxColumn()
        diagnosisColumn.HeaderText = "Diagnosis"
        diagnosisColumn.Name = "Diagnosis"
        diagnosisColumn.MinimumWidth = 220
        diagnosisColumn.FillWeight = 40
        dgvConsultationDetails.Columns.Add(diagnosisColumn)

        Dim viewButtonColumn As New DataGridViewButtonColumn()
        viewButtonColumn.HeaderText = ""
        viewButtonColumn.Name = "ViewButton"
        viewButtonColumn.Text = "View"
        viewButtonColumn.UseColumnTextForButtonValue = True
        viewButtonColumn.FlatStyle = FlatStyle.Flat
        viewButtonColumn.MinimumWidth = 60
        viewButtonColumn.FillWeight = 10
        dgvConsultationDetails.Columns.Add(viewButtonColumn)

        AddHandler dgvConsultationDetails.CellFormatting, AddressOf dgvConsultationDetails_CellFormatting
        AddHandler dgvConsultationDetails.CellClick, AddressOf dgvConsultationDetails_CellClick
    End Sub

    Private Sub dgvConsultationDetails_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvConsultationDetails.Rows(e.RowIndex)

            If e.ColumnIndex = dgvConsultationDetails.Columns("ViewButton").Index Then
                Dim cell As DataGridViewButtonCell = DirectCast(row.Cells(e.ColumnIndex), DataGridViewButtonCell)
                cell.Style.BackColor = Color.FromArgb(0, 120, 215)
                cell.Style.ForeColor = Color.White
                cell.Style.SelectionBackColor = Color.FromArgb(0, 100, 190)
                cell.Style.SelectionForeColor = Color.White
            End If

            If e.ColumnIndex = dgvConsultationDetails.Columns("Date").Index AndAlso e.Value IsNot Nothing Then
                e.CellStyle.Font = New Font(dgvConsultationDetails.Font, FontStyle.Bold)
            End If

            If e.ColumnIndex = dgvConsultationDetails.Columns("Doctor").Index AndAlso e.Value IsNot Nothing Then
                e.CellStyle.ForeColor = Color.FromArgb(60, 60, 140)
            End If
        End If
    End Sub

    Private Sub dgvConsultationDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvConsultationDetails.Columns("ViewButton").Index Then
            Dim consultationID As String = dgvConsultationDetails.Rows(e.RowIndex).Cells("ConsultationID").Value.ToString()

            Dim viewConsultationForm As New ViewConsultationDetails()
            viewConsultationForm.ConsultationID = consultationID
            viewConsultationForm.PatientID = patientID
            viewConsultationForm.ShowDialog()
        End If
    End Sub

    ' Populate dgvConsultationDetails
    Private Sub PopulateConsultationDetailsDataGrid()
        dgvConsultationDetails.Rows.Clear()

        If String.IsNullOrEmpty(patientID) Then
            Return
        End If

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
    SELECT 
        c.consultation_id,
        DATE_FORMAT(c.consultation_date, '%b %d, %Y') AS consultation_date,
        CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS doctor_name,
        c.diagnosis
    FROM 
        consultation c
    LEFT JOIN 
        doctor d ON c.doctor_id = d.doctor_id
    WHERE 
        c.patient_id = @patientID
    ORDER BY 
        c.consultation_date DESC"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@patientID", patientID)

                Try
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If Not reader.HasRows Then
                            dgvConsultationDetails.Rows.Add("", "No consultation records found", "", "", "")
                            dgvConsultationDetails.Rows(0).DefaultCellStyle.ForeColor = Color.Gray
                            dgvConsultationDetails.Rows(0).DefaultCellStyle.Font = New Font(dgvConsultationDetails.Font, FontStyle.Italic)
                            Return
                        End If

                        While reader.Read()
                            Dim consultationId As String = reader("consultation_id").ToString()
                            Dim consultationDate As String = reader("consultation_date").ToString()
                            Dim doctorName As String = reader("doctor_name").ToString()
                            Dim diagnosis As String = reader("diagnosis").ToString()

                            dgvConsultationDetails.Rows.Add(consultationId, consultationDate, doctorName, diagnosis)
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading consultation data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
End Class