Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data.Entity
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports EJBusiness.Common

Namespace ViewModels

    Public Class BomViewModel
        Inherits ViewModelBase
        Implements IDocumentModule, ISupportState(Of BomViewModel.Info)

#Region "Fields"

        Private _db As EJData.CorporateEntities
        Private WithEvents _BomSource As ObservableCollection(Of EJData.Item)
        Private _MachineType As String
        Private _initDone As Boolean
        Private _Model As String
        Friend WithEvents _ItemView As ListCollectionView
        'Private _BomSource As ObservableCollection(Of EJData.Item)
        Property MachineList As New List(Of MachineInfo)
        Property Title As String

        Public Overridable Property Caption() As String Implements IDocumentModule.Caption
        Public Overridable Property IsActive() As Boolean Implements IDocumentModule.IsActive

#End Region 'Fields

#Region "Classes/Structures"

        Public Class MachineInfo
            Public Property Number As Short
            Public Property DetailID As Integer?
        End Class

        Structure EJFilter
            Public columnName As String
            Public condition As String
            Public prefix As String ' Such as Not
        End Structure

#End Region 'Classes/Structures

#Region "Properties"

        Public Property ItemView As ListCollectionView
            Get
                Return _ItemView
            End Get
            Set
                _ItemView = Value
            End Set
        End Property

        Public Property BomSource As ObservableCollection(Of EJData.Item)
            Get
                Return _BomSource
            End Get
            Set
                _BomSource = Value
            End Set
        End Property

        Public ReadOnly Property CurrentItem As EJData.Item
            Get
                Return CType(ItemView.CurrentItem, EJData.Item)
            End Get
        End Property

        Property CurrentIndex As Integer
            Get
                Return ItemView.CurrentPosition
            End Get
            Set
                ' TODO: validate position value
                ItemView.MoveCurrentToPosition(Value)
            End Set
        End Property

        ReadOnly Property Count As Integer
            Get
                Return ItemView.Count
            End Get
        End Property

        Public Property RootID As Integer

        Public Property Model As String
            Get
                Return _Model
            End Get
            Set
                _Model = Value
                'HACK: Machine Types/Models need to be obtained from or stored in the database rather than hard-coded
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

                'If (ViewModelBase.IsInDesignModeStatic) Then Exit Property

                If Not _initDone Then
                    Init()
                    _initDone = True
                End If
                Title = Value + " Table"
                Caption = Value + " Table"
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

#End Region 'Properties

#Region "Initialisation"

        Public Sub New()
            _db = EJData.DataHelpers.GetNewDbContext

            _BomSource = _db.Items.Local
            'Dim cvs As New CollectionViewSource
            'cvs.Source = _BomSource
            ItemView = New ListCollectionView(_BomSource)
            'ItemView = cvs.View

            AttachCommands()

        End Sub

        Public Shared Function Create(ByVal caption As String, ByVal Model As String) As BomViewModel
            Return ViewModelSource.Create(Function() New BomViewModel() With {.Caption = caption, .Model = Model})
        End Function

        Private Sub Init()
            'ItemViewSource = CType(Me.FindResource("ItemViewSource"), System.Windows.Data.CollectionViewSource)


            'NavigationContext.QueryString.TryGetValue

            ' HACK: TODO: move this as it should only be done once, but not in constructor!
            If MachineType = "" Then MachineType = InputBox("Enter machine type (e.g. CW or RF, not W3 or R2)")

            Dim machines As IQueryable(Of EJData.Machine) = From m In _db.Machines
                                                            Where m.Supplied = False

            If MachineType = "" Or MachineType = "ALL" Then
                ' No further filtering needed
            Else
                ' Filter machines for machineType
                machines = From m In machines
                           Where m.Type = MachineType
            End If

            MachineList = (From m In machines
                           Order By m.Number Descending
                           Select New MachineInfo With {.Number = m.Number, .DetailID = m.OrderDetailID}).ToList

            ' Must happen after machine column data is established so data can be attached
            '_db.Items.Include("Part").Include("CustOrderItemDetails").Load
            'Start basic item query
            Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("QuoteItemDetails").Include("Part")
                                                    Where i.Status <> "D"
                                                    Select i
            'Filter by machine type
            If MachineType = "" Or MachineType = "ALL" Then
                ' No further filtering needed
            Else
                ' Filter Items for machineType
                Bom = From m In Bom
                      Where m.Type = MachineType
            End If

            Bom = From m In Bom
                  Order By m.Item1

            Bom.Load

            '' NOTE: uncommenting the following adds this query to the previous list
            'Dim test = From i In _db.Items.Include("QuoteItemDetails").Include("Part")
            '           Where i.Status <> "D" And i.Type = "CF"
            '           Select i

            'test.Load

            AttachMachineLists()


            '    ' Create machine columns for this machine type
            '    Dim colNo As Integer = 0
            '    For Each mc In m_machines

            '        Dim colS As Column = ItemDataGrid.FindResource("MCStatusColumn")
            '        colS.Header = "S" & mc.Number
            '        Dim bind = New Binding
            '        ' Binds to the Entities attached property, as indexed by colNo
            '        bind.Path = New PropertyPath("(0)[(1)].Status", MachInfo.EntitiesProperty, colNo)

            '        Dim rs As New RelativeSource(RelativeSourceMode.FindAncestor, GetType(DataGridRow), 1)
            '        bind.RelativeSource = rs
            '        colS.Binding = bind
            '        ItemDataGrid.Columns.Insert(0, colS)


            '        Dim col As Column = ItemDataGrid.FindResource("MCQtyColumn")
            '        col.Header = mc.Number
            '        Dim qtyBind As New Binding()
            '        ' Binds to the Entities attached property, as indexed by colNo
            '        qtyBind.Path = New PropertyPath("(0)[(1)].Quantity", MachInfo.EntitiesProperty, colNo)
            '        colNo += 1
            '        qtyBind.StringFormat = "G8"
            '        qtyBind.TargetNullValue = ""
            '        qtyBind.RelativeSource = rs
            '        col.Binding = qtyBind
            '        ItemDataGrid.Columns.Insert(0, col)
            '    Next

            '    Requery()

            '    '' Start basic item query
            '    'Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("QuoteItemDetails").Include("Part")
            '    '                                        Where i.Status <> "D"
            '    '                                        Select i

            '    '' Filter by machine type
            '    'If MachineType = "" Or MachineType = "All" Then
            '    '    ' No further filtering needed
            '    'Else
            '    '    ' Filter Items for machineType
            '    '    Bom = From m In Bom
            '    '          Where m.Type = MachineType
            '    'End If

            '    '' Order list
            '    'Bom = From m In Bom
            '    '      Order By m.Item1

            '    'Bom.Load

            '    'Load data by setting the CollectionViewSource.Source property:
            '    'ItemViewSource.Source = [generic data source]
            '    ItemViewSource.Source = _db.Items.Local
        End Sub

        Private Sub AttachMachineLists()
            'MsgBox("bomsource collection changed")
            For Each item As EJData.Item In _BomSource
                ' Add a CustomerOrderItemDetail for each pair of machine columns
                Dim ml As New List(Of Object)
                For Each mach In MachineList
                    Dim m = (From cod In CType(item, EJData.Item).CustOrderItemDetails
                             Where cod.DetailID = mach.DetailID).FirstOrDefault
                    ml.Add(m)
                Next

                'MachInfo.SetEntity(item, ml)
                'item.SetValue(MachInfo.EntitiesProperty, ml)

            Next
        End Sub

#End Region 'Initialisation

#Region "Commands"

#Region "Command Properties"

        Public Property DeleteCommand As DelegateCommand
        Public Property ViewOrderCommand As DelegateCommand
        Public Property EqualsCommand As DelegateCommand
        Public Property NotEqualCommand As DelegateCommand
        Public Property ContainsCommand As DelegateCommand
        Public Property NotContainsCommand As DelegateCommand
        Public Property StartsWithCommand As DelegateCommand
        Public Property NotStartsWithCommand As DelegateCommand
        Public Property EndsWithCommand As DelegateCommand
        Public Property NotEndsWithCommand As DelegateCommand
        Public Property LessThanCommand As DelegateCommand
        Public Property GreaterThanCommand As DelegateCommand

#End Region

#Region "Command handler attachment"

        Private Sub AttachCommands()

            ViewOrderCommand = New DelegateCommand(AddressOf OnViewOrder)

        End Sub

#End Region 'Command handler attachment

#Region "Command Can functions"

        'Private Function CanDelete() As Boolean
        '    If CurrentOrder Is Nothing Then Return False
        '    Return Not CurrentOrder.Sent
        'End Function

        Private Function CanPrevious() As Boolean
            If ItemView.CurrentPosition <= 0 Then
                Return False
            Else
                Return True
            End If
        End Function

        Private Function CanNext() As Boolean
            If ItemView.CurrentPosition >= ItemView.Count - 1 Then
                Return False
            Else
                Return True
            End If
        End Function

#End Region

#Region "Command Excecute subs"

        'Private Sub OnDelete()
        '    ItemView.Remove(CurrentOrder)
        'End Sub

        Private Sub OnViewOrder()
            MsgBox("view order")
        End Sub

        Private Sub OnFirst()
            ItemView.MoveCurrentToFirst()
        End Sub

        Private Sub OnPrevious()
            ItemView.MoveCurrentToPrevious()
        End Sub

        Private Sub OnNext()
            ItemView.MoveCurrentToNext()
        End Sub

        Private Sub OnLast()
            ItemView.MoveCurrentToLast()
        End Sub

        Private Sub OnNew()
            MsgBox("new")
        End Sub

#End Region

#End Region 'Commands

#Region "Events"

        Private Sub _ItemView_CurrentChanging(sender As Object, e As CurrentChangingEventArgs) Handles _ItemView.CurrentChanging
            If _db.ChangeTracker.HasChanges Then
                Try
                    _db.SaveChanges()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    e.Cancel = True
                End Try

            End If
        End Sub


        'Private Sub DataGridCell_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs)
        '    Dim cell As DataGridCell = CType(sender, DataGridCell)
        '    If Not cell.Column.Header.ToString = "Item" Then Exit Sub
        '    Dim row As DataGridRow = DataGridRow.GetRowContainingElement(cell)
        '    Dim rowitem As EJData.Item = CType(row.Item, EJData.Item)
        '    EJHelpers.FollowDrawingLink(rowitem.Part.DrawingType, rowitem.Part.PartNo)
        '    e.Handled = True
        'End Sub

        'Private Sub ItemsGrid_RowEditEnding(sender As Object, e As DataGridRowEditEndingEventArgs) Handles ItemDataGrid.RowEditEnding
        '    If Validation.GetHasError(e.Row) Then
        '        e.Cancel = True 'Validation.GetHasError(e.Row)
        '        MsgBox(Validation.GetErrors(e.Row)(0).ToString)
        '    End If
        '    If _db.ChangeTracker.HasChanges Then
        '        Try
        '            _db.SaveChanges()
        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '            e.Cancel = True
        '        End Try
        '    End If
        'End Sub


        'Private Sub DataGridCell_GotKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs)
        '    Dim tb As TextBox = ItemDataGrid.FindResource("ExpandedCellBox")
        '    Dim bind As New Binding("Text")
        '    'Dim bind As Binding = BindingOperations.GetBinding(tb, tb.TextProperty)
        '    bind.Source = CType(sender, DataGridCell).Content
        '    bind.Mode = BindingMode.TwoWay
        '    'bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        '    tb.SetBinding(tb.TextProperty, bind)
        '    tb.MinWidth = CType(sender, DataGridCell).ActualWidth
        '    Dim popup As Primitives.Popup = ItemDataGrid.FindResource("FullTextPopup")
        '    popup.PlacementTarget = sender
        '    popup.Width = CType(sender, DataGridCell).ActualWidth
        '    popup.IsOpen = True
        '    tb.Focus()
        '    'e.Handled = True
        'End Sub

        'Private Sub DataGrid_Loaded(sender As Object, e As RoutedEventArgs)
        '    Dim dg As DataGrid = sender
        '    For Each col In ItemDataGrid.Columns
        '        Dim newcol As DataGridColumn = col
        '        ' HACK: make this add child levels automatically
        '        newcol.Header = newcol.Header.ToString + "child"
        '        dg.Columns.Add(newcol)
        '    Next
        'End Sub

        'Private Sub DataGridRowHeader_Click(sender As Object, e As RoutedEventArgs)
        '    Dim row As DataGridRow = sender
        '    'GetRowLevelByRowHandle
        'End Sub

        'Private Sub ItemDataGrid_PreparingCellForEdit(sender As Object, e As DataGridPreparingCellForEditEventArgs) Handles ItemDataGrid.PreparingCellForEdit
        '    e.EditingElement.ContextMenu = FindResource("StandardContextMenu")
        '    ' TODO: merge context menus as appropriate for filtering the different column data types
        'End Sub

        'Private Sub ItemDataGrid_LoadingRow(sender As Object, e As DataGridRowEventArgs) Handles ItemDataGrid.LoadingRow

        '    ' Add a CustomerOrderItemDetail for each pair of machine columns
        '    Dim ml As New List(Of Object)
        '    For Each mach In m_machines
        '        Dim m = (From cod In CType(e.Row.Item, EJData.Item).CustOrderItemDetails
        '                 Where cod.DetailID = mach.DetailID).FirstOrDefault
        '        ml.Add(m)
        '    Next

        '    e.Row.SetValue(MachInfo.EntitiesProperty, ml)

        'End Sub

        'Private Sub StatusCell_PreviewMouseDoubleClick(sender As Object, e As MouseButtonEventArgs)
        '    If e.ChangedButton = MouseButton.Left Then
        '        If CType(sender, DataGridCell).IsEditing Then
        '            EJHelpers.OpenOrderView(CType(CType(sender, DataGridCell).Content, TextBox).Text)
        '        Else
        '            EJHelpers.OpenOrderView(CType(CType(sender, DataGridCell).Content, TextBlock).Text)
        '        End If
        '    End If
        '    e.Handled = True
        'End Sub

        'Private Sub ItemDataGrid_GotFocus(sender As Object, e As RoutedEventArgs)
        '    ' TODO: set focus on current cell content for edit on enter?
        'End Sub

        '''' <summary>
        '''' Fills the datagrid with filtered data
        '''' </summary>
        'Sub Requery()
        '    ' Start basic item query
        '    Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("CustOrderItemDetails").Include("Part")
        '                                            Where i.Status <> "D"
        '                                            Select i

        '    ' Filter by machine type
        '    If MachineType = "" Or MachineType = "All" Then
        '        ' No further filtering needed
        '    Else
        '        ' Filter Items for machineType
        '        Bom = From m In Bom
        '              Where m.Type = MachineType
        '    End If

        '    ' Add user filters from filter list if _filterOn is true
        '    If _filterOn Then
        '        For Each Filter As EJFilter In _filterList
        '            If Filter.columnName.StartsWith("MC") Then
        '                ' Machine column filtering
        '                Dim mcNumber As Integer
        '                Dim propertyString As String
        '                If Filter.columnName.StartsWith("MCS") Then
        '                    mcNumber = CInt(Filter.columnName.Replace("MCS", "").Replace("Column", ""))
        '                    propertyString = "Status"
        '                Else
        '                    mcNumber = CInt(Filter.columnName.Replace("MC", "").Replace("Column", ""))
        '                    propertyString = "Quantity"
        '                End If
        '                Dim cods = From cod In _db.CustOrderItemDetails
        '                           Where cod.CustOrderDetail.Machine.FirstOrDefault.Number = mcNumber

        '                Try
        '                    ' TODO: returns no rows when filtering for 'is blank' i.e. = null
        '                    cods = cods.Where(Filter.prefix & propertyString & Filter.condition)
        '                    Bom = From b In Bom, cod In cods
        '                          Where b.CustOrderItemDetails.Contains(cod)
        '                          Select b
        '                Catch ex As Exception
        '                    MsgBox(ex.Message)
        '                End Try
        '            Else
        '                'Dim whereString As String = Filter.prefix & DataGridView1.Columns.Item(Filter.columnName).DataPropertyName & Filter.condition
        '                'Try
        '                '    Bom = Bom.Where(whereString)
        '                'Catch ex As Exception
        '                '    MsgBox(ex.Message)
        '                'End Try
        '            End If
        '        Next
        '    End If

        '    '' Order the final results
        '    '' HACK: TODO: get this to work for multiple levels. should be Parent != [top level item] (rather than Is Nothing)
        '    'Bom = From i In Bom
        '    '      Let topLevel = If(i.Parent Is Nothing, i.Item1, i.Parent.Item1 + "_")
        '    '      Order By topLevel, i.Item1
        '    '      Select i
        '    Bom = From i In Bom
        '          Order By i.Item1
        '          Select i

        '    Bom.Load
        '    'GeneralBindingSource.DataSource = Bom.ToList
        'End Sub

        'Private Sub AddFilter(Filter As EJFilter)
        '    ' Start new filter list if not currently filtered
        '    If _filterOn = False Then _filterList.Clear()
        '    _filterList.Push(Filter)
        '    _filterOn = True
        '    Requery()
        'End Sub

        'Private Sub ContextMenu_Opened(sender As Object, e As RoutedEventArgs)
        '    Dim target = CType(sender, ContextMenu).PlacementTarget
        '    If TypeOf target Is TextBox Then
        '        If CType(target, TextBox).SelectionLength = 0 Then
        '            Dim coll As New CompositeCollection
        '            Dim c As New CollectionContainer
        '            Dim c2 As New CollectionContainer
        '            c.Collection = CType(FindResource("StandardMenu"), ContextMenu).Items
        '            coll.Add(c)
        '            c2.Collection = CType(FindResource("SelectedStringFilterMenu"), ContextMenu).Items
        '            coll.Add(c2)
        '            'CType(sender, ContextMenu).Items.Clear()
        '            CType(sender, ContextMenu).ItemsSource = coll
        '        ElseIf CType(target, TextBox).SelectionStart = 0 Then
        '            Dim coll As New CompositeCollection
        '            Dim c As New CollectionContainer
        '            Dim c2 As New CollectionContainer
        '            c.Collection = CType(FindResource("StandardMenu"), ContextMenu).Items
        '            coll.Add(c)
        '            c2.Collection = CType(FindResource("StartStringFilterMenu"), ContextMenu).Items
        '            coll.Add(c2)
        '            'CType(sender, ContextMenu).Items.Clear()
        '            CType(sender, ContextMenu).ItemsSource = coll
        '        End If
        '    ElseIf TypeOf target Is DataGridCell Then

        '    End If

        'End Sub

#End Region 'Events

#Region "Serialization"
        <Serializable>
        Public Class Info
            Public Property Content() As String
            Public Property Caption() As String
        End Class
        Private Function ISupportSerializationGeneric_SaveState() As Info Implements ISupportState(Of Info).SaveState
            Return New Info() With {.Content = Me.Model, .Caption = Me.Caption}
        End Function
        Private Sub ISupportSerializationGeneric_RestoreState(ByVal state As Info) Implements ISupportState(Of Info).RestoreState
            Me.Model = state.Content
            Me.Caption = state.Caption
        End Sub
#End Region
    End Class

End Namespace