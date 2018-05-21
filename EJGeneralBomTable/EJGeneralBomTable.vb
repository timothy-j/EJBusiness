﻿Imports System.ComponentModel
Imports System.Linq.Dynamic
Imports System.Reflection

Public Class EJGeneralBomTable
    Private _db As EJData.CorporateEntities
    Private _machines As List(Of Short)
    Private _initialisingGrid As Boolean
    Public Property MachineType() As String = ""

    <Category("Appearance"), Description("Defines the cell text colour of child rows")>
    Public Property ChildRowTextColor As Color = Color.Gray


    Private _currRow As New List(Of Object) ' row values for restoring row if edit is cancelled
    Private _getRowValues As Boolean ' indicates that row values should be saved to enable edit to be cancelled
    'Private _newRow As DataGridViewRow ' the latest new row
    'Private _discardRow As Boolean ' marks _newRow for deletion

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

        _machines = (From m In _db.Machines
                     Where m.Supplied = False And m.Type = MachineType
                     Order By m.Number Descending
                     Select m.Number).ToList

        For Each mc In _machines

            Dim colS As DataGridViewColumn = DataGridView1.Columns.Item("MCS000Column").Clone
            colS.Name = "MCS" & mc & "Column"
            colS.HeaderText = "S" & mc
            colS.ValueType = GetType(String)
            DataGridView1.Columns.Insert(0, colS)

            Dim col As DataGridViewColumn = DataGridView1.Columns.Item("MC000Column").Clone
            col.Name = "MC" & mc & "Column"
            col.HeaderText = mc
            col.ValueType = GetType(EJData.MachineItem).GetProperty("Qty").PropertyType
            DataGridView1.Columns.Insert(0, col)
        Next

        DataGridView1.Columns.Item("MC000Column").Visible = False
        DataGridView1.Columns.Item("MCS000Column").Visible = False

        ' HACK: TODO: get this to work. should be Parent != top level item (rather than Is Nothing)
        Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("MachineItems").Include("Part")
                                                Let topLevel = If(i.Parent Is Nothing, i.Item1, i.Parent.Item1 + "_")
                                                Order By topLevel, i.Item1
                                                Where i.Type = MachineType And i.Status <> "D"
                                                Select i

        GeneralBindingSource.DataSource = Bom.ToList

        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = GeneralBindingSource
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        If DataGridView1.Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

        ' Add data to machines columns
        _initialisingGrid = True
        For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1

            ' Make assembly items grey
            If DataGridView1.Rows.Item(i).DataBoundItem.Parent IsNot Nothing Then DataGridView1.Rows.Item(i).DefaultCellStyle.ForeColor = ChildRowTextColor

            For Each mc In _machines
                Dim m = (From mi In CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).MachineItems
                         Where mi.MachineID = mc
                         Select mi.Qty, mi.Status).FirstOrDefault
                If m Is Nothing Then Continue For
                DataGridView1.Rows(i).Cells("MC" & mc & "Column").Value = m.Qty
                DataGridView1.Rows(i).Cells("MCS" & mc & "Column").Value = m.Status
            Next
        Next

        _initialisingGrid = False

    End Sub

    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        ' Make unbound changes and attempt to save

        ' TO DO: machine columns

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

            Dim headers = (From header As DataGridViewColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)()
                           Select header.HeaderText).ToArray
            Dim rows = From row As DataGridViewRow In DataGridView1.SelectedRows.Cast(Of DataGridViewRow)()
                       Where Not row.IsNewRow
                       Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) _
                           If(c.Value IsNot Nothing, If(InStr(c.Value.ToString, vbTab) Or InStr(c.Value.ToString, vbNewLine) Or InStr(c.Value.ToString, vbCr),
                           Replace(Replace(Replace(c.Value.ToString, vbNewLine, """\n"""), vbCr, """\n"""), vbTab, " "), c.Value.ToString), ""))

            Dim csvString As String = String.Join(vbTab, headers) + vbNewLine
            For Each row In rows
                csvString += String.Join(vbTab, row) + vbNewLine
            Next

            data.SetData(DataFormats.Text, csvString)
            'data.SetData(DataFormats.FileDrop, fileList.ToArray)
            'data.SetData(DataFormats.CommaSeparatedValue, False, rows) 'DataGridView1.SelectedRows)
            DoDragDrop(data, DragDropEffects.Copy)
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Columns.Item(e.ColumnIndex).Name = "ItemColumn" Then
            With DataGridView1.Rows.Item(e.RowIndex).Cells
                EJHelpers.FollowDrawingLink(.Item("DrawingTypeColumn").Value, .Item("PartColumn").Value)
            End With
        End If
        If DataGridView1.Columns.Item(e.ColumnIndex).Name.StartsWith("MCS") Then
            EJHelpers.OpenOrderView(DataGridView1.Rows.Item(e.RowIndex).Cells.Item(e.ColumnIndex).Value)
        End If
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        If e.Button = MouseButtons.Right Then
            Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("MachineItems").Include("Part")
                                                    Order By i.Type, i.Item1
            'Where ("i.Type = RF")
            'Where i.Type = "RF"
            Dim filterString As String = "Not Type.Contains(""F"") Or Item.StartsWith(""AC"")"

            Try

                Bom = Bom.Where(filterString, Nothing)
                GeneralBindingSource.DataSource = Bom.ToList
            Catch ex As Exception
                MsgBox("Filter was not applied due to the following error:" + vbNewLine + ex.Message + vbNewLine + vbNewLine + "Filter string:" + vbNewLine + filterString)
            End Try
            Dim info() As PropertyInfo = GetType(EJData.Item).GetProperties
            Dim info2() As MethodInfo = GetType(EJData.Item).GetMethods
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If Not _initialisingGrid Then
            If DataGridView1.Columns(e.ColumnIndex).Name.StartsWith("MC") Then
                Dim rowItem As EJData.Item = DataGridView1.Rows.Item(e.RowIndex).DataBoundItem
                ' HACK: TODO: get this to work. should be Parent != top level item
                If rowItem.Parent IsNot Nothing Then
                    For Each mc In _machines
                        If DataGridView1.Columns(e.ColumnIndex).Name = "MC" & mc & "Column" Then
                            rowItem.MachineItems.Where("MachineID = " & mc).FirstOrDefault.Qty _
                            = DataGridView1.Rows.Item(e.RowIndex).Cells.Item("MC" & mc & "Column").Value
                        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "MCS" & mc & "Column" Then
                            rowItem.MachineItems.Where("MachineID = " & mc).FirstOrDefault.Status _
                            = DataGridView1.Rows.Item(e.RowIndex).Cells.Item("MCS" & mc & "Column").Value
                        End If
                    Next
                End If
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
End Class
