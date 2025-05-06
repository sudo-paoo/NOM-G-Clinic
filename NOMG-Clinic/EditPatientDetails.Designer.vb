<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditPatientDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditPatientDetails))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        Label29 = New Label()
        Label28 = New Label()
        btnSave = New FontAwesome.Sharp.IconButton()
        Label3 = New Label()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
        lblAssignedOB = New Label()
        lblNextCheckup = New Label()
        lblGestationalAge = New Label()
        lblLastMenstrualAge = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        HopeGroupBox4 = New ReaLTaiizor.Controls.HopeGroupBox()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        txtHistoryOfSurgery = New TextBox()
        Label27 = New Label()
        txtCurrentMedication = New TextBox()
        Label26 = New Label()
        txtEmergencyContactNumber = New TextBox()
        Label25 = New Label()
        txtEmergencyContactRelationship = New TextBox()
        Label24 = New Label()
        txtEmergencyContactName = New TextBox()
        Label23 = New Label()
        txtEmailAddress = New TextBox()
        Label22 = New Label()
        txtContactNumber = New TextBox()
        Label21 = New Label()
        Label20 = New Label()
        txtHeight = New TextBox()
        Label19 = New Label()
        txtWeight = New TextBox()
        Label18 = New Label()
        Label17 = New Label()
        txtLastName = New TextBox()
        Label16 = New Label()
        txtMiddleName = New TextBox()
        txtAddress = New TextBox()
        Label2 = New Label()
        rbtnNo = New RadioButton()
        rbtnYes = New RadioButton()
        Label1 = New Label()
        Label15 = New Label()
        txtAge = New TextBox()
        Label14 = New Label()
        Label11 = New Label()
        txtFirstName = New TextBox()
        Panel1.SuspendLayout()
        HopeGroupBox1.SuspendLayout()
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
        HopeForm1.Size = New Size(1000, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "Edit Patient Details"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        Panel1.Controls.Add(Label29)
        Panel1.Controls.Add(Label28)
        Panel1.Controls.Add(btnSave)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(HopeGroupBox1)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(HopeGroupBox4)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1000, 660)
        Panel1.TabIndex = 1
        ' 
        ' Label29
        ' 
        Label29.AutoSize = True
        Label29.Location = New Point(773, 1484)
        Label29.Name = "Label29"
        Label29.Size = New Size(18, 20)
        Label29.TabIndex = 31
        Label29.Text = "..."
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.BackColor = Color.Transparent
        Label28.Font = New Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label28.Location = New Point(47, 17)
        Label28.Name = "Label28"
        Label28.Size = New Size(323, 34)
        Label28.TabIndex = 30
        Label28.Text = "Edit Patient Details"
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.IconChar = FontAwesome.Sharp.IconChar.Cloud
        btnSave.IconColor = Color.White
        btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnSave.IconSize = 36
        btnSave.ImageAlign = ContentAlignment.MiddleLeft
        btnSave.Location = New Point(829, 1471)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(118, 44)
        btnSave.TabIndex = 29
        btnSave.Text = "SAVE"
        btnSave.TextImageRelation = TextImageRelation.TextBeforeImage
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(388, 1138)
        Label3.Name = "Label3"
        Label3.Size = New Size(246, 31)
        Label3.TabIndex = 27
        Label3.Text = "Pregnancy Information"
        ' 
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Controls.Add(lblAssignedOB)
        HopeGroupBox1.Controls.Add(lblNextCheckup)
        HopeGroupBox1.Controls.Add(lblGestationalAge)
        HopeGroupBox1.Controls.Add(lblLastMenstrualAge)
        HopeGroupBox1.Controls.Add(Label5)
        HopeGroupBox1.Controls.Add(Label6)
        HopeGroupBox1.Controls.Add(Label7)
        HopeGroupBox1.Controls.Add(Label9)
        HopeGroupBox1.Font = New Font("Segoe UI", 12F)
        HopeGroupBox1.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox1.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Location = New Point(52, 1185)
        HopeGroupBox1.Name = "HopeGroupBox1"
        HopeGroupBox1.ShowText = False
        HopeGroupBox1.Size = New Size(895, 270)
        HopeGroupBox1.TabIndex = 26
        HopeGroupBox1.TabStop = False
        HopeGroupBox1.Text = "HopeGroupBox1"
        HopeGroupBox1.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        ' 
        ' lblAssignedOB
        ' 
        lblAssignedOB.AutoSize = True
        lblAssignedOB.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        lblAssignedOB.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAssignedOB.Location = New Point(411, 192)
        lblAssignedOB.Name = "lblAssignedOB"
        lblAssignedOB.Size = New Size(22, 23)
        lblAssignedOB.TabIndex = 52
        lblAssignedOB.Text = "..."
        ' 
        ' lblNextCheckup
        ' 
        lblNextCheckup.AutoSize = True
        lblNextCheckup.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        lblNextCheckup.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNextCheckup.Location = New Point(411, 141)
        lblNextCheckup.Name = "lblNextCheckup"
        lblNextCheckup.Size = New Size(22, 23)
        lblNextCheckup.TabIndex = 51
        lblNextCheckup.Text = "..."
        ' 
        ' lblGestationalAge
        ' 
        lblGestationalAge.AutoSize = True
        lblGestationalAge.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        lblGestationalAge.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblGestationalAge.Location = New Point(411, 88)
        lblGestationalAge.Name = "lblGestationalAge"
        lblGestationalAge.Size = New Size(22, 23)
        lblGestationalAge.TabIndex = 50
        lblGestationalAge.Text = "..."
        ' 
        ' lblLastMenstrualAge
        ' 
        lblLastMenstrualAge.AutoSize = True
        lblLastMenstrualAge.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        lblLastMenstrualAge.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLastMenstrualAge.Location = New Point(411, 35)
        lblLastMenstrualAge.Name = "lblLastMenstrualAge"
        lblLastMenstrualAge.Size = New Size(22, 23)
        lblLastMenstrualAge.TabIndex = 49
        lblLastMenstrualAge.Text = "..."
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(24, 187)
        Label5.Name = "Label5"
        Label5.Size = New Size(133, 28)
        Label5.TabIndex = 48
        Label5.Text = "Assigned OB:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label6.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(24, 136)
        Label6.Name = "Label6"
        Label6.Size = New Size(145, 28)
        Label6.TabIndex = 45
        Label6.Text = "Next Checkup:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label7.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(24, 30)
        Label7.Name = "Label7"
        Label7.Size = New Size(150, 28)
        Label7.TabIndex = 7
        Label7.Text = "Last Menstrual:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label9.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(24, 83)
        Label9.Name = "Label9"
        Label9.Size = New Size(161, 28)
        Label9.TabIndex = 4
        Label9.Text = "Gestational Age:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(382, 75)
        Label8.Name = "Label8"
        Label8.Size = New Size(225, 31)
        Label8.TabIndex = 25
        Label8.Text = "Personal Information"
        ' 
        ' HopeGroupBox4
        ' 
        HopeGroupBox4.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Controls.Add(Label27)
        HopeGroupBox4.Controls.Add(ComboBox2)
        HopeGroupBox4.Controls.Add(ComboBox1)
        HopeGroupBox4.Controls.Add(txtHistoryOfSurgery)
        HopeGroupBox4.Controls.Add(txtCurrentMedication)
        HopeGroupBox4.Controls.Add(Label26)
        HopeGroupBox4.Controls.Add(txtEmergencyContactNumber)
        HopeGroupBox4.Controls.Add(Label25)
        HopeGroupBox4.Controls.Add(txtEmergencyContactRelationship)
        HopeGroupBox4.Controls.Add(Label24)
        HopeGroupBox4.Controls.Add(txtEmergencyContactName)
        HopeGroupBox4.Controls.Add(Label23)
        HopeGroupBox4.Controls.Add(txtEmailAddress)
        HopeGroupBox4.Controls.Add(Label22)
        HopeGroupBox4.Controls.Add(txtContactNumber)
        HopeGroupBox4.Controls.Add(Label21)
        HopeGroupBox4.Controls.Add(Label20)
        HopeGroupBox4.Controls.Add(txtHeight)
        HopeGroupBox4.Controls.Add(Label19)
        HopeGroupBox4.Controls.Add(txtWeight)
        HopeGroupBox4.Controls.Add(Label18)
        HopeGroupBox4.Controls.Add(Label17)
        HopeGroupBox4.Controls.Add(txtLastName)
        HopeGroupBox4.Controls.Add(Label16)
        HopeGroupBox4.Controls.Add(txtMiddleName)
        HopeGroupBox4.Controls.Add(txtAddress)
        HopeGroupBox4.Controls.Add(Label2)
        HopeGroupBox4.Controls.Add(rbtnNo)
        HopeGroupBox4.Controls.Add(rbtnYes)
        HopeGroupBox4.Controls.Add(Label1)
        HopeGroupBox4.Controls.Add(Label15)
        HopeGroupBox4.Controls.Add(txtAge)
        HopeGroupBox4.Controls.Add(Label14)
        HopeGroupBox4.Controls.Add(Label11)
        HopeGroupBox4.Controls.Add(txtFirstName)
        HopeGroupBox4.Font = New Font("Segoe UI", 12F)
        HopeGroupBox4.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox4.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox4.Location = New Point(47, 118)
        HopeGroupBox4.Name = "HopeGroupBox4"
        HopeGroupBox4.ShowText = False
        HopeGroupBox4.Size = New Size(895, 1017)
        HopeGroupBox4.TabIndex = 24
        HopeGroupBox4.TabStop = False
        HopeGroupBox4.Text = "HopeGroupBox4"
        HopeGroupBox4.ThemeColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Items.AddRange(New Object() {"Single", "Married", "Widowed", "Divorced"})
        ComboBox2.Location = New Point(341, 450)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(523, 36)
        ComboBox2.TabIndex = 78
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"})
        ComboBox1.Location = New Point(341, 398)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(523, 36)
        ComboBox1.TabIndex = 77
        ' 
        ' txtHistoryOfSurgery
        ' 
        txtHistoryOfSurgery.Location = New Point(341, 909)
        txtHistoryOfSurgery.MinimumSize = New Size(0, 75)
        txtHistoryOfSurgery.Name = "txtHistoryOfSurgery"
        txtHistoryOfSurgery.Size = New Size(523, 34)
        txtHistoryOfSurgery.TabIndex = 76
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label27.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label27.Location = New Point(24, 909)
        Label27.Name = "Label27"
        Label27.Size = New Size(183, 28)
        Label27.TabIndex = 75
        Label27.Text = "History of surgery:"
        ' 
        ' txtCurrentMedication
        ' 
        txtCurrentMedication.Location = New Point(341, 809)
        txtCurrentMedication.MinimumSize = New Size(0, 75)
        txtCurrentMedication.Name = "txtCurrentMedication"
        txtCurrentMedication.Size = New Size(523, 75)
        txtCurrentMedication.TabIndex = 74
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label26.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label26.Location = New Point(24, 809)
        Label26.Name = "Label26"
        Label26.Size = New Size(192, 28)
        Label26.TabIndex = 73
        Label26.Text = "Current medication:"
        ' 
        ' txtEmergencyContactNumber
        ' 
        txtEmergencyContactNumber.Location = New Point(341, 756)
        txtEmergencyContactNumber.Name = "txtEmergencyContactNumber"
        txtEmergencyContactNumber.Size = New Size(523, 34)
        txtEmergencyContactNumber.TabIndex = 72
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label25.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label25.Location = New Point(24, 756)
        Label25.Name = "Label25"
        Label25.Size = New Size(268, 28)
        Label25.TabIndex = 71
        Label25.Text = "Emergency contact number:"
        ' 
        ' txtEmergencyContactRelationship
        ' 
        txtEmergencyContactRelationship.Location = New Point(341, 703)
        txtEmergencyContactRelationship.Name = "txtEmergencyContactRelationship"
        txtEmergencyContactRelationship.Size = New Size(523, 34)
        txtEmergencyContactRelationship.TabIndex = 70
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label24.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label24.Location = New Point(24, 703)
        Label24.Name = "Label24"
        Label24.Size = New Size(302, 28)
        Label24.TabIndex = 69
        Label24.Text = "Emergency contact relationship:"
        ' 
        ' txtEmergencyContactName
        ' 
        txtEmergencyContactName.Location = New Point(341, 650)
        txtEmergencyContactName.Name = "txtEmergencyContactName"
        txtEmergencyContactName.Size = New Size(523, 34)
        txtEmergencyContactName.TabIndex = 68
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label23.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label23.Location = New Point(24, 650)
        Label23.Name = "Label23"
        Label23.Size = New Size(246, 28)
        Label23.TabIndex = 67
        Label23.Text = "Emergency contact name:"
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.Location = New Point(341, 600)
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.Size = New Size(523, 34)
        txtEmailAddress.TabIndex = 66
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label22.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label22.Location = New Point(24, 600)
        Label22.Name = "Label22"
        Label22.Size = New Size(144, 28)
        Label22.TabIndex = 65
        Label22.Text = "Email Address:"
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Location = New Point(341, 240)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(523, 34)
        txtContactNumber.TabIndex = 64
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label21.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label21.Location = New Point(24, 243)
        Label21.Name = "Label21"
        Label21.Size = New Size(165, 28)
        Label21.TabIndex = 63
        Label21.Text = "Contact number:"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label20.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.Location = New Point(24, 401)
        Label20.Name = "Label20"
        Label20.Size = New Size(116, 28)
        Label20.TabIndex = 61
        Label20.Text = "Blood type:"
        ' 
        ' txtHeight
        ' 
        txtHeight.Location = New Point(341, 345)
        txtHeight.Name = "txtHeight"
        txtHeight.Size = New Size(523, 34)
        txtHeight.TabIndex = 60
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label19.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(24, 348)
        Label19.Name = "Label19"
        Label19.Size = New Size(79, 28)
        Label19.TabIndex = 59
        Label19.Text = "Height:"
        ' 
        ' txtWeight
        ' 
        txtWeight.Location = New Point(341, 292)
        txtWeight.Name = "txtWeight"
        txtWeight.Size = New Size(523, 34)
        txtWeight.TabIndex = 58
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label18.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(24, 295)
        Label18.Name = "Label18"
        Label18.Size = New Size(82, 28)
        Label18.TabIndex = 57
        Label18.Text = "Weight:"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label17.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(24, 137)
        Label17.Name = "Label17"
        Label17.Size = New Size(110, 28)
        Label17.TabIndex = 55
        Label17.Text = "Last name:"
        ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(341, 134)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(523, 34)
        txtLastName.TabIndex = 56
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label16.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(24, 83)
        Label16.Name = "Label16"
        Label16.Size = New Size(137, 28)
        Label16.TabIndex = 53
        Label16.Text = "Middle name:"
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Location = New Point(341, 80)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(523, 34)
        txtMiddleName.TabIndex = 54
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(341, 549)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(523, 34)
        txtAddress.TabIndex = 52
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(24, 549)
        Label2.Name = "Label2"
        Label2.Size = New Size(90, 28)
        Label2.TabIndex = 51
        Label2.Text = "Address:"
        ' 
        ' rbtnNo
        ' 
        rbtnNo.AutoSize = True
        rbtnNo.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbtnNo.Location = New Point(454, 507)
        rbtnNo.Name = "rbtnNo"
        rbtnNo.Size = New Size(54, 27)
        rbtnNo.TabIndex = 50
        rbtnNo.TabStop = True
        rbtnNo.Text = "No"
        rbtnNo.UseVisualStyleBackColor = True
        ' 
        ' rbtnYes
        ' 
        rbtnYes.AutoSize = True
        rbtnYes.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbtnYes.Location = New Point(341, 507)
        rbtnYes.Name = "rbtnYes"
        rbtnYes.Size = New Size(55, 27)
        rbtnYes.TabIndex = 49
        rbtnYes.TabStop = True
        rbtnYes.Text = "Yes"
        rbtnYes.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(24, 504)
        Label1.Name = "Label1"
        Label1.Size = New Size(105, 28)
        Label1.TabIndex = 48
        Label1.Text = "First baby:"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label15.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(24, 453)
        Label15.Name = "Label15"
        Label15.Size = New Size(115, 28)
        Label15.TabIndex = 45
        Label15.Text = "Civil Status:"
        ' 
        ' txtAge
        ' 
        txtAge.Location = New Point(341, 186)
        txtAge.Name = "txtAge"
        txtAge.Size = New Size(523, 34)
        txtAge.TabIndex = 11
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
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.FromArgb(CByte(250), CByte(180), CByte(188))
        Label11.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(24, 189)
        Label11.Name = "Label11"
        Label11.Size = New Size(53, 28)
        Label11.TabIndex = 4
        Label11.Text = "Age:"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(341, 27)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(523, 34)
        txtFirstName.TabIndex = 8
        ' 
        ' EditPatientDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 700)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(190, 40)
        Name = "EditPatientDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "EditPatientDetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        HopeGroupBox4.ResumeLayout(False)
        HopeGroupBox4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents HopeGroupBox4 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtAge As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents rbtnNo As RadioButton
    Friend WithEvents rbtnYes As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents HopeGroupBox1 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAssignedOB As Label
    Friend WithEvents lblNextCheckup As Label
    Friend WithEvents lblGestationalAge As Label
    Friend WithEvents lblLastMenstrualAge As Label
    Friend WithEvents txtWeight As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtHistoryOfSurgery As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtCurrentMedication As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtEmergencyContactNumber As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtEmergencyContactRelationship As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtEmergencyContactName As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents btnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
End Class
