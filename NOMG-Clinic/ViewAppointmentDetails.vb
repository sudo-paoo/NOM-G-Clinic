Imports MySql.Data.MySqlClient

Public Class ViewAppointmentDetails
    Public Property AppointmentID As String
    Public Property PatientID As String
    Private PatientName As String = ""
    Private DoctorID As String = ""
    Private DoctorName As String = ""
    Private LastMenstrualDate As Date = Date.MinValue
    Private DueDate As Date = Date.MinValue
    Private LastVisitDate As Date? = Nothing
    Private AppointmentDate As Date = Date.MinValue
    Private AppointmentTime As String = ""
    Private AppointmentType As String = ""
    Private Notes As String = ""
    Private Status As String = ""
    Private GestationalAge As String = ""

    Private conn As MySqlConnection
    Private cmd As MySqlCommand

    Private Sub ViewAppointmentDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DisableAllControls()
        LoadAppointmentDetails()
    End Sub

    Private Sub LoadAppointmentDetails()
        Try
            conn = New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
            conn.Open()

            Dim query As String = "
            SELECT 
                a.appointment_date, 
                a.appointment_time, 
                a.reason_for_visit, 
                a.status, 
                a.notes,
                a.doctor_id,
                CONCAT('Dr. ', d.first_name, ' ', d.last_name) AS doctor_name,
                CONCAT(p.first_name, ' ', p.last_name) AS patient_name,
                p.last_menstrual_period,
                p.due_date,
                p.flu_vac,
                (SELECT MAX(appointment_date) FROM appointment_table 
                 WHERE patient_id = @patientID AND appointment_date < a.appointment_date) AS last_visit_date
            FROM 
                appointment_table a
            JOIN 
                patient p ON a.patient_id = p.patient_id
            JOIN 
                doctor d ON a.doctor_id = d.doctor_id
            WHERE 
                a.appointment_id = @appointmentID"

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@appointmentID", AppointmentID)
            cmd.Parameters.AddWithValue("@patientID", PatientID)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    PatientName = reader("patient_name").ToString()
                    DoctorID = reader("doctor_id").ToString()
                    DoctorName = reader("doctor_name").ToString()
                    AppointmentType = reader("reason_for_visit").ToString()
                    Status = reader("status").ToString()
                    Notes = reader("notes").ToString()

                    ' Check flu vaccination status
                    Dim fluVacStatus As Boolean = False
                    If Not reader.IsDBNull(reader.GetOrdinal("flu_vac")) Then
                        fluVacStatus = Convert.ToInt32(reader("flu_vac")) = 1
                    End If

                    If fluVacStatus Then
                        lblFluVac.Text = "Vaccinated"
                        lblFluVac.ForeColor = Color.Green
                    Else
                        lblFluVac.Text = "Not Vaccinated"
                        lblFluVac.ForeColor = Color.Red
                    End If

                    ' Parse dates
                    If Not reader.IsDBNull(reader.GetOrdinal("appointment_date")) Then
                        AppointmentDate = Convert.ToDateTime(reader("appointment_date"))
                    End If

                    AppointmentTime = reader("appointment_time").ToString()

                    If Not reader.IsDBNull(reader.GetOrdinal("last_menstrual_period")) Then
                        LastMenstrualDate = Convert.ToDateTime(reader("last_menstrual_period"))
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("due_date")) Then
                        DueDate = Convert.ToDateTime(reader("due_date"))
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("last_visit_date")) Then
                        LastVisitDate = Convert.ToDateTime(reader("last_visit_date"))
                    End If
                End If
            End Using

            ' Calculate gestational age
            If LastMenstrualDate <> Date.MinValue Then
                Dim gestationalDays As Integer = DateDiff(DateInterval.Day, LastMenstrualDate, DateTime.Now)
                Dim weeks As Integer = gestationalDays \ 7
                Dim days As Integer = gestationalDays Mod 7
                GestationalAge = $"{weeks} weeks, {days} days"
            End If

            DisplayPatientInfo()
            DisplayAppointmentDetails()

        Catch ex As Exception
            MessageBox.Show("Error loading appointment details: " & ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub DisableAllControls()
        ' Disable all interactive controls
        calAppointmentDate.Enabled = False
        cboTimeSlot.Enabled = False
        cboDoctor.Enabled = False
        cboAppointmentType.Enabled = False

        txtNotes.ReadOnly = True
        txtNotes.Enabled = False
        txtNotes.TabStop = False

        cboTimeSlot.BackColor = SystemColors.Control
        cboDoctor.BackColor = SystemColors.Control
        cboAppointmentType.BackColor = SystemColors.Control
        txtNotes.BackColor = SystemColors.Control
    End Sub

    Private Sub DisplayPatientInfo()
        ' Display basic patient information
        lblPatientName.Text = PatientName
        lblPatientID.Text = PatientID

        If Not String.IsNullOrEmpty(GestationalAge) Then
            lblGestationalAge.Text = GestationalAge
        Else
            lblGestationalAge.Text = "Not available"
        End If

        If LastVisitDate.HasValue Then
            lblLastVisit.Text = LastVisitDate.Value.ToString("MMM dd, yyyy")
        Else
            lblLastVisit.Text = "No previous visits"
        End If

        If DueDate <> Date.MinValue Then
            lblDueDate.Text = DueDate.ToString("MMM dd, yyyy")
        Else
            lblDueDate.Text = "Not available"
        End If
    End Sub

    Private Sub DisplayAppointmentDetails()
        ' Set appointment date
        If AppointmentDate <> Date.MinValue Then
            CustomizeCalendarAppearance()

            calAppointmentDate.SetDate(AppointmentDate)
            lblSelectedDate.Text = "Appointment Date: " & AppointmentDate.ToString("MMM dd, yyyy")
        End If

        ' Set time slot
        cboTimeSlot.Items.Clear()
        If Not String.IsNullOrEmpty(AppointmentTime) Then
            Dim time As DateTime = DateTime.Parse(AppointmentTime)
            cboTimeSlot.Items.Add(time.ToString("h:mm tt"))
            cboTimeSlot.SelectedIndex = 0
        End If

        ' Set doctor
        cboDoctor.Items.Clear()
        cboDoctor.Items.Add(DoctorName)
        cboDoctor.SelectedIndex = 0

        ' Set appointment type
        cboAppointmentType.Items.Clear()
        cboAppointmentType.Items.Add(AppointmentType)
        cboAppointmentType.SelectedIndex = 0

        ' Set notes
        txtNotes.Text = Notes

        If Not String.IsNullOrEmpty(Status) Then
            txtNotes.Text = txtNotes.Text & vbCrLf & vbCrLf & "Status: " & Status
        End If
    End Sub

    Private Sub CustomizeCalendarAppearance()
        calAppointmentDate.BoldedDates = New Date() {AppointmentDate}
        AddHandler calAppointmentDate.DateSelected, AddressOf PreventDateSelection

        calAppointmentDate.ShowToday = False
        calAppointmentDate.ShowTodayCircle = False
        calAppointmentDate.BackColor = SystemColors.Control
        calAppointmentDate.TitleBackColor = SystemColors.Control

        AddHandler calAppointmentDate.DateChanged, AddressOf BlockDateChanged

        ' Change the appearance of the selection
        calAppointmentDate.TitleBackColor = Color.LightBlue
        calAppointmentDate.TrailingForeColor = Color.LightGray  ' Make other month dates appear disabled

        calAppointmentDate.CalendarDimensions = New Drawing.Size(1, 1)

        calAppointmentDate.SelectionStart = AppointmentDate
        calAppointmentDate.SelectionEnd = AppointmentDate
    End Sub

    ' Event handler to prevent date selection changes
    Private Sub PreventDateSelection(sender As Object, e As DateRangeEventArgs)
        If e.Start <> AppointmentDate Then
            calAppointmentDate.SetDate(AppointmentDate)
        End If
    End Sub

    Private Sub BlockDateChanged(sender As Object, e As DateRangeEventArgs)
        calAppointmentDate.SetDate(AppointmentDate)
    End Sub

    ' Override ProcessDialogKey to prevent keyboard navigation in the calendar
    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        If keyData = Keys.Left OrElse keyData = Keys.Right OrElse
       keyData = Keys.Up OrElse keyData = Keys.Down Then
            Return True
        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function
End Class