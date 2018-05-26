Public Class MultiColComboBox
    Private _ColumnCount As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Me.

    End Sub

    ''' <summary>
    ''' Number of columns in the dropdown list
    ''' </summary>
    ''' <returns></returns>
    Public Property ColumnCount() As Integer
        Get
            Return _ColumnCount
        End Get
        Set(ByVal value As Integer)
            _ColumnCount = value
        End Set
    End Property

    Protected Overrides Sub OnDropDown(e As EventArgs)
        'MyBase.OnDropDown(e)
        'MsgBox("working?")
        With DataGridViewPanel
            Me.Parent.Controls.Add(DataGridViewPanel)
            'Me.DropDowncontrol
            'put in initialisation
            'work out datasource and datamember
            .Top = Me.Top + Me.Height
            .Left = Me.Left
            .Height = .RowTemplate.Height * Me.MaxDropDownItems
            .Show()
        End With
    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)

    End Sub

    'Private Sub MultiColComboBox_DropDown(sender As Object, e As EventArgs) Handles Me.DropDown
    '    MsgBox("working?")
    '    With DataGridViewPanel
    '        'put in initialisation
    '        'work out datasource and datamember
    '        .Top = Me.Height
    '        .Height = .RowTemplate.Height * Me.MaxDropDownItems
    '        .Show()
    '    End With
    'End Sub

    Private Sub MultiColComboBox_DropDownClosed(sender As Object, e As EventArgs) Handles Me.DropDownClosed
        DataGridViewPanel.Hide()
    End Sub

    Private Sub DataGridViewPanel_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewPanel.SelectionChanged
        'TO DO: change value and display to correct value
    End Sub
End Class
