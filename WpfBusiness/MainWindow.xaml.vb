Imports System.Collections.ObjectModel
Imports EJViews
Imports WpfTestApp
Imports Xceed.Wpf.AvalonDock.Layout

Class MainWindow
    Private _Documents As CollectionViewSource

    Public Property MyPanes As New ObservableCollection(Of Object)

    Public Shared OpenMachineRoutedCommand As New RoutedUICommand("Machine Table", "OpenMachine", GetType(MainWindow))
    Public Shared OpenOrdersRoutedCommand As New RoutedUICommand("Orders", "OpenOrders", GetType(MainWindow))
    Public Shared OpenCustomerOrdersRoutedCommand As New RoutedUICommand("Customer Orders", "OpenCustomerOrders", GetType(MainWindow))
    Public Shared OpenQuotesRoutedCommand As New RoutedUICommand("Quotes", "OpenQuotes", GetType(MainWindow))
    Public Shared NextRoutedCommand As New RoutedUICommand("Next", "Next", GetType(MainWindow))
    Public Shared PreviousRoutedCommand As New RoutedUICommand("Previous", "Previous", GetType(MainWindow))
    Public Shared LastRoutedCommand As New RoutedUICommand("Last", "Last", GetType(MainWindow))
    Public Shared FirstRoutedCommand As New RoutedUICommand("First", "First", GetType(MainWindow))

    ' Action commands
    Public Shared PopOutRoutedCommand As New RoutedUICommand("Pop out", "PopOut", GetType(MainWindow))
    Public Shared NewOrderRoutedCommand As New RoutedUICommand("New Order", "NewOrder", GetType(MainWindow))
    Public Shared NewCustomerOrderRoutedCommand As New RoutedUICommand("New Customer Order", "NewCustomerOrder", GetType(MainWindow))
    Public Shared NewQuoteRoutedCommand As New RoutedUICommand("New Quote", "NewQuote", GetType(MainWindow))


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Internationalization fix - from the WPF Binding Cheat Sheet (http//www.nbdtech.com/Free/WpfBinding.pdf)
        ' This defines default currency symbol (etc.)
        FrameworkElement.LanguageProperty.OverrideMetadata(
            GetType(FrameworkElement), New FrameworkPropertyMetadata(
            Markup.XmlLanguage.GetLanguage(Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)))


        _Documents = CType(Me.FindResource("Documents"), System.Windows.Data.CollectionViewSource)
        _Documents.Source = MyPanes

    End Sub

    Private Sub OpenMachineCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        ' TODO: Make document current if already open
        Dim Bom As New BomView
        Bom.MCModel = e.Parameter
        MyPanes.Add(Bom)
        DockMgr.ActiveContent = Bom
    End Sub

    Private Sub CloseCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        ' TODO: get current document and remove it from the collection
        MyPanes.Remove(DockMgr.ActiveContent)
    End Sub

    Private Sub OpenOrdersCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        ' TODO: Make document current if already open
        Dim ord As New OrderEntryView
        ord.Title = "Orders"
        If e.Parameter = "New" Then
            MsgBox("New order not yet implemented")
        End If
        MyPanes.Add(ord)
        DockMgr.ActiveContent = ord
    End Sub

    Private Sub OpenCustomerOrdersCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        ' TODO: Make document current if already open
        Dim ord As New CustomerOrderEntry
        ord.Title = "Customer Orders"
        If e.Parameter = "New" Then
            MsgBox("New customer order code not written yet")
        End If
        MyPanes.Add(ord)
        DockMgr.ActiveContent = ord
    End Sub

    Private Sub OpenQuotesCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
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

    Private Sub CloseCommand_CanExecute(sender As Object, e As CanExecuteRoutedEventArgs)
        If MyPanes.Count Then
            e.CanExecute = True
        Else
            e.CanExecute = False
        End If
    End Sub

    Private Sub PopOutCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        ' TODO: work out how to pop out the current document
        MsgBox("Not yet posible to pop out current document from here; right click on document tab instead")
    End Sub
End Class
