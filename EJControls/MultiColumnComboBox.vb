Public Class MultiColumnComboBox
    Private _DataSource As Object

    ReadOnly Property Columns As DataGridViewColumnCollection
        Get
            Return DataGridViewPanel.Columns
        End Get
    End Property

    Public Property DataSource As Object
        Get
            Return MyBase.DataSource
        End Get
        Set
            MyBase.DataSource = Value
            DataGridViewPanel.DataSource = Value
        End Set
    End Property

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        ' Other stuff here

        Me.DropDownControl = DataGridViewPanel
        DataGridViewPanel.AutoGenerateColumns = False

    End Sub

    Private Sub MultiColumnComboBox_DropDown(sender As Object, e As EventArgs) Handles Me.DropDown

    End Sub

    Private Sub DataGridViewPanel_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewPanel.RowsAdded

    End Sub

    Private Sub DataGridViewPanel_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridViewPanel.ColumnAdded

    End Sub
End Class
