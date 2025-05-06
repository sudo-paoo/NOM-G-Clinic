Imports MySql.Data.MySqlClient

Public Class EditPatientDetails
    Public Property PatientID As String
    Private conn As MySqlConnection
    Private cmd As MySqlCommand
    Private reader As MySqlDataReader
    Private lastMenstrualDate As Date
    Private dueDate As Date
    Private doctorDictionary As Dictionary(Of String, String)
    Private errProvider As New ErrorProvider()

    Private Sub EditPatientDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink

        ' Load patient data
        LoadPatientData()

        ' Set up KeyPress event handlers for numeric input fields
        AddHandler txtAge.KeyPress, AddressOf NumericTextBox_KeyPress
        AddHandler txtContactNumber.KeyPress, AddressOf NumericTextBox_KeyPress
        AddHandler txtWeight.KeyPress, AddressOf DecimalTextBox_KeyPress
        AddHandler txtHeight.KeyPress, AddressOf DecimalTextBox_KeyPress
        AddHandler txtEmergencyContactNumber.KeyPress, AddressOf NumericTextBox_KeyPress

    End Sub

    ' Restrict input to numeric characters only
    Private Sub NumericTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        RegistrationModule.HandleNumericKeyPress(e)
    End Sub

    ' Restrict input to decimal numbers
    Private Sub DecimalTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

        ' Prevent multiple decimal points
        If e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ' Add a validation method for numeric fields
    Private Function ValidateNumericFields() As Boolean
        Dim isValid As Boolean = True

        ' Validate Age
        If Not IsNumeric(txtAge.Text) OrElse Convert.ToInt32(txtAge.Text) <= 0 OrElse Convert.ToInt32(txtAge.Text) > 120 Then
            errProvider.SetError(txtAge, "Age must be a number between 1 and 120.")
            isValid = False
        Else
            errProvider.SetError(txtAge, "")
        End If

        ' Validate Contact Number
        If Not RegistrationModule.IsNumeric(txtContactNumber.Text.Replace("+", "").Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "")) Then
            errProvider.SetError(txtContactNumber, "Contact number must contain only numeric digits, +, -, (), and spaces.")
            isValid = False
        Else
            errProvider.SetError(txtContactNumber, "")
        End If

        ' Validate Weight
        If Not IsNumeric(txtWeight.Text.Replace(".", ",")) OrElse Convert.ToDecimal(txtWeight.Text) <= 0 OrElse Convert.ToDecimal(txtWeight.Text) > 500 Then
            errProvider.SetError(txtWeight, "Weight must be a number between 1 and 500 kg.")
            isValid = False
        Else
            errProvider.SetError(txtWeight, "")
        End If

        ' Validate Height
        If Not IsNumeric(txtHeight.Text.Replace(".", ",")) OrElse Convert.ToDecimal(txtHeight.Text) <= 0 OrElse Convert.ToDecimal(txtHeight.Text) > 300 Then
            errProvider.SetError(txtHeight, "Height must be a number between 1 and 300 cm.")
            isValid = False
        Else
            errProvider.SetError(txtHeight, "")
        End If

        ' Validate Emergency Contact Number
        If Not RegistrationModule.IsNumeric(txtEmergencyContactNumber.Text.Replace("+", "").Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "")) Then
            errProvider.SetError(txtEmergencyContactNumber, "Emergency contact number must contain only numeric digits, +, -, (), and spaces.")
            isValid = False
        Else
            errProvider.SetError(txtEmergencyContactNumber, "")
        End If

        Return isValid
    End Function

    Private Sub LoadPatientData()
        Try
            conn = New MySqlConnection(RegistrationModule.ConnectionString)
            conn.Open()

            Dim query As String = "SELECT * FROM patient WHERE patient_id = @patientId"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@patientId", PatientID)

            reader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Load patient information into form fields
                txtFirstName.Text = reader("first_name").ToString()
                txtMiddleName.Text = reader("middle_name").ToString()
                txtLastName.Text = reader("last_name").ToString()
                txtAge.Text = reader("age").ToString()
                txtWeight.Text = reader("weight").ToString()
                txtHeight.Text = reader("height").ToString()
                ComboBox1.Text = reader("blood_type").ToString() ' Blood type
                txtAddress.Text = reader("address").ToString()
                txtContactNumber.Text = reader("contact_number").ToString()
                txtEmailAddress.Text = reader("email").ToString()
                txtEmergencyContactName.Text = reader("emergency_contact_name").ToString()
                txtEmergencyContactRelationship.Text = reader("emergency_contact_relationship").ToString()
                txtEmergencyContactNumber.Text = reader("emergency_contact_number").ToString()

                ' First baby radio button
                Dim isFirstBaby As Boolean = Convert.ToBoolean(reader("first_baby"))
                If isFirstBaby Then
                    rbtnYes.Checked = True
                Else
                    rbtnNo.Checked = True
                End If

                ' Civil status
                ComboBox2.Text = reader("civil_status").ToString()

                ' Medical information
                txtCurrentMedication.Text = reader("current_medication").ToString()
                txtHistoryOfSurgery.Text = reader("history_of_surgery").ToString()

                ' Pregnancy information
                If Not Convert.IsDBNull(reader("last_menstrual_period")) Then
                    lastMenstrualDate = Convert.ToDateTime(reader("last_menstrual_period"))
                    lblLastMenstrualAge.Text = lastMenstrualDate.ToString("MMMM dd, yyyy")
                Else
                    lblLastMenstrualAge.Text = "Not recorded"
                End If

                If Not Convert.IsDBNull(reader("due_date")) Then
                    dueDate = Convert.ToDateTime(reader("due_date"))

                    ' Calculate gestational age
                    Dim today As Date = Date.Today
                    Dim gestationalDays As Integer = (today - lastMenstrualDate).Days
                    Dim gestationalWeeks As Integer = gestationalDays \ 7
                    Dim remainingDays As Integer = gestationalDays Mod 7

                    lblGestationalAge.Text = $"{gestationalWeeks} weeks and {remainingDays} days"
                End If

                ' Load next checkup data and assigned OB
                If Not Convert.IsDBNull(reader("next_checkup")) Then
                    Dim nextCheckup As Date = Convert.ToDateTime(reader("next_checkup"))

                    If Not Convert.IsDBNull(reader("next_checkup_time")) Then
                        Dim time As String = reader("next_checkup_time").ToString()
                        lblNextCheckup.Text = $"{nextCheckup.ToString("MMMM dd, yyyy")} at {time}"
                    Else
                        lblNextCheckup.Text = nextCheckup.ToString("MMMM dd, yyyy")
                    End If
                Else
                    lblNextCheckup.Text = "Not scheduled"
                End If

                ' Get and display assigned OB name
                If Not Convert.IsDBNull(reader("assigned_ob")) Then
                    Dim doctorId As String = reader("assigned_ob").ToString()
                    LoadDoctorName(doctorId)
                Else
                    lblAssignedOB.Text = "Not assigned"
                End If
            Else
                MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading patient data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If

            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub LoadDoctorName(doctorId As String)
        Try
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If

            Dim query As String = "SELECT CONCAT(first_name, ' ', last_name) AS doctor_name FROM doctor WHERE doctor_id = @doctorId"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@doctorId", doctorId)

            reader = cmd.ExecuteReader()

            If reader.Read() Then
                lblAssignedOB.Text = reader("doctor_name").ToString()
            Else
                lblAssignedOB.Text = "Doctor not found"
            End If

        Catch ex As Exception
            lblAssignedOB.Text = "Error loading doctor"
            Console.WriteLine("Error loading doctor name: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateNumericFields() Then
            MessageBox.Show("Please ensure all numeric fields contain valid numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn = New MySqlConnection(RegistrationModule.ConnectionString)
            conn.Open()

            ' Check if any fields are empty
            If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
               String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
               String.IsNullOrWhiteSpace(txtAge.Text) OrElse
               String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse
               String.IsNullOrWhiteSpace(txtWeight.Text) OrElse
               String.IsNullOrWhiteSpace(txtHeight.Text) OrElse
               String.IsNullOrWhiteSpace(ComboBox1.Text) OrElse
               String.IsNullOrWhiteSpace(txtAddress.Text) OrElse
               String.IsNullOrWhiteSpace(txtContactNumber.Text) OrElse
               String.IsNullOrWhiteSpace(txtEmailAddress.Text) OrElse
               String.IsNullOrWhiteSpace(txtEmergencyContactName.Text) OrElse
               String.IsNullOrWhiteSpace(txtEmergencyContactRelationship.Text) OrElse
               String.IsNullOrWhiteSpace(txtEmergencyContactNumber.Text) OrElse
               (Not rbtnYes.Checked AndAlso Not rbtnNo.Checked) Then

                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Determine firstBaby value
            Dim isFirstBaby As Boolean = rbtnYes.Checked

            ' Update patient data
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
                "first_baby = @firstBaby, " &
                "current_medication = @currentMedication, " &
                "history_of_surgery = @historyOfSurgery " &
                "WHERE patient_id = @patientId"

            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim())
            cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), "", txtMiddleName.Text.Trim()))
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim())
            cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text))
            cmd.Parameters.AddWithValue("@civilStatus", ComboBox2.Text.Trim().ToLower())
            cmd.Parameters.AddWithValue("@weight", Convert.ToDecimal(txtWeight.Text))
            cmd.Parameters.AddWithValue("@height", Convert.ToDecimal(txtHeight.Text))
            cmd.Parameters.AddWithValue("@bloodType", ComboBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@emergencyContactName", txtEmergencyContactName.Text.Trim())
            cmd.Parameters.AddWithValue("@emergencyContactRelationship", txtEmergencyContactRelationship.Text.Trim())
            cmd.Parameters.AddWithValue("@emergencyContactNumber", txtEmergencyContactNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@firstBaby", isFirstBaby)
            cmd.Parameters.AddWithValue("@currentMedication", txtCurrentMedication.Text.Trim())
            cmd.Parameters.AddWithValue("@historyOfSurgery", txtHistoryOfSurgery.Text.Trim())
            cmd.Parameters.AddWithValue("@patientId", PatientID)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Patient information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh any open forms that display patient data
                Dim adminForm As AdminDashboard = TryCast(Application.OpenForms("AdminDashboard"), AdminDashboard)
                If adminForm IsNot Nothing Then
                    adminForm.PatientsSetupDataGrid()
                    adminForm.PatientsPopulateDataGrid()
                End If

                Me.Close()
            Else
                MessageBox.Show("Failed to update patient information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating patient: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
End Class
