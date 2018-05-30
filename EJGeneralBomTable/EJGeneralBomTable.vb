Imports System.ComponentModel
Imports System.Linq.Dynamic
Imports System.Reflection

Public Class EJGeneralBomTable

    Private _db As EJData.CorporateEntities
    Private _machines As List(Of MachInfo)             ' List of machines to be displayed on form
    Private _initialisingGrid As Boolean            ' Flag to avoid uneccessary processing while columns are being added
    Private _editMouseLocation As Point
    Private _dynamicSelectingCell As DataGridViewCell
    Private _contextMenuCell As DataGridViewCell    ' The cell the context menu opened on
    Private _filterList As New Stack(Of EJFilter)
    Private _filterOn As Boolean

    Class MachInfo
        Public Property Number As Short
        Public Property DetailID As Integer?
    End Class

    Structure EJFilter
        Public columnName As String
        Public condition As String
        Public prefix As String ' Such as Not
    End Structure

    Public Property MachineType() As String = ""    ' Machine type code for basic form query

    <Category("Appearance"), Description("Defines the cell text colour of child rows")>
    Public Property ChildRowTextColor As Color = Color.Gray


    Private _currRow As New List(Of Object)         ' row values for restoring row if edit is cancelled
    Private _getRowValues As Boolean                ' indicates that row values should be saved to enable edit to be cancelled

    ''' <summary>
    ''' Checks whether the form is currently being used in the VS form designer
    ''' </summary>
    ''' <returns></returns>
    Function IsInDesignMode() As Boolean
        Return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio")
    End Function

    Private Sub EJGeneralBomTable_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsInDesignMode() Then Exit Sub

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


        '
        _machines = (From m In machines
                     Order By m.Number Descending
                     Select New MachInfo With {.Number = m.Number, .DetailID = m.OrderDetailID}).ToList



        For Each mc In _machines

            Dim colS As DataGridViewColumn = DataGridView1.Columns.Item("MCS000Column").Clone
            colS.Name = "MCS" & mc.Number & "Column"
            colS.HeaderText = "S" & mc.Number
            colS.ValueType = GetType(String)
            DataGridView1.Columns.Insert(0, colS)

            Dim col As DataGridViewColumn = DataGridView1.Columns.Item("MC000Column").Clone
            col.Name = "MC" & mc.Number & "Column"
            col.HeaderText = mc.Number
            col.ValueType = GetType(EJData.MachineItem).GetProperty("Qty").PropertyType
            DataGridView1.Columns.Insert(0, col)
        Next

        DataGridView1.Columns.Item("MC000Column").Visible = False
        DataGridView1.Columns.Item("MCS000Column").Visible = False


        DataGridView1.AutoGenerateColumns = False
        Requery()
        DataGridView1.DataSource = GeneralBindingSource ' Done just once when first loaded
    End Sub


    ''' <summary>
    ''' Add data to machine columns and format rows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        If DataGridView1.Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

        ' Add data to machines columns
        _initialisingGrid = True
        For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1

            ' Make assembly items grey - TODO: consider colour levels to go with nesting levels
            If DataGridView1.Rows.Item(i).DataBoundItem.Parent IsNot Nothing Then DataGridView1.Rows.Item(i).DefaultCellStyle.ForeColor = ChildRowTextColor

            For Each mc In _machines
                'Dim m = (From mi In CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).MachineItems
                '         Where mi.MachineID = mc
                '         Select mi.Qty, mi.Status).FirstOrDefault

                ' First go at machines stored in CustOrderItemDetails
                Dim m = (From cod In CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).CustOrderItemDetails
                         Where cod.DetailID = mc.DetailID
                         Select Qty = cod.Quantity, cod.Status).FirstOrDefault

                If m Is Nothing Then Continue For
                DataGridView1.Rows(i).Cells("MC" & mc.Number & "Column").Value = m.Qty
                DataGridView1.Rows(i).Cells("MCS" & mc.Number & "Column").Value = m.Status
            Next
        Next

        _initialisingGrid = False

    End Sub

    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        ' Make unbound changes and attempt to save

        If _db.ChangeTracker.HasChanges Then
            Try
                _db.SaveChanges()
                ' Empty temporary previous row values _currRow
                _currRow.RemoveRange(0, _currRow.Count)
            Catch ex As Exception
                ' Get the lowest level exception message
                Do Until ex.InnerException Is Nothing
                    ex = ex.InnerException
                Loop
                If MsgBox(ex.Message & vbNewLine & vbNewLine & "Undo row changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'ItemBindingSource.CancelEdit()
                    If _currRow.Count Then
                        DataGridView1.CurrentRow.SetValues(_currRow.ToArray)
                    End If
                End If
                e.Cancel = True
            End Try
        End If

    End Sub

    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        If _getRowValues Then
            'If DataGridView1.CurrentRow Is Nothing Then Exit Sub
            If Not DataGridView1.CurrentRow.IsNewRow Then
                ' Empty temporary previous row values _currRow
                _currRow.RemoveRange(0, _currRow.Count)
                For Each cell As DataGridViewCell In DataGridView1.CurrentRow.Cells
                    _currRow.Add(cell.Value)
                Next
            End If
            _getRowValues = False
        End If
    End Sub

    Private Sub ItemBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles GeneralBindingSource.CurrentChanged
        _getRowValues = True
    End Sub

    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = MouseButtons.Left And DataGridView1.SelectedCells.Count > 1 Then
            ' TO DO: get ItemID of all selected cells?
            ' HACK: test only!
            Dim data As New DataObject

            ' Drag drop drawing files
            Dim fileList As New List(Of String)
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                With row.Cells
                    Try
                        Dim str As String = EJHelpers.GetDrawingLink(.Item("DrawingTypeColumn").Value, .Item("PartColumn").Value)
                        fileList.Add(str)
                    Catch
                    End Try
                End With
            Next

            'Dim headers = (From header As DataGridViewColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)()
            '               Select header.HeaderText).ToArray
            Dim rows = (From cell As DataGridViewCell In DataGridView1.SelectedCells.Cast(Of DataGridViewCell)()
                        Select value = cell.Value.ToString()).ToArray
            ' Try using Group By

            'Dim headers = (From header As DataGridViewColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)()
            '               Select header.HeaderText).ToArray
            'Dim rows = From row As DataGridViewRow In DataGridView1.SelectedRows.Cast(Of DataGridViewRow)()
            '           Where Not row.IsNewRow
            '           Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) _
            '               If(c.Value IsNot Nothing, If(InStr(c.Value.ToString, vbTab) Or InStr(c.Value.ToString, vbNewLine) Or InStr(c.Value.ToString, vbCr),
            '               Replace(Replace(Replace(c.Value.ToString, vbNewLine, """\n"""), vbCr, """\n"""), vbTab, " "), c.Value.ToString), ""))

            Dim csvString As String '= String.Join(vbTab, headers) + vbNewLine
            'For Each row In rows
            'For Each row In rows
            'For Each row In rows
            '    csvString += String.Join(vbTab, row) + vbNewLine
            'Next

            data.SetData(DataFormats.Text, rows) ' csvString)
            'data.SetData(DataFormats.FileDrop, fileList.ToArray)
            'data.SetData(DataFormats.CommaSeparatedValue, False, rows) 'DataGridView1.SelectedRows)
            DoDragDrop(data, DragDropEffects.Copy)

        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.ColumnIndex < 0 Then Exit Sub
        If DataGridView1.Columns.Item(e.ColumnIndex).Name = "ItemColumn" Then
            With DataGridView1.Rows.Item(e.RowIndex).Cells
                EJHelpers.FollowDrawingLink(.Item("DrawingTypeColumn").Value, .Item("PartColumn").Value)
            End With
        End If
        If DataGridView1.Columns.Item(e.ColumnIndex).Name.StartsWith("MCS") Then
            EJHelpers.OpenOrderView(DataGridView1.Rows.Item(e.RowIndex).Cells.Item(e.ColumnIndex).Value)
        End If
    End Sub

    ''' <summary>
    ''' Save changes back to machine column data source
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If Not _initialisingGrid Then
            If DataGridView1.Columns(e.ColumnIndex).Name.StartsWith("MC") Then
                Dim rowItem As EJData.Item = DataGridView1.Rows.Item(e.RowIndex).DataBoundItem
                ' HACK: TODO: get this to work. should be Parent != top level item
                'If rowItem.Parent IsNot Nothing Then
                For Each mc In _machines
                    Dim coid As EJData.CustOrderItemDetail = (From cod In CType(rowItem, EJData.Item).CustOrderItemDetails
                                                              Where cod.DetailID = mc.DetailID).FirstOrDefault
                    If DataGridView1.Columns(e.ColumnIndex).Name = "MC" & mc.Number & "Column" Then
                        ' This is a Qty column..
                        coid.Quantity = DataGridView1.Rows.Item(e.RowIndex).Cells.Item("MC" & mc.Number & "Column").Value
                    ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "MCS" & mc.Number & "Column" Then
                        ' This is a Status column..
                        coid.Status = DataGridView1.Rows.Item(e.RowIndex).Cells.Item("MCS" & mc.Number & "Column").Value
                    End If
                Next
                'End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles DataGridView1.CellParsing
        ' Send null to nullable values
        If DataGridView1.Columns(e.ColumnIndex).Name.StartsWith("MC") Then
            If e.Value = "" Then
                ' Is type nullable?
                If Nullable.GetUnderlyingType(e.DesiredType) IsNot Nothing Then
                    ' Some columns causing string conversion data error on null. TODO: try putting e.value to cell value and then to nothing?
                    e.Value = Nothing
                    e.ParsingApplied = True
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        ' Set the ContextMenuStrip for the editing control. Items are chosen and set up only when context menu opens
        e.Control.ContextMenuStrip = DefaultContextStrip
    End Sub

    ''' <summary>
    ''' Prepares the context strip for display with appropriate menu items
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DefaultContextStrip_Opening(sender As Object, e As CancelEventArgs) Handles DefaultContextStrip.Opening
        ' Only appears on editing controls (so far) so don't need to take account of other situations (yet)

        'Dim ht As DataGridView.HitTestInfo = DataGridView1.HitTest(MousePosition.X, MousePosition.Y)
        'If ht.ColumnIndex < 0 Or ht.RowIndex < 0 Then
        '    ' TODO: deal with context menu on headers
        'End If
        'Dim cell As DataGridViewCell = DataGridView1.Rows.Item(ht.RowIndex).Cells.Item(ht.ColumnIndex)

        _contextMenuCell = DataGridView1.CurrentCell

        If DataGridView1.IsCurrentCellInEditMode Then
            ' Undo previous merge, if any.
            ToolStripManager.RevertMerge(DefaultContextStrip)
            If EJHelpers.IsNumericType(DataGridView1.CurrentCell.ValueType) Then
                ' Show only numeric options
                ToolStripManager.Merge(NumericContextMenu, DefaultContextStrip)
                If DataGridView1.CurrentCell.Value.GetType Is GetType(String) Then
                    ' Hide all other options
                    NumericEqualsToolStripMenuItem.Visible = False
                    NumericDoesNotEqualToolStripMenuItem.Visible = False
                    NumericLessThanOrEqualToToolStripMenuItem.Visible = False
                    NumericGreaterThanOrEqualToToolStripMenuItem.Visible = False
                Else
                    ' Show all options and set text
                    NumericEqualsToolStripMenuItem.Visible = True
                    NumericDoesNotEqualToolStripMenuItem.Visible = True
                    NumericLessThanOrEqualToToolStripMenuItem.Visible = True
                    NumericGreaterThanOrEqualToToolStripMenuItem.Visible = True
                    NumericEqualsToolStripMenuItem.Text = "Equals " & DataGridView1.CurrentCell.FormattedValue.ToString
                    NumericDoesNotEqualToolStripMenuItem.Text = "Does not equal " & DataGridView1.CurrentCell.FormattedValue.ToString
                    NumericLessThanOrEqualToToolStripMenuItem.Text = "Less than or equal to " & DataGridView1.CurrentCell.FormattedValue.ToString
                    NumericGreaterThanOrEqualToToolStripMenuItem.Text = "Greater than or equal to " & DataGridView1.CurrentCell.FormattedValue.ToString
                End If
            ElseIf DataGridView1.CurrentCell.ValueType = GetType(DateTime) Or Nullable.GetUnderlyingType(DataGridView1.CurrentCell.ValueType) = GetType(DateTime) Then
                ' TODO: Show only date options
                ToolStripManager.Merge(DateContextMenuStrip, DefaultContextStrip)

            ElseIf DataGridView1.CurrentCell.ValueType = GetType(String) Then
                ' TODO: Show only string options
                ToolStripManager.Merge(StringContextMenuStrip, DefaultContextStrip)
                ' Hide all options
                TextEqualsToolStripMenuItem.Visible = False
                TextDoesNotEqualToolStripMenuItem.Visible = False
                TextBeginsWithToolStripMenuItem.Visible = False
                TextDoesNotBeginWithToolStripMenuItem.Visible = False
                TextEndsWithToolStripMenuItem.Visible = False
                TextDoesNotEndWithToolStripMenuItem.Visible = False
                TextContainsToolStripMenuItem.Visible = False
                TextDoesNotContainToolStripMenuItem.Visible = False
                If DataGridView1.CurrentCell.Value = "" Then
                    ' Leave options hidden
                Else
                    ' Show available options and set text
                    Dim ctl As TextBox = DataGridView1.EditingControl
                    Dim selText As String = ctl.SelectedText
                    If selText = "" Then selText = ctl.Text

                    If ctl.SelectionLength Then ' If there is a selection
                        ' Include contains options
                        TextContainsToolStripMenuItem.Visible = True
                        TextDoesNotContainToolStripMenuItem.Visible = True
                        TextContainsToolStripMenuItem.Text = "Contains '" & selText & "'"
                        TextDoesNotContainToolStripMenuItem.Text = "Does not contain '" & selText & "'"

                        ' If selection is at beginning
                        If ctl.SelectionStart = 0 Then
                            ' Include begins with options
                            TextBeginsWithToolStripMenuItem.Visible = True
                            TextDoesNotBeginWithToolStripMenuItem.Visible = True
                            TextBeginsWithToolStripMenuItem.Text = "Begins with '" & selText & "'"
                            TextDoesNotBeginWithToolStripMenuItem.Text = "Does not begin with '" & selText & "'"
                        End If

                        ' If selection is at end
                        If ctl.SelectionStart + ctl.SelectionLength = ctl.TextLength Then
                            ' Include ends with options
                            TextEndsWithToolStripMenuItem.Visible = True
                            TextDoesNotEndWithToolStripMenuItem.Visible = True
                            TextEndsWithToolStripMenuItem.Text = "Ends with '" & selText & "'"
                            TextDoesNotEndWithToolStripMenuItem.Text = "Does not end with '" & selText & "'"
                        End If
                    End If
                    ' Always show equals options
                    TextEqualsToolStripMenuItem.Visible = True
                    TextDoesNotEqualToolStripMenuItem.Visible = True
                    TextEqualsToolStripMenuItem.Text = "Equals '" & selText & "'"
                    TextDoesNotEqualToolStripMenuItem.Text = "Does not equal '" & selText & "'"
                End If
            Else
                ' Assume data can only be equal or not equal
            End If
        End If
    End Sub

    Private Sub DefaultContextStrip_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles DefaultContextStrip.Closing
        'ToolStripManager.RevertMerge(DefaultContextStrip)
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.Button = MouseButtons.Left Then
            ' If click was on a header..
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub ' HACK: should select whole row/column

            Dim cell As DataGridViewCell = DataGridView1.Rows.Item(e.RowIndex).Cells.Item(e.ColumnIndex)
            If cell.IsInEditMode Then 'Or DataGridView1.SelectedCells.Count > 1 Then
                Exit Sub
            Else
                DataGridView1.CurrentCell = cell
                ' Mouse location must be set before this call, as this is when cell edit is called
                DataGridView1.BeginEdit(True)
            End If
        End If
    End Sub


    ''' <summary>
    ''' Fills the datagrid with filtered data
    ''' </summary>
    Sub Requery()
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
                    Dim whereString As String = Filter.prefix & DataGridView1.Columns.Item(Filter.columnName).DataPropertyName & Filter.condition
                    Try
                        Bom = Bom.Where(whereString)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        End If

        ' Order the final results
        ' HACK: TODO: get this to work for multiple levels. should be Parent != [top level item] (rather than Is Nothing)
        Bom = From i In Bom
              Let topLevel = If(i.Parent Is Nothing, i.Item1, i.Parent.Item1 + "_")
              Order By topLevel, i.Item1
              Select i

        GeneralBindingSource.DataSource = Bom.ToList
    End Sub

    Private Sub AddFilter(Filter As EJFilter)
        ' Start new filter list if not currently filtered
        If _filterOn = False Then _filterList.Clear()
        _filterList.Push(Filter)
        _filterOn = True
        Requery()
    End Sub

#Region "ContextMenuStrip Subs"

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If DataGridView1.IsCurrentCellInEditMode Then
            CType(DataGridView1.EditingControl, TextBox).Copy()
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        If DataGridView1.IsCurrentCellInEditMode Then
            CType(DataGridView1.EditingControl, TextBox).Cut()
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        If DataGridView1.IsCurrentCellInEditMode Then
            CType(DataGridView1.EditingControl, TextBox).Paste()
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If DataGridView1.IsCurrentCellInEditMode Then
            CType(DataGridView1.EditingControl, TextBox).Undo()
        End If
    End Sub

    Private Sub TextContainsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextContainsToolStripMenuItem.Click, TextDoesNotContainToolStripMenuItem.Click
        ' Editing control should be visible and have text selected..
        Dim filter As New EJFilter With {.columnName = DataGridView1.Columns.Item(_contextMenuCell.ColumnIndex).Name,
                        .condition = ".Contains(""" & CType(DataGridView1.EditingControl, TextBox).SelectedText & """)"
                        }
        If sender Is TextDoesNotContainToolStripMenuItem Then filter.prefix = "Not "
        AddFilter(filter)
    End Sub


    Private Sub TextBeginsWithToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextBeginsWithToolStripMenuItem.Click, TextDoesNotBeginWithToolStripMenuItem.Click
        ' Editing control should be visible and have text selected..
        Dim filter As New EJFilter With {.columnName = DataGridView1.Columns.Item(_contextMenuCell.ColumnIndex).Name,
                        .condition = ".StartsWith(""" & CType(DataGridView1.EditingControl, TextBox).SelectedText & """)"
                        }
        If sender Is TextDoesNotBeginWithToolStripMenuItem Then filter.prefix = "Not "
        AddFilter(filter)
    End Sub

    Private Sub TextEndsWithToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextEndsWithToolStripMenuItem.Click, TextDoesNotEndWithToolStripMenuItem.Click
        ' Editing control should be visible and have text selected..
        Dim filter As New EJFilter With {.columnName = DataGridView1.Columns.Item(_contextMenuCell.ColumnIndex).Name,
                        .condition = ".EndsWith(""" & CType(DataGridView1.EditingControl, TextBox).SelectedText & """)"
                        }
        If sender Is TextDoesNotEndWithToolStripMenuItem Then filter.prefix = "Not "
        AddFilter(filter)
    End Sub

    Private Sub IsBlankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IsBlankToolStripMenuItem.Click
        ' Editing control should be visible 
        Dim filter As New EJFilter With {.columnName = DataGridView1.Columns.Item(_contextMenuCell.ColumnIndex).Name,
                        .condition = " = null"
                        }
        AddFilter(filter)
    End Sub

    Private Sub IsNotBlankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IsNotBlankToolStripMenuItem.Click
        ' Editing control should be visible 
        Dim filter As New EJFilter With {.columnName = DataGridView1.Columns.Item(_contextMenuCell.ColumnIndex).Name,
                        .condition = " != null"
                        }
        AddFilter(filter)
    End Sub

    Private Sub UndoFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoFilterToolStripMenuItem.Click
        _filterList.Pop()
        Requery()
    End Sub

    Private Sub ToggleFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleFilterToolStripMenuItem.Click
        _filterOn = Not _filterOn
        Requery()
    End Sub

    Private Sub NumericEqualsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NumericEqualsToolStripMenuItem.Click, NumericDoesNotEqualToolStripMenuItem.Click
        ' Editing control should be visible and have text selected..
        Dim filter As New EJFilter With {.columnName = DataGridView1.Columns.Item(_contextMenuCell.ColumnIndex).Name,
                        .condition = " = " & DataGridView1.CurrentCell.Value
                        }
        If sender Is NumericDoesNotEqualToolStripMenuItem Then filter.condition = " != " & DataGridView1.CurrentCell.Value 'DataGridView1.EditingControl.Text
        AddFilter(filter)
    End Sub

    Private Sub NumericLessThanOrEqualToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NumericLessThanOrEqualToToolStripMenuItem.Click, NumericGreaterThanOrEqualToToolStripMenuItem.Click
        ' Editing control should be visible and have text selected..
        Dim filter As New EJFilter With {.columnName = DataGridView1.Columns.Item(_contextMenuCell.ColumnIndex).Name,
                        .condition = " <= " & DataGridView1.CurrentCell.Value
                        }
        If sender Is NumericGreaterThanOrEqualToToolStripMenuItem Then filter.condition = " >= " & DataGridView1.CurrentCell.Value
        AddFilter(filter)
    End Sub

#End Region

End Class
