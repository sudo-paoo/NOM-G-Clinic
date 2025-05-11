Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class DoctorRegistration
    Private errProvider As New ErrorProvider()
    Private isPasswordVisible As Boolean = False
    Private isConfirmPasswordVisible As Boolean = False

    Private Sub DoctorRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabDoctorRegistration.ItemSize = New Size(tabDoctorRegistration.Width \ tabDoctorRegistration.TabCount - 2, 30)

        errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink

        ' Position the error icons
        errProvider.SetIconAlignment(txtPassword, ErrorIconAlignment.TopLeft)
        errProvider.SetIconAlignment(txtConfirmPassword, ErrorIconAlignment.TopLeft)
        errProvider.SetIconPadding(txtPassword, 10)
        errProvider.SetIconPadding(txtConfirmPassword, 10)

        ' Disable TabPages 2 and 3 initially
        tabDoctorRegistration.TabPages(1).Enabled = False
        tabDoctorRegistration.TabPages(2).Enabled = False

        ' Set up password fields
        txtPassword.UseSystemPasswordChar = True
        txtConfirmPassword.UseSystemPasswordChar = True

        txtUsername.Focus()

        ' Set up validation for account information fields
        AddHandler txtUsername.Validating, AddressOf ValidateRequiredField
        AddHandler txtPassword.Validating, AddressOf ValidateRequiredField
        AddHandler txtConfirmPassword.Validating, AddressOf ValidateConfirmPassword
        AddHandler txtContactNumber.TextChanged, AddressOf txtContactNumber_TextChanged
        AddHandler txtEmailAddress.TextChanged, AddressOf txtEmailAddress_TextChanged
        AddHandler txtContactNumber.KeyPress, AddressOf txtContactNumber_KeyPress

        btnEyePassword.TabStop = False
        btnEyeConfirmPassword.TabStop = False
    End Sub

    ' Handle Enter key for txtUsername to move to txtPassword
    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for txtPassword to move to txtConfirmPassword
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtConfirmPassword.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Simulate btnAccountInformationNext click
    Private Sub txtConfirmPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConfirmPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAccountInformationNext.PerformClick()
            e.SuppressKeyPress = True
        End If
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

    ' Handle Enter key for numAge to move to txtGender
    Private Sub numAge_KeyDown(sender As Object, e As KeyEventArgs) Handles numAge.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGender.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Handle Enter key for txtGender to move to txtLicenseNumber
    Private Sub txtGender_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGender.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLicenseNumber.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Simulate btnPersonalInformationNext click
    Private Sub txtLicenseNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLicenseNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnPersonalInformationNext.PerformClick()
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

    ' Simulate btnRegisterDoctor click
    Private Sub txtEmailAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmailAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnRegisterDoctor.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtContactNumber_KeyPress(sender As Object, e As KeyPressEventArgs)
        RegistrationModule.HandleNumericKeyPress(e)

        Dim textBox = DirectCast(sender, TextBox)
        If textBox.Text.Length >= 11 And e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
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
        RegistrationModule.TogglePasswordVisibility(txtPassword, btnEyePassword, isPasswordVisible)
    End Sub

    Private Sub btnEyeConfirmPassword_MouseDown(sender As Object, e As MouseEventArgs) Handles btnEyeConfirmPassword.MouseDown
        RegistrationModule.TogglePasswordVisibility(txtConfirmPassword, btnEyeConfirmPassword, isConfirmPasswordVisible)
    End Sub

    ' Validation functions
    Private Function ValidateAccountInformation() As Boolean
        Dim isValid As Boolean = True

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            errProvider.SetError(txtUsername, "Username is required.")
            isValid = False
        Else
            ' Check if username exists
            Try
                If RegistrationModule.IsUsernameExists(txtUsername.Text.Trim()) Then
                    errProvider.SetError(txtUsername, "Username already exists. Please choose another.")
                    isValid = False
                Else
                    errProvider.SetError(txtUsername, "")
                End If
            Catch ex As Exception
                Console.WriteLine("Database error when checking username: " & ex.Message)
                errProvider.SetError(txtUsername, "")
            End Try
        End If

        ' Validate Password
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            errProvider.SetError(txtPassword, "Password is required.")
            isValid = False
        Else
            errProvider.SetError(txtPassword, "")
        End If

        ' Validate Confirm Password
        If String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then
            errProvider.SetError(txtConfirmPassword, "Confirm Password is required.")
            isValid = False
        ElseIf txtConfirmPassword.Text <> txtPassword.Text Then
            errProvider.SetError(txtConfirmPassword, "Passwords do not match.")
            isValid = False
        Else
            errProvider.SetError(txtConfirmPassword, "")
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
        RegistrationModule.ValidateRequiredField(sender, e, errProvider)
    End Sub

    Private Sub ValidateConfirmPassword(sender As Object, e As CancelEventArgs)
        Dim confirmPasswordTextBox = DirectCast(sender, TextBox)
        RegistrationModule.ValidateConfirmPassword(confirmPasswordTextBox, txtPassword, e, errProvider)
    End Sub

    Private Sub txtPassword_DoubleClick(sender As Object, e As EventArgs) Handles txtPassword.DoubleClick
        RegistrationModule.TogglePasswordVisibility(txtPassword, btnEyePassword, isPasswordVisible)
    End Sub

    Private Sub txtConfirmPassword_DoubleClick(sender As Object, e As EventArgs) Handles txtConfirmPassword.DoubleClick
        RegistrationModule.TogglePasswordVisibility(txtConfirmPassword, btnEyeConfirmPassword, isConfirmPasswordVisible)
    End Sub

    ' Clear validation errors when text changes
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        errProvider.SetError(txtUsername, "")
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        errProvider.SetError(txtPassword, "")
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        errProvider.SetError(txtConfirmPassword, "")
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

    Private Sub txtContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtContactNumber.TextChanged
        If txtContactNumber.Text.Length > 11 Then
            txtContactNumber.Text = txtContactNumber.Text.Substring(0, 11)
            txtContactNumber.SelectionStart = 11
        End If
        RegistrationModule.ValidateContactNumber(txtContactNumber, errProvider)
    End Sub


    Private Sub txtEmailAddress_TextChanged(sender As Object, e As EventArgs) Handles txtEmailAddress.TextChanged
        RegistrationModule.ValidateEmail(txtEmailAddress, errProvider)
    End Sub

    Private Function ValidateContactInformation() As Boolean
        Dim isValid As Boolean = True

        ' Validate Contact Number
        If String.IsNullOrWhiteSpace(txtContactNumber.Text) Then
            errProvider.SetError(txtContactNumber, "Contact Number is required.")
            isValid = False
        ElseIf Not RegistrationModule.IsNumeric(txtContactNumber.Text.Trim()) Then
            errProvider.SetError(txtContactNumber, "Contact Number must contain only numbers.")
            isValid = False
        Else
            errProvider.SetError(txtContactNumber, "")
        End If

        ' Validate Email
        If String.IsNullOrWhiteSpace(txtEmailAddress.Text) Then
            errProvider.SetError(txtEmailAddress, "Email Address is required.")
            isValid = False
        ElseIf Not RegistrationModule.IsValidEmail(txtEmailAddress.Text.Trim()) Then
            errProvider.SetError(txtEmailAddress, "Please enter a valid email address (example@domain.com).")
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

                Using conn As New MySqlConnection(RegistrationModule.ConnectionString)
                    conn.Open()

                    If RegistrationModule.IsUsernameExists(txtUsername.Text.Trim()) Then
                        MessageBox.Show("Username already exists. Please choose another username.",
                                  "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tabDoctorRegistration.SelectedIndex = 0
                        txtUsername.Focus()
                        Return
                    End If

                    ' Generate a new doctor ID
                    Dim doctorId As String = RegistrationModule.GenerateId("doctor", "doctor_id", "D", 3)

                    Dim query As String = "INSERT INTO doctor (doctor_id, username, password, first_name, middle_name, last_name, age, " &
                                   "license_number, email, contact_number, gender, address) " &
                                   "VALUES (@doctorId, @username, @password, @firstName, @middleName, @lastName, @age, " &
                                   "@licenseNumber, @email, @contactNumber, @gender, @address)"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@doctorId", doctorId)
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
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

                        RegistrationModule.AddToUsersTable(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "doctor")

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
End Class