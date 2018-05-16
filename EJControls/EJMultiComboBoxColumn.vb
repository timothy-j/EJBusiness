Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' A column with a combobox editing control with multiple columns of bound 
''' drop down data
''' </summary>
Public Class EJMultiComboBoxColumn
    Inherits DataGridViewTextBoxColumn

    Public Sub New()
        'Set the type used in the DataGridView
        Me.CellTemplate = New EJMultiComboBoxCell
    End Sub
End Class

Public Class EJMultiComboBoxCell
    Inherits DataGridViewTextBoxCell

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
        ByVal initialFormattedValue As Object,
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue,
            dataGridViewCellStyle)
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that Cell uses.
            Return GetType(EJMultiComboBoxEditingControl)
        End Get
    End Property

End Class

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
'        'Me.AutoCompleteSource = AutoCompleteSource.ListItems
'        'Me.AutoCompleteMode = AutoCompleteMode.SuggestAppend
'    End Sub

'    Public Property EditingControlFormattedValue() As Object _
'        Implements IDataGridViewEditingControl.EditingControlFormattedValue

'        Get
'            Return Me.Text 'Me.SelectedValue
'        End Get

'        Set(ByVal value As Object)
'            Try
'                ' This will throw an exception of the string is 
'                ' null, empty, or not in the format of a date.
'                Me.Text = value 'Me.SelectedValue = value
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

'        Return Me.Text 'Me.SelectedValue

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

Public Class EJMultiComboBoxEditingControl
    Inherits ComboBox
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        MyBase.New()
        'Set some default properties

    End Sub

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor

        Me.DropDownStyle = ComboBoxStyle.DropDown
        Me.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    'Private Sub EJComboBoxCellEditingControl_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
    '    Me.EditingControlDataGridView.CurrentCell.Value = Me.SelectedValue
    'End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            ' TO DO: check this is the right thing to return!
            Return Me.Text
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is 
                ' null, empty, or not in the format of a date.
                Me.Text = CStr(value)
            Catch
                ' In the case of an exception, just use the default
                ' value so we're not left with a null value.
                Me.Text = ""
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Text

    End Function

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys,
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Up, Keys.Down 'Keys.Left,, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    'Protected Sub OnValueChanged(ByVal eventargs As EventArgs) Handles Me.TextChanged

    '    ' Notify the DataGridView that the contents of the cell have changed.
    '    valueIsChanged = True
    '    Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)

    'End Sub

    Private Sub EJMultiComboBoxEditingControl_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
    End Sub
End Class



