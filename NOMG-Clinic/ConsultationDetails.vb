Imports MySql.Data.MySqlClient

Public Class ConsultationDetails
    Public Property PatientID As String
    Public Property AppointmentID As String

    Private Sub ConsultationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy")

        If Not String.IsNullOrEmpty(PatientID) Then
            LoadPatientDetails()
        Else
            MessageBox.Show("No patient ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub LoadPatientDetails()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"
        Dim query As String = "
            SELECT 
                CONCAT(first_name, ' ', last_name) AS full_name,
                age,
                blood_type,
                allergies,
                last_menstrual_period,
                due_date
            FROM 
                patient
            WHERE 
                patient_id = @patientID"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@patientID", PatientID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblPatientName.Text = reader("full_name").ToString()
                            lblPatientAge.Text = reader("age").ToString() & " years old"
                            lblBloodType.Text = If(String.IsNullOrEmpty(reader("blood_type").ToString()),
                                                  "Not specified",
                                                  reader("blood_type").ToString())
                            lblAllergies.Text = If(String.IsNullOrEmpty(reader("allergies").ToString()),
                                                  "None",
                                                  reader("allergies").ToString())
                            Dim lastMenstrualDate As DateTime
                            If DateTime.TryParse(reader("last_menstrual_period").ToString(), lastMenstrualDate) Then
                                Dim gestationalAge As TimeSpan = DateTime.Now - lastMenstrualDate
                                Dim totalDays As Integer = gestationalAge.Days
                                Dim weeks As Integer = totalDays \ 7
                                Dim days As Integer = totalDays Mod 7
                                Dim trimester As String = ""
                                If weeks < 13 Then
                                    trimester = "FIRST TRIMESTER"
                                ElseIf weeks < 27 Then
                                    trimester = "SECOND TRIMESTER"
                                Else
                                    trimester = "THIRD TRIMESTER"
                                End If

                                lblGestationalAge.Text = $"{weeks} WEEKS ({trimester})"
                            Else
                                lblGestationalAge.Text = "Not available"
                            End If
                            Dim dueDate As DateTime
                            If DateTime.TryParse(reader("due_date").ToString(), dueDate) Then
                                lblDueDate.Text = dueDate.ToString("MMMM dd, yyyy")
                            ElseIf DateTime.TryParse(reader("last_menstrual_period").ToString(), lastMenstrualDate) Then
                                dueDate = lastMenstrualDate.AddDays(280)
                                lblDueDate.Text = dueDate.ToString("MMMM dd, yyyy")
                            Else
                                lblDueDate.Text = "Not available"
                            End If
                        Else
                            MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Close()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading patient data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
        "Routine vitamins will be automatically prescribed to the patient. Continue?",
        "Confirm Save",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        If SaveConsultationData() Then
            MessageBox.Show("Consultation details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim scheduleResult As DialogResult = MessageBox.Show(
            "Do you want to schedule a follow-up appointment for this patient?",
            "Schedule Follow-up",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

            If scheduleResult = DialogResult.Yes Then
                Dim patientDetails = GetPatientDetailsForAppointment()

                If patientDetails.PatientId <> "" Then
                    ScheduleFollowUpAppointment(patientDetails, cmbReasonVisit.Text)
                End If
            End If

            Me.Close()
        End If
    End Sub


    Private Structure PatientAppointmentDetails
        Public PatientId As String
        Public PatientName As String
        Public LastMenstrualDate As Date
        Public DueDate As Date
        Public LastCheckupDate As Date
        Public GestationalWeeks As Integer
        Public AssignedDoctorId As String
    End Structure
    Private Function GetPatientDetailsForAppointment() As PatientAppointmentDetails
        Dim patientDetails As New PatientAppointmentDetails()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Dim query As String = "
                SELECT 
                    p.patient_id,
                    CONCAT(p.first_name, ' ', p.last_name) AS full_name,
                    p.last_menstrual_period,
                    p.due_date,
                    p.assigned_ob,
                    (SELECT MAX(appointment_date) FROM appointment_table 
                     WHERE patient_id = p.patient_id AND status = 'Completed') AS last_checkup_date
                FROM 
                    patient p
                WHERE 
                    p.patient_id = @patientId"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@patientId", PatientID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            patientDetails.PatientId = PatientID
                            patientDetails.PatientName = reader("full_name").ToString()

                            ' Get last menstrual date
                            If DateTime.TryParse(reader("last_menstrual_period").ToString(), patientDetails.LastMenstrualDate) Then
                                Dim gestationalAge As TimeSpan = DateTime.Now - patientDetails.LastMenstrualDate
                                patientDetails.GestationalWeeks = CInt(gestationalAge.TotalDays \ 7)
                            End If

                            ' Get due date
                            If DateTime.TryParse(reader("due_date").ToString(), patientDetails.DueDate) Then
                            ElseIf patientDetails.LastMenstrualDate <> Date.MinValue Then
                                patientDetails.DueDate = patientDetails.LastMenstrualDate.AddDays(280)
                            End If

                            ' Get assigned doctor
                            patientDetails.AssignedDoctorId = reader("assigned_ob").ToString()

                            ' Get last checkup date
                            If Not reader.IsDBNull(reader.GetOrdinal("last_checkup_date")) Then
                                patientDetails.LastCheckupDate = Convert.ToDateTime(reader("last_checkup_date"))
                            Else
                                ' If no previous checkup, use current date
                                patientDetails.LastCheckupDate = DateTime.Now
                            End If

                            Return patientDetails
                        Else
                            MessageBox.Show("Patient details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return Nothing
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error retrieving patient details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Using
    End Function

    Private Sub ScheduleFollowUpAppointment(patientDetails As PatientAppointmentDetails, reasonForVisit As String)
        Try
            ' Create new instance of AppointmentDetails
            Dim appointmentForm As New AppointmentDetails()

            appointmentForm.PatientId = patientDetails.PatientId
            appointmentForm.PatientName = patientDetails.PatientName
            appointmentForm.LastMenstrualDate = patientDetails.LastMenstrualDate
            appointmentForm.DueDate = patientDetails.DueDate
            appointmentForm.LastVisitDate = patientDetails.LastCheckupDate
            appointmentForm.DefaultDoctorId = patientDetails.AssignedDoctorId
            appointmentForm.AppointmentType = "Follow-up Check-up"
            appointmentForm.GestationalWeeks = patientDetails.GestationalWeeks
            appointmentForm.IsFollowUp = True

            appointmentForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error opening appointment form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtDoctorAssessment.Text) Then
            MessageBox.Show("Please enter an assessment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDoctorAssessment.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtDoctorPlan.Text) Then
            MessageBox.Show("Please enter a treatment plan.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDoctorPlan.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(smlBloodPressure.Text) Then
            MessageBox.Show("Please enter blood pressure reading.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            smlBloodPressure.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function SaveConsultationData() As Boolean
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Dim transaction As MySqlTransaction = connection.BeginTransaction()

                Try
                    Dim consultationId As String = GetNextConsultationId(connection)

                    Dim doctorId As String = GetPatientDoctorId(connection)

                    Dim notesJson As String = CreateConsultationNotesJson()

                    Dim insertQuery As String = "
                    INSERT INTO consultation 
                    (consultation_id, patient_id, doctor_id, consultation_date, diagnosis, notes) 
                    VALUES 
                    (@consultationId, @patientId, @doctorId, @consultationDate, @diagnosis, @notes)"

                    Using cmd As New MySqlCommand(insertQuery, connection, transaction)
                        cmd.Parameters.AddWithValue("@consultationId", consultationId)
                        cmd.Parameters.AddWithValue("@patientId", PatientID)
                        cmd.Parameters.AddWithValue("@doctorId", doctorId)
                        cmd.Parameters.AddWithValue("@consultationDate", DateTime.Now)
                        cmd.Parameters.AddWithValue("@diagnosis", txtDoctorAssessment.Text)
                        cmd.Parameters.AddWithValue("@notes", notesJson)

                        cmd.ExecuteNonQuery()
                    End Using

                    If Not String.IsNullOrEmpty(AppointmentID) Then
                        Dim updateAppointmentQuery As String = "
                        UPDATE appointment_table 
                        SET status = 'Completed' 
                        WHERE appointment_id = @appointmentId"

                        Using cmd As New MySqlCommand(updateAppointmentQuery, connection, transaction)
                            cmd.Parameters.AddWithValue("@appointmentId", AppointmentID)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    transaction.Commit()
                    Return True

                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Error saving consultation data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

            Catch ex As Exception
                MessageBox.Show("Error connecting to database: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Private Function GetNextConsultationId(connection As MySqlConnection) As String
        Dim nextId As Integer = 1

        Try
            Dim query As String = "SELECT MAX(SUBSTRING(consultation_id, 2)) FROM consultation"

            Using cmd As New MySqlCommand(query, connection)
                Dim result As Object = cmd.ExecuteScalar()

                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    If Integer.TryParse(result.ToString(), nextId) Then
                        nextId += 1
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating consultation ID: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        If nextId < 10 Then
            Return "C00" & nextId
        ElseIf nextId < 100 Then
            Return "C0" & nextId
        Else
            Return "C" & nextId
        End If
    End Function

    Private Function GetPatientDoctorId(connection As MySqlConnection) As String
        Dim doctorId As String = ""

        Try
            Dim query As String = "SELECT assigned_ob FROM patient WHERE patient_id = @patientId"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@patientId", PatientID)

                Dim result As Object = cmd.ExecuteScalar()

                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    doctorId = result.ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving doctor ID: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return doctorId
    End Function

    Private Function CreateConsultationNotesJson() As String
        Dim urineAnalysisResult As String = "none"
        If rbProtein.Checked Then
            urineAnalysisResult = "protein"
        ElseIf rbGlucose.Checked Then
            urineAnalysisResult = "glucose"
        ElseIf rbKetones.Checked Then
            urineAnalysisResult = "ketones"
        ElseIf rbBlood.Checked Then
            urineAnalysisResult = "blood"
        End If

        Dim notesObject As New With {
            .vitals = New With {
                .blood_pressure = smlBloodPressure.Text.Trim(),
                .pulse = smlPulse.Text.Trim(),
                .temperature = smlTemperature.Text.Trim(),
                .weight = smlWeight.Text.Trim()
            },
            .examination = New With {
                .fundal_height = txtFundalHeight.Text.Trim(),
                .fetal_heart_rate = txtFetalHeart.Text.Trim(),
                .urine_analysis = urineAnalysisResult
            },
            .details = New With {
                .visit_type = cmbVisitType.Text,
                .reason = cmbReasonVisit.Text,
                .assessment = txtDoctorAssessment.Text.Trim(),
                .plan = txtDoctorPlan.Text.Trim()
            },
            .timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        }

        Return Newtonsoft.Json.JsonConvert.SerializeObject(notesObject)
    End Function
End Class
