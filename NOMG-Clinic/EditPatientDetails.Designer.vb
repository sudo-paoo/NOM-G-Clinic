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
        tabPatientEdit = New TabControl()
        TabPage1 = New TabPage()
        numHeight = New NumericUpDown()
        numWeight = New NumericUpDown()
        numAge = New NumericUpDown()
        cbxBloodType = New ComboBox()
        cbxCivilStatus = New ComboBox()
        Label16 = New Label()
        btnPersonalInformationNext = New FontAwesome.Sharp.IconButton()
        Label11 = New Label()
        txtEmailAddress = New TextBox()
        Label12 = New Label()
        txtContactNumber = New TextBox()
        Label10 = New Label()
        txtAddress = New TextBox()
        Label8 = New Label()
        Label9 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label3 = New Label()
        txtLastName = New TextBox()
        Label2 = New Label()
        txtMiddleName = New TextBox()
        Label1 = New Label()
        txtFirstName = New TextBox()
        TabPage2 = New TabPage()
        Label17 = New Label()
        btnEmergencyContactPrevious = New FontAwesome.Sharp.IconButton()
        btnEmergencyContactNext = New FontAwesome.Sharp.IconButton()
        labelnum = New Label()
        txtEmergencyContactNumber = New TextBox()
        labelrel = New Label()
        txtEmergencyContactRelationship = New TextBox()
        Label15 = New Label()
        txtEmergencyContactName = New TextBox()
        TabPage3 = New TabPage()
        lblSelectedDate = New Label()
        txtHistoryOfSurgery = New TextBox()
        txtCurrentMedication = New TextBox()
        Label24 = New Label()
        Label23 = New Label()
        Label22 = New Label()
        txtAllergies = New TextBox()
        cbxAssignedOB = New ComboBox()
        Label21 = New Label()
        btnMedicalInformationPrevious = New FontAwesome.Sharp.IconButton()
        rbtnNo = New RadioButton()
        rtbnYes = New RadioButton()
        Label20 = New Label()
        clrLastMenstrual = New MonthCalendar()
        Label19 = New Label()
        Label18 = New Label()
        Label29 = New Label()
        Label28 = New Label()
        btnUpdatePatient = New FontAwesome.Sharp.IconButton()
        Panel1.SuspendLayout()
        tabPatientEdit.SuspendLayout()
        TabPage1.SuspendLayout()
        CType(numHeight, ComponentModel.ISupportInitialize).BeginInit()
        CType(numWeight, ComponentModel.ISupportInitialize).BeginInit()
        CType(numAge, ComponentModel.ISupportInitialize).BeginInit()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
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
        Panel1.Controls.Add(tabPatientEdit)
        Panel1.Controls.Add(Label29)
        Panel1.Controls.Add(Label28)
        Panel1.Controls.Add(btnUpdatePatient)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1000, 660)
        Panel1.TabIndex = 1
        ' 
        ' tabPatientEdit
        ' 
        tabPatientEdit.Controls.Add(TabPage1)
        tabPatientEdit.Controls.Add(TabPage2)
        tabPatientEdit.Controls.Add(TabPage3)
        tabPatientEdit.Font = New Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tabPatientEdit.Location = New Point(1, 75)
        tabPatientEdit.Name = "tabPatientEdit"
        tabPatientEdit.SelectedIndex = 0
        tabPatientEdit.Size = New Size(976, 641)
        tabPatientEdit.SizeMode = TabSizeMode.Fixed
        tabPatientEdit.TabIndex = 32
        ' 
        ' TabPage1
        ' 
        TabPage1.BackgroundImage = My.Resources.Resources.bg_img
        TabPage1.BackgroundImageLayout = ImageLayout.Stretch
        TabPage1.Controls.Add(numHeight)
        TabPage1.Controls.Add(numWeight)
        TabPage1.Controls.Add(numAge)
        TabPage1.Controls.Add(cbxBloodType)
        TabPage1.Controls.Add(cbxCivilStatus)
        TabPage1.Controls.Add(Label16)
        TabPage1.Controls.Add(btnPersonalInformationNext)
        TabPage1.Controls.Add(Label11)
        TabPage1.Controls.Add(txtEmailAddress)
        TabPage1.Controls.Add(Label12)
        TabPage1.Controls.Add(txtContactNumber)
        TabPage1.Controls.Add(Label10)
        TabPage1.Controls.Add(txtAddress)
        TabPage1.Controls.Add(Label8)
        TabPage1.Controls.Add(Label9)
        TabPage1.Controls.Add(Label4)
        TabPage1.Controls.Add(Label5)
        TabPage1.Controls.Add(Label6)
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(txtLastName)
        TabPage1.Controls.Add(Label2)
        TabPage1.Controls.Add(txtMiddleName)
        TabPage1.Controls.Add(Label1)
        TabPage1.Controls.Add(txtFirstName)
        TabPage1.Location = New Point(4, 27)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(968, 610)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Personal Information"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' numHeight
        ' 
        numHeight.Font = New Font("Verdana", 12F)
        numHeight.Location = New Point(506, 281)
        numHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numHeight.Name = "numHeight"
        numHeight.Size = New Size(445, 32)
        numHeight.TabIndex = 28
        ' 
        ' numWeight
        ' 
        numWeight.Font = New Font("Verdana", 12F)
        numWeight.Location = New Point(16, 281)
        numWeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numWeight.Name = "numWeight"
        numWeight.Size = New Size(445, 32)
        numWeight.TabIndex = 27
        ' 
        ' numAge
        ' 
        numAge.Font = New Font("Verdana", 12F)
        numAge.Location = New Point(16, 197)
        numAge.Name = "numAge"
        numAge.Size = New Size(287, 32)
        numAge.TabIndex = 26
        ' 
        ' cbxBloodType
        ' 
        cbxBloodType.AutoCompleteMode = AutoCompleteMode.Suggest
        cbxBloodType.AutoCompleteSource = AutoCompleteSource.ListItems
        cbxBloodType.Font = New Font("Verdana", 12F)
        cbxBloodType.FormattingEnabled = True
        cbxBloodType.Items.AddRange(New Object() {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"})
        cbxBloodType.Location = New Point(661, 196)
        cbxBloodType.Name = "cbxBloodType"
        cbxBloodType.Size = New Size(290, 33)
        cbxBloodType.TabIndex = 25
        ' 
        ' cbxCivilStatus
        ' 
        cbxCivilStatus.AutoCompleteMode = AutoCompleteMode.Suggest
        cbxCivilStatus.AutoCompleteSource = AutoCompleteSource.ListItems
        cbxCivilStatus.Font = New Font("Verdana", 12F)
        cbxCivilStatus.FormattingEnabled = True
        cbxCivilStatus.Items.AddRange(New Object() {"Single", "Married", "Widowed", "Divorced"})
        cbxCivilStatus.Location = New Point(340, 196)
        cbxCivilStatus.Name = "cbxCivilStatus"
        cbxCivilStatus.Size = New Size(290, 33)
        cbxCivilStatus.TabIndex = 24
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = Color.Transparent
        Label16.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(19, 27)
        Label16.Name = "Label16"
        Label16.Size = New Size(287, 28)
        Label16.TabIndex = 23
        Label16.Text = "Personal Information"
        ' 
        ' btnPersonalInformationNext
        ' 
        btnPersonalInformationNext.BackColor = Color.FromArgb(CByte(225), CByte(29), CByte(72))
        btnPersonalInformationNext.FlatAppearance.BorderSize = 0
        btnPersonalInformationNext.FlatStyle = FlatStyle.Flat
        btnPersonalInformationNext.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPersonalInformationNext.IconChar = FontAwesome.Sharp.IconChar.AngleRight
        btnPersonalInformationNext.IconColor = Color.Black
        btnPersonalInformationNext.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPersonalInformationNext.IconSize = 28
        btnPersonalInformationNext.ImageAlign = ContentAlignment.BottomRight
        btnPersonalInformationNext.Location = New Point(857, 554)
        btnPersonalInformationNext.Name = "btnPersonalInformationNext"
        btnPersonalInformationNext.Size = New Size(94, 40)
        btnPersonalInformationNext.TabIndex = 22
        btnPersonalInformationNext.Text = "Next"
        btnPersonalInformationNext.TextImageRelation = TextImageRelation.TextBeforeImage
        btnPersonalInformationNext.UseVisualStyleBackColor = False
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label11.Location = New Point(509, 480)
        Label11.Name = "Label11"
        Label11.Size = New Size(144, 20)
        Label11.TabIndex = 21
        Label11.Text = "Email Address"
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmailAddress.Location = New Point(506, 510)
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.Size = New Size(445, 32)
        txtEmailAddress.TabIndex = 20
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label12.Location = New Point(19, 480)
        Label12.Name = "Label12"
        Label12.Size = New Size(163, 20)
        Label12.TabIndex = 19
        Label12.Text = "Contact Number"
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtContactNumber.Location = New Point(16, 510)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(445, 32)
        txtContactNumber.TabIndex = 18
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label10.Location = New Point(19, 333)
        Label10.Name = "Label10"
        Label10.Size = New Size(85, 20)
        Label10.TabIndex = 17
        Label10.Text = "Address"
        ' 
        ' txtAddress
        ' 
        txtAddress.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAddress.Location = New Point(16, 363)
        txtAddress.MinimumSize = New Size(0, 100)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(935, 100)
        txtAddress.TabIndex = 16
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label8.Location = New Point(509, 250)
        Label8.Name = "Label8"
        Label8.Size = New Size(124, 20)
        Label8.TabIndex = 15
        Label8.Text = "Height (cm)"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label9.Location = New Point(19, 250)
        Label9.Name = "Label9"
        Label9.Size = New Size(124, 20)
        Label9.TabIndex = 13
        Label9.Text = "Weight (kg)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label4.Location = New Point(664, 167)
        Label4.Name = "Label4"
        Label4.Size = New Size(116, 20)
        Label4.TabIndex = 11
        Label4.Text = "Blood Type"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label5.Location = New Point(343, 167)
        Label5.Name = "Label5"
        Label5.Size = New Size(117, 20)
        Label5.TabIndex = 9
        Label5.Text = "Civil Status"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label6.Location = New Point(19, 167)
        Label6.Name = "Label6"
        Label6.Size = New Size(45, 20)
        Label6.TabIndex = 7
        Label6.Text = "Age"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label3.Location = New Point(664, 80)
        Label3.Name = "Label3"
        Label3.Size = New Size(109, 20)
        Label3.TabIndex = 5
        Label3.Text = "Last Name"
        ' 
        ' txtLastName
        ' 
        txtLastName.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLastName.Location = New Point(661, 110)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(290, 32)
        txtLastName.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label2.Location = New Point(343, 80)
        Label2.Name = "Label2"
        Label2.Size = New Size(132, 20)
        Label2.TabIndex = 3
        Label2.Text = "Middle Name"
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMiddleName.Location = New Point(340, 110)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(290, 32)
        txtMiddleName.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label1.Location = New Point(19, 80)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 20)
        Label1.TabIndex = 1
        Label1.Text = "First Name"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFirstName.Location = New Point(16, 110)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(290, 32)
        txtFirstName.TabIndex = 0
        ' 
        ' TabPage2
        ' 
        TabPage2.BackgroundImage = My.Resources.Resources.bg_img
        TabPage2.BackgroundImageLayout = ImageLayout.Stretch
        TabPage2.Controls.Add(Label17)
        TabPage2.Controls.Add(btnEmergencyContactPrevious)
        TabPage2.Controls.Add(btnEmergencyContactNext)
        TabPage2.Controls.Add(labelnum)
        TabPage2.Controls.Add(txtEmergencyContactNumber)
        TabPage2.Controls.Add(labelrel)
        TabPage2.Controls.Add(txtEmergencyContactRelationship)
        TabPage2.Controls.Add(Label15)
        TabPage2.Controls.Add(txtEmergencyContactName)
        TabPage2.Location = New Point(4, 27)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(968, 610)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Emergency Contact"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.Transparent
        Label17.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(19, 25)
        Label17.Name = "Label17"
        Label17.Size = New Size(423, 28)
        Label17.TabIndex = 25
        Label17.Text = "Emergency Contact Information"
        ' 
        ' btnEmergencyContactPrevious
        ' 
        btnEmergencyContactPrevious.FlatStyle = FlatStyle.Flat
        btnEmergencyContactPrevious.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEmergencyContactPrevious.IconChar = FontAwesome.Sharp.IconChar.AngleLeft
        btnEmergencyContactPrevious.IconColor = Color.Black
        btnEmergencyContactPrevious.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEmergencyContactPrevious.IconSize = 28
        btnEmergencyContactPrevious.ImageAlign = ContentAlignment.BottomRight
        btnEmergencyContactPrevious.Location = New Point(16, 317)
        btnEmergencyContactPrevious.Name = "btnEmergencyContactPrevious"
        btnEmergencyContactPrevious.Size = New Size(131, 40)
        btnEmergencyContactPrevious.TabIndex = 24
        btnEmergencyContactPrevious.Text = "Previous"
        btnEmergencyContactPrevious.TextImageRelation = TextImageRelation.ImageBeforeText
        btnEmergencyContactPrevious.UseVisualStyleBackColor = True
        ' 
        ' btnEmergencyContactNext
        ' 
        btnEmergencyContactNext.BackColor = Color.FromArgb(CByte(225), CByte(29), CByte(72))
        btnEmergencyContactNext.FlatAppearance.BorderSize = 0
        btnEmergencyContactNext.FlatStyle = FlatStyle.Flat
        btnEmergencyContactNext.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEmergencyContactNext.IconChar = FontAwesome.Sharp.IconChar.AngleRight
        btnEmergencyContactNext.IconColor = Color.Black
        btnEmergencyContactNext.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnEmergencyContactNext.IconSize = 28
        btnEmergencyContactNext.ImageAlign = ContentAlignment.BottomRight
        btnEmergencyContactNext.Location = New Point(854, 317)
        btnEmergencyContactNext.Name = "btnEmergencyContactNext"
        btnEmergencyContactNext.Size = New Size(94, 40)
        btnEmergencyContactNext.TabIndex = 23
        btnEmergencyContactNext.Text = "Next"
        btnEmergencyContactNext.TextImageRelation = TextImageRelation.TextBeforeImage
        btnEmergencyContactNext.UseVisualStyleBackColor = False
        ' 
        ' labelnum
        ' 
        labelnum.AutoSize = True
        labelnum.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        labelnum.Location = New Point(19, 244)
        labelnum.Name = "labelnum"
        labelnum.Size = New Size(163, 20)
        labelnum.TabIndex = 19
        labelnum.Text = "Contact Number"
        ' 
        ' txtEmergencyContactNumber
        ' 
        txtEmergencyContactNumber.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmergencyContactNumber.Location = New Point(16, 274)
        txtEmergencyContactNumber.Name = "txtEmergencyContactNumber"
        txtEmergencyContactNumber.Size = New Size(932, 32)
        txtEmergencyContactNumber.TabIndex = 18
        ' 
        ' labelrel
        ' 
        labelrel.AutoSize = True
        labelrel.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        labelrel.Location = New Point(19, 161)
        labelrel.Name = "labelrel"
        labelrel.Size = New Size(128, 20)
        labelrel.TabIndex = 17
        labelrel.Text = "Relationship"
        ' 
        ' txtEmergencyContactRelationship
        ' 
        txtEmergencyContactRelationship.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmergencyContactRelationship.Location = New Point(16, 191)
        txtEmergencyContactRelationship.Name = "txtEmergencyContactRelationship"
        txtEmergencyContactRelationship.Size = New Size(932, 32)
        txtEmergencyContactRelationship.TabIndex = 16
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label15.Location = New Point(19, 74)
        Label15.Name = "Label15"
        Label15.Size = New Size(142, 20)
        Label15.TabIndex = 15
        Label15.Text = "Contact Name"
        ' 
        ' txtEmergencyContactName
        ' 
        txtEmergencyContactName.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmergencyContactName.Location = New Point(16, 104)
        txtEmergencyContactName.Name = "txtEmergencyContactName"
        txtEmergencyContactName.Size = New Size(932, 32)
        txtEmergencyContactName.TabIndex = 14
        ' 
        ' TabPage3
        ' 
        TabPage3.BackgroundImage = My.Resources.Resources.bg_img
        TabPage3.BackgroundImageLayout = ImageLayout.Stretch
        TabPage3.Controls.Add(lblSelectedDate)
        TabPage3.Controls.Add(txtHistoryOfSurgery)
        TabPage3.Controls.Add(txtCurrentMedication)
        TabPage3.Controls.Add(Label24)
        TabPage3.Controls.Add(Label23)
        TabPage3.Controls.Add(Label22)
        TabPage3.Controls.Add(txtAllergies)
        TabPage3.Controls.Add(cbxAssignedOB)
        TabPage3.Controls.Add(Label21)
        TabPage3.Controls.Add(btnMedicalInformationPrevious)
        TabPage3.Controls.Add(rbtnNo)
        TabPage3.Controls.Add(rtbnYes)
        TabPage3.Controls.Add(Label20)
        TabPage3.Controls.Add(clrLastMenstrual)
        TabPage3.Controls.Add(Label19)
        TabPage3.Controls.Add(Label18)
        TabPage3.Location = New Point(4, 27)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(968, 610)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Medical Information"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' lblSelectedDate
        ' 
        lblSelectedDate.AutoSize = True
        lblSelectedDate.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        lblSelectedDate.Location = New Point(20, 326)
        lblSelectedDate.Name = "lblSelectedDate"
        lblSelectedDate.Size = New Size(66, 20)
        lblSelectedDate.TabIndex = 35
        lblSelectedDate.Text = "Date: "
        ' 
        ' txtHistoryOfSurgery
        ' 
        txtHistoryOfSurgery.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtHistoryOfSurgery.Location = New Point(331, 415)
        txtHistoryOfSurgery.MinimumSize = New Size(0, 100)
        txtHistoryOfSurgery.Name = "txtHistoryOfSurgery"
        txtHistoryOfSurgery.Size = New Size(621, 100)
        txtHistoryOfSurgery.TabIndex = 34
        ' 
        ' txtCurrentMedication
        ' 
        txtCurrentMedication.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCurrentMedication.Location = New Point(331, 264)
        txtCurrentMedication.MinimumSize = New Size(0, 100)
        txtCurrentMedication.Name = "txtCurrentMedication"
        txtCurrentMedication.Size = New Size(621, 100)
        txtCurrentMedication.TabIndex = 33
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label24.Location = New Point(331, 392)
        Label24.Name = "Label24"
        Label24.Size = New Size(183, 20)
        Label24.TabIndex = 32
        Label24.Text = "History of Surgery"
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label23.Location = New Point(331, 241)
        Label23.Name = "Label23"
        Label23.Size = New Size(190, 20)
        Label23.TabIndex = 31
        Label23.Text = "Current Medication"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label22.Location = New Point(331, 81)
        Label22.Name = "Label22"
        Label22.Size = New Size(169, 20)
        Label22.TabIndex = 30
        Label22.Text = "Allergies (if any)"
        ' 
        ' txtAllergies
        ' 
        txtAllergies.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAllergies.Location = New Point(331, 110)
        txtAllergies.MinimumSize = New Size(0, 100)
        txtAllergies.Name = "txtAllergies"
        txtAllergies.Size = New Size(621, 100)
        txtAllergies.TabIndex = 29
        ' 
        ' cbxAssignedOB
        ' 
        cbxAssignedOB.AutoCompleteMode = AutoCompleteMode.Suggest
        cbxAssignedOB.AutoCompleteSource = AutoCompleteSource.ListItems
        cbxAssignedOB.Font = New Font("Verdana", 12F)
        cbxAssignedOB.FormattingEnabled = True
        cbxAssignedOB.Location = New Point(20, 482)
        cbxAssignedOB.Name = "cbxAssignedOB"
        cbxAssignedOB.Size = New Size(262, 33)
        cbxAssignedOB.TabIndex = 28
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label21.Location = New Point(20, 448)
        Label21.Name = "Label21"
        Label21.Size = New Size(177, 20)
        Label21.TabIndex = 27
        Label21.Text = "Assigned OB-GYN"
        ' 
        ' btnMedicalInformationPrevious
        ' 
        btnMedicalInformationPrevious.FlatStyle = FlatStyle.Flat
        btnMedicalInformationPrevious.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMedicalInformationPrevious.IconChar = FontAwesome.Sharp.IconChar.AngleLeft
        btnMedicalInformationPrevious.IconColor = Color.Black
        btnMedicalInformationPrevious.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnMedicalInformationPrevious.IconSize = 28
        btnMedicalInformationPrevious.ImageAlign = ContentAlignment.BottomRight
        btnMedicalInformationPrevious.Location = New Point(20, 553)
        btnMedicalInformationPrevious.Name = "btnMedicalInformationPrevious"
        btnMedicalInformationPrevious.Size = New Size(131, 40)
        btnMedicalInformationPrevious.TabIndex = 26
        btnMedicalInformationPrevious.Text = "Previous"
        btnMedicalInformationPrevious.TextImageRelation = TextImageRelation.ImageBeforeText
        btnMedicalInformationPrevious.UseVisualStyleBackColor = True
        ' 
        ' rbtnNo
        ' 
        rbtnNo.AutoSize = True
        rbtnNo.Font = New Font("Verdana", 10.8F)
        rbtnNo.Location = New Point(111, 398)
        rbtnNo.Name = "rbtnNo"
        rbtnNo.Size = New Size(55, 26)
        rbtnNo.TabIndex = 20
        rbtnNo.TabStop = True
        rbtnNo.Text = "No"
        rbtnNo.UseVisualStyleBackColor = True
        ' 
        ' rtbnYes
        ' 
        rtbnYes.AutoSize = True
        rtbnYes.Font = New Font("Verdana", 10.8F)
        rtbnYes.Location = New Point(20, 398)
        rtbnYes.Name = "rtbnYes"
        rtbnYes.Size = New Size(61, 26)
        rtbnYes.TabIndex = 19
        rtbnYes.TabStop = True
        rtbnYes.Text = "Yes"
        rtbnYes.UseVisualStyleBackColor = True
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label20.Location = New Point(20, 369)
        Label20.Name = "Label20"
        Label20.Size = New Size(226, 20)
        Label20.TabIndex = 18
        Label20.Text = "Is this your first baby?"
        ' 
        ' clrLastMenstrual
        ' 
        clrLastMenstrual.Location = New Point(20, 110)
        clrLastMenstrual.Name = "clrLastMenstrual"
        clrLastMenstrual.TabIndex = 17
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label19.Location = New Point(20, 81)
        Label19.Name = "Label19"
        Label19.Size = New Size(216, 20)
        Label19.TabIndex = 16
        Label19.Text = "Last Menstrual Period"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(20, 24)
        Label18.Name = "Label18"
        Label18.Size = New Size(273, 28)
        Label18.TabIndex = 3
        Label18.Text = "Medical Information"
        ' 
        ' Label29
        ' 
        Label29.AutoSize = True
        Label29.Location = New Point(814, 807)
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
        Label28.Location = New Point(21, 24)
        Label28.Name = "Label28"
        Label28.Size = New Size(323, 34)
        Label28.TabIndex = 30
        Label28.Text = "Edit Patient Details"
        ' 
        ' btnUpdatePatient
        ' 
        btnUpdatePatient.BackColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        btnUpdatePatient.FlatAppearance.BorderSize = 0
        btnUpdatePatient.FlatStyle = FlatStyle.Flat
        btnUpdatePatient.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpdatePatient.IconChar = FontAwesome.Sharp.IconChar.Cloud
        btnUpdatePatient.IconColor = Color.White
        btnUpdatePatient.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnUpdatePatient.IconSize = 36
        btnUpdatePatient.ImageAlign = ContentAlignment.MiddleLeft
        btnUpdatePatient.Location = New Point(855, 22)
        btnUpdatePatient.Name = "btnUpdatePatient"
        btnUpdatePatient.Size = New Size(118, 44)
        btnUpdatePatient.TabIndex = 29
        btnUpdatePatient.Text = "SAVE"
        btnUpdatePatient.TextImageRelation = TextImageRelation.TextBeforeImage
        btnUpdatePatient.UseVisualStyleBackColor = False
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
        tabPatientEdit.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        CType(numHeight, ComponentModel.ISupportInitialize).EndInit()
        CType(numWeight, ComponentModel.ISupportInitialize).EndInit()
        CType(numAge, ComponentModel.ISupportInitialize).EndInit()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnUpdatePatient As FontAwesome.Sharp.IconButton
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents tabPatientEdit As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents numHeight As NumericUpDown
    Friend WithEvents numWeight As NumericUpDown
    Friend WithEvents cbxBloodType As ComboBox
    Friend WithEvents cbxCivilStatus As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnPersonalInformationNext As FontAwesome.Sharp.IconButton
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label17 As Label
    Friend WithEvents btnEmergencyContactPrevious As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEmergencyContactNext As FontAwesome.Sharp.IconButton
    Friend WithEvents labelnum As Label
    Friend WithEvents txtEmergencyContactNumber As TextBox
    Friend WithEvents labelrel As Label
    Friend WithEvents txtEmergencyContactRelationship As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtEmergencyContactName As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents lblSelectedDate As Label
    Friend WithEvents txtHistoryOfSurgery As TextBox
    Friend WithEvents txtCurrentMedication As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtAllergies As TextBox
    Friend WithEvents cbxAssignedOB As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents btnMedicalInformationPrevious As FontAwesome.Sharp.IconButton
    Friend WithEvents rbtnNo As RadioButton
    Friend WithEvents rtbnYes As RadioButton
    Friend WithEvents Label20 As Label
    Friend WithEvents clrLastMenstrual As MonthCalendar
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblPatientName As Label
    Friend WithEvents numAge As NumericUpDown
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtFirstName As TextBox
End Class
