<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QuoteForm2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CustomerIDLabel1 As System.Windows.Forms.Label
        Dim CarriageCostLabel As System.Windows.Forms.Label
        Dim CarriageTextLabel As System.Windows.Forms.Label
        Dim CurrencyLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DiscountFractionLabel As System.Windows.Forms.Label
        Dim GBPEquivLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim NotesLabel As System.Windows.Forms.Label
        Dim RefLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QuoteForm2))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.QuoteBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.QuoteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.QuoteBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.QuoteDetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RowNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QDItemID = New EJControls.EJComboBoxColumn()
        Me.ItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QDDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuoteDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TestCellContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuoteItemDetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.QIDItemID = New EJControls.EJComboBoxColumn()
        Me.QIDDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentID = New EJControls.EJComboBoxColumn()
        Me.QuoteItemDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QuoteItemSummaryDataGridView = New System.Windows.Forms.DataGridView()
        Me.ItemID = New EJControls.EJComboBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetailIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuoteDetailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SummaryItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QuoteItemDetail1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerIDComboBox = New System.Windows.Forms.ComboBox()
        Me.CustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CarriageCostTextBox = New System.Windows.Forms.TextBox()
        Me.CarriageTextTextBox = New System.Windows.Forms.TextBox()
        Me.CurrencyTextBox = New System.Windows.Forms.TextBox()
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.DiscountFractionTextBox = New System.Windows.Forms.TextBox()
        Me.GBPEquivTextBox = New System.Windows.Forms.TextBox()
        Me.IDTextBox = New System.Windows.Forms.TextBox()
        Me.NotesTextBox = New System.Windows.Forms.TextBox()
        Me.RefTextBox = New System.Windows.Forms.TextBox()
        CustomerIDLabel1 = New System.Windows.Forms.Label()
        CarriageCostLabel = New System.Windows.Forms.Label()
        CarriageTextLabel = New System.Windows.Forms.Label()
        CurrencyLabel = New System.Windows.Forms.Label()
        DateLabel = New System.Windows.Forms.Label()
        DiscountFractionLabel = New System.Windows.Forms.Label()
        GBPEquivLabel = New System.Windows.Forms.Label()
        IDLabel = New System.Windows.Forms.Label()
        NotesLabel = New System.Windows.Forms.Label()
        RefLabel = New System.Windows.Forms.Label()
        CType(Me.QuoteBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QuoteBindingNavigator.SuspendLayout()
        CType(Me.QuoteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuoteDetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuoteDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TestCellContextMenu.SuspendLayout()
        CType(Me.QuoteItemDetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuoteItemDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuoteItemSummaryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomerIDLabel1
        '
        CustomerIDLabel1.AutoSize = True
        CustomerIDLabel1.Location = New System.Drawing.Point(17, 138)
        CustomerIDLabel1.Name = "CustomerIDLabel1"
        CustomerIDLabel1.Size = New System.Drawing.Size(68, 13)
        CustomerIDLabel1.TabIndex = 24
        CustomerIDLabel1.Text = "Customer ID:"
        '
        'CarriageCostLabel
        '
        CarriageCostLabel.AutoSize = True
        CarriageCostLabel.Location = New System.Drawing.Point(17, 61)
        CarriageCostLabel.Name = "CarriageCostLabel"
        CarriageCostLabel.Size = New System.Drawing.Size(73, 13)
        CarriageCostLabel.TabIndex = 26
        CarriageCostLabel.Text = "Carriage Cost:"
        '
        'CarriageTextLabel
        '
        CarriageTextLabel.AutoSize = True
        CarriageTextLabel.Location = New System.Drawing.Point(17, 87)
        CarriageTextLabel.Name = "CarriageTextLabel"
        CarriageTextLabel.Size = New System.Drawing.Size(73, 13)
        CarriageTextLabel.TabIndex = 28
        CarriageTextLabel.Text = "Carriage Text:"
        '
        'CurrencyLabel
        '
        CurrencyLabel.AutoSize = True
        CurrencyLabel.Location = New System.Drawing.Point(17, 113)
        CurrencyLabel.Name = "CurrencyLabel"
        CurrencyLabel.Size = New System.Drawing.Size(52, 13)
        CurrencyLabel.TabIndex = 30
        CurrencyLabel.Text = "Currency:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Location = New System.Drawing.Point(17, 167)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(33, 13)
        DateLabel.TabIndex = 34
        DateLabel.Text = "Date:"
        '
        'DiscountFractionLabel
        '
        DiscountFractionLabel.AutoSize = True
        DiscountFractionLabel.Location = New System.Drawing.Point(17, 192)
        DiscountFractionLabel.Name = "DiscountFractionLabel"
        DiscountFractionLabel.Size = New System.Drawing.Size(93, 13)
        DiscountFractionLabel.TabIndex = 36
        DiscountFractionLabel.Text = "Discount Fraction:"
        '
        'GBPEquivLabel
        '
        GBPEquivLabel.AutoSize = True
        GBPEquivLabel.Location = New System.Drawing.Point(17, 218)
        GBPEquivLabel.Name = "GBPEquivLabel"
        GBPEquivLabel.Size = New System.Drawing.Size(59, 13)
        GBPEquivLabel.TabIndex = 38
        GBPEquivLabel.Text = "GBPEquiv:"
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Location = New System.Drawing.Point(17, 35)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(53, 13)
        IDLabel.TabIndex = 40
        IDLabel.Text = "Quote ID:"
        '
        'NotesLabel
        '
        NotesLabel.AutoSize = True
        NotesLabel.Location = New System.Drawing.Point(17, 270)
        NotesLabel.Name = "NotesLabel"
        NotesLabel.Size = New System.Drawing.Size(38, 13)
        NotesLabel.TabIndex = 42
        NotesLabel.Text = "Notes:"
        '
        'RefLabel
        '
        RefLabel.AutoSize = True
        RefLabel.Location = New System.Drawing.Point(17, 296)
        RefLabel.Name = "RefLabel"
        RefLabel.Size = New System.Drawing.Size(27, 13)
        RefLabel.TabIndex = 44
        RefLabel.Text = "Ref:"
        '
        'QuoteBindingNavigator
        '
        Me.QuoteBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.QuoteBindingNavigator.BindingSource = Me.QuoteBindingSource
        Me.QuoteBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.QuoteBindingNavigator.DeleteItem = Nothing
        Me.QuoteBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.QuoteBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.QuoteBindingNavigatorSaveItem})
        Me.QuoteBindingNavigator.Location = New System.Drawing.Point(0, 569)
        Me.QuoteBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.QuoteBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.QuoteBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.QuoteBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.QuoteBindingNavigator.Name = "QuoteBindingNavigator"
        Me.QuoteBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.QuoteBindingNavigator.Size = New System.Drawing.Size(1203, 25)
        Me.QuoteBindingNavigator.TabIndex = 0
        Me.QuoteBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'QuoteBindingSource
        '
        Me.QuoteBindingSource.DataSource = GetType(EJData.Quote)
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'QuoteBindingNavigatorSaveItem
        '
        Me.QuoteBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.QuoteBindingNavigatorSaveItem.Enabled = False
        Me.QuoteBindingNavigatorSaveItem.Image = CType(resources.GetObject("QuoteBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.QuoteBindingNavigatorSaveItem.Name = "QuoteBindingNavigatorSaveItem"
        Me.QuoteBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.QuoteBindingNavigatorSaveItem.Text = "Save Data"
        '
        'QuoteDetailsDataGridView
        '
        Me.QuoteDetailsDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QuoteDetailsDataGridView.AutoGenerateColumns = False
        Me.QuoteDetailsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.QuoteDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.QuoteDetailsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowNo, Me.QDItemID, Me.QDDescription, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.QuoteDetailsDataGridView.DataSource = Me.QuoteDetailsBindingSource
        Me.QuoteDetailsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.QuoteDetailsDataGridView.Location = New System.Drawing.Point(352, 27)
        Me.QuoteDetailsDataGridView.Name = "QuoteDetailsDataGridView"
        Me.QuoteDetailsDataGridView.RowHeadersWidth = 25
        Me.QuoteDetailsDataGridView.Size = New System.Drawing.Size(839, 286)
        Me.QuoteDetailsDataGridView.TabIndex = 21
        '
        'RowNo
        '
        Me.RowNo.DataPropertyName = "RowNo"
        Me.RowNo.HeaderText = "RowNo"
        Me.RowNo.Name = "RowNo"
        Me.RowNo.ReadOnly = True
        Me.RowNo.Width = 40
        '
        'QDItemID
        '
        Me.QDItemID.DataPropertyName = "ItemID"
        Me.QDItemID.DataSource = Me.ItemBindingSource
        Me.QDItemID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.QDItemID.HeaderText = "ItemID"
        Me.QDItemID.Name = "QDItemID"
        Me.QDItemID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QDItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QDItemID.Width = 75
        '
        'QDDescription
        '
        Me.QDDescription.DataPropertyName = "Description"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QDDescription.DefaultCellStyle = DataGridViewCellStyle1
        Me.QDDescription.HeaderText = "Description"
        Me.QDDescription.Name = "QDDescription"
        Me.QDDescription.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Unit"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 75
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Price"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Price"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 75
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Quantity"
        DataGridViewCellStyle2.Format = "0.##"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn7.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 75
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "LeadTime"
        Me.DataGridViewTextBoxColumn8.HeaderText = "LeadTime"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'QuoteDetailsBindingSource
        '
        Me.QuoteDetailsBindingSource.DataMember = "QuoteDetails"
        Me.QuoteDetailsBindingSource.DataSource = Me.QuoteBindingSource
        Me.QuoteDetailsBindingSource.Sort = "RowNo"
        '
        'TestCellContextMenu
        '
        Me.TestCellContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.MoveUpToolStripMenuItem, Me.MoveDownToolStripMenuItem})
        Me.TestCellContextMenu.Name = "Cut"
        Me.TestCellContextMenu.Size = New System.Drawing.Size(138, 114)
        Me.TestCellContextMenu.Text = "&Cut"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'MoveUpToolStripMenuItem
        '
        Me.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem"
        Me.MoveUpToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.MoveUpToolStripMenuItem.Text = "Move up"
        '
        'MoveDownToolStripMenuItem
        '
        Me.MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem"
        Me.MoveDownToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.MoveDownToolStripMenuItem.Text = "Move down"
        '
        'QuoteItemDetailsDataGridView
        '
        Me.QuoteItemDetailsDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.QuoteItemDetailsDataGridView.AutoGenerateColumns = False
        Me.QuoteItemDetailsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.QuoteItemDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.QuoteItemDetailsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QIDItemID, Me.QIDDescription, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn1, Me.ParentID})
        Me.QuoteItemDetailsDataGridView.DataSource = Me.QuoteItemDetailsBindingSource
        Me.QuoteItemDetailsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.QuoteItemDetailsDataGridView.Location = New System.Drawing.Point(17, 330)
        Me.QuoteItemDetailsDataGridView.Name = "QuoteItemDetailsDataGridView"
        Me.QuoteItemDetailsDataGridView.RowHeadersWidth = 25
        Me.QuoteItemDetailsDataGridView.Size = New System.Drawing.Size(562, 236)
        Me.QuoteItemDetailsDataGridView.TabIndex = 22
        '
        'QIDItemID
        '
        Me.QIDItemID.DataPropertyName = "ItemID"
        Me.QIDItemID.DataSource = Me.ItemBindingSource
        Me.QIDItemID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.QIDItemID.HeaderText = "ItemID"
        Me.QIDItemID.Name = "QIDItemID"
        Me.QIDItemID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QIDItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QIDItemID.Width = 75
        '
        'QIDDescription
        '
        Me.QIDDescription.DataPropertyName = "Description"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QIDDescription.DefaultCellStyle = DataGridViewCellStyle3
        Me.QIDDescription.HeaderText = "Description"
        Me.QIDDescription.Name = "QIDDescription"
        Me.QIDDescription.Width = 200
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 75
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Status"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'ParentID
        '
        Me.ParentID.DataPropertyName = "ParentID"
        Me.ParentID.DataSource = Me.ItemBindingSource
        Me.ParentID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.ParentID.HeaderText = "ParentID"
        Me.ParentID.Name = "ParentID"
        Me.ParentID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ParentID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'QuoteItemDetailsBindingSource
        '
        Me.QuoteItemDetailsBindingSource.DataMember = "QuoteItemDetails"
        Me.QuoteItemDetailsBindingSource.DataSource = Me.QuoteDetailsBindingSource
        '
        'QuoteItemSummaryDataGridView
        '
        Me.QuoteItemSummaryDataGridView.AllowUserToAddRows = False
        Me.QuoteItemSummaryDataGridView.AllowUserToDeleteRows = False
        Me.QuoteItemSummaryDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QuoteItemSummaryDataGridView.AutoGenerateColumns = False
        Me.QuoteItemSummaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.QuoteItemSummaryDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemID, Me.Description, Me.Quantity, Me.Status, Me.IDDataGridViewTextBoxColumn, Me.DetailIDDataGridViewTextBoxColumn, Me.ItemIDDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.QuantityDataGridViewTextBoxColumn, Me.ParentIDDataGridViewTextBoxColumn, Me.ItemDataGridViewTextBoxColumn, Me.QuoteDetailDataGridViewTextBoxColumn})
        Me.QuoteItemSummaryDataGridView.DataSource = Me.SummaryItemsBindingSource
        Me.QuoteItemSummaryDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.QuoteItemSummaryDataGridView.Location = New System.Drawing.Point(590, 330)
        Me.QuoteItemSummaryDataGridView.Name = "QuoteItemSummaryDataGridView"
        Me.QuoteItemSummaryDataGridView.ReadOnly = True
        Me.QuoteItemSummaryDataGridView.RowHeadersWidth = 25
        Me.QuoteItemSummaryDataGridView.Size = New System.Drawing.Size(601, 236)
        Me.QuoteItemSummaryDataGridView.TabIndex = 23
        '
        'ItemID
        '
        Me.ItemID.DataPropertyName = "ItemID"
        Me.ItemID.DataSource = Me.ItemBindingSource
        Me.ItemID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.ItemID.HeaderText = "ItemID"
        Me.ItemID.Name = "ItemID"
        Me.ItemID.ReadOnly = True
        Me.ItemID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ItemID.Width = 75
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 200
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 75
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 75
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DetailIDDataGridViewTextBoxColumn
        '
        Me.DetailIDDataGridViewTextBoxColumn.DataPropertyName = "DetailID"
        Me.DetailIDDataGridViewTextBoxColumn.HeaderText = "DetailID"
        Me.DetailIDDataGridViewTextBoxColumn.Name = "DetailIDDataGridViewTextBoxColumn"
        Me.DetailIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ItemIDDataGridViewTextBoxColumn
        '
        Me.ItemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID"
        Me.ItemIDDataGridViewTextBoxColumn.HeaderText = "ItemID"
        Me.ItemIDDataGridViewTextBoxColumn.Name = "ItemIDDataGridViewTextBoxColumn"
        Me.ItemIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
        Me.QuantityDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ParentIDDataGridViewTextBoxColumn
        '
        Me.ParentIDDataGridViewTextBoxColumn.DataPropertyName = "ParentID"
        Me.ParentIDDataGridViewTextBoxColumn.HeaderText = "ParentID"
        Me.ParentIDDataGridViewTextBoxColumn.Name = "ParentIDDataGridViewTextBoxColumn"
        Me.ParentIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ItemDataGridViewTextBoxColumn
        '
        Me.ItemDataGridViewTextBoxColumn.DataPropertyName = "Item"
        Me.ItemDataGridViewTextBoxColumn.HeaderText = "Item"
        Me.ItemDataGridViewTextBoxColumn.Name = "ItemDataGridViewTextBoxColumn"
        Me.ItemDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuoteDetailDataGridViewTextBoxColumn
        '
        Me.QuoteDetailDataGridViewTextBoxColumn.DataPropertyName = "QuoteDetail"
        Me.QuoteDetailDataGridViewTextBoxColumn.HeaderText = "QuoteDetail"
        Me.QuoteDetailDataGridViewTextBoxColumn.Name = "QuoteDetailDataGridViewTextBoxColumn"
        Me.QuoteDetailDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SummaryItemsBindingSource
        '
        Me.SummaryItemsBindingSource.DataMember = "QuoteItemDetails"
        Me.SummaryItemsBindingSource.DataSource = Me.QuoteDetailsBindingSource
        '
        'QuoteItemDetail1DataGridViewTextBoxColumn
        '
        Me.QuoteItemDetail1DataGridViewTextBoxColumn.DataPropertyName = "QuoteItemDetail1"
        Me.QuoteItemDetail1DataGridViewTextBoxColumn.HeaderText = "QuoteItemDetail1"
        Me.QuoteItemDetail1DataGridViewTextBoxColumn.Name = "QuoteItemDetail1DataGridViewTextBoxColumn"
        Me.QuoteItemDetail1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'CustomerIDComboBox
        '
        Me.CustomerIDComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CustomerIDComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CustomerIDComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.QuoteBindingSource, "CustomerID", True))
        Me.CustomerIDComboBox.DataSource = Me.CustomerBindingSource
        Me.CustomerIDComboBox.DisplayMember = "Company"
        Me.CustomerIDComboBox.Location = New System.Drawing.Point(116, 135)
        Me.CustomerIDComboBox.MaxDropDownItems = 16
        Me.CustomerIDComboBox.Name = "CustomerIDComboBox"
        Me.CustomerIDComboBox.Size = New System.Drawing.Size(200, 21)
        Me.CustomerIDComboBox.TabIndex = 25
        Me.CustomerIDComboBox.ValueMember = "ID"
        '
        'CustomerBindingSource
        '
        Me.CustomerBindingSource.DataSource = GetType(EJData.Customer)
        '
        'CarriageCostTextBox
        '
        Me.CarriageCostTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QuoteBindingSource, "CarriageCost", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.CarriageCostTextBox.Location = New System.Drawing.Point(116, 58)
        Me.CarriageCostTextBox.Name = "CarriageCostTextBox"
        Me.CarriageCostTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CarriageCostTextBox.TabIndex = 27
        Me.CarriageCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CarriageTextTextBox
        '
        Me.CarriageTextTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QuoteBindingSource, "CarriageText", True))
        Me.CarriageTextTextBox.Location = New System.Drawing.Point(116, 84)
        Me.CarriageTextTextBox.Name = "CarriageTextTextBox"
        Me.CarriageTextTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CarriageTextTextBox.TabIndex = 29
        '
        'CurrencyTextBox
        '
        Me.CurrencyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QuoteBindingSource, "Currency", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.CurrencyTextBox.Location = New System.Drawing.Point(116, 110)
        Me.CurrencyTextBox.Name = "CurrencyTextBox"
        Me.CurrencyTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CurrencyTextBox.TabIndex = 31
        Me.CurrencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.QuoteBindingSource, "Date", True))
        Me.DateDateTimePicker.Location = New System.Drawing.Point(116, 163)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DateDateTimePicker.TabIndex = 35
        '
        'DiscountFractionTextBox
        '
        Me.DiscountFractionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QuoteBindingSource, "DiscountFraction", True))
        Me.DiscountFractionTextBox.Location = New System.Drawing.Point(116, 189)
        Me.DiscountFractionTextBox.Name = "DiscountFractionTextBox"
        Me.DiscountFractionTextBox.Size = New System.Drawing.Size(200, 20)
        Me.DiscountFractionTextBox.TabIndex = 37
        Me.DiscountFractionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBPEquivTextBox
        '
        Me.GBPEquivTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QuoteBindingSource, "GBPEquiv", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.GBPEquivTextBox.Location = New System.Drawing.Point(116, 215)
        Me.GBPEquivTextBox.Name = "GBPEquivTextBox"
        Me.GBPEquivTextBox.Size = New System.Drawing.Size(200, 20)
        Me.GBPEquivTextBox.TabIndex = 39
        Me.GBPEquivTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QuoteBindingSource, "ID", True))
        Me.IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDTextBox.Location = New System.Drawing.Point(116, 27)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.Size = New System.Drawing.Size(200, 26)
        Me.IDTextBox.TabIndex = 41
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NotesTextBox
        '
        Me.NotesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QuoteBindingSource, "Notes", True))
        Me.NotesTextBox.Location = New System.Drawing.Point(116, 267)
        Me.NotesTextBox.Name = "NotesTextBox"
        Me.NotesTextBox.Size = New System.Drawing.Size(200, 20)
        Me.NotesTextBox.TabIndex = 43
        '
        'RefTextBox
        '
        Me.RefTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QuoteBindingSource, "Ref", True))
        Me.RefTextBox.Location = New System.Drawing.Point(116, 293)
        Me.RefTextBox.Name = "RefTextBox"
        Me.RefTextBox.Size = New System.Drawing.Size(200, 20)
        Me.RefTextBox.TabIndex = 45
        Me.RefTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'QuoteForm2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 594)
        Me.Controls.Add(CarriageCostLabel)
        Me.Controls.Add(Me.CarriageCostTextBox)
        Me.Controls.Add(CarriageTextLabel)
        Me.Controls.Add(Me.CarriageTextTextBox)
        Me.Controls.Add(CurrencyLabel)
        Me.Controls.Add(Me.CurrencyTextBox)
        Me.Controls.Add(DateLabel)
        Me.Controls.Add(Me.DateDateTimePicker)
        Me.Controls.Add(DiscountFractionLabel)
        Me.Controls.Add(Me.DiscountFractionTextBox)
        Me.Controls.Add(GBPEquivLabel)
        Me.Controls.Add(Me.GBPEquivTextBox)
        Me.Controls.Add(IDLabel)
        Me.Controls.Add(Me.IDTextBox)
        Me.Controls.Add(NotesLabel)
        Me.Controls.Add(Me.NotesTextBox)
        Me.Controls.Add(RefLabel)
        Me.Controls.Add(Me.RefTextBox)
        Me.Controls.Add(CustomerIDLabel1)
        Me.Controls.Add(Me.CustomerIDComboBox)
        Me.Controls.Add(Me.QuoteItemSummaryDataGridView)
        Me.Controls.Add(Me.QuoteItemDetailsDataGridView)
        Me.Controls.Add(Me.QuoteDetailsDataGridView)
        Me.Controls.Add(Me.QuoteBindingNavigator)
        Me.Name = "QuoteForm2"
        Me.Text = "QuoteForm"
        CType(Me.QuoteBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QuoteBindingNavigator.ResumeLayout(False)
        Me.QuoteBindingNavigator.PerformLayout()
        CType(Me.QuoteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuoteDetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuoteDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TestCellContextMenu.ResumeLayout(False)
        CType(Me.QuoteItemDetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuoteItemDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuoteItemSummaryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents QuoteBindingSource As BindingSource
    Friend WithEvents QuoteBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents QuoteBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents QuoteDetailsBindingSource As BindingSource
    Friend WithEvents QuoteDetailsDataGridView As DataGridView
    Friend WithEvents QuoteItemDetailsBindingSource As BindingSource
    Friend WithEvents QuoteItemDetailsDataGridView As DataGridView
    Friend WithEvents QuoteItemSummaryDataGridView As DataGridView
    Friend WithEvents SummaryItemsBindingSource As BindingSource
    Friend WithEvents ItemBindingSource As BindingSource
    Friend WithEvents CustomerIDComboBox As ComboBox
    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents CarriageCostTextBox As TextBox
    Friend WithEvents CarriageTextTextBox As TextBox
    Friend WithEvents CurrencyTextBox As TextBox
    Friend WithEvents DateDateTimePicker As DateTimePicker
    Friend WithEvents DiscountFractionTextBox As TextBox
    Friend WithEvents GBPEquivTextBox As TextBox
    Friend WithEvents IDTextBox As TextBox
    Friend WithEvents NotesTextBox As TextBox
    Friend WithEvents RefTextBox As TextBox
    Friend WithEvents ItemID As EJControls.EJComboBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents IDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DetailIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ItemIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ParentIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ItemDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuoteDetailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuoteItemDetail1DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TestCellContextMenu As ContextMenuStrip
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RowNo As DataGridViewTextBoxColumn
    Friend WithEvents QDItemID As EJControls.EJComboBoxColumn
    Friend WithEvents QDDescription As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents QIDItemID As EJControls.EJComboBoxColumn
    Friend WithEvents QIDDescription As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents ParentID As EJControls.EJComboBoxColumn
End Class
