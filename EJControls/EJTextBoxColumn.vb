Imports System
Imports System.ComponentModel
Imports System.Windows.Forms


Public Class EJTextColumnCell
    Inherits DataGridViewTextBoxCell
    'Implements IEntityCell

    'Private _entity As Object

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that EJComboBoxCell uses.
            Return GetType(EJTextCellEditingControl)
        End Get
    End Property

    'Public Property Entity As Object Implements IEntityCell.Entity
    '    Get
    '        Return _entity
    '    End Get
    '    Set(value As Object)
    '        _entity = value
    '    End Set
    'End Property

    ' TO DO: override Clone() method

    'Protected Overrides Sub OnMouseDown(e As DataGridViewCellMouseEventArgs)
    '    MyBase.OnMouseDown(e)
    '    Me.DataGridView.BeginEdit(True)
    '    'MsgBox("dfgs ")
    'End Sub

    'Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, dataGridViewCellStyle As DataGridViewCellStyle)
    '    MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

    '    'If MouseButtons.Left Then
    '    Dim ctl = CType(Me.DataGridView.EditingControl, EJTextCellEditingControl)
    '        ctl.SelectionStart = 3
    '        ctl.SelectionLength = 5
    '    'End If
    'End Sub


End Class

Public Class EJTextCellEditingControl
    Inherits DataGridViewTextBoxEditingControl

    Public Sub New()
        MyBase.New()
        'Set some default properties

    End Sub

    Public Overrides Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle)

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor

        'Me.DropDownStyle = ComboBoxStyle.DropDown
        'Me.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    Public Overrides Sub PrepareEditingControlForEdit(selectAll As Boolean)
        MyBase.PrepareEditingControlForEdit(selectAll)
        If MouseButtons.Left Then
            Me.SelectionStart = 3
            Me.SelectionLength = 5
        End If
    End Sub
    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        If MouseButtons.Left Then
            Me.SelectionStart = 3
            Me.SelectionLength = 5
        End If
    End Sub
End Class

Public Class EJTextBoxColumn
    Inherits DataGridViewTextBoxColumn
    'Implements IEntityColumn

    'Private _entityProperty As String

    Public Sub New()
        'Set the type used in the DataGridView
        Me.CellTemplate = New EJTextColumnCell
    End Sub


    'Public Property EntityType As Type Implements IEntityColumn.EntityType
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Type)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    'Public Property EntityProperty As String Implements IEntityColumn.EntityProperty
    '    Get
    '        Return _entityProperty
    '    End Get
    '    Set(value As String)
    '        _entityProperty = value
    '    End Set
    'End Property

    ' TO DO: override Clone() method
End Class


