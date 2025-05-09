Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Public Class BillingDetails
    Public Property BillingId As String = ""

    Private conn As MySqlConnection
    Private cmd As MySqlCommand

    Private patientName As String = ""
    Private billingDate As Date = Date.Now
    Private totalAmount As Decimal = 0
    Private billingItems As String = ""
    Private billingStatus As String = ""

    Private Sub BillingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAmountDueCash.ReadOnly = True
        txtAmountDueCash.BackColor = SystemColors.Control

        txtAmountDueCard.ReadOnly = True
        txtAmountDueCard.BackColor = SystemColors.Control

        SetupItemsDataGrid()

        LoadBillingData()

        ' Event handlers for validation

        AddHandler txtCCV.KeyPress, AddressOf DigitsOnly_KeyPress
        AddHandler txtCCV.TextChanged, AddressOf ValidateCCV
        AddHandler txtCCV.Leave, AddressOf CheckCCVMinLength

        AddHandler txtPostal.KeyPress, AddressOf DigitsOnly_KeyPress
        AddHandler txtPostal.TextChanged, AddressOf ValidatePostal
        AddHandler txtPostal.Leave, AddressOf CheckPostalMinLength

        AddHandler txtAmountReceived.KeyPress, AddressOf NumberAndDecimalOnly_KeyPress
        AddHandler txtCardNumber.TextChanged, AddressOf FormatCardNumber
        AddHandler txtEpirationMonth.TextChanged, AddressOf ValidateExpirationMonth
        AddHandler txtEpirationMonth.Leave, AddressOf FormatExpirationMonth
        AddHandler txtExpirationYear.TextChanged, AddressOf ValidateExpirationYear

        AddHandler txtAmountReceived.TextChanged, AddressOf CalculateChange
    End Sub

    Private Sub SetupItemsDataGrid()
        dgvItems.AllowUserToAddRows = False
        dgvItems.AllowUserToDeleteRows = False
        dgvItems.ReadOnly = True
        dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvItems.MultiSelect = False
        dgvItems.BackgroundColor = Color.White
        dgvItems.BorderStyle = BorderStyle.None
        dgvItems.RowHeadersVisible = False
        dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvItems.ColumnHeadersHeight = 40
        dgvItems.ColumnHeadersDefaultCellStyle.Font = New Font(dgvItems.Font, FontStyle.Bold)

        dgvItems.Columns.Clear()

        ' Add columns
        Dim itemNameColumn As New DataGridViewTextBoxColumn()
        itemNameColumn.HeaderText = "Item"
        itemNameColumn.Name = "ItemName"
        itemNameColumn.MinimumWidth = 140
        itemNameColumn.FillWeight = 30
        dgvItems.Columns.Add(itemNameColumn)

        Dim descriptionColumn As New DataGridViewTextBoxColumn()
        descriptionColumn.HeaderText = "Description"
        descriptionColumn.Name = "Description"
        descriptionColumn.MinimumWidth = 140
        descriptionColumn.FillWeight = 30
        dgvItems.Columns.Add(descriptionColumn)

        Dim priceColumn As New DataGridViewTextBoxColumn()
        priceColumn.HeaderText = "Price"
        priceColumn.Name = "Price"
        priceColumn.MinimumWidth = 60
        priceColumn.FillWeight = 15
        dgvItems.Columns.Add(priceColumn)

        Dim quantityColumn As New DataGridViewTextBoxColumn()
        quantityColumn.HeaderText = "Qty"
        quantityColumn.Name = "Quantity"
        quantityColumn.MinimumWidth = 40
        quantityColumn.FillWeight = 10
        dgvItems.Columns.Add(quantityColumn)

        Dim totalColumn As New DataGridViewTextBoxColumn()
        totalColumn.HeaderText = "Total"
        totalColumn.Name = "Total"
        totalColumn.MinimumWidth = 80
        totalColumn.FillWeight = 15
        dgvItems.Columns.Add(totalColumn)

        ' Add handler for formatting cells
        AddHandler dgvItems.CellFormatting, AddressOf dgvItems_CellFormatting
    End Sub

    Private Sub dgvItems_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = dgvItems.Columns("Price").Index OrElse e.ColumnIndex = dgvItems.Columns("Total").Index Then
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
                e.Value = Format(Decimal.Parse(e.Value.ToString()), "₱ #,##0.00")
                e.FormattingApplied = True
            End If
        End If
    End Sub

    ' Load items from JSON string
    Private Sub LoadItemsFromJson(jsonString As String)
        If String.IsNullOrEmpty(jsonString) Then
            Return
        End If

        Try
            dgvItems.Rows.Clear()

            If jsonString.Trim() = "[2]" OrElse Regex.IsMatch(jsonString.Trim(), "^\[\d+\]$") Then
                dgvItems.Rows.Add("Unknown Item", "Item details not available", 0, 0, 0)
                MessageBox.Show("The billing contains minimal item information. Please update billing with complete details.", "Limited Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Dim items As List(Of Dictionary(Of String, Object))

            Try
                items = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(jsonString)
            Catch ex As Exception
                Dim sanitizedJson As String = jsonString.Trim()

                If Not sanitizedJson.StartsWith("[") Then
                    sanitizedJson = "[" & sanitizedJson & "]"
                End If

                items = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(sanitizedJson)
            End Try

            For Each item In items
                Dim itemName As String = If(item.ContainsKey("item_name"), item("item_name").ToString(), "")
                Dim description As String = If(item.ContainsKey("description"), item("description").ToString(), "")

                Dim price As Decimal = 0
                If item.ContainsKey("price") Then
                    Decimal.TryParse(item("price").ToString(), price)
                End If

                Dim quantity As Integer = 0
                If item.ContainsKey("quantity") Then
                    Integer.TryParse(item("quantity").ToString(), quantity)
                End If

                Dim total As Decimal = 0
                If item.ContainsKey("total") Then
                    Decimal.TryParse(item("total").ToString(), total)
                Else
                    total = price * quantity
                End If

                dgvItems.Rows.Add(itemName, description, price, quantity, total)
            Next

        Catch ex As Exception
            MessageBox.Show($"Error parsing item data: {ex.Message}{Environment.NewLine}JSON: {jsonString}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            dgvItems.Rows.Add("Error loading items", "JSON format issue: " & ex.Message, 0, 0, 0)

            If jsonString.Contains("item_name") AndAlso jsonString.Contains("price") Then
                Try
                    Dim item As New Dictionary(Of String, Object)()

                    Dim nameMatch = Regex.Match(jsonString, "item_name""\s*:\s*""([^""]+)""")
                    Dim priceMatch = Regex.Match(jsonString, "price""\s*:\s*(\d+)")
                    Dim qtyMatch = Regex.Match(jsonString, "quantity""\s*:\s*(\d+)")
                    Dim descMatch = Regex.Match(jsonString, "description""\s*:\s*""([^""]+)""")

                    If nameMatch.Success Then
                        dgvItems.Rows.Add(
                        nameMatch.Groups(1).Value,
                        If(descMatch.Success, descMatch.Groups(1).Value, ""),
                        If(priceMatch.Success, Decimal.Parse(priceMatch.Groups(1).Value), 0),
                        If(qtyMatch.Success, Integer.Parse(qtyMatch.Groups(1).Value), 1),
                        If(priceMatch.Success AndAlso qtyMatch.Success,
                           Decimal.Parse(priceMatch.Groups(1).Value) * Integer.Parse(qtyMatch.Groups(1).Value),
                           If(priceMatch.Success, Decimal.Parse(priceMatch.Groups(1).Value), 0))
                    )
                    End If
                Catch innerEx As Exception
                    Console.WriteLine("Alternative parsing failed: " & innerEx.Message)
                End Try
            End If
        End Try
    End Sub

    ' Load billing data
    Private Sub LoadBillingData()
        If String.IsNullOrEmpty(BillingId) Then
            MessageBox.Show("No billing ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "
            SELECT 
                b.billing_id, 
                CONCAT(p.first_name, ' ', p.last_name) AS patient_name,
                b.date, 
                b.item_names, 
                b.total_amount, 
                b.status,
                p.patient_id,
                p.next_checkup,
                p.last_menstrual_period,
                p.due_date
            FROM 
                billing b
            INNER JOIN 
                patient p ON b.patient_id = p.patient_id
            WHERE 
                b.billing_id = @billingId"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@billingId", BillingId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            patientName = reader("patient_name").ToString()
                            billingDate = Convert.ToDateTime(reader("date"))
                            billingItems = reader("item_names").ToString()
                            totalAmount = Convert.ToDecimal(reader("total_amount"))
                            billingStatus = reader("status").ToString()

                            Console.WriteLine("Raw JSON from database: " & billingItems)

                            Dim gestationalAge As String = "Not Available"
                            If reader("last_menstrual_period") IsNot DBNull.Value Then
                                Dim lmpDate As DateTime = Convert.ToDateTime(reader("last_menstrual_period"))
                                Dim weeks As Integer = DateDiff(DateInterval.Day, lmpDate, DateTime.Now) \ 7
                                Dim days As Integer = DateDiff(DateInterval.Day, lmpDate, DateTime.Now) Mod 7
                                gestationalAge = $"{weeks} weeks and {days} days"
                            End If

                            lblPatientName.Text = patientName
                            lblPatientID.Text = reader("patient_id").ToString()
                            lblGestationalAge.Text = gestationalAge
                            lblLastVisit.Text = If(reader("next_checkup") IsNot DBNull.Value,
                                          Convert.ToDateTime(reader("next_checkup")).ToString("MMMM dd, yyyy"),
                                          "Not Available")
                            lblBillingDate.Text = billingDate.ToString("MMMM dd, yyyy")
                            txtAmountDueCash.Text = totalAmount.ToString("F2")
                            txtAmountDueCard.Text = totalAmount.ToString("F2")

                            LoadItemsFromJson(billingItems)
                        Else
                            MessageBox.Show("Billing record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.DialogResult = DialogResult.Cancel
                            Me.Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading billing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

    ' Pay Bill button handlers
    Private Sub btnPayBillCash_Click(sender As Object, e As EventArgs) Handles btnPayBillCash.Click
        ProcessPayment("Cash")
    End Sub

    Private Sub btnPayBillCard_Click(sender As Object, e As EventArgs) Handles btnPayBillCard.Click
        ProcessPayment("Card")
    End Sub

    ' Process payment
    Private Sub ProcessPayment(paymentMethod As String)
        If paymentMethod = "Cash" Then
            If String.IsNullOrWhiteSpace(txtAmountReceived.Text) Then
                MessageBox.Show("Please enter the amount received.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAmountReceived.Focus()
                Return
            End If

            Dim amountDue As Decimal = Decimal.Parse(txtAmountDueCash.Text)
            Dim amountReceived As Decimal = Decimal.Parse(txtAmountReceived.Text)

            If amountReceived < amountDue Then
                MessageBox.Show("Amount received is less than the amount due.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAmountReceived.Focus()
                Return
            End If
        ElseIf paymentMethod = "Card" Then
            If String.IsNullOrWhiteSpace(txtCardNumber.Text) OrElse txtCardNumber.Text.Replace(" ", "").Length < 16 Then
                MessageBox.Show("Please enter a valid card number.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCardNumber.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtEpirationMonth.Text) Then
                MessageBox.Show("Please enter the expiration month.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEpirationMonth.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtExpirationYear.Text) Then
                MessageBox.Show("Please enter the expiration year.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtExpirationYear.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtCCV.Text) OrElse txtCCV.Text.Length < 3 Then
                MessageBox.Show("Please enter a valid CCV.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCCV.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtCardHolderName.Text) Then
                MessageBox.Show("Please enter the cardholder name.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCardHolderName.Focus()
                Return
            End If
        End If

        ' Update the billing status in the database
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "UPDATE billing SET status = 'Paid', notes = @paymentMethod WHERE billing_id = @billingId"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@billingId", BillingId)
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("Failed to update billing status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error processing payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Event handler for allowing only numbers and decimal points
    Private Sub NumberAndDecimalOnly_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        If e.KeyChar = "."c AndAlso DirectCast(sender, TextBox).Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ' Event handler for allowing only digits
    Private Sub DigitsOnly_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Calculate change when amount received changes
    Private Sub CalculateChange(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrWhiteSpace(txtAmountReceived.Text) OrElse String.IsNullOrWhiteSpace(txtAmountDueCash.Text) Then
                lblChange.Text = "-"
                Return
            End If

            Dim amountDue As Decimal = Decimal.Parse(txtAmountDueCash.Text)
            Dim amountReceived As Decimal = Decimal.Parse(txtAmountReceived.Text)
            Dim change As Decimal = amountReceived - amountDue

            If change >= 0 Then
                lblChange.Text = change.ToString("C")
            Else
                lblChange.Text = "Insufficient payment"
            End If
        Catch ex As Exception
            lblChange.Text = "Invalid amount"
        End Try
    End Sub

    ' Format card number with spaces after every 4 digits
    Private Sub FormatCardNumber(sender As Object, e As EventArgs)
        Dim cursorPosition As Integer = txtCardNumber.SelectionStart
        Dim lengthBefore As Integer = txtCardNumber.Text.Length

        Dim cardNumber As String = txtCardNumber.Text.Replace(" ", "")

        If cardNumber.Length > 16 Then
            cardNumber = cardNumber.Substring(0, 16)
        End If

        Dim result As String = ""
        For Each c As Char In cardNumber
            If Char.IsDigit(c) Then
                result += c
            End If
        Next

        Dim formattedNumber As String = ""
        For i As Integer = 0 To result.Length - 1
            If i > 0 AndAlso i Mod 4 = 0 Then
                formattedNumber += " "
            End If
            formattedNumber += result(i)
        Next

        If txtCardNumber.Text <> formattedNumber Then
            txtCardNumber.Text = formattedNumber

            Dim spacesBeforeCursor As Integer = 0
            For i As Integer = 0 To Math.Min(cursorPosition - 1, formattedNumber.Length - 1)
                If formattedNumber(i) = " "c Then
                    spacesBeforeCursor += 1
                End If
            Next

            Dim adjustment As Integer = 0
            If formattedNumber.Length > lengthBefore Then
                adjustment = 1
            End If

            txtCardNumber.SelectionStart = Math.Min(cursorPosition + adjustment, formattedNumber.Length)
        End If
    End Sub

    ' Validate expiration month
    Private Sub ValidateExpirationMonth(sender As Object, e As EventArgs)
        Dim text As String = txtEpirationMonth.Text

        Dim result As String = ""
        For Each c As Char In text
            If Char.IsDigit(c) Then
                result += c
            End If
        Next

        ' Limit to 2 digits
        If result.Length > 2 Then
            result = result.Substring(0, 2)
        End If

        If result.Length = 2 Then
            Dim month As Integer
            If Integer.TryParse(result, month) Then
                If month < 1 OrElse month > 12 Then
                    result = ""
                End If
            End If
        End If

        If text <> result Then
            txtEpirationMonth.Text = result
            txtEpirationMonth.SelectionStart = result.Length
        End If
    End Sub

    ' Format expiration month
    Private Sub FormatExpirationMonth(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(txtEpirationMonth.Text) Then
            Dim month As Integer
            If Integer.TryParse(txtEpirationMonth.Text, month) Then
                If month >= 1 AndAlso month <= 12 Then
                    txtEpirationMonth.Text = month.ToString("00")
                End If
            End If
        End If
    End Sub

    ' Validate expiration year
    Private Sub ValidateExpirationYear(sender As Object, e As EventArgs)
        Dim text As String = txtExpirationYear.Text

        Dim result As String = ""
        For Each c As Char In text
            If Char.IsDigit(c) Then
                result += c
            End If
        Next

        If result.Length > 2 Then
            result = result.Substring(0, 2)
        End If

        If result.Length = 2 Then
            Dim enteredYear As Integer
            Dim currentYear As Integer = Date.Now.Year Mod 100

            If Integer.TryParse(result, enteredYear) Then
                If enteredYear < currentYear Then
                    result = ""
                End If
            End If
        End If

        If text <> result Then
            txtExpirationYear.Text = result
            txtExpirationYear.SelectionStart = result.Length
        End If
    End Sub

    ' Validate CCV
    Private Sub ValidateCCV(sender As Object, e As EventArgs)
        Dim text As String = txtCCV.Text

        Dim result As String = ""
        For Each c As Char In text
            If Char.IsDigit(c) Then
                result += c
            End If
        Next

        If result.Length > 3 Then
            result = result.Substring(0, 3)
        End If

        If text <> result Then
            txtCCV.Text = result
            txtCCV.SelectionStart = result.Length
        End If
    End Sub

    Private Sub CheckCCVMinLength(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(txtCCV.Text) AndAlso txtCCV.Text.Length < 3 Then
            MessageBox.Show("CCV must be at least 3 digits.", "Invalid CCV", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCCV.Focus()
        End If
    End Sub

    ' Validate Postal Code
    Private Sub ValidatePostal(sender As Object, e As EventArgs)
        Dim text As String = txtPostal.Text

        Dim result As String = ""
        For Each c As Char In text
            If Char.IsDigit(c) Then
                result += c
            End If
        Next

        If result.Length > 4 Then
            result = result.Substring(0, 4)
        End If

        If text <> result Then
            txtPostal.Text = result
            txtPostal.SelectionStart = result.Length
        End If
    End Sub

    Private Sub CheckPostalMinLength(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(txtPostal.Text) AndAlso txtPostal.Text.Length < 3 Then
            MessageBox.Show("Postal code must be at least 3 digits.", "Invalid Postal Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPostal.Focus()
        End If
    End Sub

End Class
