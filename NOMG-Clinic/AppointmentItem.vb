Public Class AppointmentItem
    Inherits UserControl

    Private lblInitials As New Label()
    Private lblName As New Label()
    Private lblDetails As New Label()
    Private lblDoctor As New Label()

    Public Sub New(initials As String, name As String, time As String, apptType As String, doctor As String)
        Me.Height = 60
        Me.Width = 600 ' Adjust based on FlowLayoutPanel
        Me.Margin = New Padding(5)
        Me.BackColor = Color.White

        ' Initials circle
        lblInitials.Text = initials
        lblInitials.Size = New Size(40, 40)
        lblInitials.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblInitials.TextAlign = ContentAlignment.MiddleCenter
        lblInitials.BackColor = Color.LightGray
        lblInitials.ForeColor = Color.Black
        lblInitials.Location = New Point(10, 10)
        lblInitials.BorderStyle = BorderStyle.None
        Dim circlePath As New Drawing2D.GraphicsPath()
        circlePath.AddEllipse(0, 0, lblInitials.Width, lblInitials.Height)
        lblInitials.Region = New Region(circlePath)

        ' Name
        lblName.Text = name
        lblName.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblName.AutoSize = True
        lblName.Location = New Point(60, 8)

        ' Time and Type
        lblDetails.Text = $"{time} - {apptType}"
        lblDetails.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblDetails.ForeColor = Color.Gray
        lblDetails.AutoSize = True
        lblDetails.Location = New Point(60, 30)

        ' Doctor label
        lblDoctor.Text = doctor
        lblDoctor.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblDoctor.Anchor = AnchorStyles.Right
        lblDoctor.AutoSize = True
        lblDoctor.Location = New Point(Me.Width - 200, 20)

        ' Add controls
        Me.Controls.Add(lblInitials)
        Me.Controls.Add(lblName)
        Me.Controls.Add(lblDetails)
        Me.Controls.Add(lblDoctor)
    End Sub
End Class
