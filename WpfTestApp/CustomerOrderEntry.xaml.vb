Imports System.Data.Entity

Class CustomerOrderEntry
    Private _db As EJData.CorporateEntities
    Private _initDone As Boolean

    Public Property Title As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub CustomerOrderEntry_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Not _initDone Then
            _db = EJData.DataHelpers.GetNewDbContext()

            _db.CustomerOrders.Load()

            CType(FindResource("CustomerOrderViewSource"), CollectionViewSource).Source = _db.CustomerOrders.Local

            _initDone = True
        End If
    End Sub

    Private Sub FirstCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        CType(FindResource("CustomerOrderViewSource"), CollectionViewSource).View.MoveCurrentToFirst()
    End Sub

    Private Sub PreviousCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        CType(FindResource("CustomerOrderViewSource"), CollectionViewSource).View.MoveCurrentToPrevious()
    End Sub

    Private Sub NextCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        CType(FindResource("CustomerOrderViewSource"), CollectionViewSource).View.MoveCurrentToNext()
    End Sub

    Private Sub lastCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        CType(FindResource("CustomerOrderViewSource"), CollectionViewSource).View.MoveCurrentToLast()
    End Sub
End Class
