<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PartsView
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
        Me.PartsTableControl1 = New EJParts.PartsTableControl()
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
        'PartsView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PartsTableControl1)
        Me.Name = "PartsView"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PartsTableControl1 As PartsTableControl
End Class
