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
        descLbl.AutoSize = True
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

        ' === Badge ===
        badge.Text = status
        badge.Font = New Font("Verdana", 8, FontStyle.Bold)
        badge.AutoSize = True
        badge.Padding = New Padding(8, 2, 8, 2)
        badge.ForeColor = Color.Black
        badge.BackColor = Color.WhiteSmoke
        badge.TextAlign = ContentAlignment.MiddleCenter

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
        ' Right section container width offset
        Dim rightMargin As Integer = 10

        ' Stack price and badge aligned to right
        Dim totalRightWidth = Math.Max(priceLbl.PreferredWidth, badge.PreferredWidth)
        Dim xRight = Me.Width - totalRightWidth - rightMargin

        priceLbl.Location = New Point(xRight, 10)
        badge.Location = New Point(xRight, 30)
    End Sub
End Class
