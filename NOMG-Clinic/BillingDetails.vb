Imports MySql.Data.MySqlClient

Public Class BillingDetails
    Public Property BillingId As String = ""

    Private conn As MySqlConnection
    Private cmd As MySqlCommand

    Private patientName As String = ""
    Private billingDate As Date = Date.Now
    Private totalAmount As Decimal = 0
    Private billingItems As String = ""
    Private billingStatus As String = ""

    Private Sub BillingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
