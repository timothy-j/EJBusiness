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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GeneralBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New EJControls.MultiSourceGrid()
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
        CType(Me.GeneralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowTemplate.Height = 20
        Me.DataGridView1.Size = New System.Drawing.Size(704, 422)
        Me.DataGridView1.TabIndex = 0
        '
        'MC000Column
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "0.##"
        Me.MC000Column.DefaultCellStyle = DataGridViewCellStyle9
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
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "0.##"
        Me.StockColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.StockColumn.HeaderText = "Stock"
        Me.StockColumn.Name = "StockColumn"
        Me.StockColumn.Width = 45
        '
        'ModelColumn
        '
        Me.ModelColumn.DataPropertyName = "Model"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ModelColumn.DefaultCellStyle = DataGridViewCellStyle11
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
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "0.##"
        Me.QtyColumn.DefaultCellStyle = DataGridViewCellStyle12
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
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RowNotesColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.RowNotesColumn.HeaderText = "Notes"
        Me.RowNotesColumn.Name = "RowNotesColumn"
        Me.RowNotesColumn.Width = 150
        '
        'UnitColumn
        '
        Me.UnitColumn.DataPropertyName = "Part.Unit"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "C2"
        Me.UnitColumn.DefaultCellStyle = DataGridViewCellStyle14
        Me.UnitColumn.HeaderText = "Unit"
        Me.UnitColumn.Name = "UnitColumn"
        Me.UnitColumn.Width = 70
        '
        'SecondOpColumn
        '
        Me.SecondOpColumn.DataPropertyName = "Part.SecondOperation"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "C2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.SecondOpColumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.SecondOpColumn.HeaderText = "2nd Op"
        Me.SecondOpColumn.Name = "SecondOpColumn"
        Me.SecondOpColumn.Width = 60
        '
        'DateCheckedColumn
        '
        Me.DateCheckedColumn.DataPropertyName = "Part.DateChecked"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "d"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.DateCheckedColumn.DefaultCellStyle = DataGridViewCellStyle16
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
        'EJGeneralBomTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "EJGeneralBomTable"
        Me.Size = New System.Drawing.Size(704, 422)
        CType(Me.GeneralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GeneralBindingSource As BindingSource
    Friend WithEvents DataGridView1 As EJControls.MultiSourceGrid
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
End Class
