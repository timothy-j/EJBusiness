Imports System.Data.Entity

Class CustomerOrderEntry
    Private _db As EJData.CorporateEntities

    Private Sub CustomerOrderEntry_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        _db = EJData.DataHelpers.GetNewDbContext()

        _db.CustomerOrders.Load()

        CType(FindResource("CustomerOrderViewSource"), CollectionViewSource).Source = _db.CustomerOrders.Local
    End Sub
End Class
