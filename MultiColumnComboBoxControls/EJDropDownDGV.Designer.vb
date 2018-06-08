﻿Partial Class EJDropDownDGV
    Inherits DataGridView

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

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
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EJDropDownDGV
        '
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.AllowUserToResizeColumns = False
        Me.AllowUserToResizeRows = False
        Me.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.ColumnHeadersVisible = False
        Me.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.RowHeadersVisible = False
        Me.RowTemplate.Height = 18
        Me.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
