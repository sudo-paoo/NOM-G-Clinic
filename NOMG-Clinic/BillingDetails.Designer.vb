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
        btnPay = New FontAwesome.Sharp.IconButton()
        lblTotal = New Label()
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
        Panel1.SuspendLayout()
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
        HopeForm1.Size = New Size(600, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "Billing Details"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources.bg_img
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(btnPay)
        Panel1.Controls.Add(lblTotal)
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
        Panel1.Size = New Size(600, 560)
        Panel1.TabIndex = 1
        ' 
        ' btnPay
        ' 
        btnPay.Font = New Font("Verdana", 12F)
        btnPay.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        btnPay.IconColor = Color.Black
        btnPay.IconFont = FontAwesome.Sharp.IconFont.Auto
        btnPay.IconSize = 40
        btnPay.ImageAlign = ContentAlignment.BottomRight
        btnPay.Location = New Point(436, 487)
        btnPay.Name = "btnPay"
        btnPay.Size = New Size(152, 50)
        btnPay.TabIndex = 53
        btnPay.Text = "Pay Bill"
        btnPay.TextImageRelation = TextImageRelation.TextBeforeImage
        btnPay.UseVisualStyleBackColor = True
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.Transparent
        lblTotal.Font = New Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotal.Location = New Point(497, 435)
        lblTotal.Name = "lblTotal"
        lblTotal.RightToLeft = RightToLeft.Yes
        lblTotal.Size = New Size(60, 25)
        lblTotal.TabIndex = 52
        lblTotal.Text = "Total"
        lblTotal.TextAlign = ContentAlignment.MiddleRight
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
        ' BillingDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(600, 600)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1020)
        MinimumSize = New Size(190, 40)
        Name = "BillingDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "BillingDetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
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
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnPay As FontAwesome.Sharp.IconButton
End Class
