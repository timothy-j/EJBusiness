<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemsView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsTableControl1 = New EJItems.ItemsTableControl()
        CType(Me.ItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ItemBindingSource
        '
        Me.ItemBindingSource.DataSource = GetType(EJData.Item)
        '
        'ItemsTableControl1
        '
        Me.ItemsTableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsTableControl1.Location = New System.Drawing.Point(0, 0)
        Me.ItemsTableControl1.Name = "ItemsTableControl1"
        Me.ItemsTableControl1.PartIDFilter = Nothing
        Me.ItemsTableControl1.Size = New System.Drawing.Size(800, 450)
        Me.ItemsTableControl1.TabIndex = 0
        '
        'ItemsView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ItemsTableControl1)
        Me.Name = "ItemsView"
        Me.Text = "ItemsView"
        CType(Me.ItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItemBindingSource As BindingSource
    Friend WithEvents ItemsTableControl1 As ItemsTableControl
End Class
