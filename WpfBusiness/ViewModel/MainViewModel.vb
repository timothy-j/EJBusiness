Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports EJViews
Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command

Namespace ViewModel

    ''' <summary>
    ''' This class contains properties that the main View can data bind to.
    ''' <para>
    ''' Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    ''' </para>
    ''' <para>
    ''' You can also use Blend to data bind with the tool's support.
    ''' </para>
    ''' <para>
    ''' See http://www.galasoft.ch/mvvm
    ''' </para>
    ''' </summary>
    Public Class MainViewModel
        Inherits ViewModelBase

        Private WithEvents _MyPanes As New ObservableCollection(Of Object)
        Private _ActiveDocument As Object

        Public Property ActiveDocument As Object
            Get
                Return _ActiveDocument
            End Get
            Set
                _ActiveDocument = Value
                RaisePropertyChanged("ActiveDocument")
            End Set
        End Property

        Public Property MyPanes As ObservableCollection(Of Object)
            Get
                Return _MyPanes
            End Get
            Set
                _MyPanes = Value
            End Set
        End Property

        Public Property Documents As New CollectionViewSource




        ''' <summary>
        ''' Initializes a new instance of the MainViewModel class.
        ''' </summary>
        Public Sub New()
            'if IsInDesignMode then
            '    ' Code runs in Blend --> create design time data.
            'else
            '    ' Code runs "for real"
            'end if


            '_Documents = CType(Me.FindResource("Documents"), System.Windows.Data.CollectionViewSource)
            AttachCommands()
            Documents.Source = MyPanes

        End Sub

#Region "Commands"

#Region "Command Properties"

        Public Property OpenMachineRoutedCommand As RelayCommand(Of String)
        Public Property OpenOrdersRoutedCommand As RelayCommand
        Public Property OpenCustomerOrdersRoutedCommand As RelayCommand
        Public Property OpenQuotesRoutedCommand As RelayCommand
        'Public Property NextRoutedCommand As RelayCommand
        'Public Property PreviousRoutedCommand As RelayCommand
        'Public Property LastRoutedCommand As RelayCommand
        Public Property CloseRoutedCommand As RelayCommand

        ' Action commands
        Public Property PopOutRoutedCommand As RelayCommand
        Public Property NewOrderRoutedCommand As RelayCommand
        Public Property NewCustomerOrderRoutedCommand As RelayCommand
        Public Property NewQuoteRoutedCommand As RelayCommand

#End Region

#Region "Command handler attachment"

        Private Sub AttachCommands()

            OpenMachineRoutedCommand = New RelayCommand(Of String)(AddressOf OnOpenMachine)
            OpenOrdersRoutedCommand = New RelayCommand(AddressOf OnOpenOrders)
            OpenCustomerOrdersRoutedCommand = New RelayCommand(AddressOf OnOpenCustomerOrders)
            OpenQuotesRoutedCommand = New RelayCommand(AddressOf OnOpenQuotes)
            NewOrderRoutedCommand = New RelayCommand(AddressOf OnNewOrder)
            NewCustomerOrderRoutedCommand = New RelayCommand(AddressOf OnNewCustomerOrder)
            NewQuoteRoutedCommand = New RelayCommand(AddressOf OnNewQuote)
            CloseRoutedCommand = New RelayCommand(AddressOf OnClose, AddressOf CloseCommand_CanExecute)

        End Sub

#End Region 'Command handler attachment

#Region "Command Can functions"

        Private Function CloseCommand_CanExecute() As Boolean
            If MyPanes.Count Then
                Return True
            Else
                Return False
            End If
        End Function

#End Region 'Command Can functions

#Region "Command Excecute subs"

        Private Sub OnOpenMachine(MachineType As String)
            ' Make document current if already open
            For Each pane In MyPanes
                If TypeOf pane Is BomView Then
                    If CType(pane, BomView).Title = MachineType.ToUpper & " Table" Or
                   CType(pane, BomView).Title = MachineType.ToString & " Table" Then
                        ActiveDocument = pane
                        Exit Sub
                    End If
                End If
            Next

            Mouse.OverrideCursor = Cursors.Wait
            Dim Bom As New BomView
            Bom.MCModel = MachineType
            MyPanes.Add(Bom)
            'DockMgr.ActiveContent = Bom
            'Documents.View.MoveCurrentTo(Bom)
            ActiveDocument = Bom
            Mouse.OverrideCursor = Nothing
        End Sub

        Private Sub OnClose()
            ' TODO: get current document and remove it from the collection
            'MyPanes.Remove(DockMgr.ActiveContent)
            MyPanes.Remove(ActiveDocument) 'Documents.View.CurrentItem)
        End Sub

        Private Sub OnNewOrder()
            OnOpenOrders(True)
        End Sub

        Private Sub OnOpenOrders(Optional NewOrder As Boolean = False)
            ' TODO: Make document current if already open? If so, remember to allow for new command
            Dim ord As New OrderEntryView
            ord.Title = "Orders"
            If NewOrder Then
                MsgBox("New order not yet implemented")
                'Messenger.Send()
            End If
            MyPanes.Add(ord)
            'DockMgr.ActiveContent = ord
            'Documents.View.MoveCurrentTo(ord)
            ActiveDocument = ord
        End Sub

        Private Sub OnNewCustomerOrder()
            OnOpenCustomerOrders(True)
        End Sub

        Private Sub OnOpenCustomerOrders(Optional NewOrder As Boolean = False)
            ' TODO: Make document current if already open
            Dim ord As New CustomerOrderEntryView
            ord.Title = "Customer Orders"
            If NewOrder Then
                MsgBox("New customer order code not written yet")
            End If
            MyPanes.Add(ord)
            'DockMgr.ActiveContent = ord
            'Documents.View.MoveCurrentTo(ord)
            ActiveDocument = ord
        End Sub

        Private Sub OnNewQuote()
            OnOpenQuotes(True)
        End Sub

        Private Sub OnOpenQuotes(Optional NewQuote As Boolean = False)
            ' TODO: Make document current if already open
            MsgBox("Code for quotes form has not been written yet")
            'Dim quote As New CustomerQuoteEntry
            'quote.Title = "Customer Orders"
            'If e.Parameter = "New" Then
            '    MsgBox("New quote code not written yet")
            'End If
            'MyPanes.Add(quote)
            'DockMgr.ActiveContent = quote
        End Sub

        Private Sub PopOutCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
            ' TODO: work out how to pop out the current document
            'DockMgr.ActiveContent.
            MsgBox("Not yet posible to pop out current document from here; right click on document tab instead")
        End Sub

        Private Sub _MyPanes_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs) Handles _MyPanes.CollectionChanged
            RaisePropertyChanged("MyPanes")
        End Sub

#End Region 'Command Excecute subs

#End Region 'Commands


    End Class

End Namespace