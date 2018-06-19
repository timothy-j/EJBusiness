Imports System.Data.Entity
Imports System.Globalization
Imports System.Windows.Controls

Class QtyConverter
    Implements IMultiValueConverter

    'Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
    '    Return (From cod In CType(value, EJData.ObservableListSource(Of EJData.CustOrderItemDetail))
    '            Where cod.DetailID = parameter
    '            Select Qty = cod.Quantity).FirstOrDefault
    'End Function

    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        Return (From cod In CType(values(0), EJData.ObservableListSource(Of EJData.CustOrderItemDetail))
                Where cod.DetailID = parameter
                Select Qty = cod.Quantity).FirstOrDefault
        Throw New NotImplementedException()
    End Function

    'Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
    '    Dim coid As EJData.CustOrderItemDetail = (From cod In CType(value, EJData.ObservableListSource(Of EJData.CustOrderItemDetail))
    '                                              Where cod.DetailID = parameter).FirstOrDefault
    '    coid.Quantity = value
    '    Throw New NotImplementedException()
    'End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Dim coid As EJData.CustOrderItemDetail = (From cod In CType(value(0), EJData.ObservableListSource(Of EJData.CustOrderItemDetail))
                                                  Where cod.DetailID = parameter).FirstOrDefault
        coid.Quantity = value
        Return Nothing
        'Throw New NotImplementedException()
    End Function
End Class

Class StatusConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Return (From cod In CType(value, EJData.ObservableListSource(Of EJData.CustOrderItemDetail))
                Where cod.DetailID = parameter
                Select cod.Status).FirstOrDefault
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

Class MachineInfo
    Public Property Number As Short
    Public Property DetailID As Integer?
End Class

Class MachInfo
    Inherits DependencyObject

    'Public Shared ReadOnly NumberProperty As DependencyProperty = DependencyProperty.RegisterAttached(
    '        "Number", GetType(Short), GetType(MachInfo))

    'Public Shared ReadOnly DetailIDProperty As DependencyProperty = DependencyProperty.RegisterAttached(
    '        "DetailID", GetType(Integer?), GetType(MachInfo))

    Public Shared ReadOnly EntitiesProperty As DependencyProperty = DependencyProperty.RegisterAttached(
            "Entities", GetType(List(Of Object)), GetType(MachInfo))

    'Public Shared Function GetNumber(ByVal element As DependencyObject) As Short
    '    Return CType(element.GetValue(NumberProperty), Short)
    'End Function

    'Public Shared Sub SetNumber(ByVal element As DependencyObject, ByVal value As Short)
    '    element.SetValue(NumberProperty, value)
    'End Sub

    'Public Shared Function GetDetailID(ByVal element As DependencyObject) As Integer?
    '    Return CType(element.GetValue(DetailIDProperty), Integer?)
    'End Function

    'Public Shared Function GetEntity(ByVal element As DependencyObject) As List(Of Object)
    '    Return CType(element.GetValue(DetailIDProperty), List(Of Object))
    'End Function

    Public Shared Sub SetDetailID(ByVal element As DependencyObject, ByVal value As Integer?)
        element.SetValue(EntitiesProperty, value)
    End Sub

    Public Shared Sub SetEntity(ByVal element As DependencyObject, ByVal value As List(Of Object))
        element.SetValue(EntitiesProperty, value)
    End Sub
End Class

Class MainWindow
    Private _db As EJData.CorporateEntities
    Dim ItemViewSource As System.Windows.Data.CollectionViewSource
    Dim MachineType As String
    Dim m_machines As New List(Of MachineInfo)
    Private _filterList As New Stack(Of EJFilter)
    Private _filterOn As Boolean
    Private Delete_Me As Integer? = 0

    Structure EJFilter
        Public columnName As String
        Public condition As String
        Public prefix As String ' Such as Not
    End Structure



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ItemViewSource = CType(Me.FindResource("ItemViewSource"), System.Windows.Data.CollectionViewSource)

        ' Internationalization fix - from the WPF Binding Cheat Sheet (http//www.nbdtech.com/Free/WpfBinding.pdf)
        ' This defines default currency symbol (etc.)
        FrameworkElement.LanguageProperty.OverrideMetadata(
            GetType(FrameworkElement), New FrameworkPropertyMetadata(
            Markup.XmlLanguage.GetLanguage(Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)))

    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        _db = EJData.DataHelpers.GetNewDbContext

        If MachineType = "" Then MachineType = InputBox("Enter machine type (e.g. CW or RF, not W3 or R2)")

        Dim machines As IQueryable(Of EJData.Machine) = From m In _db.Machines
                                                        Where m.Supplied = False

        If MachineType = "" Or MachineType = "All" Then
            ' No further filtering needed
        Else
            ' Filter machines for machineType
            machines = From m In machines
                       Where m.Type = MachineType
        End If

        m_machines = (From m In machines
                      Order By m.Number Descending
                      Select New MachineInfo With {.Number = m.Number, .DetailID = m.OrderDetailID}).ToList

        ' Create machine columns for this machine type
        Dim colNo As Integer = 0
        For Each mc In m_machines

            Dim colS As DataGridTextColumn = ItemDataGrid.FindResource("MCStatusColumn")
            colS.Header = "S" & mc.Number
            Dim bind = New Binding
            ' Binds to the Entities attached property, as indexed by colNo
            bind.Path = New PropertyPath("(0)[(1)].Status", MachInfo.EntitiesProperty, colNo)

            Dim rs As New RelativeSource(RelativeSourceMode.FindAncestor, GetType(DataGridRow), 1)
            bind.RelativeSource = rs
            colS.Binding = bind
            ItemDataGrid.Columns.Insert(0, colS)


            Dim col As DataGridTextColumn = ItemDataGrid.FindResource("MCQtyColumn")
            col.Header = mc.Number
            Dim qtyBind As New Binding()
            ' Binds to the Entities attached property, as indexed by colNo
            qtyBind.Path = New PropertyPath("(0)[(1)].Quantity", MachInfo.EntitiesProperty, colNo)
            colNo += 1
            qtyBind.StringFormat = "G8"
            qtyBind.TargetNullValue = ""
            qtyBind.RelativeSource = rs
            col.Binding = qtyBind
            ItemDataGrid.Columns.Insert(0, col)
        Next


        ' Start basic item query
        Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("QuoteItemDetails").Include("Part")
                                                Where i.Status <> "D"
                                                Select i

        ' Filter by machine type
        If MachineType = "" Or MachineType = "All" Then
            ' No further filtering needed
        Else
            ' Filter Items for machineType
            Bom = From m In Bom
                  Where m.Type = MachineType
        End If

        ' Order list
        Bom = From m In Bom
              Order By m.Item1

        Bom.Load

        'Load data by setting the CollectionViewSource.Source property:
        'ItemViewSource.Source = [generic data source]
        ItemViewSource.Source = _db.Items.Local
    End Sub

    Private Sub DataGridCell_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs)
        Dim cell As DataGridCell = CType(sender, DataGridCell)
        If Not cell.Column.Header.ToString = "Item" Then Exit Sub
        Dim row As DataGridRow = DataGridRow.GetRowContainingElement(cell)
        Dim rowitem As EJData.Item = CType(row.Item, EJData.Item)
        EJHelpers.FollowDrawingLink(rowitem.Part.DrawingType, rowitem.Part.PartNo)
        e.Handled = True
    End Sub

    Private Sub ItemsGrid_RowEditEnding(sender As Object, e As DataGridRowEditEndingEventArgs) Handles ItemDataGrid.RowEditEnding
        If Validation.GetHasError(e.Row) Then
            e.Cancel = True 'Validation.GetHasError(e.Row)
            MsgBox(Validation.GetErrors(e.Row)(0).ToString)
        End If
        If _db.ChangeTracker.HasChanges Then
            Try
                _db.SaveChanges()
            Catch ex As Exception
                MsgBox(ex.Message)
                e.Cancel = True
            End Try
        End If
    End Sub

    Private Sub CollectionViewSource_Filter(sender As Object, e As FilterEventArgs)

    End Sub

    Private Sub DataGridCell_GotKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs)
        Dim tb As TextBox = ItemDataGrid.FindResource("ExpandedCellBox")
        Dim bind As New Binding("Text")
        'Dim bind As Binding = BindingOperations.GetBinding(tb, tb.TextProperty)
        bind.Source = CType(sender, DataGridCell).Content
        bind.Mode = BindingMode.TwoWay
        'bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        tb.SetBinding(tb.TextProperty, bind)
        tb.MinWidth = CType(sender, DataGridCell).ActualWidth
        Dim popup As Primitives.Popup = ItemDataGrid.FindResource("FullTextPopup")
        popup.PlacementTarget = sender
        popup.Width = CType(sender, DataGridCell).ActualWidth
        popup.IsOpen = True
        tb.Focus()
        'e.Handled = True
    End Sub

    'Private Sub DataGrid_Loaded(sender As Object, e As RoutedEventArgs)
    '    Dim dg As DataGrid = sender
    '    For Each col In ItemDataGrid.Columns
    '        Dim newcol As DataGridColumn = col
    '        ' HACK: make this add child levels automatically
    '        newcol.Header = newcol.Header.ToString + "child"
    '        dg.Columns.Add(newcol)
    '    Next
    'End Sub

    Private Sub DataGridRowHeader_Click(sender As Object, e As RoutedEventArgs)
        Dim row As DataGridRow = sender
        'GetRowLevelByRowHandle
    End Sub

    Private Sub ItemDataGrid_PreparingCellForEdit(sender As Object, e As DataGridPreparingCellForEditEventArgs) Handles ItemDataGrid.PreparingCellForEdit
        e.EditingElement.ContextMenu = FindResource("StandardContextMenu")
        ' TODO: merge context menus as appropriate for filtering the different column data types
    End Sub

    Private Sub ItemDataGrid_LoadingRow(sender As Object, e As DataGridRowEventArgs) Handles ItemDataGrid.LoadingRow

        ' Add a CustomerOrderItemDetail for each pair of machine columns
        Dim ml As New List(Of Object)
        For Each mach In m_machines
            Dim m = (From cod In CType(e.Row.Item, EJData.Item).CustOrderItemDetails
                     Where cod.DetailID = mach.DetailID).FirstOrDefault
            ml.Add(m)
        Next

        e.Row.SetValue(MachInfo.EntitiesProperty, ml)

    End Sub

    Private Sub StatusCell_PreviewMouseDoubleClick(sender As Object, e As MouseButtonEventArgs)
        If e.ChangedButton = MouseButton.Left Then
            If CType(sender, DataGridCell).IsEditing Then
                EJHelpers.OpenOrderView(CType(CType(sender, DataGridCell).Content, TextBox).Text)
            Else
                EJHelpers.OpenOrderView(CType(CType(sender, DataGridCell).Content, TextBlock).Text)
            End If
        End If
        e.Handled = True
    End Sub

    Private Sub ItemDataGrid_GotFocus(sender As Object, e As RoutedEventArgs)
        ' TODO: set focus on current cell content for edit on enter?
    End Sub
End Class
