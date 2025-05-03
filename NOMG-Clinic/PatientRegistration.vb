Imports MySql.Data.MySqlClient
Imports System.Data
Public Class PatientRegistration
    Private errProvider As New ErrorProvider()

    Private conn As MySqlConnection
    Private cmd As MySqlCommand
    Private reader As MySqlDataReader

    ' tab size = 976, 405
    ' form size = 1000, 520
    Private Sub PatientRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabPatientRegistration.ItemSize = New Size(tabPatientRegistration.Width \ tabPatientRegistration.TabCount - 2, 30)

        errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink

        tabPatientRegistration.TabPages(1).Enabled = False
        tabPatientRegistration.TabPages(2).Enabled = False

        ' Set up event handlers for validation - TabPage1
        AddHandler txtFirstName.Validating, AddressOf ValidateRequiredField
        AddHandler txtLastName.Validating, AddressOf ValidateRequiredField
        AddHandler numAge.Validating, AddressOf ValidateNumericUpDown
        AddHandler cbxCivilStatus.Validating, AddressOf ValidateRequiredField
        AddHandler cbxBloodType.Validating, AddressOf ValidateRequiredField
        AddHandler numWeight.Validating, AddressOf ValidateNumericUpDown
        AddHandler numHeight.Validating, AddressOf ValidateNumericUpDown
        AddHandler txtAddress.Validating, AddressOf ValidateRequiredField
        AddHandler txtContactNumber.Validating, AddressOf ValidateContactNumber
        AddHandler txtEmailAddress.Validating, AddressOf ValidateEmail

        ' Set up event handlers for validation - TabPage2
        AddHandler txtEmergencyContactName.Validating, AddressOf ValidateRequiredField
        AddHandler txtEmergencyContactRelationship.Validating, AddressOf ValidateRequiredField
        AddHandler txtEmergencyContactNumber.Validating, AddressOf ValidateContactNumber

        AddHandler txtContactNumber.KeyPress, AddressOf NumericTextBox_KeyPress
        AddHandler txtEmergencyContactNumber.KeyPress, AddressOf NumericTextBox_KeyPress

        AddHandler clrLastMenstrual.DateSelected, AddressOf clrLastMenstrual_DateSelected

        LoadDoctors()
    End Sub

    ' Load doctors from database into the combobox
    Private Sub LoadDoctors()
        Try
            conn = New MySql.Data.MySqlClient.MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
            conn.Open()

            Dim query As String = "SELECT doctor_id, CONCAT(first_name, ' ', last_name) AS full_name FROM doctor ORDER BY last_name"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(query, conn)

            reader = cmd.ExecuteReader()

            cbxAssignedOB.Items.Clear()

            cbxAssignedOB.Items.Add("-- Select a doctor --")

            Dim doctorDictionary As New Dictionary(Of String, String)

            While reader.Read()
                Dim doctorId As String = reader("doctor_id").ToString()
                Dim doctorName As String = reader("full_name").ToString()

                doctorDictionary.Add(doctorName, doctorId)
                cbxAssignedOB.Items.Add(doctorName)
            End While

            cbxAssignedOB.Tag = doctorDictionary

            If cbxAssignedOB.Items.Count > 0 Then
                cbxAssignedOB.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading doctors: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If

            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    ' Event handler for calendar date selected
    Private Sub clrLastMenstrual_DateSelected(sender As Object, e As DateRangeEventArgs)
        Dim selectedDate As Date = clrLastMenstrual.SelectionStart
        lblSelectedDate.Text = "Date: " & selectedDate.ToString("MMMM dd, yyyy")
    End Sub

    ' Helper method to find a label by name
    Private Function FindLabelByName(name As String) As Label
        For Each ctrl As Control In TabPage3.Controls
            If TypeOf ctrl Is Label AndAlso ctrl.Name = name Then
                Return DirectCast(ctrl, Label)
            End If
        Next
        Return Nothing
    End Function

    Private Sub tabPatientRegistration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPatientRegistration.SelectedIndexChanged
        If Not tabPatientRegistration.SelectedTab.Enabled AndAlso tabPatientRegistration.SelectedIndex > tabPatientRegistration.TabPages.IndexOf(tabPatientRegistration.TabPages.Cast(Of TabPage)().LastOrDefault(Function(tab) tab.Enabled)) Then
            For i As Integer = 0 To tabPatientRegistration.TabPages.Count - 1
                If tabPatientRegistration.TabPages(i).Enabled Then
                    tabPatientRegistration.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
    End Sub

    ' Validation for the Next button on Personal Information tab
    Private Sub btnPersonalInformationNext_Click(sender As Object, e As EventArgs) Handles btnPersonalInformationNext.Click
        If ValidatePersonalInformation() Then
            tabPatientRegistration.TabPages(1).Enabled = True
            tabPatientRegistration.SelectedIndex = 1
        Else
            MessageBox.Show("Please fill all required fields with valid information.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Validation for Emergency Contact Next button
    Private Sub btnEmergencyContactNext_Click(sender As Object, e As EventArgs) Handles btnEmergencyContactNext.Click
        If ValidateEmergencyContact() Then
            tabPatientRegistration.TabPages(2).Enabled = True
            tabPatientRegistration.SelectedIndex = 2
        Else
            MessageBox.Show("Please fill all emergency contact fields with valid information.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEmergencyContactPrevious_Click(sender As Object, e As EventArgs) Handles btnEmergencyContactPrevious.Click
        Me.ActiveControl = btnEmergencyContactPrevious
        tabPatientRegistration.SelectedIndex = 0
    End Sub

    Private Sub btnMedicalInformationPrevious_Click(sender As Object, e As EventArgs) Handles btnMedicalInformationPrevious.Click
        Me.ActiveControl = btnMedicalInformationPrevious
        tabPatientRegistration.SelectedIndex = 1
    End Sub

    ' Validate all fields in the Personal Information tab
    Private Function ValidatePersonalInformation() As Boolean
        Dim isValid As Boolean = True

        ' Validate each control
        If Not ValidateControl(txtFirstName) Then isValid = False
        If Not ValidateControl(txtLastName) Then isValid = False
        If Not ValidateControl(numAge) Then isValid = False
        If Not ValidateControl(cbxCivilStatus) Then isValid = False
        If Not ValidateControl(cbxBloodType) Then isValid = False
        If Not ValidateControl(numWeight) Then isValid = False
        If Not ValidateControl(numHeight) Then isValid = False
        If Not ValidateControl(txtAddress) Then isValid = False
        If Not ValidateControl(txtContactNumber) Then isValid = False
        If Not ValidateControl(txtEmailAddress) Then isValid = False

        Return isValid
    End Function

    ' Validate all fields in the Emergency Contact tab
    Private Function ValidateEmergencyContact() As Boolean
        Dim isValid As Boolean = True

        ' Validate each control
        If Not ValidateControl(txtEmergencyContactName) Then isValid = False
        If Not ValidateControl(txtEmergencyContactRelationship) Then isValid = False
        If Not ValidateControl(txtEmergencyContactNumber) Then isValid = False

        Return isValid
    End Function

    ' Validation for a specific control
    Private Function ValidateControl(ctrl As Control) As Boolean
        Dim args As New System.ComponentModel.CancelEventArgs()
        ctrl.Focus()

        Dim methodInfo = ctrl.GetType().GetMethod("OnValidating", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        If methodInfo IsNot Nothing Then
            methodInfo.Invoke(ctrl, New Object() {args})
        End If

        Return Not args.Cancel
    End Function

    ' Validation for required fields
    Private Sub ValidateRequiredField(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim textBox = TryCast(sender, TextBox)
        Dim comboBox = TryCast(sender, ComboBox)

        If textBox IsNot Nothing Then
            If String.IsNullOrWhiteSpace(textBox.Text) Then
                errProvider.SetError(textBox, "This field is required.")
                e.Cancel = True
            Else
                errProvider.SetError(textBox, "")
            End If
        ElseIf comboBox IsNot Nothing Then
            If comboBox.SelectedIndex = -1 Then
                errProvider.SetError(comboBox, "Please select an option.")
                e.Cancel = True
            Else
                errProvider.SetError(comboBox, "")
            End If
        End If
    End Sub

    ' Validation for NumericUpDown controls
    Private Sub ValidateNumericUpDown(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim numericUpDown = DirectCast(sender, NumericUpDown)

        If numericUpDown Is numAge Then
            If numericUpDown.Value <= 0 Or numericUpDown.Value > 120 Then
                errProvider.SetError(numericUpDown, "Age must be between 1 and 120.")
                e.Cancel = True
            Else
                errProvider.SetError(numericUpDown, "")
            End If
        ElseIf numericUpDown Is numWeight Then
            If numericUpDown.Value <= 0 Or numericUpDown.Value > 500 Then
                errProvider.SetError(numericUpDown, "Weight must be between 1 and 500 kg.")
                e.Cancel = True
            Else
                errProvider.SetError(numericUpDown, "")
            End If
        ElseIf numericUpDown Is numHeight Then
            If numericUpDown.Value <= 0 Or numericUpDown.Value > 300 Then
                errProvider.SetError(numericUpDown, "Height must be between 1 and 300 cm.")
                e.Cancel = True
            Else
                errProvider.SetError(numericUpDown, "")
            End If
        End If
    End Sub

    ' Limit input to numeric characters only
    Private Sub NumericTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ControlChars.Back Or e.KeyChar = "+" Or
                e.KeyChar = "-" Or e.KeyChar = "(" Or e.KeyChar = ")" Or e.KeyChar = " ") Then
            e.Handled = True
        End If
    End Sub

    ' Validation for contact number
    Private Sub ValidateContactNumber(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim textBox = DirectCast(sender, TextBox)
        Dim contactNumber = textBox.Text.Trim()

        If String.IsNullOrWhiteSpace(contactNumber) Then
            errProvider.SetError(textBox, "Contact number is required.")
            e.Cancel = True
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(contactNumber, "^[0-9\+\-\(\) ]{7,15}$") Then
            errProvider.SetError(textBox, "Please enter a valid contact number.")
            e.Cancel = True
        Else
            errProvider.SetError(textBox, "")
        End If
    End Sub

    ' Validation for email address
    Private Sub ValidateEmail(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim textBox = DirectCast(sender, TextBox)
        Dim email = textBox.Text.Trim()

        If String.IsNullOrWhiteSpace(email) Then
            errProvider.SetError(textBox, "Email address is required.")
            e.Cancel = True
        ElseIf Not IsValidEmail(email) Then
            errProvider.SetError(textBox, "Please enter a valid email address.")
            e.Cancel = True
        Else
            errProvider.SetError(textBox, "")
        End If
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr = New System.Net.Mail.MailAddress(email)
            Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
            Return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern)
        Catch
            Return False
        End Try
    End Function


    ' Validation handler for TextBox when text changes
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged, txtLastName.TextChanged,
        txtAddress.TextChanged, txtContactNumber.TextChanged, txtEmailAddress.TextChanged,
        txtEmergencyContactName.TextChanged, txtEmergencyContactRelationship.TextChanged, txtEmergencyContactNumber.TextChanged

        Dim textBox = DirectCast(sender, TextBox)
        errProvider.SetError(textBox, "")
    End Sub

    ' Validation handler for NumericUpDown when value changes
    Private Sub NumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles numAge.ValueChanged,
        numWeight.ValueChanged, numHeight.ValueChanged

        Dim numericUpDown = DirectCast(sender, NumericUpDown)
        errProvider.SetError(numericUpDown, "")
    End Sub

    ' Validation handler for ComboBox when selection changes
    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCivilStatus.SelectedIndexChanged, cbxBloodType.SelectedIndexChanged, cbxAssignedOB.SelectedIndexChanged
        Dim comboBox = DirectCast(sender, ComboBox)
        errProvider.SetError(comboBox, "")
    End Sub

    ' Register Patient
    Private Sub btnRegisterPatient_Click(sender As Object, e As EventArgs) Handles btnRegisterPatient.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to register this patient?",
    "Confirm Registration",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                conn = New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
                conn.Open()

                Dim patientId As String = GeneratePatientId()

                Dim isFirstBaby As Boolean = False
                If rtbnYes.Checked Then
                    isFirstBaby = True
                ElseIf rbtnNo.Checked Then
                    isFirstBaby = False
                End If

                Dim assignedOb As String = ""
                If cbxAssignedOB.SelectedIndex > 0 Then
                    Dim selectedDoctorName As String = cbxAssignedOB.SelectedItem.ToString()
                    Dim doctorDictionary As Dictionary(Of String, String) = DirectCast(cbxAssignedOB.Tag, Dictionary(Of String, String))

                    If doctorDictionary.ContainsKey(selectedDoctorName) Then
                        assignedOb = doctorDictionary(selectedDoctorName)
                    End If
                End If

                Dim allergies As String = If(String.IsNullOrWhiteSpace(txtAllergies.Text), "None", txtAllergies.Text)
                Dim currentMedication As String = If(String.IsNullOrWhiteSpace(txtCurrentMedication.Text), "None", txtCurrentMedication.Text)
                Dim historyOfSurgery As String = If(String.IsNullOrWhiteSpace(txtHistoryOfSurgery.Text), "None", txtHistoryOfSurgery.Text)

                ' Get the last menstrual period
                Dim lastMenstrualPeriod As String = clrLastMenstrual.SelectionStart.ToString("yyyy-MM-dd")

                ' Calculate the estimated due date
                Dim dueDate As Date = clrLastMenstrual.SelectionStart.AddDays(280)

                Dim query As String = "INSERT INTO patient (patient_id, first_name, middle_name, last_name, age, civil_status, " &
                           "weight, height, blood_type, address, contact_number, email, emergency_contact_name, " &
                           "emergency_contact_relationship, emergency_contact_number, last_menstrual_period, first_baby, " &
                           "allergies, assigned_ob, vitamin_intake, due_date, current_medication, history_of_surgery) " &
                           "VALUES (@patientId, @firstName, @middleName, @lastName, @age, @civilStatus, @weight, @height, " &
                           "@bloodType, @address, @contactNumber, @email, @emergencyContactName, @emergencyContactRelationship, " &
                           "@emergencyContactNumber, @lastMenstrualPeriod, @firstBaby, @allergies, " &
                           "@assignedOb, @vitaminIntake, @dueDate, @currentMedication, @historyOfSurgery)"

                cmd = New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@patientId", patientId)
                cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim())
                cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), "", txtMiddleName.Text.Trim()))
                cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim())
                cmd.Parameters.AddWithValue("@age", numAge.Value)
                cmd.Parameters.AddWithValue("@civilStatus", cbxCivilStatus.SelectedItem.ToString().ToLower())
                cmd.Parameters.AddWithValue("@weight", numWeight.Value)
                cmd.Parameters.AddWithValue("@height", numHeight.Value)
                cmd.Parameters.AddWithValue("@bloodType", cbxBloodType.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text.Trim())
                cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@emergencyContactName", txtEmergencyContactName.Text.Trim())
                cmd.Parameters.AddWithValue("@emergencyContactRelationship", txtEmergencyContactRelationship.Text.Trim())
                cmd.Parameters.AddWithValue("@emergencyContactNumber", txtEmergencyContactNumber.Text.Trim())
                cmd.Parameters.AddWithValue("@lastMenstrualPeriod", lastMenstrualPeriod)
                cmd.Parameters.AddWithValue("@firstBaby", isFirstBaby)
                cmd.Parameters.AddWithValue("@allergies", allergies)
                cmd.Parameters.AddWithValue("@assignedOb", assignedOb)
                cmd.Parameters.AddWithValue("@vitaminIntake", "[]")
                cmd.Parameters.AddWithValue("@dueDate", dueDate.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@currentMedication", currentMedication)
                cmd.Parameters.AddWithValue("@historyOfSurgery", historyOfSurgery)

                cmd.ExecuteNonQuery()

                Dim scheduleNow As DialogResult = MessageBox.Show("Patient successfully registered with ID: " & patientId &
                    Environment.NewLine & Environment.NewLine &
                    "Would you like to schedule the initial appointment now?",
                    "Registration Success",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)

                If scheduleNow = DialogResult.Yes Then
                    OpenAppointmentScheduling(
                        patientId,
                        txtFirstName.Text.Trim(),
                        txtLastName.Text.Trim(),
                        clrLastMenstrual.SelectionStart,
                        dueDate,
                        assignedOb
                    )
                End If

                Dim adminForm As AdminDashboard = TryCast(Application.OpenForms("AdminDashboard"), AdminDashboard)
                If adminForm IsNot Nothing Then
                    adminForm.PatientsSetupDataGrid()
                    adminForm.PatientsPopulateDataGrid()
                Else
                    MessageBox.Show("Admin dashboard not found. Please refresh the dashboard manually.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error registering patient: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        End If
    End Sub


    Private Function GeneratePatientId() As String
        Dim newId As String = "P001"

        Try
            Using conn As New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
                conn.Open()

                Dim query As String = "SELECT patient_id FROM patient ORDER BY CAST(SUBSTRING(patient_id, 2) AS UNSIGNED) DESC LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing Then
                        Dim lastId As String = result.ToString()

                        If lastId.Length >= 2 AndAlso lastId.StartsWith("P") Then
                            Dim numericPart As Integer
                            If Integer.TryParse(lastId.Substring(1), numericPart) Then
                                numericPart += 1
                                If numericPart < 10 Then
                                    newId = "P00" & numericPart
                                ElseIf numericPart < 100 Then
                                    newId = "P0" & numericPart
                                Else
                                    newId = "P" & numericPart
                                End If
                            End If
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error generating patient ID: " & ex.Message)
            MessageBox.Show("Error generating patient ID. Using default ID: " & newId, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        Return newId
    End Function

    Private Sub OpenAppointmentScheduling(patientId As String, firstName As String, lastName As String,
                                     lastMenstrualDate As Date, dueDate As Date, assignedDoctorId As String)
        Dim appointmentForm As New AppointmentDetails()
        appointmentForm.PatientId = patientId
        appointmentForm.PatientName = $"{firstName} {lastName}"
        appointmentForm.LastMenstrualDate = lastMenstrualDate
        appointmentForm.DueDate = dueDate
        appointmentForm.DefaultDoctorId = assignedDoctorId
        appointmentForm.IsNewAppointment = True
        appointmentForm.AppointmentType = "Initial Check-up"
        appointmentForm.ShowDialog()
    End Sub
End Class