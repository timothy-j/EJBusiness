Partial Class MultiColumnComboBox
    Inherits CustomComboBox.CustomComboBox

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridViewPanel = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridViewPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewPanel
        '
        Me.DataGridViewPanel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.DataGridViewPanel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewPanel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPanel.ColumnHeadersVisible = False
        Me.DataGridViewPanel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridViewPanel.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewPanel.Name = "DataGridViewPanel"
        Me.DataGridViewPanel.ReadOnly = True
        Me.DataGridViewPanel.RowHeadersVisible = False
        Me.DataGridViewPanel.RowTemplate.Height = 20
        Me.DataGridViewPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewPanel.Size = New System.Drawing.Size(240, 150)
        Me.DataGridViewPanel.TabIndex = 0
        '
        'MultiColumnComboBox
        '
        CType(Me.DataGridViewPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridViewPanel As DataGridView
End Class
