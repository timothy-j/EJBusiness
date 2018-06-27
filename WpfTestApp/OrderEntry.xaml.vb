Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data.Entity

Class OrderEntry
    Private _db As EJData.CorporateEntities
    Private _initDone As Boolean
    'Private m_viewsource As CollectionViewSource
    'Friend WithEvents OrderDetailsCollection As ObservableCollection(Of EJData.OrderDetail)

    Public Property Title As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub CustomerOrderEntry_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Not _initDone Then
            _db = EJData.DataHelpers.GetNewDbContext()

            _db.Orders.Load()

            Dim viewsource As CollectionViewSource = FindResource("OrderViewSource")
            viewsource.Source = _db.Orders.Local
            AddHandler viewsource.View.CurrentChanging, AddressOf View_CurrentChanging
            AddHandler viewsource.View.CurrentChanged, AddressOf View_CurrentChanged
            AddHandler CType(CType(FindResource("OrderOrderDetailsViewSource"), CollectionViewSource).Source, ObservableCollection(Of EJData.OrderDetail)).CollectionChanged,
                AddressOf OrderCollection_CollectionChanged

            _initDone = True
        End If
    End Sub

    Private Sub FirstCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        CType(FindResource("OrderViewSource"), CollectionViewSource).View.MoveCurrentToFirst()
    End Sub

    Private Sub PreviousCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        CType(FindResource("OrderViewSource"), CollectionViewSource).View.MoveCurrentToPrevious()
    End Sub

    Private Sub NextCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        CType(FindResource("OrderViewSource"), CollectionViewSource).View.MoveCurrentToNext()
    End Sub

    Private Sub LastCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        CType(FindResource("OrderViewSource"), CollectionViewSource).View.MoveCurrentToLast()
    End Sub

    Private Sub NewCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        Dim view As CollectionView = CType(sender.FindResource("OrderViewSource"), CollectionViewSource).View
        If MsgBox("Create new order?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ' Create new order
            Dim o As New EJData.Order
            o.OrderNo = (From os In _db.Orders
                         Order By os.OrderNo Descending
                         Select os.OrderNo).First + 1
            o.Date = DateAndTime.Now
            _db.Orders.Add(o)
            view.MoveCurrentTo(o)
        End If
    End Sub

    Private Sub View_CurrentChanging(sender As Object, e As CurrentChangingEventArgs)
        If _db.ChangeTracker.HasChanges Then
            Dim ents = _db.ChangeTracker.Entries().Where(Function(x) x.State <> EntityState.Unchanged)
            Try
                _db.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                e.Cancel = True
            End Try
        End If

    End Sub

    Private Sub View_CurrentChanged(sender As Object, e As EventArgs)
        Dim view As CollectionView = sender

        ' If this is a new record
        If view.IsCurrentAfterLast Then
            If MsgBox("Create new order?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ' Create new order
                Dim o As New EJData.Order
                o.OrderNo = (From os In _db.Orders
                             Order By os.OrderNo Descending
                             Select os.OrderNo).First + 1
                o.Date = DateAndTime.Now
                _db.Orders.Add(o)
                view.MoveCurrentTo(o)
            Else
                view.MoveCurrentToLast()
            End If
        End If
    End Sub

    Private Sub OrderDetailsDataGrid_PreviewCanExecute(sender As Object, e As CanExecuteRoutedEventArgs)
        Dim grid As DataGrid = sender
        If e.Command Is DataGrid.DeleteCommand And Not grid.IsReadOnly Then
            ' HACK: Enity is not attached if row has errors or new row editing hasn't finished, so deletion will fail
            If Not CType(grid.ItemsSource, CollectionView).IsCurrentAfterLast Then
                _db.Entry(grid.SelectedItem).State = EntityState.Deleted
                ' Deleting the entity will update the grid, so no further action is necessary
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub OrderCollection_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add Then
            MsgBox("added")
        End If
    End Sub

    Private Sub ViewOrder_Click(sender As Object, e As RoutedEventArgs)
        EJHelpers.OpenOrderView(OrderNoTextBox.Text)
    End Sub
End Class
