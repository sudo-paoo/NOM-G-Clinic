﻿Imports MySql.Data.MySqlClient

Public Class AppointmentDetails
    Public Property PatientId As String
    Public Property PatientName As String
    Public Property LastMenstrualDate As Date
    Public Property DueDate As Date
    Public Property LastVisitDate As Date? = Nothing
    Public Property DefaultDoctorId As String = ""
    Public Property AppointmentType As String = "Initial Check-up"
    Public Property IsNewAppointment As Boolean = True
    Public Property GestationalWeeks As Integer = 0
    Public Property IsFollowUp As Boolean = False
    Public Property FollowUpReason As String = ""
    Public Property DaysLate As Integer = 0

    Private NextCheckupDays As Integer = 30
    Private ExpectedNextAppointmentDate As Date = Date.MinValue
    Private HasFluVaccination As Boolean = False
    Private MessageAlreadyShownDuringLoad As Boolean = False

    Private conn As MySqlConnection
    Private cmd As MySqlCommand

    Private Sub AppointmentDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageAlreadyShownDuringLoad = False
        lblPatientName.Text = PatientName
        lblPatientID.Text = PatientId

        If LastMenstrualDate <> Date.MinValue Then
            If GestationalWeeks = 0 Then
                Dim gestationalDays As Integer = DateDiff(DateInterval.Day, LastMenstrualDate, DateTime.Now)
                GestationalWeeks = gestationalDays \ 7
                Dim days As Integer = gestationalDays Mod 7
                lblGestationalAge.Text = $"{GestationalWeeks} weeks, {days} days"
            Else
                lblGestationalAge.Text = $"{GestationalWeeks} weeks"
            End If
        End If

        If DueDate <> Date.MinValue Then
            lblDueDate.Text = DueDate.ToString("MMM dd, yyyy")
        End If

        If LastVisitDate.HasValue Then
            lblLastVisit.Text = LastVisitDate.Value.ToString("MMMM dd, yyyy")
        Else
            lblLastVisit.Text = "No previous visits"
        End If

        cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList
        cboTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList
        cboAppointmentType.DropDownStyle = ComboBoxStyle.DropDownList

        cboAppointmentType.Items.Add("Initial Check-up")
        cboAppointmentType.Items.Add("Follow-up Check-up")

        If cboAppointmentType.Items.Contains(AppointmentType) Then
            cboAppointmentType.SelectedItem = AppointmentType
        Else
            cboAppointmentType.SelectedIndex = 0
        End If

        If IsFollowUp AndAlso Not String.IsNullOrEmpty(FollowUpReason) Then
            txtNotes.Text = "Follow-up for: " & FollowUpReason
        End If

        ConfigureCalendarForFollowUp()

        LoadDoctors()
        CheckFluVaccinationStatus()
        UpdateFluVacSwitch()

        UpdateAvailableTimeSlots()
    End Sub

    ' Check if patient has flu vaccination
    Private Sub CheckFluVaccinationStatus()
        Try
            If String.IsNullOrEmpty(PatientId) Then
                Return
            End If

            Using conn As New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
                conn.Open()

                Dim query As String = "SELECT flu_vac FROM patient WHERE patient_id = @patientId"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@patientId", PatientId)

                Dim result As Object = cmd.ExecuteScalar()
                HasFluVaccination = (result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) AndAlso Convert.ToInt32(result) = 1)
            End Using
        Catch ex As Exception
            HasFluVaccination = False
            Console.WriteLine("Error checking flu vaccination status: " & ex.Message)
        End Try
    End Sub


    Private Sub UpdateFluVacSwitch()
        hsFluVac.Visible = Not HasFluVaccination

        If Not HasFluVaccination Then
            hsFluVac.Text = "Add Flu Vaccination"
            hsFluVac.Checked = False
        End If
    End Sub

    Private Sub LoadDoctors()
        Try
            cboDoctor.Items.Clear()

            conn = New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
            conn.Open()

            Dim query As String = "SELECT doctor_id, CONCAT('Dr. ', first_name, ' ', last_name) AS full_name FROM doctor ORDER BY last_name"

            cmd = New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            Dim doctorDictionary As New Dictionary(Of String, String)

            cboDoctor.Items.Add("-- Select a doctor --")

            Dim selectedIndex As Integer = 0

            Dim index As Integer = 1

            While reader.Read()
                Dim doctorId As String = reader("doctor_id").ToString()
                Dim doctorName As String = reader("full_name").ToString()

                doctorDictionary.Add(doctorId, doctorName)

                cboDoctor.Items.Add(doctorName)

                If doctorId = DefaultDoctorId Then
                    selectedIndex = index
                End If

                index += 1
            End While

            reader.Close()

            cboDoctor.Tag = doctorDictionary

            If cboDoctor.Items.Count > 0 Then
                cboDoctor.SelectedIndex = If(selectedIndex > 0, selectedIndex, 0)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading doctors: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub UpdateAvailableTimeSlots()
        cboTimeSlot.Items.Clear()

        Dim selectedDate As Date = calAppointmentDate.SelectionStart
        Dim doctorId As String = GetSelectedDoctorId()
        Dim currentDateTime As DateTime = DateTime.Now
        Dim shouldProcessTimeSlots As Boolean = True
        Dim originalDate As Date = selectedDate ' Store original date to check if we changed it

        If String.IsNullOrEmpty(doctorId) Then
            Return
        End If

        If selectedDate.DayOfWeek = DayOfWeek.Sunday OrElse selectedDate.DayOfWeek = DayOfWeek.Monday Then
            Return
        End If

        Dim allTimeSlots As New List(Of Date)
        Dim startTime As Date = New Date(selectedDate.Year, selectedDate.Month, selectedDate.Day, 8, 0, 0)
        Dim endTime As Date = New Date(selectedDate.Year, selectedDate.Month, selectedDate.Day, 16, 0, 0)

        If selectedDate.Date = currentDateTime.Date Then
            Dim bufferTime As TimeSpan = TimeSpan.FromMinutes(30)
            Dim adjustedCurrentTime As DateTime = currentDateTime.Add(bufferTime)

            Dim nextHour As Integer = adjustedCurrentTime.Hour + 1
            If nextHour > 16 Then
                shouldProcessTimeSlots = False
            Else
                startTime = New Date(selectedDate.Year, selectedDate.Month, selectedDate.Day, nextHour, 0, 0)
            End If
        End If

        If selectedDate.Date < currentDateTime.Date Then
            calAppointmentDate.SetDate(currentDateTime.Date)
            Return
        End If

        If shouldProcessTimeSlots Then
            Dim currentTime As Date = startTime
            While currentTime <= endTime
                allTimeSlots.Add(currentTime)
                currentTime = currentTime.AddHours(1)
            End While

            Dim bookedSlots As New List(Of String)
            Try
                conn = New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
                conn.Open()

                ' Modified query to filter by doctor_id
                Dim query As String = "SELECT appointment_time FROM appointment_table " &
                 "WHERE appointment_date = @selectedDate AND doctor_id = @doctorId"

                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@doctorId", doctorId)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim timeString As String = reader("appointment_time").ToString()
                    bookedSlots.Add(timeString)
                End While

                reader.Close()
                conn.Close()
            Catch ex As Exception
                MessageBox.Show("Error retrieving appointment data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            For Each timeSlot As Date In allTimeSlots
                Dim isBooked As Boolean = False
                Dim timeString As String = timeSlot.ToString("HH:mm:ss")

                If bookedSlots.Contains(timeString) Then
                    isBooked = True
                End If

                If Not isBooked Then
                    cboTimeSlot.Items.Add(timeSlot.ToString("h:mm tt"))
                End If
            Next
        End If

        ' If no time slots are available, move to the next valid day
        If cboTimeSlot.Items.Count = 0 Then
            Dim nextDate As Date = selectedDate.AddDays(1)
            While nextDate.DayOfWeek = DayOfWeek.Sunday OrElse nextDate.DayOfWeek = DayOfWeek.Monday
                nextDate = nextDate.AddDays(1)
            End While

            ' If we're in initial form load, don't show message
            If Not MessageAlreadyShownDuringLoad AndAlso originalDate <> nextDate Then
                MessageBox.Show($"No available time slots on {selectedDate:dddd, MMMM dd, yyyy}. " &
                           $"Moving to the next available day: {nextDate:dddd, MMMM dd, yyyy}.",
                          "Finding Available Slots", MessageBoxButtons.OK, MessageBoxIcon.Information)

                MessageAlreadyShownDuringLoad = True
            End If

            calAppointmentDate.SetDate(nextDate)

            lblSelectedDate.Text = "Selected Date: " & calAppointmentDate.SelectionStart.ToString("MMMM dd, yyyy")

            Return
        ElseIf cboTimeSlot.Items.Count > 0 Then
            cboTimeSlot.SelectedIndex = 0
        End If
    End Sub

    Private Sub ConfigureCalendarForFollowUp()
        Dim minDate As Date = DateTime.Today

        If IsFollowUp AndAlso LastVisitDate.HasValue Then
            If GestationalWeeks < 12 Then
                NextCheckupDays = 30
            ElseIf GestationalWeeks < 24 Then
                NextCheckupDays = 20
            Else
                NextCheckupDays = 10
            End If

            ExpectedNextAppointmentDate = LastVisitDate.Value.AddDays(NextCheckupDays)

            If Not MessageAlreadyShownDuringLoad Then
                If DateTime.Today > ExpectedNextAppointmentDate Then
                    DaysLate = DateDiff(DateInterval.Day, ExpectedNextAppointmentDate, DateTime.Today)

                    MessageBox.Show(
                    $"Patient is {DaysLate} days late for their follow-up appointment." & vbCrLf & vbCrLf &
                    $"Expected follow-up date was {ExpectedNextAppointmentDate:MMMM dd, yyyy}." & vbCrLf &
                    $"The vitamin supply will be adjusted to {NextCheckupDays - DaysLate} days.",
                    "Late Follow-up",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                    ' Set the flag to prevent additional messages
                    MessageAlreadyShownDuringLoad = True

                    minDate = DateTime.Today
                Else
                    minDate = ExpectedNextAppointmentDate

                    MessageBox.Show(
                    $"Next follow-up should be scheduled on or after {ExpectedNextAppointmentDate:MMMM dd, yyyy}" & vbCrLf &
                    $"(+{NextCheckupDays} days from last visit).",
                    "Follow-up Schedule",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                    MessageAlreadyShownDuringLoad = True
                End If
            End If
        End If

        calAppointmentDate.MinDate = minDate

        Dim defaultDate As Date = If(minDate > DateTime.Today, minDate, DateTime.Today)

        While defaultDate.DayOfWeek = DayOfWeek.Sunday OrElse defaultDate.DayOfWeek = DayOfWeek.Monday
            defaultDate = defaultDate.AddDays(1)
        End While

        calAppointmentDate.SetDate(defaultDate)
        lblSelectedDate.Text = "Selected Date: " & calAppointmentDate.SelectionStart.ToString("MMMM dd, yyyy")
    End Sub

    Private Function IsTimeSlotAvailable(appointmentDateTime As DateTime) As Boolean
        Try
            Dim doctorId As String = GetSelectedDoctorId()

            ' Modified query to check availability for the specific doctor
            Dim query As String = "SELECT COUNT(*) FROM appointment_table " &
                         "WHERE appointment_date = @selectedDate " &
                         "AND appointment_time = @selectedTime " &
                         "AND doctor_id = @doctorId"

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@selectedDate", appointmentDateTime.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@selectedTime", appointmentDateTime.ToString("HH:mm:ss"))
            cmd.Parameters.AddWithValue("@doctorId", doctorId)

            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count = 0

        Catch ex As Exception
            MessageBox.Show("Error checking time slot availability: " & ex.Message,
                   "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Private Sub calAppointmentDate_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calAppointmentDate.DateChanged
        Dim selectedDate As Date = calAppointmentDate.SelectionStart
        Dim currentDate As Date = DateTime.Now.Date

        If selectedDate.Date < currentDate Then
            MessageBox.Show("Cannot schedule appointments for past dates. Please select today or a future date.",
                        "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            calAppointmentDate.SetDate(currentDate)
            Return
        End If

        ' Check if clinic is closed on the selected day
        If selectedDate.DayOfWeek = DayOfWeek.Sunday OrElse selectedDate.DayOfWeek = DayOfWeek.Monday Then
            MessageBox.Show("The clinic is closed on Sundays and Mondays. Please select another day.",
                        "Clinic Closed", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim nextValidDay As Date = selectedDate
            While nextValidDay.DayOfWeek = DayOfWeek.Sunday OrElse nextValidDay.DayOfWeek = DayOfWeek.Monday
                nextValidDay = nextValidDay.AddDays(1)
            End While

            calAppointmentDate.SetDate(nextValidDay)
            Return
        End If

        lblSelectedDate.Text = "Selected Date: " & calAppointmentDate.SelectionStart.ToString("MMMM dd, yyyy")

        UpdateAvailableTimeSlots()
    End Sub

    Private Sub cboDoctor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDoctor.SelectedIndexChanged
        UpdateAvailableTimeSlots()
    End Sub

    Private Sub cboAppointmentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAppointmentType.SelectedIndexChanged
        UpdateFluVacSwitch()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If Not ValidateForm() Then
            Return
        End If

        If SaveAppointment() Then
            MessageBox.Show("Appointment scheduled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Dim adminForm As AdminDashboard = TryCast(Application.OpenForms("AdminDashboard"), AdminDashboard)
            Dim doctorForm As DoctorDashboard = TryCast(Application.OpenForms("DoctorDashboard"), DoctorDashboard)
            Dim nurseForm As NurseDashboard = TryCast(Application.OpenForms("NurseDashboard"), NurseDashboard)
            If adminForm IsNot Nothing Then
                adminForm.AppointmentsSetupDataGrid()
                adminForm.AppointmentsPopulateDataGrid()
            End If
            If doctorForm IsNot Nothing Then
                doctorForm.AppointmentsSetupDataGrid()
                doctorForm.AppointmentsPopulateDataGrid()
            End If
            If nurseForm IsNot Nothing Then
                nurseForm.AppointmentsSetupDataGrid()
                nurseForm.AppointmentsPopulateDataGrid()
            End If
            Me.Close()
        End If
    End Sub

    Private Function ValidateForm() As Boolean
        If cboDoctor.SelectedIndex <= 0 Then
            MessageBox.Show("Please select a doctor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboTimeSlot.SelectedIndex < 0 Then
            MessageBox.Show("Please select an available time slot.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboAppointmentType.SelectedIndex < 0 Then
            MessageBox.Show("Please select an appointment type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function SaveAppointment() As Boolean
        Try
            conn = New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
            conn.Open()

            Dim appointmentDateTime As DateTime = CombineDateAndTime()

            If Not IsTimeSlotAvailable(appointmentDateTime) Then
                MessageBox.Show("This time slot was just booked by someone else. Please select another time.",
                       "Time Slot Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                UpdateAvailableTimeSlots()
                Return False
            End If

            Dim appointmentId As Integer = GetNextAppointmentId()
            Dim doctorId As String = GetSelectedDoctorId()

            Dim query As String = "INSERT INTO appointment_table (appointment_id, patient_id, doctor_id, " &
                             "appointment_date, appointment_time, reason_for_visit, status, notes) " &
                             "VALUES (@appointmentId, @patientId, @doctorId, @appointmentDate, " &
                             "@appointmentTime, @reason, @status, @notes)"

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@appointmentId", appointmentId)
            cmd.Parameters.AddWithValue("@patientId", PatientId)
            cmd.Parameters.AddWithValue("@doctorId", doctorId)
            cmd.Parameters.AddWithValue("@appointmentDate", appointmentDateTime.Date)
            cmd.Parameters.AddWithValue("@appointmentTime", appointmentDateTime.ToString("HH:mm:ss"))
            cmd.Parameters.AddWithValue("@reason", cboAppointmentType.Text)
            cmd.Parameters.AddWithValue("@status", "Scheduled")
            cmd.Parameters.AddWithValue("@notes", txtNotes.Text)

            cmd.ExecuteNonQuery()

            UpdatePatientAssignedOB(doctorId)
            UpdatePatientNextCheckup(appointmentDateTime)

            Dim consultationId As String = GetNextConsultationId()
            If CreateConsultationRecord(appointmentId) Then
                CreateBillingRecord(appointmentId, consultationId)
            End If

            conn.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show("Error saving appointment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    Private Function GetNextAppointmentId() As Integer
        Dim nextId As Integer = 1001
        Try
            Dim query As String = "SELECT MAX(CAST(appointment_id AS UNSIGNED)) FROM appointment_table"
            cmd = New MySqlCommand(query, conn)

            Dim result As Object = cmd.ExecuteScalar()

            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                If Integer.TryParse(result.ToString(), nextId) Then
                    nextId += 1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating appointment ID: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return nextId
    End Function

    Private Function GetSelectedDoctorId() As String
        Dim doctorId As String = String.Empty
        If cboDoctor.SelectedIndex > 0 Then
            Dim doctorDictionary As Dictionary(Of String, String) = DirectCast(cboDoctor.Tag, Dictionary(Of String, String))
            Dim selectedDoctorName As String = cboDoctor.SelectedItem.ToString()
            For Each kvp As KeyValuePair(Of String, String) In doctorDictionary
                If kvp.Value = selectedDoctorName Then
                    doctorId = kvp.Key
                    Exit For
                End If
            Next
        End If

        Return doctorId
    End Function

    Private Function CombineDateAndTime() As DateTime
        Dim selectedDate As Date = calAppointmentDate.SelectionStart
        Dim timeString As String = cboTimeSlot.SelectedItem.ToString()
        Dim selectedTime As DateTime = DateTime.Parse(timeString)
        Return New DateTime(
            selectedDate.Year,
            selectedDate.Month,
            selectedDate.Day,
            selectedTime.Hour,
            selectedTime.Minute,
            0)
    End Function

    Private Sub UpdatePatientAssignedOB(doctorId As String)
        If doctorId <> DefaultDoctorId Then
            Try
                Dim query As String = "UPDATE patient SET assigned_ob = @doctorId WHERE patient_id = @patientId"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@doctorId", doctorId)
                cmd.Parameters.AddWithValue("@patientId", PatientId)
                cmd.ExecuteNonQuery()

                DefaultDoctorId = doctorId

            Catch ex As Exception
                MessageBox.Show("Error updating patient's assigned doctor: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub UpdatePatientNextCheckup(nextCheckup As DateTime)
        Try
            Dim query As String = "UPDATE patient SET next_checkup = @nextCheckupDate, next_checkup_time = @nextCheckupTime " &
                             "WHERE patient_id = @patientId"

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@nextCheckupDate", nextCheckup.Date)
            cmd.Parameters.AddWithValue("@nextCheckupTime", nextCheckup.ToString("HH:mm:ss"))
            cmd.Parameters.AddWithValue("@patientId", PatientId)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error updating next checkup information: " & ex.Message,
                       "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CreateConsultationRecord(appointmentId As Integer) As Boolean
        Try
            Dim consultationId As String = GetNextConsultationId()
            Dim query As String = "INSERT INTO consultation " &
                             "(consultation_id, patient_id, doctor_id, consultation_date, diagnosis, notes) " &
                             "VALUES (@consultationId, @patientId, @doctorId, @consultationDate, @diagnosis, @notes)"

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@consultationId", consultationId)
            cmd.Parameters.AddWithValue("@patientId", PatientId)
            cmd.Parameters.AddWithValue("@doctorId", GetSelectedDoctorId())
            cmd.Parameters.AddWithValue("@consultationDate", CombineDateAndTime())
            cmd.Parameters.AddWithValue("@diagnosis", "Pending")
            cmd.Parameters.AddWithValue("@notes", "Initial consultation scheduled")

            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            MessageBox.Show("Error creating consultation record: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function GetNextConsultationId() As String
        Dim nextId As Integer = 1
        Try
            Dim query As String = "SELECT MAX(SUBSTRING(consultation_id, 2)) FROM consultation"
            cmd = New MySqlCommand(query, conn)

            Dim result As Object = cmd.ExecuteScalar()

            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                If Integer.TryParse(result.ToString(), nextId) Then
                    nextId += 1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating consultation ID: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return "C" & nextId.ToString("D03")
    End Function

    Private Function CreateBillingRecord(appointmentId As Integer, consultationId As String) As Boolean
        Try
            Dim billingId As String = GetNextBillingId()
            Dim appointmentType As String = cboAppointmentType.Text
            Dim totalAmount As Decimal = 0
            Dim itemCount As Integer = 0
            Dim notes As String = ""

            Dim itemsList As New List(Of Dictionary(Of String, Object))
            Dim checkupItem As New Dictionary(Of String, Object)

            If appointmentType = "Initial Check-up" Then
                checkupItem.Add("item_name", "Initial Check-up")
                checkupItem.Add("quantity", 1)
                checkupItem.Add("description", "Initial consultation fee")
                checkupItem.Add("price", 2000)
                totalAmount += 2000
                notes = "Initial consultation"
            Else
                checkupItem.Add("item_name", "Follow-up Check-up")
                checkupItem.Add("quantity", 1)
                checkupItem.Add("description", "Follow-up consultation fee")
                checkupItem.Add("price", 500)
                totalAmount += 500
                notes = "Follow-up consultation"
            End If

            itemsList.Add(checkupItem)
            itemCount += 1

            If hsFluVac.Visible AndAlso hsFluVac.Checked Then
                Dim fluVacItem As New Dictionary(Of String, Object)
                fluVacItem.Add("item_name", "Flu Vaccination")
                fluVacItem.Add("quantity", 1)
                fluVacItem.Add("description", "One-time flu vaccination during pregnancy")
                fluVacItem.Add("price", 1500)
                fluVacItem.Add("total", 1500)
                itemsList.Add(fluVacItem)
                totalAmount += 1500
                itemCount += 1
                notes += " + Flu vaccination"

                Try
                    Dim updateFluVacQuery As String = "UPDATE patient SET flu_vac = 1 WHERE patient_id = @patientId"
                    Dim updateCmd As New MySqlCommand(updateFluVacQuery, conn)
                    updateCmd.Parameters.AddWithValue("@patientId", PatientId)
                    updateCmd.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine("Error updating flu vaccination status: " & ex.Message)
                End Try
            End If

            ' Add vitamins based on gestational age for follow-up appointments
            If appointmentType = "Follow-up Check-up" Then
                Dim daysToNextVisit As Integer

                ' Calculate days to next visit based on gestational age (trimester)
                If GestationalWeeks < 12 Then
                    daysToNextVisit = 30
                ElseIf GestationalWeeks < 24 Then
                    daysToNextVisit = 20
                Else
                    daysToNextVisit = 10
                End If

                ' If patient was late, adjust vitamin supply days accordingly
                If DaysLate > 0 Then
                    Dim adjustedDays As Integer = daysToNextVisit - DaysLate
                    If adjustedDays < 1 Then adjustedDays = 1

                    daysToNextVisit = adjustedDays
                    notes += $" + {daysToNextVisit}-day vitamin supply (adjusted for {DaysLate} days late)"
                Else
                    notes += $" + {daysToNextVisit}-day vitamin supply"
                End If

                ' Add Iron vitamin details
                Dim ironItem As New Dictionary(Of String, Object)
                ironItem.Add("item_name", "Iron Vitamin")
                ironItem.Add("quantity", daysToNextVisit)
                ironItem.Add("description", "Once per day")
                ironItem.Add("price", 15)
                Dim ironTotal As Decimal = 15 * daysToNextVisit
                ironItem.Add("total", ironTotal)
                itemsList.Add(ironItem)
                totalAmount += ironTotal
                itemCount += 1

                ' Add B Complex vitamin details
                Dim bComplexItem As New Dictionary(Of String, Object)
                bComplexItem.Add("item_name", "B Complex Vitamin")
                bComplexItem.Add("quantity", daysToNextVisit)
                bComplexItem.Add("description", "Once per day")
                bComplexItem.Add("price", 25)
                Dim bComplexTotal As Decimal = 25 * daysToNextVisit
                bComplexItem.Add("total", bComplexTotal)
                itemsList.Add(bComplexItem)
                totalAmount += bComplexTotal
                itemCount += 1

                ' Add DHA vitamin details
                Dim dhaItem As New Dictionary(Of String, Object)
                dhaItem.Add("item_name", "DHA Vitamin")
                dhaItem.Add("quantity", daysToNextVisit * 3)
                dhaItem.Add("description", "Three times per day")
                dhaItem.Add("price", 20)
                Dim dhaTotal As Decimal = 20 * 3 * daysToNextVisit
                dhaItem.Add("total", dhaTotal)
                itemsList.Add(dhaItem)
                totalAmount += dhaTotal
                itemCount += 1
            End If

            Dim itemsJson As String = Newtonsoft.Json.JsonConvert.SerializeObject(itemsList)

            Dim query As String = "INSERT INTO billing " &
                    "(billing_id, patient_id, consultation_id, date, items, item_names, total_amount, status, notes) " &
                    "VALUES (@billingId, @patientId, @consultationId, @date, @items, @itemNames, @totalAmount, @status, @notes)"

            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@billingId", billingId)
            cmd.Parameters.AddWithValue("@patientId", PatientId)
            cmd.Parameters.AddWithValue("@consultationId", consultationId)
            cmd.Parameters.AddWithValue("@date", DateTime.Now)
            cmd.Parameters.AddWithValue("@items", itemCount)
            cmd.Parameters.AddWithValue("@itemNames", itemsJson)
            cmd.Parameters.AddWithValue("@totalAmount", totalAmount)
            cmd.Parameters.AddWithValue("@status", "Unpaid")
            cmd.Parameters.AddWithValue("@notes", notes)

            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            MessageBox.Show("Error creating billing record: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function GetNextBillingId() As String
        Dim nextId As Integer = 1
        Try
            Dim query As String = "SELECT MAX(SUBSTRING(billing_id, 2)) FROM billing"
            cmd = New MySqlCommand(query, conn)

            Dim result As Object = cmd.ExecuteScalar()

            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                If Integer.TryParse(result.ToString(), nextId) Then
                    nextId += 1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating billing ID: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return "B" & nextId.ToString("D03")
    End Function

    Private Sub AppointmentDetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult <> DialogResult.OK AndAlso Me.DialogResult <> DialogResult.Cancel Then
            MessageBox.Show("Please use the Submit button to complete the appointment scheduling.",
                    "Form Closing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        End If
    End Sub
End Class