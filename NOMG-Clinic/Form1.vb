Imports FontAwesome.Sharp
Imports MySql.Data.MySqlClient

Public Class Form1
    ' Variable to track the visibility state of the password
    Private isPasswordVisible As Boolean = False

    Dim conn As MySqlConnection
    Dim cmd As MySqlCommand
    Dim reader As MySqlDataReader

    Private Sub btnEyeIcon_Click(sender As Object, e As EventArgs) Handles btnEyeIcon.Click
        isPasswordVisible = Not isPasswordVisible

        txtPassword.UseSystemPasswordChar = Not isPasswordVisible

        If isPasswordVisible Then
            btnEyeIcon.IconChar = IconChar.EyeSlash ' Show "eye-slash" icon
        Else
            btnEyeIcon.IconChar = IconChar.Eye ' Show "eye" icon
        End If
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If username = "" Or password = "" Then
            MessageBox.Show("Please enter both username and password.")
            Return
        End If

        Try
            conn = New MySqlConnection("server=localhost;userid=root;password=root;database=ob_gyn;")
            conn.Open()

            Dim query As String = "SELECT role FROM users WHERE username like binary @username AND password like binary @password"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)

            reader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim role As String = reader("role").ToString()
                Select Case role.ToLower()
                    Case "admin"
                        Dim adminForm As New AdminDashboard()
                        adminForm.Show()
                    Case "doctor"
                        reader.Close()
                        Dim doctorQuery As String = "SELECT doctor_id FROM doctor WHERE username = @username AND password = @password"
                        cmd = New MySqlCommand(doctorQuery, conn)
                        cmd.Parameters.AddWithValue("@username", username)
                        cmd.Parameters.AddWithValue("@password", password)

                        reader = cmd.ExecuteReader()

                        If reader.Read() Then
                            Dim doctorID As String = reader("doctor_id").ToString()
                            Dim doctorForm As New DoctorDashboard()
                            doctorForm.doctorID = doctorID
                            doctorForm.Show()
                        Else
                            MessageBox.Show("Doctor record not found.")
                            Return
                        End If
                    Case "nurse"
                        reader.Close()
                        Dim nurseQuery As String = "SELECT nurse_id FROM nurse WHERE username = @username AND password = @password"
                        cmd = New MySqlCommand(nurseQuery, conn)
                        cmd.Parameters.AddWithValue("@username", username)
                        cmd.Parameters.AddWithValue("@password", password)

                        reader = cmd.ExecuteReader()

                        If reader.Read() Then
                            Dim nurseID As String = reader("nurse_id").ToString()
                            Dim nurseForm As New NurseDashboard()
                            nurseForm.nurseID = nurseID
                            nurseForm.Show()
                        Else
                            MessageBox.Show("Nurse record not found.")
                            Return
                        End If
                    Case "accountant"
                        reader.Close()
                        Dim accountantQuery As String = "SELECT accountant_id FROM accountant WHERE username = @username AND password = @password"
                        cmd = New MySqlCommand(accountantQuery, conn)
                        cmd.Parameters.AddWithValue("@username", username)
                        cmd.Parameters.AddWithValue("@password", password)

                        reader = cmd.ExecuteReader()

                        If reader.Read() Then
                            Dim accountantID As String = reader("accountant_id").ToString()
                            Dim accountantForm As New AccountingDashboard()
                            accountantForm.AccountantID = accountantID
                            accountantForm.Show()
                        Else
                            MessageBox.Show("Accountant record not found.")
                            Return
                        End If
                    Case "patient"
                        MsgBox("Patient ID: " & reader("patient_id").ToString())
                    Case Else
                        MessageBox.Show("Unknown role.")
                        Return
                End Select

                Me.Hide() ' Hide login form
            Else
                MessageBox.Show("Invalid username or password.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class