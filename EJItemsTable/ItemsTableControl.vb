Imports System.ComponentModel

Public Class ItemsTableControl
    Private _db As EJData.CorporateEntities
    Private OrderedItems As IQueryable(Of EJData.Item)

    Private _PartIDFilter As Integer?
    Public Property PartIDFilter() As Integer?
        Get
            Return _PartIDFilter
        End Get
        Set(ByVal value As Integer?)
            _PartIDFilter = value
            If DesignMode Or _db Is Nothing Then Exit Property

            OrderedItems = From i In _db.Items
                           Order By i.Type, i.Item1
                           Where i.PartID = value
                           Select i
        End Set
    End Property

    Private Sub ItemsView_Load(sender As Object, e As EventArgs) Handles Me.Load
        If DesignMode Then Exit Sub
        _db = New EJData.CorporateEntities

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

End Class
