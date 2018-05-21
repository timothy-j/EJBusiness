<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EJGeneralBomTable
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GeneralBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New EJControls.NestedSourceGrid()
        Me.MC000Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MCS000Column = New EJControls.EJTextBoxColumn()
        Me.StockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrawingTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuppliersDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowNotesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SecondOpColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCheckedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DefaultContextStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EqualsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoesNotEqualToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeginsWithToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoesNotBeginWithToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContainsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoesNotContainToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EndsWithToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoesNotEndWithToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NumberFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EqualsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoesNotEqualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContainsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoesNotContainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LessThanOrEqualToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GreaterThanOrEqualToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeginsWithToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoesNotBeginWithToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EndsWithToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoesNotEndWithToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.GeneralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DefaultContextStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'GeneralBindingSource
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MC000Column, Me.MCS000Column, Me.StockColumn, Me.ModelColumn, Me.ItemColumn, Me.DrawingTypeColumn, Me.DescriptionColumn, Me.SupplierColumn, Me.SuppliersDescriptionColumn, Me.QtyColumn, Me.StatusColumn, Me.RowNotesColumn, Me.UnitColumn, Me.SecondOpColumn, Me.DateCheckedColumn, Me.PartColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowTemplate.Height = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(704, 422)
        Me.DataGridView1.TabIndex = 0
        '
        'MC000Column
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "0.##"
        Me.MC000Column.DefaultCellStyle = DataGridViewCellStyle17
        Me.MC000Column.HeaderText = "000"
        Me.MC000Column.Name = "MC000Column"
        Me.MC000Column.Width = 35
        '
        'MCS000Column
        '
        Me.MCS000Column.EntityProperty = Nothing
        Me.MCS000Column.HeaderText = "S000"
        Me.MCS000Column.Name = "MCS000Column"
        Me.MCS000Column.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MCS000Column.Width = 60
        '
        'StockColumn
        '
        Me.StockColumn.DataPropertyName = "Part.Stock"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "0.##"
        Me.StockColumn.DefaultCellStyle = DataGridViewCellStyle18
        Me.StockColumn.HeaderText = "Stock"
        Me.StockColumn.Name = "StockColumn"
        Me.StockColumn.Width = 45
        '
        'ModelColumn
        '
        Me.ModelColumn.DataPropertyName = "Model"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ModelColumn.DefaultCellStyle = DataGridViewCellStyle19
        Me.ModelColumn.HeaderText = "Model"
        Me.ModelColumn.Name = "ModelColumn"
        Me.ModelColumn.Width = 35
        '
        'ItemColumn
        '
        Me.ItemColumn.DataPropertyName = "Item1"
        Me.ItemColumn.HeaderText = "Item"
        Me.ItemColumn.Name = "ItemColumn"
        Me.ItemColumn.Width = 55
        '
        'DrawingTypeColumn
        '
        Me.DrawingTypeColumn.DataPropertyName = "Part.DrawingType"
        Me.DrawingTypeColumn.HeaderText = "Dwg"
        Me.DrawingTypeColumn.Name = "DrawingTypeColumn"
        Me.DrawingTypeColumn.Width = 40
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Width = 250
        '
        'SupplierColumn
        '
        Me.SupplierColumn.DataPropertyName = "Part.Supplier"
        Me.SupplierColumn.HeaderText = "Supplier"
        Me.SupplierColumn.Name = "SupplierColumn"
        Me.SupplierColumn.Width = 55
        '
        'SuppliersDescriptionColumn
        '
        Me.SuppliersDescriptionColumn.DataPropertyName = "Part.SuppliersDescription"
        Me.SuppliersDescriptionColumn.HeaderText = "Suppliers Description"
        Me.SuppliersDescriptionColumn.Name = "SuppliersDescriptionColumn"
        Me.SuppliersDescriptionColumn.Width = 250
        '
        'QtyColumn
        '
        Me.QtyColumn.DataPropertyName = "Qty"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "0.##"
        Me.QtyColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.QtyColumn.HeaderText = "Qty"
        Me.QtyColumn.Name = "QtyColumn"
        Me.QtyColumn.Width = 40
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Part.Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Width = 40
        '
        'RowNotesColumn
        '
        Me.RowNotesColumn.DataPropertyName = "Part.ProductionNotes"
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RowNotesColumn.DefaultCellStyle = DataGridViewCellStyle21
        Me.RowNotesColumn.HeaderText = "Notes"
        Me.RowNotesColumn.Name = "RowNotesColumn"
        Me.RowNotesColumn.Width = 150
        '
        'UnitColumn
        '
        Me.UnitColumn.DataPropertyName = "Part.Unit"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.Format = "C2"
        Me.UnitColumn.DefaultCellStyle = DataGridViewCellStyle22
        Me.UnitColumn.HeaderText = "Unit"
        Me.UnitColumn.Name = "UnitColumn"
        Me.UnitColumn.Width = 70
        '
        'SecondOpColumn
        '
        Me.SecondOpColumn.DataPropertyName = "Part.SecondOperation"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.Format = "C2"
        DataGridViewCellStyle23.NullValue = Nothing
        Me.SecondOpColumn.DefaultCellStyle = DataGridViewCellStyle23
        Me.SecondOpColumn.HeaderText = "2nd Op"
        Me.SecondOpColumn.Name = "SecondOpColumn"
        Me.SecondOpColumn.Width = 60
        '
        'DateCheckedColumn
        '
        Me.DateCheckedColumn.DataPropertyName = "Part.DateChecked"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.Format = "d"
        DataGridViewCellStyle24.NullValue = Nothing
        Me.DateCheckedColumn.DefaultCellStyle = DataGridViewCellStyle24
        Me.DateCheckedColumn.HeaderText = "DateChecked"
        Me.DateCheckedColumn.Name = "DateCheckedColumn"
        Me.DateCheckedColumn.Width = 80
        '
        'PartColumn
        '
        Me.PartColumn.DataPropertyName = "Part.PartNo"
        Me.PartColumn.HeaderText = "Part"
        Me.PartColumn.Name = "PartColumn"
        Me.PartColumn.ReadOnly = True
        Me.PartColumn.Width = 70
        '
        'DefaultContextStrip
        '
        Me.DefaultContextStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator1, Me.UndoToolStripMenuItem, Me.ToolStripSeparator2, Me.TextFiltersToolStripMenuItem, Me.NumberFiltersToolStripMenuItem, Me.EqualsToolStripMenuItem, Me.DoesNotEqualToolStripMenuItem, Me.ContainsToolStripMenuItem, Me.DoesNotContainToolStripMenuItem, Me.LessThanOrEqualToToolStripMenuItem, Me.GreaterThanOrEqualToToolStripMenuItem, Me.BeginsWithToolStripMenuItem, Me.DoesNotBeginWithToolStripMenuItem, Me.EndsWithToolStripMenuItem, Me.DoesNotEndWithToolStripMenuItem})
        Me.DefaultContextStrip.Name = "DefaultContextStrip"
        Me.DefaultContextStrip.Size = New System.Drawing.Size(200, 368)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(196, 6)
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(196, 6)
        '
        'TextFiltersToolStripMenuItem
        '
        Me.TextFiltersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EqualsToolStripMenuItem1, Me.DoesNotEqualToolStripMenuItem1, Me.BeginsWithToolStripMenuItem1, Me.DoesNotBeginWithToolStripMenuItem1, Me.ContainsToolStripMenuItem1, Me.DoesNotContainToolStripMenuItem1, Me.EndsWithToolStripMenuItem1, Me.DoesNotEndWithToolStripMenuItem1})
        Me.TextFiltersToolStripMenuItem.Name = "TextFiltersToolStripMenuItem"
        Me.TextFiltersToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.TextFiltersToolStripMenuItem.Text = "Text Filters"
        '
        'EqualsToolStripMenuItem1
        '
        Me.EqualsToolStripMenuItem1.Name = "EqualsToolStripMenuItem1"
        Me.EqualsToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
        Me.EqualsToolStripMenuItem1.Text = "Equals.."
        '
        'DoesNotEqualToolStripMenuItem1
        '
        Me.DoesNotEqualToolStripMenuItem1.Name = "DoesNotEqualToolStripMenuItem1"
        Me.DoesNotEqualToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
        Me.DoesNotEqualToolStripMenuItem1.Text = "Does not equal.."
        '
        'BeginsWithToolStripMenuItem1
        '
        Me.BeginsWithToolStripMenuItem1.Name = "BeginsWithToolStripMenuItem1"
        Me.BeginsWithToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
        Me.BeginsWithToolStripMenuItem1.Text = "Begins with.."
        '
        'DoesNotBeginWithToolStripMenuItem1
        '
        Me.DoesNotBeginWithToolStripMenuItem1.Name = "DoesNotBeginWithToolStripMenuItem1"
        Me.DoesNotBeginWithToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
        Me.DoesNotBeginWithToolStripMenuItem1.Text = "Does not begin with.."
        '
        'ContainsToolStripMenuItem1
        '
        Me.ContainsToolStripMenuItem1.Name = "ContainsToolStripMenuItem1"
        Me.ContainsToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
        Me.ContainsToolStripMenuItem1.Text = "Contains.."
        '
        'DoesNotContainToolStripMenuItem1
        '
        Me.DoesNotContainToolStripMenuItem1.Name = "DoesNotContainToolStripMenuItem1"
        Me.DoesNotContainToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
        Me.DoesNotContainToolStripMenuItem1.Text = "Does not contain.."
        '
        'EndsWithToolStripMenuItem1
        '
        Me.EndsWithToolStripMenuItem1.Name = "EndsWithToolStripMenuItem1"
        Me.EndsWithToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
        Me.EndsWithToolStripMenuItem1.Text = "Ends with.."
        '
        'DoesNotEndWithToolStripMenuItem1
        '
        Me.DoesNotEndWithToolStripMenuItem1.Name = "DoesNotEndWithToolStripMenuItem1"
        Me.DoesNotEndWithToolStripMenuItem1.Size = New System.Drawing.Size(186, 22)
        Me.DoesNotEndWithToolStripMenuItem1.Text = "Does not end with.."
        '
        'NumberFiltersToolStripMenuItem
        '
        Me.NumberFiltersToolStripMenuItem.Name = "NumberFiltersToolStripMenuItem"
        Me.NumberFiltersToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.NumberFiltersToolStripMenuItem.Text = "Number Filters"
        '
        'EqualsToolStripMenuItem
        '
        Me.EqualsToolStripMenuItem.Name = "EqualsToolStripMenuItem"
        Me.EqualsToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.EqualsToolStripMenuItem.Text = "Equals"
        '
        'DoesNotEqualToolStripMenuItem
        '
        Me.DoesNotEqualToolStripMenuItem.Name = "DoesNotEqualToolStripMenuItem"
        Me.DoesNotEqualToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DoesNotEqualToolStripMenuItem.Text = "Does not equal"
        '
        'ContainsToolStripMenuItem
        '
        Me.ContainsToolStripMenuItem.Name = "ContainsToolStripMenuItem"
        Me.ContainsToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ContainsToolStripMenuItem.Text = "Contains"
        '
        'DoesNotContainToolStripMenuItem
        '
        Me.DoesNotContainToolStripMenuItem.Name = "DoesNotContainToolStripMenuItem"
        Me.DoesNotContainToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DoesNotContainToolStripMenuItem.Text = "Does not contain"
        '
        'LessThanOrEqualToToolStripMenuItem
        '
        Me.LessThanOrEqualToToolStripMenuItem.Name = "LessThanOrEqualToToolStripMenuItem"
        Me.LessThanOrEqualToToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.LessThanOrEqualToToolStripMenuItem.Text = "Less than or equal to"
        '
        'GreaterThanOrEqualToToolStripMenuItem
        '
        Me.GreaterThanOrEqualToToolStripMenuItem.Name = "GreaterThanOrEqualToToolStripMenuItem"
        Me.GreaterThanOrEqualToToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.GreaterThanOrEqualToToolStripMenuItem.Text = "Greater than or equal to"
        '
        'BeginsWithToolStripMenuItem
        '
        Me.BeginsWithToolStripMenuItem.Name = "BeginsWithToolStripMenuItem"
        Me.BeginsWithToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.BeginsWithToolStripMenuItem.Text = "Begins with"
        '
        'DoesNotBeginWithToolStripMenuItem
        '
        Me.DoesNotBeginWithToolStripMenuItem.Name = "DoesNotBeginWithToolStripMenuItem"
        Me.DoesNotBeginWithToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DoesNotBeginWithToolStripMenuItem.Text = "Does not begin with"
        '
        'EndsWithToolStripMenuItem
        '
        Me.EndsWithToolStripMenuItem.Name = "EndsWithToolStripMenuItem"
        Me.EndsWithToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.EndsWithToolStripMenuItem.Text = "Ends with"
        '
        'DoesNotEndWithToolStripMenuItem
        '
        Me.DoesNotEndWithToolStripMenuItem.Name = "DoesNotEndWithToolStripMenuItem"
        Me.DoesNotEndWithToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DoesNotEndWithToolStripMenuItem.Text = "Does not end with"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(278, 243)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 1
        '
        'EJGeneralBomTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "EJGeneralBomTable"
        Me.Size = New System.Drawing.Size(704, 422)
        CType(Me.GeneralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DefaultContextStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GeneralBindingSource As BindingSource
    Friend WithEvents DataGridView1 As EJControls.NestedSourceGrid
    Friend WithEvents MC000Column As DataGridViewTextBoxColumn
    Friend WithEvents MCS000Column As EJControls.EJTextBoxColumn
    Friend WithEvents StockColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModelColumn As DataGridViewTextBoxColumn
    Friend WithEvents ItemColumn As DataGridViewTextBoxColumn
    Friend WithEvents DrawingTypeColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As DataGridViewTextBoxColumn
    Friend WithEvents SupplierColumn As DataGridViewTextBoxColumn
    Friend WithEvents SuppliersDescriptionColumn As DataGridViewTextBoxColumn
    Friend WithEvents QtyColumn As DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As DataGridViewTextBoxColumn
    Friend WithEvents RowNotesColumn As DataGridViewTextBoxColumn
    Friend WithEvents UnitColumn As DataGridViewTextBoxColumn
    Friend WithEvents SecondOpColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateCheckedColumn As DataGridViewTextBoxColumn
    Friend WithEvents PartColumn As DataGridViewTextBoxColumn
    Friend WithEvents DefaultContextStrip As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TextFiltersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EqualsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DoesNotEqualToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BeginsWithToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DoesNotBeginWithToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ContainsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DoesNotContainToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EndsWithToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DoesNotEndWithToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NumberFiltersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EqualsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoesNotEqualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContainsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoesNotContainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LessThanOrEqualToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GreaterThanOrEqualToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeginsWithToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoesNotBeginWithToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EndsWithToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoesNotEndWithToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox1 As TextBox
End Class
