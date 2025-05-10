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
        btnAccountant = New FontAwesome.Sharp.IconButton()
        btnNurse = New FontAwesome.Sharp.IconButton()
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
        lblActiveDoctors = New Label()
        Label4 = New Label()
        lblTodaysAppointments = New Label()
        Label3 = New Label()
        pnlPatients = New Panel()
        pnlPatientsDataGrid = New Panel()
        dgvPatients = New DataGridView()
        txtSearchPatient = New TextBox()
        btnAddPatient = New FontAwesome.Sharp.IconButton()
        Label5 = New Label()
        pnlDoctors = New Panel()
        btnAddDoctor = New FontAwesome.Sharp.IconButton()
        pnlDoctorsDataGrid = New Panel()
        dgvDoctors = New DataGridView()
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
        pnlSettingsAdmin = New Panel()
        btnSaveAdminSettings = New FontAwesome.Sharp.IconButton()
        SmallLabel1 = New ReaLTaiizor.Controls.SmallLabel()
        btnEyeConfirmPassword = New FontAwesome.Sharp.IconButton()
        txtConfirmPassword = New TextBox()
        Label15 = New Label()
        btnEyePassword = New FontAwesome.Sharp.IconButton()
        txtContactNumber = New TextBox()
        txtPassword = New TextBox()
        txtEmail = New TextBox()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        txtUsername = New TextBox()
        Label21 = New Label()
        pnlNurses = New Panel()
        Panel5 = New Panel()
        dgvNurses = New DataGridView()
        txtSearchNurses = New TextBox()
        btnAddNurse = New FontAwesome.Sharp.IconButton()
        Label9 = New Label()
        pnlAccountants = New Panel()
        Panel6 = New Panel()
        dgvAccountants = New DataGridView()
        txtSearchAccountant = New TextBox()
        btnAddAccountant = New FontAwesome.Sharp.IconButton()
        Label10 = New Label()
        Panel2 = New Panel()
        Label2 = New Label()
        lblTotalPatients = New Label()
        Panel7 = New Panel()
        Panel8 = New Panel()
        Panel9 = New Panel()
        Panel1.SuspendLayout()
        pnlDashboard.SuspendLayout()
        tabDashboard.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
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
        pnlSettingsAdmin.SuspendLayout()
        pnlNurses.SuspendLayout()
        Panel5.SuspendLayout()
        CType(dgvNurses, ComponentModel.ISupportInitialize).BeginInit()
        pnlAccountants.SuspendLayout()
        Panel6.SuspendLayout()
        CType(dgvAccountants, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel7.SuspendLayout()
        Panel8.SuspendLayout()
        Panel9.SuspendLayout()
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
        Panel1.Controls.Add(btnAccountant)
        Panel1.Controls.Add(btnNurse)
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
        btnSettings.Location = New Point(0, 420)
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
        btnBilling.Location = New Point(0, 360)
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
        btnAppointments.Location = New Point(0, 300)
        btnAppointments.Margin = New Padding(5)
        btnAppointments.Name = "btnAppointments"
        btnAppointments.Size = New Size(300, 60)
        btnAppointments.TabIndex = 3
        btnAppointments.Text = "Appointments"
        btnAppointments.TextAlign = ContentAlignment.MiddleLeft
        btnAppointments.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAppointments.UseVisualStyleBackColor = False
        ' 
        ' btnAccountant
        ' 
        btnAccountant.BackColor = Color.Transparent
        btnAccountant.Dock = DockStyle.Top
        btnAccountant.FlatAppearance.BorderSize = 0
        btnAccountant.FlatStyle = FlatStyle.Flat
        btnAccountant.Font = New Font("Verdana", 10.2F)
        btnAccountant.IconChar = FontAwesome.Sharp.IconChar.UserTie
        btnAccountant.IconColor = Color.Black
        btnAccountant.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnAccountant.IconSize = 36
        btnAccountant.ImageAlign = ContentAlignment.MiddleLeft
        btnAccountant.Location = New Point(0, 240)
        btnAccountant.Margin = New Padding(5)
        btnAccountant.Name = "btnAccountant"
        btnAccountant.Size = New Size(300, 60)
        btnAccountant.TabIndex = 8
        btnAccountant.Text = "Accountants"
        btnAccountant.TextAlign = ContentAlignment.MiddleLeft
        btnAccountant.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAccountant.UseVisualStyleBackColor = False
        ' 
        ' btnNurse
        ' 
        btnNurse.BackColor = Color.Transparent
        btnNurse.Dock = DockStyle.Top
        btnNurse.FlatAppearance.BorderSize = 0
        btnNurse.FlatStyle = FlatStyle.Flat
        btnNurse.Font = New Font("Verdana", 10.2F)
        btnNurse.IconChar = FontAwesome.Sharp.IconChar.UserNurse
        btnNurse.IconColor = Color.Black
        btnNurse.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnNurse.IconSize = 36
        btnNurse.ImageAlign = ContentAlignment.MiddleLeft
        btnNurse.Location = New Point(0, 180)
        btnNurse.Margin = New Padding(5)
        btnNurse.Name = "btnNurse"
        btnNurse.Size = New Size(300, 60)
        btnNurse.TabIndex = 7
        btnNurse.Text = "Nurses"
        btnNurse.TextAlign = ContentAlignment.MiddleLeft
        btnNurse.TextImageRelation = TextImageRelation.ImageBeforeText
        btnNurse.UseVisualStyleBackColor = False
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
        pnlDashboard.Controls.Add(Panel8)
        pnlDashboard.Controls.Add(Panel7)
        pnlDashboard.Controls.Add(Panel2)
        pnlDashboard.Controls.Add(tabDashboard)
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
        ' lblActiveDoctors
        ' 
        lblActiveDoctors.AutoSize = True
        lblActiveDoctors.BackColor = Color.Transparent
        lblActiveDoctors.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActiveDoctors.Location = New Point(19, 74)
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
        Label4.Location = New Point(19, 13)
        Label4.Name = "Label4"
        Label4.Size = New Size(157, 22)
        Label4.TabIndex = 5
        Label4.Text = "Active Doctors"
        ' 
        ' lblTodaysAppointments
        ' 
        lblTodaysAppointments.AutoSize = True
        lblTodaysAppointments.BackColor = Color.Transparent
        lblTodaysAppointments.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTodaysAppointments.Location = New Point(17, 74)
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
        Label3.Location = New Point(17, 13)
        Label3.Name = "Label3"
        Label3.Size = New Size(236, 22)
        Label3.TabIndex = 4
        Label3.Text = "Today's Appointments"
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
        txtSearchPatient.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchPatient.Location = New Point(24, 90)
        txtSearchPatient.Name = "txtSearchPatient"
        txtSearchPatient.PlaceholderText = "Search patient..."
        txtSearchPatient.Size = New Size(250, 32)
        txtSearchPatient.TabIndex = 3
        ' 
        ' btnAddPatient
        ' 
        btnAddPatient.BackColor = Color.FromArgb(CByte(204), CByte(51), CByte(102))
        btnAddPatient.FlatAppearance.BorderSize = 0
        btnAddPatient.FlatStyle = FlatStyle.Flat
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
        btnAddPatient.UseVisualStyleBackColor = False
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
        pnlDoctors.Controls.Add(btnAddDoctor)
        pnlDoctors.Controls.Add(pnlDoctorsDataGrid)
        pnlDoctors.Controls.Add(txtSearchDoctor)
        pnlDoctors.Controls.Add(Label6)
        pnlDoctors.Dock = DockStyle.Fill
        pnlDoctors.Location = New Point(300, 40)
        pnlDoctors.Name = "pnlDoctors"
        pnlDoctors.Size = New Size(900, 660)
        pnlDoctors.TabIndex = 7
        ' 
        ' btnAddDoctor
        ' 
        btnAddDoctor.BackColor = Color.FromArgb(CByte(204), CByte(51), CByte(102))
        btnAddDoctor.FlatAppearance.BorderSize = 0
        btnAddDoctor.FlatStyle = FlatStyle.Flat
        btnAddDoctor.Font = New Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddDoctor.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        btnAddDoctor.IconColor = Color.Black
        btnAddDoctor.IconFont = FontAwesome.Sharp.IconFont.Regular
        btnAddDoctor.IconSize = 34
        btnAddDoctor.Location = New Point(681, 22)
        btnAddDoctor.Name = "btnAddDoctor"
        btnAddDoctor.Size = New Size(195, 60)
        btnAddDoctor.TabIndex = 2
        btnAddDoctor.Text = "Add Doctor"
        btnAddDoctor.TextAlign = ContentAlignment.MiddleRight
        btnAddDoctor.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAddDoctor.UseVisualStyleBackColor = False
        ' 
        ' pnlDoctorsDataGrid
        ' 
        pnlDoctorsDataGrid.Controls.Add(dgvDoctors)
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
        ' txtSearchDoctor
        ' 
        txtSearchDoctor.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
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
        ' pnlSettingsAdmin
        ' 
        pnlSettingsAdmin.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlSettingsAdmin.Controls.Add(Panel9)
        pnlSettingsAdmin.Controls.Add(btnSaveAdminSettings)
        pnlSettingsAdmin.Controls.Add(SmallLabel1)
        pnlSettingsAdmin.Controls.Add(Label21)
        pnlSettingsAdmin.Dock = DockStyle.Fill
        pnlSettingsAdmin.Location = New Point(300, 40)
        pnlSettingsAdmin.Name = "pnlSettingsAdmin"
        pnlSettingsAdmin.Size = New Size(900, 660)
        pnlSettingsAdmin.TabIndex = 12
        ' 
        ' btnSaveAdminSettings
        ' 
        btnSaveAdminSettings.BackColor = Color.FromArgb(CByte(204), CByte(51), CByte(102))
        btnSaveAdminSettings.FlatAppearance.BorderSize = 0
        btnSaveAdminSettings.FlatStyle = FlatStyle.Flat
        btnSaveAdminSettings.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveAdminSettings.IconChar = FontAwesome.Sharp.IconChar.Check
        btnSaveAdminSettings.IconColor = Color.Black
        btnSaveAdminSettings.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSaveAdminSettings.IconSize = 36
        btnSaveAdminSettings.ImageAlign = ContentAlignment.MiddleRight
        btnSaveAdminSettings.Location = New Point(664, 463)
        btnSaveAdminSettings.Name = "btnSaveAdminSettings"
        btnSaveAdminSettings.Size = New Size(118, 44)
        btnSaveAdminSettings.TabIndex = 21
        btnSaveAdminSettings.Text = "Save"
        btnSaveAdminSettings.TextImageRelation = TextImageRelation.TextBeforeImage
        btnSaveAdminSettings.UseVisualStyleBackColor = False
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
        ' btnEyeConfirmPassword
        ' 
        btnEyeConfirmPassword.BackColor = Color.Transparent
        btnEyeConfirmPassword.FlatAppearance.BorderSize = 0
        btnEyeConfirmPassword.FlatStyle = FlatStyle.Flat
        btnEyeConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        btnEyeConfirmPassword.IconColor = Color.Black
        btnEyeConfirmPassword.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEyeConfirmPassword.IconSize = 25
        btnEyeConfirmPassword.Location = New Point(588, 183)
        btnEyeConfirmPassword.Name = "btnEyeConfirmPassword"
        btnEyeConfirmPassword.Size = New Size(32, 32)
        btnEyeConfirmPassword.TabIndex = 47
        btnEyeConfirmPassword.UseVisualStyleBackColor = False
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Location = New Point(285, 180)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(300, 27)
        txtConfirmPassword.TabIndex = 46
        txtConfirmPassword.UseSystemPasswordChar = True
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.Transparent
        Label15.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(19, 183)
        Label15.Name = "Label15"
        Label15.Size = New Size(181, 28)
        Label15.TabIndex = 45
        Label15.Text = "Confirm Password:"
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
        btnEyePassword.Location = New Point(588, 134)
        btnEyePassword.Name = "btnEyePassword"
        btnEyePassword.Size = New Size(32, 32)
        btnEyePassword.TabIndex = 44
        btnEyePassword.UseVisualStyleBackColor = False
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Location = New Point(285, 278)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(300, 27)
        txtContactNumber.TabIndex = 12
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(285, 131)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(300, 27)
        txtPassword.TabIndex = 11
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(285, 229)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(300, 27)
        txtEmail.TabIndex = 10
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(91, 85)
        Label14.Name = "Label14"
        Label14.Size = New Size(109, 28)
        Label14.TabIndex = 7
        Label14.Text = "Username:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(32, 281)
        Label13.Name = "Label13"
        Label13.Size = New Size(168, 28)
        Label13.TabIndex = 6
        Label13.Text = "Contact Number:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(135, 232)
        Label12.Name = "Label12"
        Label12.Size = New Size(65, 28)
        Label12.TabIndex = 5
        Label12.Text = "Email:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(98, 134)
        Label11.Name = "Label11"
        Label11.Size = New Size(102, 28)
        Label11.TabIndex = 4
        Label11.Text = "Password:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(285, 82)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(300, 27)
        txtUsername.TabIndex = 8
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
        ' pnlNurses
        ' 
        pnlNurses.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlNurses.Controls.Add(Panel5)
        pnlNurses.Controls.Add(txtSearchNurses)
        pnlNurses.Controls.Add(btnAddNurse)
        pnlNurses.Controls.Add(Label9)
        pnlNurses.Dock = DockStyle.Fill
        pnlNurses.Location = New Point(300, 40)
        pnlNurses.Name = "pnlNurses"
        pnlNurses.Size = New Size(900, 660)
        pnlNurses.TabIndex = 22
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(dgvNurses)
        Panel5.Location = New Point(24, 134)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(852, 514)
        Panel5.TabIndex = 5
        ' 
        ' dgvNurses
        ' 
        dgvNurses.ColumnHeadersHeight = 29
        dgvNurses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvNurses.Dock = DockStyle.Fill
        dgvNurses.Location = New Point(0, 0)
        dgvNurses.Name = "dgvNurses"
        dgvNurses.RowHeadersWidth = 51
        dgvNurses.Size = New Size(852, 514)
        dgvNurses.TabIndex = 4
        ' 
        ' txtSearchNurses
        ' 
        txtSearchNurses.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchNurses.Location = New Point(24, 90)
        txtSearchNurses.Name = "txtSearchNurses"
        txtSearchNurses.PlaceholderText = "Search nurse..."
        txtSearchNurses.Size = New Size(250, 32)
        txtSearchNurses.TabIndex = 3
        ' 
        ' btnAddNurse
        ' 
        btnAddNurse.BackColor = Color.FromArgb(CByte(204), CByte(51), CByte(102))
        btnAddNurse.FlatAppearance.BorderSize = 0
        btnAddNurse.FlatStyle = FlatStyle.Flat
        btnAddNurse.Font = New Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddNurse.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        btnAddNurse.IconColor = Color.Black
        btnAddNurse.IconFont = FontAwesome.Sharp.IconFont.Regular
        btnAddNurse.IconSize = 34
        btnAddNurse.Location = New Point(681, 22)
        btnAddNurse.Name = "btnAddNurse"
        btnAddNurse.Size = New Size(195, 60)
        btnAddNurse.TabIndex = 2
        btnAddNurse.Text = "Add Nurse"
        btnAddNurse.TextAlign = ContentAlignment.MiddleRight
        btnAddNurse.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAddNurse.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(24, 32)
        Label9.Name = "Label9"
        Label9.Size = New Size(126, 34)
        Label9.TabIndex = 1
        Label9.Text = "Nurses"
        ' 
        ' pnlAccountants
        ' 
        pnlAccountants.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlAccountants.Controls.Add(Panel6)
        pnlAccountants.Controls.Add(txtSearchAccountant)
        pnlAccountants.Controls.Add(btnAddAccountant)
        pnlAccountants.Controls.Add(Label10)
        pnlAccountants.Dock = DockStyle.Fill
        pnlAccountants.Location = New Point(300, 40)
        pnlAccountants.Name = "pnlAccountants"
        pnlAccountants.Size = New Size(900, 660)
        pnlAccountants.TabIndex = 23
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(dgvAccountants)
        Panel6.Location = New Point(24, 134)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(852, 514)
        Panel6.TabIndex = 5
        ' 
        ' dgvAccountants
        ' 
        dgvAccountants.ColumnHeadersHeight = 29
        dgvAccountants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvAccountants.Dock = DockStyle.Fill
        dgvAccountants.Location = New Point(0, 0)
        dgvAccountants.Name = "dgvAccountants"
        dgvAccountants.RowHeadersWidth = 51
        dgvAccountants.Size = New Size(852, 514)
        dgvAccountants.TabIndex = 4
        ' 
        ' txtSearchAccountant
        ' 
        txtSearchAccountant.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchAccountant.Location = New Point(24, 90)
        txtSearchAccountant.Name = "txtSearchAccountant"
        txtSearchAccountant.PlaceholderText = "Search accountant..."
        txtSearchAccountant.Size = New Size(250, 32)
        txtSearchAccountant.TabIndex = 3
        ' 
        ' btnAddAccountant
        ' 
        btnAddAccountant.BackColor = Color.FromArgb(CByte(204), CByte(51), CByte(102))
        btnAddAccountant.FlatAppearance.BorderSize = 0
        btnAddAccountant.FlatStyle = FlatStyle.Flat
        btnAddAccountant.Font = New Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddAccountant.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        btnAddAccountant.IconColor = Color.Black
        btnAddAccountant.IconFont = FontAwesome.Sharp.IconFont.Regular
        btnAddAccountant.IconSize = 34
        btnAddAccountant.Location = New Point(681, 22)
        btnAddAccountant.Name = "btnAddAccountant"
        btnAddAccountant.Size = New Size(195, 60)
        btnAddAccountant.TabIndex = 2
        btnAddAccountant.Text = "Add Accountant"
        btnAddAccountant.TextAlign = ContentAlignment.MiddleRight
        btnAddAccountant.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAddAccountant.UseVisualStyleBackColor = False
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(24, 32)
        Label10.Name = "Label10"
        Label10.Size = New Size(210, 34)
        Label10.TabIndex = 1
        Label10.Text = "Accountants"
        ' 
        ' Panel2
        ' 
        Panel2.BackgroundImage = My.Resources.Resources._8
        Panel2.BackgroundImageLayout = ImageLayout.Stretch
        Panel2.Controls.Add(lblTotalPatients)
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(24, 60)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(280, 150)
        Panel2.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(17, 13)
        Label2.Name = "Label2"
        Label2.Size = New Size(149, 22)
        Label2.TabIndex = 3
        Label2.Text = "Total Patients"
        ' 
        ' lblTotalPatients
        ' 
        lblTotalPatients.AutoSize = True
        lblTotalPatients.BackColor = Color.Transparent
        lblTotalPatients.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalPatients.Location = New Point(17, 77)
        lblTotalPatients.Name = "lblTotalPatients"
        lblTotalPatients.Size = New Size(190, 28)
        lblTotalPatients.TabIndex = 4
        lblTotalPatients.Text = "Total Patients"
        ' 
        ' Panel7
        ' 
        Panel7.BackgroundImage = My.Resources.Resources._8
        Panel7.BackgroundImageLayout = ImageLayout.Stretch
        Panel7.Controls.Add(lblTodaysAppointments)
        Panel7.Controls.Add(Label3)
        Panel7.Location = New Point(310, 60)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(280, 150)
        Panel7.TabIndex = 6
        ' 
        ' Panel8
        ' 
        Panel8.BackgroundImage = My.Resources.Resources._8
        Panel8.BackgroundImageLayout = ImageLayout.Stretch
        Panel8.Controls.Add(lblActiveDoctors)
        Panel8.Controls.Add(Label4)
        Panel8.Location = New Point(596, 60)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(280, 150)
        Panel8.TabIndex = 7
        ' 
        ' Panel9
        ' 
        Panel9.BackgroundImage = CType(resources.GetObject("Panel9.BackgroundImage"), Image)
        Panel9.BackgroundImageLayout = ImageLayout.Stretch
        Panel9.Controls.Add(btnEyeConfirmPassword)
        Panel9.Controls.Add(txtConfirmPassword)
        Panel9.Controls.Add(Label15)
        Panel9.Controls.Add(btnEyePassword)
        Panel9.Controls.Add(txtContactNumber)
        Panel9.Controls.Add(txtPassword)
        Panel9.Controls.Add(txtEmail)
        Panel9.Controls.Add(Label14)
        Panel9.Controls.Add(Label13)
        Panel9.Controls.Add(Label12)
        Panel9.Controls.Add(Label11)
        Panel9.Controls.Add(txtUsername)
        Panel9.Location = New Point(157, 98)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(631, 332)
        Panel9.TabIndex = 48
        ' 
        ' AdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 700)
        Controls.Add(pnlSettingsAdmin)
        Controls.Add(pnlDashboard)
        Controls.Add(pnlAccountants)
        Controls.Add(pnlNurses)
        Controls.Add(pnlDoctors)
        Controls.Add(pnlPatients)
        Controls.Add(pnlBilling)
        Controls.Add(pnlAppointments)
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
        pnlSettingsAdmin.ResumeLayout(False)
        pnlSettingsAdmin.PerformLayout()
        pnlNurses.ResumeLayout(False)
        pnlNurses.PerformLayout()
        Panel5.ResumeLayout(False)
        CType(dgvNurses, ComponentModel.ISupportInitialize).EndInit()
        pnlAccountants.ResumeLayout(False)
        pnlAccountants.PerformLayout()
        Panel6.ResumeLayout(False)
        CType(dgvAccountants, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
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
    Friend WithEvents pnlSettingsAdmin As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents pnlAdminSettings As Panel
    Friend WithEvents SmallLabel1 As ReaLTaiizor.Controls.SmallLabel
    Friend WithEvents btnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents HopeGroupBox6 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents btnEyePassword As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSaveAdminSettings As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAccountant As FontAwesome.Sharp.IconButton
    Friend WithEvents btnNurse As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlNurses As Panel
    Friend WithEvents dgvNurses As DataGridView
    Friend WithEvents txtSearchNurses As TextBox
    Friend WithEvents btnAddNurse As FontAwesome.Sharp.IconButton
    Friend WithEvents Label9 As Label
    Friend WithEvents pnlAccountants As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents dgvAccountants As DataGridView
    Friend WithEvents txtSearchAccountant As TextBox
    Friend WithEvents btnAddAccountant As FontAwesome.Sharp.IconButton
    Friend WithEvents Label10 As Label
    Friend WithEvents btnEyeConfirmPassword As FontAwesome.Sharp.IconButton
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTotalPatients As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
End Class
