Imports System.ComponentModel

Public Class PartsTableControl
    Private _db As EJData.CorporateEntities
    Private OrderedParts As IQueryable(Of EJData.Part)

    Private _currRow As New List(Of Object) ' row values for restoring row if edit is cancelled
    Private _getRowValues As Boolean ' indicates that row values should be saved to enable edit to be cancelled
    Private _newRow As DataGridViewRow ' the latest new row
    Private _discardRow As Boolean ' marks _newRow for deletion

    Function IsInDesignMode() As Boolean
        Return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio")
    End Function

    Private Sub PartsView_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsInDesignMode() Then Exit Sub
        _db = EJData.DataHelpers.GetNewDbContext

        OrderedParts = From p In _db.Parts
                       Order By p.PartNo
                       Select p
        PartBindingSource.DataSource = OrderedParts.ToList
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        ' TO DO: If PartNo, show drawing.
    End Sub

    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        ' If this is a new row..
        If DataGridView1.CurrentRow Is _newRow Then
            Try
                _db.Parts.Add(CType(DataGridView1.CurrentRow.DataBoundItem, EJData.Part))
                _db.SaveChanges()
                ' Empty temporary previous row values _currRow
                _currRow.RemoveRange(0, _currRow.Count)
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
                    'PartBindingSource.CancelEdit()
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
        If MsgBox("Are you sure you want to completely delete this Part? Parts should only be deleted if they have never been used or referenced in any way", vbYesNoCancel) = MsgBoxResult.Yes Then
            ' Try removing the part from the Parts table. If unsuccessful, cancel the row deletion
            Try
                _db.Parts.Remove(CType(e.Row.DataBoundItem, EJData.Part))
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

    Private Sub PartBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles PartBindingSource.CurrentChanged
        _getRowValues = True

        ' Now we've moved away from it we can delete the row marked for deletion
        If _discardRow Then
            _discardRow = False
            Try
                _db.Parts.Remove(CType(_newRow.DataBoundItem, EJData.Part))
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

    Private Sub DataGridView1_DragEnter(sender As Object, e As DragEventArgs) Handles DataGridView1.DragEnter
        ' HACK: test only!
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub DataGridView1_DragDrop(sender As Object, e As DragEventArgs) Handles DataGridView1.DragDrop
        ' HACK: test only!
        Dim files() As String = CType(e.Data.GetData(DataFormats.Text), String())
        MsgBox(files(0))
        MsgBox(e.Data.GetData(DataFormats.Text, True))
    End Sub
End Class
