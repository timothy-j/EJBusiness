Imports System.Data.Entity
Imports System.Globalization
Imports System.Windows.Controls
Imports System.Linq.Dynamic

Class MachineInfo
    Public Property Number As Short
    Public Property DetailID As Integer?
End Class

Class MachInfo
    Inherits DependencyObject

    Public Shared ReadOnly EntitiesProperty As DependencyProperty = DependencyProperty.RegisterAttached(
            "Entities", GetType(List(Of Object)), GetType(MachInfo))

    Public Shared Sub SetDetailID(ByVal element As DependencyObject, ByVal value As Integer?)
        element.SetValue(EntitiesProperty, value)
    End Sub

    Public Shared Sub SetEntity(ByVal element As DependencyObject, ByVal value As List(Of Object))
        element.SetValue(EntitiesProperty, value)
    End Sub
End Class

Class GeneralBomTable
    Private _db As EJData.CorporateEntities
    Dim ItemViewSource As System.Windows.Data.CollectionViewSource
    Dim m_machines As New List(Of MachineInfo)
    Private _filterList As New Stack(Of EJFilter)
    Private _filterOn As Boolean
    Private Delete_Me As Integer? = 0
    Private _MachineType As String
    Private _initDone As Boolean
    Private _Model As String

    Public Shared EqualsCommand As New RoutedUICommand("Equals", "Equals", GetType(MainWindow))
    Public Shared NotEqualCommand As New RoutedUICommand("Not Equal To", "NotEqual", GetType(MainWindow))
    Public Shared ContainsCommand As New RoutedUICommand("Contains", "Contains", GetType(MainWindow))
    Public Shared NotContainsCommand As New RoutedUICommand("Does Not Contain", "NotContains", GetType(MainWindow))
    Public Shared StartsWithCommand As New RoutedUICommand("Starts With", "StartsWith", GetType(MainWindow))
    Public Shared NotStartsWithCommand As New RoutedUICommand("Does Not Start With", "NotStartsWith", GetType(MainWindow))
    Public Shared EndsWithCommand As New RoutedUICommand("Ends With", "EndsWith", GetType(MainWindow))
    Public Shared NotEndsWithCommand As New RoutedUICommand("Does Not End With", "NotEndsWith", GetType(MainWindow))
    Public Shared LessThanCommand As New RoutedUICommand("Less Than", "LessThan", GetType(MainWindow))
    Public Shared GreaterThanCommand As New RoutedUICommand("Greater Than", "GreaterThan", GetType(MainWindow))
    Public Property Title As String

    Public Property Model As String
        Get
            Return _Model
        End Get
        Set
            _Model = Value
            'HACK: Machine Types/Models need to be obtined from or stored in the database rather than hard-coded
            Select Case Value
                Case "HX"
                    MachineType = "HX"
                Case "R2", "RF"
                    MachineType = "RF"
                Case "W3", "EW", "W2"
                    MachineType = "CW"
                Case "CF"
                    MachineType = "CF"
                Case "F3", "F2", "HSF"
                    MachineType = "AF"
                Case Else
                    MachineType = "All"
            End Select

            Title = Value + " Table"
        End Set
    End Property

    Private Property MachineType As String
        Get
            Return _MachineType
        End Get
        Set
            If Value = "" Then
                _MachineType = "All"
            Else
                _MachineType = Value.ToUpper
            End If
        End Set
    End Property


    Structure EJFilter
        Public columnName As String
        Public condition As String
        Public prefix As String ' Such as Not
    End Structure

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' HACK: TODO: move this as it should only be done once, but not in constructor!
        'Init()

    End Sub

    Private Sub Init()
        ItemViewSource = CType(Me.FindResource("ItemViewSource"), System.Windows.Data.CollectionViewSource)

        _db = EJData.DataHelpers.GetNewDbContext

        'NavigationContext.QueryString.TryGetValue

        ' HACK: TODO: move this as it should only be done once, but not in constructor!
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

        Requery()

        '' Start basic item query
        'Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("QuoteItemDetails").Include("Part")
        '                                        Where i.Status <> "D"
        '                                        Select i

        '' Filter by machine type
        'If MachineType = "" Or MachineType = "All" Then
        '    ' No further filtering needed
        'Else
        '    ' Filter Items for machineType
        '    Bom = From m In Bom
        '          Where m.Type = MachineType
        'End If

        '' Order list
        'Bom = From m In Bom
        '      Order By m.Item1

        'Bom.Load

        'Load data by setting the CollectionViewSource.Source property:
        'ItemViewSource.Source = [generic data source]
        ItemViewSource.Source = _db.Items.Local
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        If Not _initDone Then
            Init()
            _initDone = True
        End If

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

    ''' <summary>
    ''' Fills the datagrid with filtered data
    ''' </summary>
    Sub Requery()
        ' Start basic item query
        Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("CustOrderItemDetails").Include("Part")
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

        ' Add user filters from filter list if _filterOn is true
        If _filterOn Then
            For Each Filter As EJFilter In _filterList
                If Filter.columnName.StartsWith("MC") Then
                    ' Machine column filtering
                    Dim mcNumber As Integer
                    Dim propertyString As String
                    If Filter.columnName.StartsWith("MCS") Then
                        mcNumber = CInt(Filter.columnName.Replace("MCS", "").Replace("Column", ""))
                        propertyString = "Status"
                    Else
                        mcNumber = CInt(Filter.columnName.Replace("MC", "").Replace("Column", ""))
                        propertyString = "Quantity"
                    End If
                    Dim cods = From cod In _db.CustOrderItemDetails
                               Where cod.CustOrderDetail.Machine.FirstOrDefault.Number = mcNumber

                    Try
                        ' TODO: returns no rows when filtering for 'is blank' i.e. = null
                        cods = cods.Where(Filter.prefix & propertyString & Filter.condition)
                        Bom = From b In Bom, cod In cods
                              Where b.CustOrderItemDetails.Contains(cod)
                              Select b
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    'Dim whereString As String = Filter.prefix & DataGridView1.Columns.Item(Filter.columnName).DataPropertyName & Filter.condition
                    'Try
                    '    Bom = Bom.Where(whereString)
                    'Catch ex As Exception
                    '    MsgBox(ex.Message)
                    'End Try
                End If
            Next
        End If

        '' Order the final results
        '' HACK: TODO: get this to work for multiple levels. should be Parent != [top level item] (rather than Is Nothing)
        'Bom = From i In Bom
        '      Let topLevel = If(i.Parent Is Nothing, i.Item1, i.Parent.Item1 + "_")
        '      Order By topLevel, i.Item1
        '      Select i
        Bom = From i In Bom
              Order By i.Item1
              Select i

        Bom.Load
        'GeneralBindingSource.DataSource = Bom.ToList
    End Sub

    Private Sub AddFilter(Filter As EJFilter)
        ' Start new filter list if not currently filtered
        If _filterOn = False Then _filterList.Clear()
        _filterList.Push(Filter)
        _filterOn = True
        Requery()
    End Sub

    Private Sub ContextMenu_Opened(sender As Object, e As RoutedEventArgs)
        Dim target = CType(sender, ContextMenu).PlacementTarget
        If TypeOf target Is TextBox Then
            If CType(target, TextBox).SelectionLength = 0 Then
                Dim coll As New CompositeCollection
                Dim c As New CollectionContainer
                Dim c2 As New CollectionContainer
                c.Collection = CType(FindResource("StandardMenu"), ContextMenu).Items
                coll.Add(c)
                c2.Collection = CType(FindResource("SelectedStringFilterMenu"), ContextMenu).Items
                coll.Add(c2)
                'CType(sender, ContextMenu).Items.Clear()
                CType(sender, ContextMenu).ItemsSource = coll
            ElseIf CType(target, TextBox).SelectionStart = 0 Then
                Dim coll As New CompositeCollection
                Dim c As New CollectionContainer
                Dim c2 As New CollectionContainer
                c.Collection = CType(FindResource("StandardMenu"), ContextMenu).Items
                coll.Add(c)
                c2.Collection = CType(FindResource("StartStringFilterMenu"), ContextMenu).Items
                coll.Add(c2)
                'CType(sender, ContextMenu).Items.Clear()
                CType(sender, ContextMenu).ItemsSource = coll
            End If
        ElseIf TypeOf target Is DataGridCell Then

        End If

    End Sub
End Class
