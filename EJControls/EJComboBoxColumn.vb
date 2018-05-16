Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

'Public Class DropDownListCell
'    Inherits DataGridViewComboBoxCell

'    Public Overrides ReadOnly Property EditType() As Type
'        Get
'            ' Return the type of the editing contol that 
'            ' the DropDownListCell uses.
'            Return GetType(EJComboBoxCellEditingControl)
'        End Get
'    End Property

'End Class

Public Class EJComboBoxCell
    Inherits DataGridViewComboBoxCell

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that EJComboBoxCell uses.
            Return GetType(EJComboBoxCellEditingControl)
        End Get
    End Property

End Class

'Public Class EJComboBoxCell2
'    Inherits DataGridViewTextBoxCell

'    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
'        ByVal initialFormattedValue As Object,
'        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

'        ' Set the value of the editing control to the current cell value.
'        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue,
'            dataGridViewCellStyle)
'        'Me.DataGridView.
'        'dataGridViewCellStyle.
'        'Dim ctl As EJComboBoxCellEditingControl =
'        '    CType(DataGridView.EditingControl, EJComboBoxCellEditingControl)
'    End Sub

'    Public Overrides ReadOnly Property EditType() As Type
'        Get
'            ' Return the type of the editing control that CalendarCell uses.
'            Return GetType(EJComboBoxCellEditingControl)
'        End Get
'    End Property

'End Class

'Public Class EJComboBoxCellEditingControl
'    Inherits ComboBox
'    Implements IDataGridViewEditingControl

'    Private dataGridViewControl As DataGridView
'    Private valueIsChanged As Boolean = False
'    Private rowIndexNum As Integer

'    Public Sub New()
'        MyBase.New()
'        'Set some default properties

'        'Make this a DropDownList 
'        Me.DropDownStyle = ComboBoxStyle.DropDown
'        Me.AutoCompleteSource = AutoCompleteSource.ListItems
'        Me.AutoCompleteMode = AutoCompleteMode.SuggestAppend
'        Me.SelectedIndex = -1
'    End Sub

'    Private Sub EJComboBoxCellEditingControl_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
'        'Me.DropDownStyle = ComboBoxStyle.DropDown
'        'Me.SelectedIndex = -1
'    End Sub

'    Public Property EditingControlFormattedValue() As Object _
'        Implements IDataGridViewEditingControl.EditingControlFormattedValue

'        Get
'            Return Me.SelectedValue
'        End Get

'        Set(ByVal value As Object)
'            Try
'                ' This will throw an exception of the string is 
'                ' null, empty, or not in the format of a date.
'                Me.SelectedValue = value
'            Catch
'                ' In the case of an exception, just use the default
'                ' value so we're not left with a null value.
'                MsgBox("Passed value does not correspond to an item on the list." & vbNewLine &
'                       "If this works correctly, delete this msgbox in EJComboBoxCellEditingControl.EditingControlFormattedValue")
'                'Me.SelectedValue = DateTime.Now
'            End Try
'        End Set

'    End Property

'    Public Function GetEditingControlFormattedValue(ByVal context _
'        As DataGridViewDataErrorContexts) As Object _
'        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

'        Return Me.SelectedValue

'    End Function

'    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
'        DataGridViewCellStyle) _
'        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

'        Me.Font = dataGridViewCellStyle.Font
'        Me.ForeColor = dataGridViewCellStyle.ForeColor
'        Me.BackColor = dataGridViewCellStyle.BackColor

'    End Sub

'    Public Property EditingControlRowIndex() As Integer _
'        Implements IDataGridViewEditingControl.EditingControlRowIndex

'        Get
'            Return rowIndexNum
'        End Get
'        Set(ByVal value As Integer)
'            rowIndexNum = value
'        End Set

'    End Property

'    Public Function EditingControlWantsInputKey(ByVal key As Keys,
'        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
'        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

'        ' Let the DateTimePicker handle the keys listed.
'        Select Case key And Keys.KeyCode
'            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right,
'                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

'                Return True

'            Case Else
'                Return Not dataGridViewWantsInputKey
'        End Select

'    End Function

'    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
'        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

'        ' No preparation needs to be done.

'    End Sub

'    Public ReadOnly Property RepositionEditingControlOnValueChange() _
'        As Boolean Implements _
'        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

'        Get
'            Return False
'        End Get

'    End Property

'    Public Property EditingControlDataGridView() As DataGridView _
'        Implements IDataGridViewEditingControl.EditingControlDataGridView

'        Get
'            Return dataGridViewControl
'        End Get
'        Set(ByVal value As DataGridView)
'            dataGridViewControl = value
'        End Set

'    End Property

'    Public Property EditingControlValueChanged() As Boolean _
'        Implements IDataGridViewEditingControl.EditingControlValueChanged

'        Get
'            Return valueIsChanged
'        End Get
'        Set(ByVal value As Boolean)
'            valueIsChanged = value
'        End Set

'    End Property

'    Public ReadOnly Property EditingControlCursor() As Cursor _
'        Implements IDataGridViewEditingControl.EditingPanelCursor

'        Get
'            Return MyBase.Cursor
'        End Get

'    End Property

'    Protected Overrides Sub OnSelectedValueChanged(ByVal eventargs As EventArgs)

'        ' Notify the DataGridView that the contents of the cell have changed.
'        valueIsChanged = True
'        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
'        MyBase.OnSelectedValueChanged(eventargs)

'    End Sub


'End Class

Public Class EJComboBoxCellEditingControl
    Inherits DataGridViewComboBoxEditingControl

    Public Sub New()
        MyBase.New()
        'Set some default properties

    End Sub

    Public Overrides Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle)

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor

        Me.DropDownStyle = ComboBoxStyle.DropDown
        Me.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    Private Sub EJComboBoxCellEditingControl_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
        Me.EditingControlDataGridView.CurrentCell.Value = Me.SelectedValue
    End Sub

End Class

Public Class EJComboBoxColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        'Set the type used in the DataGridView
        Me.CellTemplate = New EJComboBoxCell
    End Sub
End Class

