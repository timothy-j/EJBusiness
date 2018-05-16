<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Startup
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
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.btnQuotes = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.GridTest = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOrders
        '
        Me.btnOrders.Location = New System.Drawing.Point(58, 48)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(75, 23)
        Me.btnOrders.TabIndex = 0
        Me.btnOrders.Text = "Orders"
        Me.btnOrders.UseVisualStyleBackColor = True
        '
        'btnQuotes
        '
        Me.btnQuotes.Location = New System.Drawing.Point(189, 48)
        Me.btnQuotes.Name = "btnQuotes"
        Me.btnQuotes.Size = New System.Drawing.Size(75, 23)
        Me.btnQuotes.TabIndex = 1
        Me.btnQuotes.Text = "Quotes"
        Me.btnQuotes.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(58, 89)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(75, 23)
        Me.btnReport.TabIndex = 3
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'GridTest
        '
        Me.GridTest.Location = New System.Drawing.Point(332, 48)
        Me.GridTest.Name = "GridTest"
        Me.GridTest.Size = New System.Drawing.Size(75, 23)
        Me.GridTest.TabIndex = 4
        Me.GridTest.Text = "Grid"
        Me.GridTest.UseVisualStyleBackColor = True
        '
        'Startup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 124)
        Me.Controls.Add(Me.GridTest)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnQuotes)
        Me.Controls.Add(Me.btnOrders)
        Me.Name = "Startup"
        Me.Text = "Startup"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOrders As Button
    Friend WithEvents btnQuotes As Button
    Friend WithEvents btnReport As Button
    Friend WithEvents GridTest As Button
End Class
