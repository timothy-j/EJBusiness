Imports System.Data.Entity
Imports System.Globalization

Class QtyConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Return (From cod In CType(value, EJData.ObservableListSource(Of EJData.CustOrderItemDetail))
                Where cod.DetailID = parameter
                Select Qty = cod.Quantity).FirstOrDefault
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Dim coid As EJData.CustOrderItemDetail = (From cod In CType(value, EJData.ObservableListSource(Of EJData.CustOrderItemDetail))
                                                  Where cod.DetailID = parameter).FirstOrDefault
        coid.Quantity = value
        Throw New NotImplementedException()
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

Class MachInfo
    Inherits DependencyObject

    Public Shared ReadOnly NumberProperty As DependencyProperty = DependencyProperty.RegisterAttached(
            "Number", GetType(Short), GetType(MachInfo))

    Public Shared ReadOnly DetailIDProperty As DependencyProperty = DependencyProperty.RegisterAttached(
            "DetailID", GetType(Integer?), GetType(MachInfo))

    Public Shared Function GetNumber(ByVal element As DependencyObject) As Short
        Return CType(element.GetValue(NumberProperty), Short)
    End Function

    Public Shared Sub SetNumber(ByVal element As DependencyObject, ByVal value As Short)
        element.SetValue(NumberProperty, value)
    End Sub

    Public Shared Function GetDetailID(ByVal element As DependencyObject) As Integer?
        Return CType(element.GetValue(DetailIDProperty), Integer?)
    End Function

    Public Shared Sub SetDetailID(ByVal element As DependencyObject, ByVal value As Integer?)
        element.SetValue(DetailIDProperty, value)
    End Sub
End Class

Class MainWindow
    Private _db As EJData.CorporateEntities
    Dim ItemViewSource As System.Windows.Data.CollectionViewSource
    Dim MachineType As String
    'Dim m_machines As List(Of MachInfo)
    Private _filterList As New Stack(Of EJFilter)
    Private _filterOn As Boolean

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

        Dim MachineList = (From m In machines
                           Order By m.Number Descending
                           Select m.Number, m.OrderDetailID).ToList

        For Each mc In MachineList

            Dim colS As DataGridTextColumn = ItemDataGrid.FindResource("MCStatusColumn")
            colS.Header = "S" & mc.Number
            Dim bind = New Binding("CustOrderItemDetails")
            bind.Converter = New StatusConverter
            bind.ConverterParameter = mc.OrderDetailID
            'bind.Mode = BindingMode.OneWay
            colS.Binding = bind
            ItemDataGrid.Columns.Insert(0, colS)


            Dim col As DataGridTextColumn = ItemDataGrid.FindResource("MCQtyColumn")
            col.Header = mc.Number
            'Dim format As String = col.Binding.StringFormat
            Dim qtyBind As New Binding("CustOrderItemDetails")
            qtyBind.Converter = New QtyConverter
            qtyBind.StringFormat = "G8"
            qtyBind.TargetNullValue = ""
            qtyBind.ConverterParameter = mc.OrderDetailID
            'qtyBind.Mode = BindingMode.OneWay
            col.Binding = qtyBind
            CType(col.Binding, Binding).ConverterParameter = mc.OrderDetailID
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
        'ItemDataGrid.CommitEdit(DataGridEditingUnit.Cell, False)
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

End Class
