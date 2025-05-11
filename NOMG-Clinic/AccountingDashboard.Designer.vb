<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountingDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountingDashboard))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        btnSettings = New FontAwesome.Sharp.IconButton()
        btnLogout = New FontAwesome.Sharp.IconButton()
        btnBilling = New FontAwesome.Sharp.IconButton()
        btnPatients = New FontAwesome.Sharp.IconButton()
        btnDashboard = New FontAwesome.Sharp.IconButton()
        pnlDashboard = New Panel()
        Panel3 = New Panel()
        lblTotalPaymentToday = New Label()
        Label2 = New Label()
        Panel2 = New Panel()
        lblTotalRevenue = New Label()
        Label4 = New Label()
        Label1 = New Label()
        flowRecentPayments = New FlowLayoutPanel()
        lblWelcomeMessage = New Label()
        pnlPatients = New Panel()
        Label3 = New Label()
        txtSearchPatient = New TextBox()
        pnlPatientsDataGrid = New Panel()
        dgvPatients = New DataGridView()
        pnlBilling = New Panel()
        Panel4 = New Panel()
        dgvBilling = New DataGridView()
        Label7 = New Label()
        pnlSettings = New Panel()
        txtAddress = New TextBox()
        txtContactNumber = New TextBox()
        txtEmailAddress = New TextBox()
        btnEyeConfirmPassword = New FontAwesome.Sharp.IconButton()
        Label18 = New Label()
        numAge = New NumericUpDown()
        btnEyePassword = New FontAwesome.Sharp.IconButton()
        Label20 = New Label()
        Label19 = New Label()
        txtConfirmPassword = New TextBox()
        Label13 = New Label()
        txtLastName = New TextBox()
        txtPassword = New TextBox()
        Label15 = New Label()
        txtUsername = New TextBox()
        txtMiddleName = New TextBox()
        SmallLabel1 = New ReaLTaiizor.Controls.SmallLabel()
        Label17 = New Label()
        Label10 = New Label()
        Label12 = New Label()
        btnSave = New FontAwesome.Sharp.IconButton()
        Label14 = New Label()
        Label11 = New Label()
        txtFirstName = New TextBox()
        Panel1.SuspendLayout()
        pnlDashboard.SuspendLayout()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        pnlPatients.SuspendLayout()
        pnlPatientsDataGrid.SuspendLayout()
        CType(dgvPatients, ComponentModel.ISupportInitialize).BeginInit()
        pnlBilling.SuspendLayout()
        Panel4.SuspendLayout()
        CType(dgvBilling, ComponentModel.ISupportInitialize).BeginInit()
        pnlSettings.SuspendLayout()
        CType(numAge, ComponentModel.ISupportInitialize).BeginInit()
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
        HopeForm1.Image = CType(resources.GetObject("HopeForm1.Image"), Image)
        HopeForm1.Location = New Point(0, 0)
        HopeForm1.MaximizeBox = False
        HopeForm1.Name = "HopeForm1"
        HopeForm1.Size = New Size(1200, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "Accounting"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(227), CByte(190), CByte(210))
        Panel1.Controls.Add(btnSettings)
        Panel1.Controls.Add(btnLogout)
        Panel1.Controls.Add(btnBilling)
        Panel1.Controls.Add(btnPatients)
        Panel1.Controls.Add(btnDashboard)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 660)
        Panel1.TabIndex = 2
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.Transparent
        btnSettings.Dock = DockStyle.Top
        btnSettings.FlatAppearance.BorderSize = 0
        btnSettings.FlatStyle = FlatStyle.Flat
        btnSettings.Font = New Font("Verdana", 10.2F)
        btnSettings.IconChar = FontAwesome.Sharp.IconChar.Bars
        btnSettings.IconColor = Color.Black
        btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSettings.IconSize = 36
        btnSettings.ImageAlign = ContentAlignment.MiddleLeft
        btnSettings.Location = New Point(0, 180)
        btnSettings.Margin = New Padding(5)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(300, 60)
        btnSettings.TabIndex = 7
        btnSettings.Text = "Settings"
        btnSettings.TextAlign = ContentAlignment.MiddleLeft
        btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Transparent
        btnLogout.Dock = DockStyle.Bottom
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Verdana", 10.2F)
        btnLogout.IconChar = FontAwesome.Sharp.IconChar.RightToBracket
        btnLogout.IconColor = Color.Black
        btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnLogout.IconSize = 36
        btnLogout.ImageAlign = ContentAlignment.MiddleLeft
        btnLogout.Location = New Point(0, 600)
        btnLogout.Margin = New Padding(5)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(300, 60)
        btnLogout.TabIndex = 5
        btnLogout.Text = "Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnBilling
        ' 
        btnBilling.BackColor = Color.Transparent
        btnBilling.Dock = DockStyle.Top
        btnBilling.FlatAppearance.BorderSize = 0
        btnBilling.FlatStyle = FlatStyle.Flat
        btnBilling.Font = New Font("Verdana", 10.2F)
        btnBilling.IconChar = FontAwesome.Sharp.IconChar.CreditCard
        btnBilling.IconColor = Color.Black
        btnBilling.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnBilling.IconSize = 36
        btnBilling.ImageAlign = ContentAlignment.MiddleLeft
        btnBilling.Location = New Point(0, 120)
        btnBilling.Margin = New Padding(5)
        btnBilling.Name = "btnBilling"
        btnBilling.Size = New Size(300, 60)
        btnBilling.TabIndex = 4
        btnBilling.Text = "Billing"
        btnBilling.TextAlign = ContentAlignment.MiddleLeft
        btnBilling.TextImageRelation = TextImageRelation.ImageBeforeText
        btnBilling.UseVisualStyleBackColor = False
        ' 
        ' btnPatients
        ' 
        btnPatients.BackColor = Color.Transparent
        btnPatients.Dock = DockStyle.Top
        btnPatients.FlatAppearance.BorderSize = 0
        btnPatients.FlatStyle = FlatStyle.Flat
        btnPatients.Font = New Font("Verdana", 10.2F)
        btnPatients.IconChar = FontAwesome.Sharp.IconChar.Users
        btnPatients.IconColor = Color.Black
        btnPatients.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPatients.IconSize = 36
        btnPatients.ImageAlign = ContentAlignment.MiddleLeft
        btnPatients.Location = New Point(0, 60)
        btnPatients.Margin = New Padding(5)
        btnPatients.Name = "btnPatients"
        btnPatients.Size = New Size(300, 60)
        btnPatients.TabIndex = 1
        btnPatients.Text = "Patients"
        btnPatients.TextAlign = ContentAlignment.MiddleLeft
        btnPatients.TextImageRelation = TextImageRelation.ImageBeforeText
        btnPatients.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.Transparent
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Verdana", 10.2F)
        btnDashboard.IconChar = FontAwesome.Sharp.IconChar.House
        btnDashboard.IconColor = Color.Black
        btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnDashboard.IconSize = 36
        btnDashboard.ImageAlign = ContentAlignment.MiddleLeft
        btnDashboard.Location = New Point(0, 0)
        btnDashboard.Margin = New Padding(5)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(300, 60)
        btnDashboard.TabIndex = 0
        btnDashboard.Text = "Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlDashboard.Controls.Add(Panel3)
        pnlDashboard.Controls.Add(Panel2)
        pnlDashboard.Controls.Add(Label1)
        pnlDashboard.Controls.Add(flowRecentPayments)
        pnlDashboard.Controls.Add(lblWelcomeMessage)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(300, 40)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(900, 660)
        pnlDashboard.TabIndex = 3
        ' 
        ' Panel3
        ' 
        Panel3.BackgroundImage = My.Resources.Resources.groupbox_bg
        Panel3.BackgroundImageLayout = ImageLayout.Stretch
        Panel3.Controls.Add(lblTotalPaymentToday)
        Panel3.Controls.Add(Label2)
        Panel3.Location = New Point(460, 63)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(405, 157)
        Panel3.TabIndex = 10
        ' 
        ' lblTotalPaymentToday
        ' 
        lblTotalPaymentToday.AutoSize = True
        lblTotalPaymentToday.BackColor = Color.Transparent
        lblTotalPaymentToday.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalPaymentToday.Location = New Point(12, 83)
        lblTotalPaymentToday.Name = "lblTotalPaymentToday"
        lblTotalPaymentToday.Size = New Size(243, 28)
        lblTotalPaymentToday.TabIndex = 6
        lblTotalPaymentToday.Text = "Total within a day"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 10.8F, FontStyle.Bold)
        Label2.Location = New Point(62, 11)
        Label2.Name = "Label2"
        Label2.Size = New Size(275, 22)
        Label2.TabIndex = 5
        Label2.Text = "Payments Received Today"
        ' 
        ' Panel2
        ' 
        Panel2.BackgroundImage = My.Resources.Resources.groupbox_bg
        Panel2.BackgroundImageLayout = ImageLayout.Stretch
        Panel2.Controls.Add(lblTotalRevenue)
        Panel2.Controls.Add(Label4)
        Panel2.Location = New Point(22, 63)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(405, 157)
        Panel2.TabIndex = 9
        ' 
        ' lblTotalRevenue
        ' 
        lblTotalRevenue.AutoSize = True
        lblTotalRevenue.BackColor = Color.Transparent
        lblTotalRevenue.Font = New Font("Verdana", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalRevenue.Location = New Point(12, 85)
        lblTotalRevenue.Name = "lblTotalRevenue"
        lblTotalRevenue.Size = New Size(185, 28)
        lblTotalRevenue.TabIndex = 6
        lblTotalRevenue.Text = "Total Amount"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 10.8F, FontStyle.Bold)
        Label4.Location = New Point(119, 11)
        Label4.Name = "Label4"
        Label4.Size = New Size(154, 22)
        Label4.TabIndex = 5
        Label4.Text = "Total Revenue"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(25, 229)
        Label1.Name = "Label1"
        Label1.Size = New Size(186, 22)
        Label1.TabIndex = 7
        Label1.Text = "Recent Payments"
        ' 
        ' flowRecentPayments
        ' 
        flowRecentPayments.AutoScroll = True
        flowRecentPayments.Location = New Point(27, 260)
        flowRecentPayments.Name = "flowRecentPayments"
        flowRecentPayments.Size = New Size(838, 385)
        flowRecentPayments.TabIndex = 0
        ' 
        ' lblWelcomeMessage
        ' 
        lblWelcomeMessage.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        lblWelcomeMessage.Font = New Font("Verdana", 16.2F, FontStyle.Bold)
        lblWelcomeMessage.Location = New Point(23, 14)
        lblWelcomeMessage.Name = "lblWelcomeMessage"
        lblWelcomeMessage.Size = New Size(851, 38)
        lblWelcomeMessage.TabIndex = 0
        lblWelcomeMessage.Text = "Welcome!"
        ' 
        ' pnlPatients
        ' 
        pnlPatients.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlPatients.Controls.Add(Label3)
        pnlPatients.Controls.Add(txtSearchPatient)
        pnlPatients.Controls.Add(pnlPatientsDataGrid)
        pnlPatients.Dock = DockStyle.Fill
        pnlPatients.Location = New Point(300, 40)
        pnlPatients.Name = "pnlPatients"
        pnlPatients.Size = New Size(900, 660)
        pnlPatients.TabIndex = 13
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(21, 26)
        Label3.Name = "Label3"
        Label3.Size = New Size(147, 34)
        Label3.TabIndex = 8
        Label3.Text = "Patients"
        ' 
        ' txtSearchPatient
        ' 
        txtSearchPatient.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchPatient.Location = New Point(21, 80)
        txtSearchPatient.Name = "txtSearchPatient"
        txtSearchPatient.PlaceholderText = "Search patient..."
        txtSearchPatient.Size = New Size(250, 32)
        txtSearchPatient.TabIndex = 7
        ' 
        ' pnlPatientsDataGrid
        ' 
        pnlPatientsDataGrid.Controls.Add(dgvPatients)
        pnlPatientsDataGrid.Location = New Point(21, 134)
        pnlPatientsDataGrid.Name = "pnlPatientsDataGrid"
        pnlPatientsDataGrid.Size = New Size(852, 514)
        pnlPatientsDataGrid.TabIndex = 6
        ' 
        ' dgvPatients
        ' 
        dgvPatients.ColumnHeadersHeight = 29
        dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvPatients.Dock = DockStyle.Fill
        dgvPatients.Location = New Point(0, 0)
        dgvPatients.Name = "dgvPatients"
        dgvPatients.RowHeadersWidth = 51
        dgvPatients.Size = New Size(852, 514)
        dgvPatients.TabIndex = 4
        ' 
        ' pnlBilling
        ' 
        pnlBilling.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlBilling.Controls.Add(Panel4)
        pnlBilling.Controls.Add(Label7)
        pnlBilling.Dock = DockStyle.Fill
        pnlBilling.Location = New Point(300, 40)
        pnlBilling.Name = "pnlBilling"
        pnlBilling.Size = New Size(900, 660)
        pnlBilling.TabIndex = 13
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(dgvBilling)
        Panel4.Location = New Point(24, 93)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(852, 555)
        Panel4.TabIndex = 5
        ' 
        ' dgvBilling
        ' 
        dgvBilling.AllowUserToResizeColumns = False
        dgvBilling.ColumnHeadersHeight = 29
        dgvBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvBilling.Dock = DockStyle.Fill
        dgvBilling.Location = New Point(0, 0)
        dgvBilling.Name = "dgvBilling"
        dgvBilling.RowHeadersWidth = 51
        dgvBilling.Size = New Size(852, 555)
        dgvBilling.TabIndex = 4
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(24, 32)
        Label7.Name = "Label7"
        Label7.Size = New Size(133, 34)
        Label7.TabIndex = 1
        Label7.Text = "Billings"
        ' 
        ' pnlSettings
        ' 
        pnlSettings.AutoScroll = True
        pnlSettings.BackColor = Color.Transparent
        pnlSettings.BackgroundImage = My.Resources.Resources.Settings__1_
        pnlSettings.BackgroundImageLayout = ImageLayout.Stretch
        pnlSettings.Controls.Add(txtAddress)
        pnlSettings.Controls.Add(txtContactNumber)
        pnlSettings.Controls.Add(txtEmailAddress)
        pnlSettings.Controls.Add(btnEyeConfirmPassword)
        pnlSettings.Controls.Add(Label18)
        pnlSettings.Controls.Add(numAge)
        pnlSettings.Controls.Add(btnEyePassword)
        pnlSettings.Controls.Add(Label20)
        pnlSettings.Controls.Add(Label19)
        pnlSettings.Controls.Add(txtConfirmPassword)
        pnlSettings.Controls.Add(Label13)
        pnlSettings.Controls.Add(txtLastName)
        pnlSettings.Controls.Add(txtPassword)
        pnlSettings.Controls.Add(Label15)
        pnlSettings.Controls.Add(txtUsername)
        pnlSettings.Controls.Add(txtMiddleName)
        pnlSettings.Controls.Add(SmallLabel1)
        pnlSettings.Controls.Add(Label17)
        pnlSettings.Controls.Add(Label10)
        pnlSettings.Controls.Add(Label12)
        pnlSettings.Controls.Add(btnSave)
        pnlSettings.Controls.Add(Label14)
        pnlSettings.Controls.Add(Label11)
        pnlSettings.Controls.Add(txtFirstName)
        pnlSettings.Dock = DockStyle.Fill
        pnlSettings.Location = New Point(300, 40)
        pnlSettings.Name = "pnlSettings"
        pnlSettings.Size = New Size(900, 660)
        pnlSettings.TabIndex = 14
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(319, 700)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(398, 27)
        txtAddress.TabIndex = 8
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Location = New Point(319, 747)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(398, 27)
        txtContactNumber.TabIndex = 11
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.Location = New Point(318, 794)
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.Size = New Size(399, 27)
        txtEmailAddress.TabIndex = 13
        ' 
        ' btnEyeConfirmPassword
        ' 
        btnEyeConfirmPassword.BackColor = Color.Transparent
        btnEyeConfirmPassword.FlatAppearance.BorderSize = 0
        btnEyeConfirmPassword.FlatStyle = FlatStyle.Flat
        btnEyeConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        btnEyeConfirmPassword.IconColor = Color.Black
        btnEyeConfirmPassword.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEyeConfirmPassword.IconSize = 25
        btnEyeConfirmPassword.Location = New Point(715, 543)
        btnEyeConfirmPassword.Name = "btnEyeConfirmPassword"
        btnEyeConfirmPassword.Size = New Size(32, 32)
        btnEyeConfirmPassword.TabIndex = 44
        btnEyeConfirmPassword.UseVisualStyleBackColor = False
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = SystemColors.ControlText
        Label18.Location = New Point(172, 793)
        Label18.Name = "Label18"
        Label18.Size = New Size(144, 28)
        Label18.TabIndex = 12
        Label18.Text = "Email Address:"
        ' 
        ' numAge
        ' 
        numAge.Location = New Point(319, 294)
        numAge.Name = "numAge"
        numAge.Size = New Size(398, 27)
        numAge.TabIndex = 12
        ' 
        ' btnEyePassword
        ' 
        btnEyePassword.BackColor = Color.Transparent
        btnEyePassword.FlatAppearance.BorderSize = 0
        btnEyePassword.FlatStyle = FlatStyle.Flat
        btnEyePassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        btnEyePassword.IconColor = Color.Black
        btnEyePassword.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEyePassword.IconSize = 25
        btnEyePassword.Location = New Point(715, 493)
        btnEyePassword.Name = "btnEyePassword"
        btnEyePassword.Size = New Size(32, 32)
        btnEyePassword.TabIndex = 43
        btnEyePassword.UseVisualStyleBackColor = False
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.BackColor = Color.Transparent
        Label20.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.ForeColor = SystemColors.ControlText
        Label20.Location = New Point(148, 746)
        Label20.Name = "Label20"
        Label20.Size = New Size(168, 28)
        Label20.TabIndex = 4
        Label20.Text = "Contact Number:"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.BackColor = Color.Transparent
        Label19.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = SystemColors.ControlText
        Label19.Location = New Point(222, 699)
        Label19.Name = "Label19"
        Label19.Size = New Size(90, 28)
        Label19.TabIndex = 7
        Label19.Text = "Address:"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Location = New Point(312, 545)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(400, 27)
        txtConfirmPassword.TabIndex = 13
        txtConfirmPassword.UseSystemPasswordChar = True
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(238, 290)
        Label13.Name = "Label13"
        Label13.Size = New Size(53, 28)
        Label13.TabIndex = 6
        Label13.Text = "Age:"
        ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(317, 251)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(400, 27)
        txtLastName.TabIndex = 10
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(313, 496)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(399, 27)
        txtPassword.TabIndex = 11
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.Transparent
        Label15.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(126, 542)
        Label15.Name = "Label15"
        Label15.Size = New Size(181, 28)
        Label15.TabIndex = 12
        Label15.Text = "Confirm Password:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(313, 447)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(399, 27)
        txtUsername.TabIndex = 8
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Location = New Point(319, 209)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(398, 27)
        txtMiddleName.TabIndex = 11
        ' 
        ' SmallLabel1
        ' 
        SmallLabel1.AutoSize = True
        SmallLabel1.BackColor = Color.Transparent
        SmallLabel1.Font = New Font("Segoe UI", 8F)
        SmallLabel1.ForeColor = Color.FromArgb(CByte(142), CByte(142), CByte(142))
        SmallLabel1.Location = New Point(11, 1017)
        SmallLabel1.Name = "SmallLabel1"
        SmallLabel1.Size = New Size(12, 19)
        SmallLabel1.TabIndex = 20
        SmallLabel1.Text = "."
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.Transparent
        Label17.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(205, 493)
        Label17.Name = "Label17"
        Label17.Size = New Size(102, 28)
        Label17.TabIndex = 4
        Label17.Text = "Password:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(198, 446)
        Label10.Name = "Label10"
        Label10.Size = New Size(109, 28)
        Label10.TabIndex = 7
        Label10.Text = "Username:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(184, 251)
        Label12.Name = "Label12"
        Label12.Size = New Size(110, 28)
        Label12.TabIndex = 5
        Label12.Text = "Last name:"
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(204), CByte(51), CByte(102))
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.IconChar = FontAwesome.Sharp.IconChar.Cloud
        btnSave.IconColor = Color.Black
        btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSave.IconSize = 36
        btnSave.ImageAlign = ContentAlignment.MiddleLeft
        btnSave.Location = New Point(641, 913)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(115, 44)
        btnSave.TabIndex = 14
        btnSave.Text = "Save"
        btnSave.TextImageRelation = TextImageRelation.TextBeforeImage
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(184, 167)
        Label14.Name = "Label14"
        Label14.Size = New Size(112, 28)
        Label14.TabIndex = 7
        Label14.Text = "First name:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(159, 209)
        Label11.Name = "Label11"
        Label11.Size = New Size(137, 28)
        Label11.TabIndex = 4
        Label11.Text = "Middle name:"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(319, 169)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(398, 27)
        txtFirstName.TabIndex = 8
        ' 
        ' AccountingDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 700)
        Controls.Add(pnlSettings)
        Controls.Add(pnlDashboard)
        Controls.Add(pnlPatients)
        Controls.Add(pnlBilling)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1020)
        MinimumSize = New Size(190, 40)
        Name = "AccountingDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AccountingDashboard"
        Panel1.ResumeLayout(False)
        pnlDashboard.ResumeLayout(False)
        pnlDashboard.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        pnlPatients.ResumeLayout(False)
        pnlPatients.PerformLayout()
        pnlPatientsDataGrid.ResumeLayout(False)
        CType(dgvPatients, ComponentModel.ISupportInitialize).EndInit()
        pnlBilling.ResumeLayout(False)
        pnlBilling.PerformLayout()
        Panel4.ResumeLayout(False)
        CType(dgvBilling, ComponentModel.ISupportInitialize).EndInit()
        pnlSettings.ResumeLayout(False)
        pnlSettings.PerformLayout()
        CType(numAge, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLogout As FontAwesome.Sharp.IconButton
    Friend WithEvents btnBilling As FontAwesome.Sharp.IconButton
    Friend WithEvents btnPatients As FontAwesome.Sharp.IconButton
    Friend WithEvents btnDashboard As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents lblWelcomeMessage As Label
    Friend WithEvents lblTotalRevenue As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlPatients As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearchPatient As TextBox
    Friend WithEvents pnlPatientsDataGrid As Panel
    Friend WithEvents dgvPatients As DataGridView
    Friend WithEvents pnlBilling As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dgvBilling As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSettings As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents SmallLabel1 As ReaLTaiizor.Controls.SmallLabel
    Friend WithEvents btnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents btnEyeConfirmPassword As FontAwesome.Sharp.IconButton
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents btnEyePassword As FontAwesome.Sharp.IconButton
    Friend WithEvents Label15 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents numAge As NumericUpDown
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents flowRecentPayments As FlowLayoutPanel
    Friend WithEvents lblTotalPaymentToday As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
End Class
