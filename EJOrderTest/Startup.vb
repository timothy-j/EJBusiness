﻿Public Class Startup
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
        Dim rpt = New EJOrderView.OrderView
        rpt.Show()
    End Sub

    Private Sub GridTest_Click(sender As Object, e As EventArgs) Handles GridTest.Click
        Dim o = New GeneralTableTest
        o.Show()
    End Sub
End Class