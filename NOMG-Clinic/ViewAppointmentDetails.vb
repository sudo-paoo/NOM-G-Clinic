Public Class ViewAppointmentDetails
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        calAppointmentDate.Enabled = False

        cboDoctor.Enabled = False
        cboTimeSlot.Enabled = False
        cboAppointmentType.Enabled = False

        txtNotes.Enabled = False
    End Sub

End Class