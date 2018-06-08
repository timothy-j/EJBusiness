<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MultiColumnComboBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.InputBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DropDownToolStrip = New System.Windows.Forms.ToolStripDropDown()
        Me.DropDownGrid = New MultiColumnComboBoxControls.EJDropDownDGV(Me.components)
        Me.DropDownBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.InputBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropDownGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropDownBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(3, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(152, 13)
        Me.TextBox1.TabIndex = 1
        '
        'DropDownToolStrip
        '
        Me.DropDownToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.DropDownToolStrip.Name = "DropDownToolStrip"
        Me.DropDownToolStrip.Padding = New System.Windows.Forms.Padding(0)
        Me.DropDownToolStrip.Size = New System.Drawing.Size(0, 0)
        '
        'DropDownGrid
        '
        Me.DropDownGrid.AllowUserToResizeRows = False
        Me.DropDownGrid.AutoGenerateColumns = False
        Me.DropDownGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DropDownGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DropDownGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DropDownGrid.ColumnHeadersVisible = False
        Me.DropDownGrid.DataSource = Me.DropDownBindingSource
        Me.DropDownGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DropDownGrid.Location = New System.Drawing.Point(32, 109)
        Me.DropDownGrid.Name = "DropDownGrid"
        Me.DropDownGrid.RowHeadersVisible = False
        Me.DropDownGrid.RowTemplate.Height = 18
        Me.DropDownGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DropDownGrid.Size = New System.Drawing.Size(208, 41)
        Me.DropDownGrid.TabIndex = 2
        '
        'DropDownBindingSource
        '
        '
        'MultiColumnComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.DropDownGrid)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "MultiColumnComboBox"
        Me.Size = New System.Drawing.Size(276, 170)
        CType(Me.InputBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropDownGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropDownBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents InputBindingSource As BindingSource
    Friend WithEvents DropDownToolStrip As ToolStripDropDown
    Friend WithEvents DropDownGrid As EJDropDownDGV
    Friend WithEvents DropDownBindingSource As BindingSource
End Class
