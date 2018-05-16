Imports System.Linq.Dynamic
Imports System.Reflection

Public Class EJGeneralBomTable
    Private _db As EJData.CorporateEntities
    Private _machines As List(Of Short)
    Public Property MachineType() As String

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

        MachineType = "HX"

        _machines = (From m In _db.Machines
                     Where m.Supplied = False And m.Type = MachineType
                     Order By m.Number Descending
                     Select m.Number).ToList

        For Each mc In _machines

            Dim colS As DataGridViewColumn = DataGridView1.Columns.Item("MCS000Column").Clone
            colS.Name = "MCS" & mc & "Column"
            colS.HeaderText = "S" & mc
            DataGridView1.Columns.Insert(0, colS)

            Dim col As DataGridViewColumn = DataGridView1.Columns.Item("MC000Column").Clone
            col.Name = "MC" & mc & "Column"
            col.HeaderText = mc
            DataGridView1.Columns.Insert(0, col)
        Next

        DataGridView1.Columns.Item("MC000Column").Visible = False
        DataGridView1.Columns.Item("MCS000Column").Visible = False
        'DataGridView1.DoubleBuffered = True

        Dim Bom As IQueryable(Of EJData.Item) = From i In _db.Items.Include("MachineItems").Include("Part")
                                                Order By i.Type, i.Item1
                                                Where i.Type = MachineType

        GeneralBindingSource.DataSource = Bom.ToList

        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = GeneralBindingSource
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        If DataGridView1.Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub
        For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
            'MsgBox(CType(DataGridView1.Rows(e.RowIndex).DataBoundItem.i, EJData.Item).Item1)
            'DataGridView1.Rows(i).Cells("StockColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.Stock
            'DataGridView1.Rows(i).Cells("SuppliersDescriptionColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.SuppliersDescription
            'DataGridView1.Rows(i).Cells("SupplierColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.Supplier
            'DataGridView1.Rows(i).Cells("UnitColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.Unit
            'DataGridView1.Rows(i).Cells("SecondOpColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.SecondOperation
            'DataGridView1.Rows(i).Cells("DateCheckedColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.DateChecked
            'DataGridView1.Rows(i).Cells("StatusColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.Status
            'DataGridView1.Rows(i).Cells("PartColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.PartNo
            'DataGridView1.Rows(i).Cells("RowNotesColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.ProductionNotes
            'DataGridView1.Rows(i).Cells("DrawingTypeColumn").Value = CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).Part.DrawingType

            For Each mc In _machines
                Dim m = (From mi In CType(DataGridView1.Rows(i).DataBoundItem, EJData.Item).MachineItems
                         Where mi.MachineID = mc
                         Select mi.Qty, mi.Status).FirstOrDefault
                If m Is Nothing Then Continue For
                DataGridView1.Rows(i).Cells("MC" & mc & "Column").Value = m.Qty
                DataGridView1.Rows(i).Cells("MCS" & mc & "Column").Value = m.Status
            Next
        Next

    End Sub

    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        ' Make unbound changes and attempt to save
        ' TO DO: do unbound changes on cellvalidating
        With CType(DataGridView1.CurrentRow.DataBoundItem, EJData.Item).Part
            ' TO DO: sort out nulls or ""
            '.Stock = DataGridView1.CurrentRow.Cells("StockColumn").Value
            '.SuppliersDescription = DataGridView1.CurrentRow.Cells("SuppliersDescriptionColumn").Value
            '.Supplier = DataGridView1.CurrentRow.Cells("SupplierColumn").Value
            '.Unit = DataGridView1.CurrentRow.Cells("UnitColumn").Value
            '.SecondOperation = DataGridView1.CurrentRow.Cells("SecondOpColumn").Value
            '.DateChecked = DataGridView1.CurrentRow.Cells("DateCheckedColumn").Value
            '.Status = DataGridView1.CurrentRow.Cells("StatusColumn").Value
            ''.PartNo = DataGridView1.CurrentRow.Cells("PartColumn").Value 
            '.ProductionNotes = DataGridView1.CurrentRow.Cells("RowNotesColumn").Value
            '.DrawingType = DataGridView1.CurrentRow.Cells("DrawingTypeColumn").Value
        End With

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
End Class
