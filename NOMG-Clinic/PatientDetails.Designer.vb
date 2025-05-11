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
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        Panel2 = New Panel()
        HopeGroupBox4 = New ReaLTaiizor.Controls.HopeGroupBox()
        Panel8 = New Panel()
        Label18 = New Label()
        flowRecentAppointments = New FlowLayoutPanel()
        Label12 = New Label()
        HopeGroupBox2 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblHsFluVac = New Label()
        Label15 = New Label()
        Panel7 = New Panel()
        Label21 = New Label()
        lblAssignedOB = New Label()
        lblNextCheckup = New Label()
        lblGestationalAge = New Label()
        lblLastMenstrual = New Label()
        Label3 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
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
        Panel6 = New Panel()
        Label17 = New Label()
        TabPage2 = New TabPage()
        Panel3 = New Panel()
        dgvAppointments = New DataGridView()
        lblAppointments = New Label()
        Label14 = New Label()
        TabPage3 = New TabPage()
        Panel4 = New Panel()
        dgvBillings = New DataGridView()
        lblBillings = New Label()
        Label16 = New Label()
        TabPage4 = New TabPage()
        Panel5 = New Panel()
        dgvConsultationDetails = New DataGridView()
        lblConsultationDetails = New Label()
        Label13 = New Label()
        Label7 = New Label()
        Panel1.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        Panel2.SuspendLayout()
        HopeGroupBox4.SuspendLayout()
        Panel8.SuspendLayout()
        HopeGroupBox2.SuspendLayout()
        Panel7.SuspendLayout()
        HopeGroupBox1.SuspendLayout()
        Panel6.SuspendLayout()
        TabPage2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvAppointments, ComponentModel.ISupportInitialize).BeginInit()
        TabPage3.SuspendLayout()
        Panel4.SuspendLayout()
        CType(dgvBillings, ComponentModel.ISupportInitialize).BeginInit()
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
        HopeForm1.Image = My.Resources.Resources.icon
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
        Panel1.BackColor = SystemColors.ControlLightLight
        Panel1.Controls.Add(TabControl1)
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
        HopeGroupBox4.Controls.Add(Panel8)
        HopeGroupBox4.Controls.Add(flowRecentAppointments)
        HopeGroupBox4.Controls.Add(Label12)
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
        HopeGroupBox4.ThemeColor = SystemColors.ControlLightLight
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(247), CByte(124), CByte(161))
        Panel8.Controls.Add(Label18)
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(942, 41)
        Panel8.TabIndex = 16
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(328, 7)
        Label18.Name = "Label18"
        Label18.Size = New Size(287, 28)
        Label18.TabIndex = 14
        Label18.Text = "Recent Appointments"
        ' 
        ' flowRecentAppointments
        ' 
        flowRecentAppointments.AutoScroll = True
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
        ' HopeGroupBox2
        ' 
        HopeGroupBox2.BackColor = Color.Transparent
        HopeGroupBox2.BorderColor = Color.Transparent
        HopeGroupBox2.Controls.Add(lblHsFluVac)
        HopeGroupBox2.Controls.Add(Label15)
        HopeGroupBox2.Controls.Add(Panel7)
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
        HopeGroupBox2.ThemeColor = SystemColors.ControlLightLight
        ' 
        ' lblHsFluVac
        ' 
        lblHsFluVac.AutoSize = True
        lblHsFluVac.Font = New Font("Verdana", 10.2F)
        lblHsFluVac.Location = New Point(126, 216)
        lblHsFluVac.Name = "lblHsFluVac"
        lblHsFluVac.Size = New Size(126, 20)
        lblHsFluVac.TabIndex = 18
        lblHsFluVac.Text = "Assigned OB:"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Verdana", 10.2F)
        Label15.Location = New Point(6, 216)
        Label15.Name = "Label15"
        Label15.Size = New Size(114, 20)
        Label15.TabIndex = 17
        Label15.Text = "Flu Vaccine:"
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.FromArgb(CByte(247), CByte(124), CByte(161))
        Panel7.Controls.Add(Label21)
        Panel7.Location = New Point(0, 0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(450, 41)
        Panel7.TabIndex = 16
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.BackColor = Color.Transparent
        Label21.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label21.Location = New Point(74, 5)
        Label21.Name = "Label21"
        Label21.Size = New Size(310, 28)
        Label21.TabIndex = 14
        Label21.Text = "Pregnancy Information"
        ' 
        ' lblAssignedOB
        ' 
        lblAssignedOB.AutoSize = True
        lblAssignedOB.Font = New Font("Verdana", 10.2F)
        lblAssignedOB.Location = New Point(139, 176)
        lblAssignedOB.Name = "lblAssignedOB"
        lblAssignedOB.Size = New Size(126, 20)
        lblAssignedOB.TabIndex = 15
        lblAssignedOB.Text = "Assigned OB:"
        ' 
        ' lblNextCheckup
        ' 
        lblNextCheckup.AutoSize = True
        lblNextCheckup.Font = New Font("Verdana", 10.2F)
        lblNextCheckup.Location = New Point(152, 136)
        lblNextCheckup.Name = "lblNextCheckup"
        lblNextCheckup.Size = New Size(137, 20)
        lblNextCheckup.TabIndex = 14
        lblNextCheckup.Text = "Next Checkup:"
        ' 
        ' lblGestationalAge
        ' 
        lblGestationalAge.AutoSize = True
        lblGestationalAge.Font = New Font("Verdana", 10.2F)
        lblGestationalAge.Location = New Point(165, 96)
        lblGestationalAge.Name = "lblGestationalAge"
        lblGestationalAge.Size = New Size(153, 20)
        lblGestationalAge.TabIndex = 13
        lblGestationalAge.Text = "Gestational Age:"
        ' 
        ' lblLastMenstrual
        ' 
        lblLastMenstrual.AutoSize = True
        lblLastMenstrual.Font = New Font("Verdana", 10.2F)
        lblLastMenstrual.Location = New Point(154, 56)
        lblLastMenstrual.Name = "lblLastMenstrual"
        lblLastMenstrual.Size = New Size(142, 20)
        lblLastMenstrual.TabIndex = 12
        lblLastMenstrual.Text = "Last Menstrual:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Verdana", 10.2F)
        Label3.Location = New Point(6, 176)
        Label3.Name = "Label3"
        Label3.Size = New Size(126, 20)
        Label3.TabIndex = 11
        Label3.Text = "Assigned OB:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Verdana", 10.2F)
        Label8.Location = New Point(6, 136)
        Label8.Name = "Label8"
        Label8.Size = New Size(137, 20)
        Label8.TabIndex = 10
        Label8.Text = "Next Checkup:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Verdana", 10.2F)
        Label9.Location = New Point(6, 96)
        Label9.Name = "Label9"
        Label9.Size = New Size(153, 20)
        Label9.TabIndex = 9
        Label9.Text = "Gestational Age:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Verdana", 10.2F)
        Label10.Location = New Point(6, 56)
        Label10.Name = "Label10"
        Label10.Size = New Size(142, 20)
        Label10.TabIndex = 8
        Label10.Text = "Last Menstrual:"
        ' 
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BackColor = Color.Transparent
        HopeGroupBox1.BorderColor = Color.Transparent
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
        HopeGroupBox1.Controls.Add(Panel6)
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
        HopeGroupBox1.ThemeColor = SystemColors.ControlLightLight
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.Font = New Font("Verdana", 10.2F)
        lblAddress.Location = New Point(93, 212)
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
        lblFirstBaby.Location = New Point(116, 173)
        lblFirstBaby.Name = "lblFirstBaby"
        lblFirstBaby.Size = New Size(104, 20)
        lblFirstBaby.TabIndex = 12
        lblFirstBaby.Text = "First Baby:"
        ' 
        ' lblCivilStatus
        ' 
        lblCivilStatus.AutoSize = True
        lblCivilStatus.Font = New Font("Verdana", 10.2F)
        lblCivilStatus.Location = New Point(122, 134)
        lblCivilStatus.Name = "lblCivilStatus"
        lblCivilStatus.Size = New Size(116, 20)
        lblCivilStatus.TabIndex = 11
        lblCivilStatus.Text = "Civil Status:"
        ' 
        ' lblAge
        ' 
        lblAge.AutoSize = True
        lblAge.Font = New Font("Verdana", 10.2F)
        lblAge.Location = New Point(60, 95)
        lblAge.Name = "lblAge"
        lblAge.Size = New Size(50, 20)
        lblAge.TabIndex = 10
        lblAge.Text = "Age:"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Verdana", 10.2F)
        lblName.Location = New Point(79, 56)
        lblName.Name = "lblName"
        lblName.Size = New Size(67, 20)
        lblName.TabIndex = 9
        lblName.Text = "Name:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Verdana", 10.2F)
        Label6.Location = New Point(6, 212)
        Label6.Name = "Label6"
        Label6.Size = New Size(86, 20)
        Label6.TabIndex = 8
        Label6.Text = "Address:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Verdana", 10.2F)
        Label5.Location = New Point(6, 173)
        Label5.Name = "Label5"
        Label5.Size = New Size(104, 20)
        Label5.TabIndex = 7
        Label5.Text = "First Baby:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Verdana", 10.2F)
        Label4.Location = New Point(6, 134)
        Label4.Name = "Label4"
        Label4.Size = New Size(116, 20)
        Label4.TabIndex = 6
        Label4.Text = "Civil Status:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Verdana", 10.2F)
        Label2.Location = New Point(6, 95)
        Label2.Name = "Label2"
        Label2.Size = New Size(50, 20)
        Label2.TabIndex = 4
        Label2.Text = "Age:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 10.2F)
        Label1.Location = New Point(6, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 20)
        Label1.TabIndex = 2
        Label1.Text = "Name:"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.FromArgb(CByte(247), CByte(124), CByte(161))
        Panel6.Controls.Add(Label17)
        Panel6.Location = New Point(0, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(450, 41)
        Panel6.TabIndex = 15
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.Transparent
        Label17.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(74, 5)
        Label17.Name = "Label17"
        Label17.Size = New Size(287, 28)
        Label17.TabIndex = 14
        Label17.Text = "Personal Information"
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
        Panel3.Controls.Add(lblAppointments)
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
        ' lblAppointments
        ' 
        lblAppointments.AutoSize = True
        lblAppointments.Font = New Font("Verdana", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblAppointments.Location = New Point(13, 43)
        lblAppointments.Name = "lblAppointments"
        lblAppointments.Size = New Size(297, 20)
        lblAppointments.TabIndex = 14
        lblAppointments.Text = "All appointments for Maria Garcia"
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
        Panel4.Controls.Add(dgvBillings)
        Panel4.Controls.Add(lblBillings)
        Panel4.Controls.Add(Label16)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(967, 554)
        Panel4.TabIndex = 0
        ' 
        ' dgvBillings
        ' 
        dgvBillings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBillings.Location = New Point(17, 71)
        dgvBillings.Name = "dgvBillings"
        dgvBillings.RowHeadersWidth = 51
        dgvBillings.Size = New Size(933, 479)
        dgvBillings.TabIndex = 17
        ' 
        ' lblBillings
        ' 
        lblBillings.AutoSize = True
        lblBillings.Font = New Font("Verdana", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblBillings.Location = New Point(17, 48)
        lblBillings.Name = "lblBillings"
        lblBillings.Size = New Size(300, 20)
        lblBillings.TabIndex = 16
        lblBillings.Text = "All billing records for Maria Garcia"
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
        Panel5.BackgroundImage = My.Resources.Resources.bg_img
        Panel5.Controls.Add(dgvConsultationDetails)
        Panel5.Controls.Add(lblConsultationDetails)
        Panel5.Controls.Add(Label13)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(3, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(961, 548)
        Panel5.TabIndex = 1
        ' 
        ' dgvConsultationDetails
        ' 
        dgvConsultationDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvConsultationDetails.Location = New Point(17, 71)
        dgvConsultationDetails.Name = "dgvConsultationDetails"
        dgvConsultationDetails.RowHeadersWidth = 51
        dgvConsultationDetails.Size = New Size(933, 479)
        dgvConsultationDetails.TabIndex = 17
        ' 
        ' lblConsultationDetails
        ' 
        lblConsultationDetails.AutoSize = True
        lblConsultationDetails.Font = New Font("Verdana", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblConsultationDetails.Location = New Point(17, 48)
        lblConsultationDetails.Name = "lblConsultationDetails"
        lblConsultationDetails.Size = New Size(300, 20)
        lblConsultationDetails.TabIndex = 16
        lblConsultationDetails.Text = "All billing records for Maria Garcia"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(17, 20)
        Label13.Name = "Label13"
        Label13.Size = New Size(271, 28)
        Label13.TabIndex = 15
        Label13.Text = "Consultation Details"
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
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        HopeGroupBox2.ResumeLayout(False)
        HopeGroupBox2.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        TabPage2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(dgvAppointments, ComponentModel.ISupportInitialize).EndInit()
        TabPage3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(dgvBillings, ComponentModel.ISupportInitialize).EndInit()
        TabPage4.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(dgvConsultationDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
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
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents flowRecentAppointments As FlowLayoutPanel
    Friend WithEvents dgvAppointments As DataGridView
    Friend WithEvents lblAppointments As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dgvBillings As DataGridView
    Friend WithEvents lblBillings As Label
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
    Friend WithEvents Label17 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label21 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents dgvConsultationDetails As DataGridView
    Friend WithEvents lblConsultationDetails As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblHsFluVac As Label
    Friend WithEvents Label15 As Label
End Class
