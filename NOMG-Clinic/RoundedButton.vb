Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RoundedButton
    Inherits Button

    Private _radius As Integer = 20
    Private _hoverColor As Color = Color.LightBlue
    Private _defaultBackColor As Color
    Private _isHovering As Boolean = False

    Public Property CornerRadius As Integer
        Get
            Return _radius
        End Get
        Set(value As Integer)
            _radius = value
            Me.Invalidate()
        End Set
    End Property

    Public Property HoverColor As Color
        Get
            Return _hoverColor
        End Get
        Set(value As Color)
            _hoverColor = value
        End Set
    End Property

    Public Sub New()
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0
        Me._defaultBackColor = Me.BackColor
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.ResizeRedraw Or
                    ControlStyles.UserPaint Or
                    ControlStyles.DoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim path As New GraphicsPath()
        path.AddArc(rect.X, rect.Y, _radius, _radius, 180, 90)
        path.AddArc(rect.Right - _radius, rect.Y, _radius, _radius, 270, 90)
        path.AddArc(rect.Right - _radius, rect.Bottom - _radius, _radius, _radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - _radius, _radius, _radius, 90, 90)
        path.CloseAllFigures()

        Me.Region = New Region(path)

        Using brush As New SolidBrush(Me.BackColor)
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            pevent.Graphics.FillPath(brush, path)
        End Using

        TextRenderer.DrawText(pevent.Graphics, Me.Text, Me.Font, rect, Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        If Not _isHovering Then
            _defaultBackColor = Me.BackColor
            Me.BackColor = _hoverColor
            _isHovering = True
            Me.Invalidate() ' Only redraw self
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        If _isHovering Then
            Me.BackColor = _defaultBackColor
            _isHovering = False
            Me.Invalidate() ' Only redraw self
        End If
    End Sub
End Class
