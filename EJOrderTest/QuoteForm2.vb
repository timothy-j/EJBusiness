Imports System.ComponentModel

Public Class QuoteForm2
    Private _db As EJData.CorporateEntities
    Private _detailToDelete As EJData.QuoteDetail
    Private _itemDetailToDelete As EJData.QuoteItemDetail
    ' HACK: up/down button test
    Dim upBtn As New Button
    Dim downBtn As New Button

    ''' <summary>
    ''' Defines a concrete type to be returned by EF query for combobox list
    ''' Can be used for any list in the form .ID as Integer?, .Item1 as String
    ''' </summary>
    Public Class EJItemType
        Private _ID As Integer?
        Public Property ID() As Integer?
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer?)
                _ID = value
            End Set
        End Property

        Private _Item1 As String
        Public Property Item1() As String
            Get
                Return _Item1
            End Get
            Set(ByVal value As String)
                _Item1 = value
            End Set
        End Property
    End Class

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Fill bindingsources for tables and ComboBoxes
        _db = EJData.DataHelpers.GetNewDbContext

        ' Fill combobox data sources BEFORE form data source
        CustomerBindingSource.DataSource = _db.Customers.ToList
        CustomerBindingSource.Sort = "Company"

        Dim source = From i In _db.Items
                     Select New EJItemType With {.ID = i.ID, .Item1 = i.Model + "-" + i.Item1}

        Dim ItemList As List(Of EJItemType) = source.ToList
        ItemList.Insert(0, New EJItemType With {.ID = Nothing, .Item1 = ""})
        ItemBindingSource.DataSource = ItemList 'source.ToList

        QuoteBindingSource.DataSource = _db.Quotes.ToList

        QDItemID.ValueMember = "ID"
        QDItemID.DisplayMember = "Item1"
        QIDItemID.ValueMember = "ID"
        QIDItemID.DisplayMember = "Item1"
        ItemID.ValueMember = "ID"
        ItemID.DisplayMember = "Item1"
        ParentID.ValueMember = "ID"
        ParentID.DisplayMember = "Item1"

        ' HACK: up/down button layout
        upBtn.Width = 12
        upBtn.Height = 20
        upBtn.Text = "^"
        downBtn.Width = 12
        downBtn.Height = 20
        downBtn.Left = 12
        downBtn.Text = "v"
        QuoteDetailsDataGridView.Controls.Add(upBtn)
        QuoteDetailsDataGridView.Controls.Add(downBtn)

    End Sub

    Private Sub QuoteBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles QuoteBindingSource.CurrentChanged
        Dim source = From q In _db.QuoteItemDetails
                     Where q.QuoteDetail.QuoteID = CType(QuoteBindingSource.Current, EJData.Quote).ID
                     Select q
        SummaryItemsBindingSource.DataSource = source.ToList
        If _db.ChangeTracker.HasChanges Then
            _db.SaveChanges()
        End If
    End Sub

    Private Sub QuoteDetailsDataGridView_Leave(sender As Object, e As EventArgs) Handles QuoteDetailsDataGridView.Leave
        QuoteDetailsDataGridView.EndEdit()
        If _db.ChangeTracker.HasChanges Then _db.SaveChanges()
    End Sub

    Private Sub QuoteForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        QuoteItemDetailsDataGridView.Dispose()
        QuoteDetailsDataGridView.Dispose()
        QuoteItemSummaryDataGridView.Dispose()
        _db.Dispose()
    End Sub

    Private Sub QuoteBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles QuoteBindingSource.AddingNew
        ' Create a Quote
        Dim newQuote As New EJData.Quote With {
            .Date = DateTime.Now
        }
        ' Add Quote to Entity (gets saved in CurrentChanged event)
        _db.Quotes.Add(newQuote)
        _db.SaveChanges()
        ' Add Quote to BindingSource
        e.NewObject = newQuote
    End Sub

    Private Sub QuoteDetailsBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles QuoteDetailsBindingSource.AddingNew
        ' Create a QuoteDetail
        Dim newQuoteDetail As New EJData.QuoteDetail
        Dim qID = CType(QuoteBindingSource.Current, EJData.Quote).ID
        Dim LastRowNo As Integer
        Try
            LastRowNo = Aggregate qd In _db.QuoteDetails
                            Where qd.QuoteID = qID
                                Into Max(qd.RowNo)
        Catch ex As System.InvalidOperationException
            If ex.Message = "Sequence contains no elements" Then
                LastRowNo = 0
            Else Throw
            End If
        End Try

        ' Add QuoteDetail to Entity (gets saved on SaveChanges)
        newQuoteDetail.QuoteID = CType(QuoteBindingSource.Current, EJData.Quote).ID
        newQuoteDetail.RowNo = LastRowNo + 1
        _db.QuoteDetails.Add(newQuoteDetail)
        ' Add QuoteDetail to BindingSource
        e.NewObject = newQuoteDetail
    End Sub

    Private Sub QuoteDetailsDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles QuoteDetailsDataGridView.CellEndEdit
        ' HACK: This assumes ItemID is selected from valid values
        If e.ColumnIndex = QuoteDetailsDataGridView.Columns("QDItemID").Index _
            And Not QuoteDetailsDataGridView.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing _
            And QuoteDetailsDataGridView.IsCurrentRowDirty Then

            If Not QuoteDetailsDataGridView.Item(QuoteDetailsDataGridView.Columns("QDDescription").Index, e.RowIndex).Value Is Nothing Then
                If MsgBox("Overwrite description?", vbYesNo) = MsgBoxResult.No Then Exit Sub
            End If
            ' Get the Item Description, from Spares if available or from Items if not
            Dim tempItemID = CInt(QuoteDetailsDataGridView.Item(e.ColumnIndex, e.RowIndex).Value)
            Dim desc = (From i In _db.Items
                        Where i.ID = tempItemID
                        Select i.Description).First
            QuoteDetailsDataGridView.Item(QuoteDetailsDataGridView.Columns("QDDescription").Index, e.RowIndex).Value = desc
            ' TODO: fill QuoteItemDetails with associated items
        End If
    End Sub

    Private Sub QuoteDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles QuoteDetailsBindingSource.CurrentChanged
        'QuoteItemDetailsBindingSource.EndEdit()
        'QuoteDetailsBindingSource.EndEdit()
        'QuoteBindingSource.EndEdit()
        If _db.ChangeTracker.HasChanges Then
            _db.SaveChanges()
            'QuoteDetailsBindingSource.ResetBindings(False)
        End If
    End Sub

    Private Sub QuoteItemDetailsDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles QuoteItemDetailsDataGridView.CellEndEdit
        ' HACK: This assumes ItemID is selected from valid values
        If e.ColumnIndex = QuoteItemDetailsDataGridView.Columns("QIDItemID").Index _
            And Not QuoteItemDetailsDataGridView.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing _
            And QuoteItemDetailsDataGridView.IsCurrentRowDirty Then

            'MsgBox(QuoteItemDetailsDataGridView.Item(e.ColumnIndex, e.RowIndex).EditedFormattedValue)
            If Not QuoteItemDetailsDataGridView.Item(QuoteItemDetailsDataGridView.Columns("QIDDescription").Index, e.RowIndex).Value Is Nothing Then
                If MsgBox("Overwrite description?", vbYesNo) = MsgBoxResult.No Then Exit Sub
            End If
            ' Get the Item Description, from Spares if available or from Items if not
            Dim tempItemID = CInt(QuoteItemDetailsDataGridView.Item(e.ColumnIndex, e.RowIndex).Value)
            Dim desc = (From i In _db.Items
                        Where i.ID = tempItemID
                        Select i.Description).First
            QuoteItemDetailsDataGridView.Item(QuoteItemDetailsDataGridView.Columns("QIDDescription").Index, e.RowIndex).Value = desc
        End If
    End Sub

    Private Sub QuoteDetailsDataGridView_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles QuoteDetailsDataGridView.UserDeletingRow
        If MsgBox("Are you sure you want to delete these rows and the associated items from this quote?", vbYesNo) = MsgBoxResult.Yes Then
            _detailToDelete = QuoteDetailsBindingSource.Current
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub QuoteDetailsDataGridView_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles QuoteDetailsDataGridView.UserDeletedRow
        If Not _detailToDelete Is Nothing Then
            _db.QuoteDetails.Remove(_detailToDelete)
            _detailToDelete = Nothing
        End If
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        If MsgBox("Are you sure you want to delete this quote?", vbYesNo) = MsgBoxResult.Yes Then
            ' make sure Sent state has been saved to database otherwise deletion won't be allowed
            QuoteBindingSource.EndEdit()
            If _db.ChangeTracker.HasChanges Then _db.SaveChanges()

            ' Delete from Entities and BindingSource (actual deletion will happen on _db.SaveChanges)
            _db.Quotes.Remove(QuoteBindingSource.Current)
            '_db.SaveChanges()
            QuoteBindingSource.RemoveCurrent()
        End If
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) _
        Handles Me.Closing, BindingNavigatorMoveFirstItem.Click, BindingNavigatorMovePreviousItem.Click, BindingNavigatorMoveNextItem.Click, BindingNavigatorMoveLastItem.Click

        ' Attempt to update record before moving/closing
        ' Note that record change cannot be cancelled unless BindingNavigator controls use only custom handlers
        QuoteItemSummaryDataGridView.EndEdit()
        QuoteItemDetailsDataGridView.EndEdit()
        QuoteDetailsDataGridView.EndEdit()
        'SummaryItemsBindingSource.EndEdit()
        'QuoteItemDetailsBindingSource.EndEdit()
        'QuoteDetailsBindingSource.EndEdit()
        ' QuoteBindingSource.EndEdit()
        If _db.ChangeTracker.HasChanges Then
            _db.SaveChanges()
            'QuoteDetailsBindingSource.ResetBindings(False)
        End If
    End Sub

    Private Sub QuoteItemDetailsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles QuoteItemDetailsDataGridView.SelectionChanged
        If QuoteItemDetailsDataGridView.IsCurrentCellInEditMode Then
            If QuoteItemDetailsDataGridView.SelectedRows.Count Then QuoteItemDetailsDataGridView.EndEdit()
        End If
    End Sub

    Private Sub QuoteItemDetailsDataGridView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles QuoteItemDetailsDataGridView.CellEnter
        If Me.ActiveControl Is QuoteItemDetailsDataGridView Then
            If QuoteItemDetailsDataGridView.SelectedRows.Count Then
                QuoteItemDetailsDataGridView.EndEdit()
            Else
                QuoteItemDetailsDataGridView.BeginEdit(False)
            End If
        End If
    End Sub

    Private Sub QuoteItemDetailsDataGridView_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles QuoteItemDetailsDataGridView.UserDeletingRow
        _itemDetailToDelete = QuoteItemDetailsBindingSource.Current
    End Sub

    Private Sub QuoteItemDetailsDataGridView_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles QuoteItemDetailsDataGridView.UserDeletedRow
        If Not _itemDetailToDelete Is Nothing Then
            ' Delete all Child QuoteItemDetails (where ParentID.Value = _itemDetailToDelete.ItemID.Value)
            Dim children = From qid In _db.QuoteItemDetails
                           Select qid
                           Where qid.ParentID = _itemDetailToDelete.ItemID And qid.DetailID = _itemDetailToDelete.DetailID
            Dim childrenList As List(Of EJData.QuoteItemDetail) = children.ToList
            If childrenList.Count > 0 Then _db.QuoteItemDetails.RemoveRange(childrenList)
            _db.QuoteItemDetails.Remove(_itemDetailToDelete)
            _itemDetailToDelete = Nothing
        End If
    End Sub

    Private Sub QuoteDetailsDataGridView_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles QuoteDetailsDataGridView.RowValidating
        If QuoteDetailsDataGridView.Rows(e.RowIndex).Cells("QDDescription").Value Is Nothing Then
            e.Cancel = True
            MsgBox("Description cannot be blank. Use a space [or press escape to undo edit]")
        End If
    End Sub

    Private Sub CustomerIDComboBox_Validating(sender As Object, e As CancelEventArgs) Handles CustomerIDComboBox.Validating
        If CustomerIDComboBox.SelectedValue Is Nothing Then
            MsgBox("yep")
            'CustomerIDComboBox.SelectedIndex = -1
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        If TypeOf sender Is TextBoxBase Then CType(sender, TextBoxBase).Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If TypeOf sender Is TextBoxBase Then CType(sender, TextBoxBase).Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        If TypeOf sender Is TextBoxBase Then CType(sender, TextBoxBase).Paste()
    End Sub

    Private Sub MoveUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem.Click
        ' HACK: assumes top left of menu is click point
        Dim ht As DataGridView.HitTestInfo = QuoteDetailsDataGridView.HitTest(TestCellContextMenu.Left, TestCellContextMenu.Top)
        If ht.Type = DataGridViewHitTestType.RowHeader Then
            'QuoteDetailsDataGridView.Rows(ht.RowIndex).
        End If
    End Sub

    ' HACK: up/down buttons
#Region "up/down button hack"
    Private Sub QuoteDetailsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles QuoteDetailsDataGridView.RowEnter
        upBtn.Top = QuoteDetailsDataGridView.GetRowDisplayRectangle(e.RowIndex, False).Top
        downBtn.Top = QuoteDetailsDataGridView.GetRowDisplayRectangle(e.RowIndex, False).Top
        If e.RowIndex < 1 Then
            upBtn.Visible = False
        Else
            upBtn.Visible = True
        End If
        If e.RowIndex = QuoteDetailsDataGridView.Rows.Count - 2 Then
            downBtn.Visible = False
        Else
            downBtn.Visible = True
        End If
    End Sub

    Private Sub QuoteDetailsDataGridView_Scroll(sender As Object, e As ScrollEventArgs) Handles QuoteDetailsDataGridView.Scroll
        ' TODO: sort out buttons disappearing when scrolled out of view and back. Ideas:
        ' Looks like it might be something to do with order of events as it
        Dim rowTop As Integer = QuoteDetailsDataGridView.GetRowDisplayRectangle(QuoteDetailsDataGridView.CurrentRow.Index, False).Top
        If rowTop < QuoteDetailsDataGridView.ColumnHeadersHeight Then
            upBtn.Visible = False
            downBtn.Visible = False
        Else
            upBtn.Top = rowTop
            downBtn.Top = rowTop
            upBtn.Visible = True
            downBtn.Visible = True
        End If
        If QuoteDetailsDataGridView.CurrentRow.Index < 1 Then upBtn.Visible = False
        If QuoteDetailsDataGridView.CurrentRow.Index = QuoteDetailsDataGridView.Rows.Count - 2 Then upBtn.Visible = False
    End Sub
#End Region
End Class