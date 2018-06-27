﻿Imports System.Data.Entity
Imports System.Globalization
Imports System.Windows.Controls

Class MainWindow

    Public Shared PopOutRoutedCommand As New RoutedUICommand("Pop out", "PopOut", GetType(MainWindow))
    Public Shared OpenMachineRoutedCommand As New RoutedUICommand("Machine Table", "OpenMachine", GetType(MainWindow))
    Public Shared OpenOrdersRoutedCommand As New RoutedUICommand("Orders", "OpenOrders", GetType(MainWindow))
    Public Shared OpenCustomerOrdersRoutedCommand As New RoutedUICommand("Customer Orders", "OpenCustomerOrders", GetType(MainWindow))
    Public Shared OpenQuotesRoutedCommand As New RoutedUICommand("Quotes", "OpenQuotes", GetType(MainWindow))
    Public Shared NextRoutedCommand As New RoutedUICommand("Next", "Next", GetType(MainWindow))
    Public Shared PreviousRoutedCommand As New RoutedUICommand("Previous", "Previous", GetType(MainWindow))
    Public Shared LastRoutedCommand As New RoutedUICommand("Last", "Last", GetType(MainWindow))
    Public Shared FirstRoutedCommand As New RoutedUICommand("First", "First", GetType(MainWindow))

    ' Action commands
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

    End Sub

    Private Sub OpenMachineCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        Dim newTab As TabItem = FindResource("MachineTableTab")
        DocumentTabControl.Items.Add(newTab)
        DocumentTabControl.SelectedItem = newTab
    End Sub

    Private Sub CloseCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        If e.Source Is Nothing Then
            DocumentTabControl.Items.Remove(DocumentTabControl.SelectedItem)
        Else
            ' HACK: assumes source is tab control, but this depends on correct source specification elsewhere
            DocumentTabControl.Items.Remove(e.Source)
        End If
    End Sub

    Private Sub OpenOrdersCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        Dim newTab As TabItem = FindResource("OrderTab")
        DocumentTabControl.Items.Add(newTab)
        DocumentTabControl.SelectedItem = newTab
        If e.Parameter = "New" Then
            MsgBox("New order code not written yet")
            'WpfControls.NavigationBar.NewRoutedCommand.Execute(Nothing, newTab.Content)
        End If
    End Sub

    Private Sub OpenCustomerOrdersCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        Dim newTab As TabItem = FindResource("CustomerOrderTab")
        DocumentTabControl.Items.Add(newTab)
        DocumentTabControl.SelectedItem = newTab
        If e.Parameter = "New" Then
            MsgBox("New customer order code not written yet")
        End If
    End Sub

    Private Sub OpenQuotesCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        Throw New NotImplementedException("Code for quotes form has not been written yet")
        Dim newTab As TabItem = FindResource("QuoteTab")
        DocumentTabControl.Items.Add(newTab)
        DocumentTabControl.SelectedItem = newTab
        If e.Parameter = "New" Then
            MsgBox("New quote code not written yet")
        End If
    End Sub

    Private Sub CloseCommand_CanExecute(sender As Object, e As CanExecuteRoutedEventArgs)
        If DocumentTabControl.Items.IsEmpty Then
            e.CanExecute = False
        Else
            e.CanExecute = True
        End If
    End Sub

    Private Sub TabItem_MouseDown(sender As Object, e As MouseButtonEventArgs)
        ' TODO: record location so dragging and dropping can happen in MouseMove...
        ' ...or just start drag drop but only mark e.Handled = true if drag drop is successful:
        ' If DragDrop.DoDragDrop() = DragDropEffects.None Then
    End Sub

    Private Sub PopOutCommand_Executed(sender As Object, e As ExecutedRoutedEventArgs)
        Dim w As New Window
        w.Content = CType(DocumentTabControl.SelectedItem, TabItem).Content
        'w.Title = 
        DocumentTabControl.Items.Remove(DocumentTabControl.SelectedItem)
        w.Show()
    End Sub
End Class
