Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports System.Data
Public Class DoctorRegistration
    Private errProvider As New ErrorProvider()
    Private isPasswordVisible As Boolean = False
    Private isConfirmPasswordVisible As Boolean = False

    Private Sub DoctorRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabDoctorRegistration.ItemSize = New Size(tabDoctorRegistration.Width \ tabDoctorRegistration.TabCount - 2, 30)

        errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink

        ' Position the error icons
        errProvider.SetIconAlignment(txtEmergencyContactRelationship, ErrorIconAlignment.TopLeft)
        errProvider.SetIconAlignment(txtEmergencyContactNumber, ErrorIconAlignment.TopLeft)
        errProvider.SetIconPadding(txtEmergencyContactRelationship, 10)
        errProvider.SetIconPadding(txtEmergencyContactNumber, 10)

        ' Disable TabPages 2 and 3 initially
        tabDoctorRegistration.TabPages(1).Enabled = False
        tabDoctorRegistration.TabPages(2).Enabled = False

        ' Set up password fields
        txtEmergencyContactRelationship.UseSystemPasswordChar = True
        txtEmergencyContactNumber.UseSystemPasswordChar = True

        ' Set up validation for account information fields
        AddHandler txtEmergencyContactName.Validating, AddressOf ValidateRequiredField
        AddHandler txtEmergencyContactRelationship.Validating, AddressOf ValidateRequiredField
        AddHandler txtEmergencyContactNumber.Validating, AddressOf ValidateConfirmPassword

        btnEyePassword.TabStop = False
        btnEyeConfirmPassword.TabStop = False
    End Sub

    Private Sub tabDoctorRegistration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabDoctorRegistration.SelectedIndexChanged
        If Not tabDoctorRegistration.SelectedTab.Enabled Then
            For i As Integer = 0 To tabDoctorRegistration.TabPages.Count - 1
                If tabDoctorRegistration.TabPages(i).Enabled Then
                    tabDoctorRegistration.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnAccountInformationNext_Click(sender As Object, e As EventArgs) Handles btnAccountInformationNext.Click
        ' Validate all account information fields before proceeding
        If ValidateAccountInformation() Then
            tabDoctorRegistration.TabPages(1).Enabled = True
            tabDoctorRegistration.SelectedIndex = 1
        Else
            MessageBox.Show("Please fill all required fields correctly. Make sure passwords match.",
                          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Personal Information Next button
    Private Sub btnPersonalInformationNext_Click(sender As Object, e As EventArgs) Handles btnPersonalInformationNext.Click
        ' Validate all personal information fields before proceeding
        If ValidatePersonalInformation() Then
            tabDoctorRegistration.TabPages(2).Enabled = True
            tabDoctorRegistration.SelectedIndex = 2
        Else
            MessageBox.Show("Please fill all required fields with valid information.",
                          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Previous buttons
    Private Sub btnPersonalInformationPrevious_Click(sender As Object, e As EventArgs) Handles btnPersonalInformationPrevious.Click
        Me.ActiveControl = btnPersonalInformationPrevious
        tabDoctorRegistration.SelectedIndex = 0
    End Sub

    Private Sub btnEmergencyContactPrevious_Click(sender As Object, e As EventArgs) Handles btnEmergencyContactPrevious.Click
        Me.ActiveControl = btnEmergencyContactPrevious
        tabDoctorRegistration.SelectedIndex = 1
    End Sub

    ' Password visibility toggle buttons
    Private Sub btnEyePassword_MouseDown(sender As Object, e As MouseEventArgs) Handles btnEyePassword.MouseDown
        isPasswordVisible = Not isPasswordVisible
        txtEmergencyContactRelationship.UseSystemPasswordChar = Not isPasswordVisible

        If isPasswordVisible Then
            btnEyePassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
        Else
            btnEyePassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        End If
    End Sub

    Private Sub btnEyeConfirmPassword_MouseDown(sender As Object, e As MouseEventArgs) Handles btnEyeConfirmPassword.MouseDown
        isConfirmPasswordVisible = Not isConfirmPasswordVisible
        txtEmergencyContactNumber.UseSystemPasswordChar = Not isConfirmPasswordVisible

        If isConfirmPasswordVisible Then
            btnEyeConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
        Else
            btnEyeConfirmPassword.IconChar = FontAwesome.Sharp.IconChar.Eye
        End If
    End Sub

    ' Validation functions
    Private Function ValidateAccountInformation() As Boolean
        Dim isValid As Boolean = True

        If String.IsNullOrWhiteSpace(txtEmergencyContactName.Text) Then
            errProvider.SetError(txtEmergencyContactName, "Username is required.")
            isValid = False
        Else
            ' Check if username exists
            Try
                Using conn As New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
                    conn.Open()

                    If IsUsernameExists(conn, txtEmergencyContactName.Text.Trim()) Then
                        errProvider.SetError(txtEmergencyContactName, "Username already exists. Please choose another.")
                        isValid = False
                    Else
                        errProvider.SetError(txtEmergencyContactName, "")
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine("Database error when checking username: " & ex.Message)
                errProvider.SetError(txtEmergencyContactName, "")
            End Try
        End If

        ' Validate Password
        If String.IsNullOrWhiteSpace(txtEmergencyContactRelationship.Text) Then
            errProvider.SetError(txtEmergencyContactRelationship, "Password is required.")
            isValid = False
        Else
            errProvider.SetError(txtEmergencyContactRelationship, "")
        End If

        ' Validate Confirm Password
        If String.IsNullOrWhiteSpace(txtEmergencyContactNumber.Text) Then
            errProvider.SetError(txtEmergencyContactNumber, "Confirm Password is required.")
            isValid = False
        ElseIf txtEmergencyContactNumber.Text <> txtEmergencyContactRelationship.Text Then
            errProvider.SetError(txtEmergencyContactNumber, "Passwords do not match.")
            isValid = False
        Else
            errProvider.SetError(txtEmergencyContactNumber, "")
        End If

        Return isValid
    End Function

    Private Function ValidatePersonalInformation() As Boolean
        Dim isValid As Boolean = True

        ' Validate First Name
        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            errProvider.SetError(txtFirstName, "First Name is required.")
            isValid = False
        Else
            errProvider.SetError(txtFirstName, "")
        End If

        ' Validate Last Name
        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            errProvider.SetError(txtLastName, "Last Name is required.")
            isValid = False
        Else
            errProvider.SetError(txtLastName, "")
        End If

        ' Validate Age
        If numAge.Value <= 0 Then
            errProvider.SetError(numAge, "Age must be greater than 0.")
            isValid = False
        Else
            errProvider.SetError(numAge, "")
        End If

        ' Validate Gender
        If String.IsNullOrWhiteSpace(txtGender.Text) Then
            errProvider.SetError(txtGender, "Gender is required.")
            isValid = False
        Else
            errProvider.SetError(txtGender, "")
        End If

        ' Validate License Number
        If String.IsNullOrWhiteSpace(txtLicenseNumber.Text) Then
            errProvider.SetError(txtLicenseNumber, "License Number is required.")
            isValid = False
        Else
            errProvider.SetError(txtLicenseNumber, "")
        End If

        Return isValid
    End Function

    Private Sub ValidateRequiredField(sender As Object, e As CancelEventArgs)
        Dim textBox = DirectCast(sender, TextBox)

        If String.IsNullOrWhiteSpace(textBox.Text) Then
            errProvider.SetError(textBox, "This field is required.")
            e.Cancel = True
        Else
            errProvider.SetError(textBox, "")
        End If
    End Sub

    Private Sub ValidateConfirmPassword(sender As Object, e As CancelEventArgs)
        Dim textBox = DirectCast(sender, TextBox)

        If String.IsNullOrWhiteSpace(textBox.Text) Then
            errProvider.SetError(textBox, "Confirm Password is required.")
            e.Cancel = True
        ElseIf textBox.Text <> txtEmergencyContactRelationship.Text Then
            errProvider.SetError(textBox, "Passwords do not match.")
            e.Cancel = True
        Else
            errProvider.SetError(textBox, "")
        End If
    End Sub

    Public Sub TogglePasswordVisibility(passwordTextBox As TextBox, eyeButton As FontAwesome.Sharp.IconButton, ByRef visibilityState As Boolean)
        visibilityState = Not visibilityState
        passwordTextBox.UseSystemPasswordChar = Not visibilityState

        If visibilityState Then
            eyeButton.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
        Else
            eyeButton.IconChar = FontAwesome.Sharp.IconChar.Eye
        End If
    End Sub

    Private Sub txtEmergencyContactRelationship_DoubleClick(sender As Object, e As EventArgs) Handles txtEmergencyContactRelationship.DoubleClick
        TogglePasswordVisibility(txtEmergencyContactRelationship, btnEyePassword, isPasswordVisible)
    End Sub

    Private Sub txtEmergencyContactNumber_DoubleClick(sender As Object, e As EventArgs) Handles txtEmergencyContactNumber.DoubleClick
        TogglePasswordVisibility(txtEmergencyContactNumber, btnEyeConfirmPassword, isConfirmPasswordVisible)
    End Sub

    ' Clear validation errors when text changes
    Private Sub txtEmergencyContactName_TextChanged(sender As Object, e As EventArgs) Handles txtEmergencyContactName.TextChanged
        errProvider.SetError(txtEmergencyContactName, "")
    End Sub

    Private Sub txtEmergencyContactRelationship_TextChanged(sender As Object, e As EventArgs) Handles txtEmergencyContactRelationship.TextChanged
        errProvider.SetError(txtEmergencyContactRelationship, "")
    End Sub

    Private Sub txtEmergencyContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtEmergencyContactNumber.TextChanged
        errProvider.SetError(txtEmergencyContactNumber, "")
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        errProvider.SetError(txtFirstName, "")
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        errProvider.SetError(txtLastName, "")
    End Sub

    Private Sub txtGender_TextChanged(sender As Object, e As EventArgs) Handles txtGender.TextChanged
        errProvider.SetError(txtGender, "")
    End Sub

    Private Sub txtLicenseNumber_TextChanged(sender As Object, e As EventArgs) Handles txtLicenseNumber.TextChanged
        errProvider.SetError(txtLicenseNumber, "")
    End Sub

    Private Sub numAge_ValueChanged(sender As Object, e As EventArgs) Handles numAge.ValueChanged
        errProvider.SetError(numAge, "")
    End Sub

    Private Function ValidateContactInformation() As Boolean
        Dim isValid As Boolean = True

        ' Validate Contact Number
        If String.IsNullOrWhiteSpace(txtContactNumber.Text) Then
            errProvider.SetError(txtContactNumber, "Contact Number is required.")
            isValid = False
        Else
            errProvider.SetError(txtContactNumber, "")
        End If

        ' Validate Email
        If String.IsNullOrWhiteSpace(txtEmailAddress.Text) Then
            errProvider.SetError(txtEmailAddress, "Email Address is required.")
            isValid = False
        Else
            errProvider.SetError(txtEmailAddress, "")
        End If

        ' Validate Address
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            errProvider.SetError(txtAddress, "Address is required.")
            isValid = False
        Else
            errProvider.SetError(txtAddress, "")
        End If

        Return isValid
    End Function

    Private Sub btnRegisterDoctor_Click(sender As Object, e As EventArgs) Handles btnRegisterDoctor.Click
        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to register this doctor?",
        "Confirm Registration",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

        ' If user confirms, save the doctor
        If result = DialogResult.Yes Then
            Try
                If Not ValidateContactInformation() Then
                    MessageBox.Show("Please fill all contact information fields with valid data.",
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Using conn As New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
                    conn.Open()

                    If IsUsernameExists(conn, txtEmergencyContactName.Text.Trim()) Then
                        MessageBox.Show("Username already exists. Please choose another username.",
                                  "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tabDoctorRegistration.SelectedIndex = 0
                        txtEmergencyContactName.Focus()
                        Return
                    End If

                    ' Generate a new doctor ID
                    Dim doctorId As String = GenerateDoctorId(conn)

                    Dim query As String = "INSERT INTO doctor (doctor_id, username, password, first_name, middle_name, last_name, age, " &
                                   "license_number, email, contact_number, gender, address) " &
                                   "VALUES (@doctorId, @username, @password, @firstName, @middleName, @lastName, @age, " &
                                   "@licenseNumber, @email, @contactNumber, @gender, @address)"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@doctorId", doctorId)
                        cmd.Parameters.AddWithValue("@username", txtEmergencyContactName.Text.Trim())
                        cmd.Parameters.AddWithValue("@password", txtEmergencyContactRelationship.Text.Trim())
                        cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim())
                        cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), "", txtMiddleName.Text.Trim()))
                        cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim())
                        cmd.Parameters.AddWithValue("@age", numAge.Value)
                        cmd.Parameters.AddWithValue("@licenseNumber", txtLicenseNumber.Text.Trim())
                        cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.Trim())
                        cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text.Trim())
                        cmd.Parameters.AddWithValue("@gender", txtGender.Text.Trim())
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim())

                        cmd.ExecuteNonQuery()

                        ' Also add this doctor to the users table for login
                        AddToUsersTable(conn, txtEmergencyContactName.Text.Trim(), txtEmergencyContactRelationship.Text.Trim())

                        ' Show success message
                        MessageBox.Show("Doctor successfully registered with ID: " & doctorId,
                                  "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim adminForm As AdminDashboard = TryCast(Application.OpenForms("AdminDashboard"), AdminDashboard)
                        If adminForm IsNot Nothing Then
                            adminForm.DoctorsSetupDataGrid()
                            adminForm.DoctorsPopulateDataGrid()
                        Else
                            MessageBox.Show("Admin dashboard not found. Please refresh the dashboard manually.",
                   "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        Me.Close()
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error registering doctor: " & ex.Message,
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function IsUsernameExists(conn As MySqlConnection, username As String) As Boolean
        Try
            Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As Exception
            Console.WriteLine("Error checking username: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub AddToUsersTable(conn As MySqlConnection, username As String, password As String)
        Try
            Dim query As String = "INSERT INTO users (username, password, role) VALUES (@username, @password, 'doctor')"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Console.WriteLine("Error adding to users table: " & ex.Message)
        End Try
    End Sub

    Private Function GenerateDoctorId(conn As MySqlConnection) As String
        Dim newId As String = "D001"

        Try
            Dim query As String = "SELECT doctor_id FROM doctor ORDER BY CAST(SUBSTRING(doctor_id, 2) AS UNSIGNED) DESC LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)
                Dim result As Object = cmd.ExecuteScalar()

                If result IsNot Nothing Then
                    Dim lastId As String = result.ToString()

                    If lastId.Length >= 2 AndAlso lastId.StartsWith("D") Then
                        Dim numericPart As Integer
                        If Integer.TryParse(lastId.Substring(1), numericPart) Then
                            numericPart += 1

                            If numericPart < 10 Then
                                newId = "D00" & numericPart
                            ElseIf numericPart < 100 Then
                                newId = "D0" & numericPart
                            Else
                                newId = "D" & numericPart
                            End If
                        End If
                    End If
                End If
            End Using
        Catch ex As Exception
            ' Log the error but continue with default ID
            Console.WriteLine("Error generating doctor ID: " & ex.Message)
            MessageBox.Show("Error generating doctor ID. Using default ID: " & newId,
                          "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return newId
    End Function
End Class
