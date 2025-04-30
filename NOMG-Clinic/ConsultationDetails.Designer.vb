<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultationDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultationDetails))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        Button2 = New Button()
        Button1 = New Button()
        HopeGroupBox2 = New ReaLTaiizor.Controls.HopeGroupBox()
        txtDoctorPlan = New TextBox()
        Label20 = New Label()
        txtDoctorAssessment = New TextBox()
        Label19 = New Label()
        Label18 = New Label()
        rbBlood = New RadioButton()
        rbKetones = New RadioButton()
        rbGlucose = New RadioButton()
        rbProtein = New RadioButton()
        Label17 = New Label()
        txtFetalHeart = New TextBox()
        Label16 = New Label()
        Me.txtFundalHeight = New TextBox()
        Label15 = New Label()
        smlWeight = New ReaLTaiizor.Controls.SmallTextBox()
        smlTemperature = New ReaLTaiizor.Controls.SmallTextBox()
        smlPulse = New ReaLTaiizor.Controls.SmallTextBox()
        smlBloodPressure = New ReaLTaiizor.Controls.SmallTextBox()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        Label10 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblAllergies = New Label()
        lblBloodType = New Label()
        lblDueDate = New Label()
        lblGestationalAge = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        lblTypeOfPatient = New Label()
        lblPatientAge = New Label()
        lblPatientName = New Label()
        Label2 = New Label()
        lblDate = New Label()
        Label1 = New Label()
        cmbReasonVisit = New ReaLTaiizor.Controls.HopeComboBox()
        cmbVisitType = New ReaLTaiizor.Controls.HopeComboBox()
        hgbUrineAnalysis = New ReaLTaiizor.Controls.HopeGroupBox()
        Panel1.SuspendLayout()
        HopeGroupBox2.SuspendLayout()
        HopeGroupBox1.SuspendLayout()
        hgbUrineAnalysis.SuspendLayout()
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
        HopeForm1.Text = "Consultation Summary"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackgroundImage = My.Resources.Resources.bg_img
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(HopeGroupBox2)
        Panel1.Controls.Add(HopeGroupBox1)
        Panel1.Controls.Add(lblDate)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1200, 660)
        Panel1.TabIndex = 1
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(1006, 75)
        Button2.Name = "Button2"
        Button2.Size = New Size(120, 43)
        Button2.TabIndex = 5
        Button2.Text = "Save Notes"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(866, 75)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 43)
        Button1.TabIndex = 4
        Button1.Text = "Cancel"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' HopeGroupBox2
        ' 
        HopeGroupBox2.BackColor = SystemColors.Control
        HopeGroupBox2.BorderColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        HopeGroupBox2.Controls.Add(hgbUrineAnalysis)
        HopeGroupBox2.Controls.Add(cmbVisitType)
        HopeGroupBox2.Controls.Add(cmbReasonVisit)
        HopeGroupBox2.Controls.Add(txtDoctorPlan)
        HopeGroupBox2.Controls.Add(Label20)
        HopeGroupBox2.Controls.Add(txtDoctorAssessment)
        HopeGroupBox2.Controls.Add(Label19)
        HopeGroupBox2.Controls.Add(Label18)
        HopeGroupBox2.Controls.Add(txtFetalHeart)
        HopeGroupBox2.Controls.Add(Label16)
        HopeGroupBox2.Controls.Add(Me.txtFundalHeight)
        HopeGroupBox2.Controls.Add(Label15)
        HopeGroupBox2.Controls.Add(smlWeight)
        HopeGroupBox2.Controls.Add(smlTemperature)
        HopeGroupBox2.Controls.Add(smlPulse)
        HopeGroupBox2.Controls.Add(smlBloodPressure)
        HopeGroupBox2.Controls.Add(Label14)
        HopeGroupBox2.Controls.Add(Label13)
        HopeGroupBox2.Controls.Add(Label12)
        HopeGroupBox2.Controls.Add(Label11)
        HopeGroupBox2.Controls.Add(Label10)
        HopeGroupBox2.Controls.Add(Label5)
        HopeGroupBox2.Controls.Add(Label4)
        HopeGroupBox2.Controls.Add(Label3)
        HopeGroupBox2.Font = New Font("Segoe UI", 12.0F)
        HopeGroupBox2.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox2.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox2.Location = New Point(432, 135)
        HopeGroupBox2.Name = "HopeGroupBox2"
        HopeGroupBox2.ShowText = False
        HopeGroupBox2.Size = New Size(734, 1118)
        HopeGroupBox2.TabIndex = 3
        HopeGroupBox2.TabStop = False
        HopeGroupBox2.Text = "HopeGroupBox2"
        HopeGroupBox2.ThemeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        ' 
        ' txtDoctorPlan
        ' 
        txtDoctorPlan.BorderStyle = BorderStyle.FixedSingle
        txtDoctorPlan.Location = New Point(35, 925)
        txtDoctorPlan.Multiline = True
        txtDoctorPlan.Name = "txtDoctorPlan"
        txtDoctorPlan.Size = New Size(659, 167)
        txtDoctorPlan.TabIndex = 39
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.BackColor = Color.Transparent
        Label20.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.ForeColor = Color.Black
        Label20.Location = New Point(31, 895)
        Label20.Name = "Label20"
        Label20.Size = New Size(54, 22)
        Label20.TabIndex = 38
        Label20.Text = "Plan"
        ' 
        ' txtDoctorAssessment
        ' 
        txtDoctorAssessment.BorderStyle = BorderStyle.FixedSingle
        txtDoctorAssessment.Location = New Point(35, 704)
        txtDoctorAssessment.Multiline = True
        txtDoctorAssessment.Name = "txtDoctorAssessment"
        txtDoctorAssessment.Size = New Size(659, 167)
        txtDoctorAssessment.TabIndex = 37
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.BackColor = Color.Transparent
        Label19.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = Color.Black
        Label19.Location = New Point(31, 674)
        Label19.Name = "Label19"
        Label19.Size = New Size(132, 22)
        Label19.TabIndex = 36
        Label19.Text = "Assessment"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = Color.Black
        Label18.Location = New Point(26, 621)
        Label18.Name = "Label18"
        Label18.Size = New Size(188, 28)
        Label18.TabIndex = 35
        Label18.Text = "Doctor's Note"
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
        Label17.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.Black
        Label17.Location = New Point(4, 7)
        Label17.Name = "Label17"
        Label17.Size = New Size(156, 22)
        Label17.TabIndex = 30
        Label17.Text = "Urine Analysis"
        ' 
        ' txtFetalHeart
        ' 
        txtFetalHeart.Location = New Point(31, 460)
        txtFetalHeart.Name = "txtFetalHeart"
        txtFetalHeart.Size = New Size(663, 34)
        txtFetalHeart.TabIndex = 29
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = Color.Transparent
        Label16.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.ForeColor = Color.Black
        Label16.Location = New Point(26, 422)
        Label16.Name = "Label16"
        Label16.Size = New Size(245, 22)
        Label16.TabIndex = 28
        Label16.Text = "Fetal Heart Rate (bpm)"
        ' 
        ' txtFundalHeight
        ' 
        Me.txtFundalHeight.Location = New Point(31, 368)
        Me.txtFundalHeight.Name = "txtFundalHeight"
        Me.txtFundalHeight.Size = New Size(663, 34)
        Me.txtFundalHeight.TabIndex = 27
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.Transparent
        Label15.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.ForeColor = Color.Black
        Label15.Location = New Point(26, 330)
        Label15.Name = "Label15"
        Label15.Size = New Size(152, 22)
        Label15.TabIndex = 26
        Label15.Text = "Fundal Height"
        ' 
        ' smlWeight
        ' 
        smlWeight.BackColor = Color.Transparent
        smlWeight.BorderColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        smlWeight.CustomBGColor = Color.White
        smlWeight.Font = New Font("Tahoma", 11.0F)
        smlWeight.ForeColor = Color.DimGray
        smlWeight.Location = New Point(561, 273)
        smlWeight.MaxLength = 32767
        smlWeight.Multiline = False
        smlWeight.Name = "smlWeight"
        smlWeight.ReadOnly = False
        smlWeight.Size = New Size(133, 33)
        smlWeight.SmoothingType = Drawing2D.SmoothingMode.AntiAlias
        smlWeight.TabIndex = 25
        smlWeight.Text = "SmallTextBox4"
        smlWeight.TextAlignment = HorizontalAlignment.Left
        smlWeight.UseSystemPasswordChar = False
        ' 
        ' smlTemperature
        ' 
        smlTemperature.BackColor = Color.Transparent
        smlTemperature.BorderColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        smlTemperature.CustomBGColor = Color.White
        smlTemperature.Font = New Font("Tahoma", 11.0F)
        smlTemperature.ForeColor = Color.DimGray
        smlTemperature.Location = New Point(390, 273)
        smlTemperature.MaxLength = 32767
        smlTemperature.Multiline = False
        smlTemperature.Name = "smlTemperature"
        smlTemperature.ReadOnly = False
        smlTemperature.Size = New Size(141, 33)
        smlTemperature.SmoothingType = Drawing2D.SmoothingMode.AntiAlias
        smlTemperature.TabIndex = 24
        smlTemperature.Text = "SmallTextBox3"
        smlTemperature.TextAlignment = HorizontalAlignment.Left
        smlTemperature.UseSystemPasswordChar = False
        ' 
        ' smlPulse
        ' 
        smlPulse.BackColor = Color.Transparent
        smlPulse.BorderColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        smlPulse.CustomBGColor = Color.White
        smlPulse.Font = New Font("Tahoma", 11.0F)
        smlPulse.ForeColor = Color.DimGray
        smlPulse.Location = New Point(223, 273)
        smlPulse.MaxLength = 32767
        smlPulse.Multiline = False
        smlPulse.Name = "smlPulse"
        smlPulse.ReadOnly = False
        smlPulse.Size = New Size(136, 33)
        smlPulse.SmoothingType = Drawing2D.SmoothingMode.AntiAlias
        smlPulse.TabIndex = 23
        smlPulse.Text = "SmallTextBox2"
        smlPulse.TextAlignment = HorizontalAlignment.Left
        smlPulse.UseSystemPasswordChar = False
        ' 
        ' smlBloodPressure
        ' 
        smlBloodPressure.BackColor = Color.Transparent
        smlBloodPressure.BorderColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        smlBloodPressure.CustomBGColor = Color.White
        smlBloodPressure.Font = New Font("Tahoma", 11.0F)
        smlBloodPressure.ForeColor = Color.DimGray
        smlBloodPressure.Location = New Point(31, 273)
        smlBloodPressure.MaxLength = 32767
        smlBloodPressure.Multiline = False
        smlBloodPressure.Name = "smlBloodPressure"
        smlBloodPressure.ReadOnly = False
        smlBloodPressure.Size = New Size(163, 33)
        smlBloodPressure.SmoothingType = Drawing2D.SmoothingMode.AntiAlias
        smlBloodPressure.TabIndex = 22
        smlBloodPressure.Text = "SmallTextBox1"
        smlBloodPressure.TextAlignment = HorizontalAlignment.Left
        smlBloodPressure.UseSystemPasswordChar = False
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = Color.Black
        Label14.Location = New Point(561, 236)
        Label14.Name = "Label14"
        Label14.Size = New Size(133, 22)
        Label14.TabIndex = 20
        Label14.Text = "Weight (kg)"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = Color.Black
        Label13.Location = New Point(390, 236)
        Label13.Name = "Label13"
        Label13.Size = New Size(141, 22)
        Label13.TabIndex = 19
        Label13.Text = "Temperature"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.Black
        Label12.Location = New Point(223, 236)
        Label12.Name = "Label12"
        Label12.Size = New Size(136, 22)
        Label12.TabIndex = 18
        Label12.Text = "Pulse (bpm)"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Black
        Label11.Location = New Point(31, 236)
        Label11.Name = "Label11"
        Label11.Size = New Size(163, 22)
        Label11.TabIndex = 17
        Label11.Text = "Blood Pressure"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.Black
        Label10.Location = New Point(26, 199)
        Label10.Name = "Label10"
        Label10.Size = New Size(150, 22)
        Label10.TabIndex = 16
        Label10.Text = "Current Vitals"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(354, 99)
        Label5.Name = "Label5"
        Label5.Size = New Size(170, 22)
        Label5.TabIndex = 13
        Label5.Text = "Reason for Visit"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(26, 99)
        Label4.Name = "Label4"
        Label4.Size = New Size(110, 22)
        Label4.TabIndex = 12
        Label4.Text = "Visit Type"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(26, 30)
        Label3.Name = "Label3"
        Label3.Size = New Size(101, 28)
        Label3.TabIndex = 12
        Label3.Text = "Details"
        ' 
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BackColor = Color.Transparent
        HopeGroupBox1.BackgroundImage = My.Resources.Resources.bg_img
        HopeGroupBox1.BackgroundImageLayout = ImageLayout.Center
        HopeGroupBox1.BorderColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        HopeGroupBox1.Controls.Add(lblAllergies)
        HopeGroupBox1.Controls.Add(lblBloodType)
        HopeGroupBox1.Controls.Add(lblDueDate)
        HopeGroupBox1.Controls.Add(lblGestationalAge)
        HopeGroupBox1.Controls.Add(Label9)
        HopeGroupBox1.Controls.Add(Label8)
        HopeGroupBox1.Controls.Add(Label7)
        HopeGroupBox1.Controls.Add(Label6)
        HopeGroupBox1.Controls.Add(lblTypeOfPatient)
        HopeGroupBox1.Controls.Add(lblPatientAge)
        HopeGroupBox1.Controls.Add(lblPatientName)
        HopeGroupBox1.Controls.Add(Label2)
        HopeGroupBox1.Font = New Font("Segoe UI", 12.0F)
        HopeGroupBox1.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox1.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Location = New Point(35, 135)
        HopeGroupBox1.Name = "HopeGroupBox1"
        HopeGroupBox1.ShowText = False
        HopeGroupBox1.Size = New Size(380, 513)
        HopeGroupBox1.TabIndex = 2
        HopeGroupBox1.TabStop = False
        HopeGroupBox1.Text = "HopeGroupBox1"
        HopeGroupBox1.ThemeColor = Color.Gainsboro
        ' 
        ' lblAllergies
        ' 
        lblAllergies.AutoSize = True
        lblAllergies.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAllergies.ForeColor = Color.Black
        lblAllergies.Location = New Point(50, 475)
        lblAllergies.Name = "lblAllergies"
        lblAllergies.Size = New Size(92, 22)
        lblAllergies.TabIndex = 11
        lblAllergies.Text = "Seafood"
        ' 
        ' lblBloodType
        ' 
        lblBloodType.AutoSize = True
        lblBloodType.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblBloodType.ForeColor = Color.Black
        lblBloodType.Location = New Point(50, 403)
        lblBloodType.Name = "lblBloodType"
        lblBloodType.Size = New Size(59, 22)
        lblBloodType.TabIndex = 10
        lblBloodType.Text = "Type"
        ' 
        ' lblDueDate
        ' 
        lblDueDate.AutoSize = True
        lblDueDate.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDueDate.ForeColor = Color.Black
        lblDueDate.Location = New Point(50, 330)
        lblDueDate.Name = "lblDueDate"
        lblDueDate.Size = New Size(157, 22)
        lblDueDate.TabIndex = 9
        lblDueDate.Text = "Date of Preg..."
        ' 
        ' lblGestationalAge
        ' 
        lblGestationalAge.AutoSize = True
        lblGestationalAge.Font = New Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblGestationalAge.ForeColor = Color.Black
        lblGestationalAge.Location = New Point(50, 253)
        lblGestationalAge.Name = "lblGestationalAge"
        lblGestationalAge.Size = New Size(223, 22)
        lblGestationalAge.TabIndex = 8
        lblGestationalAge.Text = "WEEKS (TRIMESTER)"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Black
        Label9.Location = New Point(19, 437)
        Label9.Name = "Label9"
        Label9.Size = New Size(111, 25)
        Label9.TabIndex = 7
        Label9.Text = "Allergies"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.Black
        Label8.Location = New Point(19, 368)
        Label8.Name = "Label8"
        Label8.Size = New Size(137, 25)
        Label8.TabIndex = 6
        Label8.Text = "Blood Type"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(19, 296)
        Label7.Name = "Label7"
        Label7.Size = New Size(115, 25)
        Label7.TabIndex = 5
        Label7.Text = "Due Date"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(19, 217)
        Label6.Name = "Label6"
        Label6.Size = New Size(189, 25)
        Label6.TabIndex = 4
        Label6.Text = "Gestational Age"
        ' 
        ' lblTypeOfPatient
        ' 
        lblTypeOfPatient.AutoSize = True
        lblTypeOfPatient.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTypeOfPatient.ForeColor = Color.Black
        lblTypeOfPatient.Location = New Point(161, 160)
        lblTypeOfPatient.Name = "lblTypeOfPatient"
        lblTypeOfPatient.Size = New Size(154, 25)
        lblTypeOfPatient.TabIndex = 3
        lblTypeOfPatient.Text = "what patient"
        ' 
        ' lblPatientAge
        ' 
        lblPatientAge.AutoSize = True
        lblPatientAge.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatientAge.ForeColor = Color.Black
        lblPatientAge.Location = New Point(161, 123)
        lblPatientAge.Name = "lblPatientAge"
        lblPatientAge.Size = New Size(58, 25)
        lblPatientAge.TabIndex = 2
        lblPatientAge.Text = "AGE"
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatientName.ForeColor = Color.Black
        lblPatientName.Location = New Point(161, 85)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.Size = New Size(78, 25)
        lblPatientName.TabIndex = 1
        lblPatientName.Text = "NAME"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(19, 30)
        Label2.Name = "Label2"
        Label2.Size = New Size(266, 28)
        Label2.TabIndex = 0
        Label2.Text = "Patient Information"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.BackColor = Color.Transparent
        lblDate.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDate.Location = New Point(24, 65)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(145, 25)
        lblDate.TabIndex = 1
        lblDate.Text = "DATE & TIME"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(317, 34)
        Label1.TabIndex = 0
        Label1.Text = "Consultation Notes"
        ' 
        ' cmbReasonVisit
        ' 
        cmbReasonVisit.DrawMode = DrawMode.OwnerDrawFixed
        cmbReasonVisit.FlatStyle = FlatStyle.Flat
        cmbReasonVisit.Font = New Font("Segoe UI", 12.0F)
        cmbReasonVisit.FormattingEnabled = True
        cmbReasonVisit.ItemHeight = 30
        cmbReasonVisit.Items.AddRange(New Object() {"Routine Check-Up", "Follow-up"})
        cmbReasonVisit.Location = New Point(354, 133)
        cmbReasonVisit.Name = "cmbReasonVisit"
        cmbReasonVisit.Size = New Size(315, 36)
        cmbReasonVisit.TabIndex = 40
        ' 
        ' cmbVisitType
        ' 
        cmbVisitType.DrawMode = DrawMode.OwnerDrawFixed
        cmbVisitType.FlatStyle = FlatStyle.Flat
        cmbVisitType.Font = New Font("Segoe UI", 12.0F)
        cmbVisitType.FormattingEnabled = True
        cmbVisitType.ItemHeight = 30
        cmbVisitType.Items.AddRange(New Object() {"Prenatal Check-Up", "", "Ultrasound", "", "Postpartum Follow-Up", "", "Consultation"})
        cmbVisitType.Location = New Point(26, 133)
        cmbVisitType.Name = "cmbVisitType"
        cmbVisitType.Size = New Size(315, 36)
        cmbVisitType.TabIndex = 41
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
        hgbUrineAnalysis.Font = New Font("Segoe UI", 12.0F)
        hgbUrineAnalysis.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        hgbUrineAnalysis.LineColor = Color.Transparent
        hgbUrineAnalysis.Location = New Point(24, 517)
        hgbUrineAnalysis.Name = "hgbUrineAnalysis"
        hgbUrineAnalysis.ShowText = False
        hgbUrineAnalysis.Size = New Size(670, 86)
        hgbUrineAnalysis.TabIndex = 42
        hgbUrineAnalysis.TabStop = False
        hgbUrineAnalysis.Text = "HopeGroupBox3"
        hgbUrineAnalysis.ThemeColor = Color.Transparent
        ' 
        ' ConsultationDetails
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 700)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1020)
        MinimumSize = New Size(190, 40)
        Name = "ConsultationDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ConsultationDetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        HopeGroupBox2.ResumeLayout(False)
        HopeGroupBox2.PerformLayout()
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        hgbUrineAnalysis.ResumeLayout(False)
        hgbUrineAnalysis.PerformLayout()
        ResumeLayout(False)

        ' 
        ' txtFundalHeight
        ' 
        txtFundalHeight.BackColor = Color.Transparent
        txtFundalHeight.Font = New Font("Tahoma", 11.0F)
        txtFundalHeight.ForeColor = Color.DimGray
        txtFundalHeight.Location = New Point(31, 330)
        txtFundalHeight.MaxLength = 32767
        txtFundalHeight.Multiline = False
        txtFundalHeight.Name = "txtFundalHeight"
        txtFundalHeight.ReadOnly = False
        txtFundalHeight.Size = New Size(163, 33)
        txtFundalHeight.TabIndex = 26
        txtFundalHeight.Text = ""
        txtFundalHeight.UseSystemPasswordChar = False
        HopeGroupBox2.Controls.Add(txtFundalHeight)

    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblDate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents HopeGroupBox1 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents lblTypeOfPatient As Label
    Friend WithEvents lblPatientAge As Label
    Friend WithEvents lblPatientName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblAllergies As Label
    Friend WithEvents lblBloodType As Label
    Friend WithEvents lblDueDate As Label
    Friend WithEvents lblGestationalAge As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents HopeGroupBox2 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents listVisitType As ListBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents smlWeight As ReaLTaiizor.Controls.SmallTextBox
    Friend WithEvents smlTemperature As ReaLTaiizor.Controls.SmallTextBox
    Friend WithEvents smlPulse As ReaLTaiizor.Controls.SmallTextBox
    Friend WithEvents smlBloodPressure As ReaLTaiizor.Controls.SmallTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtFetalHeart As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents rbBlood As RadioButton
    Friend WithEvents rbKetones As RadioButton
    Friend WithEvents rbGlucose As RadioButton
    Friend WithEvents rbProtein As RadioButton
    Friend WithEvents txtDoctorAssessment As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtDoctorPlan As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbReasonVisit As ReaLTaiizor.Controls.HopeComboBox
    Friend WithEvents cmbVisitType As ReaLTaiizor.Controls.HopeComboBox
    Friend WithEvents hgbUrineAnalysis As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents txtFundalHeight As TextBox

End Class
