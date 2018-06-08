Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Linq.Dynamic

Public Class MultiColumnComboBox

#Region "Attributes"

    Private Const m_btnWidth As Integer = 16        ' HACK: should be property with default of 16?
    Private m_dataTable As New DataTable            ' Copy of the datasource columns specified in DisplayMembers and ValueMember
    Private m_DisplayMembers As New List(Of String) '
    Private m_host As ToolStripControlHost          ' = New ToolStripControlHost(DropDownGrid)
    Private _TextMemberIndex As Integer
    Private m_settingText As Boolean
    Private m_previousText As String = ""
    Private m_itemSelectedByUser As Boolean         ' Change in list selection caused by user selection, so dropdown should be closed
    Private _ColumnWidths As New List(Of Integer)
    Private _Value As Object

#End Region

#Region "Types"

    ''' <summary>
    ''' Controls how the drop down list acts as text is entered
    ''' </summary>
    Enum ListFilterBehaviors
        NoFilter                ' List will not be filtered. First match will be selected
        FilterListStartsWith    ' List filtered by "text begins with input text"
        FilterListContains      ' List filtered by "text contains input text" first "begins with" match will be selected
    End Enum
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

    Private Property DataTable As DataTable
        Get
            Return m_dataTable
        End Get
        Set
            m_dataTable = Value
        End Set
    End Property

    <Category("Data"),
        Description("Data source for list items."),
        RefreshProperties(RefreshProperties.Repaint),
        AttributeProvider(GetType(IListSource))>
    Property DataSource As Object
        Get
            Return InputBindingSource.DataSource
        End Get
        Set
            InputBindingSource.DataSource = Value
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

            If InputBindingSource.Count = 0 Then Exit Property

            If IsInDesignMode() Then Exit Property
        End Set
    End Property

    <Category("Behavior"),
        Description("The maximum number of rows shown in the drop down list."),
        DefaultValue(16)>
    Property ListMaxRows As Integer = 16

    Property Value As Object
        Get
            Return _Value
        End Get
        Set
            ' TODO: validate and synchronise bindingsource
            _Value = Value
        End Set
    End Property

    <Category("Behavior"),
        Description("Whether 'no value' is acceptable when limited to list or using Value Member"),
        DefaultValue(True)>
    Property AllowEmpty As Boolean = True

    <Category("Behavior"),
        Description("Limit to list values only (required when using Value Member)"), ' TODO: implement limit to list
        DefaultValue(True)>
    Property LimitToList As Boolean = True

    <Category("Behavior"),
        Description("Controls how the list is filtered during text entry"),
        DefaultValue(ListFilterBehaviors.FilterListStartsWith)>
    Property ListFilterBehaviour As ListFilterBehaviors = ListFilterBehaviors.FilterListStartsWith ' TODO: implement filter functions

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

        'DropDownBindingSource.DataSource = DataTable

        ' For some reason a new BindingContext is needed to correctly 
        ' display DGV in dropdown
        'DropDownGrid.BindingContext = New BindingContext
    End Sub

    Private Sub MultiColumnComboBox_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' This guarantees that columns get created (creation only happens
        ' when bindingsource is full, so may not have happened during initialization)
        CreateDropDownColumns()

        If Not IsInDesignMode() Then FillDataTable()
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

    Private Sub FillDataTable()
        DataTable.Clear()
        DataTable.Columns.Clear()

        ' If no display has been specified, exit
        If DisplayMembers.Count < 1 Then Exit Sub

        ' Create table stucture:

        ' If applicable, create value column (without name)
        If Not ValueMember = "" Then DataTable.Columns.Add(New DataColumn("", InputBindingSource.Item(0).GetType.GetProperty(ValueMember).PropertyType))

        ' Create all display columns
        For Each prop As String In DisplayMembers
            ' TODO: handle identical column names?
            ' TODO: convert all display columns to string?
            DataTable.Columns.Add(New DataColumn(prop, InputBindingSource.Item(0).GetType.GetProperty(prop).PropertyType))
        Next

        ' Fill with data
        If AllowEmpty Then ' add empty row
            Dim row As DataRow = m_dataTable.NewRow()
            ' HACK: this may only work if type is String?
            'row.Item(DisplayMembers(TextMemberIndex)) = ""
            DataTable.Rows.Add(row)
        End If

        For Each item In InputBindingSource
            Dim row As DataRow = m_dataTable.NewRow()

            ' If applicable, insert value
            If Not ValueMember = "" Then row.Item(0) = item.GetType.GetProperty(ValueMember).GetValue(item)

            ' Insert display values
            For Each prop As String In DisplayMembers
                row.Item(prop) = item.GetType.GetProperty(prop).GetValue(item)
            Next

            DataTable.Rows.Add(row)
        Next

        'Dim bindingList = (From data In DataTable
        '                   Order By data.Item(DisplayMembers(TextMemberIndex))).AsEnumerable

        DropDownBindingSource.DataSource = DataTable 'bindingList

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
        If TextBox1.Focused Then
            ' TODO: never hit
            ComboBoxRenderer.DrawTextBox(e.Graphics, e.ClipRectangle, VisualStyles.ComboBoxState.Pressed)
            'ComboBoxRenderer.DrawDropDownButton(e.Graphics, btnRect, VisualStyles.ComboBoxState.Hot)
        Else
            ComboBoxRenderer.DrawTextBox(e.Graphics, e.ClipRectangle, VisualStyles.ComboBoxState.Normal)
            'ComboBoxRenderer.DrawDropDownButton(e.Graphics, btnRect, VisualStyles.ComboBoxState.Normal)
        End If
        If DropDownToolStrip.Visible = True Then
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, btnRect, VisualStyles.ComboBoxState.Pressed)
        Else
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, btnRect, VisualStyles.ComboBoxState.Normal)
        End If
    End Sub

    'Public Overrides Function ValidateChildren() As Boolean
    '    Return MyBase.ValidateChildren()
    'End Function

#End Region

#Region "Event handlers"

    Private Sub MultiColumnComboBox_Click(sender As Object, e As EventArgs) Handles Me.Click
        ' Set height and widths of DropDownList and grid
        Dim width As Integer = SystemInformation.VerticalScrollBarWidth
        For Each i As Integer In ColumnWidths
            width += i
        Next

        With DropDownGrid
            ' Set height to show ListMaxRows
            ' TODO: reduce height if list is shorter than ListMaxRows?
            .Height = .RowTemplate.Height * ListMaxRows
            .Width = width
        End With

        If m_host Is Nothing Then m_host = New ToolStripControlHost(DropDownGrid)
        m_host.AutoSize = False
        m_host.Height = DropDownGrid.Height
        m_host.Width = width

        ' Show the DropDown
        With DropDownToolStrip
            .Items.Add(m_host)
            .Show(PointToScreen(New Point With {.X = 0, .Y = Height}))
        End With

        ' Scroll currently selected row to top of list
        If DropDownGrid.Rows.Count > 0 Then DropDownGrid.FirstDisplayedScrollingRowIndex = DropDownGrid.CurrentRow.Index
        DropDownGrid.Focus() ' Needed for Return key to close list if row isn't changed
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If m_settingText Then Exit Sub ' Text has been changed by internal code

        ' Don't make suggestion if text has got shorter (i.e. been deleted)
        Dim startText As String = TextBox1.Text
        If m_previousText.Length >= startText.Length Then
            m_previousText = startText
            Exit Sub
        End If

        m_previousText = startText

        Dim suggestion As DataRow

        suggestion = (From row In DataTable
                      Where row(DisplayMembers(TextMemberIndex)).ToString.StartsWith(startText)).FirstOrDefault


        ' TODO: move this into options below
        If suggestion Is Nothing Then
            DropDownBindingSource.Filter = ""
            Exit Sub
        End If

        m_settingText = True ' This sub will effectively not be called while m_settingText = True

        ' HACK: TODO: sort out what happens when text isn't found
        Select Case ListFilterBehaviour
            Case ListFilterBehaviors.FilterListStartsWith
                ' HACK: breaks if ', ", * or % are in string?
                DropDownBindingSource.Filter = DisplayMembers(TextMemberIndex) & " LIKE '" & startText & "*'"
                ' Selected row will already be first row 
            Case ListFilterBehaviors.FilterListContains
                ' HACK: breaks if ', ", * or % are in string?
                DropDownBindingSource.Filter = DisplayMembers(TextMemberIndex) & " LIKE '*" & startText & "*'"
                ' HACK: this will break if there is no suggestion
                DropDownBindingSource.Position = DropDownBindingSource.IndexOf(suggestion)
            Case Else
                DropDownBindingSource.Filter = ""
                DropDownBindingSource.Position = DropDownBindingSource.IndexOf(suggestion)
        End Select
        'DropDownBindingSource.Position = suggest.Index
        TextBox1.Text = suggestion.Item(DisplayMembers(TextMemberIndex)).ToString
        TextBox1.Select(startText.Length, TextBox1.Text.Length - startText.Length)
        m_settingText = False
    End Sub

    Private Sub DropDownBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles DropDownBindingSource.CurrentItemChanged
        If DataTable.Rows.Count < 1 Or DropDownBindingSource.Position < 0 Or m_settingText Then Exit Sub

        ' HACK: this breaks when coming back off end of list
        TextBox1.Text = CType(DropDownBindingSource.Current(), DataRowView).Item(DisplayMembers(TextMemberIndex)).ToString
        m_previousText = TextBox1.Text
        'TextBox1.Focus()
        If m_itemSelectedByUser Then DropDownToolStrip.Hide()
        m_itemSelectedByUser = False
    End Sub

    Private Sub DropDownGrid_MouseDown(sender As Object, e As MouseEventArgs) Handles DropDownGrid.MouseDown
        ' HACK: uses change in binding list to cause list to update and close, so doesn't work when clicking the current item
        m_itemSelectedByUser = True
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If DropDownToolStrip.Visible Then Exit Sub
        If e.KeyCode = Keys.Down Then MultiColumnComboBox_Click(sender, e)
    End Sub

    Private Sub DropDownGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles DropDownGrid.KeyDown
        ' TODO: handle return and tab
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Return Then
            DropDownToolStrip.Hide()
            e.Handled = True
        End If
    End Sub

    Private Sub DropDownToolStrip_VisibleChanged(sender As Object, e As EventArgs) Handles DropDownToolStrip.VisibleChanged
        Invalidate() ' Make sure new button state is drawn
    End Sub

    Private Sub MultiColumnComboBox_ChangeFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus, TextBox1.LostFocus
        Invalidate() ' Make sure new button state is drawn
    End Sub

#End Region

End Class
