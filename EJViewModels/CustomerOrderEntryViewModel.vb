Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data.Entity
Imports System.Windows
Imports Xceed.Wpf.DataGrid
Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command

Public Class CustomerOrderEntryViewModel
    Inherits ViewModelBase 'WpfHelpers.ViewModelBase

#Region "Fields"

    Private _db As EJData.CorporateEntities
    Private _OrdersSource As ObservableCollection(Of EJData.CustomerOrder)
    Private WithEvents _Orders As DataGridCollectionView
    Private WithEvents _OrderDetails As DataGridCollectionView

#End Region 'Fields

#Region "Properties"

    Public Property Orders As DataGridCollectionView
        Get
            Return _Orders
        End Get
        Set
            _Orders = Value
            RaisePropertyChanged("Orders")
        End Set
    End Property

    Public Property OrderDetails As DataGridCollectionView
        Get
            Return _OrderDetails
        End Get
        Set
            _OrderDetails = Value
            RaisePropertyChanged("OrderDetails")
        End Set
    End Property

    Public ReadOnly Property CurrentOrder As EJData.CustomerOrder
        Get
            Return Orders.CurrentItem
        End Get
    End Property

    Property CurrentIndex As Integer
        Get
            Return Orders.CurrentPosition 'GetValue(CurrentIndexProperty)
        End Get
        Set
            ' TODO: validate position value
            Orders.MoveCurrentToPosition(Value)
            RaisePropertyChanged("Orders")
        End Set
    End Property

    Public ReadOnly Property CurrentOrderDetail As EJData.CustOrderDetail
        Get
            Return OrderDetails.CurrentItem
        End Get
    End Property

    Property CurrentDetailIndex As Integer
        Get
            Return OrderDetails.CurrentPosition 'GetValue(CurrentIndexProperty)
        End Get
        Set
            ' TODO: validate position value
            OrderDetails.MoveCurrentToPosition(Value)
            RaisePropertyChanged("OrderDetails")
        End Set
    End Property

    ReadOnly Property Count As Integer
        Get
            Return Orders.Count
        End Get
    End Property

#End Region 'Properties

#Region "Initialisation"

    Public Sub New()
        _db = EJData.DataHelpers.GetNewDbContext
        'Dim t As Thread = New Thread(Sub()
        '                                 _db.Orders.Include("OrderDetails").Load
        '                                 _OrdersSource = _db.Orders.Local
        '                                 Orders = New DataGridCollectionView(_OrdersSource)
        '                             End Sub)
        't.Start()
        _db.CustomerOrders.Load
        _OrdersSource = _db.CustomerOrders.Local
        Orders = New DataGridCollectionView(_OrdersSource)
        Orders.SortDescriptions.Add(New SortDescription("ID", ListSortDirection.Ascending))
        'OrderDetails = New DataGridCollectionView(CurrentOrderDetail.CustOrderItemDetails)

        AttachCommands()
    End Sub

#End Region 'Initialisation

#Region "Commands"

#Region "Command Properties"

    Public Property DeleteCommand As RelayCommand 'WpfHelpers.RelayCommand
    'Public Property ViewOrderCommand As RelayCommand
    Public Property NextCommand As RelayCommand
    Public Property PreviousCommand As RelayCommand
    Public Property FirstCommand As RelayCommand
    Public Property LastCommand As RelayCommand
    Public Property NewCommand As RelayCommand

#End Region 'Command Properties

#Region "Command handler attachment"

    Private Sub AttachCommands()

        DeleteCommand = New RelayCommand(AddressOf OnDelete, AddressOf CanDelete)
        'ViewOrderCommand = New RelayCommand(AddressOf OnViewOrder)

        FirstCommand = New RelayCommand(AddressOf OnFirst)
        PreviousCommand = New RelayCommand(AddressOf OnPrevious, AddressOf CanPrevious)
        NextCommand = New RelayCommand(AddressOf OnNext, AddressOf CanNext)
        LastCommand = New RelayCommand(AddressOf OnLast)
        NewCommand = New RelayCommand(AddressOf OnNew)

    End Sub

#End Region 'Command handler attachment

#Region "Command Can functions"

    Private Function CanDelete() As Boolean
        'Return Not CurrentOrder.Sent
        Return False
    End Function

    Private Function CanPrevious() As Boolean
        If Orders.CurrentPosition <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CanNext() As Boolean
        If Orders.CurrentPosition >= Orders.Count Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region 'Command Can functions

#Region "Command Excecute subs"

    Private Sub OnDelete()
        Orders.Remove(CurrentOrder)
    End Sub

    Private Sub OnViewOrder()
        MsgBox("view order")
    End Sub

    Private Sub OnFirst()
        Orders.MoveCurrentToFirst()
    End Sub

    Private Sub OnPrevious()
        Orders.MoveCurrentToPrevious()
    End Sub

    Private Sub OnNext()
        Orders.MoveCurrentToNext()
    End Sub

    Private Sub OnLast()
        Orders.MoveCurrentToLast()
    End Sub

    Private Sub OnNew()
        If MsgBox("Create new order?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ' Create new order
            Dim o As New EJData.Order
            o.OrderNo = (From os In _db.Orders
                         Order By os.OrderNo Descending
                         Select os.OrderNo).First + 1
            o.Date = DateAndTime.Now
            _db.Orders.Add(o)
            _Orders.MoveCurrentTo(o)
        End If
    End Sub

#End Region 'Command Excecute subs

#End Region 'Commands

#Region "Events"

    Private Sub _Orders_CurrentChanging(sender As Object, e As CurrentChangingEventArgs) Handles _Orders.CurrentChanging
        If _db.ChangeTracker.HasChanges Then
            'Dim ents = _db.ChangeTracker.Entries().Where(Function(x) x.State <> EntityState.Unchanged)
            Try
                _db.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                e.Cancel = True
            End Try
        End If
    End Sub

    Private Sub _Orders_CurrentChanged(sender As Object, e As EventArgs) Handles _Orders.CurrentChanged
        If _Orders.IsCurrentAfterLast Then
            If MsgBox("Create new order?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ' Create new order
                Dim o As New EJData.CustomerOrder
                'o.OrderNo = (From os In _db.Orders
                '             Order By os.OrderNo Descending
                '             Select os.OrderNo).First + 1
                o.Date = DateAndTime.Now
                _db.CustomerOrders.Add(o)
                _Orders.MoveCurrentTo(o)
            Else
                _Orders.MoveCurrentToLast()
            End If
        End If
        RaisePropertyChanged("CurrentIndex")
        RaisePropertyChanged("CurrentOrder")
        PreviousCommand.RaiseCanExecuteChanged()
        NextCommand.RaiseCanExecuteChanged()
        DeleteCommand.RaiseCanExecuteChanged()
        'CurrentIndex = _Orders.CurrentPosition
    End Sub

    Private Sub _Orders_ItemRemoved(sender As Object, e As DataGridItemRemovedEventArgs) Handles _Orders.ItemRemoved
        RaisePropertyChanged("Count")
    End Sub

    Private Sub _Orders_NewItemCreated(sender As Object, e As DataGridItemEventArgs) Handles _Orders.NewItemCreated
        RaisePropertyChanged("Count")
    End Sub

#End Region 'Events

End Class
