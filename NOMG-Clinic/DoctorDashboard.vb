Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class DoctorDashboard
    Public doctorID As String
    Private errorProvider As New ErrorProvider()
    Private activeDropdownPatients As Panel = Nothing

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

        ' Load doctor for settings 
        LoadDoctorInfo()

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

        Dim query As String = "SELECT a.appointment_id, a.patient_id, a.appointment_date, a.appointment_time, a.reason_for_visit, " &
"CONCAT(p.first_name, ' ', p.last_name) AS patient_name, " &
"CONCAT(d.first_name, ' ', d.last_name) AS doctor_name " &
"FROM appointment_table a " &
"JOIN patient p ON a.patient_id = p.patient_id " &
"JOIN doctor d ON a.doctor_id = d.doctor_id " &
"WHERE a.doctor_id = @doctorID AND DATE(a.appointment_date) = CURDATE() " &
"ORDER BY a.appointment_time ASC"

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

                        Dim appointmentTime As DateTime
                        Dim formattedTime As String = "No time set"

                        If DateTime.TryParse(reader("appointment_time").ToString(), appointmentTime) Then
                            formattedTime = appointmentTime.ToString("h:mm tt")
                        End If

                        ' Create appointment panel
                        Dim appointmentPanel As Panel = CreateAppointmentPanel(
                        reader("patient_name").ToString(),
                        formattedTime,
                        reader("reason_for_visit").ToString()
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

        Dim query As String = "SELECT a.appointment_id, a.patient_id, a.appointment_date, a.reason_for_visit, a.appointment_time, " &
                             "CONCAT(p.first_name, ' ', p.last_name) AS patient_name, " &
                             "CONCAT(d.first_name, ' ', d.last_name) AS doctor_name " &
                             "FROM appointment_table a " &
                             "JOIN patient p ON a.patient_id = p.patient_id " &
                             "JOIN doctor d ON a.doctor_id = d.doctor_id " &
                             "WHERE a.doctor_id = @doctorID " &
                             "AND DATE(a.appointment_date) < CURDATE() " &
                             "AND DATE(a.appointment_date) >= DATE_SUB(CURDATE(), INTERVAL 7 DAY) " &
                             "ORDER BY a.appointment_time ASC"

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
                        Dim appointmentTime As DateTime
                        Dim formattedTime As String = "No time set"

                        If DateTime.TryParse(reader("appointment_time").ToString(), appointmentTime) Then
                            formattedTime = appointmentTime.ToString("h:mm tt")
                        End If


                        Dim appointmentPanel As Panel = CreateAppointmentPanel(
                            reader("patient_name").ToString(),
                            formattedTime,
                            reader("reason_for_visit").ToString()
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

    Private Function CreateAppointmentPanel(patientName As String, appointmentDateTime As String, reason As String) As Panel
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

    ''''''''''''''''''''''''''''''''''
    '                                '
    ' patients data grid view setup  '
    '                                '
    ''''''''''''''''''''''''''''''''''
    ' Setup dgvPatients
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
        dgvPatients.ColumnHeadersHeight = 50
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

        Dim nameColumn As New DataGridViewTextBoxColumn()
        nameColumn.HeaderText = "Name"
        nameColumn.Name = "Name"
        nameColumn.MinimumWidth = 140
        nameColumn.FillWeight = 20
        dgvPatients.Columns.Add(nameColumn)

        Dim ageColumn As New DataGridViewTextBoxColumn()
        ageColumn.HeaderText = "Age"
        ageColumn.Name = "Age"
        ageColumn.MinimumWidth = 80
        ageColumn.FillWeight = 8
        ageColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPatients.Columns.Add(ageColumn)

        Dim gestationalAgeColumn As New DataGridViewTextBoxColumn()
        gestationalAgeColumn.HeaderText = "Gestational Age"
        gestationalAgeColumn.Name = "GestationalAge"
        gestationalAgeColumn.MinimumWidth = 50
        gestationalAgeColumn.FillWeight = 18
        gestationalAgeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPatients.Columns.Add(gestationalAgeColumn)

        Dim nextCheckupColumn As New DataGridViewTextBoxColumn()
        nextCheckupColumn.HeaderText = "Next Checkup"
        nextCheckupColumn.Name = "NextCheckup"
        nextCheckupColumn.MinimumWidth = 100
        nextCheckupColumn.FillWeight = 18
        dgvPatients.Columns.Add(nextCheckupColumn)

        Dim bloodTypeColumn As New DataGridViewTextBoxColumn()
        bloodTypeColumn.HeaderText = "Blood Type"
        bloodTypeColumn.Name = "BloodType"
        bloodTypeColumn.MinimumWidth = 100
        bloodTypeColumn.FillWeight = 10
        bloodTypeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPatients.Columns.Add(bloodTypeColumn)

        Dim firstBabyColumn As New DataGridViewTextBoxColumn()
        firstBabyColumn.HeaderText = "First Baby"
        firstBabyColumn.Name = "FirstBaby"
        firstBabyColumn.MinimumWidth = 100
        firstBabyColumn.FillWeight = 10
        firstBabyColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPatients.Columns.Add(firstBabyColumn)

        Dim fluVacColumn As New DataGridViewTextBoxColumn()
        fluVacColumn.HeaderText = "Flu Vac"
        fluVacColumn.Name = "FluVac"
        fluVacColumn.MinimumWidth = 90
        fluVacColumn.FillWeight = 10
        fluVacColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPatients.Columns.Add(fluVacColumn)

        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = ""
        buttonColumn.Name = "ActionButton"
        buttonColumn.Text = "..."
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Flat
        buttonColumn.MinimumWidth = 60
        buttonColumn.FillWeight = 8
        dgvPatients.Columns.Add(buttonColumn)

        AddHandler dgvPatients.DataBindingComplete, AddressOf dgvPatients_DataBindingComplete

        AddHandler dgvPatients.CellClick, AddressOf dgvPatients_CellClick
        AddHandler dgvPatients.CellFormatting, AddressOf dgvPatients_CellFormatting
    End Sub

    Private Sub dgvPatients_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If dgvPatients.DisplayedRowCount(True) < dgvPatients.RowCount Then
            Dim scrollWidth As Integer = SystemInformation.VerticalScrollBarWidth
            dgvPatients.PerformLayout()
        End If
    End Sub

    Private Sub dgvPatients_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvPatients.Rows(e.RowIndex)

            If e.ColumnIndex = dgvPatients.Columns("ActionButton").Index Then
                Dim cell As DataGridViewButtonCell = DirectCast(row.Cells(e.ColumnIndex), DataGridViewButtonCell)
                cell.Style.BackColor = Color.White
                cell.Style.ForeColor = Color.FromArgb(100, 100, 100)
            End If

            If e.ColumnIndex = dgvPatients.Columns("Name").Index Then
                Dim cell As DataGridViewCell = row.Cells(e.ColumnIndex)
                cell.Style.Font = New Font(dgvPatients.Font, FontStyle.Bold)
            End If
        End If
    End Sub

    ' Populate the dgvPatients
    Public Sub PatientsPopulateDataGrid()
        If dgvPatients.Columns.Count = 0 Then
            PatientsSetupDataGrid()
        End If
        dgvPatients.Rows.Clear()

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String =
        "SELECT 
            CONCAT(p.first_name, ' ', p.last_name) AS Name, 
            p.age, 
            TIMESTAMPDIFF(WEEK, STR_TO_DATE(p.last_menstrual_period, '%Y-%m-%d'), CURDATE()) AS GestationalAge, 
            DATE_FORMAT(p.next_checkup, '%b %d, %Y') AS NextCheckup, 
            CASE WHEN p.first_baby = 1 THEN 'Yes' ELSE 'No' END AS FirstBaby,
            CASE WHEN p.flu_vac = 1 THEN 'Yes' ELSE 'No' END AS FluVac,
            p.blood_type AS BloodType
        FROM 
            patient p
        WHERE 
            p.assigned_ob = @doctorID
        ORDER BY 
            p.last_name, p.first_name"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@doctorID", doctorID)
                Try
                    connection.Open()
                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    For Each row As DataRow In dataTable.Rows
                        dgvPatients.Rows.Add(row("Name"), row("Age"), row("GestationalAge"), row("NextCheckup"), row("BloodType"), row("FirstBaby"), row("FluVac"))
                    Next
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching patient data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub dgvPatients_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = dgvPatients.Columns("ActionButton").Index And e.RowIndex >= 0 Then
            CloseDropdownPatients()

            ShowDropdownPatientsMenu(e.RowIndex)
        ElseIf activeDropdownPatients IsNot Nothing Then
            CloseDropdownPatients()
        End If
    End Sub

    ' Add dropdown menu
    Private Sub ShowDropdownPatientsMenu(rowIndex As Integer)
        Dim buttonColumnIndex As Integer = dgvPatients.Columns("ActionButton").Index
        Dim buttonCell = dgvPatients.Rows(rowIndex).Cells(buttonColumnIndex)

        activeDropdownPatients = New Panel With {
        .BorderStyle = BorderStyle.FixedSingle,
        .BackColor = Color.White,
        .Size = New Size(200, 100)
    }

        Dim cellRect = dgvPatients.GetCellDisplayRectangle(buttonColumnIndex, rowIndex, False)
        Dim screenPoint = dgvPatients.PointToScreen(New Point(cellRect.Right, cellRect.Bottom))
        Dim formPoint = Me.PointToClient(screenPoint)

        Dim dropdownX = formPoint.X - activeDropdownPatients.Width
        Dim dropdownY = formPoint.Y

        If dropdownY + activeDropdownPatients.Height > Me.ClientSize.Height Then
            dropdownY = Me.PointToClient(dgvPatients.PointToScreen(New Point(cellRect.Right, cellRect.Top))).Y - activeDropdownPatients.Height
        End If

        If dropdownX < 0 Then dropdownX = 0
        If dropdownX + activeDropdownPatients.Width > Me.ClientSize.Width Then
            dropdownX = Me.ClientSize.Width - activeDropdownPatients.Width
        End If

        If dropdownY < 0 Then dropdownY = 0

        activeDropdownPatients.Location = New Point(dropdownX, dropdownY)

        Dim lblTitle As New Label With {
        .Text = "Actions",
        .Font = New Font(dgvPatients.Font.FontFamily, 10, FontStyle.Bold),
        .AutoSize = False,
        .Size = New Size(200, 30),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Padding = New Padding(10, 0, 0, 0)
    }
        activeDropdownPatients.Controls.Add(lblTitle)

        AddMenuOption("View patient details", rowIndex, 30)
        AddMenuOption("Edit patient", rowIndex, 60)

        Me.Controls.Add(activeDropdownPatients)
        activeDropdownPatients.BringToFront()
    End Sub


    Private Sub AddMenuOption(text As String, rowIndex As Integer, topPosition As Integer)
        Dim btn As New Button With {
        .Text = text,
        .FlatStyle = FlatStyle.Flat,
        .TextAlign = ContentAlignment.MiddleLeft,
        .Size = New Size(200, 30),
        .Location = New Point(0, topPosition),
        .BackColor = Color.White,
        .Padding = New Padding(10, 0, 0, 0),
        .Tag = rowIndex
    }
        btn.FlatAppearance.BorderSize = 0

        AddHandler btn.Click, AddressOf MenuOption_Click
        AddHandler btn.MouseEnter, AddressOf MenuOption_MouseEnter
        AddHandler btn.MouseLeave, AddressOf MenuOption_MouseLeave

        activeDropdownPatients.Controls.Add(btn)
    End Sub

    Private Sub MenuOption_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim rowIndex = CInt(btn.Tag)
        Dim patientName = dgvPatients.Rows(rowIndex).Cells("Name").Value.ToString()
        Dim patientId As String = GetPatientIdByName(patientName)
        Select Case btn.Text

            Case "View patient details"

                If Not String.IsNullOrEmpty(patientId) Then
                    Dim patientDetailsForm As New PatientDetails()
                    patientDetailsForm.patientID = patientId
                    patientDetailsForm.ShowDialog()
                Else
                    MessageBox.Show("Could not retrieve patient details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Case "Edit patient"
                If Not String.IsNullOrEmpty(patientId) Then
                    Dim editPatientDetailsForm As New EditPatientDetails()
                    editPatientDetailsForm.PatientID = patientId
                    editPatientDetailsForm.ShowDialog()
                Else
                    MessageBox.Show("Could not retrieve patient details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
        End Select

        CloseDropdownPatients()
    End Sub

    ' Method to get patient details for appointment scheduling
    Private Function GetPatientDetailsForAppointment(patientId As String, ByRef firstName As String, ByRef lastName As String,
        ByRef lastMenstrualDate As Date, ByRef dueDate As Date, ByRef doctorId As String) As Boolean
        Dim success As Boolean = False

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "SELECT first_name, last_name, last_menstrual_period, due_date, assigned_ob FROM patient WHERE patient_id = @patientId"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@patientId", patientId)
                Try
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            firstName = reader("first_name").ToString()
                            lastName = reader("last_name").ToString()

                            If Not reader.IsDBNull(reader.GetOrdinal("last_menstrual_period")) Then
                                lastMenstrualDate = Convert.ToDateTime(reader("last_menstrual_period"))
                            End If

                            If Not reader.IsDBNull(reader.GetOrdinal("due_date")) Then
                                dueDate = Convert.ToDateTime(reader("due_date"))
                            End If

                            doctorId = reader("assigned_ob").ToString()
                            success = True
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error retrieving patient details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
        Return success
    End Function

    ' Method to get patient ID by patient name
    Private Function GetPatientIdByName(patientName As String) As String
        Dim patientId As String = String.Empty

        Dim names As String() = patientName.Trim().Split(" "c)
        If names.Length < 2 Then
            Return String.Empty
        End If

        Dim firstName As String = names(0)
        Dim lastName As String = names(names.Length - 1)

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "SELECT patient_id FROM patient WHERE first_name = @firstName AND last_name = @lastName LIMIT 1"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Try 1: Exact match
                Using command As New MySqlCommand("SELECT patient_id FROM patient WHERE first_name = @firstName AND last_name = @lastName LIMIT 1", connection)
                    command.Parameters.AddWithValue("@firstName", firstName)
                    command.Parameters.AddWithValue("@lastName", lastName)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return result.ToString()
                    End If
                End Using

                ' Try 2: Case insensitive match
                Using command As New MySqlCommand("SELECT patient_id FROM patient WHERE LOWER(first_name) = LOWER(@firstName) AND LOWER(last_name) = LOWER(@lastName) LIMIT 1", connection)
                    command.Parameters.AddWithValue("@firstName", firstName)
                    command.Parameters.AddWithValue("@lastName", lastName)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return result.ToString()
                    End If
                End Using

                ' Try 3: Partial match
                Using command As New MySqlCommand("SELECT patient_id FROM patient WHERE first_name LIKE @firstName AND last_name LIKE @lastName LIMIT 1", connection)
                    command.Parameters.AddWithValue("@firstName", firstName + "%")  ' Match first name starting with
                    command.Parameters.AddWithValue("@lastName", lastName)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return result.ToString()
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("Error retrieving patient ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return patientId
    End Function

    Private Sub MenuOption_MouseEnter(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        btn.BackColor = Color.LightGray
    End Sub

    Private Sub MenuOption_MouseLeave(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        btn.BackColor = Color.White
    End Sub

    Private Sub CloseDropdownPatients()
        If activeDropdownPatients IsNot Nothing Then
            Me.Controls.Remove(activeDropdownPatients)
            activeDropdownPatients.Dispose()
            activeDropdownPatients = Nothing
        End If
    End Sub

    Private Sub CloseDropdownPatientsHandler(sender As Object, e As EventArgs) Handles dgvPatients.Click, Panel1.Click, pnlPatients.Click, btnDashboard.Click, btnPatients.Click, btnAppointments.Click, txtSearchPatient.Click, Label5.Click
        CloseDropdownPatients()
    End Sub
    Private Sub txtSearchPatient_TextChanged_1(sender As Object, e As EventArgs) Handles txtSearchPatient.TextChanged
        Dim searchText = txtSearchPatient.Text.Trim.ToLower

        For Each row As DataGridViewRow In dgvPatients.Rows
            Dim name = row.Cells("Name").Value.ToString.ToLower
            Dim assignedOB = row.Cells("AssignedOB").Value.ToString.ToLower

            If name.Contains(searchText) OrElse assignedOB.Contains(searchText) Then
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

        Dim appointmentDateColumn As New DataGridViewTextBoxColumn()
        appointmentDateColumn.HeaderText = "Date"
        appointmentDateColumn.Name = "AppointmentDate"
        appointmentDateColumn.MinimumWidth = 120
        appointmentDateColumn.FillWeight = 15
        appointmentDateColumn.ReadOnly = True
        dgvAppointments.Columns.Add(appointmentDateColumn)

        Dim timeColumn As New DataGridViewTextBoxColumn()
        timeColumn.HeaderText = "Time"
        timeColumn.Name = "Time"
        timeColumn.MinimumWidth = 120
        timeColumn.FillWeight = 15
        timeColumn.ReadOnly = True
        dgvAppointments.Columns.Add(timeColumn)

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

        ' Add hidden column for patient ID
        Dim patientIDColumn As New DataGridViewTextBoxColumn()
        patientIDColumn.HeaderText = "PatientID"
        patientIDColumn.Name = "PatientID"
        patientIDColumn.Visible = False
        dgvAppointments.Columns.Add(patientIDColumn)

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
            p.patient_id AS PatientID,
            CONCAT(p.first_name, ' ', p.last_name) AS PatientName,
            CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS DoctorName,
            a.appointment_date AS RawDate,
            DATE_FORMAT(a.appointment_date, '%b %d, %Y') AS AppointmentDate,
            a.reason_for_visit AS Reason,
            a.status AS Status,
            a.appointment_time as Time
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
                        Dim time As String = reader("Time").ToString()
                        Dim appointmentDate As String = reader("AppointmentDate").ToString()
                        Dim reason As String = reader("Reason").ToString()
                        Dim status As String = reader("Status").ToString()
                        Dim rawDate As DateTime = Convert.ToDateTime(reader("RawDate"))

                        Dim rowIndex As Integer = dgvAppointments.Rows.Add(
                            patientName,
                            appointmentDate,
                            time,
                            reason,
                            status,
                            "",
                            appointmentID,
                            rawDate,
                            reader("PatientID").ToString()
                        )

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
                        Dim appointmentDay As DateTime = appointmentDate.Date

                        If status = "scheduled" AndAlso appointmentDay <= today Then
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
                Dim patientID As String = row.Cells("PatientID").Value.ToString()
                Dim patientName As String = row.Cells("PatientName").Value.ToString()

                If MessageBox.Show($"Proceed to consultation details for {patientName}?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim consultationDetailsForm As New ConsultationDetails()
                    consultationDetailsForm.PatientID = patientID
                    consultationDetailsForm.AppointmentID = appointmentID
                    consultationDetailsForm.ShowDialog()

                    AppointmentsPopulateDataGrid()
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
        Panel4.Visible = False

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

        btnSettings.BackColor = Color.Transparent
        btnSettings.ForeColor = Color.Black

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

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ShowPanel(Panel4, btnSettings)
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrEmpty(email) Then
            Return False
        End If

        If Not email.Contains("@") OrElse Not email.Contains(".") Then
            Return False
        End If

        Dim parts As String() = email.Split("@"c)
        If parts.Length <> 2 Then
            Return False
        End If

        Dim domainParts As String() = parts(1).Split("."c)
        If domainParts.Length < 2 OrElse String.IsNullOrEmpty(domainParts(0)) OrElse String.IsNullOrEmpty(domainParts(1)) Then
            Return False
        End If

        ' Use Regex for more complete validation
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        Return Regex.IsMatch(email, emailPattern)
    End Function

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        If txtPassword.Text <> txtConfirmPassword.Text Then
            errorProvider.SetError(txtConfirmPassword, "Passwords do not match")
        Else
            errorProvider.SetError(txtConfirmPassword, "")
        End If
    End Sub

    Private Sub txtContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtContactNumber.TextChanged
        If Not String.IsNullOrEmpty(txtContactNumber.Text) Then
            If Not IsNumeric(txtContactNumber.Text) OrElse txtContactNumber.Text.Contains(" ") Then
                errorProvider.SetError(txtContactNumber, "Contact number should contain only numbers")
            Else
                errorProvider.SetError(txtContactNumber, "")
            End If
        Else
            errorProvider.SetError(txtContactNumber, "")
        End If
    End Sub

    Private Sub txtEmailAddress_TextChanged(sender As Object, e As EventArgs) Handles txtEmailAddress.TextChanged
        If Not String.IsNullOrEmpty(txtEmailAddress.Text) Then
            If Not IsValidEmail(txtEmailAddress.Text) Then
                errorProvider.SetError(txtEmailAddress, "Please enter a valid email address")
            Else
                errorProvider.SetError(txtEmailAddress, "")
            End If
        Else
            errorProvider.SetError(txtEmailAddress, "")
        End If
    End Sub

    Private Sub txtContactNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNumber.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnEyePassword_Click(sender As Object, e As EventArgs) Handles btnEyePassword.Click
        txtPassword.UseSystemPasswordChar = Not txtPassword.UseSystemPasswordChar

        If txtPassword.UseSystemPasswordChar Then
            btnEyePassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        Else
            btnEyePassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
        End If
    End Sub

    Private Sub btnEyeConfirmPassword_Click(sender As Object, e As EventArgs) Handles btnEyeConfirmPassword.Click
        txtConfirmPassword.UseSystemPasswordChar = Not txtConfirmPassword.UseSystemPasswordChar

        If txtConfirmPassword.UseSystemPasswordChar Then
            btnEyeConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        Else
            btnEyeConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        errorProvider.Clear()

        Dim isValid As Boolean = True

        ' Validate all fields
        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            errorProvider.SetError(txtFirstName, "First name is required")
            isValid = False
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            errorProvider.SetError(txtLastName, "Last name is required")
            isValid = False
        End If

        If numAge.Value <= 0 Then
            errorProvider.SetError(numAge, "Please enter a valid age")
            isValid = False
        End If

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            errorProvider.SetError(txtUsername, "Username is required")
            isValid = False
        End If

        If Not String.IsNullOrEmpty(txtPassword.Text) Or Not String.IsNullOrEmpty(txtConfirmPassword.Text) Then
            If txtPassword.Text <> txtConfirmPassword.Text Then
                errorProvider.SetError(txtConfirmPassword, "Passwords do not match")
                isValid = False
            ElseIf txtPassword.Text.Length < 6 Then
                errorProvider.SetError(txtPassword, "Password must be at least 6 characters")
                isValid = False
            End If
        End If

        If Not String.IsNullOrEmpty(txtContactNumber.Text) Then
            If Not IsNumeric(txtContactNumber.Text) OrElse txtContactNumber.Text.Contains(" ") Then
                errorProvider.SetError(txtContactNumber, "Contact number should contain only numbers")
                isValid = False
            End If
        End If

        If Not String.IsNullOrEmpty(txtEmailAddress.Text) Then
            If Not IsValidEmail(txtEmailAddress.Text) Then
                errorProvider.SetError(txtEmailAddress, "Please enter a valid email address")
                isValid = False
            End If
        End If

        If Not isValid Then
            MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim oldUsername As String = GetCurrentUsername()

            UpdateDoctorInfo()

            If Not String.IsNullOrEmpty(oldUsername) Then
                UpdateUserInUsersTable(oldUsername)
            Else
                MessageBox.Show("Warning: Could not retrieve current username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            MessageBox.Show("Settings updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error updating settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateDoctorInfo()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Try
            Dim query As String
            If String.IsNullOrEmpty(txtPassword.Text) Then
                query = "UPDATE doctor SET 
                    first_name = @firstName, 
                    middle_name = @middleName, 
                    last_name = @lastName, 
                    age = @age, 
                    email = @email, 
                    contact_number = @contactNumber, 
                    address = @address, 
                    username = @username 
                    WHERE doctor_id = @doctorID"
            Else
                query = "UPDATE doctor SET 
                    first_name = @firstName, 
                    middle_name = @middleName, 
                    last_name = @lastName, 
                    age = @age, 
                    email = @email, 
                    contact_number = @contactNumber, 
                    address = @address, 
                    username = @username, 
                    password = @password 
                    WHERE doctor_id = @doctorID"
            End If

            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@firstName", txtFirstName.Text)
                    command.Parameters.AddWithValue("@middleName", If(String.IsNullOrEmpty(txtMiddleName.Text), DBNull.Value, txtMiddleName.Text))
                    command.Parameters.AddWithValue("@lastName", txtLastName.Text)
                    command.Parameters.AddWithValue("@age", numAge.Value)
                    command.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(txtEmailAddress.Text), DBNull.Value, txtEmailAddress.Text))
                    command.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrEmpty(txtContactNumber.Text), DBNull.Value, txtContactNumber.Text))
                    command.Parameters.AddWithValue("@address", If(String.IsNullOrEmpty(txtAddress.Text), DBNull.Value, txtAddress.Text))
                    command.Parameters.AddWithValue("@username", txtUsername.Text)
                    command.Parameters.AddWithValue("@doctorID", doctorID)

                    If Not String.IsNullOrEmpty(txtPassword.Text) Then
                        command.Parameters.AddWithValue("@password", txtPassword.Text)
                    End If

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected = 0 Then
                        Throw New Exception("No doctor records were updated. Please check if the doctor information exists.")
                    End If

                    Console.WriteLine($"Successfully updated doctor info. Rows affected: {rowsAffected}")
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error updating doctor: " & ex.Message & Environment.NewLine & "Error code: " & ex.Number, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        Catch ex As Exception
            Throw New Exception("Error updating doctor information: " & ex.Message, ex)
        End Try
    End Sub

    Private Sub UpdateUserInUsersTable(oldUsername As String)
        If String.IsNullOrEmpty(oldUsername) Then
            MessageBox.Show("Cannot update user record: old username is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Try
            Console.WriteLine($"Attempting to update user record from '{oldUsername}' to '{txtUsername.Text}'")
            Dim query As String
            If String.IsNullOrEmpty(txtPassword.Text) Then
                query = "UPDATE users SET username = @newUsername WHERE username = @oldUsername"
            Else
                query = "UPDATE users SET username = @newUsername, password = @password WHERE username = @oldUsername"
            End If

            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@newUsername", txtUsername.Text)
                    command.Parameters.AddWithValue("@oldUsername", oldUsername)

                    If Not String.IsNullOrEmpty(txtPassword.Text) Then
                        command.Parameters.AddWithValue("@password", txtPassword.Text)
                    End If

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    Console.WriteLine($"User update completed. Rows affected: {rowsAffected}")

                    If rowsAffected = 0 Then
                        If String.IsNullOrEmpty(txtPassword.Text) Then
                            MessageBox.Show("No user record was updated. You may need to enter a password to create a new user record.",
                                       "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            InsertUserRecord()
                        End If
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error updating user: " & ex.Message & Environment.NewLine & "Error code: " & ex.Number,
                       "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        Catch ex As Exception
            Throw New Exception("Error updating user: " & ex.Message, ex)
        End Try
    End Sub

    Private Sub InsertUserRecord()
        If String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Password is required to create a new user record.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim insertQuery As String = "INSERT INTO users (username, password, role) VALUES (@username, @password, 'doctor')"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(insertQuery, connection)
                command.Parameters.AddWithValue("@username", txtUsername.Text)
                command.Parameters.AddWithValue("@password", txtPassword.Text)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function GetCurrentUsername() As String
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim query As String = "SELECT username FROM doctor WHERE doctor_id = @doctorID"
        Dim username As String = String.Empty

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@doctorID", doctorID)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot Nothing Then
                    username = result.ToString()
                End If
            End Using
        End Using

        Return username
    End Function

    Private Sub LoadDoctorInfo()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim query As String = "SELECT first_name, middle_name, last_name, age, username, " &
                          "email, contact_number, address " &
                          "FROM doctor WHERE doctor_id = @doctorID"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@doctorID", doctorID)

                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        txtFirstName.Text = If(reader.IsDBNull(reader.GetOrdinal("first_name")), "", reader("first_name").ToString())
                        txtMiddleName.Text = If(reader.IsDBNull(reader.GetOrdinal("middle_name")), "", reader("middle_name").ToString())
                        txtLastName.Text = If(reader.IsDBNull(reader.GetOrdinal("last_name")), "", reader("last_name").ToString())
                        numAge.Value = If(reader.IsDBNull(reader.GetOrdinal("age")), 0, Convert.ToInt32(reader("age")))
                        txtUsername.Text = If(reader.IsDBNull(reader.GetOrdinal("username")), "", reader("username").ToString())
                        txtEmailAddress.Text = If(reader.IsDBNull(reader.GetOrdinal("email")), "", reader("email").ToString())
                        txtContactNumber.Text = If(reader.IsDBNull(reader.GetOrdinal("contact_number")), "", reader("contact_number").ToString())
                        txtAddress.Text = If(reader.IsDBNull(reader.GetOrdinal("address")), "", reader("address").ToString())
                    End If
                End Using
            End Using
        End Using
    End Sub
End Class