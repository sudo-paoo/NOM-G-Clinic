<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAppointmentDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewAppointmentDetails))
        HopeForm1 = New ReaLTaiizor.Forms.HopeForm()
        Panel1 = New Panel()
        lblFluVac = New Label()
        Label7 = New Label()
        txtNotes = New TextBox()
        lblSelectedDate = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label8 = New Label()
        Label6 = New Label()
        lblTimeSlotHeader = New Label()
        lblAppointmentHeader = New Label()
        lblDueDate = New Label()
        lblLastVisit = New Label()
        lblGestationalAge = New Label()
        lblPatientID = New Label()
        lblPatientName = New Label()
        cboAppointmentType = New ComboBox()
        cboDoctor = New ComboBox()
        cboTimeSlot = New ComboBox()
        calAppointmentDate = New MonthCalendar()
        Label9 = New Label()
        Panel1.SuspendLayout()
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
        HopeForm1.Text = "View Appointment"
        HopeForm1.ThemeColor = Color.FromArgb(CByte(236), CByte(72), CByte(153))
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.BackgroundImage = My.Resources.Resources.bg_img
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(lblFluVac)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(txtNotes)
        Panel1.Controls.Add(lblSelectedDate)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(lblTimeSlotHeader)
        Panel1.Controls.Add(lblAppointmentHeader)
        Panel1.Controls.Add(lblDueDate)
        Panel1.Controls.Add(lblLastVisit)
        Panel1.Controls.Add(lblGestationalAge)
        Panel1.Controls.Add(lblPatientID)
        Panel1.Controls.Add(lblPatientName)
        Panel1.Controls.Add(cboAppointmentType)
        Panel1.Controls.Add(cboDoctor)
        Panel1.Controls.Add(cboTimeSlot)
        Panel1.Controls.Add(calAppointmentDate)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 40)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(600, 600)
        Panel1.TabIndex = 2
        ' 
        ' lblFluVac
        ' 
        lblFluVac.AutoSize = True
        lblFluVac.BackColor = Color.Transparent
        lblFluVac.Font = New Font("Verdana", 10.2F)
        lblFluVac.Location = New Point(97, 428)
        lblFluVac.Name = "lblFluVac"
        lblFluVac.Size = New Size(66, 20)
        lblFluVac.TabIndex = 44
        lblFluVac.Text = "Notes:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Verdana", 10.2F)
        Label7.Location = New Point(12, 456)
        Label7.Name = "Label7"
        Label7.Size = New Size(66, 20)
        Label7.TabIndex = 43
        Label7.Text = "Notes:"
        ' 
        ' txtNotes
        ' 
        txtNotes.Location = New Point(12, 488)
        txtNotes.MinimumSize = New Size(0, 100)
        txtNotes.Multiline = True
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(576, 100)
        txtNotes.TabIndex = 42
        ' 
        ' lblSelectedDate
        ' 
        lblSelectedDate.AutoSize = True
        lblSelectedDate.BackColor = Color.Transparent
        lblSelectedDate.Font = New Font("Verdana", 10.2F)
        lblSelectedDate.Location = New Point(12, 400)
        lblSelectedDate.Name = "lblSelectedDate"
        lblSelectedDate.Size = New Size(137, 20)
        lblSelectedDate.TabIndex = 39
        lblSelectedDate.Text = "Selected Date:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Verdana", 10.2F)
        Label5.Location = New Point(330, 143)
        Label5.Name = "Label5"
        Label5.Size = New Size(97, 20)
        Label5.TabIndex = 38
        Label5.Text = "Due Date:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Verdana", 10.2F)
        Label4.Location = New Point(331, 109)
        Label4.Name = "Label4"
        Label4.Size = New Size(96, 20)
        Label4.TabIndex = 37
        Label4.Text = "Last Visit:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Verdana", 10.2F)
        Label3.Location = New Point(9, 143)
        Label3.Name = "Label3"
        Label3.Size = New Size(153, 20)
        Label3.TabIndex = 36
        Label3.Text = "Gestational Age:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Verdana", 10.2F)
        Label2.Location = New Point(58, 109)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 20)
        Label2.TabIndex = 35
        Label2.Text = "Patient ID:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Verdana", 10.2F)
        Label1.Location = New Point(29, 70)
        Label1.Name = "Label1"
        Label1.Size = New Size(133, 20)
        Label1.TabIndex = 34
        Label1.Text = "Patient Name:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Verdana", 10.2F)
        Label8.Location = New Point(286, 329)
        Label8.Name = "Label8"
        Label8.Size = New Size(174, 20)
        Label8.TabIndex = 33
        Label8.Text = "Appointment Type:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Verdana", 10.2F)
        Label6.Location = New Point(286, 184)
        Label6.Name = "Label6"
        Label6.Size = New Size(73, 20)
        Label6.TabIndex = 31
        Label6.Text = "Doctor:"
        ' 
        ' lblTimeSlotHeader
        ' 
        lblTimeSlotHeader.AutoSize = True
        lblTimeSlotHeader.BackColor = Color.Transparent
        lblTimeSlotHeader.Font = New Font("Verdana", 10.2F)
        lblTimeSlotHeader.Location = New Point(286, 252)
        lblTimeSlotHeader.Name = "lblTimeSlotHeader"
        lblTimeSlotHeader.Size = New Size(108, 20)
        lblTimeSlotHeader.TabIndex = 30
        lblTimeSlotHeader.Text = "Time Slots:"
        ' 
        ' lblAppointmentHeader
        ' 
        lblAppointmentHeader.AutoSize = True
        lblAppointmentHeader.BackColor = Color.Transparent
        lblAppointmentHeader.Font = New Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAppointmentHeader.Location = New Point(9, 23)
        lblAppointmentHeader.Name = "lblAppointmentHeader"
        lblAppointmentHeader.Size = New Size(242, 25)
        lblAppointmentHeader.TabIndex = 29
        lblAppointmentHeader.Text = "Appointment Details"
        ' 
        ' lblDueDate
        ' 
        lblDueDate.AutoSize = True
        lblDueDate.BackColor = Color.Transparent
        lblDueDate.Font = New Font("Verdana", 10.2F)
        lblDueDate.Location = New Point(433, 143)
        lblDueDate.Name = "lblDueDate"
        lblDueDate.Size = New Size(85, 20)
        lblDueDate.TabIndex = 28
        lblDueDate.Text = "due date"
        ' 
        ' lblLastVisit
        ' 
        lblLastVisit.AutoSize = True
        lblLastVisit.BackColor = Color.Transparent
        lblLastVisit.Font = New Font("Verdana", 10.2F)
        lblLastVisit.Location = New Point(433, 109)
        lblLastVisit.Name = "lblLastVisit"
        lblLastVisit.Size = New Size(82, 20)
        lblLastVisit.TabIndex = 27
        lblLastVisit.Text = "last visit"
        ' 
        ' lblGestationalAge
        ' 
        lblGestationalAge.AutoSize = True
        lblGestationalAge.BackColor = Color.Transparent
        lblGestationalAge.Font = New Font("Verdana", 10.2F)
        lblGestationalAge.Location = New Point(168, 143)
        lblGestationalAge.Name = "lblGestationalAge"
        lblGestationalAge.Size = New Size(141, 20)
        lblGestationalAge.TabIndex = 26
        lblGestationalAge.Text = "gestational age"
        ' 
        ' lblPatientID
        ' 
        lblPatientID.AutoSize = True
        lblPatientID.BackColor = Color.Transparent
        lblPatientID.Font = New Font("Verdana", 10.2F)
        lblPatientID.Location = New Point(168, 109)
        lblPatientID.Name = "lblPatientID"
        lblPatientID.Size = New Size(92, 20)
        lblPatientID.TabIndex = 25
        lblPatientID.Text = "patient id"
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.BackColor = Color.Transparent
        lblPatientName.Font = New Font("Verdana", 10.2F)
        lblPatientName.Location = New Point(168, 70)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.Size = New Size(124, 20)
        lblPatientName.TabIndex = 24
        lblPatientName.Text = "patient name"
        ' 
        ' cboAppointmentType
        ' 
        cboAppointmentType.FormattingEnabled = True
        cboAppointmentType.Location = New Point(286, 363)
        cboAppointmentType.Name = "cboAppointmentType"
        cboAppointmentType.Size = New Size(302, 28)
        cboAppointmentType.TabIndex = 22
        ' 
        ' cboDoctor
        ' 
        cboDoctor.FormattingEnabled = True
        cboDoctor.Location = New Point(286, 213)
        cboDoctor.Name = "cboDoctor"
        cboDoctor.Size = New Size(302, 28)
        cboDoctor.TabIndex = 21
        ' 
        ' cboTimeSlot
        ' 
        cboTimeSlot.FormattingEnabled = True
        cboTimeSlot.Location = New Point(286, 286)
        cboTimeSlot.Name = "cboTimeSlot"
        cboTimeSlot.Size = New Size(302, 28)
        cboTimeSlot.TabIndex = 20
        ' 
        ' calAppointmentDate
        ' 
        calAppointmentDate.Location = New Point(12, 184)
        calAppointmentDate.Name = "calAppointmentDate"
        calAppointmentDate.TabIndex = 19
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Verdana", 10.2F)
        Label9.Location = New Point(12, 428)
        Label9.Name = "Label9"
        Label9.Size = New Size(79, 20)
        Label9.TabIndex = 45
        Label9.Text = "Flu Vac:"
        ' 
        ' ViewAppointmentDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(255), CByte(227), CByte(241))
        ClientSize = New Size(600, 640)
        Controls.Add(Panel1)
        Controls.Add(HopeForm1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(190, 40)
        Name = "ViewAppointmentDetails"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ViewAppointmentDetails"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents HopeForm1 As ReaLTaiizor.Forms.HopeForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblSelectedDate As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTimeSlotHeader As Label
    Friend WithEvents lblAppointmentHeader As Label
    Friend WithEvents lblDueDate As Label
    Friend WithEvents lblLastVisit As Label
    Friend WithEvents lblGestationalAge As Label
    Friend WithEvents lblPatientID As Label
    Friend WithEvents lblPatientName As Label
    Friend WithEvents cboAppointmentType As ComboBox
    Friend WithEvents cboDoctor As ComboBox
    Friend WithEvents cboTimeSlot As ComboBox
    Friend WithEvents calAppointmentDate As MonthCalendar
    Friend WithEvents lblFluVac As Label
    Friend WithEvents Label9 As Label
End Class
