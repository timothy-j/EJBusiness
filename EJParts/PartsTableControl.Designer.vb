<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartsTableControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PartBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsTableControl2 = New EJItems.ItemsTableControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrawingType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuppliersDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductionNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateChecked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PartBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ItemsTableControl2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Size = New System.Drawing.Size(696, 459)
        Me.SplitContainer1.SplitterDistance = 250
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Stock, Me.PartNo, Me.DrawingType, Me.DescriptionDataGridViewTextBoxColumn, Me.Supplier, Me.SuppliersDescription, Me.ProductionNotes, Me.Status, Me.Unit, Me.DateChecked, Me.OpType})
        Me.DataGridView1.DataSource = Me.PartBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(692, 246)
        Me.DataGridView1.TabIndex = 3
        '
        'PartBindingSource
        '
        Me.PartBindingSource.DataSource = GetType(EJData.Part)
        '
        'ItemsTableControl2
        '
        Me.ItemsTableControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItemsTableControl2.DataBindings.Add(New System.Windows.Forms.Binding("PartIDFilter", Me.PartBindingSource, "ID", True, System.Windows.Forms.DataSourceUpdateMode.Never))
        Me.ItemsTableControl2.Location = New System.Drawing.Point(0, 22)
        Me.ItemsTableControl2.Name = "ItemsTableControl2"
        Me.ItemsTableControl2.PartIDFilter = Nothing
        Me.ItemsTableControl2.Size = New System.Drawing.Size(692, 187)
        Me.ItemsTableControl2.SplitterDistance = 100
        Me.ItemsTableControl2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Associated Items"
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "Stock"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "0.##"
        Me.Stock.DefaultCellStyle = DataGridViewCellStyle1
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 40
        '
        'PartNo
        '
        Me.PartNo.DataPropertyName = "PartNo"
        Me.PartNo.HeaderText = "PartNo"
        Me.PartNo.Name = "PartNo"
        Me.PartNo.Width = 60
        '
        'DrawingType
        '
        Me.DrawingType.DataPropertyName = "DrawingType"
        Me.DrawingType.HeaderText = "DrawingType"
        Me.DrawingType.Name = "DrawingType"
        Me.DrawingType.Width = 30
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.MinimumWidth = 100
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        '
        'Supplier
        '
        Me.Supplier.DataPropertyName = "Supplier"
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.Width = 50
        '
        'SuppliersDescription
        '
        Me.SuppliersDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SuppliersDescription.DataPropertyName = "SuppliersDescription"
        Me.SuppliersDescription.HeaderText = "SuppliersDescription"
        Me.SuppliersDescription.MinimumWidth = 100
        Me.SuppliersDescription.Name = "SuppliersDescription"
        '
        'ProductionNotes
        '
        Me.ProductionNotes.DataPropertyName = "ProductionNotes"
        Me.ProductionNotes.HeaderText = "ProductionNotes"
        Me.ProductionNotes.MinimumWidth = 50
        Me.ProductionNotes.Name = "ProductionNotes"
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.Width = 30
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "Unit"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Unit.DefaultCellStyle = DataGridViewCellStyle2
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.Width = 60
        '
        'DateChecked
        '
        Me.DateChecked.DataPropertyName = "DateChecked"
        Me.DateChecked.HeaderText = "DateChecked"
        Me.DateChecked.Name = "DateChecked"
        Me.DateChecked.Width = 70
        '
        'OpType
        '
        Me.OpType.DataPropertyName = "OpType"
        Me.OpType.HeaderText = "OpType"
        Me.OpType.Name = "OpType"
        Me.OpType.Width = 40
        '
        'PartsTableControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "PartsTableControl"
        Me.Size = New System.Drawing.Size(696, 459)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PartBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents PartBindingSource As BindingSource
    Friend WithEvents Item1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ItemsTableControl2 As EJItems.ItemsTableControl
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents PartNo As DataGridViewTextBoxColumn
    Friend WithEvents DrawingType As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents SuppliersDescription As DataGridViewTextBoxColumn
    Friend WithEvents ProductionNotes As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Unit As DataGridViewTextBoxColumn
    Friend WithEvents DateChecked As DataGridViewTextBoxColumn
    Friend WithEvents OpType As DataGridViewTextBoxColumn
End Class
