<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneralTableTest
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
        Me.EjGeneralBomTable1 = New EJGeneralBomTable.EJGeneralBomTable()
        Me.SuspendLayout()
        '
        'EjGeneralBomTable1
        '
        Me.EjGeneralBomTable1.ChildRowTextColor = System.Drawing.Color.Gray
        Me.EjGeneralBomTable1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EjGeneralBomTable1.Location = New System.Drawing.Point(0, 0)
        Me.EjGeneralBomTable1.MachineType = Nothing
        Me.EjGeneralBomTable1.Name = "EjGeneralBomTable1"
        Me.EjGeneralBomTable1.Size = New System.Drawing.Size(800, 450)
        Me.EjGeneralBomTable1.TabIndex = 0
        '
        'GeneralTableTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.EjGeneralBomTable1)
        Me.Name = "GeneralTableTest"
        Me.Text = "GeneralTableTest"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents EjGeneralBomTable1 As EJGeneralBomTable.EJGeneralBomTable
End Class
