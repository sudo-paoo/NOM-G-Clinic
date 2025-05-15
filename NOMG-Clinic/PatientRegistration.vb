Imports MySql.Data.MySqlClient

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

        txtFirstName.Focus()

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

        clrLastMenstrual.MaxDate = DateTime.Today
        LoadDoctors()
    End Sub

    ' Handle Enter key for txtFirstName to move to txtMiddleName
    Private Sub txtFirstName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFirstName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMiddleName.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for txtMiddleName to move to txtLastName
    Private Sub txtMiddleName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMiddleName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLastName.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for txtLastName to move to numAge
    Private Sub txtLastName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLastName.KeyDown
        If e.KeyCode = Keys.Enter Then
            numAge.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for numAge to move to cbxCivilStatus
    Private Sub numAge_KeyDown(sender As Object, e As KeyEventArgs) Handles numAge.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCivilStatus.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for cbxCivilStatus to move to cbxBloodType
    Private Sub cbxCivilStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCivilStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ValidateComboBox(cbxCivilStatus) Then
                cbxBloodType.Focus()
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    ' Handle Enter key for cbxBloodType to move to numWeight
    Private Sub cbxBloodType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBloodType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ValidateComboBox(cbxBloodType) Then
                numWeight.Focus()
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    ' Handle Enter key for numWeight to move to numHeight
    Private Sub numWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles numWeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            numHeight.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for numHeight to move to txtAddress
    Private Sub numHeight_KeyDown(sender As Object, e As KeyEventArgs) Handles numHeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAddress.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for txtAddress to move to txtContactNumber
    Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContactNumber.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for txtContactNumber to move to txtEmailAddress
    Private Sub txtContactNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmailAddress.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Simulate btnPersonalInformationNext click
    Private Sub txtEmailAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmailAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnPersonalInformationNext.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for txtEmergencyContactName to move to txtEmergencyContactRelationship
    Private Sub txtEmergencyContactName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmergencyContactName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmergencyContactRelationship.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for txtEmergencyContactRelationship to move to txtEmergencyContactNumber
    Private Sub txtEmergencyContactRelationship_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmergencyContactRelationship.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmergencyContactNumber.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Simulate btnEmergencyContactNext click
    Private Sub txtEmergencyContactNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmergencyContactNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnEmergencyContactNext.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Function ValidateComboBox(cmb As ComboBox) As Boolean
        If cmb.SelectedIndex = -1 AndAlso Not String.IsNullOrEmpty(cmb.Text) Then
            Dim itemExists As Boolean = False
            For Each item As Object In cmb.Items
                If item.ToString().Equals(cmb.Text, StringComparison.OrdinalIgnoreCase) Then
                    itemExists = True
                    Exit For
                End If
            Next

            If Not itemExists Then
                errProvider.SetError(cmb, "Please select a valid option from the list.")
                Return False
            End If
        End If

        errProvider.SetError(cmb, "")
        Return True
    End Function

    Private Sub cbxCivilStatus_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles cbxCivilStatus.Validating
        ValidateComboBox(cbxCivilStatus)
    End Sub

    Private Sub cbxBloodType_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles cbxBloodType.Validating
        ValidateComboBox(cbxBloodType)
    End Sub

    Private Sub cbxCivilStatus_TextChanged(sender As Object, e As EventArgs) Handles cbxCivilStatus.TextChanged
        If cbxCivilStatus.SelectedIndex = -1 AndAlso Not String.IsNullOrEmpty(cbxCivilStatus.Text) Then
            ValidateComboBox(cbxCivilStatus)
        End If
    End Sub

    Private Sub cbxBloodType_TextChanged(sender As Object, e As EventArgs) Handles cbxBloodType.TextChanged
        If cbxBloodType.SelectedIndex = -1 AndAlso Not String.IsNullOrEmpty(cbxBloodType.Text) Then
            ValidateComboBox(cbxBloodType)
        End If
    End Sub

    ' Load doctors from database into the combobox
    Private Sub LoadDoctors()
        Try
            conn = New MySqlConnection(RegistrationModule.ConnectionString)
            conn.Open()

            Dim query As String = "SELECT doctor_id, CONCAT(first_name, ' ', last_name) AS full_name FROM doctor ORDER BY last_name"
            cmd = New MySqlCommand(query, conn)

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

        ' This is a safety check, but shouldn't be necessary since MaxDate is already set
        If selectedDate > DateTime.Today Then
            MessageBox.Show("Please select today's date or a date in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            clrLastMenstrual.SetDate(DateTime.Today)
            selectedDate = DateTime.Today
        End If

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
            RegistrationModule.ValidateRequiredField(sender, e, errProvider)
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
            If numericUpDown.Value <= 12 Or numericUpDown.Value > 120 Then
                errProvider.SetError(numericUpDown, "Age must be between 12 and 120.")
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
        Dim textBox = DirectCast(sender, TextBox)
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            Return
        End If
        If textBox.Text.Length >= 11 And e.KeyChar <> ControlChars.Back Then
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
        ElseIf contactNumber.Length <> 11 Then
            errProvider.SetError(textBox, "Contact number must be exactly 11 digits.")
            e.Cancel = True
        ElseIf Not RegistrationModule.IsNumeric(contactNumber) Then
            errProvider.SetError(textBox, "Contact number must contain only digits.")
            e.Cancel = True
        Else
            errProvider.SetError(textBox, "")
        End If
    End Sub

    ' Validation for email address
    Private Sub ValidateEmail(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim textBox = DirectCast(sender, TextBox)
        RegistrationModule.ValidateEmail(textBox, errProvider, e)
    End Sub

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
                conn = New MySqlConnection(RegistrationModule.ConnectionString)
                conn.Open()

                Dim patientId As String = RegistrationModule.GenerateId("patient", "patient_id", "P", 3)

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
                   "allergies, assigned_ob, vitamin_intake, due_date, current_medication, history_of_surgery, flu_vac) " &
                   "VALUES (@patientId, @firstName, @middleName, @lastName, @age, @civilStatus, @weight, @height, " &
                   "@bloodType, @address, @contactNumber, @email, @emergencyContactName, @emergencyContactRelationship, " &
                   "@emergencyContactNumber, @lastMenstrualPeriod, @firstBaby, @allergies, " &
                   "@assignedOb, @vitaminIntake, @dueDate, @currentMedication, @historyOfSurgery, @fluVac)"


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
                cmd.Parameters.AddWithValue("@fluVac", 0)

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
                Dim doctorForm As DoctorDashboard = TryCast(Application.OpenForms("DoctorDashboard"), DoctorDashboard)
                Dim nurseForm As NurseDashboard = TryCast(Application.OpenForms("NurseDashboard"), NurseDashboard)
                If adminForm IsNot Nothing Then
                    adminForm.PatientsSetupDataGrid()
                    adminForm.PatientsPopulateDataGrid()
                    adminForm.AppointmentsSetupDataGrid()
                    adminForm.AppointmentsPopulateDataGrid()
                    adminForm.DoctorsSetupDataGrid()
                    adminForm.DoctorsPopulateDataGrid()
                End If
                If doctorForm IsNot Nothing Then
                    doctorForm.PatientsSetupDataGrid()
                    doctorForm.PatientsPopulateDataGrid()
                    doctorForm.AppointmentsSetupDataGrid()
                    doctorForm.AppointmentsPopulateDataGrid()
                End If
                If nurseForm IsNot Nothing Then
                    nurseForm.PatientsSetupDataGrid()
                    nurseForm.PatientsPopulateDataGrid()
                    nurseForm.AppointmentsSetupDataGrid()
                    nurseForm.AppointmentsPopulateDataGrid()
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
