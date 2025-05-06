Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Module RegistrationModule
    Public Const ConnectionString As String = "server=localhost;userid=root;password=root;database=ob_gyn;"

    ' Check if username exists in database
    Public Function IsUsernameExists(username As String) As Boolean
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error checking username: " & ex.Message)
            Return False
        End Try
    End Function

    ' Add user to users table for login
    Public Sub AddToUsersTable(username As String, password As String, role As String)
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()
                Dim query As String = "INSERT INTO users (username, password, role) VALUES (@username, @password, @role)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.Parameters.AddWithValue("@role", role)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error adding to users table: " & ex.Message)
            Throw
        End Try
    End Sub

    ' Generate ID with prefix (N for Nurse, ACC for Accountant, D for Doctor)
    Public Function GenerateId(tableName As String, idColumnName As String, prefix As String, padLength As Integer) As String
        Dim newId As String = prefix & New String("0", padLength - 1) & "1" ' Default ID (e.g., "N001" or "ACC001")

        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()
                Dim query As String = $"SELECT {idColumnName} FROM {tableName} " &
                                     $"ORDER BY CAST(SUBSTRING({idColumnName}, {prefix.Length + 1}) AS UNSIGNED) DESC LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)
                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing Then
                        Dim lastId As String = result.ToString()

                        If lastId.Length >= prefix.Length AndAlso lastId.StartsWith(prefix) Then
                            Dim numericPart As Integer
                            If Integer.TryParse(lastId.Substring(prefix.Length), numericPart) Then
                                numericPart += 1

                                ' Format with leading zeros based on padLength
                                Dim formatString As String = "D" & padLength
                                newId = prefix & numericPart.ToString(formatString)
                            End If
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error generating {tableName} ID: " & ex.Message)
        End Try

        Return newId
    End Function

    ' Toggle password visibility
    Public Sub TogglePasswordVisibility(passwordTextBox As TextBox, eyeButton As FontAwesome.Sharp.IconButton,
                                      ByRef visibilityState As Boolean)
        visibilityState = Not visibilityState
        passwordTextBox.UseSystemPasswordChar = Not visibilityState

        If visibilityState Then
            eyeButton.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
        Else
            eyeButton.IconChar = FontAwesome.Sharp.IconChar.Eye
        End If
    End Sub

    ' Validate if field is empty
    Public Sub ValidateRequiredField(sender As Object, e As CancelEventArgs, errProvider As ErrorProvider)
        Dim textBox = DirectCast(sender, TextBox)

        If String.IsNullOrWhiteSpace(textBox.Text) Then
            errProvider.SetError(textBox, "This field is required.")
            e.Cancel = True
        Else
            errProvider.SetError(textBox, "")
        End If
    End Sub

    ' Validate confirm password matches
    Public Sub ValidateConfirmPassword(confirmPasswordTextBox As TextBox, passwordTextBox As TextBox,
                                      e As CancelEventArgs, errProvider As ErrorProvider)
        If String.IsNullOrWhiteSpace(confirmPasswordTextBox.Text) Then
            errProvider.SetError(confirmPasswordTextBox, "Confirm Password is required.")
            e.Cancel = True
        ElseIf confirmPasswordTextBox.Text <> passwordTextBox.Text Then
            errProvider.SetError(confirmPasswordTextBox, "Passwords do not match.")
            e.Cancel = True
        Else
            errProvider.SetError(confirmPasswordTextBox, "")
        End If
    End Sub

    ' Check if a string is a valid email address
    Public Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False

        ' Pattern to match basic email format (name@domain.tld)
        Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        Return Regex.IsMatch(email, pattern)
    End Function

    ' Check if string contains only numeric characters
    Public Function IsNumeric(text As String) As Boolean
        If String.IsNullOrWhiteSpace(text) Then Return False

        Return text.All(Function(c) Char.IsDigit(c))
    End Function

    ' Validate and apply error provider for contact number
    Public Sub ValidateContactNumber(contactTextBox As TextBox, errProvider As ErrorProvider, Optional e As CancelEventArgs = Nothing)
        If String.IsNullOrWhiteSpace(contactTextBox.Text) Then
            errProvider.SetError(contactTextBox, "Contact Number is required.")
            If e IsNot Nothing Then e.Cancel = True
        ElseIf Not IsNumeric(contactTextBox.Text.Trim()) Then
            errProvider.SetError(contactTextBox, "Contact Number must contain only numbers.")
            If e IsNot Nothing Then e.Cancel = True
        Else
            errProvider.SetError(contactTextBox, "")
        End If
    End Sub

    ' Validate and apply error provider for email address
    Public Sub ValidateEmail(emailTextBox As TextBox, errProvider As ErrorProvider, Optional e As CancelEventArgs = Nothing)
        If String.IsNullOrWhiteSpace(emailTextBox.Text) Then
            errProvider.SetError(emailTextBox, "Email Address is required.")
            If e IsNot Nothing Then e.Cancel = True
        ElseIf Not IsValidEmail(emailTextBox.Text.Trim()) Then
            errProvider.SetError(emailTextBox, "Please enter a valid email address (example@domain.com).")
            If e IsNot Nothing Then e.Cancel = True
        Else
            errProvider.SetError(emailTextBox, "")
        End If
    End Sub

    ' Restrict input to numeric only for KeyPress events
    Public Sub HandleNumericKeyPress(e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Module
