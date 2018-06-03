Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class MultiColumnComboBox

#Region "Attributes"

    Private Const m_btnWidth As Integer = 16
    'Private DropDownGrid As New EJDropDownDGV
    Private m_DisplayMembers As New List(Of String)
    Private m_host As ToolStripControlHost ' = New ToolStripControlHost(DropDownGrid)
    Private _TextMemberIndex As Integer
    Private m_settingText As Boolean
    Private m_previousText As String = ""
    Private _ColumnWidths As New List(Of Integer)

#End Region

#Region "Design mode identification"

    ''' <summary>
    ''' Checks whether the form is currently being used in the VS form designer
    ''' </summary>
    ''' <returns></returns>
    Function IsInDesignMode() As Boolean
        Return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio")
    End Function

#End Region

#Region "Properties"

    ' TODO: expose textbox properties and hide unnecessary UserControl ones

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
            'TextListBindingSource.DataSource = Value
        End Set
    End Property

    <Category("Data"),
        Description("The property of the data source to use for the controls undelying value.")>
    Property ValueMember As String

    <Category("Data"),
        Description("The properties of the data source to display in the drop down list."),
        EditorAttribute("System.Windows.Forms.Design.StringCollectionEditor", GetType(System.Drawing.Design.UITypeEditor))>'"System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(System.Drawing.Design.UITypeEditor))>
    Property DisplayMembers As List(Of String)
        Get
            Return m_DisplayMembers
        End Get
        Set
            m_DisplayMembers.Clear()
            DropDownGrid.Columns.Clear()
            If Value Is Nothing Then Exit Property
            For Each str As String In Value
                m_DisplayMembers.Add(str)
                'Dim col As New DataGridViewTextBoxColumn
                'col.DataPropertyName = str
                'DropDownGrid.Columns.Add(col)
            Next
            CreateDropDownColumns()
        End Set
    End Property

    <Category("Data"),
        Description("The widths of the columns in the drop down list.")>
    Property ColumnWidths As List(Of Integer)
        Get
            Return _ColumnWidths
        End Get
        Set
            _ColumnWidths = Value
        End Set
    End Property

    <Category("Data"),
        Description("The zero-based index of the Display Member to display and search in the textbox."),
        DefaultValue(0)>
    Property TextMemberIndex As Integer
        Get
            Return _TextMemberIndex
        End Get
        Set
            If Value >= DisplayMembers.Count Then
                _TextMemberIndex = 0
                Exit Property
            Else
                _TextMemberIndex = Value
            End If

            If DropDownBindingSource.Count = 0 Then Exit Property

            If IsInDesignMode() Then Exit Property
            ' Fill autocomplete list
            Dim strList As New AutoCompleteStringCollection
            For Each item In DropDownBindingSource.List
                strList.Add(item.GetType.GetProperty(DisplayMembers(Value)).GetValue(item).ToString)
            Next
            TextBox1.AutoCompleteCustomSource = strList
        End Set
    End Property

    <Category("Behavior"),
        Description("The maximum number of rows shown in the drop down list."),
        DefaultValue(16)>
    Property ListMaxRows As Integer = 16

#End Region

#Region "Initialisation"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DoubleBuffered = True
        MyBase.BorderStyle = Windows.Forms.BorderStyle.None
        Height = TextBox1.Height + TextBox1.Top + Margin.Bottom
        TextBox1.Width = Me.Width - 6 - m_btnWidth ' 6 = two margins

        DropDownGrid.AutoGenerateColumns = False

        ' For some reason a new BindingContext is needed to correctly 
        ' display DGV in dropdown
        'DropDownGrid.BindingContext = New BindingContext
    End Sub

    Private Sub MultiColumnComboBox_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' This guarantees that columns get created (creation only happens
        ' when bindingsource is full, so may not have happened during initialization)
        CreateDropDownColumns() 'TextMemberIndex = TextMemberIndex

        ' HACK: Fill autocomplete list
        Dim strList As New AutoCompleteStringCollection
        For Each item In DropDownBindingSource.List
            strList.Add(item.GetType.GetProperty(DisplayMembers(TextMemberIndex)).GetValue(item).ToString)
        Next
        TextBox1.AutoCompleteCustomSource = strList
    End Sub

#End Region

#Region "Internal methods"

    Private Sub CreateDropDownColumns()
        If m_DisplayMembers.Count = ColumnWidths.Count Then
            DropDownGrid.Columns.Clear()
            For i As Integer = 0 To m_DisplayMembers.Count - 1
                Dim col As New DataGridViewTextBoxColumn
                col.DataPropertyName = DisplayMembers(i)
                col.Width = ColumnWidths(i)
                DropDownGrid.Columns.Add(col)
            Next
        End If
    End Sub

#End Region

#Region "Overridden methods"

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        TextBox1.Width = Me.Width - 6 - m_btnWidth ' 6 = two margins
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
        Dim btnRect As New Rectangle With {.X = e.ClipRectangle.Width - m_btnWidth, .Y = 0, .Height = e.ClipRectangle.Height, .Width = m_btnWidth}
        Dim txtRect As New Rectangle With {.X = 0, .Y = 0, .Height = e.ClipRectangle.Height, .Width = e.ClipRectangle.Width - m_btnWidth}
        'btnRect.Width = 18
        If Me.ContainsFocus Then
            ' TODO: never hit
            ComboBoxRenderer.DrawTextBox(e.Graphics, e.ClipRectangle, VisualStyles.ComboBoxState.Hot)
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, btnRect, VisualStyles.ComboBoxState.Hot)
        Else
            ComboBoxRenderer.DrawTextBox(e.Graphics, e.ClipRectangle, VisualStyles.ComboBoxState.Normal)
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, btnRect, VisualStyles.ComboBoxState.Normal)
        End If
    End Sub

#End Region

#Region "Event handlers"

    Private Sub MultiColumnComboBox_Click(sender As Object, e As EventArgs) Handles Me.Click
        'MsgBox("clicked")
        ' TODO: show dropdown
        ' HACK:
        'DropDownGrid.DataSource = DropDownBindingSource
        'DropDownGrid.Width = DropDownGrid.GetRowDisplayRectangle(0, False).Width
        Dim width As Integer = SystemInformation.VerticalScrollBarWidth
        For Each i As Integer In ColumnWidths
            width += i
        Next
        With DropDownGrid
            '.BindingContext = m_dropDownStrip.BindingContext
            '.DataSource = DropDownBindingSource
            'DropDownBindingSource.Position = 50
            .Height = .RowTemplate.Height * ListMaxRows
            .Width = width
        End With

        If m_host Is Nothing Then m_host = New ToolStripControlHost(DropDownGrid)
        m_host.AutoSize = False
        m_host.Height = DropDownGrid.Height
        m_host.Width = width

        With DropDownToolStrip
            .Items.Add(m_host)
            'DropDownGrid.BindingContext = New BindingContext
            .Show(PointToScreen(New Point With {.X = 0, .Y = Height}))
        End With
        'DropDownGrid.DataSource = DropDownBindingSource
        'DropDownGrid.FirstDisplayedScrollingRowIndex = 50
        DropDownGrid.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If m_settingText Then Exit Sub
        Dim startText As String = TextBox1.Text
        If m_previousText.Length >= startText.Length Then
            m_previousText = startText
            Exit Sub
        End If
        m_previousText = startText
        Dim suggest As String = (From str In TextBox1.AutoCompleteCustomSource
                                 Where str.ToString.ToLower.StartsWith(startText.ToLower)).FirstOrDefault
        If suggest = "" Then Exit Sub
        m_settingText = True
        TextBox1.Text = suggest
        TextBox1.Select(startText.Length, suggest.Length - startText.Length)
        'DropDownBindingSource.Position = DropDownBindingSource.Find(DisplayMembers(TextMemberIndex), suggest)
        m_settingText = False
    End Sub

    Private Sub DropDownBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles DropDownBindingSource.CurrentItemChanged
        If DropDownBindingSource.Position < 0 Then Exit Sub
        ' HACK: this breaks when coming back off end of list
        TextBox1.Text = DropDownBindingSource.Current().GetType.GetProperty(DisplayMembers(TextMemberIndex)).GetValue(DropDownBindingSource.Current())
        m_previousText = TextBox1.Text
    End Sub

#End Region

End Class
