Imports System.ComponentModel
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class AdminDashboard

    Private activeDropdownPatients As Panel = Nothing
    Private activeDropdownDoctors As Panel = Nothing
    Private activeDropdownAppointments As Panel = Nothing

    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabDashboard.ItemSize = New Size(tabDashboard.Width \ tabDashboard.TabCount - 2, 30)

        ' call all setup and populate methods
        PatientsSetupDataGrid()
        PatientsPopulateDataGrid()

        DoctorsSetupDataGrid()
        DoctorsPopulateDataGrid()

        AppointmentsSetupDataGrid()
        AppointmentsPopulateDataGrid()

        BillingSetupDataGrid()
        BillingPopulateDataGrid()

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        PopulateRecentPayments(connectionString)

        PopulateRecentAppointments(connectionString)

        ' dashboard details
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

        ShowPanel(pnlDashboard, btnDashboard)

        flowRecentAppointments.AutoScroll = True
        flowRecentAppointments.WrapContents = False
        flowRecentAppointments.FlowDirection = FlowDirection.TopDown
        flowRecentPayments.AutoScroll = True
        flowRecentPayments.WrapContents = False
        flowRecentPayments.FlowDirection = FlowDirection.TopDown
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowPanel(pnlDashboard, btnDashboard)
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        ShowPanel(pnlPatients, btnPatients)
    End Sub

    Private Sub btnDoctors_Click(sender As Object, e As EventArgs) Handles btnDoctors.Click
        ShowPanel(pnlDoctors, btnDoctors)
    End Sub

    Private Sub btnAppointments_Click(sender As Object, e As EventArgs) Handles btnAppointments.Click
        ShowPanel(pnlAppointments, btnAppointments)
    End Sub

    Private Sub btnBilling_Click(sender As Object, e As EventArgs) Handles btnBilling.Click
        ShowPanel(pnlBilling, btnBilling)
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ShowPanel(pnlSettings, btnSettings)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim loginForm = New Form1()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub ShowPanel(panelToShow As Panel, activeButton As Button)
        ' Hide all panels
        pnlDashboard.Visible = False
        pnlPatients.Visible = False
        pnlDoctors.Visible = False
        pnlAppointments.Visible = False
        pnlBilling.Visible = False
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

        btnDoctors.BackColor = Color.Transparent
        btnDoctors.ForeColor = Color.Black

        btnAppointments.BackColor = Color.Transparent
        btnAppointments.ForeColor = Color.Black

        btnBilling.BackColor = Color.Transparent
        btnBilling.ForeColor = Color.Black

        btnSettings.BackColor = Color.Transparent
        btnSettings.ForeColor = Color.Black
    End Sub

    Private Sub AdminDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    ''''''''''''''''''''''''''''''''''''
    '                                  '
    ' appointment panel, payment panel '
    '                                  '
    ''''''''''''''''''''''''''''''''''''

    ' populate the recent appointments flow panel
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

    Private Sub flowRecentPayments_Resize(sender As Object, e As EventArgs)
        For Each ctrl As Control In flowRecentPayments.Controls
            SetItemWidth(ctrl)
        Next
    End Sub

    ' populate the recent appointments flow panel
    Private Sub PopulateRecentPayments(connectionString As String)
        flowRecentPayments.Controls.Clear()

        Dim query As String = "
        SELECT 
            CONCAT(p.first_name, ' ', p.last_name) AS PatientName,
            b.date AS BillingDate,
            b.total_amount AS TotalAmount,
            b.status AS PaymentStatus
        FROM 
            billing b
        LEFT JOIN 
            patient p ON b.patient_id = p.patient_id
        ORDER BY 
            b.date DESC"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim description As String = $"Billing for {reader("PatientName")}"
                            Dim billingDate As Date = Convert.ToDateTime(reader("BillingDate"))
                            Dim totalAmount As Decimal = Convert.ToDecimal(reader("TotalAmount"))
                            Dim paymentStatus As String = reader("PaymentStatus").ToString()

                            Dim item As New TransactionItem(description, billingDate, totalAmount, paymentStatus)
                            item.Margin = New Padding(0, 5, 0, 5)
                            SetItemWidth(item)

                            flowRecentPayments.Controls.Add(item)
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching billing data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub


    ''''''''''''''''''''''''''''''''''
    '                                '
    ' patients data grid view setup  '
    '                                '
    ''''''''''''''''''''''''''''''''''
    ' setup dgvPatients
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
        dgvPatients.Columns.Add(ageColumn)

        Dim gestationalAgeColumn As New DataGridViewTextBoxColumn()
        gestationalAgeColumn.HeaderText = "Gestational Age"
        gestationalAgeColumn.Name = "GestationalAge"
        gestationalAgeColumn.MinimumWidth = 120
        gestationalAgeColumn.FillWeight = 18
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

    ' populate the dgvPatients
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

    ' add dropdown menu
    Private Sub ShowDropdownPatientsMenu(rowIndex As Integer)
        Dim buttonCell = dgvPatients.Rows(rowIndex).Cells(6)

        activeDropdownPatients = New Panel With {
        .BorderStyle = BorderStyle.FixedSingle,
        .BackColor = Color.White,
        .Size = New Size(200, 130)
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
        AddMenuOption("Schedule appointment", rowIndex, 90)

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

        Select Case btn.Text
            Case "View patient details"
                Dim patientId As String = GetPatientIdByName(patientName)
                If Not String.IsNullOrEmpty(patientId) Then
                    Dim patientDetailsForm As New PatientDetails()
                    patientDetailsForm.patientID = patientId
                    patientDetailsForm.ShowDialog()
                Else
                    MessageBox.Show("Could not retrieve patient details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Case "Edit patient"
                MessageBox.Show("Editing patient " & patientName)

            Case "Schedule appointment"
                Dim patientId As String = GetPatientIdByName(patientName)
                If Not String.IsNullOrEmpty(patientId) Then
                    Dim lastMenstrualDate As Date = Date.MinValue
                    Dim dueDate As Date = Date.MinValue
                    Dim doctorId As String = ""
                    Dim firstName As String = ""
                    Dim lastName As String = ""

                    If GetPatientDetailsForAppointment(patientId, firstName, lastName, lastMenstrualDate, dueDate, doctorId) Then
                        Dim appointmentForm As New AppointmentDetails()
                        appointmentForm.PatientId = patientId
                        appointmentForm.PatientName = $"{firstName} {lastName}"
                        appointmentForm.LastMenstrualDate = lastMenstrualDate
                        appointmentForm.DueDate = dueDate
                        appointmentForm.DefaultDoctorId = doctorId
                        appointmentForm.IsNewAppointment = True
                        appointmentForm.AppointmentType = "Follow-up Check-up"
                        appointmentForm.ShowDialog()
                    Else
                        MessageBox.Show("Could not retrieve patient details for appointment scheduling.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Could not retrieve patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
        End Select

        CloseDropdownPatients()
    End Sub

    ' method to get patient details for appointment scheduling
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

    ' method to get patient ID by patient name
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

    Private Sub CloseDropdownPatientsHandler(sender As Object, e As EventArgs) Handles dgvPatients.Click, Panel1.Click, pnlPatients.Click, btnDashboard.Click, btnPatients.Click, btnDoctors.Click, btnAppointments.Click, btnBilling.Click, btnAddPatient.Click, txtSearchPatient.Click, Label5.Click
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

    Private Sub btnAddPatient_Clink(sender As Object, e As EventArgs) Handles btnAddPatient.Click
        Dim PatientRegistrationForm As New PatientRegistration()
        PatientRegistrationForm.Show()
    End Sub


    ''''''''''''''''''''''''''''''''
    '                              '
    ' doctors data grid view setup '
    '                              '
    ''''''''''''''''''''''''''''''''

    ' setup dgvDoctors
    Public Sub DoctorsSetupDataGrid()
        dgvDoctors.AllowUserToAddRows = False
        dgvDoctors.AllowUserToDeleteRows = False
        dgvDoctors.ReadOnly = True
        dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDoctors.MultiSelect = False
        dgvDoctors.BackgroundColor = Color.White
        dgvDoctors.BorderStyle = BorderStyle.None
        dgvDoctors.RowHeadersVisible = False
        dgvDoctors.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvDoctors.GridColor = Color.LightGray
        dgvDoctors.ColumnHeadersVisible = True

        dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvDoctors.ColumnHeadersHeight = 40
        dgvDoctors.ColumnHeadersDefaultCellStyle.Font = New Font(dgvDoctors.Font, FontStyle.Bold)
        dgvDoctors.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvDoctors.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgvDoctors.RowTemplate.Height = 50
        dgvDoctors.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvDoctors.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
        dgvDoctors.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvDoctors.AllowUserToResizeColumns = False
        dgvDoctors.AllowUserToResizeRows = False

        dgvDoctors.ScrollBars = ScrollBars.Vertical

        dgvDoctors.AutoGenerateColumns = False
        dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvDoctors.Columns.Clear()

        Dim nameColumn As New DataGridViewTextBoxColumn()
        nameColumn.HeaderText = "Name"
        nameColumn.Name = "Name"
        nameColumn.MinimumWidth = 120
        nameColumn.FillWeight = 15
        dgvDoctors.Columns.Add(nameColumn)

        Dim licenseNumberColumn As New DataGridViewTextBoxColumn()
        licenseNumberColumn.HeaderText = "License Number"
        licenseNumberColumn.Name = "LicenseNumber"
        licenseNumberColumn.MinimumWidth = 120
        licenseNumberColumn.FillWeight = 15
        dgvDoctors.Columns.Add(licenseNumberColumn)

        Dim emailColumn As New DataGridViewTextBoxColumn()
        emailColumn.HeaderText = "Email"
        emailColumn.Name = "Email"
        emailColumn.MinimumWidth = 150
        emailColumn.FillWeight = 20
        dgvDoctors.Columns.Add(emailColumn)

        Dim phoneColumn As New DataGridViewTextBoxColumn()
        phoneColumn.HeaderText = "Phone"
        phoneColumn.Name = "Phone"
        phoneColumn.MinimumWidth = 120
        phoneColumn.FillWeight = 15
        dgvDoctors.Columns.Add(phoneColumn)

        Dim patientsColumn As New DataGridViewTextBoxColumn()
        patientsColumn.HeaderText = "Patients"
        patientsColumn.Name = "Patients"
        patientsColumn.MinimumWidth = 80
        patientsColumn.FillWeight = 10
        dgvDoctors.Columns.Add(patientsColumn)

        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = ""
        buttonColumn.Name = "ActionButton"
        buttonColumn.Text = "..."
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Flat
        buttonColumn.MinimumWidth = 60
        buttonColumn.FillWeight = 10
        dgvDoctors.Columns.Add(buttonColumn)

        AddHandler dgvDoctors.DataBindingComplete, AddressOf dgvDoctors_DataBindingComplete

        AddHandler dgvDoctors.CellClick, AddressOf dgvDoctors_CellClick
        AddHandler dgvDoctors.ColumnHeaderMouseClick, AddressOf dgvDoctors_ColumnHeaderMouseClick
        AddHandler dgvDoctors.CellFormatting, AddressOf dgvDoctors_CellFormatting
    End Sub

    Private Sub dgvDoctors_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvDoctors.Rows(e.RowIndex)

            If e.ColumnIndex = dgvDoctors.Columns("ActionButton").Index Then
                Dim cell As DataGridViewButtonCell = TryCast(row.Cells(e.ColumnIndex), DataGridViewButtonCell)
                If cell IsNot Nothing Then
                    cell.Style.BackColor = Color.White
                    cell.Style.ForeColor = Color.FromArgb(100, 100, 100)
                End If
            End If

            If e.ColumnIndex = dgvDoctors.Columns("Name").Index Then
                Dim cell As DataGridViewCell = row.Cells(e.ColumnIndex)
                If cell.Value IsNot Nothing Then
                    cell.Style.Font = New Font(dgvDoctors.Font, FontStyle.Bold)
                End If
            End If
        End If
    End Sub

    ' populate the dgvDoctors
    Public Sub DoctorsPopulateDataGrid()
        If dgvDoctors.Columns.Count = 0 Then
            DoctorsSetupDataGrid()
        End If

        dgvDoctors.Rows.Clear()

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
        SELECT 
            CONCAT('Dr. ', first_name, ' ', last_name) AS Name, 
            license_number AS LicenseNumber, 
            email AS Email, 
            contact_number AS Phone, 
            (SELECT COUNT(*) FROM patient WHERE assigned_ob = doctor_id) AS Patients
        FROM 
            doctor"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    For Each row As DataRow In dataTable.Rows
                        dgvDoctors.Rows.Add(row("Name"), row("LicenseNumber"), row("Email"), row("Phone"), row("Patients"))
                    Next
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching doctor data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub dgvDoctors_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If dgvDoctors.DisplayedRowCount(True) < dgvDoctors.RowCount Then
            dgvDoctors.PerformLayout()
        End If
    End Sub

    Private Sub dgvDoctors_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.ColumnIndex = dgvDoctors.Columns("Name").Index Or e.ColumnIndex = dgvDoctors.Columns("Patients").Index Then
            Dim clickedColumn = dgvDoctors.Columns(e.ColumnIndex)

            If clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.None Or
           clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending Then
                clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
                SortDoctorsDataGridView(e.ColumnIndex, ListSortDirection.Ascending)
            Else
                clickedColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
                SortDoctorsDataGridView(e.ColumnIndex, ListSortDirection.Descending)
            End If

            For Each col As DataGridViewColumn In dgvDoctors.Columns
                If col.Index <> e.ColumnIndex Then
                    col.HeaderCell.SortGlyphDirection = SortOrder.None
                End If
            Next
        End If
    End Sub

    Private Sub SortDoctorsDataGridView(columnIndex As Integer, direction As ListSortDirection)
        If dgvDoctors.Columns(columnIndex).Name = "Patients" Then
            If direction = ListSortDirection.Ascending Then
                dgvDoctors.Sort(New NumberComparerDoctors(columnIndex, True))
            Else
                dgvDoctors.Sort(New NumberComparerDoctors(columnIndex, False))
            End If
        Else
            If direction = ListSortDirection.Ascending Then
                dgvDoctors.Sort(dgvDoctors.Columns(columnIndex), ListSortDirection.Ascending)
            Else
                dgvDoctors.Sort(dgvDoctors.Columns(columnIndex), ListSortDirection.Descending)
            End If
        End If
    End Sub

    Private Sub dgvDoctors_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = dgvDoctors.Columns("ActionButton").Index And e.RowIndex >= 0 Then
            CloseDoctorsDropdown()

            ShowDoctorsDropdownMenu(e.RowIndex)
        ElseIf activeDropdownDoctors IsNot Nothing Then
            CloseDoctorsDropdown()
        End If
    End Sub

    ' generate dropdown for doctors
    Private Sub ShowDoctorsDropdownMenu(rowIndex As Integer)
        Dim buttonCell = dgvDoctors.Rows(rowIndex).Cells("ActionButton")

        activeDropdownDoctors = New Panel With {
        .BorderStyle = BorderStyle.FixedSingle,
        .BackColor = Color.White,
        .Size = New Size(200, 130)
    }

        Dim cellRect = dgvDoctors.GetCellDisplayRectangle(dgvDoctors.Columns("ActionButton").Index, rowIndex, False)
        Dim screenPoint = dgvDoctors.PointToScreen(New Point(cellRect.Right, cellRect.Top))
        Dim formPoint = Me.PointToClient(screenPoint)

        Dim dropdownX = formPoint.X - activeDropdownDoctors.Width
        Dim dropdownY = formPoint.Y

        If dropdownX < 0 Then dropdownX = 0
        If dropdownX + activeDropdownDoctors.Width > Me.ClientSize.Width Then
            dropdownX = Me.ClientSize.Width - activeDropdownDoctors.Width
        End If

        If dropdownY + activeDropdownDoctors.Height > Me.ClientSize.Height Then
            dropdownY = formPoint.Y - activeDropdownDoctors.Height + cellRect.Height
        End If

        If dropdownY < 0 Then dropdownY = 0

        activeDropdownDoctors.Location = New Point(dropdownX, dropdownY)

        Dim lblTitle As New Label With {
        .Text = "Actions",
        .Font = New Font(dgvDoctors.Font.FontFamily, 10, FontStyle.Bold),
        .AutoSize = False,
        .Size = New Size(200, 30),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Padding = New Padding(10, 0, 0, 0)
    }
        activeDropdownDoctors.Controls.Add(lblTitle)

        AddDoctorsMenuOption("Copy doctor ID", rowIndex, 30)
        AddDoctorsMenuOption("View doctor details", rowIndex, 60)
        AddDoctorsMenuOption("Edit doctor", rowIndex, 90)

        Me.Controls.Add(activeDropdownDoctors)
        activeDropdownDoctors.BringToFront()
    End Sub

    Private Sub AddDoctorsMenuOption(text As String, rowIndex As Integer, topPosition As Integer)
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

        AddHandler btn.Click, AddressOf DoctorsMenuOption_Click
        AddHandler btn.MouseEnter, AddressOf DoctorsMenuOption_MouseEnter
        AddHandler btn.MouseLeave, AddressOf DoctorsMenuOption_MouseLeave

        activeDropdownDoctors.Controls.Add(btn)
    End Sub

    Private Sub DoctorsMenuOption_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim rowIndex = CInt(btn.Tag)
        Dim doctorName = dgvDoctors.Rows(rowIndex).Cells("Name").Value.ToString()

        Select Case btn.Text
            Case "Copy doctor ID"
                MessageBox.Show("Doctor ID for " & doctorName & " copied to clipboard!")
            Case "View doctor details"
                MessageBox.Show("Viewing details for " & doctorName)
            Case "Edit doctor"
                MessageBox.Show("Editing doctor " & doctorName)
        End Select

        CloseDoctorsDropdown()
    End Sub

    Private Sub DoctorsMenuOption_MouseEnter(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        btn.BackColor = Color.LightGray
    End Sub

    Private Sub DoctorsMenuOption_MouseLeave(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        btn.BackColor = Color.White
    End Sub

    Private Sub CloseDoctorsDropdown()
        If activeDropdownDoctors IsNot Nothing Then
            Me.Controls.Remove(activeDropdownDoctors)
            activeDropdownDoctors.Dispose()
            activeDropdownDoctors = Nothing
        End If
    End Sub

    Private Sub CloseDropdownDoctorHandler(sender As Object, e As EventArgs) Handles Panel1.Click, pnlDoctors.Click, btnDashboard.Click, btnPatients.Click, btnDoctors.Click, btnAppointments.Click, btnBilling.Click, btnAddDoctor.Click, txtSearchDoctor.Click, Label6.Click, dgvDoctors.Click
        CloseDoctorsDropdown()
    End Sub

    Private Sub txtSearchDoctor_TextChanged_1(sender As Object, e As EventArgs) Handles txtSearchDoctor.TextChanged
        Dim searchText As String = txtSearchDoctor.Text.Trim().ToLower()

        For Each row As DataGridViewRow In dgvDoctors.Rows
            Dim name As String = row.Cells("Name").Value.ToString().ToLower()
            Dim licenseNumber As String = row.Cells("LicenseNumber").Value.ToString().ToLower()

            If name.Contains(searchText) OrElse licenseNumber.Contains(searchText) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next
    End Sub

    Private Sub btnAddDoctor_Click(sender As Object, e As EventArgs) Handles btnAddDoctor.Click
        Dim doctorRegistrationForm As New DoctorRegistration()
        doctorRegistrationForm.Show()
    End Sub

    '''''''''''''''''''''''''''''''''''''
    '                                   '
    ' appointments data grid view setup '
    '                                   '
    '''''''''''''''''''''''''''''''''''''

    ' setup dgvAppointments
    Private Sub AppointmentsSetupDataGrid()
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

        Dim actionButtonColumn As New DataGridViewButtonColumn()
        actionButtonColumn.HeaderText = ""
        actionButtonColumn.Name = "ActionButton"
        actionButtonColumn.Text = "..."
        actionButtonColumn.UseColumnTextForButtonValue = True
        actionButtonColumn.FlatStyle = FlatStyle.Flat
        actionButtonColumn.MinimumWidth = 60
        actionButtonColumn.FillWeight = 5
        dgvAppointments.Columns.Add(actionButtonColumn)

        AddHandler dgvAppointments.DataBindingComplete, AddressOf dgvAppointments_DataBindingComplete
    End Sub

    Private Sub dgvAppointments_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If dgvAppointments.DisplayedRowCount(True) < dgvAppointments.RowCount Then
            Dim scrollWidth As Integer = SystemInformation.VerticalScrollBarWidth
            dgvAppointments.PerformLayout()
        End If
    End Sub

    ' populate the dgvAppointments
    Private Sub AppointmentsPopulateDataGrid()
        dgvAppointments.Rows.Clear()

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
        SELECT 
            a.appointment_id AS AppointmentID,
            CONCAT(p.first_name, ' ', p.last_name) AS PatientName,
            CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS DoctorName,
            DATE_FORMAT(a.appointment_date, '%b %d, %Y') AS AppointmentDate,
            a.reason_for_visit AS Reason,
            a.status AS Status
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
                        dgvAppointments.Rows.Add(row("AppointmentID"), row("PatientName"), row("DoctorName"), row("AppointmentDate"), row("Reason"), row("Status"))
                    Next
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching appointment data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub dgvAppointments_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAppointments.CellClick
        If e.ColumnIndex = dgvAppointments.Columns("ActionButton").Index And e.RowIndex >= 0 Then
            CloseDropdownAppointments()

            ShowDropdownAppointments(e.RowIndex)
        ElseIf activeDropdownAppointments IsNot Nothing Then
            CloseDropdownAppointments()
        End If
    End Sub

    ' generate dropdown for appointments
    Private Sub ShowDropdownAppointments(rowIndex As Integer)
        CloseDropdownAppointments()

        Dim cellRect = dgvAppointments.GetCellDisplayRectangle(dgvAppointments.Columns("ActionButton").Index, rowIndex, False)
        Dim screenPoint = dgvAppointments.PointToScreen(New Point(cellRect.Right, cellRect.Top))
        Dim formPoint = Me.PointToClient(screenPoint)

        activeDropdownAppointments = New Panel With {
        .BorderStyle = BorderStyle.FixedSingle,
        .BackColor = Color.White,
        .Size = New Size(200, 130)
    }

        Dim dropdownX = formPoint.X - activeDropdownAppointments.Width
        Dim dropdownY = formPoint.Y

        If dropdownX < 0 Then dropdownX = 0
        If dropdownX + activeDropdownAppointments.Width > Me.ClientSize.Width Then
            dropdownX = Me.ClientSize.Width - activeDropdownAppointments.Width
        End If

        If dropdownY + activeDropdownAppointments.Height > Me.ClientSize.Height Then
            dropdownY = formPoint.Y - activeDropdownAppointments.Height + cellRect.Height
        End If

        activeDropdownAppointments.Location = New Point(dropdownX, dropdownY)

        Dim lblTitle As New Label With {
        .Text = "Actions",
        .Font = New Font(dgvAppointments.Font.FontFamily, 10, FontStyle.Bold),
        .AutoSize = False,
        .Size = New Size(200, 30),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Padding = New Padding(10, 0, 0, 0)
    }
        activeDropdownAppointments.Controls.Add(lblTitle)

        AddMenuOptionAppointments("View details", rowIndex, 30)
        AddMenuOptionAppointments("Reschedule", rowIndex, 60)
        AddMenuOptionAppointments("Cancel appointment", rowIndex, 90)

        Me.Controls.Add(activeDropdownAppointments)
        activeDropdownAppointments.BringToFront()
    End Sub

    Private Sub AddMenuOptionAppointments(text As String, rowIndex As Integer, topPosition As Integer)
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

        AddHandler btn.Click, AddressOf MenuOptionAppointments_Click
        AddHandler btn.MouseEnter, AddressOf MenuOptionAppointments_MouseEnter
        AddHandler btn.MouseLeave, AddressOf MenuOptionAppointments_MouseLeave

        activeDropdownAppointments.Controls.Add(btn)
    End Sub

    Private Sub MenuOptionAppointments_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim rowIndex = CInt(btn.Tag)

        Dim name = dgvAppointments.Rows(rowIndex).Cells("PatientName").Value.ToString()

        Select Case btn.Text
            Case "View details"
                MessageBox.Show($"Viewing details for {name}")
            Case "Reschedule"
                MessageBox.Show($"Rescheduling appointment with {name}")
            Case "Cancel appointment"
                If MessageBox.Show($"Are you sure you want to cancel the appointment with {name}?",
                          "Confirm Cancellation", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    If dgvAppointments.DataSource IsNot Nothing Then
                        Dim dt As DataTable = TryCast(dgvAppointments.DataSource, DataTable)
                        If dt IsNot Nothing Then
                            dt.Rows.RemoveAt(rowIndex)
                        End If
                    Else
                        dgvAppointments.Rows.RemoveAt(rowIndex)
                    End If
                End If
        End Select

        CloseDropdownAppointments()
    End Sub

    Private Sub MenuOptionAppointments_MouseEnter(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        btn.BackColor = Color.LightGray
    End Sub

    Private Sub MenuOptionAppointments_MouseLeave(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        btn.BackColor = Color.White
    End Sub

    Private Sub CloseDropdownAppointments()
        If activeDropdownAppointments IsNot Nothing Then
            Me.Controls.Remove(activeDropdownAppointments)
            activeDropdownAppointments.Dispose()
            activeDropdownAppointments = Nothing
        End If
    End Sub

    Private Sub CloseDropdownAppointmentsHandler(sender As Object, e As EventArgs) Handles dgvAppointments.Click, Panel1.Click, pnlAppointments.Click, btnDashboard.Click, btnPatients.Click, btnDoctors.Click, btnAppointments.Click, btnBilling.Click, Appointments.Click
        CloseDropdownAppointments
    End Sub

    ''''''''''''''''''''''''''''''''
    '                              '
    ' billing data grid view setup '
    '                              '
    ''''''''''''''''''''''''''''''''

    ' setup dgvBilling
    Private Sub BillingSetupDataGrid()
        ' Configure the DataGridView
        dgvBilling.AllowUserToAddRows = False
        dgvBilling.AllowUserToDeleteRows = False
        dgvBilling.ReadOnly = True
        dgvBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBilling.MultiSelect = False
        dgvBilling.BackgroundColor = Color.White
        dgvBilling.BorderStyle = BorderStyle.None
        dgvBilling.RowHeadersVisible = False
        dgvBilling.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvBilling.GridColor = Color.LightGray
        dgvBilling.ColumnHeadersVisible = True

        dgvBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvBilling.ColumnHeadersHeight = 40
        dgvBilling.ColumnHeadersDefaultCellStyle.Font = New Font(dgvBilling.Font, FontStyle.Bold)
        dgvBilling.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvBilling.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgvBilling.RowTemplate.Height = 50
        dgvBilling.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)
        dgvBilling.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245)
        dgvBilling.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvBilling.AllowUserToResizeColumns = False
        dgvBilling.AllowUserToResizeRows = False

        dgvBilling.ScrollBars = ScrollBars.Vertical

        dgvBilling.AutoGenerateColumns = False
        dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvBilling.Columns.Clear()

        Dim nameColumn As New DataGridViewTextBoxColumn()
        nameColumn.HeaderText = "Name"
        nameColumn.Name = "Name"
        nameColumn.MinimumWidth = 140
        nameColumn.FillWeight = 25
        dgvBilling.Columns.Add(nameColumn)

        Dim dateColumn As New DataGridViewTextBoxColumn()
        dateColumn.HeaderText = "Date"
        dateColumn.Name = "Date"
        dateColumn.MinimumWidth = 100
        dateColumn.FillWeight = 15
        dgvBilling.Columns.Add(dateColumn)

        Dim itemsColumn As New DataGridViewTextBoxColumn()
        itemsColumn.HeaderText = "Items"
        itemsColumn.Name = "Items"
        itemsColumn.MinimumWidth = 150
        itemsColumn.FillWeight = 30
        dgvBilling.Columns.Add(itemsColumn)

        Dim totalColumn As New DataGridViewTextBoxColumn()
        totalColumn.HeaderText = "Total"
        totalColumn.Name = "Total"
        totalColumn.MinimumWidth = 100
        totalColumn.FillWeight = 15
        dgvBilling.Columns.Add(totalColumn)

        Dim statusColumn As New DataGridViewTextBoxColumn()
        statusColumn.HeaderText = "Status"
        statusColumn.Name = "Status"
        statusColumn.MinimumWidth = 80
        statusColumn.FillWeight = 15
        dgvBilling.Columns.Add(statusColumn)

        Dim paymentButtonColumn As New DataGridViewButtonColumn()
        paymentButtonColumn.HeaderText = "Payment"
        paymentButtonColumn.Name = "PaymentButton"
        paymentButtonColumn.UseColumnTextForButtonValue = False
        paymentButtonColumn.FlatStyle = FlatStyle.Flat
        paymentButtonColumn.MinimumWidth = 100
        paymentButtonColumn.FillWeight = 15
        dgvBilling.Columns.Add(paymentButtonColumn)

        AddHandler dgvBilling.CellFormatting, AddressOf dgvBilling_CellFormatting
        AddHandler dgvBilling.CellClick, AddressOf dgvBilling_CellClick

        AddHandler dgvBilling.DataBindingComplete, AddressOf dgvBilling_DataBindingComplete
    End Sub

    ' populate the dgvBilling
    Private Sub BillingPopulateDataGrid()
        dgvBilling.Rows.Clear()

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
    SELECT 
        b.billing_id AS BillingID,
        CONCAT(p.first_name, ' ', p.last_name) AS Name, 
        DATE_FORMAT(b.date, '%b %d, %Y') AS Date, 
        b.items AS Items, 
        b.total_amount AS Total, 
        b.status AS Status
    FROM 
        billing b
    LEFT JOIN 
        patient p
    ON 
        b.patient_id = p.patient_id"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    For Each row As DataRow In dataTable.Rows
                        Dim rowIndex As Integer = dgvBilling.Rows.Add(row("Name"), row("Date"), row("Items"), row("Total"), row("Status"))
                        dgvBilling.Rows(rowIndex).Tag = row("BillingID").ToString()
                    Next
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching billing data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub dgvBilling_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If dgvBilling.DisplayedRowCount(True) < dgvBilling.RowCount Then
            dgvBilling.PerformLayout()
        End If
    End Sub

    Private Sub dgvBilling_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = dgvBilling.Columns("PaymentButton").Index AndAlso e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBilling.Rows(e.RowIndex)
            Dim status As String = row.Cells("Status").Value.ToString()

            Dim buttonCell As DataGridViewButtonCell = DirectCast(row.Cells(e.ColumnIndex), DataGridViewButtonCell)

            If status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase) Then
                buttonCell.Value = "Pay"
                buttonCell.Style.BackColor = Color.FromArgb(50, 150, 50)
                buttonCell.Style.ForeColor = Color.White
                buttonCell.Style.SelectionBackColor = Color.FromArgb(70, 170, 70)
                buttonCell.Style.SelectionForeColor = Color.White
            Else
                buttonCell.Value = "Completed"
                buttonCell.Style.BackColor = Color.LightGray
                buttonCell.Style.ForeColor = Color.DarkGray
                buttonCell.Style.SelectionBackColor = Color.LightGray
                buttonCell.Style.SelectionForeColor = Color.DarkGray
                buttonCell.FlatStyle = FlatStyle.Flat
            End If
        End If

        If e.ColumnIndex = dgvBilling.Columns("Name").Index And e.RowIndex >= 0 Then
            Dim cell As DataGridViewCell = dgvBilling.Rows(e.RowIndex).Cells(e.ColumnIndex)
            cell.Style.Font = New Font(dgvBilling.Font, FontStyle.Bold)
        End If

        If e.ColumnIndex = dgvBilling.Columns("Status").Index And e.RowIndex >= 0 Then
            Dim status As String = dgvBilling.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()

            If status.Equals("Paid", StringComparison.OrdinalIgnoreCase) Then
                dgvBilling.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
            ElseIf status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase) Then
                dgvBilling.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgvBilling_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = dgvBilling.Columns("PaymentButton").Index AndAlso e.RowIndex >= 0 Then
            Dim status As String = dgvBilling.Rows(e.RowIndex).Cells("Status").Value.ToString()

            If status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase) Then
                Dim billingId As String = dgvBilling.Rows(e.RowIndex).Tag.ToString()

                Dim billingDetailsForm As New BillingDetails()
                billingDetailsForm.BillingId = billingId

                If billingDetailsForm.ShowDialog() = DialogResult.OK Then
                    BillingPopulateDataGrid()

                    Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
                    PopulateRecentPayments(connectionString)
                End If
            End If
        End If
    End Sub

End Class

Public Class NumberComparerDoctors
    Implements IComparer

    Private columnIndex As Integer
    Private ascending As Boolean

    Public Sub New(columnIndex As Integer, ascending As Boolean)
        Me.columnIndex = columnIndex
        Me.ascending = ascending
    End Sub
    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim row1 = DirectCast(x, DataGridViewRow)
        Dim row2 = DirectCast(y, DataGridViewRow)

        Dim value1 As Integer
        Dim value2 As Integer

        If Integer.TryParse(row1.Cells(columnIndex).Value.ToString(), value1) AndAlso
           Integer.TryParse(row2.Cells(columnIndex).Value.ToString(), value2) Then
            If ascending Then
                Return value1.CompareTo(value2)
            Else
                Return value2.CompareTo(value1)
            End If
        End If
        Return 0
    End Function
End Class