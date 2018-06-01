Imports System.ComponentModel

'<ComplexBindingProperties("DataSource", "ValueMember")>
Public Class MultiColumnComboBox
    'Private _BorderStyle As Border3DStyle
    Private Const _btnWidth As Integer = 16

    ' TODO: expose textbox properties and hide unnecessary UserControl ones

    '    <Category("Data"),
    'Description("Data source for list items.")>
    <Category("Data"),
        Description("Data source for list items."),
        RefreshProperties(RefreshProperties.Repaint),
        AttributeProvider(GetType(IListSource))>
    Property DataSource As Object
        Get
            Return DropDownBindingSource.DataSource
        End Get
        Set
            DropDownBindingSource.DataSource = Value
        End Set
    End Property

    <Category("Data"),
        Description("The property of the data source to use for the controls undelying value.")>
    Property ValueMember As String

    <Category("Data"),
        Description("The properties of the data source to display in the drop down list.")>
    Property DisplayMembers As List(Of String)

    <Category("Data"),
        Description("The index of the Display Member to display and search in the textbox.")>
    Property TextMemberIndex As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DoubleBuffered = True
        MyBase.BorderStyle = Windows.Forms.BorderStyle.None
        Height = TextBox1.Height + TextBox1.Top + Margin.Bottom
        TextBox1.Width = Me.Width - 6 - _btnWidth ' 6 = two margins
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        TextBox1.Width = Me.Width - 6 - _btnWidth ' 6 = two margins
        Height = TextBox1.Height + TextBox1.Top + Margin.Bottom
        Invalidate()
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        Dim w = TextBox1.Width
        TextBox1.Font = Me.Font
        TextBox1.Width = w
        OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim btnRect As New Rectangle With {.X = e.ClipRectangle.Width - _btnWidth, .Y = 0, .Height = e.ClipRectangle.Height, .Width = _btnWidth}
        Dim txtRect As New Rectangle With {.X = 0, .Y = 0, .Height = e.ClipRectangle.Height, .Width = e.ClipRectangle.Width - _btnWidth}
        'btnRect.Width = 18
        ComboBoxRenderer.DrawTextBox(e.Graphics, e.ClipRectangle, VisualStyles.ComboBoxState.Normal)
        ComboBoxRenderer.DrawDropDownButton(e.Graphics, btnRect, VisualStyles.ComboBoxState.Normal)
    End Sub

    Private Sub MultiColumnComboBox_Click(sender As Object, e As EventArgs) Handles Me.Click
        MsgBox("clicked")
        ' TODO: show dropdown
    End Sub
End Class
