Imports System.Data.Entity

Public Class DataGridTest
    Public Property EJContext As New EJData.CorporateEntities

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EJContext = EJData.DataHelpers.GetNewDbContext

        EJContext.Orders.Load
    End Sub

End Class
