<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountantRegistration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountantRegistration))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        Label7 = New Label()
        tabAccountantRegistration = New TabControl()
        TabPage1 = New TabPage()
        btnEyeConfirmPassword = New FontAwesome.Sharp.IconButton()
        btnEyePassword = New FontAwesome.Sharp.IconButton()
        btnAccountInformationNext = New FontAwesome.Sharp.IconButton()
        Label17 = New Label()
        labelnum = New Label()
        txtConfirmPassword = New TextBox()
        labelrel = New Label()
        txtPassword = New TextBox()
        Label15 = New Label()
        txtUsername = New TextBox()
        TabPage2 = New TabPage()
        cmbPosition = New ComboBox()
        btnPersonalInformationPrevious = New FontAwesome.Sharp.IconButton()
        btnPersonalInformationNext = New FontAwesome.Sharp.IconButton()
        txtGender = New TextBox()
        Label4 = New Label()
        numAge = New NumericUpDown()
        Label8 = New Label()
        Label9 = New Label()
        Label16 = New Label()
        Label3 = New Label()
        txtLastName = New TextBox()
        Label2 = New Label()
        txtMiddleName = New TextBox()
        Label1 = New Label()
        txtFirstName = New TextBox()
        TabPage3 = New TabPage()
        btnContactInformationPrevious = New FontAwesome.Sharp.IconButton()
        btnRegisterAccountant = New FontAwesome.Sharp.IconButton()
        Label5 = New Label()
        Label11 = New Label()
        txtEmailAddress = New TextBox()
        Label12 = New Label()
        txtContactNumber = New TextBox()
        Label10 = New Label()
        txtAddress = New TextBox()
        Panel1.SuspendLayout()
        tabAccountantRegistration.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        CType(numAge, ComponentModel.ISupportInitialize).BeginInit()
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
        HopeForm1.Text = "Accountant Registration"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackgroundImage = My.Resources.Resources.bg_img
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(tabAccountantRegistration)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1000, 520)
        Panel1.TabIndex = 2
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(12, 21)
        Label7.Name = "Label7"
        Label7.Size = New Size(396, 28)
        Label7.TabIndex = 3
        Label7.Text = "Accountant Registration Form"
        ' 
        ' tabAccountantRegistration
        ' 
        tabAccountantRegistration.Controls.Add(TabPage1)
        tabAccountantRegistration.Controls.Add(TabPage2)
        tabAccountantRegistration.Controls.Add(TabPage3)
        tabAccountantRegistration.ImeMode = ImeMode.NoControl
        tabAccountantRegistration.Location = New Point(12, 55)
        tabAccountantRegistration.Name = "tabAccountantRegistration"
        tabAccountantRegistration.SelectedIndex = 0
        tabAccountantRegistration.Size = New Size(976, 453)
        tabAccountantRegistration.SizeMode = TabSizeMode.Fixed
        tabAccountantRegistration.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.BackgroundImage = My.Resources.Resources.bg_img
        TabPage1.BackgroundImageLayout = ImageLayout.Stretch
        TabPage1.Controls.Add(btnEyeConfirmPassword)
        TabPage1.Controls.Add(btnEyePassword)
        TabPage1.Controls.Add(btnAccountInformationNext)
        TabPage1.Controls.Add(Label17)
        TabPage1.Controls.Add(labelnum)
        TabPage1.Controls.Add(txtConfirmPassword)
        TabPage1.Controls.Add(labelrel)
        TabPage1.Controls.Add(txtPassword)
        TabPage1.Controls.Add(Label15)
        TabPage1.Controls.Add(txtUsername)
        TabPage1.Location = New Point(4, 29)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(968, 420)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Account Information"
        TabPage1.UseVisualStyleBackColor = True
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
        btnEyeConfirmPassword.Location = New Point(920, 277)
        btnEyeConfirmPassword.Name = "btnEyeConfirmPassword"
        btnEyeConfirmPassword.Size = New Size(32, 32)
        btnEyeConfirmPassword.TabIndex = 42
        btnEyeConfirmPassword.UseVisualStyleBackColor = False
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
        btnEyePassword.Location = New Point(920, 192)
        btnEyePassword.Name = "btnEyePassword"
        btnEyePassword.Size = New Size(32, 32)
        btnEyePassword.TabIndex = 41
        btnEyePassword.UseVisualStyleBackColor = False
        ' 
        ' btnAccountInformationNext
        ' 
        btnAccountInformationNext.BackColor = Color.Transparent
        btnAccountInformationNext.FlatStyle = FlatStyle.Flat
        btnAccountInformationNext.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAccountInformationNext.IconChar = FontAwesome.Sharp.IconChar.AngleRight
        btnAccountInformationNext.IconColor = Color.Black
        btnAccountInformationNext.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnAccountInformationNext.IconSize = 28
        btnAccountInformationNext.ImageAlign = ContentAlignment.BottomRight
        btnAccountInformationNext.Location = New Point(810, 345)
        btnAccountInformationNext.Name = "btnAccountInformationNext"
        btnAccountInformationNext.Size = New Size(94, 40)
        btnAccountInformationNext.TabIndex = 40
        btnAccountInformationNext.Text = "Next"
        btnAccountInformationNext.TextImageRelation = TextImageRelation.TextBeforeImage
        btnAccountInformationNext.UseVisualStyleBackColor = False
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.Transparent
        Label17.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(23, 26)
        Label17.Name = "Label17"
        Label17.Size = New Size(279, 28)
        Label17.TabIndex = 39
        Label17.Text = "Account Information"
        ' 
        ' labelnum
        ' 
        labelnum.AutoSize = True
        labelnum.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        labelnum.Location = New Point(23, 245)
        labelnum.Name = "labelnum"
        labelnum.Size = New Size(182, 20)
        labelnum.TabIndex = 38
        labelnum.Text = "Confirm Password"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtConfirmPassword.Location = New Point(20, 275)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(894, 32)
        txtConfirmPassword.TabIndex = 37
        txtConfirmPassword.UseSystemPasswordChar = True
        ' 
        ' labelrel
        ' 
        labelrel.AutoSize = True
        labelrel.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        labelrel.Location = New Point(23, 162)
        labelrel.Name = "labelrel"
        labelrel.Size = New Size(101, 20)
        labelrel.TabIndex = 36
        labelrel.Text = "Password"
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(20, 192)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(894, 32)
        txtPassword.TabIndex = 35
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label15.Location = New Point(23, 75)
        Label15.Name = "Label15"
        Label15.Size = New Size(104, 20)
        Label15.TabIndex = 34
        Label15.Text = "Username"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(20, 105)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(894, 32)
        txtUsername.TabIndex = 33
        ' 
        ' TabPage2
        ' 
        TabPage2.BackgroundImage = My.Resources.Resources.bg_img
        TabPage2.BackgroundImageLayout = ImageLayout.Stretch
        TabPage2.Controls.Add(cmbPosition)
        TabPage2.Controls.Add(btnPersonalInformationPrevious)
        TabPage2.Controls.Add(btnPersonalInformationNext)
        TabPage2.Controls.Add(txtGender)
        TabPage2.Controls.Add(Label4)
        TabPage2.Controls.Add(numAge)
        TabPage2.Controls.Add(Label8)
        TabPage2.Controls.Add(Label9)
        TabPage2.Controls.Add(Label16)
        TabPage2.Controls.Add(Label3)
        TabPage2.Controls.Add(txtLastName)
        TabPage2.Controls.Add(Label2)
        TabPage2.Controls.Add(txtMiddleName)
        TabPage2.Controls.Add(Label1)
        TabPage2.Controls.Add(txtFirstName)
        TabPage2.Location = New Point(4, 29)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(968, 420)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Personal Information"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' cmbPosition
        ' 
        cmbPosition.Font = New Font("Verdana", 12F)
        cmbPosition.FormattingEnabled = True
        cmbPosition.Items.AddRange(New Object() {"Accountant", "Junior Accountant", "Senior Accountant"})
        cmbPosition.Location = New Point(16, 304)
        cmbPosition.Name = "cmbPosition"
        cmbPosition.Size = New Size(937, 33)
        cmbPosition.TabIndex = 40
        ' 
        ' btnPersonalInformationPrevious
        ' 
        btnPersonalInformationPrevious.FlatStyle = FlatStyle.Flat
        btnPersonalInformationPrevious.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPersonalInformationPrevious.IconChar = FontAwesome.Sharp.IconChar.AngleLeft
        btnPersonalInformationPrevious.IconColor = Color.Black
        btnPersonalInformationPrevious.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPersonalInformationPrevious.IconSize = 28
        btnPersonalInformationPrevious.ImageAlign = ContentAlignment.BottomRight
        btnPersonalInformationPrevious.Location = New Point(36, 362)
        btnPersonalInformationPrevious.Name = "btnPersonalInformationPrevious"
        btnPersonalInformationPrevious.Size = New Size(131, 40)
        btnPersonalInformationPrevious.TabIndex = 39
        btnPersonalInformationPrevious.Text = "Previous"
        btnPersonalInformationPrevious.TextImageRelation = TextImageRelation.ImageBeforeText
        btnPersonalInformationPrevious.UseVisualStyleBackColor = True
        ' 
        ' btnPersonalInformationNext
        ' 
        btnPersonalInformationNext.BackColor = Color.Transparent
        btnPersonalInformationNext.FlatStyle = FlatStyle.Flat
        btnPersonalInformationNext.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPersonalInformationNext.IconChar = FontAwesome.Sharp.IconChar.AngleRight
        btnPersonalInformationNext.IconColor = Color.Black
        btnPersonalInformationNext.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPersonalInformationNext.IconSize = 28
        btnPersonalInformationNext.ImageAlign = ContentAlignment.BottomRight
        btnPersonalInformationNext.Location = New Point(838, 362)
        btnPersonalInformationNext.Name = "btnPersonalInformationNext"
        btnPersonalInformationNext.Size = New Size(94, 40)
        btnPersonalInformationNext.TabIndex = 38
        btnPersonalInformationNext.Text = "Next"
        btnPersonalInformationNext.TextImageRelation = TextImageRelation.TextBeforeImage
        btnPersonalInformationNext.UseVisualStyleBackColor = False
        ' 
        ' txtGender
        ' 
        txtGender.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtGender.Location = New Point(508, 207)
        txtGender.Name = "txtGender"
        txtGender.Size = New Size(445, 32)
        txtGender.TabIndex = 37
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label4.Location = New Point(21, 271)
        Label4.Name = "Label4"
        Label4.Size = New Size(87, 20)
        Label4.TabIndex = 36
        Label4.Text = "Position"
        ' 
        ' numAge
        ' 
        numAge.Font = New Font("Verdana", 12F)
        numAge.Location = New Point(18, 208)
        numAge.Name = "numAge"
        numAge.Size = New Size(445, 32)
        numAge.TabIndex = 33
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label8.Location = New Point(511, 177)
        Label8.Name = "Label8"
        Label8.Size = New Size(77, 20)
        Label8.TabIndex = 32
        Label8.Text = "Gender"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label9.Location = New Point(21, 177)
        Label9.Name = "Label9"
        Label9.Size = New Size(45, 20)
        Label9.TabIndex = 31
        Label9.Text = "Age"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = Color.Transparent
        Label16.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(21, 31)
        Label16.Name = "Label16"
        Label16.Size = New Size(287, 28)
        Label16.TabIndex = 30
        Label16.Text = "Personal Information"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label3.Location = New Point(666, 84)
        Label3.Name = "Label3"
        Label3.Size = New Size(109, 20)
        Label3.TabIndex = 29
        Label3.Text = "Last Name"
        ' 
        ' txtLastName
        ' 
        txtLastName.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLastName.Location = New Point(663, 114)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(290, 32)
        txtLastName.TabIndex = 28
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label2.Location = New Point(345, 84)
        Label2.Name = "Label2"
        Label2.Size = New Size(132, 20)
        Label2.TabIndex = 27
        Label2.Text = "Middle Name"
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMiddleName.Location = New Point(342, 114)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(290, 32)
        txtMiddleName.TabIndex = 26
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label1.Location = New Point(21, 84)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 20)
        Label1.TabIndex = 25
        Label1.Text = "First Name"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFirstName.Location = New Point(18, 114)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(290, 32)
        txtFirstName.TabIndex = 24
        ' 
        ' TabPage3
        ' 
        TabPage3.BackgroundImage = My.Resources.Resources.bg_img
        TabPage3.BackgroundImageLayout = ImageLayout.Stretch
        TabPage3.Controls.Add(btnContactInformationPrevious)
        TabPage3.Controls.Add(btnRegisterAccountant)
        TabPage3.Controls.Add(Label5)
        TabPage3.Controls.Add(Label11)
        TabPage3.Controls.Add(txtEmailAddress)
        TabPage3.Controls.Add(Label12)
        TabPage3.Controls.Add(txtContactNumber)
        TabPage3.Controls.Add(Label10)
        TabPage3.Controls.Add(txtAddress)
        TabPage3.Location = New Point(4, 29)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(968, 420)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Contact Information"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' btnContactInformationPrevious
        ' 
        btnContactInformationPrevious.FlatStyle = FlatStyle.Flat
        btnContactInformationPrevious.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnContactInformationPrevious.IconChar = FontAwesome.Sharp.IconChar.AngleLeft
        btnContactInformationPrevious.IconColor = Color.Black
        btnContactInformationPrevious.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnContactInformationPrevious.IconSize = 28
        btnContactInformationPrevious.ImageAlign = ContentAlignment.BottomRight
        btnContactInformationPrevious.Location = New Point(26, 356)
        btnContactInformationPrevious.Name = "btnContactInformationPrevious"
        btnContactInformationPrevious.Size = New Size(131, 40)
        btnContactInformationPrevious.TabIndex = 33
        btnContactInformationPrevious.Text = "Previous"
        btnContactInformationPrevious.TextImageRelation = TextImageRelation.ImageBeforeText
        btnContactInformationPrevious.UseVisualStyleBackColor = True
        ' 
        ' btnRegisterAccountant
        ' 
        btnRegisterAccountant.BackColor = Color.FromArgb(CByte(225), CByte(29), CByte(72))
        btnRegisterAccountant.FlatAppearance.BorderSize = 0
        btnRegisterAccountant.FlatStyle = FlatStyle.Flat
        btnRegisterAccountant.Font = New Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegisterAccountant.IconChar = FontAwesome.Sharp.IconChar.AngleRight
        btnRegisterAccountant.IconColor = Color.Black
        btnRegisterAccountant.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnRegisterAccountant.IconSize = 28
        btnRegisterAccountant.ImageAlign = ContentAlignment.BottomRight
        btnRegisterAccountant.Location = New Point(717, 356)
        btnRegisterAccountant.Name = "btnRegisterAccountant"
        btnRegisterAccountant.Size = New Size(224, 40)
        btnRegisterAccountant.TabIndex = 32
        btnRegisterAccountant.Text = "Register Accountant"
        btnRegisterAccountant.TextImageRelation = TextImageRelation.TextBeforeImage
        btnRegisterAccountant.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(20, 29)
        Label5.Name = "Label5"
        Label5.Size = New Size(273, 28)
        Label5.TabIndex = 31
        Label5.Text = "Contact Information"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label11.Location = New Point(516, 247)
        Label11.Name = "Label11"
        Label11.Size = New Size(144, 20)
        Label11.TabIndex = 27
        Label11.Text = "Email Address"
        ' 
        ' txtEmailAddress
        ' 
        txtEmailAddress.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmailAddress.Location = New Point(513, 277)
        txtEmailAddress.Name = "txtEmailAddress"
        txtEmailAddress.Size = New Size(445, 32)
        txtEmailAddress.TabIndex = 26
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label12.Location = New Point(26, 247)
        Label12.Name = "Label12"
        Label12.Size = New Size(163, 20)
        Label12.TabIndex = 25
        Label12.Text = "Contact Number"
        ' 
        ' txtContactNumber
        ' 
        txtContactNumber.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtContactNumber.Location = New Point(23, 277)
        txtContactNumber.Name = "txtContactNumber"
        txtContactNumber.Size = New Size(445, 32)
        txtContactNumber.TabIndex = 24
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Verdana", 10.2F, FontStyle.Bold)
        Label10.Location = New Point(26, 84)
        Label10.Name = "Label10"
        Label10.Size = New Size(85, 20)
        Label10.TabIndex = 23
        Label10.Text = "Address"
        ' 
        ' txtAddress
        ' 
        txtAddress.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAddress.Location = New Point(23, 114)
        txtAddress.MinimumSize = New Size(0, 100)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(935, 100)
        txtAddress.TabIndex = 22
        ' 
        ' AccountantRegistration
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        ClientSize = New Size(1000, 560)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(190, 40)
        Name = "AccountantRegistration"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AccountantRegistration"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        tabAccountantRegistration.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        CType(numAge, ComponentModel.ISupportInitialize).EndInit()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents tabAccountantRegistration As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnEyeConfirmPassword As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEyePassword As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAccountInformationNext As FontAwesome.Sharp.IconButton
    Friend WithEvents Label17 As Label
    Friend WithEvents labelnum As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents labelrel As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnPersonalInformationPrevious As FontAwesome.Sharp.IconButton
    Friend WithEvents btnPersonalInformationNext As FontAwesome.Sharp.IconButton
    Friend WithEvents txtGender As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents numAge As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnContactInformationPrevious As FontAwesome.Sharp.IconButton
    Friend WithEvents btnRegisterAccountant As FontAwesome.Sharp.IconButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents cmbPosition As ComboBox
End Class
