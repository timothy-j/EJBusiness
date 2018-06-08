<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestContainer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestContainer))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PartBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MultiColumnComboBox1 = New MultiColumnComboBoxControls.MultiColumnComboBox()
        CType(Me.PartBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(15, 68)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(173, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(15, 156)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(173, 22)
        Me.TextBox1.TabIndex = 3
        '
        'PartBindingSource
        '
        Me.PartBindingSource.DataSource = GetType(EJData.Part)
        '
        'MultiColumnComboBox1
        '
        Me.MultiColumnComboBox1.BackColor = System.Drawing.SystemColors.Window
        Me.MultiColumnComboBox1.ColumnWidths = CType(resources.GetObject("MultiColumnComboBox1.ColumnWidths"), System.Collections.Generic.List(Of Integer))
        Me.MultiColumnComboBox1.DataSource = Me.PartBindingSource
        Me.MultiColumnComboBox1.DisplayMembers = CType(resources.GetObject("MultiColumnComboBox1.DisplayMembers"), System.Collections.Generic.List(Of String))
        Me.MultiColumnComboBox1.Location = New System.Drawing.Point(15, 113)
        Me.MultiColumnComboBox1.Name = "MultiColumnComboBox1"
        Me.MultiColumnComboBox1.Size = New System.Drawing.Size(173, 19)
        Me.MultiColumnComboBox1.TabIndex = 2
        Me.MultiColumnComboBox1.Value = Nothing
        Me.MultiColumnComboBox1.ValueMember = ""
        '
        'TestContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MultiColumnComboBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "TestContainer"
        Me.Size = New System.Drawing.Size(602, 289)
        CType(Me.PartBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MultiColumnComboBox1 As MultiColumnComboBox
    Friend WithEvents PartBindingSource As BindingSource
End Class
