Imports System.ComponentModel

Public Class ItemsTableControl
    Private _db As EJData.CorporateEntities
    Private OrderedItems As IQueryable(Of EJData.Item)

    Private _currRow As New List(Of Object) ' row values for restoring row if edit is cancelled
    Private _getRowValues As Boolean ' indicates that row values should be saved to enable edit to be cancelled
    Private _newRow As DataGridViewRow ' the latest new row
    Private _discardRow As Boolean ' marks _newRow for deletion
    Private _previousPartFilter As Integer?
    Private _addedItem As EJData.Item ' Stores the last item added to the database so it can be removed if necessary (e.g. if it is a duplicate)
    Private _leavingDGV As Boolean

    Public Property DBContext() As EJData.CorporateEntities
        Get
            Return _db
        End Get
        Set(ByVal value As EJData.CorporateEntities)
            _db = value
        End Set
    End Property

    ''' <summary>
    ''' Checks whether the form is currently being used in the VS form designer
    ''' </summary>
    ''' <returns></returns>
    Function IsInDesignMode() As Boolean
        Return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio")
    End Function

    'Private _usePartFilter As Boolean
    'Public Property PartFilterEnable() As Boolean
    '    Get
    '        Return _usePartFilter
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _usePartFilter = value
    '    End Set
    'End Property

    Private _PartIDFilter As Integer?
    Public Property PartIDFilter() As Integer?
        Get
            Return _PartIDFilter
        End Get
        Set(ByVal value As Integer?)
            _PartIDFilter = value
            If IsInDesignMode() Or _db Is Nothing Then Exit Property

            ' TO DO: speed up loading by avoiding unneccessary database call for full Items table
            'If Not PartFilterEnable And value Is Nothing Then Exit Property

            If value = _previousPartFilter Then Exit Property

            _previousPartFilter = value

            Requery()

            'OrderedItems = From i In _db.Items
            '               Order By i.Type, i.Item1
            '               Where i.PartID = value
            '               Select i

            'ItemBindingSource.DataSource = OrderedItems.ToList
        End Set
    End Property

    Public Property SplitterDistance() As Integer
        Get
            Return SplitContainer1.SplitterDistance
        End Get
        Set(ByVal value As Integer)
            SplitContainer1.SplitterDistance = value
        End Set
    End Property

    Private Sub ItemsView_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsInDesignMode() Then Exit Sub
        If DBContext Is Nothing Then DBContext = EJData.DataHelpers.GetNewDbContext

        OrderedItems = From i In _db.Items
                       Order By i.Type, i.Item1
                       Select i
        ItemBindingSource.DataSource = OrderedItems.ToList
    End Sub

    Private Sub ChildrenBindingSource_ListChanged(sender As Object, e As ListChangedEventArgs) Handles ChildrenBindingSource.ListChanged
        If ChildrenBindingSource.Count = 0 Then
            SplitContainer1.Panel2Collapsed = True
        Else
            SplitContainer1.Panel2Collapsed = False
        End If
    End Sub

    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        ' If this is a new row..
        If DataGridView1.CurrentRow Is _newRow Then
            Try
                ' Make sure Item links to filtered Part
                If Not PartIDFilter Is Nothing Then
                    CType(DataGridView1.CurrentRow.DataBoundItem, EJData.Item).PartID = PartIDFilter
                    DataGridView1.CurrentRow.Cells("PartIDDataGridViewTextBoxColumn").Value = PartIDFilter
                End If

                'MsgBox(_db.Items.Contains(_addedItem))
                If _addedItem IsNot CType(DataGridView1.CurrentRow.DataBoundItem, EJData.Item) Then
                    _addedItem = _db.Items.Add(CType(DataGridView1.CurrentRow.DataBoundItem, EJData.Item))
                End If
                _db.SaveChanges()
                ' Empty temporary previous row values _currRow
                _currRow.RemoveRange(0, _currRow.Count)
                _newRow = Nothing
            Catch ex As Exception
                ' Get the lowest level exception message
                Do Until ex.InnerException Is Nothing
                    ex = ex.InnerException
                Loop
                If MsgBox(ex.Message & vbNewLine & vbNewLine & "Discard new row?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    _discardRow = True
                    ' don't cancel the validation so row gets deleted
                    Exit Sub
                Else
                    ' Keep this row as _newRow
                    _getRowValues = False
                End If
                e.Cancel = True
            End Try
            Exit Sub
        End If

        ' If this is a row edit (or delete?)
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
            Else
                ' Do I need to clear _currRow here?
                _newRow = DataGridView1.CurrentRow
            End If
            _getRowValues = False
        End If
    End Sub

    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        If MsgBox("Are you sure you want to completely delete this Item? Items should only be deleted if they have never been used or referenced in any way", vbYesNoCancel) = MsgBoxResult.Yes Then
            ' Try removing the item from the Items table. If unsuccessful, cancel the row deletion
            Try
                _db.Items.Remove(CType(e.Row.DataBoundItem, EJData.Item))
                _db.SaveChanges()
            Catch ex As Exception
                ' Get the lowest level exception message
                Do Until ex.InnerException Is Nothing
                    ex = ex.InnerException
                Loop
                MsgBox(ex.Message)
                e.Cancel = True
                ' TO DO: User can never leave row as _db model or BindingSource still has row flagged as deleted
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ItemBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles ItemBindingSource.CurrentChanged
        _getRowValues = True

        ' Now we've moved away from it we can delete the row marked for deletion
        If _discardRow Then
            _discardRow = False
            Try
                _db.Items.Remove(_addedItem)
                _db.SaveChanges()
                DataGridView1.Rows.Remove(_newRow)
            Catch ex As Exception
                ' Get the lowest level exception message
                Do Until ex.InnerException Is Nothing
                    ex = ex.InnerException
                Loop
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = MouseButtons.Left And DataGridView1.SelectedCells.Count > 1 Then
            ' TO DO: get ItemID of all selected cells?
            ' HACK: test only! (Drag drop)
            Dim headers = (From header As DataGridViewColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)()
                           Select header.HeaderText).ToArray
            Dim rows = From row As DataGridViewRow In DataGridView1.Rows.Cast(Of DataGridViewRow)()
                       Where Not row.IsNewRow
                       Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))

            Dim data As New DataObject
            Dim files() As String = {"\\SERVER2\Business\Drawings\PIV Spare Parts List.pdf"}
            'Dim files() As String = String.Join("\t", rows) '{"\\SERVER2\Business\Drawings\PIV Spare Parts List.pdf"}
            'data.SetData(DataFormats.FileDrop, files)
            data.SetData(DataFormats.Text, String.Join(vbTab, rows(0)))
            'data.SetData(DataFormats.CommaSeparatedValue, False, rows) 'DataGridView1.SelectedRows)
            DoDragDrop(data, DragDropEffects.Copy)
        End If
    End Sub

    Public Sub Requery()
        OrderedItems = From i In _db.Items
                       Order By i.Type, i.Item1
                       Where i.PartID = PartIDFilter
                       Select i

        ItemBindingSource.DataSource = OrderedItems.ToList
    End Sub

    Private Sub DataGridView1_Leave(sender As Object, e As EventArgs) Handles DataGridView1.Leave
        _leavingDGV = True
    End Sub

    Private Sub DataGridView1_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowValidated
        If Not _leavingDGV Then Exit Sub
        _leavingDGV = True

        _getRowValues = True

        ' Now we've moved away from it we can delete the row marked for deletion
        If _discardRow Then
            _discardRow = False
            Try
                _db.Items.Remove(_addedItem)
                _db.SaveChanges()
                _newRow = Nothing
                Requery()
            Catch ex As Exception
                ' Get the lowest level exception message
                Do Until ex.InnerException Is Nothing
                    ex = ex.InnerException
                Loop
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class
