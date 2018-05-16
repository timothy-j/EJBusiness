Imports System.ComponentModel

Public Class OrderForm
    Private _db As EJData.CorporateEntities

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'MsgBox(DataGridViewTextBoxColumn13.CellType.ToString)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Fill data sources
        _db = EJData.DataHelpers.GetNewDbContext

        ' Must fill combobox source before form source otherwise combobox will initially contain wrong value
        Dim CurrentSuppliers = From s In _db.Suppliers
                               Select s
                               Where s.Archived = False
        SupplierBindingSource.DataSource = CurrentSuppliers.ToList

        OrderBindingSource.DataSource = _db.Orders.ToList
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        OrderDetailsDataGridView.EndEdit()
        OrderDetailsBindingSource.EndEdit()
        OrderBindingSource.EndEdit()
        If _db.ChangeTracker.HasChanges Then _db.SaveChanges()
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click

        If Not SentCheckBox.Checked Then
            If MsgBox("Are you sure you want to delete this order?", vbYesNo) = MsgBoxResult.Yes Then
                ' make sure Sent state has been saved to database otherwise deletion won't be allowed
                OrderBindingSource.EndEdit()
                If _db.ChangeTracker.HasChanges Then _db.SaveChanges()

                ' Delete from Entities and BindingSource (actual deletion will happen on _db.SaveChanges)
                _db.Orders.Remove(OrderBindingSource.Current)
                OrderBindingSource.RemoveCurrent()
            End If
        Else
            MsgBox("Orders can only be deleted if not marked 'sent'")
        End If

    End Sub

    Private Sub OrderBindingSource_AddingNew(sender As Object, e As AddingNewEventArgs) Handles OrderBindingSource.AddingNew
        ' Create an Order with next order number
        Dim newOrder As New EJData.Order
        Dim LastOrder = Aggregate o In _db.Orders
                                Into Max(o.OrderNo)
        newOrder.Date = DateTime.Now
        newOrder.OrderNo = LastOrder + 1
        ' Add Order to Entity (gets saved in CurrentChanged event)
        _db.Orders.Add(newOrder)
        ' Add order to BindingSource
        e.NewObject = newOrder
    End Sub

    Private Sub OrderBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles OrderBindingSource.CurrentChanged
        OrderDetailsBindingSource.EndEdit()
        OrderBindingSource.EndEdit()
        If _db.ChangeTracker.HasChanges Then
            'MsgBox("has changes. Saving..")
            _db.SaveChanges()
        End If
    End Sub

    Private Sub OrderDetailsDataGridView_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles OrderDetailsDataGridView.EditingControlShowing
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim txtCtrl = CType(e.Control, DataGridViewTextBoxEditingControl)
            txtCtrl.Select(txtCtrl.TextLength, 0)
            If OrderDetailsDataGridView.GetChildAtPoint(MousePosition) Is txtCtrl Then
                MsgBox("selected")
                txtCtrl.SelectionStart = txtCtrl.GetCharIndexFromPosition(MousePosition)
            End If
        End If
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        OrderDetailsDataGridView.Dispose()
        _db.Dispose()
    End Sub

    'Private Sub SupplierComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles SupplierComboBox.SelectionChangeCommitted
    '    MsgBox("selection change committed")
    'End Sub

    'Private Sub SupplierComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SupplierComboBox.SelectedIndexChanged
    '    MsgBox("selected index committed")
    'End Sub
End Class
