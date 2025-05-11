Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class AccountantRegistration
    Private errProvider As New ErrorProvider()
    Private isPasswordVisible As Boolean = False
    Private isConfirmPasswordVisible As Boolean = False

    Private Sub AccountantRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabAccountantRegistration.ItemSize = New Size(tabAccountantRegistration.Width \ tabAccountantRegistration.TabCount - 2, 30)

        errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink

        ' Position the error icons
        errProvider.SetIconAlignment(txtPassword, ErrorIconAlignment.TopLeft)
        errProvider.SetIconAlignment(txtConfirmPassword, ErrorIconAlignment.TopLeft)
        errProvider.SetIconPadding(txtPassword, 10)
        errProvider.SetIconPadding(txtConfirmPassword, 10)

        ' Disable TabPages 2 and 3 initially
        tabAccountantRegistration.TabPages(1).Enabled = False
        tabAccountantRegistration.TabPages(2).Enabled = False

        ' Set up password fields
        txtPassword.UseSystemPasswordChar = True
        txtConfirmPassword.UseSystemPasswordChar = True

        ' Set up validation for account information fields
        AddHandler txtUsername.Validating, AddressOf ValidateRequiredField
        AddHandler txtPassword.Validating, AddressOf ValidateRequiredField
        AddHandler txtConfirmPassword.Validating, AddressOf ValidateConfirmPassword

        btnEyePassword.TabStop = False
        btnEyeConfirmPassword.TabStop = False
    End Sub



    Private Sub tabAccountantRegistration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabAccountantRegistration.SelectedIndexChanged
        If Not tabAccountantRegistration.SelectedTab.Enabled Then
            For i As Integer = 0 To tabAccountantRegistration.TabPages.Count - 1
                If tabAccountantRegistration.TabPages(i).Enabled Then
                    tabAccountantRegistration.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnAccountInformationNext_Click(sender As Object, e As EventArgs) Handles btnAccountInformationNext.Click
        ' Validate all account information fields before proceeding
        If ValidateAccountInformation() Then
            tabAccountantRegistration.TabPages(1).Enabled = True
            tabAccountantRegistration.SelectedIndex = 1
        Else
            MessageBox.Show("Please fill all required fields correctly. Make sure passwords match.",
                          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Personal Information Next button
    Private Sub btnPersonalInformationNext_Click(sender As Object, e As EventArgs) Handles btnPersonalInformationNext.Click
        ' Validate all personal information fields before proceeding
        If ValidatePersonalInformation() Then
            tabAccountantRegistration.TabPages(2).Enabled = True
            tabAccountantRegistration.SelectedIndex = 2
        Else
            MessageBox.Show("Please fill all required fields with valid information.",
                          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Previous buttons
    Private Sub btnPersonalInformationPrevious_Click(sender As Object, e As EventArgs) Handles btnPersonalInformationPrevious.Click
        Me.ActiveControl = btnPersonalInformationPrevious
        tabAccountantRegistration.SelectedIndex = 0
    End Sub

    Private Sub btnContactInformationPrevious_Click(sender As Object, e As EventArgs) Handles btnContactInformationPrevious.Click
        Me.ActiveControl = btnContactInformationPrevious
        tabAccountantRegistration.SelectedIndex = 1
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

        ' Validate Position
        If String.IsNullOrWhiteSpace(cmbPosition.Text) Then
            errProvider.SetError(cmbPosition, "Position is required.")
            isValid = False
        Else
            errProvider.SetError(cmbPosition, "")
        End If

        Return isValid
    End Function

    Private Sub ValidateRequiredField(sender As Object, e As CancelEventArgs)
        RegistrationModule.ValidateRequiredField(sender, e, errProvider)
    End Sub

    Private Sub ValidateConfirmPassword(sender As Object, e As CancelEventArgs)
        RegistrationModule.ValidateConfirmPassword(txtConfirmPassword, txtPassword, e, errProvider)
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
        ElseIf txtContactNumber.Text.Trim().Length <> 11 Then
            errProvider.SetError(txtContactNumber, "Contact Number must be exactly 11 digits.")
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


    Private Sub btnRegisterAccountant_Click(sender As Object, e As EventArgs) Handles btnRegisterAccountant.Click
        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to register this accountant?",
        "Confirm Registration",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

        ' If user confirms, save the accountant
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
                        tabAccountantRegistration.SelectedIndex = 0
                        txtUsername.Focus()
                        Return
                    End If

                    ' Generate a new accountant ID
                    Dim accountantId As String = RegistrationModule.GenerateId("accountant", "accountant_id", "ACC", 3)

                    Dim query As String = "INSERT INTO accountant (accountant_id, username, password, first_name, middle_name, last_name, age, " &
                                   "position, email_address, contact_number, gender, address) " &
                                   "VALUES (@accountantId, @username, @password, @firstName, @middleName, @lastName, @age, " &
                                   "@position, @email, @contactNumber, @gender, @address)"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@accountantId", accountantId)
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
                        cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim())
                        cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), "", txtMiddleName.Text.Trim()))
                        cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim())
                        cmd.Parameters.AddWithValue("@age", numAge.Value)
                        cmd.Parameters.AddWithValue("@position", cmbPosition.Text.Trim())
                        cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.Trim())
                        cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text.Trim())
                        cmd.Parameters.AddWithValue("@gender", txtGender.Text.Trim())
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim())

                        cmd.ExecuteNonQuery()

                        ' Also add this accountant to the users table for login
                        RegistrationModule.AddToUsersTable(txtUsername.Text.Trim(), txtPassword.Text.Trim(), "accountant")

                        ' Show success message
                        MessageBox.Show("Accountant successfully registered with ID: " & accountantId,
                                  "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim adminForm As AdminDashboard = TryCast(Application.OpenForms("AdminDashboard"), AdminDashboard)
                        If adminForm IsNot Nothing Then
                            ' Call method to refresh accountant grid if it exists
                            Try
                                adminForm.AccountantsSetupDataGrid()
                                adminForm.AccountantsPopulateDataGrid()
                            Catch ex As Exception
                                MessageBox.Show("Could not refresh the accountant list: " & ex.Message,
                                          "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End Try
                        End If
                        Me.Close()
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error registering accountant: " & ex.Message,
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
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

    Private Sub cmbPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPosition.SelectedIndexChanged
        errProvider.SetError(cmbPosition, "")
    End Sub

    Private Sub numAge_ValueChanged(sender As Object, e As EventArgs) Handles numAge.ValueChanged
        errProvider.SetError(numAge, "")
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged
        errProvider.SetError(txtAddress, "")
    End Sub

    Private Sub txtContactNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNumber.KeyPress
        RegistrationModule.HandleNumericKeyPress(e)

        Dim textBox = DirectCast(sender, TextBox)
        If textBox.Text.Length >= 11 And e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
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
End Class
