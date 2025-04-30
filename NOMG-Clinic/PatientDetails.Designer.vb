<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PatientDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PatientDetails))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        Panel2 = New Panel()
        HopeGroupBox4 = New ReaLTaiizor.Controls.HopeGroupBox()
        flowRecentAppointments = New FlowLayoutPanel()
        Label12 = New Label()
        Label11 = New Label()
        HopeGroupBox2 = New ReaLTaiizor.Controls.HopeGroupBox()
        Label18 = New Label()
        lblAssignedOB = New Label()
        lblNextCheckup = New Label()
        lblGestationalAge = New Label()
        lblLastMenstrual = New Label()
        Label3 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
        Label17 = New Label()
        lblAddress = New Label()
        lblFirstBaby = New Label()
        lblCivilStatus = New Label()
        lblAge = New Label()
        lblName = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TabPage2 = New TabPage()
        Panel3 = New Panel()
        dgvAppointments = New DataGridView()
        Label13 = New Label()
        Label14 = New Label()
        TabPage3 = New TabPage()
        Panel4 = New Panel()
        dgvBilling = New DataGridView()
        Label15 = New Label()
        Label16 = New Label()
        TabPage4 = New TabPage()
        Panel5 = New Panel()
        dgvConsultationDetails = New DataGridView()
        Label19 = New Label()
        Label20 = New Label()
        IconButton2 = New FontAwesome.Sharp.IconButton()
        IconButton1 = New FontAwesome.Sharp.IconButton()
        Label7 = New Label()
        Panel1.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        Panel2.SuspendLayout()
        HopeGroupBox4.SuspendLayout()
        HopeGroupBox2.SuspendLayout()
        HopeGroupBox1.SuspendLayout()
        TabPage2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvAppointments, ComponentModel.ISupportInitialize).BeginInit()
        TabPage3.SuspendLayout()
        Panel4.SuspendLayout()
        CType(dgvBilling, ComponentModel.ISupportInitialize).BeginInit()
        TabPage4.SuspendLayout()
        Panel5.SuspendLayout()
        CType(dgvConsultationDetails, ComponentModel.ISupportInitialize).BeginInit()
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
        HopeForm1.Size = New Size(1000, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "Patient Details"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.BackgroundImage = My.Resources.Resources.bg_img
        Panel1.Controls.Add(TabControl1)
        Panel1.Controls.Add(IconButton2)
        Panel1.Controls.Add(IconButton1)
        Panel1.Controls.Add(Label7)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1000, 660)
        Panel1.TabIndex = 1
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Controls.Add(TabPage4)
        TabControl1.Location = New Point(13, 61)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(975, 587)
        TabControl1.SizeMode = TabSizeMode.Fixed
        TabControl1.TabIndex = 8
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(Panel2)
        TabPage1.Location = New Point(4, 29)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(967, 554)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Overview"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackgroundImage = My.Resources.Resources.bg_img
        Panel2.BackgroundImageLayout = ImageLayout.Stretch
        Panel2.Controls.Add(HopeGroupBox4)
        Panel2.Controls.Add(HopeGroupBox2)
        Panel2.Controls.Add(HopeGroupBox1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(961, 548)
        Panel2.TabIndex = 0
        ' 
        ' HopeGroupBox4
        ' 
        HopeGroupBox4.BackColor = Color.Transparent
        HopeGroupBox4.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Controls.Add(flowRecentAppointments)
        HopeGroupBox4.Controls.Add(Label12)
        HopeGroupBox4.Controls.Add(Label11)
        HopeGroupBox4.Font = New Font("Segoe UI", 12F)
        HopeGroupBox4.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox4.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Location = New Point(10, 269)
        HopeGroupBox4.Name = "HopeGroupBox4"
        HopeGroupBox4.ShowText = False
        HopeGroupBox4.Size = New Size(942, 276)
        HopeGroupBox4.TabIndex = 3
        HopeGroupBox4.TabStop = False
        HopeGroupBox4.Text = "HopeGroupBox4"
        HopeGroupBox4.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        ' 
        ' flowRecentAppointments
        ' 
        flowRecentAppointments.Location = New Point(6, 66)
        flowRecentAppointments.Name = "flowRecentAppointments"
        flowRecentAppointments.Size = New Size(930, 204)
        flowRecentAppointments.TabIndex = 13
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Verdana", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(6, 43)
        Label12.Name = "Label12"
        Label12.Size = New Size(296, 20)
        Label12.TabIndex = 12
        Label12.Text = "Showing the last 3 appointments"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(6, 15)
        Label11.Name = "Label11"
        Label11.Size = New Size(287, 28)
        Label11.TabIndex = 5
        Label11.Text = "Recent Appointments"
        ' 
        ' HopeGroupBox2
        ' 
        HopeGroupBox2.BackColor = Color.Transparent
        HopeGroupBox2.BorderColor = Color.Transparent
        HopeGroupBox2.Controls.Add(Label18)
        HopeGroupBox2.Controls.Add(lblAssignedOB)
        HopeGroupBox2.Controls.Add(lblNextCheckup)
        HopeGroupBox2.Controls.Add(lblGestationalAge)
        HopeGroupBox2.Controls.Add(lblLastMenstrual)
        HopeGroupBox2.Controls.Add(Label3)
        HopeGroupBox2.Controls.Add(Label8)
        HopeGroupBox2.Controls.Add(Label9)
        HopeGroupBox2.Controls.Add(Label10)
        HopeGroupBox2.FlatStyle = FlatStyle.Flat
        HopeGroupBox2.Font = New Font("Segoe UI", 12F)
        HopeGroupBox2.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox2.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox2.Location = New Point(502, 13)
        HopeGroupBox2.Name = "HopeGroupBox2"
        HopeGroupBox2.ShowText = False
        HopeGroupBox2.Size = New Size(450, 250)
        HopeGroupBox2.TabIndex = 1
        HopeGroupBox2.TabStop = False
        HopeGroupBox2.Text = "HopeGroupBox2"
        HopeGroupBox2.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(0, 1)
        Label18.Name = "Label18"
        Label18.Size = New Size(310, 28)
        Label18.TabIndex = 15
        Label18.Text = "Pregnancy Information"
        ' 
        ' lblAssignedOB
        ' 
        lblAssignedOB.AutoSize = True
        lblAssignedOB.Font = New Font("Verdana", 10.2F)
        lblAssignedOB.Location = New Point(138, 142)
        lblAssignedOB.Name = "lblAssignedOB"
        lblAssignedOB.Size = New Size(126, 20)
        lblAssignedOB.TabIndex = 15
        lblAssignedOB.Text = "Assigned OB:"
        ' 
        ' lblNextCheckup
        ' 
        lblNextCheckup.AutoSize = True
        lblNextCheckup.Font = New Font("Verdana", 10.2F)
        lblNextCheckup.Location = New Point(149, 108)
        lblNextCheckup.Name = "lblNextCheckup"
        lblNextCheckup.Size = New Size(137, 20)
        lblNextCheckup.TabIndex = 14
        lblNextCheckup.Text = "Next Checkup:"
        ' 
        ' lblGestationalAge
        ' 
        lblGestationalAge.AutoSize = True
        lblGestationalAge.Font = New Font("Verdana", 10.2F)
        lblGestationalAge.Location = New Point(157, 77)
        lblGestationalAge.Name = "lblGestationalAge"
        lblGestationalAge.Size = New Size(153, 20)
        lblGestationalAge.TabIndex = 13
        lblGestationalAge.Text = "Gestational Age:"
        ' 
        ' lblLastMenstrual
        ' 
        lblLastMenstrual.AutoSize = True
        lblLastMenstrual.Font = New Font("Verdana", 10.2F)
        lblLastMenstrual.Location = New Point(149, 44)
        lblLastMenstrual.Name = "lblLastMenstrual"
        lblLastMenstrual.Size = New Size(142, 20)
        lblLastMenstrual.TabIndex = 12
        lblLastMenstrual.Text = "Last Menstrual:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Verdana", 10.2F)
        Label3.Location = New Point(6, 142)
        Label3.Name = "Label3"
        Label3.Size = New Size(126, 20)
        Label3.TabIndex = 11
        Label3.Text = "Assigned OB:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Verdana", 10.2F)
        Label8.Location = New Point(6, 108)
        Label8.Name = "Label8"
        Label8.Size = New Size(137, 20)
        Label8.TabIndex = 10
        Label8.Text = "Next Checkup:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Verdana", 10.2F)
        Label9.Location = New Point(6, 77)
        Label9.Name = "Label9"
        Label9.Size = New Size(153, 20)
        Label9.TabIndex = 9
        Label9.Text = "Gestational Age:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Verdana", 10.2F)
        Label10.Location = New Point(6, 44)
        Label10.Name = "Label10"
        Label10.Size = New Size(142, 20)
        Label10.TabIndex = 8
        Label10.Text = "Last Menstrual:"
        ' 
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BackColor = Color.Transparent
        HopeGroupBox1.BorderColor = Color.Transparent
        HopeGroupBox1.Controls.Add(Label17)
        HopeGroupBox1.Controls.Add(lblAddress)
        HopeGroupBox1.Controls.Add(lblFirstBaby)
        HopeGroupBox1.Controls.Add(lblCivilStatus)
        HopeGroupBox1.Controls.Add(lblAge)
        HopeGroupBox1.Controls.Add(lblName)
        HopeGroupBox1.Controls.Add(Label6)
        HopeGroupBox1.Controls.Add(Label5)
        HopeGroupBox1.Controls.Add(Label4)
        HopeGroupBox1.Controls.Add(Label2)
        HopeGroupBox1.Controls.Add(Label1)
        HopeGroupBox1.FlatStyle = FlatStyle.Flat
        HopeGroupBox1.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        HopeGroupBox1.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox1.LineColor = Color.Transparent
        HopeGroupBox1.Location = New Point(10, 13)
        HopeGroupBox1.Name = "HopeGroupBox1"
        HopeGroupBox1.ShowText = False
        HopeGroupBox1.Size = New Size(450, 250)
        HopeGroupBox1.TabIndex = 0
        HopeGroupBox1.TabStop = False
        HopeGroupBox1.Text = "HopeGroupBox1"
        HopeGroupBox1.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.Transparent
        Label17.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(0, 3)
        Label17.Name = "Label17"
        Label17.Size = New Size(287, 28)
        Label17.TabIndex = 14
        Label17.Text = "Personal Information"
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.Font = New Font("Verdana", 10.2F)
        lblAddress.Location = New Point(124, 177)
        lblAddress.MaximumSize = New Size(180, 0)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(86, 20)
        lblAddress.TabIndex = 13
        lblAddress.Text = "Address:"
        ' 
        ' lblFirstBaby
        ' 
        lblFirstBaby.AutoSize = True
        lblFirstBaby.Font = New Font("Verdana", 10.2F)
        lblFirstBaby.Location = New Point(124, 144)
        lblFirstBaby.Name = "lblFirstBaby"
        lblFirstBaby.Size = New Size(104, 20)
        lblFirstBaby.TabIndex = 12
        lblFirstBaby.Text = "First Baby:"
        ' 
        ' lblCivilStatus
        ' 
        lblCivilStatus.AutoSize = True
        lblCivilStatus.Font = New Font("Verdana", 10.2F)
        lblCivilStatus.Location = New Point(124, 110)
        lblCivilStatus.Name = "lblCivilStatus"
        lblCivilStatus.Size = New Size(116, 20)
        lblCivilStatus.TabIndex = 11
        lblCivilStatus.Text = "Civil Status:"
        ' 
        ' lblAge
        ' 
        lblAge.AutoSize = True
        lblAge.Font = New Font("Verdana", 10.2F)
        lblAge.Location = New Point(124, 77)
        lblAge.Name = "lblAge"
        lblAge.Size = New Size(50, 20)
        lblAge.TabIndex = 10
        lblAge.Text = "Age:"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Verdana", 10.2F)
        lblName.Location = New Point(124, 44)
        lblName.Name = "lblName"
        lblName.Size = New Size(67, 20)
        lblName.TabIndex = 9
        lblName.Text = "Name:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Verdana", 10.2F)
        Label6.Location = New Point(32, 177)
        Label6.Name = "Label6"
        Label6.Size = New Size(86, 20)
        Label6.TabIndex = 8
        Label6.Text = "Address:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Verdana", 10.2F)
        Label5.Location = New Point(18, 144)
        Label5.Name = "Label5"
        Label5.Size = New Size(104, 20)
        Label5.TabIndex = 7
        Label5.Text = "First Baby:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Verdana", 10.2F)
        Label4.Location = New Point(6, 110)
        Label4.Name = "Label4"
        Label4.Size = New Size(116, 20)
        Label4.TabIndex = 6
        Label4.Text = "Civil Status:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Verdana", 10.2F)
        Label2.Location = New Point(72, 77)
        Label2.Name = "Label2"
        Label2.Size = New Size(50, 20)
        Label2.TabIndex = 4
        Label2.Text = "Age:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 10.2F)
        Label1.Location = New Point(55, 44)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 20)
        Label1.TabIndex = 2
        Label1.Text = "Name:"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(Panel3)
        TabPage2.Location = New Point(4, 29)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(967, 554)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Appointments"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.BackgroundImage = My.Resources.Resources.bg_img
        Panel3.Controls.Add(dgvAppointments)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(Label14)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(3, 3)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(961, 548)
        Panel3.TabIndex = 0
        ' 
        ' dgvAppointments
        ' 
        dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAppointments.Location = New Point(13, 66)
        dgvAppointments.Name = "dgvAppointments"
        dgvAppointments.RowHeadersWidth = 51
        dgvAppointments.Size = New Size(933, 479)
        dgvAppointments.TabIndex = 15
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Verdana", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(13, 43)
        Label13.Name = "Label13"
        Label13.Size = New Size(297, 20)
        Label13.TabIndex = 14
        Label13.Text = "All appointments for Maria Garcia"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(13, 15)
        Label14.Name = "Label14"
        Label14.Size = New Size(191, 28)
        Label14.TabIndex = 13
        Label14.Text = "Appointments"
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(Panel4)
        TabPage3.Location = New Point(4, 29)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(967, 554)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Billings"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' Panel4
        ' 
        Panel4.BackgroundImage = My.Resources.Resources.bg_img
        Panel4.Controls.Add(dgvBilling)
        Panel4.Controls.Add(Label15)
        Panel4.Controls.Add(Label16)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(967, 554)
        Panel4.TabIndex = 0
        ' 
        ' dgvBilling
        ' 
        dgvBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBilling.Location = New Point(17, 71)
        dgvBilling.Name = "dgvBilling"
        dgvBilling.RowHeadersWidth = 51
        dgvBilling.Size = New Size(933, 479)
        dgvBilling.TabIndex = 17
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Verdana", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(17, 48)
        Label15.Name = "Label15"
        Label15.Size = New Size(300, 20)
        Label15.TabIndex = 16
        Label15.Text = "All billing records for Maria Garcia"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = Color.Transparent
        Label16.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(17, 20)
        Label16.Name = "Label16"
        Label16.Size = New Size(94, 28)
        Label16.TabIndex = 15
        Label16.Text = "Billing"
        ' 
        ' TabPage4
        ' 
        TabPage4.Controls.Add(Panel5)
        TabPage4.Location = New Point(4, 29)
        TabPage4.Name = "TabPage4"
        TabPage4.Padding = New Padding(3)
        TabPage4.Size = New Size(967, 554)
        TabPage4.TabIndex = 3
        TabPage4.Text = "Consultation Details"
        TabPage4.UseVisualStyleBackColor = True
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(dgvConsultationDetails)
        Panel5.Controls.Add(Label19)
        Panel5.Controls.Add(Label20)
        Panel5.Location = New Point(0, 0)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(967, 554)
        Panel5.TabIndex = 0
        ' 
        ' dgvConsultationDetails
        ' 
        dgvConsultationDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvConsultationDetails.Location = New Point(17, 63)
        dgvConsultationDetails.Name = "dgvConsultationDetails"
        dgvConsultationDetails.RowHeadersWidth = 51
        dgvConsultationDetails.Size = New Size(933, 479)
        dgvConsultationDetails.TabIndex = 20
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Verdana", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(17, 40)
        Label19.Name = "Label19"
        Label19.Size = New Size(346, 20)
        Label19.TabIndex = 19
        Label19.Text = "All consultation details for Maria Garcia"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.BackColor = Color.Transparent
        Label20.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.Location = New Point(17, 12)
        Label20.Name = "Label20"
        Label20.Size = New Size(246, 28)
        Label20.TabIndex = 18
        Label20.Text = "Consultaion Notes"
        ' 
        ' IconButton2
        ' 
        IconButton2.BackColor = Color.Transparent
        IconButton2.FlatAppearance.BorderColor = Color.Black
        IconButton2.FlatStyle = FlatStyle.Flat
        IconButton2.Font = New Font("Verdana", 12F)
        IconButton2.IconChar = FontAwesome.Sharp.IconChar.Pen
        IconButton2.IconColor = Color.Black
        IconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton2.IconSize = 25
        IconButton2.ImageAlign = ContentAlignment.MiddleLeft
        IconButton2.Location = New Point(896, 17)
        IconButton2.Name = "IconButton2"
        IconButton2.Size = New Size(88, 40)
        IconButton2.TabIndex = 6
        IconButton2.Text = "Edit"
        IconButton2.TextImageRelation = TextImageRelation.ImageBeforeText
        IconButton2.UseVisualStyleBackColor = False
        ' 
        ' IconButton1
        ' 
        IconButton1.BackColor = Color.Transparent
        IconButton1.FlatAppearance.BorderColor = Color.Black
        IconButton1.FlatStyle = FlatStyle.Flat
        IconButton1.Font = New Font("Verdana", 12F)
        IconButton1.IconChar = FontAwesome.Sharp.IconChar.Calendar
        IconButton1.IconColor = Color.Black
        IconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton1.IconSize = 25
        IconButton1.ImageAlign = ContentAlignment.MiddleLeft
        IconButton1.Location = New Point(611, 17)
        IconButton1.Name = "IconButton1"
        IconButton1.Size = New Size(279, 40)
        IconButton1.TabIndex = 5
        IconButton1.Text = "Schedule Appointment"
        IconButton1.TextImageRelation = TextImageRelation.ImageBeforeText
        IconButton1.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(12, 17)
        Label7.Name = "Label7"
        Label7.Size = New Size(251, 34)
        Label7.TabIndex = 4
        Label7.Text = "Patient Details"
        ' 
        ' PatientDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 700)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1020)
        MinimumSize = New Size(190, 40)
        Name = "PatientDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "PatientDetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        HopeGroupBox4.ResumeLayout(False)
        HopeGroupBox4.PerformLayout()
        HopeGroupBox2.ResumeLayout(False)
        HopeGroupBox2.PerformLayout()
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        TabPage2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(dgvAppointments, ComponentModel.ISupportInitialize).EndInit()
        TabPage3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(dgvBilling, ComponentModel.ISupportInitialize).EndInit()
        TabPage4.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(dgvConsultationDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents HopeGroupBox1 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents HopeGroupBox2 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents HopeGroupBox4 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents flowRecentAppointments As FlowLayoutPanel
    Friend WithEvents dgvAppointments As DataGridView
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dgvBilling As DataGridView
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblAssignedOB As Label
    Friend WithEvents lblNextCheckup As Label
    Friend WithEvents lblGestationalAge As Label
    Friend WithEvents lblLastMenstrual As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblFirstBaby As Label
    Friend WithEvents lblCivilStatus As Label
    Friend WithEvents lblAge As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Panel5 As Panel
    Friend WithEvents dgvConsultationDetails As DataGridView
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
End Class
