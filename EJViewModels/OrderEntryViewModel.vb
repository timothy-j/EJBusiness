Imports System.Collections.ObjectModel
Imports System.Data.Entity
Imports System.Windows
Imports Xceed.Wpf.DataGrid

Public Class OrderEntryViewModel
    Inherits DependencyObject

    Private _db As EJData.CorporateEntities
    Private _OrdersSource As ObservableCollection(Of EJData.Order)
    Private WithEvents _Orders As DataGridCollectionView

    Public Property Orders As DataGridCollectionView
        Get
            Return _Orders
        End Get
        Set
            _Orders = Value
        End Set
    End Property

#Region "Command Properties"

    Public Property DeleteCommand As WpfHelpers.RelayCommand
    Public Property ViewOrderCommand As WpfHelpers.RelayCommand
    Public Property NextCommand As WpfHelpers.RelayCommand
    Public Property PreviousCommand As WpfHelpers.RelayCommand
    Public Property FirstCommand As WpfHelpers.RelayCommand
    Public Property LastCommand As WpfHelpers.RelayCommand
    Public Property NewCommand As WpfHelpers.RelayCommand

#End Region

    Public ReadOnly Property CurrentOrder As EJData.Order
        Get
            Return Orders.CurrentItem
        End Get
    End Property

    Property CurrentIndex As Integer
        Get
            Return Orders.CurrentPosition
        End Get
        Set
            ' TODO: validate position value
            Orders.MoveCurrentToPosition(Value)
        End Set
    End Property

    ReadOnly Property Count As Integer
        Get
            Return Orders.Count
        End Get
    End Property

    Public Sub New()
        _db = EJData.DataHelpers.GetNewDbContext
        _db.Orders.Include("OrderDetails").Load
        _OrdersSource = _db.Orders.Local
        Orders = New DataGridCollectionView(_OrdersSource)

#Region "Command handler attachment"

        DeleteCommand = New WpfHelpers.RelayCommand(AddressOf OnDelete, AddressOf CanDelete)
        ViewOrderCommand = New WpfHelpers.RelayCommand(AddressOf OnViewOrder)

        FirstCommand = New WpfHelpers.RelayCommand(AddressOf OnFirst)
        PreviousCommand = New WpfHelpers.RelayCommand(AddressOf OnPrevious, AddressOf CanPrevious)
        NextCommand = New WpfHelpers.RelayCommand(AddressOf OnNext, AddressOf CanNext)
        LastCommand = New WpfHelpers.RelayCommand(AddressOf OnLast)
        NewCommand = New WpfHelpers.RelayCommand(AddressOf OnNew)

#End Region

    End Sub

#Region "Command 'Can' functions"

    Private Function CanDelete() As Boolean
        If CurrentOrder Is Nothing Then Return False
        Return Not CurrentOrder.Sent
    End Function

    Private Function CanPrevious() As Boolean
        If Orders.CurrentPosition <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CanNext() As Boolean
        If Orders.CurrentPosition >= Orders.Count - 1 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "Command excecute subs"

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
        MsgBox("new")
    End Sub

#End Region

End Class
