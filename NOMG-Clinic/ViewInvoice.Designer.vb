<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewInvoice))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        BigLabel1 = New ReaLTaiizor.Controls.BigLabel()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        InvoiceNumber = New ReaLTaiizor.Controls.BigLabel()
        HopeGroupBox1 = New ReaLTaiizor.Controls.HopeGroupBox()
        Label5 = New Label()
        DoctorEmail = New Label()
        DoctorNumber = New Label()
        DoctorAddress = New Label()
        DoctorName = New Label()
        Label15 = New Label()
        PatientEmail = New Label()
        PatientContact = New Label()
        PatientAddress = New Label()
        PatientName = New Label()
        Label7 = New Label()
        InvoiceDate = New Label()
        InvoiceDataGrid = New DataGridView()
        TotalPayment = New Label()
        HopeGroupBox1.SuspendLayout()
        CType(InvoiceDataGrid, ComponentModel.ISupportInitialize).BeginInit()
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
        HopeForm1.Name = "HopeForm1"
        HopeForm1.Size = New Size(853, 40)
        HopeForm1.TabIndex = 0
        HopeForm1.Text = "HopeForm1"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' BigLabel1
        ' 
        BigLabel1.AutoSize = True
        BigLabel1.BackColor = Color.Transparent
        BigLabel1.Font = New Font("Segoe UI", 25.0F)
        BigLabel1.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        BigLabel1.Location = New Point(12, 93)
        BigLabel1.Name = "BigLabel1"
        BigLabel1.Size = New Size(156, 57)
        BigLabel1.TabIndex = 1
        BigLabel1.Text = "Invoice"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 12.0F)
        Label1.Location = New Point(521, 75)
        Label1.Name = "Label1"
        Label1.Size = New Size(247, 28)
        Label1.TabIndex = 2
        Label1.Text = "New OB-GYN Master Clinic"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 12.0F)
        Label2.Location = New Point(521, 103)
        Label2.Name = "Label2"
        Label2.Size = New Size(235, 28)
        Label2.TabIndex = 3
        Label2.Text = "Address: San Isidro, Tarlac"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 12.0F)
        Label3.Location = New Point(521, 131)
        Label3.Name = "Label3"
        Label3.Size = New Size(246, 28)
        Label3.TabIndex = 4
        Label3.Text = "ob-gynmaster@gmail.com"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Location = New Point(159, 123)
        Label4.Name = "Label4"
        Label4.Size = New Size(32, 20)
        Label4.TabIndex = 5
        Label4.Text = "No."
        ' 
        ' InvoiceNumber
        ' 
        InvoiceNumber.BackColor = Color.Transparent
        InvoiceNumber.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        InvoiceNumber.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        InvoiceNumber.Location = New Point(185, 109)
        InvoiceNumber.Name = "InvoiceNumber"
        InvoiceNumber.Size = New Size(250, 41)
        InvoiceNumber.TabIndex = 6
        InvoiceNumber.Text = "InvoiceNumber"
        ' 
        ' HopeGroupBox1
        ' 
        HopeGroupBox1.BorderColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Controls.Add(Label5)
        HopeGroupBox1.Controls.Add(DoctorEmail)
        HopeGroupBox1.Controls.Add(DoctorNumber)
        HopeGroupBox1.Controls.Add(DoctorAddress)
        HopeGroupBox1.Controls.Add(DoctorName)
        HopeGroupBox1.Controls.Add(Label15)
        HopeGroupBox1.Controls.Add(PatientEmail)
        HopeGroupBox1.Controls.Add(PatientContact)
        HopeGroupBox1.Controls.Add(PatientAddress)
        HopeGroupBox1.Controls.Add(PatientName)
        HopeGroupBox1.Font = New Font("Segoe UI", 12.0F)
        HopeGroupBox1.ForeColor = Color.FromArgb(CByte(48), CByte(49), CByte(51))
        HopeGroupBox1.LineColor = Color.FromArgb(CByte(220), CByte(223), CByte(230))
        HopeGroupBox1.Location = New Point(0, 211)
        HopeGroupBox1.Name = "HopeGroupBox1"
        HopeGroupBox1.ShowText = False
        HopeGroupBox1.Size = New Size(855, 241)
        HopeGroupBox1.TabIndex = 7
        HopeGroupBox1.TabStop = False
        HopeGroupBox1.Text = "HopeGroupBox1"
        HopeGroupBox1.ThemeColor = Color.WhiteSmoke
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(529, 30)
        Label5.Name = "Label5"
        Label5.Size = New Size(122, 28)
        Label5.TabIndex = 20
        Label5.Text = "Assigned OB"
        ' 
        ' DoctorEmail
        ' 
        DoctorEmail.AutoSize = True
        DoctorEmail.BackColor = Color.Transparent
        DoctorEmail.Location = New Point(529, 185)
        DoctorEmail.Name = "DoctorEmail"
        DoctorEmail.Size = New Size(59, 28)
        DoctorEmail.TabIndex = 19
        DoctorEmail.Text = "email"
        ' 
        ' DoctorNumber
        ' 
        DoctorNumber.AutoSize = True
        DoctorNumber.BackColor = Color.Transparent
        DoctorNumber.Location = New Point(529, 148)
        DoctorNumber.Name = "DoctorNumber"
        DoctorNumber.Size = New Size(24, 28)
        DoctorNumber.TabIndex = 18
        DoctorNumber.Text = "#"
        ' 
        ' DoctorAddress
        ' 
        DoctorAddress.AutoSize = True
        DoctorAddress.BackColor = Color.Transparent
        DoctorAddress.Location = New Point(529, 111)
        DoctorAddress.Name = "DoctorAddress"
        DoctorAddress.Size = New Size(79, 28)
        DoctorAddress.TabIndex = 17
        DoctorAddress.Text = "address"
        ' 
        ' DoctorName
        ' 
        DoctorName.AutoSize = True
        DoctorName.BackColor = Color.Transparent
        DoctorName.Location = New Point(529, 75)
        DoctorName.Name = "DoctorName"
        DoctorName.Size = New Size(114, 28)
        DoctorName.TabIndex = 16
        DoctorName.Text = "name of OB"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(108, 30)
        Label15.Name = "Label15"
        Label15.Size = New Size(180, 28)
        Label15.TabIndex = 15
        Label15.Text = "Patient Information"
        ' 
        ' PatientEmail
        ' 
        PatientEmail.AutoSize = True
        PatientEmail.BackColor = Color.Transparent
        PatientEmail.Location = New Point(108, 185)
        PatientEmail.Name = "PatientEmail"
        PatientEmail.Size = New Size(59, 28)
        PatientEmail.TabIndex = 14
        PatientEmail.Text = "email"
        ' 
        ' PatientContact
        ' 
        PatientContact.AutoSize = True
        PatientContact.BackColor = Color.Transparent
        PatientContact.Location = New Point(108, 148)
        PatientContact.Name = "PatientContact"
        PatientContact.Size = New Size(24, 28)
        PatientContact.TabIndex = 11
        PatientContact.Text = "#"
        ' 
        ' PatientAddress
        ' 
        PatientAddress.AutoSize = True
        PatientAddress.BackColor = Color.Transparent
        PatientAddress.Location = New Point(108, 111)
        PatientAddress.Name = "PatientAddress"
        PatientAddress.Size = New Size(79, 28)
        PatientAddress.TabIndex = 10
        PatientAddress.Text = "address"
        ' 
        ' PatientName
        ' 
        PatientName.AutoSize = True
        PatientName.BackColor = Color.Transparent
        PatientName.Location = New Point(108, 75)
        PatientName.Name = "PatientName"
        PatientName.Size = New Size(202, 28)
        PatientName.TabIndex = 8
        PatientName.Text = "name of patient/biller"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Location = New Point(23, 156)
        Label7.Name = "Label7"
        Label7.Size = New Size(95, 20)
        Label7.TabIndex = 8
        Label7.Text = "Invoice Date:"
        ' 
        ' InvoiceDate
        ' 
        InvoiceDate.AutoSize = True
        InvoiceDate.BackColor = Color.Transparent
        InvoiceDate.Location = New Point(121, 156)
        InvoiceDate.Name = "InvoiceDate"
        InvoiceDate.Size = New Size(45, 20)
        InvoiceDate.TabIndex = 9
        InvoiceDate.Text = "DATE"
        ' 
        ' InvoiceDataGrid
        ' 
        InvoiceDataGrid.ColumnHeadersHeight = 29
        InvoiceDataGrid.Location = New Point(0, 511)
        InvoiceDataGrid.Name = "InvoiceDataGrid"
        InvoiceDataGrid.RowHeadersWidth = 51
        InvoiceDataGrid.Size = New Size(853, 449)
        InvoiceDataGrid.TabIndex = 0
        ' 
        ' TotalPayment
        ' 
        TotalPayment.AutoSize = True
        TotalPayment.BackColor = Color.Transparent
        TotalPayment.Font = New Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TotalPayment.Location = New Point(631, 972)
        TotalPayment.Name = "TotalPayment"
        TotalPayment.Size = New Size(146, 60)
        TotalPayment.TabIndex = 21
        TotalPayment.Text = "TOTAL"
        ' 
        ' ViewInvoice
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.bg_img
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(853, 1055)
        Controls.Add(TotalPayment)
        Controls.Add(InvoiceDataGrid)
        Controls.Add(InvoiceDate)
        Controls.Add(Label7)
        Controls.Add(HopeGroupBox1)
        Controls.Add(InvoiceNumber)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(BigLabel1)
        Controls.Add(HopeForm1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(190, 40)
        Name = "ViewInvoice"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form3"
        HopeGroupBox1.ResumeLayout(False)
        HopeGroupBox1.PerformLayout()
        CType(InvoiceDataGrid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents BigLabel1 As ReaLTaiizor.Controls.BigLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents InvoiceNumber As ReaLTaiizor.Controls.BigLabel
    Friend WithEvents HopeGroupBox1 As ReaLTaiizor.Controls.HopeGroupBox
    Friend WithEvents PatientName As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PatientEmail As Label
    Friend WithEvents PatientContact As Label
    Friend WithEvents PatientAddress As Label
    Friend WithEvents InvoiceDate As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DoctorEmail As Label
    Friend WithEvents DoctorNumber As Label
    Friend WithEvents DoctorAddress As Label
    Friend WithEvents DoctorName As Label
    Friend WithEvents InvoiceDataGrid As DataGridView
    Friend WithEvents TotalPayment As Label
End Class
