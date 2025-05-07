Public Class TransactionItem
    Inherits UserControl

    Private iconBox As New Label()
    Private descLbl As New Label()
    Private dateLbl As New Label()
    Private priceLbl As New Label()
    Private badge As New Label()
    Private separator As New Panel()

    Public Sub New(description As String, txDate As Date, amount As Decimal, status As String)
        Me.Height = 65
        Me.BackColor = Color.Transparent
        Me.Margin = New Padding(0, 0, 0, 5)

        ' === Icon Circle ===
        iconBox.Text = "🧾"
        iconBox.Font = New Font("Segoe UI Emoji", 16)
        iconBox.BackColor = Color.Gainsboro
        iconBox.ForeColor = Color.Black
        iconBox.Size = New Size(36, 36)
        iconBox.TextAlign = ContentAlignment.MiddleCenter
        iconBox.Location = New Point(10, 14)
        Dim path As New Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, iconBox.Width, iconBox.Height)
        iconBox.Region = New Region(path)

        ' === Description ===
        descLbl.Text = description
        descLbl.Font = New Font("Verdana", 9, FontStyle.Bold)
        descLbl.AutoSize = False
        descLbl.Size = New Size(350, 20)
        descLbl.Location = New Point(60, 10)

        ' === Date ===
        dateLbl.Text = txDate.ToString("MMM dd, yyyy")
        dateLbl.Font = New Font("Verdana", 8)
        dateLbl.ForeColor = Color.Gray
        dateLbl.AutoSize = True
        dateLbl.Location = New Point(60, 32)

        ' === Price ===
        priceLbl.Text = "₱" & amount.ToString("N0")
        priceLbl.Font = New Font("Verdana", 9, FontStyle.Bold)
        priceLbl.ForeColor = Color.Black
        priceLbl.AutoSize = True

        ' === Status Badge ===
        badge.Text = status
        badge.Font = New Font("Verdana", 8, FontStyle.Bold)
        badge.AutoSize = False
        badge.Size = New Size(65, 20)
        badge.TextAlign = ContentAlignment.MiddleCenter
        badge.ForeColor = Color.White

        ' Set color based on status
        If status.ToLower() = "paid" Then
            badge.BackColor = Color.Green
        Else
            badge.BackColor = Color.Red
        End If

        ' === Separator ===
        separator.Height = 1
        separator.Dock = DockStyle.Bottom
        separator.BackColor = Color.LightGray

        ' Add controls
        Me.Controls.Add(iconBox)
        Me.Controls.Add(descLbl)
        Me.Controls.Add(dateLbl)
        Me.Controls.Add(priceLbl)
        Me.Controls.Add(badge)
        Me.Controls.Add(separator)

        AddHandler Me.Resize, AddressOf TransactionItem_Resize
    End Sub

    Private Sub TransactionItem_Resize(sender As Object, e As EventArgs)
        ' Calculate available width
        Dim availableWidth As Integer = Me.ClientSize.Width - 20

        ' Position price and badge on the right side
        priceLbl.Location = New Point(availableWidth - priceLbl.Width, 10)
        badge.Location = New Point(availableWidth - badge.Width, 32)

        ' Ensure description doesn't overlap with price/status
        Dim maxDescWidth As Integer = priceLbl.Left - descLbl.Left - 10
        If maxDescWidth > 50 Then
            descLbl.Width = maxDescWidth
        End If
    End Sub
End Class
