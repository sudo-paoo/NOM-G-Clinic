Imports System.Windows.Forms
Imports System.Drawing

Public Class DoctorsDataGridView
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
        Me.Columns.Add("Specialty", "Specialty")
        Me.Columns.Add("Email", "Email")
        Me.Columns.Add("Phone", "Phone")
        Me.Columns.Add("Status", "Status")
        Me.Columns.Add("Patients", "Patients")

        ' Add a button column for the ellipsis menu
        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = ""
        buttonColumn.Text = "•••"
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Flat
        Me.Columns.Add(buttonColumn)

        ' Set minimum and proportional column widths
        Me.Columns("Name").MinimumWidth = 120
        Me.Columns("Specialty").MinimumWidth = 120
        Me.Columns("Email").MinimumWidth = 150
        Me.Columns("Phone").MinimumWidth = 120
        Me.Columns("Status").MinimumWidth = 100
        Me.Columns("Patients").MinimumWidth = 80
        buttonColumn.MinimumWidth = 60

        ' Set relative column widths using Fill mode
        Me.Columns("Name").FillWeight = 15
        Me.Columns("Specialty").FillWeight = 15
        Me.Columns("Email").FillWeight = 20
        Me.Columns("Phone").FillWeight = 15
        Me.Columns("Status").FillWeight = 15
        Me.Columns("Patients").FillWeight = 10
        buttonColumn.FillWeight = 10
    End Sub

    Public Sub PopulateData()
        ' Add sample data
        Me.Rows.Add("Dr. Johnson", "Obstetrics", "johnson@nomg.com", "(555) 123-4567", "Available", "45")
        Me.Rows.Add("Dr. Martinez", "Gynecology", "martinez@nomg.com", "(555) 234-5678", "Available", "38")
        Me.Rows.Add("Dr. Patel", "Obstetrics", "patel@nomg.com", "(555) 345-6789", "Available", "42")
        Me.Rows.Add("Dr. Wilson", "Gynecology", "wilson@nomg.com", "(555) 456-7890", "On Leave", "29")
        Me.Rows.Add("Dr. Thompson", "Obstetrics", "thompson@nomg.com", "(555) 567-8901", "Available", "41")
    End Sub
End Class
