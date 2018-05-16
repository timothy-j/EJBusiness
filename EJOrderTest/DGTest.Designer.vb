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
        Me.TableGridView = New System.Windows.Forms.DataGridView()
        Me.TableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.TableGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableGridView
        '
        Me.TableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableGridView.Location = New System.Drawing.Point(0, 0)
        Me.TableGridView.Name = "TableGridView"
        Me.TableGridView.Size = New System.Drawing.Size(800, 450)
        Me.TableGridView.TabIndex = 0
        '
        'DGTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableGridView)
        Me.Name = "DGTest"
        Me.Text = "DGTest"
        CType(Me.TableGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableGridView As DataGridView
    Friend WithEvents TableBindingSource As BindingSource
End Class
