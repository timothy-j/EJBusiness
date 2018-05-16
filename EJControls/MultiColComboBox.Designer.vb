<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiColComboBox
    Inherits System.Windows.Forms.ComboBox

    'Control overrides dispose to clean up the component list.
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

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridViewPanel = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridViewPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewPanel
        '
        Me.DataGridViewPanel.AllowUserToAddRows = False
        Me.DataGridViewPanel.AllowUserToDeleteRows = False
        Me.DataGridViewPanel.AllowUserToResizeColumns = False
        Me.DataGridViewPanel.AllowUserToResizeRows = False
        Me.DataGridViewPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPanel.ColumnHeadersVisible = False
        Me.DataGridViewPanel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridViewPanel.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewPanel.MultiSelect = False
        Me.DataGridViewPanel.Name = "DataGridViewPanel"
        Me.DataGridViewPanel.RowHeadersVisible = False
        Me.DataGridViewPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewPanel.Size = New System.Drawing.Size(240, 150)
        Me.DataGridViewPanel.TabIndex = 0
        '
        'MultiColComboBox
        '
        CType(Me.DataGridViewPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridViewPanel As DataGridView
End Class

