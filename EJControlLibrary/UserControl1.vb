Public Class UserControl1

    Private _db As EJData.CorporateEntities
    Private _items As New System.ComponentModel.BindingList(Of Item)
    Private _potentialItems As New System.ComponentModel.BindingList(Of Item)

    Public Property Items() As System.ComponentModel.BindingList(Of Item)
        Get
            Return _items
        End Get
        Set(ByVal value As System.ComponentModel.BindingList(Of Item))
            _items = value
        End Set
    End Property


    Public Property PotentialItems() As System.ComponentModel.BindingList(Of Item)
        Get
            Return _potentialItems
        End Get
        Set(ByVal value As System.ComponentModel.BindingList(Of Item))
            _potentialItems = value
        End Set
    End Property

    Structure Item
        Private _ID As Integer
        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property

        Private _Desc As String
        Public Property Description() As String
            Get
                Return _Desc
            End Get
            Set(ByVal value As String)
                _Desc = value
            End Set
        End Property
    End Structure

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _db = EJData.DataHelpers.GetNewDbContext
        ItemBindingSource.DataSource = _db.Items.ToList
    End Sub

    Private Sub ItemAdd_Click(sender As Object, e As EventArgs) Handles ItemAdd.Click
        ItemBindingSource1.Add(New Item With {.Description = DescBox.Text, .ID = CInt(IDBox.Text)})
    End Sub

    Private Sub PotentialItemAdd_Click(sender As Object, e As EventArgs) Handles PotentialItemAdd.Click
        PotentialItems.Add(New Item With {.Description = DescBox.Text, .ID = CInt(IDBox.Text)})
        IDBox.Text = CInt(IDBox.Text) + 1
    End Sub

    Private Sub BindBtn_Click(sender As Object, e As EventArgs) Handles BindBtn.Click
        ItemBindingSource1.DataSource = Items
    End Sub
End Class
