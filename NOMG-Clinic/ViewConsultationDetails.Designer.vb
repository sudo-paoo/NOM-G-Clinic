<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewConsultationDetails
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
        IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        HopeGroupBox2 = New ReaLTaiizor.Controls.HopeGroupBox()
        Label3 = New Label()
        Panel3 = New Panel()
        txtDoctorPlan = New TextBox()
        Label7 = New Label()
        txtVitaminIntake = New TextBox()
        hgbUrineAnalysis = New ReaLTaiizor.Controls.HopeGroupBox()
        rbBlood = New RadioButton()
        rbKetones = New RadioButton()
        rbGlucose = New RadioButton()
        rbProtein = New RadioButton()
        Label17 = New Label()
        Label20 = New Label()
        cmbVisitType = New ComboBox()
        txtDoctorAssessment = New TextBox()
        cmbReasonVisit = New ComboBox()
        Label19 = New Label()
        Label5 = New Label()
        Label18 = New Label()
        Label4 = New Label()
        Label10 = New Label()
        smlWeight = New ReaLTaiizor.Controls.SmallTextBox()
        txtFetalHeart = New TextBox()
        txtFundalHeight = New TextBox()
        smlTemperature = New ReaLTaiizor.Controls.SmallTextBox()
        Label16 = New Label()
        smlPulse = New ReaLTaiizor.Controls.SmallTextBox()
        Label15 = New Label()
        smlBloodPressure = New ReaLTaiizor.Controls.SmallTextBox()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
        Panel2 = New Panel()
        Label26 = New Label()
        lblPatientName = New Label()
        Label8 = New Label()
        Label6 = New Label()
        Label24 = New Label()
        lblDueDate = New Label()
        Label23 = New Label()
        lblPatientAge = New Label()
        Label22 = New Label()
        lblBloodType = New Label()
        Label21 = New Label()
        lblAllergies = New Label()
        Label2 = New Label()
        lblDate = New Label()
        Label1 = New Label()
        Panel1.SuspendLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        HopeGroupBox2.SuspendLayout()
        Panel3.SuspendLayout()
        hgbUrineAnalysis.SuspendLayout()
        HopeGroupBox1.SuspendLayout()
        Panel2.SuspendLayout()
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
        HopeForm1.Size = New Size(1200, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "View Consultation Details"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(247), CByte(124), CByte(161))
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = SystemColors.ControlLightLight
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(IconPictureBox1)
        Panel1.Controls.Add(HopeGroupBox2)
        Panel1.Controls.Add(HopeGroupBox1)
        Panel1.Controls.Add(lblDate)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1200, 660)
        Panel1.TabIndex = 3
        ' 
        ' IconPictureBox1
        ' 
        IconPictureBox1.BackColor = SystemColors.ControlLightLight
        IconPictureBox1.ForeColor = Color.FromArgb(CByte(247), CByte(124), CByte(161))
        IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Clipboard
        IconPictureBox1.IconColor = Color.FromArgb(CByte(247), CByte(124), CByte(161))
        IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconPictureBox1.IconSize = 24
        IconPictureBox1.Location = New Point(310, 30)
        IconPictureBox1.Name = "IconPictureBox1"
        IconPictureBox1.Size = New Size(24, 26)
        IconPictureBox1.TabIndex = 8
        IconPictureBox1.TabStop = False
        ' 
        ' HopeGroupBox2
        ' 
        HopeGroupBox2.BackColor = SystemColors.ControlLightLight
        HopeGroupBox2.BorderColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        HopeGroupBox2.Controls.Add(Label3)
        HopeGroupBox2.Controls.Add(Panel3)
        HopeGroupBox2.Font = New Font("Segoe UI", 12F)
        HopeGroupBox2.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox2.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox2.Location = New Point(39, 404)
        HopeGroupBox2.Name = "HopeGroupBox2"
        HopeGroupBox2.ShowText = False
        HopeGroupBox2.Size = New Size(1100, 1253)
        HopeGroupBox2.TabIndex = 3
        HopeGroupBox2.TabStop = False
        HopeGroupBox2.Text = "HopeGroupBox2"
        HopeGroupBox2.ThemeColor = Color.FromArgb(CByte(247), CByte(124), CByte(161))
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(491, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(101, 28)
        Label3.TabIndex = 12
        Label3.Text = "Details"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(txtDoctorPlan)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(txtVitaminIntake)
        Panel3.Controls.Add(hgbUrineAnalysis)
        Panel3.Controls.Add(Label20)
        Panel3.Controls.Add(cmbVisitType)
        Panel3.Controls.Add(txtDoctorAssessment)
        Panel3.Controls.Add(cmbReasonVisit)
        Panel3.Controls.Add(Label19)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(Label18)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(smlWeight)
        Panel3.Controls.Add(txtFetalHeart)
        Panel3.Controls.Add(txtFundalHeight)
        Panel3.Controls.Add(smlTemperature)
        Panel3.Controls.Add(Label16)
        Panel3.Controls.Add(smlPulse)
        Panel3.Controls.Add(Label15)
        Panel3.Controls.Add(smlBloodPressure)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(Label12)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(Label14)
        Panel3.Location = New Point(3, 50)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1100, 1208)
        Panel3.TabIndex = 45
        ' 
        ' txtDoctorPlan
        ' 
        txtDoctorPlan.BorderStyle = BorderStyle.FixedSingle
        txtDoctorPlan.Location = New Point(25, 795)
        txtDoctorPlan.Multiline = True
        txtDoctorPlan.Name = "txtDoctorPlan"
        txtDoctorPlan.Size = New Size(1050, 167)
        txtDoctorPlan.TabIndex = 39
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(447, 976)
        Label7.Name = "Label7"
        Label7.Size = New Size(203, 28)
        Label7.TabIndex = 46
        Label7.Text = "Vitamin Intake"
        ' 
        ' txtVitaminIntake
        ' 
        txtVitaminIntake.BorderStyle = BorderStyle.FixedSingle
        txtVitaminIntake.Location = New Point(34, 1018)
        txtVitaminIntake.Multiline = True
        txtVitaminIntake.Name = "txtVitaminIntake"
        txtVitaminIntake.Size = New Size(1050, 167)
        txtVitaminIntake.TabIndex = 45
        ' 
        ' hgbUrineAnalysis
        ' 
        hgbUrineAnalysis.BackColor = Color.Transparent
        hgbUrineAnalysis.BorderColor = Color.Transparent
        hgbUrineAnalysis.Controls.Add(rbBlood)
        hgbUrineAnalysis.Controls.Add(rbKetones)
        hgbUrineAnalysis.Controls.Add(rbGlucose)
        hgbUrineAnalysis.Controls.Add(rbProtein)
        hgbUrineAnalysis.Controls.Add(Label17)
        hgbUrineAnalysis.Font = New Font("Segoe UI", 12F)
        hgbUrineAnalysis.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        hgbUrineAnalysis.LineColor = Color.Transparent
        hgbUrineAnalysis.Location = New Point(226, 398)
        hgbUrineAnalysis.Name = "hgbUrineAnalysis"
        hgbUrineAnalysis.ShowText = False
        hgbUrineAnalysis.Size = New Size(670, 82)
        hgbUrineAnalysis.TabIndex = 42
        hgbUrineAnalysis.TabStop = False
        hgbUrineAnalysis.Text = "HopeGroupBox3"
        hgbUrineAnalysis.ThemeColor = Color.Transparent
        ' 
        ' rbBlood
        ' 
        rbBlood.AutoSize = True
        rbBlood.BackColor = Color.Transparent
        rbBlood.Location = New Point(579, 40)
        rbBlood.Name = "rbBlood"
        rbBlood.Size = New Size(85, 32)
        rbBlood.TabIndex = 34
        rbBlood.TabStop = True
        rbBlood.Text = "Blood"
        rbBlood.UseVisualStyleBackColor = False
        ' 
        ' rbKetones
        ' 
        rbKetones.AutoSize = True
        rbKetones.BackColor = Color.Transparent
        rbKetones.Location = New Point(387, 40)
        rbKetones.Name = "rbKetones"
        rbKetones.Size = New Size(103, 32)
        rbKetones.TabIndex = 33
        rbKetones.TabStop = True
        rbKetones.Text = "Ketones"
        rbKetones.UseVisualStyleBackColor = False
        ' 
        ' rbGlucose
        ' 
        rbGlucose.AutoSize = True
        rbGlucose.BackColor = Color.Transparent
        rbGlucose.Location = New Point(187, 40)
        rbGlucose.Name = "rbGlucose"
        rbGlucose.Size = New Size(102, 32)
        rbGlucose.TabIndex = 32
        rbGlucose.TabStop = True
        rbGlucose.Text = "Glucose"
        rbGlucose.UseVisualStyleBackColor = False
        ' 
        ' rbProtein
        ' 
        rbProtein.AutoSize = True
        rbProtein.BackColor = Color.Transparent
        rbProtein.Location = New Point(7, 40)
        rbProtein.Name = "rbProtein"
        rbProtein.Size = New Size(96, 32)
        rbProtein.TabIndex = 31
        rbProtein.TabStop = True
        rbProtein.Text = "Protein"
        rbProtein.UseVisualStyleBackColor = False
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.Transparent
        Label17.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.Black
        Label17.Location = New Point(243, 0)
        Label17.Name = "Label17"
        Label17.Size = New Size(167, 31)
        Label17.TabIndex = 30
        Label17.Text = "Urine Analysis"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.BackColor = Color.Transparent
        Label20.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.ForeColor = Color.Black
        Label20.Location = New Point(511, 753)
        Label20.Name = "Label20"
        Label20.Size = New Size(68, 28)
        Label20.TabIndex = 38
        Label20.Text = "Plan"
        ' 
        ' cmbVisitType
        ' 
        cmbVisitType.FormattingEnabled = True
        cmbVisitType.Location = New Point(89, 57)
        cmbVisitType.Name = "cmbVisitType"
        cmbVisitType.Size = New Size(362, 36)
        cmbVisitType.TabIndex = 43
        ' 
        ' txtDoctorAssessment
        ' 
        txtDoctorAssessment.BorderStyle = BorderStyle.FixedSingle
        txtDoctorAssessment.Location = New Point(25, 572)
        txtDoctorAssessment.Multiline = True
        txtDoctorAssessment.Name = "txtDoctorAssessment"
        txtDoctorAssessment.Size = New Size(1050, 167)
        txtDoctorAssessment.TabIndex = 37
        ' 
        ' cmbReasonVisit
        ' 
        cmbReasonVisit.FormattingEnabled = True
        cmbReasonVisit.Location = New Point(660, 57)
        cmbReasonVisit.Name = "cmbReasonVisit"
        cmbReasonVisit.Size = New Size(362, 36)
        cmbReasonVisit.TabIndex = 44
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.BackColor = Color.Transparent
        Label19.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = Color.Black
        Label19.Location = New Point(481, 536)
        Label19.Name = "Label19"
        Label19.Size = New Size(132, 22)
        Label19.TabIndex = 36
        Label19.Text = "Assessment"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold)
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(774, 29)
        Label5.Name = "Label5"
        Label5.Size = New Size(143, 25)
        Label5.TabIndex = 13
        Label5.Text = "Reason for Visit"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = Color.Black
        Label18.Location = New Point(448, 493)
        Label18.Name = "Label18"
        Label18.Size = New Size(188, 28)
        Label18.TabIndex = 35
        Label18.Text = "Doctor's Note"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold)
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(215, 29)
        Label4.Name = "Label4"
        Label4.Size = New Size(93, 25)
        Label4.TabIndex = 12
        Label4.Text = "Visit Type"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.Black
        Label10.Location = New Point(475, 128)
        Label10.Name = "Label10"
        Label10.Size = New Size(161, 31)
        Label10.TabIndex = 16
        Label10.Text = "Current Vitals"
        ' 
        ' smlWeight
        ' 
        smlWeight.BackColor = Color.Transparent
        smlWeight.BorderColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        smlWeight.CustomBGColor = Color.White
        smlWeight.Font = New Font("Tahoma", 11F)
        smlWeight.ForeColor = Color.DimGray
        smlWeight.Location = New Point(660, 276)
        smlWeight.MaxLength = 32767
        smlWeight.Multiline = False
        smlWeight.Name = "smlWeight"
        smlWeight.ReadOnly = False
        smlWeight.Size = New Size(362, 33)
        smlWeight.SmoothingType = Drawing2D.SmoothingMode.AntiAlias
        smlWeight.TabIndex = 25
        smlWeight.TextAlignment = HorizontalAlignment.Left
        smlWeight.UseSystemPasswordChar = False
        ' 
        ' txtFetalHeart
        ' 
        txtFetalHeart.Location = New Point(660, 342)
        txtFetalHeart.Name = "txtFetalHeart"
        txtFetalHeart.Size = New Size(362, 34)
        txtFetalHeart.TabIndex = 29
        ' 
        ' txtFundalHeight
        ' 
        txtFundalHeight.Font = New Font("Tahoma", 11F)
        txtFundalHeight.ForeColor = Color.DimGray
        txtFundalHeight.Location = New Point(88, 347)
        txtFundalHeight.Name = "txtFundalHeight"
        txtFundalHeight.Size = New Size(363, 30)
        txtFundalHeight.TabIndex = 26
        ' 
        ' smlTemperature
        ' 
        smlTemperature.BackColor = Color.Transparent
        smlTemperature.BorderColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        smlTemperature.CustomBGColor = Color.White
        smlTemperature.Font = New Font("Tahoma", 11F)
        smlTemperature.ForeColor = Color.DimGray
        smlTemperature.Location = New Point(660, 210)
        smlTemperature.MaxLength = 32767
        smlTemperature.Multiline = False
        smlTemperature.Name = "smlTemperature"
        smlTemperature.ReadOnly = False
        smlTemperature.Size = New Size(362, 33)
        smlTemperature.SmoothingType = Drawing2D.SmoothingMode.AntiAlias
        smlTemperature.TabIndex = 24
        smlTemperature.TextAlignment = HorizontalAlignment.Left
        smlTemperature.UseSystemPasswordChar = False
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = Color.Transparent
        Label16.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold)
        Label16.ForeColor = Color.Black
        Label16.Location = New Point(660, 313)
        Label16.Name = "Label16"
        Label16.Size = New Size(201, 25)
        Label16.TabIndex = 28
        Label16.Text = "Fetal Heart Rate (bpm)"
        ' 
        ' smlPulse
        ' 
        smlPulse.BackColor = Color.Transparent
        smlPulse.BorderColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        smlPulse.CustomBGColor = Color.White
        smlPulse.Font = New Font("Tahoma", 11F)
        smlPulse.ForeColor = Color.DimGray
        smlPulse.Location = New Point(88, 279)
        smlPulse.MaxLength = 32767
        smlPulse.Multiline = False
        smlPulse.Name = "smlPulse"
        smlPulse.ReadOnly = False
        smlPulse.Size = New Size(363, 33)
        smlPulse.SmoothingType = Drawing2D.SmoothingMode.AntiAlias
        smlPulse.TabIndex = 23
        smlPulse.TextAlignment = HorizontalAlignment.Left
        smlPulse.UseSystemPasswordChar = False
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.Transparent
        Label15.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold)
        Label15.ForeColor = Color.Black
        Label15.Location = New Point(88, 317)
        Label15.Name = "Label15"
        Label15.Size = New Size(129, 25)
        Label15.TabIndex = 26
        Label15.Text = "Fundal Height"
        ' 
        ' smlBloodPressure
        ' 
        smlBloodPressure.BackColor = Color.Transparent
        smlBloodPressure.BorderColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        smlBloodPressure.CustomBGColor = Color.White
        smlBloodPressure.Font = New Font("Tahoma", 11F)
        smlBloodPressure.ForeColor = Color.DimGray
        smlBloodPressure.Location = New Point(89, 211)
        smlBloodPressure.MaxLength = 32767
        smlBloodPressure.Multiline = False
        smlBloodPressure.Name = "smlBloodPressure"
        smlBloodPressure.ReadOnly = False
        smlBloodPressure.Size = New Size(362, 33)
        smlBloodPressure.SmoothingType = Drawing2D.SmoothingMode.AntiAlias
        smlBloodPressure.TabIndex = 22
        smlBloodPressure.TextAlignment = HorizontalAlignment.Left
        smlBloodPressure.UseSystemPasswordChar = False
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold)
        Label11.ForeColor = Color.Black
        Label11.Location = New Point(89, 181)
        Label11.Name = "Label11"
        Label11.Size = New Size(138, 25)
        Label11.TabIndex = 17
        Label11.Text = "Blood Pressure"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold)
        Label12.ForeColor = Color.Black
        Label12.Location = New Point(88, 249)
        Label12.Name = "Label12"
        Label12.Size = New Size(112, 25)
        Label12.TabIndex = 18
        Label12.Text = "Pulse (bpm)"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold)
        Label13.ForeColor = Color.Black
        Label13.Location = New Point(660, 181)
        Label13.Name = "Label13"
        Label13.Size = New Size(118, 25)
        Label13.TabIndex = 19
        Label13.Text = "Temperature"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold)
        Label14.ForeColor = Color.Black
        Label14.Location = New Point(660, 247)
        Label14.Name = "Label14"
        Label14.Size = New Size(109, 25)
        Label14.TabIndex = 20
        Label14.Text = "Weight (kg)"
        ' 
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BackColor = Color.Transparent
        HopeGroupBox1.BackgroundImageLayout = ImageLayout.Center
        HopeGroupBox1.BorderColor = Color.Gray
        HopeGroupBox1.Controls.Add(Panel2)
        HopeGroupBox1.Controls.Add(Label2)
        HopeGroupBox1.FlatStyle = FlatStyle.Popup
        HopeGroupBox1.Font = New Font("Segoe UI", 12F)
        HopeGroupBox1.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox1.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Location = New Point(39, 96)
        HopeGroupBox1.Name = "HopeGroupBox1"
        HopeGroupBox1.ShowText = False
        HopeGroupBox1.Size = New Size(1100, 295)
        HopeGroupBox1.TabIndex = 2
        HopeGroupBox1.TabStop = False
        HopeGroupBox1.Text = "HopeGroupBox1"
        HopeGroupBox1.ThemeColor = Color.FromArgb(CByte(247), CByte(124), CByte(161))
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ControlLightLight
        Panel2.Controls.Add(Label26)
        Panel2.Controls.Add(lblPatientName)
        Panel2.Controls.Add(Label8)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(Label24)
        Panel2.Controls.Add(lblDueDate)
        Panel2.Controls.Add(Label23)
        Panel2.Controls.Add(lblPatientAge)
        Panel2.Controls.Add(Label22)
        Panel2.Controls.Add(lblBloodType)
        Panel2.Controls.Add(Label21)
        Panel2.Controls.Add(lblAllergies)
        Panel2.Location = New Point(0, 53)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1100, 249)
        Panel2.TabIndex = 1
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Location = New Point(705, 84)
        Label26.Name = "Label26"
        Label26.Size = New Size(78, 28)
        Label26.TabIndex = 33
        Label26.Text = "Allergy:"
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.BackColor = SystemColors.ControlLightLight
        lblPatientName.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatientName.ForeColor = Color.Black
        lblPatientName.Location = New Point(102, 40)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.Size = New Size(68, 28)
        lblPatientName.TabIndex = 20
        lblPatientName.Text = "NAME"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(705, 40)
        Label8.Name = "Label8"
        Label8.Size = New Size(51, 28)
        Label8.TabIndex = 31
        Label8.Text = "Age:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(186, 84)
        Label6.Name = "Label6"
        Label6.Size = New Size(156, 28)
        Label6.TabIndex = 22
        Label6.Text = "Gestational Age"
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Location = New Point(28, 172)
        Label24.Name = "Label24"
        Label24.Size = New Size(114, 28)
        Label24.TabIndex = 30
        Label24.Text = "Blood Type:"
        ' 
        ' lblDueDate
        ' 
        lblDueDate.AutoSize = True
        lblDueDate.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDueDate.ForeColor = Color.Black
        lblDueDate.Location = New Point(144, 132)
        lblDueDate.Name = "lblDueDate"
        lblDueDate.Size = New Size(142, 28)
        lblDueDate.TabIndex = 24
        lblDueDate.Text = "Date of Preg..."
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Location = New Point(28, 128)
        Label23.Name = "Label23"
        Label23.Size = New Size(97, 28)
        Label23.TabIndex = 29
        Label23.Text = "Due Date:"
        ' 
        ' lblPatientAge
        ' 
        lblPatientAge.AutoSize = True
        lblPatientAge.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatientAge.ForeColor = Color.Black
        lblPatientAge.Location = New Point(762, 40)
        lblPatientAge.Name = "lblPatientAge"
        lblPatientAge.Size = New Size(49, 28)
        lblPatientAge.TabIndex = 21
        lblPatientAge.Text = "AGE"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(28, 84)
        Label22.Name = "Label22"
        Label22.Size = New Size(155, 28)
        Label22.TabIndex = 28
        Label22.Text = "Gestational Age:"
        ' 
        ' lblBloodType
        ' 
        lblBloodType.AutoSize = True
        lblBloodType.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblBloodType.ForeColor = Color.Black
        lblBloodType.Location = New Point(148, 172)
        lblBloodType.Name = "lblBloodType"
        lblBloodType.Size = New Size(55, 28)
        lblBloodType.TabIndex = 25
        lblBloodType.Text = "Type"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(28, 40)
        Label21.Name = "Label21"
        Label21.Size = New Size(68, 28)
        Label21.TabIndex = 27
        Label21.Text = "Name:"
        ' 
        ' lblAllergies
        ' 
        lblAllergies.AutoSize = True
        lblAllergies.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAllergies.ForeColor = Color.Black
        lblAllergies.Location = New Point(789, 84)
        lblAllergies.Name = "lblAllergies"
        lblAllergies.Size = New Size(87, 28)
        lblAllergies.TabIndex = 26
        lblAllergies.Text = "Seafood"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(407, 11)
        Label2.Name = "Label2"
        Label2.Size = New Size(277, 38)
        Label2.TabIndex = 0
        Label2.Text = "Patient Information"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.BackColor = Color.Transparent
        lblDate.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDate.Location = New Point(42, 53)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(116, 28)
        lblDate.TabIndex = 1
        lblDate.Text = "DATE & TIME"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(35, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(269, 38)
        Label1.TabIndex = 0
        Label1.Text = "Consultation Notes"
        ' 
        ' ViewConsultationDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 700)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(190, 40)
        Name = "ViewConsultationDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ViewConsultationDetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(IconPictureBox1, ComponentModel.ISupportInitialize).EndInit()
        HopeGroupBox2.ResumeLayout(False)
        HopeGroupBox2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        hgbUrineAnalysis.ResumeLayout(False)
        hgbUrineAnalysis.PerformLayout()
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents HopeGroupBox2 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtDoctorPlan As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtVitaminIntake As TextBox
    Friend WithEvents hgbUrineAnalysis As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents rbBlood As RadioButton
    Friend WithEvents rbKetones As RadioButton
    Friend WithEvents rbGlucose As RadioButton
    Friend WithEvents rbProtein As RadioButton
    Friend WithEvents Label17 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbVisitType As ComboBox
    Friend WithEvents txtDoctorAssessment As TextBox
    Friend WithEvents cmbReasonVisit As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents smlWeight As ReaLTaiizor.Controls.SmallTextBox
    Friend WithEvents txtFetalHeart As TextBox
    Friend WithEvents txtFundalHeight As TextBox
    Friend WithEvents smlTemperature As ReaLTaiizor.Controls.SmallTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents smlPulse As ReaLTaiizor.Controls.SmallTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents smlBloodPressure As ReaLTaiizor.Controls.SmallTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents HopeGroupBox1 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label26 As Label
    Friend WithEvents lblPatientName As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblDueDate As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblPatientAge As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents lblBloodType As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblAllergies As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents Label1 As Label
End Class
