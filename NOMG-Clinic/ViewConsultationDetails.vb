Imports Newtonsoft.Json
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class ViewConsultationDetails
    Public Property ConsultationID As String
    Public Property PatientID As String

    Private Sub ViewConsultationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisableAllControls()

        If Not String.IsNullOrEmpty(ConsultationID) Then
            LoadConsultationData()
        Else
            MessageBox.Show("No consultation ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    ' Disable all interactive controls
    Private Sub DisableAllControls()
        For Each control As Control In GetAllControlsOfType(Of TextBox)(Me)
            Dim textBox As TextBox = DirectCast(control, TextBox)
            textBox.ReadOnly = True
            textBox.Enabled = False
            textBox.TabStop = False
            textBox.BackColor = SystemColors.Control
        Next

        For Each control As Control In GetAllControlsOfType(Of ReaLTaiizor.Controls.SmallTextBox)(Me)
            Dim smallTextBox As ReaLTaiizor.Controls.SmallTextBox = DirectCast(control, ReaLTaiizor.Controls.SmallTextBox)
            smallTextBox.ReadOnly = True
            smallTextBox.CustomBGColor = SystemColors.Control
        Next

        For Each control As Control In GetAllControlsOfType(Of ComboBox)(Me)
            Dim comboBox As ComboBox = DirectCast(control, ComboBox)
            comboBox.Enabled = False
            comboBox.BackColor = SystemColors.Control
        Next

        For Each control As Control In GetAllControlsOfType(Of RadioButton)(Me)
            Dim radioButton As RadioButton = DirectCast(control, RadioButton)
            radioButton.Enabled = False
        Next
    End Sub

    ' Method to get all controls of a specific type
    Private Function GetAllControlsOfType(Of T As Control)(container As Control) As List(Of Control)
        Dim controls As New List(Of Control)

        For Each control As Control In container.Controls
            If TypeOf control Is T Then
                controls.Add(control)
            End If

            If control.HasChildren Then
                controls.AddRange(GetAllControlsOfType(Of T)(control))
            End If
        Next

        Return controls
    End Function

    Private Sub LoadConsultationData()
        Dim connectionString As String = "Server=localhost;Database=ob_gyn;Uid=root;Pwd=root;"

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Console.WriteLine($"Loading consultation with ID: {ConsultationID}")
                Console.WriteLine($"Patient ID: {PatientID}")

                LoadPatientDetails(connection)

                Dim consultationQuery As String = "
                SELECT 
                    c.consultation_id,
                    c.consultation_date,
                    c.diagnosis,
                    c.notes,
                    b.item_names
                FROM 
                    consultation c
                LEFT JOIN 
                    billing b ON c.consultation_id = b.consultation_id
                WHERE 
                    c.consultation_id = @consultationId"

                Using cmd As New MySqlCommand(consultationQuery, connection)
                    cmd.Parameters.AddWithValue("@consultationId", ConsultationID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblDate.Text = Convert.ToDateTime(reader("consultation_date")).ToString("MMMM dd, yyyy")

                            ' Load the JSON notes data
                            Dim notesJson As String = reader("notes").ToString()
                            Console.WriteLine("Raw notes from DB: " & notesJson)

                            If Not String.IsNullOrEmpty(notesJson) Then
                                Try
                                    ParseAndDisplayConsultationNotes(notesJson)
                                Catch ex As Exception
                                    Console.WriteLine($"Invalid JSON: {notesJson}")
                                    Console.WriteLine($"Error: {ex.Message}")
                                End Try
                            Else
                                Console.WriteLine("No notes found in consultation record")
                            End If

                            If Not reader.IsDBNull(reader.GetOrdinal("item_names")) Then
                                Dim itemNamesJson As String = reader("item_names").ToString()
                                Try
                                    ParseAndDisplayVitaminIntake(itemNamesJson)
                                Catch ex As Exception
                                    Console.WriteLine($"Invalid JSON: {itemNamesJson}")
                                End Try
                            End If
                        Else
                            MessageBox.Show("Consultation record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Close()
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error loading consultation data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine("Database Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadPatientDetails(connection As MySqlConnection)
        If String.IsNullOrEmpty(PatientID) Then
            Dim patientIdQuery As String = "SELECT patient_id FROM consultation WHERE consultation_id = @consultationId"

            Using patientIdCmd As New MySqlCommand(patientIdQuery, connection)
                patientIdCmd.Parameters.AddWithValue("@consultationId", ConsultationID)

                Dim result = patientIdCmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    PatientID = result.ToString()
                Else
                    MessageBox.Show("Could not find patient information for this consultation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                    Return
                End If
            End Using
        End If

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

                        Label6.Text = $"{weeks} WEEKS ({trimester})"
                    Else
                        Label6.Text = "Not available"
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
    End Sub

    Private Sub ParseAndDisplayConsultationNotes(jsonString As String)
        If String.IsNullOrEmpty(jsonString) Then Return

        Try
            Console.WriteLine("Raw consultation notes JSON: " & jsonString)

            Dim cleanedJson As String = CleanJsonString(jsonString)
            Console.WriteLine("Cleaned JSON: " & cleanedJson)

            Dim notesObject As Dictionary(Of String, Object)
            Try
                notesObject = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(cleanedJson)
            Catch ex As Exception
                Console.WriteLine("JSON deserialization error: " & ex.Message)
                If Not TryParseConsultationNotesWithRegex(jsonString) Then
                End If
                Return
            End Try

            ' Extract vitals
            If notesObject.ContainsKey("vitals") Then
                Try
                    Dim vitals = DirectCast(notesObject("vitals"), Newtonsoft.Json.Linq.JObject).ToObject(Of Dictionary(Of String, String))()
                    smlBloodPressure.Text = If(vitals.ContainsKey("blood_pressure"), vitals("blood_pressure"), "")
                    smlPulse.Text = If(vitals.ContainsKey("pulse"), vitals("pulse"), "")
                    smlTemperature.Text = If(vitals.ContainsKey("temperature"), vitals("temperature"), "")
                    smlWeight.Text = If(vitals.ContainsKey("weight"), vitals("weight"), "")
                Catch ex As Exception
                    Console.WriteLine("Error parsing vitals: " & ex.Message)
                End Try
            End If

            ' Extract examination
            If notesObject.ContainsKey("examination") Then
                Try
                    Dim examination = DirectCast(notesObject("examination"), Newtonsoft.Json.Linq.JObject).ToObject(Of Dictionary(Of String, String))()
                    txtFundalHeight.Text = If(examination.ContainsKey("fundal_height"), examination("fundal_height"), "")
                    txtFetalHeart.Text = If(examination.ContainsKey("fetal_heart_rate"), examination("fetal_heart_rate"), "")

                    If examination.ContainsKey("urine_analysis") Then
                        Select Case examination("urine_analysis").ToLower()
                            Case "protein" : rbProtein.Checked = True
                            Case "glucose" : rbGlucose.Checked = True
                            Case "ketones" : rbKetones.Checked = True
                            Case "blood" : rbBlood.Checked = True
                        End Select
                    End If
                Catch ex As Exception
                    Console.WriteLine("Error parsing examination: " & ex.Message)
                End Try
            End If

            ' Extract visit details
            If notesObject.ContainsKey("details") Then
                Try
                    Dim details = DirectCast(notesObject("details"), Newtonsoft.Json.Linq.JObject).ToObject(Of Dictionary(Of String, String))()
                    cmbVisitType.Text = If(details.ContainsKey("visit_type"), details("visit_type"), "")
                    cmbReasonVisit.Text = If(details.ContainsKey("reason"), details("reason"), "")
                    txtDoctorAssessment.Text = If(details.ContainsKey("assessment"), details("assessment"), "")
                    txtDoctorPlan.Text = If(details.ContainsKey("plan"), details("plan"), "")
                Catch ex As Exception
                    Console.WriteLine("Error parsing details: " & ex.Message)
                End Try
            End If

            ' Extract timestamp
            If notesObject.ContainsKey("timestamp") Then
                lblDate.Text = notesObject("timestamp").ToString()
            End If

        Catch ex As Exception
            Console.WriteLine("General parsing error: " & ex.Message)
            If Not TryParseConsultationNotesWithRegex(jsonString) Then
                MessageBox.Show($"Error parsing consultation notes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    ' Method to clean a JSON string before parsing
    Private Function CleanJsonString(strInput As String) As String
        If String.IsNullOrWhiteSpace(strInput) Then
            Return "{}"
        End If

        Dim cleaned = strInput.Trim().Replace("\""", """")

        cleaned = cleaned.Replace("\\", "\").Replace("\n", Environment.NewLine).Replace("\r", "")

        Dim startIndex = cleaned.IndexOfAny(New Char() {"{"c, "["c})
        Dim endIndex = cleaned.LastIndexOfAny(New Char() {"}"c, "]"c})

        If startIndex >= 0 AndAlso endIndex >= 0 AndAlso endIndex > startIndex Then
            cleaned = cleaned.Substring(startIndex, endIndex - startIndex + 1)
        End If

        Return cleaned
    End Function

    Private Sub ParseAndDisplayVitaminIntake(jsonString As String)
        If String.IsNullOrEmpty(jsonString) Then
            Return
        End If

        Try
            Console.WriteLine("Raw vitamin JSON " & jsonString)

            If jsonString.Trim() = "[2]" OrElse Regex.IsMatch(jsonString.Trim(), "^\[\d+\]$") Then
                txtVitaminIntake.Text = "No vitamin details available"
                Return
            End If

            Dim items As List(Of Dictionary(Of String, Object))

            Try
                items = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(jsonString)
            Catch ex As Exception
                Dim sanitizedJson As String = jsonString.Trim()

                If Not sanitizedJson.StartsWith("[") Then
                    sanitizedJson = "[" & sanitizedJson & "]"
                End If

                Try
                    items = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(sanitizedJson)
                Catch innerEx As Exception
                    If Not TryParseVitaminIntakeWithRegex(jsonString) Then
                    End If
                    Return
                End Try
            End Try

            Dim formattedItems As New List(Of String)

            For Each item In items
                Dim itemName As String = If(item.ContainsKey("item_name"), item("item_name").ToString(), "")
                Dim description As String = If(item.ContainsKey("description"), item("description").ToString().ToLower(), "")

                Dim quantity As Integer = 0
                If item.ContainsKey("quantity") Then
                    Integer.TryParse(item("quantity").ToString(), quantity)
                End If

                If Not String.IsNullOrEmpty(itemName) AndAlso quantity > 0 Then
                    formattedItems.Add($"{itemName} ({description}) x {quantity}")
                ElseIf Not String.IsNullOrEmpty(itemName) Then
                    formattedItems.Add(itemName)
                End If
            Next

            txtVitaminIntake.Text = String.Join(Environment.NewLine, formattedItems)

        Catch ex As Exception
            MessageBox.Show($"Error parsing vitamin intake: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Regex as a fallback
    Private Function TryParseConsultationNotesWithRegex(jsonString As String) As Boolean
        Try
            Dim bpMatch = Regex.Match(jsonString, """blood_pressure""\s*:\s*""?([^"",}]+)""?")
            If bpMatch.Success Then
                smlBloodPressure.Text = bpMatch.Groups(1).Value
            End If

            Dim pulseMatch = Regex.Match(jsonString, """pulse""\s*:\s*""?([^"",}]+)""?")
            If pulseMatch.Success Then
                smlPulse.Text = pulseMatch.Groups(1).Value
            End If

            Dim tempMatch = Regex.Match(jsonString, """temperature""\s*:\s*""?([^"",}]+)""?")
            If tempMatch.Success Then
                smlTemperature.Text = tempMatch.Groups(1).Value
            End If

            Dim weightMatch = Regex.Match(jsonString, """weight""\s*:\s*""?([^"",}]+)""?")
            If weightMatch.Success Then
                smlWeight.Text = weightMatch.Groups(1).Value
            End If

            ' Extract examination data
            Dim heightMatch = Regex.Match(jsonString, """fundal_height""\s*:\s*""?([^"",}]+)""?")
            If heightMatch.Success Then
                txtFundalHeight.Text = heightMatch.Groups(1).Value
            End If

            Dim fetalHeartMatch = Regex.Match(jsonString, """fetal_heart_rate""\s*:\s*""?([^"",}]+)""?")
            If fetalHeartMatch.Success Then
                txtFetalHeart.Text = fetalHeartMatch.Groups(1).Value
            End If

            ' Extract urine analysis
            Dim urineMatch = Regex.Match(jsonString, """urine_analysis""\s*:\s*""?([^"",}]+)""?")
            If urineMatch.Success Then
                Select Case urineMatch.Groups(1).Value.ToLower()
                    Case "protein"
                        rbProtein.Checked = True
                    Case "glucose"
                        rbGlucose.Checked = True
                    Case "ketones"
                        rbKetones.Checked = True
                    Case "blood"
                        rbBlood.Checked = True
                End Select
            End If

            ' Extract visit details
            Dim visitTypeMatch = Regex.Match(jsonString, """visit_type""\s*:\s*""?([^"",}]+)""?")
            If visitTypeMatch.Success Then
                cmbVisitType.Text = visitTypeMatch.Groups(1).Value.Replace("""", "")
            End If

            Dim reasonMatch = Regex.Match(jsonString, """reason""\s*:\s*""?([^"",}]+)""?")
            If reasonMatch.Success Then
                cmbReasonVisit.Text = reasonMatch.Groups(1).Value.Replace("""", "")
            End If

            Dim assessmentMatch = Regex.Match(jsonString, """assessment""\s*:\s*""?([^"",}]+)""?")
            If assessmentMatch.Success Then
                txtDoctorAssessment.Text = assessmentMatch.Groups(1).Value.Replace("""", "")
            End If

            Dim planMatch = Regex.Match(jsonString, """plan""\s*:\s*""?([^"",}]+)""?")
            If planMatch.Success Then
                txtDoctorPlan.Text = planMatch.Groups(1).Value.Replace("""", "")
            End If

            ' Extract timestamp
            Dim timestampMatch = Regex.Match(jsonString, """timestamp""\s*:\s*""?([^"",}]+)""?")
            If timestampMatch.Success Then
                lblDate.Text = timestampMatch.Groups(1).Value.Replace("""", "")
            End If

            Return (bpMatch.Success Or pulseMatch.Success Or tempMatch.Success Or weightMatch.Success Or
               heightMatch.Success Or fetalHeartMatch.Success Or urineMatch.Success Or
               visitTypeMatch.Success Or reasonMatch.Success Or assessmentMatch.Success Or planMatch.Success)

        Catch ex As Exception
            Console.WriteLine($"Regex parsing failed: {ex.Message}")
            Return False
        End Try
    End Function


    ' Regex as a fallback
    Private Function TryParseVitaminIntakeWithRegex(jsonString As String) As Boolean
        Try
            Dim itemMatches = Regex.Matches(jsonString, "\{[^\}]*""item_name""\s*:\s*""([^""]+)""[^\}]*\}")
            If itemMatches.Count = 0 Then
                Return False
            End If

            Dim formattedItems As New List(Of String)

            For Each match As Match In itemMatches
                Dim itemText As String = match.Value

                Dim nameMatch = Regex.Match(itemText, """item_name""\s*:\s*""([^""]+)""")
                Dim descMatch = Regex.Match(itemText, """description""\s*:\s*""([^""]+)""")
                Dim qtyMatch = Regex.Match(itemText, """quantity""\s*:\s*(\d+)")

                If nameMatch.Success Then
                    Dim itemName As String = nameMatch.Groups(1).Value
                    Dim description As String = If(descMatch.Success, descMatch.Groups(1).Value.ToLower(), "")
                    Dim quantity As Integer = If(qtyMatch.Success, Integer.Parse(qtyMatch.Groups(1).Value), 0)

                    formattedItems.Add($"{itemName} ({description}) x {quantity}")
                End If
            Next

            txtVitaminIntake.Text = String.Join(Environment.NewLine, formattedItems)
            Return formattedItems.Count > 0

        Catch ex As Exception
            Console.WriteLine($"Regex vitamin parsing failed: {ex.Message}")
            Return False
        End Try
    End Function

    ' Method to check if a string is valid JSON
    Private Function IsValidJson(strInput As String) As Boolean
        If String.IsNullOrWhiteSpace(strInput) Then
            Return False
        End If

        strInput = strInput.Trim()

        If (strInput.StartsWith("{") AndAlso strInput.EndsWith("}")) OrElse
           (strInput.StartsWith("[") AndAlso strInput.EndsWith("]")) Then
            Try
                Dim obj = Newtonsoft.Json.Linq.JToken.Parse(strInput)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

        Return False
    End Function

    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        If keyData = Keys.Tab Then
            Return True
        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function
End Class
