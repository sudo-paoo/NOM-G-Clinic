Imports System.Web
Imports MySql.Data.MySqlClient

Public Class EditPatientDetails
    Public Property PatientID As String

    Private conn As MySqlConnection
    Private cmd As MySqlCommand
    Private reader As MySqlDataReader
    Private errProvider As New ErrorProvider()

    ' For tracking current tab
    Private currentTabIndex As Integer = 0

    Private Sub EditPatientDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set tab size
        tabPatientEdit.ItemSize = New Size(tabPatientEdit.Width \ tabPatientEdit.TabCount - 2, 30)

        ' Configure error provider
        errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink

        ' Set up validation handlers - TabPage1
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

        ' Set up validation handlers - TabPage2
        AddHandler txtEmergencyContactName.Validating, AddressOf ValidateRequiredField
        AddHandler txtEmergencyContactRelationship.Validating, AddressOf ValidateRequiredField
        AddHandler txtEmergencyContactNumber.Validating, AddressOf ValidateContactNumber

        ' Add handling for numeric input
        AddHandler txtContactNumber.KeyPress, AddressOf NumericTextBox_KeyPress
        AddHandler txtEmergencyContactNumber.KeyPress, AddressOf NumericTextBox_KeyPress

        AddHandler clrLastMenstrual.DateSelected, AddressOf clrLastMenstrual_DateSelected

        ' Load doctors for dropdown
        LoadDoctors()

        ' Load patient data
        LoadPatientData()
    End Sub

    ' Load doctors from database into the combobox
    Private Sub LoadDoctors()
        Try
            conn = New MySqlConnection("Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;")
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

    ' Load patient data from database
    Private Sub LoadPatientData()
        If String.IsNullOrEmpty(PatientID) Then
            MessageBox.Show("No patient ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If

        Try
            conn = New MySqlConnection("Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;")
            conn.Open()

            Dim query As String = "SELECT * FROM patient WHERE patient_id = @patientId"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@patientId", PatientID)

            reader = cmd.ExecuteReader()

            If reader.Read() Then
                txtFirstName.Text = reader("first_name").ToString()
                txtMiddleName.Text = reader("middle_name").ToString()
                txtLastName.Text = reader("last_name").ToString()
                numAge.Value = Convert.ToInt32(reader("age"))

                ' Set Civil Status
                Dim civilStatus As String = reader("civil_status").ToString().ToLower()
                For i As Integer = 0 To cbxCivilStatus.Items.Count - 1
                    If cbxCivilStatus.Items(i).ToString().ToLower() = civilStatus Then
                        cbxCivilStatus.SelectedIndex = i
                        Exit For
                    End If
                Next

                numWeight.Value = Convert.ToDecimal(reader("weight"))
                numHeight.Value = Convert.ToDecimal(reader("height"))

                ' Set Blood Type
                Dim bloodType As String = reader("blood_type").ToString()
                For i As Integer = 0 To cbxBloodType.Items.Count - 1
                    If cbxBloodType.Items(i).ToString() = bloodType Then
                        cbxBloodType.SelectedIndex = i
                        Exit For
                    End If
                Next

                txtAddress.Text = reader("address").ToString()
                txtContactNumber.Text = reader("contact_number").ToString()
                txtEmailAddress.Text = reader("email").ToString()

                ' Fill Emergency Contact tab
                txtEmergencyContactName.Text = reader("emergency_contact_name").ToString()
                txtEmergencyContactRelationship.Text = reader("emergency_contact_relationship").ToString()
                txtEmergencyContactNumber.Text = reader("emergency_contact_number").ToString()

                ' Fill Medical Information tab
                If reader("last_menstrual_period") IsNot DBNull.Value Then
                    Dim lmpDate As DateTime = Convert.ToDateTime(reader("last_menstrual_period"))
                    clrLastMenstrual.SetDate(lmpDate)
                    lblSelectedDate.Text = "Date: " & lmpDate.ToString("MMMM dd, yyyy")
                End If

                ' Set First Baby Radio Buttons
                Dim isFirstBaby As Boolean = Convert.ToBoolean(reader("first_baby"))
                If isFirstBaby Then
                    rtbnYes.Checked = True
                Else
                    rbtnNo.Checked = True
                End If

                txtAllergies.Text = reader("allergies").ToString()

                ' Set Assigned OB
                Dim assignedOb As String = reader("assigned_ob").ToString()
                If Not String.IsNullOrEmpty(assignedOb) Then
                    Dim doctorDictionary As Dictionary(Of String, String) = DirectCast(cbxAssignedOB.Tag, Dictionary(Of String, String))
                    For Each kvp As KeyValuePair(Of String, String) In doctorDictionary
                        If kvp.Value = assignedOb Then
                            cbxAssignedOB.SelectedItem = kvp.Key
                            Exit For
                        End If
                    Next
                End If

                txtCurrentMedication.Text = reader("current_medication").ToString()
                txtHistoryOfSurgery.Text = reader("history_of_surgery").ToString()

            Else
                MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading patient data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If

            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    ' Next and Previous button handlers
    Private Sub btnPersonalInformationNext_Click(sender As Object, e As EventArgs) Handles btnPersonalInformationNext.Click
        If ValidatePersonalInformation() Then
            tabPatientEdit.SelectedIndex = 1
            currentTabIndex = 1
        Else
            MessageBox.Show("Please fill all required fields with valid information.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEmergencyContactNext_Click(sender As Object, e As EventArgs) Handles btnEmergencyContactNext.Click
        If ValidateEmergencyContact() Then
            tabPatientEdit.SelectedIndex = 2
            currentTabIndex = 2
        Else
            MessageBox.Show("Please fill all emergency contact fields with valid information.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEmergencyContactPrevious_Click(sender As Object, e As EventArgs) Handles btnEmergencyContactPrevious.Click
        Me.ActiveControl = btnEmergencyContactPrevious
        tabPatientEdit.SelectedIndex = 0
        currentTabIndex = 0
    End Sub

    Private Sub btnMedicalInformationPrevious_Click(sender As Object, e As EventArgs) Handles btnMedicalInformationPrevious.Click
        Me.ActiveControl = btnMedicalInformationPrevious
        tabPatientEdit.SelectedIndex = 1
        currentTabIndex = 1
    End Sub

    ' Event handler for calendar date selected
    Private Sub clrLastMenstrual_DateSelected(sender As Object, e As DateRangeEventArgs)
        Dim selectedDate As Date = clrLastMenstrual.SelectionStart
        lblSelectedDate.Text = "Date: " & selectedDate.ToString("MMMM dd, yyyy")

        ' Calculate and display the estimated due date
        'Dim dueDate As Date = selectedDate.AddDays(280)
        'lblDueDate.Text = dueDate.ToString("MMMM dd, yyyy")
    End Sub

    ' Validation for Personal Information tab
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

    ' Validation for Emergency Contact tab
    Private Function ValidateEmergencyContact() As Boolean
        Dim isValid As Boolean = True

        ' Validate each control
        If Not ValidateControl(txtEmergencyContactName) Then isValid = False
        If Not ValidateControl(txtEmergencyContactRelationship) Then isValid = False
        If Not ValidateControl(txtEmergencyContactNumber) Then isValid = False

        Return isValid
    End Function

    ' Generic validation method for a specific control
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
        ElseIf contactNumber.Count(Function(c) Char.IsDigit(c)) > 11 Then
            errProvider.SetError(textBox, "Contact number can only have up to 11 digits.")
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

    ' Email validation function
    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr = New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    ' Clear error when text changes
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged, txtLastName.TextChanged,
        txtAddress.TextChanged, txtContactNumber.TextChanged, txtEmailAddress.TextChanged,
        txtEmergencyContactName.TextChanged, txtEmergencyContactRelationship.TextChanged, txtEmergencyContactNumber.TextChanged

        Dim textBox = DirectCast(sender, TextBox)
        errProvider.SetError(textBox, "")
    End Sub

    ' Clear error when numeric value changes
    Private Sub NumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles numAge.ValueChanged,
        numWeight.ValueChanged, numHeight.ValueChanged

        Dim numericUpDown = DirectCast(sender, NumericUpDown)
        errProvider.SetError(numericUpDown, "")
    End Sub

    ' Clear error when combo selection changes
    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCivilStatus.SelectedIndexChanged,
        cbxBloodType.SelectedIndexChanged, cbxAssignedOB.SelectedIndexChanged

        Dim comboBox = DirectCast(sender, ComboBox)
        errProvider.SetError(comboBox, "")
    End Sub

    Private Sub btnUpdatePatient_Click(sender As Object, e As EventArgs) Handles btnUpdatePatient.Click
        If Not ValidatePersonalInformation() Or Not ValidateEmergencyContact() Then
            MessageBox.Show("Please fill all required fields with valid information.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this patient's information?",
            "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                conn = New MySqlConnection("Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;")
                conn.Open()

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

                Dim query As String = "UPDATE patient SET " &
                "first_name = @firstName, " &
                "middle_name = @middleName, " &
                "last_name = @lastName, " &
                "age = @age, " &
                "civil_status = @civilStatus, " &
                "weight = @weight, " &
                "height = @height, " &
                "blood_type = @bloodType, " &
                "address = @address, " &
                "contact_number = @contactNumber, " &
                "email = @email, " &
                "emergency_contact_name = @emergencyContactName, " &
                "emergency_contact_relationship = @emergencyContactRelationship, " &
                "emergency_contact_number = @emergencyContactNumber, " &
                "last_menstrual_period = @lastMenstrualPeriod, " &
                "first_baby = @firstBaby, " &
                "allergies = @allergies, " &
                "assigned_ob = @assignedOb, " &
                "due_date = @dueDate, " &
                "current_medication = @currentMedication, " &
                "history_of_surgery = @historyOfSurgery " &
                "WHERE patient_id = @patientId"


                cmd = New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@patientId", PatientID)
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
                cmd.Parameters.AddWithValue("@dueDate", dueDate.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@currentMedication", currentMedication)
                cmd.Parameters.AddWithValue("@historyOfSurgery", historyOfSurgery)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Patient information updated successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                RefreshOpenForms()

                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error updating patient information: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub txtContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtContactNumber.TextChanged
        LimitContactNumberDigits(txtContactNumber)
    End Sub

    Private Sub txtEmergencyContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtEmergencyContactNumber.TextChanged
        LimitContactNumberDigits(txtEmergencyContactNumber)
    End Sub

    ' Helper method to limit the number of digits to 11
    Private Sub LimitContactNumberDigits(textBox As TextBox)
        Dim cursorPosition As Integer = textBox.SelectionStart

        Dim digitCount As Integer = textBox.Text.Count(Function(c) Char.IsDigit(c))

        If digitCount > 11 Then
            Dim result As String = ""
            Dim currentDigitCount As Integer = 0

            For Each c As Char In textBox.Text
                If Char.IsDigit(c) Then
                    If currentDigitCount < 11 Then
                        result += c
                        currentDigitCount += 1
                    End If
                Else
                    result += c
                End If
            Next

            If textBox.Text <> result Then
                textBox.Text = result

                textBox.SelectionStart = Math.Min(cursorPosition, textBox.Text.Length)
            End If
        End If

        If digitCount <= 11 Then
            errProvider.SetError(textBox, "")
        End If
    End Sub


    Private Sub RefreshOpenForms()
        Dim adminForm As AdminDashboard = TryCast(Application.OpenForms("AdminDashboard"), AdminDashboard)
        Dim doctorForm As DoctorDashboard = TryCast(Application.OpenForms("DoctorDashboard"), DoctorDashboard)
        Dim nurseForm As NurseDashboard = TryCast(Application.OpenForms("NurseDashboard"), NurseDashboard)

        If adminForm IsNot Nothing Then
            adminForm.PatientsSetupDataGrid()
            adminForm.PatientsPopulateDataGrid()
        End If

        If doctorForm IsNot Nothing Then
            doctorForm.PatientsSetupDataGrid()
            doctorForm.PatientsPopulateDataGrid()
        End If

        If nurseForm IsNot Nothing Then
            nurseForm.PatientsSetupDataGrid()
            nurseForm.PatientsPopulateDataGrid()
        End If
    End Sub
End Class