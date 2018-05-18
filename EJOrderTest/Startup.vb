Imports System.Text.RegularExpressions

Public Class Startup
    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        Dim o = New OrderForm
        o.Show()
    End Sub

    Private Sub btnQuotes_Click(sender As Object, e As EventArgs) Handles btnQuotes.Click
        Dim o = New QuoteForm
        o.Show()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim cnx = EJData.DataHelpers.GetNewDbContext
        Dim range = From qd In cnx.QuoteDetails
                    Where qd.ID = 10
                    Select qd
        cnx.QuoteDetails.RemoveRange(range)
        cnx.SaveChanges()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim rpt = New OrderView
        'rpt.Order = 2456
        rpt.Show()
    End Sub

    Private Sub GridTest_Click(sender As Object, e As EventArgs) Handles GridTest.Click
        Dim o = New DGTest
        o.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, RegexTextBox.TextChanged
        ResultTextBox.Text = Regex.Match(TextBox1.Text, RegexTextBox.Text).Value
    End Sub
End Class