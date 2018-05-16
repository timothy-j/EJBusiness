<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl1
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
        Me.IDBox = New System.Windows.Forms.TextBox()
        Me.DescBox = New System.Windows.Forms.TextBox()
        Me.PotentialItemAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ItemAdd = New System.Windows.Forms.Button()
        Me.BindBtn = New System.Windows.Forms.Button()
        Me.UserControl1_ItemDataGridView = New System.Windows.Forms.DataGridView()
        Me.ItemBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New EJControls.EJMultiComboBoxColumn()
        Me.Part = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.UserControl1_ItemDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDBox
        '
        Me.IDBox.Location = New System.Drawing.Point(101, 63)
        Me.IDBox.Name = "IDBox"
        Me.IDBox.Size = New System.Drawing.Size(100, 20)
        Me.IDBox.TabIndex = 1
        '
        'DescBox
        '
        Me.DescBox.Location = New System.Drawing.Point(101, 90)
        Me.DescBox.Name = "DescBox"
        Me.DescBox.Size = New System.Drawing.Size(100, 20)
        Me.DescBox.TabIndex = 2
        '
        'PotentialItemAdd
        '
        Me.PotentialItemAdd.Location = New System.Drawing.Point(273, 63)
        Me.PotentialItemAdd.Name = "PotentialItemAdd"
        Me.PotentialItemAdd.Size = New System.Drawing.Size(75, 23)
        Me.PotentialItemAdd.TabIndex = 3
        Me.PotentialItemAdd.Text = "Potential"
        Me.PotentialItemAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Desc"
        '
        'ItemAdd
        '
        Me.ItemAdd.Location = New System.Drawing.Point(273, 92)
        Me.ItemAdd.Name = "ItemAdd"
        Me.ItemAdd.Size = New System.Drawing.Size(75, 23)
        Me.ItemAdd.TabIndex = 6
        Me.ItemAdd.Text = "Item"
        Me.ItemAdd.UseVisualStyleBackColor = True
        '
        'BindBtn
        '
        Me.BindBtn.Location = New System.Drawing.Point(273, 165)
        Me.BindBtn.Name = "BindBtn"
        Me.BindBtn.Size = New System.Drawing.Size(75, 23)
        Me.BindBtn.TabIndex = 7
        Me.BindBtn.Text = "Bind"
        Me.BindBtn.UseVisualStyleBackColor = True
        '
        'UserControl1_ItemDataGridView
        '
        Me.UserControl1_ItemDataGridView.AutoGenerateColumns = False
        Me.UserControl1_ItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UserControl1_ItemDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Part, Me.DataGridViewTextBoxColumn2})
        Me.UserControl1_ItemDataGridView.DataSource = Me.ItemBindingSource
        Me.UserControl1_ItemDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.UserControl1_ItemDataGridView.Location = New System.Drawing.Point(101, 257)
        Me.UserControl1_ItemDataGridView.Name = "UserControl1_ItemDataGridView"
        Me.UserControl1_ItemDataGridView.Size = New System.Drawing.Size(406, 165)
        Me.UserControl1_ItemDataGridView.TabIndex = 8
        '
        'ItemBindingSource1
        '
        Me.ItemBindingSource1.DataSource = GetType(EJControlLibrary.UserControl1.Item)
        '
        'ItemBindingSource
        '
        Me.ItemBindingSource.DataSource = GetType(EJData.Item)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Part
        '
        Me.Part.DataPropertyName = "Part.PartNo"
        Me.Part.HeaderText = "Part"
        Me.Part.Name = "Part"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UserControl1_ItemDataGridView)
        Me.Controls.Add(Me.BindBtn)
        Me.Controls.Add(Me.ItemAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PotentialItemAdd)
        Me.Controls.Add(Me.DescBox)
        Me.Controls.Add(Me.IDBox)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(800, 520)
        CType(Me.UserControl1_ItemDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IDBox As TextBox
    Friend WithEvents DescBox As TextBox
    Friend WithEvents PotentialItemAdd As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ItemAdd As Button
    Friend WithEvents BindBtn As Button
    Friend WithEvents UserControl1_ItemDataGridView As DataGridView
    Friend WithEvents ItemBindingSource1 As BindingSource
    Friend WithEvents DataGridViewTextBoxColumn1 As EJControls.EJMultiComboBoxColumn
    Friend WithEvents Part As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents ItemBindingSource As BindingSource
End Class
