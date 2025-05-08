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
        tabDashboard = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        TabPage3 = New TabPage()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblTotalPayment = New Label()
        Label2 = New Label()
        HopeGroupBox3 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblTotalRevenue = New Label()
        Label4 = New Label()
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
        Panel2 = New Panel()
        SmallLabel1 = New ReaLTaiizor.Controls.SmallLabel()
        btnSave = New FontAwesome.Sharp.IconButton()
        Label16 = New Label()
        HopeGroupBox6 = New ReaLTaiizor.Controls.HopeGroupBox()
        txtEmailAddress = New TextBox()
        Label18 = New Label()
        txtContactNumber = New TextBox()
        Label19 = New Label()
        Label20 = New Label()
        txtAddress = New TextBox()
        Label9 = New Label()
        HopeGroupBox5 = New ReaLTaiizor.Controls.HopeGroupBox()
        btnEyeConfirmPassword = New FontAwesome.Sharp.IconButton()
        txtConfirmPassword = New TextBox()
        btnEyePassword = New FontAwesome.Sharp.IconButton()
        Label15 = New Label()
        txtPassword = New TextBox()
        Label10 = New Label()
        Label17 = New Label()
        txtUsername = New TextBox()
        Label1 = New Label()
        HopeGroupBox4 = New ReaLTaiizor.Controls.HopeGroupBox()
        numAge = New NumericUpDown()
        txtMiddleName = New TextBox()
        txtLastName = New TextBox()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        txtFirstName = New TextBox()
        Label6 = New Label()
        Panel1.SuspendLayout()
        pnlDashboard.SuspendLayout()
        tabDashboard.SuspendLayout()
        HopeGroupBox1.SuspendLayout()
        HopeGroupBox3.SuspendLayout()
        pnlPatients.SuspendLayout()
        pnlPatientsDataGrid.SuspendLayout()
        CType(dgvPatients, ComponentModel.ISupportInitialize).BeginInit()
        pnlBilling.SuspendLayout()
        Panel4.SuspendLayout()
        CType(dgvBilling, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        HopeGroupBox6.SuspendLayout()
        HopeGroupBox5.SuspendLayout()
        HopeGroupBox4.SuspendLayout()
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
        btnSettings.Text = "Setting"
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
        pnlDashboard.Controls.Add(tabDashboard)
        pnlDashboard.Controls.Add(HopeGroupBox1)
        pnlDashboard.Controls.Add(HopeGroupBox3)
        pnlDashboard.Controls.Add(lblWelcomeMessage)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(300, 40)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(900, 660)
        pnlDashboard.TabIndex = 3
        ' 
        ' tabDashboard
        ' 
        tabDashboard.Controls.Add(TabPage1)
        tabDashboard.Controls.Add(TabPage2)
        tabDashboard.Controls.Add(TabPage3)
        tabDashboard.Location = New Point(22, 215)
        tabDashboard.Name = "tabDashboard"
        tabDashboard.SelectedIndex = 0
        tabDashboard.Size = New Size(852, 430)
        tabDashboard.SizeMode = TabSizeMode.Fixed
        tabDashboard.TabIndex = 12
        ' 
        ' TabPage1
        ' 
        TabPage1.Location = New Point(4, 29)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(844, 397)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Recent Invoices"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 29)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(844, 397)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Recent Payments"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Location = New Point(4, 29)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(844, 397)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Recent Expenses"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BackColor = SystemColors.Control
        HopeGroupBox1.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Controls.Add(lblTotalPayment)
        HopeGroupBox1.Controls.Add(Label2)
        HopeGroupBox1.Font = New Font("Segoe UI", 12F)
        HopeGroupBox1.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox1.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Location = New Point(459, 59)
        HopeGroupBox1.Name = "HopeGroupBox1"
        HopeGroupBox1.ShowText = False
        HopeGroupBox1.Size = New Size(414, 150)
        HopeGroupBox1.TabIndex = 10
        HopeGroupBox1.TabStop = False
        HopeGroupBox1.Text = "HopeGroupBox1"
        HopeGroupBox1.ThemeColor = SystemColors.ControlLightLight
        ' 
        ' lblTotalPayment
        ' 
        lblTotalPayment.AutoSize = True
        lblTotalPayment.BackColor = Color.Transparent
        lblTotalPayment.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalPayment.Location = New Point(20, 74)
        lblTotalPayment.Name = "lblTotalPayment"
        lblTotalPayment.Size = New Size(243, 28)
        lblTotalPayment.TabIndex = 6
        lblTotalPayment.Text = "Total within a day"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(20, 30)
        Label2.Name = "Label2"
        Label2.Size = New Size(208, 22)
        Label2.TabIndex = 5
        Label2.Text = "Payments Received"
        ' 
        ' HopeGroupBox3
        ' 
        HopeGroupBox3.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox3.Controls.Add(lblTotalRevenue)
        HopeGroupBox3.Controls.Add(Label4)
        HopeGroupBox3.Font = New Font("Segoe UI", 12F)
        HopeGroupBox3.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox3.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox3.Location = New Point(21, 59)
        HopeGroupBox3.Name = "HopeGroupBox3"
        HopeGroupBox3.ShowText = False
        HopeGroupBox3.Size = New Size(414, 150)
        HopeGroupBox3.TabIndex = 9
        HopeGroupBox3.TabStop = False
        HopeGroupBox3.Text = "HopeGroupBox3"
        HopeGroupBox3.ThemeColor = SystemColors.ControlLightLight
        ' 
        ' lblTotalRevenue
        ' 
        lblTotalRevenue.AutoSize = True
        lblTotalRevenue.BackColor = Color.Transparent
        lblTotalRevenue.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalRevenue.Location = New Point(20, 74)
        lblTotalRevenue.Name = "lblTotalRevenue"
        lblTotalRevenue.Size = New Size(185, 28)
        lblTotalRevenue.TabIndex = 6
        lblTotalRevenue.Text = "Total Amount"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(20, 30)
        Label4.Name = "Label4"
        Label4.Size = New Size(154, 22)
        Label4.TabIndex = 5
        Label4.Text = "Total Revenue"
        ' 
        ' lblWelcomeMessage
        ' 
        lblWelcomeMessage.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        lblWelcomeMessage.Font = New Font("Verdana", 16.2F, FontStyle.Bold)
        lblWelcomeMessage.Location = New Point(23, 10)
        lblWelcomeMessage.Name = "lblWelcomeMessage"
        lblWelcomeMessage.Size = New Size(851, 38)
        lblWelcomeMessage.TabIndex = 0
        lblWelcomeMessage.Text = "Welcome!"
        ' 
        ' pnlPatients
        ' 
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
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.BackColor = SystemColors.ControlLightLight
        Panel2.Controls.Add(SmallLabel1)
        Panel2.Controls.Add(btnSave)
        Panel2.Controls.Add(Label16)
        Panel2.Controls.Add(HopeGroupBox6)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(HopeGroupBox5)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(HopeGroupBox4)
        Panel2.Controls.Add(Label6)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(300, 40)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(900, 660)
        Panel2.TabIndex = 14
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
        ' btnSave
        ' 
        btnSave.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.IconChar = FontAwesome.Sharp.IconChar.Cloud
        btnSave.IconColor = Color.RosyBrown
        btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSave.IconSize = 36
        btnSave.ImageAlign = ContentAlignment.MiddleLeft
        btnSave.Location = New Point(649, 950)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(133, 44)
        btnSave.TabIndex = 14
        btnSave.Text = "SAVE"
        btnSave.TextImageRelation = TextImageRelation.TextBeforeImage
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(354, 657)
        Label16.Name = "Label16"
        Label16.Size = New Size(218, 31)
        Label16.TabIndex = 19
        Label16.Text = "Contact Information"
        ' 
        ' HopeGroupBox6
        ' 
        HopeGroupBox6.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox6.Controls.Add(txtEmailAddress)
        HopeGroupBox6.Controls.Add(Label18)
        HopeGroupBox6.Controls.Add(txtContactNumber)
        HopeGroupBox6.Controls.Add(Label19)
        HopeGroupBox6.Controls.Add(Label20)
        HopeGroupBox6.Controls.Add(txtAddress)
        HopeGroupBox6.Font = New Font("Segoe UI", 12F)
        HopeGroupBox6.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox6.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox6.Location = New Point(151, 694)
        HopeGroupBox6.Name = "HopeGroupBox6"
        HopeGroupBox6.ShowText = False
        HopeGroupBox6.Size = New Size(631, 210)
        HopeGroupBox6.TabIndex = 18
        HopeGroupBox6.TabStop = False
        HopeGroupBox6.Text = "HopeGroupBox6"
        HopeGroupBox6.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.Location = New Point(290, 139)
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.Size = New Size(300, 34)
        txtEmailAddress.TabIndex = 13
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label18.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(24, 138)
        Label18.Name = "Label18"
        Label18.Size = New Size(144, 28)
        Label18.TabIndex = 12
        Label18.Text = "Email Address:"
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Location = New Point(290, 84)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(300, 34)
        txtContactNumber.TabIndex = 11
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label19.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(24, 30)
        Label19.Name = "Label19"
        Label19.Size = New Size(90, 28)
        Label19.TabIndex = 7
        Label19.Text = "Address:"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label20.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.Location = New Point(24, 83)
        Label20.Name = "Label20"
        Label20.Size = New Size(168, 28)
        Label20.TabIndex = 4
        Label20.Text = "Contact Number:"
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(290, 31)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(300, 34)
        txtAddress.TabIndex = 8
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(354, 408)
        Label9.Name = "Label9"
        Label9.Size = New Size(223, 31)
        Label9.TabIndex = 17
        Label9.Text = "Account Information"
        ' 
        ' HopeGroupBox5
        ' 
        HopeGroupBox5.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox5.Controls.Add(btnEyeConfirmPassword)
        HopeGroupBox5.Controls.Add(txtConfirmPassword)
        HopeGroupBox5.Controls.Add(btnEyePassword)
        HopeGroupBox5.Controls.Add(Label15)
        HopeGroupBox5.Controls.Add(txtPassword)
        HopeGroupBox5.Controls.Add(Label10)
        HopeGroupBox5.Controls.Add(Label17)
        HopeGroupBox5.Controls.Add(txtUsername)
        HopeGroupBox5.Font = New Font("Segoe UI", 12F)
        HopeGroupBox5.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox5.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox5.Location = New Point(151, 445)
        HopeGroupBox5.Name = "HopeGroupBox5"
        HopeGroupBox5.ShowText = False
        HopeGroupBox5.Size = New Size(631, 193)
        HopeGroupBox5.TabIndex = 16
        HopeGroupBox5.TabStop = False
        HopeGroupBox5.Text = "HopeGroupBox5"
        HopeGroupBox5.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
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
        btnEyeConfirmPassword.Location = New Point(593, 139)
        btnEyeConfirmPassword.Name = "btnEyeConfirmPassword"
        btnEyeConfirmPassword.Size = New Size(32, 32)
        btnEyeConfirmPassword.TabIndex = 44
        btnEyeConfirmPassword.UseVisualStyleBackColor = False
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Location = New Point(290, 139)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(300, 34)
        txtConfirmPassword.TabIndex = 13
        txtConfirmPassword.UseSystemPasswordChar = True
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
        btnEyePassword.Location = New Point(593, 86)
        btnEyePassword.Name = "btnEyePassword"
        btnEyePassword.Size = New Size(32, 32)
        btnEyePassword.TabIndex = 43
        btnEyePassword.UseVisualStyleBackColor = False
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label15.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(24, 138)
        Label15.Name = "Label15"
        Label15.Size = New Size(181, 28)
        Label15.TabIndex = 12
        Label15.Text = "Confirm Password:"
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(290, 84)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(300, 34)
        txtPassword.TabIndex = 11
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label10.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(24, 30)
        Label10.Name = "Label10"
        Label10.Size = New Size(109, 28)
        Label10.TabIndex = 7
        Label10.Text = "Username:"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label17.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(24, 83)
        Label17.Name = "Label17"
        Label17.Size = New Size(102, 28)
        Label17.TabIndex = 4
        Label17.Text = "Password:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(290, 31)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(300, 34)
        txtUsername.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(354, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(225, 31)
        Label1.TabIndex = 15
        Label1.Text = "Personal Information"
        ' 
        ' HopeGroupBox4
        ' 
        HopeGroupBox4.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Controls.Add(numAge)
        HopeGroupBox4.Controls.Add(txtMiddleName)
        HopeGroupBox4.Controls.Add(txtLastName)
        HopeGroupBox4.Controls.Add(Label14)
        HopeGroupBox4.Controls.Add(Label13)
        HopeGroupBox4.Controls.Add(Label12)
        HopeGroupBox4.Controls.Add(Label11)
        HopeGroupBox4.Controls.Add(txtFirstName)
        HopeGroupBox4.Font = New Font("Segoe UI", 12F)
        HopeGroupBox4.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox4.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Location = New Point(151, 137)
        HopeGroupBox4.Name = "HopeGroupBox4"
        HopeGroupBox4.ShowText = False
        HopeGroupBox4.Size = New Size(631, 250)
        HopeGroupBox4.TabIndex = 14
        HopeGroupBox4.TabStop = False
        HopeGroupBox4.Text = "HopeGroupBox4"
        HopeGroupBox4.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        ' 
        ' numAge
        ' 
        numAge.Location = New Point(290, 187)
        numAge.Name = "numAge"
        numAge.Size = New Size(304, 34)
        numAge.TabIndex = 12
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Location = New Point(290, 84)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(300, 34)
        txtMiddleName.TabIndex = 11
        ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(290, 137)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(300, 34)
        txtLastName.TabIndex = 10
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label14.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(24, 30)
        Label14.Name = "Label14"
        Label14.Size = New Size(112, 28)
        Label14.TabIndex = 7
        Label14.Text = "First name:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label13.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(24, 189)
        Label13.Name = "Label13"
        Label13.Size = New Size(53, 28)
        Label13.TabIndex = 6
        Label13.Text = "Age:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label12.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(23, 136)
        Label12.Name = "Label12"
        Label12.Size = New Size(110, 28)
        Label12.TabIndex = 5
        Label12.Text = "Last name:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label11.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(24, 83)
        Label11.Name = "Label11"
        Label11.Size = New Size(137, 28)
        Label11.TabIndex = 4
        Label11.Text = "Middle name:"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(290, 31)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(300, 34)
        txtFirstName.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(24, 22)
        Label6.Name = "Label6"
        Label6.Size = New Size(147, 34)
        Label6.TabIndex = 1
        Label6.Text = "Settings"
        ' 
        ' AccountingDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 700)
        Controls.Add(Panel2)
        Controls.Add(pnlDashboard)
        Controls.Add(pnlBilling)
        Controls.Add(pnlPatients)
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
        tabDashboard.ResumeLayout(False)
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        HopeGroupBox3.ResumeLayout(False)
        HopeGroupBox3.PerformLayout()
        pnlPatients.ResumeLayout(False)
        pnlPatients.PerformLayout()
        pnlPatientsDataGrid.ResumeLayout(False)
        CType(dgvPatients, ComponentModel.ISupportInitialize).EndInit()
        pnlBilling.ResumeLayout(False)
        pnlBilling.PerformLayout()
        Panel4.ResumeLayout(False)
        CType(dgvBilling, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        HopeGroupBox6.ResumeLayout(False)
        HopeGroupBox6.PerformLayout()
        HopeGroupBox5.ResumeLayout(False)
        HopeGroupBox5.PerformLayout()
        HopeGroupBox4.ResumeLayout(False)
        HopeGroupBox4.PerformLayout()
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
    Friend WithEvents HopeGroupBox1 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents lblTotalPayment As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents HopeGroupBox3 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents lblTotalRevenue As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tabDashboard As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
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
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SmallLabel1 As ReaLTaiizor.Controls.SmallLabel
    Friend WithEvents btnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents Label16 As Label
    Friend WithEvents HopeGroupBox6 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents HopeGroupBox5 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents btnEyeConfirmPassword As FontAwesome.Sharp.IconButton
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents btnEyePassword As FontAwesome.Sharp.IconButton
    Friend WithEvents Label15 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents HopeGroupBox4 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents numAge As NumericUpDown
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label6 As Label
End Class
