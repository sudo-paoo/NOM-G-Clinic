<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminDashboard))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        btnSettings = New FontAwesome.Sharp.IconButton()
        btnLogout = New FontAwesome.Sharp.IconButton()
        btnBilling = New FontAwesome.Sharp.IconButton()
        btnAppointments = New FontAwesome.Sharp.IconButton()
        btnDoctors = New FontAwesome.Sharp.IconButton()
        btnPatients = New FontAwesome.Sharp.IconButton()
        btnDashboard = New FontAwesome.Sharp.IconButton()
        Label1 = New Label()
        pnlDashboard = New Panel()
        tabDashboard = New TabControl()
        TabPage1 = New TabPage()
        flowRecentAppointments = New FlowLayoutPanel()
        TabPage2 = New TabPage()
        flowRecentPayments = New FlowLayoutPanel()
        HopeGroupBox3 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblActiveDoctors = New Label()
        Label4 = New Label()
        HopeGroupBox2 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblTodaysAppointments = New Label()
        Label3 = New Label()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblTotalPatients = New Label()
        Label2 = New Label()
        pnlPatients = New Panel()
        pnlPatientsDataGrid = New Panel()
        dgvPatients = New DataGridView()
        txtSearchPatient = New TextBox()
        btnAddPatient = New FontAwesome.Sharp.IconButton()
        Label5 = New Label()
        pnlDoctors = New Panel()
        pnlDoctorsDataGrid = New Panel()
        dgvDoctors = New DataGridView()
        btnAddDoctor = New FontAwesome.Sharp.IconButton()
        txtSearchDoctor = New TextBox()
        Label6 = New Label()
        pnlAppointments = New Panel()
        Panel3 = New Panel()
        dgvAppointments = New DataGridView()
        Appointments = New Label()
        pnlBilling = New Panel()
        Panel4 = New Panel()
        dgvBilling = New DataGridView()
        Label7 = New Label()
        pnlSettings = New Panel()
        Panel5 = New Panel()
        Panel2 = New Panel()
        SmallLabel1 = New ReaLTaiizor.Controls.SmallLabel()
        btnSave = New FontAwesome.Sharp.IconButton()
        Label16 = New Label()
        HopeGroupBox6 = New ReaLTaiizor.Controls.HopeGroupBox()
        TextBox7 = New TextBox()
        Label18 = New Label()
        TextBox8 = New TextBox()
        Label19 = New Label()
        Label20 = New Label()
        TextBox9 = New TextBox()
        Label8 = New Label()
        HopeGroupBox4 = New ReaLTaiizor.Controls.HopeGroupBox()
        btnEyePassword = New FontAwesome.Sharp.IconButton()
        TextBox2 = New TextBox()
        TextBox4 = New TextBox()
        TextBox3 = New TextBox()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        TextBox1 = New TextBox()
        Label21 = New Label()
        IconButton1 = New FontAwesome.Sharp.IconButton()
        Panel1.SuspendLayout()
        pnlDashboard.SuspendLayout()
        tabDashboard.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        HopeGroupBox3.SuspendLayout()
        HopeGroupBox2.SuspendLayout()
        HopeGroupBox1.SuspendLayout()
        pnlPatients.SuspendLayout()
        pnlPatientsDataGrid.SuspendLayout()
        CType(dgvPatients, ComponentModel.ISupportInitialize).BeginInit()
        pnlDoctors.SuspendLayout()
        pnlDoctorsDataGrid.SuspendLayout()
        CType(dgvDoctors, ComponentModel.ISupportInitialize).BeginInit()
        pnlAppointments.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvAppointments, ComponentModel.ISupportInitialize).BeginInit()
        pnlBilling.SuspendLayout()
        Panel4.SuspendLayout()
        CType(dgvBilling, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        Panel2.SuspendLayout()
        HopeGroupBox6.SuspendLayout()
        HopeGroupBox4.SuspendLayout()
        SuspendLayout()
        ' 
        ' HopeForm1
        ' 
        HopeForm1.ControlBoxColorH = Color.FromArgb(CByte(228), CByte(231), CByte(237))
        HopeForm1.ControlBoxColorHC = Color.FromArgb(CByte(245), CByte(108), CByte(108))
        HopeForm1.ControlBoxColorN = Color.White
        HopeForm1.Dock = DockStyle.Top
        HopeForm1.Font = New Font("Segoe UI", 12.0F)
        HopeForm1.ForeColor = Color.FromArgb(CByte(242), CByte(246), CByte(252))
        HopeForm1.Image = CType(resources.GetObject("HopeForm1.Image"), Image)
        HopeForm1.Location = New Point(0, 0)
        HopeForm1.MaximizeBox = False
        HopeForm1.Name = "HopeForm1"
        HopeForm1.Size = New Size(1200, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "Admin"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(227), CByte(190), CByte(210))
        Panel1.Controls.Add(btnSettings)
        Panel1.Controls.Add(btnLogout)
        Panel1.Controls.Add(btnBilling)
        Panel1.Controls.Add(btnAppointments)
        Panel1.Controls.Add(btnDoctors)
        Panel1.Controls.Add(btnPatients)
        Panel1.Controls.Add(btnDashboard)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 660)
        Panel1.TabIndex = 1
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
        btnSettings.Location = New Point(0, 300)
        btnSettings.Margin = New Padding(5)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(300, 60)
        btnSettings.TabIndex = 6
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
        btnBilling.Location = New Point(0, 240)
        btnBilling.Margin = New Padding(5)
        btnBilling.Name = "btnBilling"
        btnBilling.Size = New Size(300, 60)
        btnBilling.TabIndex = 4
        btnBilling.Text = "Billing"
        btnBilling.TextAlign = ContentAlignment.MiddleLeft
        btnBilling.TextImageRelation = TextImageRelation.ImageBeforeText
        btnBilling.UseVisualStyleBackColor = False
        ' 
        ' btnAppointments
        ' 
        btnAppointments.BackColor = Color.Transparent
        btnAppointments.Dock = DockStyle.Top
        btnAppointments.FlatAppearance.BorderSize = 0
        btnAppointments.FlatStyle = FlatStyle.Flat
        btnAppointments.Font = New Font("Verdana", 10.2F)
        btnAppointments.IconChar = FontAwesome.Sharp.IconChar.CalendarDays
        btnAppointments.IconColor = Color.Black
        btnAppointments.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnAppointments.IconSize = 36
        btnAppointments.ImageAlign = ContentAlignment.MiddleLeft
        btnAppointments.Location = New Point(0, 180)
        btnAppointments.Margin = New Padding(5)
        btnAppointments.Name = "btnAppointments"
        btnAppointments.Size = New Size(300, 60)
        btnAppointments.TabIndex = 3
        btnAppointments.Text = "Appointments"
        btnAppointments.TextAlign = ContentAlignment.MiddleLeft
        btnAppointments.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAppointments.UseVisualStyleBackColor = False
        ' 
        ' btnDoctors
        ' 
        btnDoctors.BackColor = Color.Transparent
        btnDoctors.Dock = DockStyle.Top
        btnDoctors.FlatAppearance.BorderSize = 0
        btnDoctors.FlatStyle = FlatStyle.Flat
        btnDoctors.Font = New Font("Verdana", 10.2F)
        btnDoctors.IconChar = FontAwesome.Sharp.IconChar.Stethoscope
        btnDoctors.IconColor = Color.Black
        btnDoctors.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnDoctors.IconSize = 36
        btnDoctors.ImageAlign = ContentAlignment.MiddleLeft
        btnDoctors.Location = New Point(0, 120)
        btnDoctors.Margin = New Padding(5)
        btnDoctors.Name = "btnDoctors"
        btnDoctors.Size = New Size(300, 60)
        btnDoctors.TabIndex = 2
        btnDoctors.Text = "Doctors"
        btnDoctors.TextAlign = ContentAlignment.MiddleLeft
        btnDoctors.TextImageRelation = TextImageRelation.ImageBeforeText
        btnDoctors.UseVisualStyleBackColor = False
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(24, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(186, 34)
        Label1.TabIndex = 2
        Label1.Text = "Dashboard"
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlDashboard.Controls.Add(tabDashboard)
        pnlDashboard.Controls.Add(HopeGroupBox3)
        pnlDashboard.Controls.Add(HopeGroupBox2)
        pnlDashboard.Controls.Add(HopeGroupBox1)
        pnlDashboard.Controls.Add(Label1)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(300, 40)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(900, 660)
        pnlDashboard.TabIndex = 2
        ' 
        ' tabDashboard
        ' 
        tabDashboard.Controls.Add(TabPage1)
        tabDashboard.Controls.Add(TabPage2)
        tabDashboard.Font = New Font("Verdana", 10.8F)
        tabDashboard.Location = New Point(24, 216)
        tabDashboard.Name = "tabDashboard"
        tabDashboard.SelectedIndex = 0
        tabDashboard.Size = New Size(852, 432)
        tabDashboard.SizeMode = TabSizeMode.Fixed
        tabDashboard.TabIndex = 5
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(flowRecentAppointments)
        TabPage1.Location = New Point(4, 31)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(844, 397)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Recent Appointments"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' flowRecentAppointments
        ' 
        flowRecentAppointments.AutoScroll = True
        flowRecentAppointments.Dock = DockStyle.Fill
        flowRecentAppointments.FlowDirection = FlowDirection.TopDown
        flowRecentAppointments.Location = New Point(3, 3)
        flowRecentAppointments.Name = "flowRecentAppointments"
        flowRecentAppointments.Size = New Size(838, 391)
        flowRecentAppointments.TabIndex = 0
        flowRecentAppointments.WrapContents = False
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(flowRecentPayments)
        TabPage2.Location = New Point(4, 31)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(844, 397)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Recent Payments"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' flowRecentPayments
        ' 
        flowRecentPayments.Dock = DockStyle.Fill
        flowRecentPayments.Location = New Point(3, 3)
        flowRecentPayments.Name = "flowRecentPayments"
        flowRecentPayments.Size = New Size(838, 391)
        flowRecentPayments.TabIndex = 0
        ' 
        ' HopeGroupBox3
        ' 
        HopeGroupBox3.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox3.Controls.Add(lblActiveDoctors)
        HopeGroupBox3.Controls.Add(Label4)
        HopeGroupBox3.Font = New Font("Segoe UI", 12.0F)
        HopeGroupBox3.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox3.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox3.Location = New Point(596, 60)
        HopeGroupBox3.Name = "HopeGroupBox3"
        HopeGroupBox3.ShowText = False
        HopeGroupBox3.Size = New Size(280, 150)
        HopeGroupBox3.TabIndex = 4
        HopeGroupBox3.TabStop = False
        HopeGroupBox3.Text = "HopeGroupBox3"
        HopeGroupBox3.ThemeColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        ' 
        ' lblActiveDoctors
        ' 
        lblActiveDoctors.AutoSize = True
        lblActiveDoctors.BackColor = Color.Transparent
        lblActiveDoctors.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActiveDoctors.Location = New Point(20, 74)
        lblActiveDoctors.Name = "lblActiveDoctors"
        lblActiveDoctors.Size = New Size(190, 28)
        lblActiveDoctors.TabIndex = 6
        lblActiveDoctors.Text = "Total Patients"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(20, 30)
        Label4.Name = "Label4"
        Label4.Size = New Size(157, 22)
        Label4.TabIndex = 5
        Label4.Text = "Active Doctors"
        ' 
        ' HopeGroupBox2
        ' 
        HopeGroupBox2.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox2.Controls.Add(lblTodaysAppointments)
        HopeGroupBox2.Controls.Add(Label3)
        HopeGroupBox2.Font = New Font("Segoe UI", 12.0F)
        HopeGroupBox2.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox2.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox2.Location = New Point(310, 60)
        HopeGroupBox2.Name = "HopeGroupBox2"
        HopeGroupBox2.ShowText = False
        HopeGroupBox2.Size = New Size(280, 150)
        HopeGroupBox2.TabIndex = 4
        HopeGroupBox2.TabStop = False
        HopeGroupBox2.Text = "HopeGroupBox2"
        HopeGroupBox2.ThemeColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        ' 
        ' lblTodaysAppointments
        ' 
        lblTodaysAppointments.AutoSize = True
        lblTodaysAppointments.BackColor = Color.Transparent
        lblTodaysAppointments.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTodaysAppointments.Location = New Point(20, 74)
        lblTodaysAppointments.Name = "lblTodaysAppointments"
        lblTodaysAppointments.Size = New Size(190, 28)
        lblTodaysAppointments.TabIndex = 5
        lblTodaysAppointments.Text = "Total Patients"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(20, 30)
        Label3.Name = "Label3"
        Label3.Size = New Size(236, 22)
        Label3.TabIndex = 4
        Label3.Text = "Today's Appointments"
        ' 
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Controls.Add(lblTotalPatients)
        HopeGroupBox1.Controls.Add(Label2)
        HopeGroupBox1.Font = New Font("Segoe UI", 12.0F)
        HopeGroupBox1.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox1.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Location = New Point(24, 60)
        HopeGroupBox1.Name = "HopeGroupBox1"
        HopeGroupBox1.ShowText = False
        HopeGroupBox1.Size = New Size(280, 150)
        HopeGroupBox1.TabIndex = 3
        HopeGroupBox1.TabStop = False
        HopeGroupBox1.Text = "HopeGroupBox1"
        HopeGroupBox1.ThemeColor = Color.FromArgb(CByte(59), CByte(130), CByte(246))
        ' 
        ' lblTotalPatients
        ' 
        lblTotalPatients.AutoSize = True
        lblTotalPatients.BackColor = Color.Transparent
        lblTotalPatients.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalPatients.Location = New Point(20, 74)
        lblTotalPatients.Name = "lblTotalPatients"
        lblTotalPatients.Size = New Size(190, 28)
        lblTotalPatients.TabIndex = 4
        lblTotalPatients.Text = "Total Patients"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(20, 30)
        Label2.Name = "Label2"
        Label2.Size = New Size(149, 22)
        Label2.TabIndex = 3
        Label2.Text = "Total Patients"
        ' 
        ' pnlPatients
        ' 
        pnlPatients.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlPatients.Controls.Add(pnlPatientsDataGrid)
        pnlPatients.Controls.Add(txtSearchPatient)
        pnlPatients.Controls.Add(btnAddPatient)
        pnlPatients.Controls.Add(Label5)
        pnlPatients.Dock = DockStyle.Fill
        pnlPatients.Location = New Point(300, 40)
        pnlPatients.Name = "pnlPatients"
        pnlPatients.Size = New Size(900, 660)
        pnlPatients.TabIndex = 6
        ' 
        ' pnlPatientsDataGrid
        ' 
        pnlPatientsDataGrid.Controls.Add(dgvPatients)
        pnlPatientsDataGrid.Location = New Point(24, 134)
        pnlPatientsDataGrid.Name = "pnlPatientsDataGrid"
        pnlPatientsDataGrid.Size = New Size(852, 514)
        pnlPatientsDataGrid.TabIndex = 5
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
        ' txtSearchPatient
        ' 
        txtSearchPatient.Font = New Font("Verdana", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchPatient.Location = New Point(24, 90)
        txtSearchPatient.Name = "txtSearchPatient"
        txtSearchPatient.PlaceholderText = "Search patient..."
        txtSearchPatient.Size = New Size(250, 32)
        txtSearchPatient.TabIndex = 3
        ' 
        ' btnAddPatient
        ' 
        btnAddPatient.Font = New Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddPatient.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        btnAddPatient.IconColor = Color.Black
        btnAddPatient.IconFont = FontAwesome.Sharp.IconFont.Regular
        btnAddPatient.IconSize = 34
        btnAddPatient.Location = New Point(681, 22)
        btnAddPatient.Name = "btnAddPatient"
        btnAddPatient.Size = New Size(195, 60)
        btnAddPatient.TabIndex = 2
        btnAddPatient.Text = "Add Patient"
        btnAddPatient.TextAlign = ContentAlignment.MiddleRight
        btnAddPatient.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAddPatient.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(24, 32)
        Label5.Name = "Label5"
        Label5.Size = New Size(147, 34)
        Label5.TabIndex = 1
        Label5.Text = "Patients"
        ' 
        ' pnlDoctors
        ' 
        pnlDoctors.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlDoctors.Controls.Add(pnlDoctorsDataGrid)
        pnlDoctors.Controls.Add(txtSearchDoctor)
        pnlDoctors.Controls.Add(Label6)
        pnlDoctors.Dock = DockStyle.Fill
        pnlDoctors.Location = New Point(300, 40)
        pnlDoctors.Name = "pnlDoctors"
        pnlDoctors.Size = New Size(900, 660)
        pnlDoctors.TabIndex = 7
        ' 
        ' pnlDoctorsDataGrid
        ' 
        pnlDoctorsDataGrid.Controls.Add(dgvDoctors)
        pnlDoctorsDataGrid.Controls.Add(btnAddDoctor)
        pnlDoctorsDataGrid.Location = New Point(24, 134)
        pnlDoctorsDataGrid.Name = "pnlDoctorsDataGrid"
        pnlDoctorsDataGrid.Size = New Size(852, 514)
        pnlDoctorsDataGrid.TabIndex = 5
        ' 
        ' dgvDoctors
        ' 
        dgvDoctors.ColumnHeadersHeight = 29
        dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvDoctors.Dock = DockStyle.Fill
        dgvDoctors.Location = New Point(0, 0)
        dgvDoctors.Name = "dgvDoctors"
        dgvDoctors.RowHeadersWidth = 51
        dgvDoctors.Size = New Size(852, 514)
        dgvDoctors.TabIndex = 4
        ' 
        ' btnAddDoctor
        ' 
        btnAddDoctor.Font = New Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddDoctor.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        btnAddDoctor.IconColor = Color.Black
        btnAddDoctor.IconFont = FontAwesome.Sharp.IconFont.Regular
        btnAddDoctor.IconSize = 34
        btnAddDoctor.Location = New Point(0, 0)
        btnAddDoctor.Name = "btnAddDoctor"
        btnAddDoctor.Size = New Size(195, 60)
        btnAddDoctor.TabIndex = 2
        btnAddDoctor.Text = "Add Doctor"
        btnAddDoctor.TextAlign = ContentAlignment.MiddleRight
        btnAddDoctor.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAddDoctor.UseVisualStyleBackColor = True
        ' 
        ' txtSearchDoctor
        ' 
        txtSearchDoctor.Font = New Font("Verdana", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchDoctor.Location = New Point(24, 90)
        txtSearchDoctor.Name = "txtSearchDoctor"
        txtSearchDoctor.PlaceholderText = "Search doctor..."
        txtSearchDoctor.Size = New Size(250, 32)
        txtSearchDoctor.TabIndex = 3
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(24, 32)
        Label6.Name = "Label6"
        Label6.Size = New Size(136, 34)
        Label6.TabIndex = 1
        Label6.Text = "Doctors"
        ' 
        ' pnlAppointments
        ' 
        pnlAppointments.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlAppointments.Controls.Add(Panel3)
        pnlAppointments.Controls.Add(Appointments)
        pnlAppointments.Dock = DockStyle.Fill
        pnlAppointments.Location = New Point(300, 40)
        pnlAppointments.Name = "pnlAppointments"
        pnlAppointments.Size = New Size(900, 660)
        pnlAppointments.TabIndex = 8
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(dgvAppointments)
        Panel3.Location = New Point(24, 93)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(852, 555)
        Panel3.TabIndex = 5
        ' 
        ' dgvAppointments
        ' 
        dgvAppointments.AllowUserToResizeColumns = False
        dgvAppointments.ColumnHeadersHeight = 29
        dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvAppointments.Dock = DockStyle.Fill
        dgvAppointments.Location = New Point(0, 0)
        dgvAppointments.Name = "dgvAppointments"
        dgvAppointments.RowHeadersWidth = 51
        dgvAppointments.Size = New Size(852, 555)
        dgvAppointments.TabIndex = 4
        ' 
        ' Appointments
        ' 
        Appointments.AutoSize = True
        Appointments.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Appointments.Location = New Point(24, 32)
        Appointments.Name = "Appointments"
        Appointments.Size = New Size(238, 34)
        Appointments.TabIndex = 1
        Appointments.Text = "Appointments"
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
        pnlBilling.TabIndex = 9
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
        pnlSettings.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlSettings.Dock = DockStyle.Fill
        pnlSettings.Location = New Point(300, 40)
        pnlSettings.Name = "pnlSettings"
        pnlSettings.Size = New Size(900, 660)
        pnlSettings.TabIndex = 10
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        Panel5.Controls.Add(Panel2)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(300, 40)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(900, 660)
        Panel5.TabIndex = 11
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        Panel2.Controls.Add(IconButton1)
        Panel2.Controls.Add(SmallLabel1)
        Panel2.Controls.Add(btnSave)
        Panel2.Controls.Add(Label16)
        Panel2.Controls.Add(HopeGroupBox6)
        Panel2.Controls.Add(Label8)
        Panel2.Controls.Add(HopeGroupBox4)
        Panel2.Controls.Add(Label21)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(900, 660)
        Panel2.TabIndex = 12
        ' 
        ' SmallLabel1
        ' 
        SmallLabel1.AutoSize = True
        SmallLabel1.BackColor = Color.Transparent
        SmallLabel1.Font = New Font("Segoe UI", 8.0F)
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
        btnSave.ImageAlign = ContentAlignment.MiddleLeft
        btnSave.Location = New Point(664, 950)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(118, 44)
        btnSave.TabIndex = 14
        btnSave.Text = "        SAVE"
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
        HopeGroupBox6.Controls.Add(TextBox7)
        HopeGroupBox6.Controls.Add(Label18)
        HopeGroupBox6.Controls.Add(TextBox8)
        HopeGroupBox6.Controls.Add(Label19)
        HopeGroupBox6.Controls.Add(Label20)
        HopeGroupBox6.Controls.Add(TextBox9)
        HopeGroupBox6.Font = New Font("Segoe UI", 12.0F)
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
        ' TextBox7
        ' 
        TextBox7.Location = New Point(290, 139)
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(300, 34)
        TextBox7.TabIndex = 13
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label18.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(24, 138)
        Label18.Name = "Label18"
        Label18.Size = New Size(144, 28)
        Label18.TabIndex = 12
        Label18.Text = "Email Address:"
        ' 
        ' TextBox8
        ' 
        TextBox8.Location = New Point(290, 84)
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(300, 34)
        TextBox8.TabIndex = 11
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label19.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
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
        Label20.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.Location = New Point(24, 83)
        Label20.Name = "Label20"
        Label20.Size = New Size(168, 28)
        Label20.TabIndex = 4
        Label20.Text = "Contact Number:"
        ' 
        ' TextBox9
        ' 
        TextBox9.Location = New Point(290, 31)
        TextBox9.Name = "TextBox9"
        TextBox9.Size = New Size(300, 34)
        TextBox9.TabIndex = 8
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(354, 100)
        Label8.Name = "Label8"
        Label8.Size = New Size(225, 31)
        Label8.TabIndex = 15
        Label8.Text = "Personal Information"
        ' 
        ' HopeGroupBox4
        ' 
        HopeGroupBox4.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Controls.Add(btnEyePassword)
        HopeGroupBox4.Controls.Add(TextBox2)
        HopeGroupBox4.Controls.Add(TextBox4)
        HopeGroupBox4.Controls.Add(TextBox3)
        HopeGroupBox4.Controls.Add(Label14)
        HopeGroupBox4.Controls.Add(Label13)
        HopeGroupBox4.Controls.Add(Label12)
        HopeGroupBox4.Controls.Add(Label11)
        HopeGroupBox4.Controls.Add(TextBox1)
        HopeGroupBox4.Font = New Font("Segoe UI", 12.0F)
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
        ' btnEyePassword
        ' 
        btnEyePassword.BackColor = Color.Transparent
        btnEyePassword.FlatAppearance.BorderSize = 0
        btnEyePassword.FlatStyle = FlatStyle.Flat
        btnEyePassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        btnEyePassword.IconColor = Color.Black
        btnEyePassword.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEyePassword.IconSize = 25
        btnEyePassword.Location = New Point(593, 84)
        btnEyePassword.Name = "btnEyePassword"
        btnEyePassword.Size = New Size(32, 32)
        btnEyePassword.TabIndex = 44
        btnEyePassword.UseVisualStyleBackColor = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(290, 189)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(300, 34)
        TextBox2.TabIndex = 12
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(290, 84)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(300, 34)
        TextBox4.TabIndex = 11
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(290, 137)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(300, 34)
        TextBox3.TabIndex = 10
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label14.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(24, 30)
        Label14.Name = "Label14"
        Label14.Size = New Size(109, 28)
        Label14.TabIndex = 7
        Label14.Text = "Username:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label13.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(24, 189)
        Label13.Name = "Label13"
        Label13.Size = New Size(168, 28)
        Label13.TabIndex = 6
        Label13.Text = "Contact Number:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label12.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(23, 136)
        Label12.Name = "Label12"
        Label12.Size = New Size(65, 28)
        Label12.TabIndex = 5
        Label12.Text = "Email:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label11.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(24, 83)
        Label11.Name = "Label11"
        Label11.Size = New Size(102, 28)
        Label11.TabIndex = 4
        Label11.Text = "Password:"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(290, 31)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(300, 34)
        TextBox1.TabIndex = 8
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label21.Location = New Point(24, 22)
        Label21.Name = "Label21"
        Label21.Size = New Size(147, 34)
        Label21.TabIndex = 1
        Label21.Text = "Settings"
        ' 
        ' IconButton1
        ' 
        IconButton1.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        IconButton1.IconChar = FontAwesome.Sharp.IconChar.Cloud
        IconButton1.IconColor = Color.RosyBrown
        IconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton1.ImageAlign = ContentAlignment.MiddleLeft
        IconButton1.Location = New Point(402, 415)
        IconButton1.Name = "IconButton1"
        IconButton1.Size = New Size(118, 44)
        IconButton1.TabIndex = 21
        IconButton1.Text = "        SAVE"
        IconButton1.UseVisualStyleBackColor = True
        ' 
        ' AdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 700)
        Controls.Add(Panel5)
        Controls.Add(pnlPatients)
        Controls.Add(pnlSettings)
        Controls.Add(pnlBilling)
        Controls.Add(pnlAppointments)
        Controls.Add(pnlDoctors)
        Controls.Add(pnlDashboard)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1020)
        MinimumSize = New Size(190, 40)
        Name = "AdminDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AdminDashboard"
        Panel1.ResumeLayout(False)
        pnlDashboard.ResumeLayout(False)
        pnlDashboard.PerformLayout()
        tabDashboard.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        HopeGroupBox3.ResumeLayout(False)
        HopeGroupBox3.PerformLayout()
        HopeGroupBox2.ResumeLayout(False)
        HopeGroupBox2.PerformLayout()
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        pnlPatients.ResumeLayout(False)
        pnlPatients.PerformLayout()
        pnlPatientsDataGrid.ResumeLayout(False)
        CType(dgvPatients, ComponentModel.ISupportInitialize).EndInit()
        pnlDoctors.ResumeLayout(False)
        pnlDoctors.PerformLayout()
        pnlDoctorsDataGrid.ResumeLayout(False)
        CType(dgvDoctors, ComponentModel.ISupportInitialize).EndInit()
        pnlAppointments.ResumeLayout(False)
        pnlAppointments.PerformLayout()
        Panel3.ResumeLayout(False)
        CType(dgvAppointments, ComponentModel.ISupportInitialize).EndInit()
        pnlBilling.ResumeLayout(False)
        pnlBilling.PerformLayout()
        Panel4.ResumeLayout(False)
        CType(dgvBilling, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        HopeGroupBox6.ResumeLayout(False)
        HopeGroupBox6.PerformLayout()
        HopeGroupBox4.ResumeLayout(False)
        HopeGroupBox4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDashboard As FontAwesome.Sharp.IconButton
    Friend WithEvents btnBilling As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAppointments As FontAwesome.Sharp.IconButton
    Friend WithEvents btnDoctors As FontAwesome.Sharp.IconButton
    Friend WithEvents btnPatients As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents HopeGroupBox3 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents HopeGroupBox2 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents HopeGroupBox1 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotalPatients As Label
    Friend WithEvents tabDashboard As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lblActiveDoctors As Label
    Friend WithEvents lblTodaysAppointments As Label
    Friend WithEvents flowRecentAppointments As FlowLayoutPanel
    Friend WithEvents flowRecentPayments As FlowLayoutPanel
    Friend WithEvents pnlPatients As Panel
    Friend WithEvents txtSearchPatient As TextBox
    Friend WithEvents btnAddPatient As FontAwesome.Sharp.IconButton
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvPatients As DataGridView
    Friend WithEvents pnlPatientsDataGrid As Panel
    Friend WithEvents pnlDoctors As Panel
    Friend WithEvents pnlDoctorsDataGrid As Panel
    Friend WithEvents dgvDoctors As DataGridView
    Friend WithEvents txtSearchDoctor As TextBox
    Friend WithEvents btnAddDoctor As FontAwesome.Sharp.IconButton
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlAppointments As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgvAppointments As DataGridView
    Friend WithEvents Appointments As Label
    Friend WithEvents pnlBilling As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dgvBilling As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents btnLogout As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSettings As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SmallLabel1 As ReaLTaiizor.Controls.SmallLabel
    Friend WithEvents btnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents Label16 As Label
    Friend WithEvents HopeGroupBox6 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents HopeGroupBox4 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents btnEyePassword As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
End Class
