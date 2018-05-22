<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DGTest
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
        Me.TableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PartsTableControl1 = New EJParts.PartsTableControl()
        CType(Me.TableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PartsTableControl1
        '
        Me.PartsTableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PartsTableControl1.Location = New System.Drawing.Point(0, 0)
        Me.PartsTableControl1.Name = "PartsTableControl1"
        Me.PartsTableControl1.Size = New System.Drawing.Size(800, 450)
        Me.PartsTableControl1.TabIndex = 0
        '
        'DGTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PartsTableControl1)
        Me.Name = "DGTest"
        Me.Text = "DGTest"
        CType(Me.TableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableBindingSource As BindingSource
    Friend WithEvents PartsTableControl1 As EJParts.PartsTableControl
End Class
