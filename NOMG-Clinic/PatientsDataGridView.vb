Imports System.Windows.Forms
Imports System.Drawing

Public Class PatientsDataGridView
    Inherits DataGridView

    Public Sub New()
        ' Configure the DataGridView
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.ReadOnly = True
        Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.MultiSelect = False
        Me.BackgroundColor = Color.White
        Me.BorderStyle = BorderStyle.Fixed3D
        Me.RowHeadersVisible = False
        Me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Row height and padding
        Me.RowTemplate.Height = 40
        Me.DefaultCellStyle.Padding = New Padding(5, 0, 5, 0)

        ' Disable column and row resizing
        Me.AllowUserToResizeColumns = False
        Me.AllowUserToResizeRows = False

        ' Enable scrollbars when needed
        Me.ScrollBars = ScrollBars.Both

        ' Add columns to the DataGridView
        Me.Columns.Add("Name", "Name")
        Me.Columns.Add("Age", "Age")
        Me.Columns.Add("GestationalAge", "Gestational Age")
        Me.Columns.Add("AssignedOB", "Assigned OB")
        Me.Columns.Add("NextCheckup", "Next Checkup")
        Me.Columns.Add("FirstBaby", "First Baby")

        ' Add a button column for the ellipsis menu
        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = ""
        buttonColumn.Text = "•••"
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Flat
        Me.Columns.Add(buttonColumn)

        ' Set minimum and proportional column widths
        Me.Columns("Name").MinimumWidth = 150
        Me.Columns("Age").MinimumWidth = 80
        Me.Columns("GestationalAge").MinimumWidth = 120
        Me.Columns("AssignedOB").MinimumWidth = 130
        Me.Columns("NextCheckup").MinimumWidth = 130
        Me.Columns("FirstBaby").MinimumWidth = 80
        buttonColumn.MinimumWidth = 60

        ' Set relative column widths using Fill mode
        Me.Columns("Name").FillWeight = 20
        Me.Columns("Age").FillWeight = 8
        Me.Columns("GestationalAge").FillWeight = 18
        Me.Columns("AssignedOB").FillWeight = 18
        Me.Columns("NextCheckup").FillWeight = 18
        Me.Columns("FirstBaby").FillWeight = 10
        buttonColumn.FillWeight = 8
    End Sub

    Public Sub PopulateData()
        ' Add sample data
        Me.Rows.Add("Maria Garcia", "28", "12 weeks", "Dr. Johnson", "Jul 15, 2023", "Yes")
        Me.Rows.Add("Sarah Lee", "32", "24 weeks", "Dr. Martinez", "Jul 10, 2023", "No")
        Me.Rows.Add("Emily Chen", "26", "8 weeks", "Dr. Johnson", "Jul 20, 2023", "Yes")
        Me.Rows.Add("Jessica Wong", "30", "32 weeks", "Dr. Patel", "Jul 5, 2023", "No")
        Me.Rows.Add("Amanda Taylor", "29", "16 weeks", "Dr. Martinez", "Jul 18, 2023", "Yes")

        ' Add more rows to test scrolling
        For i As Integer = 1 To 15
            Me.Rows.Add("Patient " & i, "30", "20 weeks", "Dr. Smith", "Jul 25, 2023", "No")
        Next
    End Sub
End Class
