<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        lblLastVisit = New Label()
        lblPatientName = New Label()
        Label4 = New Label()
        lblPatientID = New Label()
        tabModePayment = New TabControl()
        tabCash = New TabPage()
        btnPayBillCash = New FontAwesome.Sharp.IconButton()
        lblChange = New Label()
        Label17 = New Label()
        txtAmountReceived = New TextBox()
        txtAmountDueCash = New TextBox()
        Label16 = New Label()
        Label15 = New Label()
        tabCard = New TabPage()
        txtAmountDueCard = New TextBox()
        Label19 = New Label()
        Label14 = New Label()
        Label10 = New Label()
        txtPostal = New TextBox()
        Label13 = New Label()
        txtExpirationYear = New TextBox()
        txtCardHolderName = New TextBox()
        txtBillingAddress = New TextBox()
        txtCCV = New TextBox()
        txtEpirationMonth = New TextBox()
        txtCardNumber = New TextBox()
        Label12 = New Label()
        Label11 = New Label()
        btnPayBillCard = New FontAwesome.Sharp.IconButton()
        Label9 = New Label()
        Label8 = New Label()
        pnlItems = New Panel()
        dgvItems = New DataGridView()
        lblGestationalAge = New Label()
        Label5 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        lblAppointmentHeader = New Label()
        lblBillingDate = New Label()
        Panel1.SuspendLayout()
        tabModePayment.SuspendLayout()
        tabCash.SuspendLayout()
        tabCard.SuspendLayout()
        pnlItems.SuspendLayout()
        CType(dgvItems, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' HopeForm1
        ' 
        HopeForm1.ControlBoxColorH = Color.FromArgb(CByte(228), CByte(231), CByte(237))
        HopeForm1.ControlBoxColorHC = Color.FromArgb(CByte(245), CByte(108), CByte(108))
        HopeForm1.ControlBoxColorN = Color.White
        HopeForm1.Dock = DockStyle.Top
        HopeForm1.Font = New Font("Segoe UI", 12F)
        HopeForm1.ForeColor = Color.FromArgb(CByte(242), CByte(246), CByte(252))
        HopeForm1.Image = My.Resources.Resources.icon
        HopeForm1.Location = New Point(0, 0)
        HopeForm1.MaximizeBox = False
        HopeForm1.Name = "HopeForm1"
        HopeForm1.Size = New Size(1192, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "Billing Details"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackgroundImage = My.Resources.Resources.Billing__1_
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(lblLastVisit)
        Panel1.Controls.Add(lblPatientName)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(lblPatientID)
        Panel1.Controls.Add(tabModePayment)
        Panel1.Controls.Add(pnlItems)
        Panel1.Controls.Add(lblGestationalAge)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(lblAppointmentHeader)
        Panel1.Controls.Add(lblBillingDate)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1192, 465)
        Panel1.TabIndex = 1
        ' 
        ' lblLastVisit
        ' 
        lblLastVisit.AutoSize = True
        lblLastVisit.BackColor = Color.Transparent
        lblLastVisit.Font = New Font("Verdana", 10.2F)
        lblLastVisit.Location = New Point(213, 157)
        lblLastVisit.Name = "lblLastVisit"
        lblLastVisit.Size = New Size(82, 20)
        lblLastVisit.TabIndex = 42
        lblLastVisit.Text = "last visit"
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.BackColor = Color.Transparent
        lblPatientName.Font = New Font("Verdana", 10.2F)
        lblPatientName.Location = New Point(212, 97)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.Size = New Size(124, 20)
        lblPatientName.TabIndex = 39
        lblPatientName.Text = "patient name"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 10.2F)
        Label4.Location = New Point(117, 157)
        Label4.Name = "Label4"
        Label4.Size = New Size(96, 20)
        Label4.TabIndex = 48
        Label4.Text = "Last Visit:"
        ' 
        ' lblPatientID
        ' 
        lblPatientID.AutoSize = True
        lblPatientID.BackColor = Color.Transparent
        lblPatientID.Font = New Font("Verdana", 10.2F)
        lblPatientID.Location = New Point(212, 117)
        lblPatientID.Name = "lblPatientID"
        lblPatientID.Size = New Size(92, 20)
        lblPatientID.TabIndex = 40
        lblPatientID.Text = "patient id"
        ' 
        ' tabModePayment
        ' 
        tabModePayment.Controls.Add(tabCash)
        tabModePayment.Controls.Add(tabCard)
        tabModePayment.Location = New Point(600, 52)
        tabModePayment.Name = "tabModePayment"
        tabModePayment.SelectedIndex = 0
        tabModePayment.Size = New Size(562, 387)
        tabModePayment.SizeMode = TabSizeMode.Fixed
        tabModePayment.TabIndex = 54
        ' 
        ' tabCash
        ' 
        tabCash.BackColor = Color.FromArgb(CByte(250), CByte(210), CByte(235))
        tabCash.Controls.Add(btnPayBillCash)
        tabCash.Controls.Add(lblChange)
        tabCash.Controls.Add(Label17)
        tabCash.Controls.Add(txtAmountReceived)
        tabCash.Controls.Add(txtAmountDueCash)
        tabCash.Controls.Add(Label16)
        tabCash.Controls.Add(Label15)
        tabCash.Location = New Point(4, 29)
        tabCash.Name = "tabCash"
        tabCash.Padding = New Padding(3)
        tabCash.Size = New Size(554, 354)
        tabCash.TabIndex = 0
        tabCash.Text = "Cash"
        ' 
        ' btnPayBillCash
        ' 
        btnPayBillCash.Font = New Font("Verdana", 12F)
        btnPayBillCash.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        btnPayBillCash.IconColor = Color.Black
        btnPayBillCash.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPayBillCash.IconSize = 40
        btnPayBillCash.ImageAlign = ContentAlignment.BottomRight
        btnPayBillCash.Location = New Point(201, 280)
        btnPayBillCash.Name = "btnPayBillCash"
        btnPayBillCash.Size = New Size(152, 54)
        btnPayBillCash.TabIndex = 54
        btnPayBillCash.Text = "Pay Bill"
        btnPayBillCash.TextImageRelation = TextImageRelation.TextBeforeImage
        btnPayBillCash.UseVisualStyleBackColor = True
        ' 
        ' lblChange
        ' 
        lblChange.AutoSize = True
        lblChange.BackColor = Color.Transparent
        lblChange.Font = New Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblChange.Location = New Point(225, 225)
        lblChange.Name = "lblChange"
        lblChange.Size = New Size(22, 29)
        lblChange.TabIndex = 5
        lblChange.Text = "-"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(41, 220)
        Label17.Name = "Label17"
        Label17.Size = New Size(153, 39)
        Label17.TabIndex = 4
        Label17.Text = "Change:"
        ' 
        ' txtAmountReceived
        ' 
        txtAmountReceived.Location = New Point(170, 169)
        txtAmountReceived.Name = "txtAmountReceived"
        txtAmountReceived.Size = New Size(212, 27)
        txtAmountReceived.TabIndex = 3
        ' 
        ' txtAmountDueCash
        ' 
        txtAmountDueCash.Enabled = False
        txtAmountDueCash.Location = New Point(171, 78)
        txtAmountDueCash.Name = "txtAmountDueCash"
        txtAmountDueCash.Size = New Size(212, 27)
        txtAmountDueCash.TabIndex = 2
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold)
        Label16.Location = New Point(156, 128)
        Label16.Name = "Label16"
        Label16.Size = New Size(242, 32)
        Label16.TabIndex = 1
        Label16.Text = "Amount received"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold)
        Label15.Location = New Point(184, 40)
        Label15.Name = "Label15"
        Label15.Size = New Size(181, 32)
        Label15.TabIndex = 0
        Label15.Text = "Amount Due"
        ' 
        ' tabCard
        ' 
        tabCard.BackColor = Color.FromArgb(CByte(250), CByte(210), CByte(235))
        tabCard.Controls.Add(txtAmountDueCard)
        tabCard.Controls.Add(Label19)
        tabCard.Controls.Add(Label14)
        tabCard.Controls.Add(Label10)
        tabCard.Controls.Add(txtPostal)
        tabCard.Controls.Add(Label13)
        tabCard.Controls.Add(txtExpirationYear)
        tabCard.Controls.Add(txtCardHolderName)
        tabCard.Controls.Add(txtBillingAddress)
        tabCard.Controls.Add(txtCCV)
        tabCard.Controls.Add(txtEpirationMonth)
        tabCard.Controls.Add(txtCardNumber)
        tabCard.Controls.Add(Label12)
        tabCard.Controls.Add(Label11)
        tabCard.Controls.Add(btnPayBillCard)
        tabCard.Controls.Add(Label9)
        tabCard.Controls.Add(Label8)
        tabCard.Location = New Point(4, 29)
        tabCard.Name = "tabCard"
        tabCard.Padding = New Padding(3)
        tabCard.Size = New Size(554, 354)
        tabCard.TabIndex = 1
        tabCard.Text = "Card"
        ' 
        ' txtAmountDueCard
        ' 
        txtAmountDueCard.Enabled = False
        txtAmountDueCard.Location = New Point(216, 49)
        txtAmountDueCard.Name = "txtAmountDueCard"
        txtAmountDueCard.Size = New Size(315, 27)
        txtAmountDueCard.TabIndex = 65
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(39, 49)
        Label19.Name = "Label19"
        Label19.Size = New Size(123, 25)
        Label19.TabIndex = 64
        Label19.Text = "Amount Due:"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(369, 168)
        Label14.Name = "Label14"
        Label14.Size = New Size(15, 20)
        Label14.TabIndex = 63
        Label14.Text = "/"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(39, 167)
        Label10.Name = "Label10"
        Label10.Size = New Size(106, 25)
        Label10.TabIndex = 62
        Label10.Text = "CCV/Postal:"
        ' 
        ' txtPostal
        ' 
        txtPostal.Location = New Point(393, 165)
        txtPostal.Name = "txtPostal"
        txtPostal.PlaceholderText = "postal code"
        txtPostal.Size = New Size(138, 27)
        txtPostal.TabIndex = 61
        txtPostal.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(369, 130)
        Label13.Name = "Label13"
        Label13.Size = New Size(15, 20)
        Label13.TabIndex = 60
        Label13.Text = "/"
        ' 
        ' txtExpirationYear
        ' 
        txtExpirationYear.Location = New Point(393, 126)
        txtExpirationYear.Name = "txtExpirationYear"
        txtExpirationYear.PlaceholderText = "yy"
        txtExpirationYear.Size = New Size(138, 27)
        txtExpirationYear.TabIndex = 59
        txtExpirationYear.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtCardHolderName
        ' 
        txtCardHolderName.Location = New Point(216, 246)
        txtCardHolderName.Name = "txtCardHolderName"
        txtCardHolderName.Size = New Size(315, 27)
        txtCardHolderName.TabIndex = 58
        ' 
        ' txtBillingAddress
        ' 
        txtBillingAddress.Location = New Point(216, 206)
        txtBillingAddress.Name = "txtBillingAddress"
        txtBillingAddress.Size = New Size(315, 27)
        txtBillingAddress.TabIndex = 57
        ' 
        ' txtCCV
        ' 
        txtCCV.Location = New Point(216, 165)
        txtCCV.Name = "txtCCV"
        txtCCV.PlaceholderText = "ccv"
        txtCCV.Size = New Size(138, 27)
        txtCCV.TabIndex = 56
        txtCCV.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtEpirationMonth
        ' 
        txtEpirationMonth.Location = New Point(216, 126)
        txtEpirationMonth.Name = "txtEpirationMonth"
        txtEpirationMonth.PlaceholderText = "mm"
        txtEpirationMonth.Size = New Size(135, 27)
        txtEpirationMonth.TabIndex = 55
        txtEpirationMonth.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtCardNumber
        ' 
        txtCardNumber.Location = New Point(216, 86)
        txtCardNumber.Name = "txtCardNumber"
        txtCardNumber.Size = New Size(315, 27)
        txtCardNumber.TabIndex = 54
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(39, 245)
        Label12.Name = "Label12"
        Label12.Size = New Size(162, 25)
        Label12.TabIndex = 4
        Label12.Text = "Cardholder Name:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(39, 205)
        Label11.Name = "Label11"
        Label11.Size = New Size(141, 25)
        Label11.TabIndex = 3
        Label11.Text = "Billing Address:"
        ' 
        ' btnPayBillCard
        ' 
        btnPayBillCard.Font = New Font("Verdana", 12F)
        btnPayBillCard.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        btnPayBillCard.IconColor = Color.Black
        btnPayBillCard.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPayBillCard.IconSize = 40
        btnPayBillCard.ImageAlign = ContentAlignment.BottomRight
        btnPayBillCard.Location = New Point(379, 289)
        btnPayBillCard.Name = "btnPayBillCard"
        btnPayBillCard.Size = New Size(152, 50)
        btnPayBillCard.TabIndex = 53
        btnPayBillCard.Text = "Pay Bill"
        btnPayBillCard.TextImageRelation = TextImageRelation.TextBeforeImage
        btnPayBillCard.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(39, 125)
        Label9.Name = "Label9"
        Label9.Size = New Size(144, 25)
        Label9.TabIndex = 1
        Label9.Text = "Expiration Date:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(39, 85)
        Label8.Name = "Label8"
        Label8.Size = New Size(129, 25)
        Label8.TabIndex = 0
        Label8.Text = "Card Number:"
        ' 
        ' pnlItems
        ' 
        pnlItems.BackColor = Color.Transparent
        pnlItems.Controls.Add(dgvItems)
        pnlItems.Location = New Point(46, 259)
        pnlItems.Name = "pnlItems"
        pnlItems.Size = New Size(541, 176)
        pnlItems.TabIndex = 51
        ' 
        ' dgvItems
        ' 
        dgvItems.AllowUserToAddRows = False
        dgvItems.AllowUserToDeleteRows = False
        dgvItems.AllowUserToResizeColumns = False
        dgvItems.AllowUserToResizeRows = False
        dgvItems.BackgroundColor = SystemColors.ControlLightLight
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvItems.Dock = DockStyle.Fill
        dgvItems.Location = New Point(0, 0)
        dgvItems.Name = "dgvItems"
        dgvItems.RowHeadersWidth = 51
        dgvItems.Size = New Size(541, 176)
        dgvItems.TabIndex = 0
        ' 
        ' lblGestationalAge
        ' 
        lblGestationalAge.AutoSize = True
        lblGestationalAge.BackColor = Color.Transparent
        lblGestationalAge.Font = New Font("Verdana", 10.2F)
        lblGestationalAge.Location = New Point(212, 137)
        lblGestationalAge.Name = "lblGestationalAge"
        lblGestationalAge.Size = New Size(141, 20)
        lblGestationalAge.TabIndex = 41
        lblGestationalAge.Text = "gestational age"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label5.Location = New Point(46, 15)
        Label5.Name = "Label5"
        Label5.Size = New Size(60, 20)
        Label5.TabIndex = 49
        Label5.Text = "Date:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Verdana", 10.2F)
        Label1.Location = New Point(80, 97)
        Label1.Name = "Label1"
        Label1.Size = New Size(133, 20)
        Label1.TabIndex = 45
        Label1.Text = "Patient Name:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Verdana", 10.2F)
        Label3.Location = New Point(60, 137)
        Label3.Name = "Label3"
        Label3.Size = New Size(153, 20)
        Label3.TabIndex = 47
        Label3.Text = "Gestational Age:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 10.2F)
        Label2.Location = New Point(109, 117)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 20)
        Label2.TabIndex = 46
        Label2.Text = "Patient ID:"
        ' 
        ' lblAppointmentHeader
        ' 
        lblAppointmentHeader.AutoSize = True
        lblAppointmentHeader.BackColor = Color.Transparent
        lblAppointmentHeader.Font = New Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAppointmentHeader.Location = New Point(12, 20)
        lblAppointmentHeader.Name = "lblAppointmentHeader"
        lblAppointmentHeader.Size = New Size(0, 25)
        lblAppointmentHeader.TabIndex = 44
        ' 
        ' lblBillingDate
        ' 
        lblBillingDate.AutoSize = True
        lblBillingDate.BackColor = Color.Transparent
        lblBillingDate.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        lblBillingDate.Location = New Point(109, 15)
        lblBillingDate.Name = "lblBillingDate"
        lblBillingDate.Size = New Size(92, 20)
        lblBillingDate.TabIndex = 43
        lblBillingDate.Text = "due date"
        ' 
        ' BillingDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1192, 505)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 550)
        MinimumSize = New Size(190, 40)
        Name = "BillingDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "BillingDetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        tabModePayment.ResumeLayout(False)
        tabCash.ResumeLayout(False)
        tabCash.PerformLayout()
        tabCard.ResumeLayout(False)
        tabCard.PerformLayout()
        pnlItems.ResumeLayout(False)
        CType(dgvItems, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAppointmentHeader As Label
    Friend WithEvents lblBillingDate As Label
    Friend WithEvents lblGestationalAge As Label
    Friend WithEvents lblPatientID As Label
    Friend WithEvents lblPatientName As Label
    Friend WithEvents pnlItems As Panel
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents btnPayBillCard As FontAwesome.Sharp.IconButton
    Friend WithEvents tabModePayment As TabControl
    Friend WithEvents tabCash As TabPage
    Friend WithEvents tabCard As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtExpirationYear As TextBox
    Friend WithEvents txtCardHolderName As TextBox
    Friend WithEvents txtBillingAddress As TextBox
    Friend WithEvents txtCCV As TextBox
    Friend WithEvents txtEpirationMonth As TextBox
    Friend WithEvents txtCardNumber As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPostal As TextBox
    Friend WithEvents txtAmountReceived As TextBox
    Friend WithEvents txtAmountDueCash As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents btnPayBillCash As FontAwesome.Sharp.IconButton
    Friend WithEvents lblChange As Label
    Friend WithEvents txtAmountDueCard As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents lblLastVisit As Label
End Class
