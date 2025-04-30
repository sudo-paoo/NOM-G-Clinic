<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingDetails))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        Label7 = New Label()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TextBox9 = New TextBox()
        TextBox8 = New TextBox()
        Label16 = New Label()
        Label15 = New Label()
        TabPage2 = New TabPage()
        Label14 = New Label()
        Label10 = New Label()
        TextBox7 = New TextBox()
        Label13 = New Label()
        TextBox6 = New TextBox()
        TextBox5 = New TextBox()
        TextBox4 = New TextBox()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Label12 = New Label()
        Label11 = New Label()
        btnPay = New FontAwesome.Sharp.IconButton()
        Label9 = New Label()
        Label8 = New Label()
        pnlItems = New Panel()
        dgvItems = New DataGridView()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        lblAppointmentHeader = New Label()
        lblDueDate = New Label()
        lblLastVisit = New Label()
        lblGestationalAge = New Label()
        lblPatientID = New Label()
        lblPatientName = New Label()
        Label17 = New Label()
        Label18 = New Label()
        IconButton1 = New FontAwesome.Sharp.IconButton()
        TextBox10 = New TextBox()
        Label19 = New Label()
        Panel1.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        pnlItems.SuspendLayout()
        CType(dgvItems, ComponentModel.ISupportInitialize).BeginInit()
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
        HopeForm1.Size = New Size(1250, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "Billing Details"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackgroundImage = My.Resources.Resources.bg_img
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(TabControl1)
        Panel1.Controls.Add(pnlItems)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(lblAppointmentHeader)
        Panel1.Controls.Add(lblDueDate)
        Panel1.Controls.Add(lblLastVisit)
        Panel1.Controls.Add(lblGestationalAge)
        Panel1.Controls.Add(lblPatientID)
        Panel1.Controls.Add(lblPatientName)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1250, 510)
        Panel1.TabIndex = 1
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(884, 62)
        Label7.Name = "Label7"
        Label7.Size = New Size(170, 25)
        Label7.TabIndex = 55
        Label7.Text = "Mode of Payement"
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Location = New Point(649, 90)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(575, 396)
        TabControl1.TabIndex = 54
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.LightPink
        TabPage1.Controls.Add(IconButton1)
        TabPage1.Controls.Add(Label18)
        TabPage1.Controls.Add(Label17)
        TabPage1.Controls.Add(TextBox9)
        TabPage1.Controls.Add(TextBox8)
        TabPage1.Controls.Add(Label16)
        TabPage1.Controls.Add(Label15)
        TabPage1.Location = New Point(4, 29)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(567, 363)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Cash"
        ' 
        ' TextBox9
        ' 
        TextBox9.Location = New Point(304, 73)
        TextBox9.Name = "TextBox9"
        TextBox9.Size = New Size(212, 27)
        TextBox9.TabIndex = 3
        ' 
        ' TextBox8
        ' 
        TextBox8.Location = New Point(47, 73)
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(212, 27)
        TextBox8.TabIndex = 2
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(331, 27)
        Label16.Name = "Label16"
        Label16.Size = New Size(159, 25)
        Label16.TabIndex = 1
        Label16.Text = "Amount received:"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(92, 27)
        Label15.Name = "Label15"
        Label15.Size = New Size(123, 25)
        Label15.TabIndex = 0
        Label15.Text = "Amount Due:"
        ' 
        ' TabPage2
        ' 
        TabPage2.BackColor = Color.Pink
        TabPage2.Controls.Add(TextBox10)
        TabPage2.Controls.Add(Label19)
        TabPage2.Controls.Add(Label14)
        TabPage2.Controls.Add(Label10)
        TabPage2.Controls.Add(TextBox7)
        TabPage2.Controls.Add(Label13)
        TabPage2.Controls.Add(TextBox6)
        TabPage2.Controls.Add(TextBox5)
        TabPage2.Controls.Add(TextBox4)
        TabPage2.Controls.Add(TextBox3)
        TabPage2.Controls.Add(TextBox2)
        TabPage2.Controls.Add(TextBox1)
        TabPage2.Controls.Add(Label12)
        TabPage2.Controls.Add(Label11)
        TabPage2.Controls.Add(btnPay)
        TabPage2.Controls.Add(Label9)
        TabPage2.Controls.Add(Label8)
        TabPage2.Location = New Point(4, 29)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(567, 363)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Card"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(369, 164)
        Label14.Name = "Label14"
        Label14.Size = New Size(15, 20)
        Label14.TabIndex = 63
        Label14.Text = "/"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(39, 163)
        Label10.Name = "Label10"
        Label10.Size = New Size(106, 25)
        Label10.TabIndex = 62
        Label10.Text = "CCV/Postal:"
        ' 
        ' TextBox7
        ' 
        TextBox7.Location = New Point(393, 161)
        TextBox7.Name = "TextBox7"
        TextBox7.PlaceholderText = "postal code"
        TextBox7.Size = New Size(138, 27)
        TextBox7.TabIndex = 61
        TextBox7.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(369, 126)
        Label13.Name = "Label13"
        Label13.Size = New Size(15, 20)
        Label13.TabIndex = 60
        Label13.Text = "/"
        ' 
        ' TextBox6
        ' 
        TextBox6.Location = New Point(415, 122)
        TextBox6.Name = "TextBox6"
        TextBox6.PlaceholderText = "yy"
        TextBox6.Size = New Size(97, 27)
        TextBox6.TabIndex = 59
        TextBox6.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox5
        ' 
        TextBox5.Location = New Point(216, 242)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(315, 27)
        TextBox5.TabIndex = 58
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(216, 202)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(315, 27)
        TextBox4.TabIndex = 57
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(216, 161)
        TextBox3.Name = "TextBox3"
        TextBox3.PlaceholderText = "ccv"
        TextBox3.Size = New Size(138, 27)
        TextBox3.TabIndex = 56
        TextBox3.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(238, 122)
        TextBox2.Name = "TextBox2"
        TextBox2.PlaceholderText = "mm"
        TextBox2.Size = New Size(97, 27)
        TextBox2.TabIndex = 55
        TextBox2.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(216, 82)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(315, 27)
        TextBox1.TabIndex = 54
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(39, 241)
        Label12.Name = "Label12"
        Label12.Size = New Size(162, 25)
        Label12.TabIndex = 4
        Label12.Text = "Cardholder Name:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(39, 201)
        Label11.Name = "Label11"
        Label11.Size = New Size(141, 25)
        Label11.TabIndex = 3
        Label11.Text = "Billing Address:"
        ' 
        ' btnPay
        ' 
        btnPay.Font = New Font("Verdana", 12F)
        btnPay.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        btnPay.IconColor = Color.Black
        btnPay.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPay.IconSize = 40
        btnPay.ImageAlign = ContentAlignment.BottomRight
        btnPay.Location = New Point(231, 292)
        btnPay.Name = "btnPay"
        btnPay.Size = New Size(152, 50)
        btnPay.TabIndex = 53
        btnPay.Text = "Pay Bill"
        btnPay.TextImageRelation = TextImageRelation.TextBeforeImage
        btnPay.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(39, 121)
        Label9.Name = "Label9"
        Label9.Size = New Size(144, 25)
        Label9.TabIndex = 1
        Label9.Text = "Expiration Date:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(39, 81)
        Label8.Name = "Label8"
        Label8.Size = New Size(129, 25)
        Label8.TabIndex = 0
        Label8.Text = "Card Number:"
        ' 
        ' pnlItems
        ' 
        pnlItems.Controls.Add(dgvItems)
        pnlItems.Location = New Point(13, 216)
        pnlItems.Name = "pnlItems"
        pnlItems.Size = New Size(575, 200)
        pnlItems.TabIndex = 51
        ' 
        ' dgvItems
        ' 
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvItems.Dock = DockStyle.Fill
        dgvItems.Location = New Point(0, 0)
        dgvItems.Name = "dgvItems"
        dgvItems.RowHeadersWidth = 51
        dgvItems.Size = New Size(575, 200)
        dgvItems.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(12, 188)
        Label6.Name = "Label6"
        Label6.Size = New Size(78, 25)
        Label6.TabIndex = 50
        Label6.Text = "Items"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Verdana", 10.2F)
        Label5.Location = New Point(333, 140)
        Label5.Name = "Label5"
        Label5.Size = New Size(97, 20)
        Label5.TabIndex = 49
        Label5.Text = "Due Date:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 10.2F)
        Label4.Location = New Point(334, 106)
        Label4.Name = "Label4"
        Label4.Size = New Size(96, 20)
        Label4.TabIndex = 48
        Label4.Text = "Last Visit:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Verdana", 10.2F)
        Label3.Location = New Point(12, 140)
        Label3.Name = "Label3"
        Label3.Size = New Size(153, 20)
        Label3.TabIndex = 47
        Label3.Text = "Gestational Age:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 10.2F)
        Label2.Location = New Point(61, 106)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 20)
        Label2.TabIndex = 46
        Label2.Text = "Patient ID:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Verdana", 10.2F)
        Label1.Location = New Point(32, 67)
        Label1.Name = "Label1"
        Label1.Size = New Size(133, 20)
        Label1.TabIndex = 45
        Label1.Text = "Patient Name:"
        ' 
        ' lblAppointmentHeader
        ' 
        lblAppointmentHeader.AutoSize = True
        lblAppointmentHeader.BackColor = Color.Transparent
        lblAppointmentHeader.Font = New Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAppointmentHeader.Location = New Point(12, 20)
        lblAppointmentHeader.Name = "lblAppointmentHeader"
        lblAppointmentHeader.Size = New Size(83, 25)
        lblAppointmentHeader.TabIndex = 44
        lblAppointmentHeader.Text = "Billing"
        ' 
        ' lblDueDate
        ' 
        lblDueDate.AutoSize = True
        lblDueDate.BackColor = Color.Transparent
        lblDueDate.Font = New Font("Verdana", 10.2F)
        lblDueDate.Location = New Point(436, 140)
        lblDueDate.Name = "lblDueDate"
        lblDueDate.Size = New Size(85, 20)
        lblDueDate.TabIndex = 43
        lblDueDate.Text = "due date"
        ' 
        ' lblLastVisit
        ' 
        lblLastVisit.AutoSize = True
        lblLastVisit.BackColor = Color.Transparent
        lblLastVisit.Font = New Font("Verdana", 10.2F)
        lblLastVisit.Location = New Point(436, 106)
        lblLastVisit.Name = "lblLastVisit"
        lblLastVisit.Size = New Size(82, 20)
        lblLastVisit.TabIndex = 42
        lblLastVisit.Text = "last visit"
        ' 
        ' lblGestationalAge
        ' 
        lblGestationalAge.AutoSize = True
        lblGestationalAge.BackColor = Color.Transparent
        lblGestationalAge.Font = New Font("Verdana", 10.2F)
        lblGestationalAge.Location = New Point(171, 140)
        lblGestationalAge.Name = "lblGestationalAge"
        lblGestationalAge.Size = New Size(141, 20)
        lblGestationalAge.TabIndex = 41
        lblGestationalAge.Text = "gestational age"
        ' 
        ' lblPatientID
        ' 
        lblPatientID.AutoSize = True
        lblPatientID.BackColor = Color.Transparent
        lblPatientID.Font = New Font("Verdana", 10.2F)
        lblPatientID.Location = New Point(171, 106)
        lblPatientID.Name = "lblPatientID"
        lblPatientID.Size = New Size(92, 20)
        lblPatientID.TabIndex = 40
        lblPatientID.Text = "patient id"
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.BackColor = Color.Transparent
        lblPatientName.Font = New Font("Verdana", 10.2F)
        lblPatientName.Location = New Point(171, 67)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.Size = New Size(124, 20)
        lblPatientName.TabIndex = 39
        lblPatientName.Text = "patient name"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(44, 135)
        Label17.Name = "Label17"
        Label17.Size = New Size(78, 25)
        Label17.TabIndex = 4
        Label17.Text = "Change:"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = SystemColors.Control
        Label18.Location = New Point(136, 140)
        Label18.Name = "Label18"
        Label18.Size = New Size(15, 20)
        Label18.TabIndex = 5
        Label18.Text = "-"
        ' 
        ' IconButton1
        ' 
        IconButton1.Font = New Font("Verdana", 12F)
        IconButton1.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        IconButton1.IconColor = Color.Black
        IconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto
        IconButton1.IconSize = 40
        IconButton1.ImageAlign = ContentAlignment.BottomRight
        IconButton1.Location = New Point(205, 204)
        IconButton1.Name = "IconButton1"
        IconButton1.Size = New Size(152, 50)
        IconButton1.TabIndex = 54
        IconButton1.Text = "Pay Bill"
        IconButton1.TextImageRelation = TextImageRelation.TextBeforeImage
        IconButton1.UseVisualStyleBackColor = True
        ' 
        ' TextBox10
        ' 
        TextBox10.Location = New Point(216, 37)
        TextBox10.Name = "TextBox10"
        TextBox10.Size = New Size(315, 27)
        TextBox10.TabIndex = 65
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(39, 37)
        Label19.Name = "Label19"
        Label19.Size = New Size(123, 25)
        Label19.TabIndex = 64
        Label19.Text = "Amount Due:"
        ' 
        ' BillingDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1250, 550)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 550)
        MinimumSize = New Size(190, 40)
        Name = "BillingDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "BillingDetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        pnlItems.ResumeLayout(False)
        CType(dgvItems, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAppointmentHeader As Label
    Friend WithEvents lblDueDate As Label
    Friend WithEvents lblLastVisit As Label
    Friend WithEvents lblGestationalAge As Label
    Friend WithEvents lblPatientID As Label
    Friend WithEvents lblPatientName As Label
    Friend WithEvents pnlItems As Panel
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents btnPay As FontAwesome.Sharp.IconButton
    Friend WithEvents Label7 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label18 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label19 As Label
End Class
