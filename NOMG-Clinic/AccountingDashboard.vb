Imports MySql.Data.MySqlClient

Public Class AccountingDashboard
    Private activeDropdownPatients As Panel = Nothing
    Public Property AccountantID As String
    Private Sub AccountingDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabDashboard.ItemSize = New Size(tabDashboard.Width \ tabDashboard.TabCount - 2, 30)

        PatientsSetupDataGrid()
        PatientsPopulateDataGrid()

        BillingSetupDataGrid()
        BillingPopulateDataGrid()

        UpdateWelcomeMessage()

        ShowPanel(pnlDashboard, btnDashboard)

    End Sub

    Private Sub UpdateWelcomeMessage()
        Console.WriteLine("Using AccountantID: " & AccountantID)

        Dim query As String = "SELECT CONCAT('Welcome back, ', first_name, ' ', last_name) FROM accountant WHERE accountant_id = @accountantID"
        Dim welcomeMessage As String = ExecuteStringQuery(query, New MySqlParameter("@accountantID", AccountantID))
        Console.WriteLine("Query returned: " & welcomeMessage)

        If String.IsNullOrEmpty(welcomeMessage) Then
            lblWelcomeMessage.Text = "Welcome back, Accountant!"
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

        Dim patientIdColumn As New DataGridViewTextBoxColumn()
        patientIdColumn.HeaderText = "Patient ID"
        patientIdColumn.Name = "PatientID"
        patientIdColumn.Visible = False
        dgvPatients.Columns.Add(patientIdColumn)

        Dim nameColumn As New DataGridViewTextBoxColumn()
        nameColumn.HeaderText = "Patient Name"
        nameColumn.Name = "Name"
        nameColumn.MinimumWidth = 140
        nameColumn.FillWeight = 22
        dgvPatients.Columns.Add(nameColumn)

        Dim nextCheckupColumn As New DataGridViewTextBoxColumn()
        nextCheckupColumn.HeaderText = "Next Appointment"
        nextCheckupColumn.Name = "NextCheckup"
        nextCheckupColumn.MinimumWidth = 130
        nextCheckupColumn.FillWeight = 19
        dgvPatients.Columns.Add(nextCheckupColumn)

        Dim contactColumn As New DataGridViewTextBoxColumn()
        contactColumn.HeaderText = "Contact Number"
        contactColumn.Name = "ContactNumber"
        contactColumn.MinimumWidth = 120
        contactColumn.FillWeight = 19
        dgvPatients.Columns.Add(contactColumn)

        Dim assignedOBColumn As New DataGridViewTextBoxColumn()
        assignedOBColumn.HeaderText = "Assigned Doctor"
        assignedOBColumn.Name = "AssignedOB"
        assignedOBColumn.MinimumWidth = 130
        assignedOBColumn.FillWeight = 20
        dgvPatients.Columns.Add(assignedOBColumn)

        Dim billingStatusColumn As New DataGridViewTextBoxColumn()
        billingStatusColumn.HeaderText = "Billing Status"
        billingStatusColumn.Name = "BillingStatus"
        billingStatusColumn.MinimumWidth = 100
        billingStatusColumn.FillWeight = 20
        dgvPatients.Columns.Add(billingStatusColumn)

        AddHandler dgvPatients.DataBindingComplete, AddressOf dgvPatients_DataBindingComplete
        AddHandler dgvPatients.CellFormatting, AddressOf dgvPatients_CellFormatting
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
            p.patient_id,
            CONCAT(p.first_name, ' ', p.last_name) AS Name, 
            DATE_FORMAT(p.next_checkup, '%b %d, %Y') AS NextCheckup,
            p.contact_number AS ContactNumber,
            CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS AssignedOB,
            IFNULL((SELECT 
                CASE 
                    WHEN COUNT(*) = 0 THEN 'No Bill'
                    WHEN SUM(CASE WHEN status = 'Paid' THEN 1 ELSE 0 END) = COUNT(*) THEN 'Paid'
                    ELSE 'Pending'
                END
            FROM billing WHERE patient_id = p.patient_id), 'No Bill') AS BillingStatus
        FROM 
            patient p
        LEFT JOIN 
            doctor d ON p.assigned_ob = d.doctor_id
        ORDER BY 
            p.next_checkup ASC"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()

                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    For Each row As DataRow In dataTable.Rows
                        dgvPatients.Rows.Add(
                        row("patient_id"),
                        row("Name"),
                        row("NextCheckup"),
                        row("ContactNumber"),
                        row("AssignedOB"),
                        row("BillingStatus")
                    )
                    Next
                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching patient data: " & ex.Message)
                End Try
            End Using
        End Using
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

            If e.ColumnIndex = dgvPatients.Columns("Name").Index Then
                Dim cell As DataGridViewCell = row.Cells(e.ColumnIndex)
                cell.Style.Font = New Font(dgvPatients.Font, FontStyle.Bold)
            End If

            If e.ColumnIndex = dgvPatients.Columns("BillingStatus").Index Then
                Dim status As String = row.Cells("BillingStatus").Value.ToString()
                If status = "Pending" Then
                    e.CellStyle.ForeColor = Color.FromArgb(217, 83, 79) ' Red
                ElseIf status = "Paid" Then
                    e.CellStyle.ForeColor = Color.FromArgb(92, 184, 92) ' Green
                End If
            End If
        End If
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

    Private Sub btnAddPatient_Click(sender As Object, e As EventArgs)
        Dim PatientRegistrationForm As New PatientRegistration
        PatientRegistrationForm.Show()
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

    Private Sub btnBilling_Click(sender As Object, e As EventArgs) Handles btnBilling.Click
        ShowPanel(pnlBilling, btnBilling)
    End Sub

    Private Sub ShowPanel(panelToShow As Panel, activeButton As Button)
        ' Hide all panels
        pnlDashboard.Visible = False
        pnlPatients.Visible = False
        pnlBilling.Visible = False

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

        btnBilling.BackColor = Color.Transparent
        btnBilling.ForeColor = Color.Black
    End Sub

    ''''''''''''''''''''''''''''''''
    '                              '
    ' billing data grid view setup '
    '                              '
    ''''''''''''''''''''''''''''''''

    ' Setup dgvBilling
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

    ' Populate the dgvBilling
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
                End If
            End If
        End If
    End Sub

    Private Sub AccountingDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class