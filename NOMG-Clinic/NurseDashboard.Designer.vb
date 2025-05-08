<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NurseDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NurseDashboard))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        btnSettings = New FontAwesome.Sharp.IconButton()
        btnLogout = New FontAwesome.Sharp.IconButton()
        btnAppointments = New FontAwesome.Sharp.IconButton()
        btnPatients = New FontAwesome.Sharp.IconButton()
        btnDashboard = New FontAwesome.Sharp.IconButton()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblTotalPatients = New Label()
        Label1 = New Label()
        HopeGroupBox2 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblActiveDoctors = New Label()
        label = New Label()
        tabDashboard = New TabControl()
        TabPage1 = New TabPage()
        flowScheduledToday = New FlowLayoutPanel()
        TabPage2 = New TabPage()
        flowRecentAppointments = New FlowLayoutPanel()
        HopeGroupBox3 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblTodaysAppointments = New Label()
        Label4 = New Label()
        pnlDashboard = New Panel()
        lblWelcomeMessage = New Label()
        pnlPatients = New Panel()
        btnAddPatient = New FontAwesome.Sharp.IconButton()
        pnlPatientsDataGrid = New Panel()
        dgvPatients = New DataGridView()
        txtSearchPatient = New TextBox()
        Label5 = New Label()
        pnlAppointments = New Panel()
        Panel3 = New Panel()
        dgvAppointments = New DataGridView()
        Appointments = New Label()
        pnlSettings = New Panel()
        btnSave = New FontAwesome.Sharp.IconButton()
        Label8 = New Label()
        HopeGroupBox4 = New ReaLTaiizor.Controls.HopeGroupBox()
        btnEyeConfirmPassword = New FontAwesome.Sharp.IconButton()
        txtConfirmPassword = New TextBox()
        Label15 = New Label()
        btnEyePassword = New FontAwesome.Sharp.IconButton()
        txtPassword = New TextBox()
        Label14 = New Label()
        Label11 = New Label()
        txtUsername = New TextBox()
        Label6 = New Label()
        Panel1.SuspendLayout()
        HopeGroupBox1.SuspendLayout()
        HopeGroupBox2.SuspendLayout()
        tabDashboard.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        HopeGroupBox3.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlPatients.SuspendLayout()
        pnlPatientsDataGrid.SuspendLayout()
        CType(dgvPatients, ComponentModel.ISupportInitialize).BeginInit()
        pnlAppointments.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvAppointments, ComponentModel.ISupportInitialize).BeginInit()
        pnlSettings.SuspendLayout()
        HopeGroupBox4.SuspendLayout()
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
        HopeForm1.Text = "Nurse"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(227), CByte(190), CByte(210))
        Panel1.Controls.Add(btnSettings)
        Panel1.Controls.Add(btnLogout)
        Panel1.Controls.Add(btnAppointments)
        Panel1.Controls.Add(btnPatients)
        Panel1.Controls.Add(btnDashboard)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 660)
        Panel1.TabIndex = 4
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
        btnSettings.TabIndex = 8
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
        btnLogout.TabIndex = 6
        btnLogout.Text = "Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText
        btnLogout.UseVisualStyleBackColor = False
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
        btnAppointments.Location = New Point(0, 120)
        btnAppointments.Margin = New Padding(5)
        btnAppointments.Name = "btnAppointments"
        btnAppointments.Size = New Size(300, 60)
        btnAppointments.TabIndex = 3
        btnAppointments.Text = "Appointments"
        btnAppointments.TextAlign = ContentAlignment.MiddleLeft
        btnAppointments.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAppointments.UseVisualStyleBackColor = False
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
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Controls.Add(lblTotalPatients)
        HopeGroupBox1.Controls.Add(Label1)
        HopeGroupBox1.Font = New Font("Segoe UI", 12F)
        HopeGroupBox1.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox1.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Location = New Point(27, 60)
        HopeGroupBox1.Name = "HopeGroupBox1"
        HopeGroupBox1.ShowText = False
        HopeGroupBox1.Size = New Size(266, 157)
        HopeGroupBox1.TabIndex = 0
        HopeGroupBox1.TabStop = False
        HopeGroupBox1.Text = "HopeGroupBox1"
        HopeGroupBox1.ThemeColor = Color.FromArgb(CByte(64), CByte(158), CByte(255))
        ' 
        ' lblTotalPatients
        ' 
        lblTotalPatients.BackColor = Color.Transparent
        lblTotalPatients.Font = New Font("Verdana", 13.8F, FontStyle.Bold)
        lblTotalPatients.Location = New Point(11, 85)
        lblTotalPatients.Name = "lblTotalPatients"
        lblTotalPatients.Size = New Size(224, 44)
        lblTotalPatients.TabIndex = 1
        lblTotalPatients.Text = "Total Patients"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Verdana", 10.8F, FontStyle.Bold)
        Label1.Location = New Point(11, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(149, 22)
        Label1.TabIndex = 0
        Label1.Text = "Total Patients"
        ' 
        ' HopeGroupBox2
        ' 
        HopeGroupBox2.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox2.Controls.Add(lblActiveDoctors)
        HopeGroupBox2.Controls.Add(label)
        HopeGroupBox2.Font = New Font("Segoe UI", 12F)
        HopeGroupBox2.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox2.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox2.Location = New Point(316, 60)
        HopeGroupBox2.Name = "HopeGroupBox2"
        HopeGroupBox2.ShowText = False
        HopeGroupBox2.Size = New Size(266, 157)
        HopeGroupBox2.TabIndex = 1
        HopeGroupBox2.TabStop = False
        HopeGroupBox2.Text = "HopeGroupBox2"
        HopeGroupBox2.ThemeColor = Color.FromArgb(CByte(64), CByte(158), CByte(255))
        ' 
        ' lblActiveDoctors
        ' 
        lblActiveDoctors.BackColor = Color.Transparent
        lblActiveDoctors.Font = New Font("Verdana", 13.8F, FontStyle.Bold)
        lblActiveDoctors.Location = New Point(11, 85)
        lblActiveDoctors.Name = "lblActiveDoctors"
        lblActiveDoctors.Size = New Size(229, 44)
        lblActiveDoctors.TabIndex = 1
        lblActiveDoctors.Text = "Total Doctors"
        ' 
        ' label
        ' 
        label.AutoSize = True
        label.BackColor = Color.Transparent
        label.Font = New Font("Verdana", 10.8F, FontStyle.Bold)
        label.Location = New Point(11, 25)
        label.Name = "label"
        label.Size = New Size(173, 22)
        label.TabIndex = 0
        label.Text = "Doctors on Duty"
        ' 
        ' tabDashboard
        ' 
        tabDashboard.Controls.Add(TabPage1)
        tabDashboard.Controls.Add(TabPage2)
        tabDashboard.Location = New Point(31, 248)
        tabDashboard.Name = "tabDashboard"
        tabDashboard.SelectedIndex = 0
        tabDashboard.Size = New Size(845, 397)
        tabDashboard.SizeMode = TabSizeMode.Fixed
        tabDashboard.TabIndex = 2
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(flowScheduledToday)
        TabPage1.Location = New Point(4, 29)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(837, 364)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Scheduled Today"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' flowScheduledToday
        ' 
        flowScheduledToday.Dock = DockStyle.Fill
        flowScheduledToday.Location = New Point(3, 3)
        flowScheduledToday.Name = "flowScheduledToday"
        flowScheduledToday.Size = New Size(831, 358)
        flowScheduledToday.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(flowRecentAppointments)
        TabPage2.Location = New Point(4, 29)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(837, 364)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Recent Appointments"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' flowRecentAppointments
        ' 
        flowRecentAppointments.AutoScroll = True
        flowRecentAppointments.Dock = DockStyle.Fill
        flowRecentAppointments.Location = New Point(3, 3)
        flowRecentAppointments.Name = "flowRecentAppointments"
        flowRecentAppointments.Size = New Size(831, 358)
        flowRecentAppointments.TabIndex = 0
        ' 
        ' HopeGroupBox3
        ' 
        HopeGroupBox3.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox3.Controls.Add(lblTodaysAppointments)
        HopeGroupBox3.Controls.Add(Label4)
        HopeGroupBox3.Font = New Font("Segoe UI", 12F)
        HopeGroupBox3.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox3.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox3.Location = New Point(606, 60)
        HopeGroupBox3.Name = "HopeGroupBox3"
        HopeGroupBox3.ShowText = False
        HopeGroupBox3.Size = New Size(266, 157)
        HopeGroupBox3.TabIndex = 3
        HopeGroupBox3.TabStop = False
        HopeGroupBox3.Text = "HopeGroupBox3"
        HopeGroupBox3.ThemeColor = Color.FromArgb(CByte(64), CByte(158), CByte(255))
        ' 
        ' lblTodaysAppointments
        ' 
        lblTodaysAppointments.BackColor = Color.Transparent
        lblTodaysAppointments.Font = New Font("Verdana", 13.8F, FontStyle.Bold)
        lblTodaysAppointments.Location = New Point(11, 85)
        lblTodaysAppointments.Name = "lblTodaysAppointments"
        lblTodaysAppointments.Size = New Size(229, 40)
        lblTodaysAppointments.TabIndex = 2
        lblTodaysAppointments.Text = "Total Doctors"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(11, 25)
        Label4.Name = "Label4"
        Label4.Size = New Size(251, 25)
        Label4.TabIndex = 0
        Label4.Text = "Today's Appointment"
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.BackColor = Color.Transparent
        pnlDashboard.Controls.Add(lblWelcomeMessage)
        pnlDashboard.Controls.Add(HopeGroupBox3)
        pnlDashboard.Controls.Add(tabDashboard)
        pnlDashboard.Controls.Add(HopeGroupBox2)
        pnlDashboard.Controls.Add(HopeGroupBox1)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(300, 40)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(900, 660)
        pnlDashboard.TabIndex = 5
        ' 
        ' lblWelcomeMessage
        ' 
        lblWelcomeMessage.AutoSize = True
        lblWelcomeMessage.BackColor = Color.Transparent
        lblWelcomeMessage.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWelcomeMessage.Location = New Point(27, 10)
        lblWelcomeMessage.Name = "lblWelcomeMessage"
        lblWelcomeMessage.Size = New Size(25, 34)
        lblWelcomeMessage.TabIndex = 7
        lblWelcomeMessage.Text = "."
        ' 
        ' pnlPatients
        ' 
        pnlPatients.BackColor = Color.Transparent
        pnlPatients.Controls.Add(btnAddPatient)
        pnlPatients.Controls.Add(pnlPatientsDataGrid)
        pnlPatients.Controls.Add(txtSearchPatient)
        pnlPatients.Controls.Add(Label5)
        pnlPatients.Dock = DockStyle.Fill
        pnlPatients.Location = New Point(300, 40)
        pnlPatients.Name = "pnlPatients"
        pnlPatients.Size = New Size(900, 660)
        pnlPatients.TabIndex = 6
        ' 
        ' btnAddPatient
        ' 
        btnAddPatient.Font = New Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddPatient.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        btnAddPatient.IconColor = Color.Black
        btnAddPatient.IconFont = FontAwesome.Sharp.IconFont.Regular
        btnAddPatient.IconSize = 34
        btnAddPatient.Location = New Point(671, 16)
        btnAddPatient.Name = "btnAddPatient"
        btnAddPatient.Size = New Size(195, 60)
        btnAddPatient.TabIndex = 12
        btnAddPatient.Text = "Add Patient"
        btnAddPatient.TextAlign = ContentAlignment.MiddleRight
        btnAddPatient.TextImageRelation = TextImageRelation.ImageBeforeText
        btnAddPatient.UseVisualStyleBackColor = True
        ' 
        ' pnlPatientsDataGrid
        ' 
        pnlPatientsDataGrid.Controls.Add(dgvPatients)
        pnlPatientsDataGrid.Location = New Point(20, 139)
        pnlPatientsDataGrid.Name = "pnlPatientsDataGrid"
        pnlPatientsDataGrid.Size = New Size(852, 514)
        pnlPatientsDataGrid.TabIndex = 11
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
        txtSearchPatient.Location = New Point(24, 82)
        txtSearchPatient.Name = "txtSearchPatient"
        txtSearchPatient.PlaceholderText = "Search patient..."
        txtSearchPatient.Size = New Size(250, 32)
        txtSearchPatient.TabIndex = 10
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(24, 26)
        Label5.Name = "Label5"
        Label5.Size = New Size(147, 34)
        Label5.TabIndex = 9
        Label5.Text = "Patients"
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
        pnlAppointments.TabIndex = 12
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
        ' pnlSettings
        ' 
        pnlSettings.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        pnlSettings.Controls.Add(btnSave)
        pnlSettings.Controls.Add(Label8)
        pnlSettings.Controls.Add(HopeGroupBox4)
        pnlSettings.Controls.Add(Label6)
        pnlSettings.Dock = DockStyle.Fill
        pnlSettings.Location = New Point(300, 40)
        pnlSettings.Name = "pnlSettings"
        pnlSettings.Size = New Size(900, 660)
        pnlSettings.TabIndex = 5
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.IconChar = FontAwesome.Sharp.IconChar.Cloud
        btnSave.IconColor = Color.RosyBrown
        btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSave.ImageAlign = ContentAlignment.MiddleLeft
        btnSave.Location = New Point(382, 424)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(118, 44)
        btnSave.TabIndex = 24
        btnSave.Text = "        SAVE"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(338, 151)
        Label8.Name = "Label8"
        Label8.Size = New Size(223, 31)
        Label8.TabIndex = 23
        Label8.Text = "Account Information"
        ' 
        ' HopeGroupBox4
        ' 
        HopeGroupBox4.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Controls.Add(btnEyeConfirmPassword)
        HopeGroupBox4.Controls.Add(txtConfirmPassword)
        HopeGroupBox4.Controls.Add(Label15)
        HopeGroupBox4.Controls.Add(btnEyePassword)
        HopeGroupBox4.Controls.Add(txtPassword)
        HopeGroupBox4.Controls.Add(Label14)
        HopeGroupBox4.Controls.Add(Label11)
        HopeGroupBox4.Controls.Add(txtUsername)
        HopeGroupBox4.Font = New Font("Segoe UI", 12F)
        HopeGroupBox4.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox4.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Location = New Point(135, 188)
        HopeGroupBox4.Name = "HopeGroupBox4"
        HopeGroupBox4.ShowText = False
        HopeGroupBox4.Size = New Size(631, 199)
        HopeGroupBox4.TabIndex = 22
        HopeGroupBox4.TabStop = False
        HopeGroupBox4.Text = "HopeGroupBox4"
        HopeGroupBox4.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
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
        btnEyeConfirmPassword.Location = New Point(593, 137)
        btnEyeConfirmPassword.Name = "btnEyeConfirmPassword"
        btnEyeConfirmPassword.Size = New Size(32, 32)
        btnEyeConfirmPassword.TabIndex = 47
        btnEyeConfirmPassword.UseVisualStyleBackColor = False
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Location = New Point(290, 137)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(300, 34)
        txtConfirmPassword.TabIndex = 46
        txtConfirmPassword.UseSystemPasswordChar = True
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label15.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(24, 136)
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
        btnEyePassword.Location = New Point(593, 84)
        btnEyePassword.Name = "btnEyePassword"
        btnEyePassword.Size = New Size(32, 32)
        btnEyePassword.TabIndex = 44
        btnEyePassword.UseVisualStyleBackColor = False
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(290, 84)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(300, 34)
        txtPassword.TabIndex = 11
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label14.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(24, 30)
        Label14.Name = "Label14"
        Label14.Size = New Size(109, 28)
        Label14.TabIndex = 7
        Label14.Text = "Username:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label11.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(24, 83)
        Label11.Name = "Label11"
        Label11.Size = New Size(102, 28)
        Label11.TabIndex = 4
        Label11.Text = "Password:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(290, 31)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(300, 34)
        txtUsername.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(20, 23)
        Label6.Name = "Label6"
        Label6.Size = New Size(147, 34)
        Label6.TabIndex = 2
        Label6.Text = "Settings"
        ' 
        ' NurseDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.bg_img
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1200, 700)
        Controls.Add(pnlDashboard)
        Controls.Add(pnlSettings)
        Controls.Add(pnlPatients)
        Controls.Add(pnlAppointments)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1020)
        MinimumSize = New Size(190, 40)
        Name = "NurseDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "NurseDashboard"
        Panel1.ResumeLayout(False)
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        HopeGroupBox2.ResumeLayout(False)
        HopeGroupBox2.PerformLayout()
        tabDashboard.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        HopeGroupBox3.ResumeLayout(False)
        HopeGroupBox3.PerformLayout()
        pnlDashboard.ResumeLayout(False)
        pnlDashboard.PerformLayout()
        pnlPatients.ResumeLayout(False)
        pnlPatients.PerformLayout()
        pnlPatientsDataGrid.ResumeLayout(False)
        CType(dgvPatients, ComponentModel.ISupportInitialize).EndInit()
        pnlAppointments.ResumeLayout(False)
        pnlAppointments.PerformLayout()
        Panel3.ResumeLayout(False)
        CType(dgvAppointments, ComponentModel.ISupportInitialize).EndInit()
        pnlSettings.ResumeLayout(False)
        pnlSettings.PerformLayout()
        HopeGroupBox4.ResumeLayout(False)
        HopeGroupBox4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLogout As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAppointments As FontAwesome.Sharp.IconButton
    Friend WithEvents btnPatients As FontAwesome.Sharp.IconButton
    Friend WithEvents btnDashboard As FontAwesome.Sharp.IconButton
    Friend WithEvents HopeGroupBox1 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents lblTotalPatients As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents HopeGroupBox2 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents lblActiveDoctors As Label
    Friend WithEvents label As Label
    Friend WithEvents tabDashboard As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents flowScheduledToday As FlowLayoutPanel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents flowRecentAppointments As FlowLayoutPanel
    Friend WithEvents HopeGroupBox3 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents pnlPatients As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSearchPatient As TextBox
    Friend WithEvents pnlPatientsDataGrid As Panel
    Friend WithEvents dgvPatients As DataGridView
    Friend WithEvents pnlAppointments As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgvAppointments As DataGridView
    Friend WithEvents Appointments As Label
    Friend WithEvents btnSettings As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents Label8 As Label
    Friend WithEvents HopeGroupBox4 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents btnEyePassword As FontAwesome.Sharp.IconButton
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnEyeConfirmPassword As FontAwesome.Sharp.IconButton
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents lblTodaysAppointments As Label
    Friend WithEvents btnAddPatient As FontAwesome.Sharp.IconButton
    Friend WithEvents lblWelcomeMessage As Label
End Class
