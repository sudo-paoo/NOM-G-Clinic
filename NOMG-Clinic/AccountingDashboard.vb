Imports MySql.Data.MySqlClient

Public Class AccountingDashboard
    Private activeDropdownPatients As Panel = Nothing
    Private errorProvider As New ErrorProvider()

    Public Property AccountantID As String
    Private Sub AccountingDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PatientsSetupDataGrid()
        PatientsPopulateDataGrid()

        BillingSetupDataGrid()
        BillingPopulateDataGrid()

        UpdateWelcomeMessage()

        PopulateRecentPayments(ConnectionString)

        ShowPanel(pnlDashboard, btnDashboard)

        CalculateTotalRevenue()
        CalculateTodayPayments()

        LoadAccountantProfile()
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

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ShowPanel(pnlSettings, btnSettings)
    End Sub

    Private Sub ShowPanel(panelToShow As Panel, activeButton As Button)
        ' Hide all panels
        pnlDashboard.Visible = False
        pnlPatients.Visible = False
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

        btnBilling.BackColor = Color.Transparent
        btnBilling.ForeColor = Color.Black

        btnSettings.BackColor = Color.Transparent
        btnSettings.ForeColor = Color.Black
    End Sub

    ''''''''''''''''''''''''''''''''
    '                              '
    ' billing data grid view setup '
    '                              '
    ''''''''''''''''''''''''''''''''

    ' Setup dgvBilling
    Public Sub BillingSetupDataGrid()
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

        ' Enable auto-sizing for row height based on content
        dgvBilling.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ' Set default row height
        dgvBilling.RowTemplate.Height = 60
        dgvBilling.RowTemplate.MinimumHeight = 60


        ' Enable word wrapping for cells
        dgvBilling.DefaultCellStyle.WrapMode = DataGridViewTriState.True

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
        nameColumn.FillWeight = 20
        dgvBilling.Columns.Add(nameColumn)

        Dim dateColumn As New DataGridViewTextBoxColumn()
        dateColumn.HeaderText = "Date"
        dateColumn.Name = "Date"
        dateColumn.MinimumWidth = 100
        dateColumn.FillWeight = 15
        dgvBilling.Columns.Add(dateColumn)

        Dim quantityColumn As New DataGridViewTextBoxColumn()
        quantityColumn.HeaderText = "Quantity"
        quantityColumn.Name = "Quantity"
        quantityColumn.MinimumWidth = 80
        quantityColumn.FillWeight = 10
        quantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBilling.Columns.Add(quantityColumn)

        Dim itemsColumn As New DataGridViewTextBoxColumn()
        itemsColumn.HeaderText = "Items"
        itemsColumn.Name = "Items"
        itemsColumn.MinimumWidth = 150
        itemsColumn.FillWeight = 25
        itemsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        itemsColumn.DefaultCellStyle.Padding = New Padding(5, 10, 5, 10)
        itemsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
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
    Public Sub BillingPopulateDataGrid()
        dgvBilling.Rows.Clear()

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Dim query As String = "
    SELECT 
        b.billing_id AS BillingID,
        CONCAT(p.first_name, ' ', p.last_name) AS Name, 
        DATE_FORMAT(b.date, '%b %d, %Y') AS Date, 
        b.items AS Items, 
        b.item_names AS ItemNames,
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
                        ' Get formatted item names from JSON
                        Dim formattedItems As String = FormatItemNames(row("ItemNames").ToString())

                        Dim rowIndex As Integer = dgvBilling.Rows.Add(
                    row("Name"),
                    row("Date"),
                    row("Items"),
                    formattedItems,
                    row("Total"),
                    row("Status"))

                        dgvBilling.Rows(rowIndex).Tag = row("BillingID").ToString()
                    Next

                    dgvBilling.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)

                Catch ex As Exception
                    MessageBox.Show("An error occurred while fetching billing data: " & ex.Message)
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

                'Dim price As Integer = 0
                'If item.ContainsKey("price") Then
                '    Integer.TryParse(item("price").ToString(), price)
                'End If

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


    Private Sub dgvBilling_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        dgvBilling.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)

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
                buttonCell.Value = "View Billing"
                buttonCell.Style.BackColor = Color.FromArgb(0, 120, 215)
                buttonCell.Style.ForeColor = Color.White
                buttonCell.Style.SelectionBackColor = Color.FromArgb(0, 100, 190)
                buttonCell.Style.SelectionForeColor = Color.White
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
            Dim billingId As String = dgvBilling.Rows(e.RowIndex).Tag.ToString()

            Dim billingDetailsForm As New BillingDetails()
            billingDetailsForm.BillingId = billingId

            If status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase) Then
                If billingDetailsForm.ShowDialog() = DialogResult.OK Then
                    BillingPopulateDataGrid()

                    Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
                    PopulateRecentPayments(connectionString)
                End If
            Else
                billingDetailsForm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub flowRecentPayments_Resize(sender As Object, e As EventArgs) Handles flowRecentPayments.Resize
        Dim scrollbarWidth As Integer = 0
        If flowRecentPayments.VerticalScroll.Visible Then
            scrollbarWidth = SystemInformation.VerticalScrollBarWidth
        End If

        For Each ctrl As Control In flowRecentPayments.Controls
            ctrl.Width = flowRecentPayments.ClientSize.Width - flowRecentPayments.Padding.Left - flowRecentPayments.Padding.Right - scrollbarWidth
        Next
    End Sub

    ' Populate the recent appointments flow panel
    Public Sub PopulateRecentPayments(connectionString As String)
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
        WHERE
            b.status != 'Unpaid'
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

    Private Sub SetItemWidth(ctrl As Control)
        Dim paddingWidth As Integer = flowRecentPayments.Padding.Left + flowRecentPayments.Padding.Right
        ctrl.Width = flowRecentPayments.ClientSize.Width - paddingWidth
    End Sub

    Public Sub CalculateTotalRevenue()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim totalRevenue As Decimal = 0

        Dim query As String = "
    SELECT 
        SUM(total_amount) AS TotalRevenue
    FROM 
        billing
    WHERE 
        status = 'Paid'"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        totalRevenue = Convert.ToDecimal(result)
                    End If

                    lblTotalRevenue.Text = String.Format("{0:C}", totalRevenue)
                Catch ex As Exception
                    MessageBox.Show("Error calculating total revenue: " & ex.Message)
                    lblTotalRevenue.Text = "$0.00"
                End Try
            End Using
        End Using
    End Sub

    Public Sub CalculateTodayPayments()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim todayTotal As Decimal = 0
        Dim today As String = DateTime.Now.ToString("yyyy-MM-dd")

        ' Debug output
        Console.WriteLine("Today's date for query: " & today)

        ' Get a count of all records in the billing table
        Dim countQuery As String = "SELECT COUNT(*) FROM billing"
        Using countConnection As New MySqlConnection(connectionString)
            Using countCommand As New MySqlCommand(countQuery, countConnection)
                Try
                    countConnection.Open()
                    Dim count = countCommand.ExecuteScalar()
                    Console.WriteLine("Total records in billing table: " & count)
                Catch ex As Exception
                    Console.WriteLine("Error counting records: " & ex.Message)
                End Try
            End Using
        End Using

        ' Get a count of paid records (regardless of date)
        Dim paidCountQuery As String = "SELECT COUNT(*) FROM billing WHERE status = 'Paid'"
        Using paidCountConnection As New MySqlConnection(connectionString)
            Using paidCountCommand As New MySqlCommand(paidCountQuery, paidCountConnection)
                Try
                    paidCountConnection.Open()
                    Dim paidCount = paidCountCommand.ExecuteScalar()
                    Console.WriteLine("Total 'Paid' records in billing table: " & paidCount)
                Catch ex As Exception
                    Console.WriteLine("Error counting paid records: " & ex.Message)
                End Try
            End Using
        End Using

        ' Get all unique status values
        Dim statusQuery As String = "SELECT DISTINCT status FROM billing"
        Using statusConnection As New MySqlConnection(connectionString)
            Using statusCommand As New MySqlCommand(statusQuery, statusConnection)
                Try
                    statusConnection.Open()
                    Using reader As MySqlDataReader = statusCommand.ExecuteReader()
                        Console.WriteLine("Unique status values in billing table:")
                        While reader.Read()
                            Console.WriteLine("- " & reader.GetString(0))
                        End While
                    End Using
                Catch ex As Exception
                    Console.WriteLine("Error getting unique status values: " & ex.Message)
                End Try
            End Using
        End Using

        ' Main query for today's payments
        Dim query As String = "
    SELECT 
        SUM(total_amount) AS TodayTotal
    FROM 
        billing
    WHERE 
        status = 'Paid'
        AND DATE(date) = '" & today & "'"

        Console.WriteLine("Final query: " & query)

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()

                    Console.WriteLine("Query result: " & If(result Is Nothing, "NULL", result.ToString()))

                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        todayTotal = Convert.ToDecimal(result)
                        Console.WriteLine("Converted to decimal: " & todayTotal)
                    End If

                    lblTotalPaymentToday.Text = String.Format("{0:C}", todayTotal)
                    Console.WriteLine("Set label text to: " & lblTotalPaymentToday.Text)
                Catch ex As Exception
                    MessageBox.Show("Error calculating today's payments: " & ex.Message)
                    lblTotalPaymentToday.Text = "$0.00"
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub


    Private Sub LoadAccountantProfile()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim query As String = "SELECT first_name, middle_name, last_name, age, username, " &
                      "email_address, contact_number, address " &
                      "FROM accountant WHERE accountant_id = @accountantID"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@accountantID", AccountantID)

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

            UpdateAccountantInfo()

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

    Private Sub UpdateAccountantInfo()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Try
            Dim query As String
            If String.IsNullOrEmpty(txtPassword.Text) Then
                query = "UPDATE accountant SET 
                first_name = @firstName, 
                middle_name = @middleName, 
                last_name = @lastName, 
                age = @age, 
                email_address = @emailAddress, 
                contact_number = @contactNumber, 
                address = @address, 
                username = @username 
                WHERE accountant_id = @accountantID"
            Else
                query = "UPDATE accountant SET 
                first_name = @firstName, 
                middle_name = @middleName, 
                last_name = @lastName, 
                age = @age, 
                email_address = @emailAddress, 
                contact_number = @contactNumber, 
                address = @address, 
                username = @username, 
                password = @password 
                WHERE accountant_id = @accountantID"
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
                    command.Parameters.AddWithValue("@accountantID", AccountantID)

                    If Not String.IsNullOrEmpty(txtPassword.Text) Then
                        command.Parameters.AddWithValue("@password", txtPassword.Text)
                    End If

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected = 0 Then
                        Throw New Exception("No accountant records were updated. Please check if the accountant information exists.")
                    End If

                    Console.WriteLine($"Successfully updated accountant info. Rows affected: {rowsAffected}")
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error updating accountant: " & ex.Message & Environment.NewLine & "Error code: " & ex.Number, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        Catch ex As Exception
            Throw New Exception("Error updating accountant information: " & ex.Message, ex)
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
        Dim insertQuery As String = "INSERT INTO users (username, password, role) VALUES (@username, @password, 'accountant')"

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
        Dim query As String = "SELECT username FROM accountant WHERE accountant_id = @accountantID"
        Dim username As String = String.Empty

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@accountantID", AccountantID)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot Nothing Then
                    username = result.ToString()
                End If
            End Using
        End Using

        Return username
    End Function

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

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        If txtPassword.Text <> txtConfirmPassword.Text Then
            errorProvider.SetError(txtConfirmPassword, "Passwords do not match")
        Else
            errorProvider.SetError(txtConfirmPassword, "")
        End If
    End Sub

    Private Sub AccountingDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub lblTotalPaymentToday_Click(sender As Object, e As EventArgs) Handles lblTotalPaymentToday.Click

    End Sub
End Class