Imports MySql.Data.MySqlClient

Public Class NurseDashboard
    Public nurseID As String
    Private activeDropdownPatients As Panel = Nothing
    Private activeDropdownAppointments As Panel = Nothing
    Private errorProvider As New ErrorProvider()

    Private Sub NurseDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabDashboard.ItemSize = New Size(tabDashboard.Width \ tabDashboard.TabCount - 2, 30)
        ShowPanel(pnlDashboard, btnDashboard)



        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        PopulateRecentAppointments(connectionString)
        PopulateScheduledToday(connectionString)


        PatientsSetupDataGrid()
        PatientsPopulateDataGrid()

        AppointmentsSetupDataGrid()
        AppointmentsPopulateDataGrid()

        ' Load nurse profile for settings
        LoadNurseProfile()

        UpdateWelcomeMessage()

        ' Dashboard details
        Dim totalPatients As Integer = 0
        Dim totalAppointmentsToday As Integer = 0
        Dim totalDoctors As Integer = 0

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Dim queryPatients As String = "SELECT COUNT(*) FROM patient"
                Using command As New MySqlCommand(queryPatients, connection)
                    totalPatients = Convert.ToInt32(command.ExecuteScalar())
                End Using

                Dim queryAppointments As String = "SELECT COUNT(*) FROM appointment_table WHERE appointment_date = CURDATE()"
                Using command As New MySqlCommand(queryAppointments, connection)
                    totalAppointmentsToday = Convert.ToInt32(command.ExecuteScalar())
                End Using

                Dim queryDoctors As String = "SELECT COUNT(*) FROM doctor"
                Using command As New MySqlCommand(queryDoctors, connection)
                    totalDoctors = Convert.ToInt32(command.ExecuteScalar())
                End Using

            Catch ex As Exception
                MessageBox.Show("An error occurred while fetching dashboard counts: " & ex.Message)
            End Try
        End Using

        lblTotalPatients.Text = totalPatients.ToString()
        lblTodaysAppointments.Text = totalAppointmentsToday.ToString()
        lblActiveDoctors.Text = totalDoctors.ToString()
    End Sub

    Private Sub UpdateWelcomeMessage()
        Dim query As String = "SELECT CONCAT('Welcome back, Nrs. ', first_name, ' ', last_name) FROM nurse WHERE nurse_id = @nurseID"
        Dim welcomeMessage As String = ExecuteStringQuery(query, New MySqlParameter("@nurseID", nurseID))

        If String.IsNullOrEmpty(welcomeMessage) Then
            lblWelcomeMessage.Text = "Welcome back, Nurse"
        Else
            lblWelcomeMessage.Text = welcomeMessage
        End If
    End Sub

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

    Private Sub PopulateRecentAppointments(connectionString As String)
        flowRecentAppointments.Controls.Clear()

        Dim query As String = "
        SELECT 
            CONCAT(p.first_name, ' ', p.last_name) AS PatientName,
            CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS DoctorName,
            a.appointment_date AS AppointmentDate,
            a.reason_for_visit AS Reason
        FROM 
            appointment_table a
        LEFT JOIN 
            patient p ON a.patient_id = p.patient_id
        LEFT JOIN 
            doctor d ON a.doctor_id = d.doctor_id
        WHERE 
            a.appointment_date < CURDATE() AND a.appointment_date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
        ORDER BY 
            a.appointment_date DESC"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim hasPastAppointments As Boolean = False

                        While reader.Read()
                            hasPastAppointments = True

                            Dim patientName As String = reader("PatientName").ToString()
                            Dim doctorName As String = reader("DoctorName").ToString()
                            Dim appointmentDate As Date = Convert.ToDateTime(reader("AppointmentDate"))
                            Dim reason As String = reader("Reason").ToString()

                            Dim item As New AppointmentItem(patientName.Substring(0, 2).ToUpper(), patientName, appointmentDate.ToString("hh:mm tt"), reason, doctorName)
                            item.Margin = New Padding(0, 5, 0, 5)
                            SetItemWidth(item)

                            flowRecentAppointments.Controls.Add(item)
                        End While

                        If Not hasPastAppointments Then
                            Dim noAppointmentsLabel As New Label With {
                            .Text = "No past appointments in the last 30 days.",
                            .Font = New Font("Verdana", 10, FontStyle.Italic),
                            .ForeColor = Color.Gray,
                            .AutoSize = True,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Margin = New Padding(10)
                        }
                            flowRecentAppointments.Controls.Add(noAppointmentsLabel)
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching past appointments: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub flowRecentAppointments_Resize(sender As Object, e As EventArgs) Handles flowRecentAppointments.Resize
        For Each ctrl As Control In flowRecentAppointments.Controls
            SetItemWidth(ctrl)
        Next
    End Sub

    Private Sub SetItemWidth(ctrl As Control)
        Dim paddingWidth As Integer = flowRecentAppointments.Padding.Left + flowRecentAppointments.Padding.Right
        ctrl.Width = flowRecentAppointments.ClientSize.Width - paddingWidth
    End Sub

    ' Populate scheduled today
    Private Sub PopulateScheduledToday(connectionString As String)
        flowScheduledToday.Controls.Clear()

        Dim query As String = "
    SELECT 
        CONCAT(p.first_name, ' ', p.last_name) AS PatientName,
        CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS DoctorName,
        a.appointment_date AS AppointmentDate,
        a.reason_for_visit AS Reason
    FROM 
        appointment_table a
    LEFT JOIN 
        patient p ON a.patient_id = p.patient_id
    LEFT JOIN 
        doctor d ON a.doctor_id = d.doctor_id
    WHERE 
        DATE(a.appointment_date) = CURDATE() 
        AND a.status = 'scheduled'
    ORDER BY 
        a.appointment_date ASC"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim hasTodayAppointments As Boolean = False

                        While reader.Read()
                            hasTodayAppointments = True

                            Dim patientName As String = reader("PatientName").ToString()
                            Dim doctorName As String = reader("DoctorName").ToString()
                            Dim appointmentDate As Date = Convert.ToDateTime(reader("AppointmentDate"))
                            Dim reason As String = reader("Reason").ToString()

                            ' Create initials from the first two characters of the patient name
                            Dim initials As String = patientName.Substring(0, Math.Min(2, patientName.Length)).ToUpper()

                            Dim item As New AppointmentItem(initials, patientName, appointmentDate.ToString("hh:mm tt"), reason, doctorName)
                            item.Margin = New Padding(0, 5, 0, 5)
                            SetItemWidth(item)

                            flowScheduledToday.Controls.Add(item)
                        End While

                        If Not hasTodayAppointments Then
                            Dim noAppointmentsLabel As New Label With {
                            .Text = "No appointments scheduled for today.",
                            .Font = New Font("Verdana", 10, FontStyle.Italic),
                            .ForeColor = Color.Gray,
                            .AutoSize = True,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Margin = New Padding(10)
                        }
                            flowScheduledToday.Controls.Add(noAppointmentsLabel)
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching today's appointments: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub flowScheduledToday_Resize(sender As Object, e As EventArgs) Handles flowScheduledToday.Resize
        For Each ctrl As Control In flowScheduledToday.Controls
            SetItemWidth(ctrl)
        Next
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
        ShowPanel(pnlSettings, btnSettings)
    End Sub

    Private Sub btnEyePassword_Click(sender As Object, e As EventArgs) Handles btnEyePassword.Click
        txtPassword.UseSystemPasswordChar = Not txtPassword.UseSystemPasswordChar

        If txtPassword.UseSystemPasswordChar Then
            btnEyePassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        Else
            btnEyePassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
        End If
    End Sub

    Private Sub ShowPanel(panelToShow As Panel, activeButton As Button)
        ' Hide all panels
        pnlDashboard.Visible = False
        pnlPatients.Visible = False
        pnlAppointments.Visible = False
        pnlSettings.Visible = False

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

    Private Sub btnEyeConfirmPassword_Click(sender As Object, e As EventArgs) Handles btnEyeConfirmPassword.Click
        txtConfirmPassword.UseSystemPasswordChar = Not txtConfirmPassword.UseSystemPasswordChar

        If txtConfirmPassword.UseSystemPasswordChar Then
            btnEyeConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        Else
            btnEyeConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
        End If
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
        gestationalAgeColumn.MinimumWidth = 120
        gestationalAgeColumn.FillWeight = 18
        gestationalAgeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPatients.Columns.Add(gestationalAgeColumn)

        Dim assignedOBColumn As New DataGridViewTextBoxColumn()
        assignedOBColumn.HeaderText = "Assigned OB"
        assignedOBColumn.Name = "AssignedOB"
        assignedOBColumn.MinimumWidth = 130
        assignedOBColumn.FillWeight = 18
        dgvPatients.Columns.Add(assignedOBColumn)

        Dim nextCheckupColumn As New DataGridViewTextBoxColumn()
        nextCheckupColumn.HeaderText = "Next Checkup"
        nextCheckupColumn.Name = "NextCheckup"
        nextCheckupColumn.MinimumWidth = 130
        nextCheckupColumn.FillWeight = 18
        dgvPatients.Columns.Add(nextCheckupColumn)

        Dim firstBabyColumn As New DataGridViewTextBoxColumn()
        firstBabyColumn.HeaderText = "First Baby"
        firstBabyColumn.Name = "FirstBaby"
        firstBabyColumn.MinimumWidth = 100
        firstBabyColumn.FillWeight = 10
        firstBabyColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPatients.Columns.Add(firstBabyColumn)

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

        Dim query As String = "
        SELECT 
            CONCAT(p.first_name, ' ', p.last_name) AS Name, 
            p.age, 
            TIMESTAMPDIFF(WEEK, STR_TO_DATE(p.last_menstrual_period, '%Y-%m-%d'), CURDATE()) AS GestationalAge, 
            CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS AssignedOB, 
            DATE_FORMAT(p.next_checkup, '%b %d, %Y') AS NextCheckup, 
            CASE WHEN p.first_baby = 1 THEN 'Yes' ELSE 'No' END AS FirstBaby
        FROM 
            patient p
        LEFT JOIN 
            doctor d
        ON 
            p.assigned_ob = d.doctor_id"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    For Each row As DataRow In dataTable.Rows
                        dgvPatients.Rows.Add(row("Name"), row("Age"), row("GestationalAge"), row("AssignedOB"), row("NextCheckup"), row("FirstBaby"))
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
        Dim buttonCell = dgvPatients.Rows(rowIndex).Cells(6)

        activeDropdownPatients = New Panel With {
        .BorderStyle = BorderStyle.FixedSingle,
        .BackColor = Color.White,
        .Size = New Size(200, 100)
    }

        Dim cellRect = dgvPatients.GetCellDisplayRectangle(6, rowIndex, False)
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
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@firstName", firstName)
                command.Parameters.AddWithValue("@lastName", lastName)
                Try
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        patientId = result.ToString()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error retrieving patient ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
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
        Dim searchText As String = txtSearchPatient.Text.Trim().ToLower()

        For Each row As DataGridViewRow In dgvPatients.Rows
            Dim name As String = row.Cells("Name").Value.ToString().ToLower()
            Dim assignedOB As String = row.Cells("AssignedOB").Value.ToString().ToLower()

            If name.Contains(searchText) OrElse assignedOB.Contains(searchText) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next
    End Sub

    Private Sub btnAddPatient_Click(sender As Object, e As EventArgs) Handles btnAddPatient.Click
        Dim PatientRegistrationForm As New PatientRegistration
        PatientRegistrationForm.Show()
    End Sub

    '''''''''''''''''''''''''''''''''''''
    '                                   '
    ' appointments data grid view setup '
    '                                   '
    '''''''''''''''''''''''''''''''''''''

    ' Setup dgvAppointments
    Public Sub AppointmentsSetupDataGrid()
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

        Dim appointmentIDColumn As New DataGridViewTextBoxColumn()
        appointmentIDColumn.HeaderText = "ID"
        appointmentIDColumn.Name = "AppointmentID"
        appointmentIDColumn.MinimumWidth = 100
        appointmentIDColumn.FillWeight = 10
        dgvAppointments.Columns.Add(appointmentIDColumn)

        Dim patientNameColumn As New DataGridViewTextBoxColumn()
        patientNameColumn.HeaderText = "Patient Name"
        patientNameColumn.Name = "PatientName"
        patientNameColumn.MinimumWidth = 150
        patientNameColumn.FillWeight = 20
        dgvAppointments.Columns.Add(patientNameColumn)

        Dim doctorNameColumn As New DataGridViewTextBoxColumn()
        doctorNameColumn.HeaderText = "Doctor Name"
        doctorNameColumn.Name = "DoctorName"
        doctorNameColumn.MinimumWidth = 150
        doctorNameColumn.FillWeight = 20
        dgvAppointments.Columns.Add(doctorNameColumn)

        Dim appointmentDateColumn As New DataGridViewTextBoxColumn()
        appointmentDateColumn.HeaderText = "Date"
        appointmentDateColumn.Name = "AppointmentDate"
        appointmentDateColumn.MinimumWidth = 120
        appointmentDateColumn.FillWeight = 15
        dgvAppointments.Columns.Add(appointmentDateColumn)

        Dim reasonColumn As New DataGridViewTextBoxColumn()
        reasonColumn.HeaderText = "Reason for Visit"
        reasonColumn.Name = "Reason"
        reasonColumn.MinimumWidth = 150
        reasonColumn.FillWeight = 20
        dgvAppointments.Columns.Add(reasonColumn)

        Dim statusColumn As New DataGridViewTextBoxColumn()
        statusColumn.HeaderText = "Status"
        statusColumn.Name = "Status"
        statusColumn.MinimumWidth = 100
        statusColumn.FillWeight = 10
        dgvAppointments.Columns.Add(statusColumn)

        ' Patient ID column
        Dim patientIDColumn As New DataGridViewTextBoxColumn()
        patientIDColumn.HeaderText = "PatientID"
        patientIDColumn.Name = "PatientID"
        patientIDColumn.Visible = False
        dgvAppointments.Columns.Add(patientIDColumn)

        ' View button
        Dim viewButtonColumn As New DataGridViewButtonColumn()
        viewButtonColumn.HeaderText = ""
        viewButtonColumn.Name = "ViewButton"
        viewButtonColumn.Text = "View"
        viewButtonColumn.UseColumnTextForButtonValue = True
        viewButtonColumn.FlatStyle = FlatStyle.Flat
        viewButtonColumn.MinimumWidth = 60
        viewButtonColumn.FillWeight = 5
        dgvAppointments.Columns.Add(viewButtonColumn)

        AddHandler dgvAppointments.DataBindingComplete, AddressOf dgvAppointments_DataBindingComplete
        AddHandler dgvAppointments.CellClick, AddressOf dgvAppointments_CellClick
        AddHandler dgvAppointments.CellFormatting, AddressOf dgvAppointments_CellFormatting
    End Sub

    ' Populate the dgvAppointments
    Public Sub AppointmentsPopulateDataGrid()
        dgvAppointments.Rows.Clear()

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
    SELECT 
        a.appointment_id AS AppointmentID,
        CONCAT(p.first_name, ' ', p.last_name) AS PatientName,
        CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS DoctorName,
        DATE_FORMAT(a.appointment_date, '%b %d, %Y') AS AppointmentDate,
        a.reason_for_visit AS Reason,
        a.status AS Status,
        p.patient_id AS PatientID
    FROM 
        appointment_table a
    LEFT JOIN 
        patient p ON a.patient_id = p.patient_id
    LEFT JOIN 
        doctor d ON a.doctor_id = d.doctor_id"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    For Each row As DataRow In dataTable.Rows
                        dgvAppointments.Rows.Add(
                            row("AppointmentID"),
                            row("PatientName"),
                            row("DoctorName"),
                            row("AppointmentDate"),
                            row("Reason"),
                            row("Status"),
                            row("PatientID")
                        )
                    Next
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching appointment data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub dgvAppointments_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvAppointments.Rows(e.RowIndex)

            If e.ColumnIndex = dgvAppointments.Columns("ViewButton").Index Then
                Dim cell As DataGridViewButtonCell = DirectCast(row.Cells(e.ColumnIndex), DataGridViewButtonCell)
                cell.Style.BackColor = Color.FromArgb(0, 120, 215)
                cell.Style.ForeColor = Color.White
                cell.Style.SelectionBackColor = Color.FromArgb(0, 100, 190)
                cell.Style.SelectionForeColor = Color.White
            End If

            If e.ColumnIndex = dgvAppointments.Columns("PatientName").Index Then
                Dim cell As DataGridViewCell = row.Cells(e.ColumnIndex)
                cell.Style.Font = New Font(dgvAppointments.Font, FontStyle.Bold)
            End If

            If e.ColumnIndex = dgvAppointments.Columns("Status").Index Then
                Dim status As String = row.Cells(e.ColumnIndex).Value.ToString()
                If status.Equals("Completed", StringComparison.OrdinalIgnoreCase) Then
                    row.Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                ElseIf status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) Then
                    row.Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                ElseIf status.Equals("Scheduled", StringComparison.OrdinalIgnoreCase) Then
                    row.Cells(e.ColumnIndex).Style.ForeColor = Color.Blue
                End If
            End If
        End If
    End Sub

    Private Sub dgvAppointments_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvAppointments.Columns("ViewButton").Index Then
            Dim appointmentID As String = dgvAppointments.Rows(e.RowIndex).Cells("AppointmentID").Value.ToString()
            Dim patientID As String = dgvAppointments.Rows(e.RowIndex).Cells("PatientID").Value.ToString()

            Dim viewAppointmentForm As New ViewAppointmentDetails()
            viewAppointmentForm.AppointmentID = appointmentID
            viewAppointmentForm.PatientID = patientID
            viewAppointmentForm.ShowDialog()
        End If
    End Sub

    Private Sub dgvAppointments_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If dgvAppointments.DisplayedRowCount(True) < dgvAppointments.RowCount Then
            Dim scrollWidth As Integer = SystemInformation.VerticalScrollBarWidth
            dgvAppointments.PerformLayout()
        End If
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        If txtPassword.Text <> txtConfirmPassword.Text Then
            ErrorProvider.SetError(txtConfirmPassword, "Passwords do not match")
        Else
            ErrorProvider.SetError(txtConfirmPassword, "")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        errorProvider.Clear()

        If txtPassword.Text <> txtConfirmPassword.Text Then
            errorProvider.SetError(txtConfirmPassword, "Passwords do not match")
            Return
        End If

        If txtPassword.Text.Length > 0 AndAlso txtPassword.Text.Length < 6 Then
            errorProvider.SetError(txtPassword, "Password must be at least 6 characters long")
            Return
        End If

        Try
            Dim oldUsername As String = GetCurrentUsername()

            UpdateNurseInfo()

            If Not String.IsNullOrEmpty(oldUsername) Then
                UpdateUserInUsersTable(oldUsername)
            Else
                MessageBox.Show("Warning: Could not retrieve current username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error updating profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateNurseInfo()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Try
            Dim query As String
            If String.IsNullOrEmpty(txtPassword.Text) Then
                query = "UPDATE nurse SET 
                    first_name = @firstName, 
                    middle_name = @middleName, 
                    last_name = @lastName, 
                    age = @age, 
                    email_address = @emailAddress, 
                    contact_number = @contactNumber, 
                    address = @address, 
                    username = @username 
                    WHERE nurse_id = @nurseID"
            Else
                query = "UPDATE nurse SET 
                    first_name = @firstName, 
                    middle_name = @middleName, 
                    last_name = @lastName, 
                    age = @age, 
                    email_address = @emailAddress, 
                    contact_number = @contactNumber, 
                    address = @address, 
                    username = @username, 
                    password = @password 
                    WHERE nurse_id = @nurseID"
            End If

            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@firstName", txtFirstName.Text)
                    command.Parameters.AddWithValue("@middleName", If(String.IsNullOrEmpty(txtMiddleName.Text), DBNull.Value, txtMiddleName.Text))
                    command.Parameters.AddWithValue("@lastName", txtLastName.Text)
                    command.Parameters.AddWithValue("@age", numAge.Value)
                    command.Parameters.AddWithValue("@emailAddress", If(String.IsNullOrEmpty(txtEmailAddress.Text), DBNull.Value, txtEmailAddress.Text))
                    command.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrEmpty(txtContactNumber.Text), DBNull.Value, txtContactNumber.Text))
                    command.Parameters.AddWithValue("@address", If(String.IsNullOrEmpty(txtAddress.Text), DBNull.Value, txtAddress.Text))
                    command.Parameters.AddWithValue("@username", txtUsername.Text)
                    command.Parameters.AddWithValue("@nurseID", nurseID)

                    If Not String.IsNullOrEmpty(txtPassword.Text) Then
                        command.Parameters.AddWithValue("@password", txtPassword.Text)
                    End If

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected = 0 Then
                        Throw New Exception("No nurse records were updated. Please check if the nurse information exists.")
                    End If

                    Console.WriteLine($"Successfully updated nurse info. Rows affected: {rowsAffected}")
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
        Dim insertQuery As String = "INSERT INTO users (username, password, role) VALUES (@username, @password, 'nurse')"

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
        Dim query As String = "SELECT username FROM nurse WHERE nurse_id = @nurseID"
        Dim username As String = String.Empty

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@nurseID", nurseID)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot Nothing Then
                    username = result.ToString()
                End If
            End Using
        End Using

        Return username
    End Function

    Private Sub LoadNurseProfile()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim query As String = "SELECT first_name, middle_name, last_name, age, username, " &
                          "email_address, contact_number, address " &
                          "FROM nurse WHERE nurse_id = @nurseID"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@nurseID", nurseID)

                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        txtFirstName.Text = If(reader.IsDBNull(reader.GetOrdinal("first_name")), "", reader("first_name").ToString())
                        txtMiddleName.Text = If(reader.IsDBNull(reader.GetOrdinal("middle_name")), "", reader("middle_name").ToString())
                        txtLastName.Text = If(reader.IsDBNull(reader.GetOrdinal("last_name")), "", reader("last_name").ToString())
                        numAge.Value = If(reader.IsDBNull(reader.GetOrdinal("age")), 0, Convert.ToInt32(reader("age")))
                        txtUsername.Text = If(reader.IsDBNull(reader.GetOrdinal("username")), "", reader("username").ToString())
                        txtEmailAddress.Text = If(reader.IsDBNull(reader.GetOrdinal("email_address")), "", reader("email_address").ToString())
                        txtContactNumber.Text = If(reader.IsDBNull(reader.GetOrdinal("contact_number")), "", reader("contact_number").ToString())
                        txtAddress.Text = If(reader.IsDBNull(reader.GetOrdinal("address")), "", reader("address").ToString())
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub NurseDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class