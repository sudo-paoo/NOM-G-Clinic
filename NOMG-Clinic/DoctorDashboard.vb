Imports MySql.Data.MySqlClient

Public Class DoctorDashboard
    Public doctorID As String

    Private Sub DoctorDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabDashboard.ItemSize = New Size(tabDashboard.Width \ tabDashboard.TabCount - 2, 30)

        ' Update labels
        UpdateWelcomeMessage()
        UpdateTotalPatients()
        UpdateTodaysAppointments()
        UpdateUpcomingDeliveries()

        ' Load appointments
        LoadTodaysAppointments()
        LoadRecentAppointments()

        ' Load patients
        PatientsSetupDataGrid()
        PatientsPopulateDataGrid()

        ' Load appointments
        AppointmentsSetupDataGrid()
        AppointmentsPopulateDataGrid()

        ShowPanel(pnlDashboard, btnDashboard)
    End Sub

    Private Sub UpdateWelcomeMessage()
        Dim query As String = "SELECT CONCAT('Welcome back, Dr. ', first_name, ' ', last_name) FROM doctor WHERE doctor_id = @doctorID"
        Dim welcomeMessage As String = ExecuteStringQuery(query, New MySqlParameter("@doctorID", doctorID))

        If String.IsNullOrEmpty(welcomeMessage) Then
            lblWelcomeMessage.Text = "Welcome back, Doctor"
        Else
            lblWelcomeMessage.Text = welcomeMessage
        End If
    End Sub

    Private Sub UpdateTotalPatients()
        Dim query As String = "SELECT COUNT(*) FROM patient WHERE assigned_ob = @doctorID"
        Dim totalPatients As Integer = ExecuteScalarQuery(query, New MySqlParameter("@doctorID", doctorID))
        lblTotalPatients.Text = totalPatients.ToString()
    End Sub

    Private Sub UpdateTodaysAppointments()
        Dim query As String = "SELECT COUNT(*) FROM appointment_table WHERE doctor_id = @doctorID AND DATE(appointment_date) = CURDATE()"
        Dim todaysAppointments As Integer = ExecuteScalarQuery(query, New MySqlParameter("@doctorID", doctorID))
        lblTodaysAppointments.Text = todaysAppointments.ToString()
    End Sub

    Private Sub UpdateUpcomingDeliveries()
        Dim query As String = "SELECT COUNT(*) FROM patient WHERE assigned_ob = @doctorID AND due_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)"
        Dim upcomingDeliveries As Integer = ExecuteScalarQuery(query, New MySqlParameter("@doctorID", doctorID))
        lblUpcomingDeliveries.Text = upcomingDeliveries.ToString()
    End Sub

    Private Function ExecuteScalarQuery(query As String, ParamArray parameters As MySqlParameter()) As Integer
        Dim result As Integer = 0
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddRange(parameters)
                connection.Open()
                Dim scalarResult = command.ExecuteScalar()
                If scalarResult IsNot Nothing Then
                    result = Convert.ToInt32(scalarResult)
                End If
            End Using
        End Using

        Return result
    End Function

    Private Function ExecuteStringQuery(query As String, ParamArray parameters As MySqlParameter()) As String
        Dim result As String = String.Empty
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddRange(parameters)
                Try
                    connection.Open()
                    Dim scalarResult = command.ExecuteScalar()
                    If scalarResult IsNot Nothing Then
                        result = scalarResult.ToString()
                    End If
                Catch ex As Exception
                    Console.WriteLine("Error querying database: " & ex.Message)
                End Try
            End Using
        End Using

        Return result
    End Function

    Private Sub LoadTodaysAppointments()
        flowTodaysAppointments.Controls.Clear()

        ' SQL query to get today's appointments for this doctor
        Dim query As String = "SELECT a.appointment_id, a.patient_id, a.appointment_date, a.reason_for_visit, " &
        "CONCAT(p.first_name, ' ', p.last_name) AS patient_name, " &
        "CONCAT(d.first_name, ' ', d.last_name) AS doctor_name " &
        "FROM appointment_table a " &
        "JOIN patient p ON a.patient_id = p.patient_id " &
        "JOIN doctor d ON a.doctor_id = d.doctor_id " &
        "WHERE a.doctor_id = @doctorID AND DATE(a.appointment_date) = CURDATE() " &
        "ORDER BY a.appointment_date ASC"

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@doctorID", doctorID)

                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    Dim hasAppointments As Boolean = False

                    While reader.Read()
                        hasAppointments = True

                        ' Create appointment panel
                        Dim appointmentPanel As Panel = CreateAppointmentPanel(
                            reader("patient_name").ToString(),
                            Convert.ToDateTime(reader("appointment_date")).ToString("h:mm tt"),
                            reader("reason_for_visit").ToString(),
                            reader("doctor_name").ToString()
                        )

                        ' Add to flow layout panel
                        flowTodaysAppointments.Controls.Add(appointmentPanel)
                    End While

                    reader.Close()

                    ' If no appointments, add a message
                    If Not hasAppointments Then
                        Dim noAppointmentsLabel As New Label()
                        noAppointmentsLabel.Text = "No appointments for today"
                        noAppointmentsLabel.AutoSize = True
                        noAppointmentsLabel.Font = New Font("Verdana", 10, FontStyle.Regular)
                        noAppointmentsLabel.Padding = New Padding(10)
                        flowTodaysAppointments.Controls.Add(noAppointmentsLabel)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error loading appointments: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadRecentAppointments()
        flowRecentAppointments.Controls.Clear()

        ' SQL query to get recent appointments for this doctor (past 7 days excluding today)
        Dim query As String = "SELECT a.appointment_id, a.patient_id, a.appointment_date, a.reason_for_visit, " &
                             "CONCAT(p.first_name, ' ', p.last_name) AS patient_name, " &
                             "CONCAT(d.first_name, ' ', d.last_name) AS doctor_name " &
                             "FROM appointment_table a " &
                             "JOIN patient p ON a.patient_id = p.patient_id " &
                             "JOIN doctor d ON a.doctor_id = d.doctor_id " &
                             "WHERE a.doctor_id = @doctorID " &
                             "AND DATE(a.appointment_date) < CURDATE() " &
                             "AND DATE(a.appointment_date) >= DATE_SUB(CURDATE(), INTERVAL 7 DAY) " &
                             "ORDER BY a.appointment_date DESC"

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@doctorID", doctorID)

                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    Dim hasAppointments As Boolean = False

                    While reader.Read()
                        hasAppointments = True

                        ' Create appointment panel
                        Dim appointmentPanel As Panel = CreateAppointmentPanel(
                            reader("patient_name").ToString(),
                            Convert.ToDateTime(reader("appointment_date")).ToString("MMM dd, h:mm tt"),
                            reader("reason_for_visit").ToString(),
                            reader("doctor_name").ToString()
                        )

                        ' Add to flow layout panel
                        flowRecentAppointments.Controls.Add(appointmentPanel)
                    End While

                    reader.Close()

                    ' If no appointments, add a message
                    If Not hasAppointments Then
                        Dim noAppointmentsLabel As New Label()
                        noAppointmentsLabel.Text = "No recent appointments"
                        noAppointmentsLabel.AutoSize = True
                        noAppointmentsLabel.Font = New Font("Verdana", 10, FontStyle.Regular)
                        noAppointmentsLabel.Padding = New Padding(10)
                        flowRecentAppointments.Controls.Add(noAppointmentsLabel)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error loading recent appointments: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Function CreateAppointmentPanel(patientName As String, appointmentDateTime As String, reason As String, doctorName As String) As Panel
        Dim panelWidth As Integer = flowTodaysAppointments.ClientSize.Width - 20

        ' Create the main panel
        Dim panel As New Panel()
        panel.Size = New Size(panelWidth, 80)
        panel.BackColor = Color.White
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Margin = New Padding(10, 0, 10, 10)

        ' Patient name label
        Dim nameLabel As New Label()
        nameLabel.Text = patientName
        nameLabel.Font = New Font("Verdana", 10, FontStyle.Bold)
        nameLabel.AutoSize = True
        nameLabel.Location = New Point(10, 10)
        panel.Controls.Add(nameLabel)

        ' Appointment date and time label
        Dim dateTimeLabel As New Label()
        dateTimeLabel.Text = appointmentDateTime
        dateTimeLabel.Font = New Font("Verdana", 9)
        dateTimeLabel.AutoSize = True
        dateTimeLabel.Location = New Point(10, 30)
        panel.Controls.Add(dateTimeLabel)

        ' Reason for visit label
        Dim reasonLabel As New Label()
        Dim displayReason As String = reason
        If reason.Length > 50 Then
            displayReason = reason.Substring(0, 50) & "..."
        End If
        reasonLabel.Text = "Reason: " & displayReason
        reasonLabel.Font = New Font("Verdana", 8)
        reasonLabel.AutoSize = True
        reasonLabel.Location = New Point(10, 50)
        panel.Controls.Add(reasonLabel)

        ' Doctor name label
        Dim doctorLabel As New Label()
        doctorLabel.Text = doctorName
        doctorLabel.Font = New Font("Verdana", 9)
        doctorLabel.AutoSize = True
        doctorLabel.TextAlign = ContentAlignment.MiddleRight
        doctorLabel.Location = New Point(panel.Width - 150, 10)
        panel.Controls.Add(doctorLabel)

        Return panel
    End Function
    Private Sub flowTodaysAppointments_Resize(sender As Object, e As EventArgs) Handles flowTodaysAppointments.Resize
        For Each ctrl As Control In flowTodaysAppointments.Controls
            If TypeOf ctrl Is Panel Then
                Dim panel As Panel = DirectCast(ctrl, Panel)
                panel.Width = flowTodaysAppointments.ClientSize.Width - 20
            End If
        Next
    End Sub

    Public Sub PatientsSetupDataGrid()
        dgvPatients.AllowUserToAddRows = False
        dgvPatients.AllowUserToDeleteRows = False
        dgvPatients.ReadOnly = True
        dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPatients.MultiSelect = False
        dgvPatients.BackgroundColor = Color.White
        dgvPatients.BorderStyle = BorderStyle.None
        dgvPatients.RowHeadersVisible = False
        dgvPatients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvPatients.GridColor = Color.LightGray
        dgvPatients.ColumnHeadersVisible = True

        dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvPatients.ColumnHeadersHeight = 40
        dgvPatients.ColumnHeadersDefaultCellStyle.Font = New Font(dgvPatients.Font, FontStyle.Bold)
        dgvPatients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvPatients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgvPatients.RowTemplate.Height = 50
        dgvPatients.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvPatients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
        dgvPatients.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvPatients.AllowUserToResizeColumns = False
        dgvPatients.AllowUserToResizeRows = False

        dgvPatients.ScrollBars = ScrollBars.Vertical

        dgvPatients.AutoGenerateColumns = False
        dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvPatients.Columns.Clear()

        Dim fullNameColumn As New DataGridViewTextBoxColumn()
        fullNameColumn.HeaderText = "Full Name"
        fullNameColumn.Name = "FullName"
        fullNameColumn.MinimumWidth = 140
        fullNameColumn.FillWeight = 30
        dgvPatients.Columns.Add(fullNameColumn)

        Dim ageColumn As New DataGridViewTextBoxColumn()
        ageColumn.HeaderText = "Age"
        ageColumn.Name = "Age"
        ageColumn.MinimumWidth = 80
        ageColumn.FillWeight = 15
        dgvPatients.Columns.Add(ageColumn)

        Dim lastMensColumn As New DataGridViewTextBoxColumn()
        lastMensColumn.HeaderText = "Last Menstrual Period"
        lastMensColumn.Name = "LastMens"
        lastMensColumn.MinimumWidth = 150
        lastMensColumn.FillWeight = 25
        dgvPatients.Columns.Add(lastMensColumn)

        Dim allergiesColumn As New DataGridViewTextBoxColumn()
        allergiesColumn.HeaderText = "Allergies"
        allergiesColumn.Name = "Allergies"
        allergiesColumn.MinimumWidth = 150
        allergiesColumn.FillWeight = 30
        dgvPatients.Columns.Add(allergiesColumn)

        AddHandler dgvPatients.DataBindingComplete, AddressOf dgvPatients_DataBindingComplete
    End Sub

    Private Sub dgvPatients_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If dgvPatients.DisplayedRowCount(True) < dgvPatients.RowCount Then
            dgvPatients.PerformLayout()
        End If
    End Sub

    Public Sub PatientsPopulateDataGrid()
        dgvPatients.Rows.Clear()

        Dim query As String = "
        SELECT 
            CONCAT(first_name, ' ', last_name) AS FullName, 
            age, 
            DATE_FORMAT(last_menstrual_period, '%b %d, %Y') AS LastMens, 
            allergies 
        FROM patient 
        WHERE assigned_ob = @doctorID"

        Using connection As New MySqlConnection("Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;")
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@doctorID", doctorID)

                connection.Open()
                Dim reader As MySqlDataReader = command.ExecuteReader()

                While reader.Read()
                    dgvPatients.Rows.Add(reader("FullName"), reader("Age"), reader("LastMens"), reader("Allergies"))
                End While
            End Using
        End Using
    End Sub

    Private Sub txtSearchPatient_TextChanged(sender As Object, e As EventArgs) Handles txtSearchPatient.TextChanged
        Dim searchText As String = txtSearchPatient.Text.Trim().ToLower()

        For Each row As DataGridViewRow In dgvPatients.Rows
            Dim fullName As String = row.Cells("FullName").Value.ToString().ToLower()
            Dim allergies As String = row.Cells("Allergies").Value.ToString().ToLower()

            If fullName.Contains(searchText) OrElse allergies.Contains(searchText) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next
    End Sub

    Public Sub AppointmentsSetupDataGrid()
        dgvAppointments.AllowUserToAddRows = False
        dgvAppointments.AllowUserToDeleteRows = False
        dgvAppointments.ReadOnly = False
        dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAppointments.MultiSelect = False
        dgvAppointments.BackgroundColor = Color.White
        dgvAppointments.BorderStyle = BorderStyle.None
        dgvAppointments.RowHeadersVisible = False
        dgvAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvAppointments.GridColor = Color.LightGray
        dgvAppointments.ColumnHeadersVisible = True

        dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvAppointments.ColumnHeadersHeight = 40
        dgvAppointments.ColumnHeadersDefaultCellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
        dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvAppointments.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

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

        Dim patientNameColumn As New DataGridViewTextBoxColumn()
        patientNameColumn.HeaderText = "Patient Name"
        patientNameColumn.Name = "PatientName"
        patientNameColumn.MinimumWidth = 150
        patientNameColumn.FillWeight = 20
        patientNameColumn.ReadOnly = True
        dgvAppointments.Columns.Add(patientNameColumn)

        Dim doctorNameColumn As New DataGridViewTextBoxColumn()
        doctorNameColumn.HeaderText = "Doctor"
        doctorNameColumn.Name = "DoctorName"
        doctorNameColumn.MinimumWidth = 120
        doctorNameColumn.FillWeight = 15
        doctorNameColumn.ReadOnly = True
        dgvAppointments.Columns.Add(doctorNameColumn)

        Dim appointmentDateColumn As New DataGridViewTextBoxColumn()
        appointmentDateColumn.HeaderText = "Date"
        appointmentDateColumn.Name = "AppointmentDate"
        appointmentDateColumn.MinimumWidth = 120
        appointmentDateColumn.FillWeight = 15
        appointmentDateColumn.ReadOnly = True
        dgvAppointments.Columns.Add(appointmentDateColumn)

        Dim reasonColumn As New DataGridViewTextBoxColumn()
        reasonColumn.HeaderText = "Reason for Visit"
        reasonColumn.Name = "Reason"
        reasonColumn.MinimumWidth = 150
        reasonColumn.FillWeight = 20
        reasonColumn.ReadOnly = True
        dgvAppointments.Columns.Add(reasonColumn)

        Dim statusColumn As New DataGridViewTextBoxColumn()
        statusColumn.HeaderText = "Status"
        statusColumn.Name = "Status"
        statusColumn.MinimumWidth = 100
        statusColumn.FillWeight = 10
        statusColumn.ReadOnly = True
        dgvAppointments.Columns.Add(statusColumn)

        Dim completeButtonColumn As New DataGridViewButtonColumn()
        completeButtonColumn.HeaderText = "Action"
        completeButtonColumn.Name = "CompleteButton"
        completeButtonColumn.Text = "Complete"
        completeButtonColumn.UseColumnTextForButtonValue = False
        completeButtonColumn.FlatStyle = FlatStyle.Flat
        completeButtonColumn.MinimumWidth = 80
        completeButtonColumn.FillWeight = 12
        dgvAppointments.Columns.Add(completeButtonColumn)

        ' Add hidden column for appointment ID
        Dim appointmentIDColumn As New DataGridViewTextBoxColumn()
        appointmentIDColumn.HeaderText = "ID"
        appointmentIDColumn.Name = "AppointmentID"
        appointmentIDColumn.Visible = False
        dgvAppointments.Columns.Add(appointmentIDColumn)

        ' Add hidden column for raw appointment date
        Dim rawDateColumn As New DataGridViewTextBoxColumn()
        rawDateColumn.HeaderText = "RawDate"
        rawDateColumn.Name = "RawDate"
        rawDateColumn.Visible = False
        dgvAppointments.Columns.Add(rawDateColumn)

        ' Add event handlers
        AddHandler dgvAppointments.DataBindingComplete, AddressOf dgvAppointments_DataBindingComplete
        AddHandler dgvAppointments.CellClick, AddressOf dgvAppointments_CellClick
        AddHandler dgvAppointments.CellFormatting, AddressOf dgvAppointments_CellFormatting
    End Sub

    Public Sub AppointmentsPopulateDataGrid()
        dgvAppointments.Rows.Clear()

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
    SELECT 
        a.appointment_id AS AppointmentID,
        CONCAT(p.first_name, ' ', p.last_name) AS PatientName,
        CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS DoctorName,
        a.appointment_date AS RawDate,
        DATE_FORMAT(a.appointment_date, '%b %d, %Y %h:%i %p') AS AppointmentDate,
        a.reason_for_visit AS Reason,
        a.status AS Status
    FROM 
        appointment_table a
    LEFT JOIN 
        patient p ON a.patient_id = p.patient_id
    LEFT JOIN 
        doctor d ON a.doctor_id = d.doctor_id
    WHERE
        a.doctor_id = @doctorID
    ORDER BY 
        a.appointment_date DESC"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@doctorID", doctorID)
                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    Dim today As DateTime = DateTime.Today
                    Dim yesterday As DateTime = today.AddDays(-1)

                    While reader.Read()
                        Dim appointmentID As String = reader("AppointmentID").ToString()
                        Dim patientName As String = reader("PatientName").ToString()
                        Dim doctorName As String = reader("DoctorName").ToString()
                        Dim appointmentDate As String = reader("AppointmentDate").ToString()
                        Dim reason As String = reader("Reason").ToString()
                        Dim status As String = reader("Status").ToString()
                        Dim rawDate As DateTime = Convert.ToDateTime(reader("RawDate"))

                        Dim rowIndex As Integer = dgvAppointments.Rows.Add(
                        patientName,
                        doctorName,
                        appointmentDate,
                        reason,
                        status,
                        "",
                        appointmentID,
                        rawDate)
                        Dim row As DataGridViewRow = dgvAppointments.Rows(rowIndex)
                        row.Tag = New Dictionary(Of String, Object) From {
                        {"AppointmentDate", rawDate},
                        {"Status", status}
                    }
                    End While
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching appointment data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub dgvAppointments_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If dgvAppointments.DisplayedRowCount(True) < dgvAppointments.RowCount Then
            dgvAppointments.PerformLayout()
        End If
    End Sub

    Private Sub dgvAppointments_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvAppointments.Rows(e.RowIndex)

            If e.ColumnIndex = dgvAppointments.Columns("Status").Index Then
                If e.Value IsNot Nothing Then
                    Dim status As String = e.Value.ToString().ToLower()
                    If status = "completed" Then
                        e.CellStyle.ForeColor = Color.Green
                        e.CellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
                    ElseIf status = "cancelled" Then
                        e.CellStyle.ForeColor = Color.Red
                        e.CellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
                    ElseIf status = "scheduled" Then
                        e.CellStyle.ForeColor = Color.Blue
                        e.CellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
                    End If
                End If
            End If

            If e.ColumnIndex = dgvAppointments.Columns("CompleteButton").Index Then
                Dim cell As DataGridViewButtonCell = TryCast(row.Cells(e.ColumnIndex), DataGridViewButtonCell)
                If cell IsNot Nothing Then
                    Dim rowData As Dictionary(Of String, Object) = TryCast(row.Tag, Dictionary(Of String, Object))
                    If rowData IsNot Nothing Then
                        Dim status As String = rowData("Status").ToString().ToLower()
                        Dim appointmentDate As DateTime = CType(rowData("AppointmentDate"), DateTime)

                        Dim today As DateTime = DateTime.Today
                        Dim yesterday As DateTime = today.AddDays(-1)
                        Dim appointmentDay As DateTime = appointmentDate.Date

                        If status = "scheduled" AndAlso (appointmentDay = today OrElse appointmentDay = yesterday) Then
                            cell.Value = "Complete"
                            cell.Style.BackColor = Color.FromArgb(245, 245, 245)
                            cell.Style.ForeColor = Color.Blue
                            cell.Style.SelectionForeColor = Color.Blue
                            row.Cells(e.ColumnIndex).ReadOnly = False
                        Else
                            cell.Value = ""
                            cell.Style.BackColor = Color.White
                            row.Cells(e.ColumnIndex).ReadOnly = True
                        End If
                    End If
                End If
            End If

            If e.ColumnIndex = dgvAppointments.Columns("PatientName").Index Then
                e.CellStyle.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub dgvAppointments_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvAppointments.Columns("CompleteButton").Index Then
            Dim row As DataGridViewRow = dgvAppointments.Rows(e.RowIndex)
            Dim cell As DataGridViewButtonCell = TryCast(row.Cells(e.ColumnIndex), DataGridViewButtonCell)
            If cell IsNot Nothing AndAlso cell.Value IsNot Nothing AndAlso cell.Value.ToString() = "Complete" Then
                Dim appointmentID As String = row.Cells("AppointmentID").Value.ToString()
                Dim patientName As String = row.Cells("PatientName").Value.ToString()

                If MessageBox.Show($"Mark appointment with {patientName} as completed?",
                               "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    UpdateAppointmentStatus(appointmentID, "Completed")

                    row.Cells("Status").Value = "Completed"

                    cell.Value = ""

                    Dim rowData As Dictionary(Of String, Object) = TryCast(row.Tag, Dictionary(Of String, Object))
                    If rowData IsNot Nothing Then
                        rowData("Status") = "Completed"
                    End If

                    dgvAppointments.InvalidateRow(e.RowIndex)
                End If
            End If
        End If
    End Sub

    Private Sub UpdateAppointmentStatus(appointmentID As String, status As String)
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim query As String = "UPDATE appointment_table SET status = @status WHERE appointment_id = @appointmentID"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@status", status)
                command.Parameters.AddWithValue("@appointmentID", appointmentID)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        MessageBox.Show("Failed to update appointment status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error updating appointment status: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ShowPanel(panelToShow As Panel, activeButton As Button)
        ' Hide all panels
        pnlDashboard.Visible = False
        pnlPatients.Visible = False
        pnlAppointments.Visible = False

        ' Show the selected panel
        panelToShow.Visible = True

        ' Reset all button styles
        ResetButtonStyles()

        ' Highlight the active button
        activeButton.BackColor = Color.LightBlue
        activeButton.ForeColor = Color.White
    End Sub

    Private Sub ResetButtonStyles()
        ' Reset the styles of all buttons
        btnDashboard.BackColor = Color.Transparent
        btnDashboard.ForeColor = Color.Black

        btnPatients.BackColor = Color.Transparent
        btnPatients.ForeColor = Color.Black

        btnAppointments.BackColor = Color.Transparent
        btnAppointments.ForeColor = Color.Black

    End Sub

    Private Sub DoctorDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim loginForm = New Form1()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowPanel(pnlDashboard, btnDashboard)
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        ShowPanel(pnlPatients, btnPatients)
    End Sub

    Private Sub btnAppointments_Click(sender As Object, e As EventArgs) Handles btnAppointments.Click
        ShowPanel(pnlAppointments, btnAppointments)
    End Sub
End Class