Imports System.Reflection
Imports System.Linq.Dynamic
Imports System.Text.RegularExpressions

Public Class MultiSourceGrid

    Private _commitAttempt As Boolean

    ''' <summary>
    ''' Request to retrieve data from the data source
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="returnValue">Put requested data into this value</param>
    Public Event CustomDataGet(ByVal sender As MultiSourceGrid, ByVal e As CustomDataGetSetEventArgs, ByRef returnValue As Object)

    Class CustomDataGetSetEventArgs
        Inherits EventArgs
        ''' <summary>
        ''' The value to be set in the data source
        ''' </summary>
        ''' <returns></returns>
        Property Value As Object
        ''' <summary>
        ''' The binding source data for this row
        ''' </summary>
        ''' <returns></returns>
        Property RowBoundItem As Object

        Property Column As DataGridViewColumn
    End Class

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event CustomDataSet(ByVal sender As MultiSourceGrid, ByVal e As CustomDataGetSetEventArgs)

    Public Event CustomDataGetType(ByVal sender As MultiSourceGrid, ByVal e As CustomDataGetSetEventArgs, ByRef returnType As Type)

    ''' <summary>
    ''' Stores list of properties/methods for complex bound columns
    ''' Key = column name
    ''' </summary>
    Dim BindPropertyLists As New Dictionary(Of String, List(Of EJProperty))

    Enum EJPropertyType
        None = 0
        [Property]
        [Method]
        Custom
    End Enum

    Structure EJProperty
        Public Name As String
        Public [Type] As EJPropertyType
    End Structure

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DoubleBuffered = True
    End Sub

    ''' <summary>
    ''' Gets the value of the  property (specified in the column binding property) from the supplied Object
    ''' </summary>
    ''' <param name="boundObject"></param>
    ''' <param name="columnName"></param>
    ''' <returns></returns>
    Private Function GetBindProperty(ByVal boundObject As Object, ByVal columnName As String) As Object

        For Each prop As EJProperty In BindPropertyLists(columnName)
            Select Case prop.Type
                Case EJPropertyType.Property
                    boundObject = boundObject.GetType().GetProperty(prop.Name).GetValue(boundObject, Nothing)
                Case EJPropertyType.Method
                    ' TO DO: write method code
                    ' HACK: currently only works for methods with one string parameter or no parameter
                    Dim propName As String = prop.Name.Substring(0, prop.Name.IndexOf("(") - 1)
                    Dim args As New List(Of Object)
                    args.Add(prop.Name.Substring(prop.Name.IndexOf(""""), prop.Name.LastIndexOf("""") - prop.Name.IndexOf("""")))
                    boundObject = boundObject.GetType.GetMethod("MyMethod").Invoke(boundObject, args.ToArray)
                Case Else
                    ' Throw error
            End Select
            If boundObject Is Nothing Then Exit For
        Next

        Return boundObject
    End Function

    Private Sub SetBindProperty(ByVal boundObject As Object, ByVal columnName As String, ByVal value As Object)
        Dim i As Integer
        For i = 0 To BindPropertyLists(columnName).Count - 2 ' Does not retrieve final property
            Dim prop As EJProperty = BindPropertyLists(columnName)(i)
            Select Case prop.Type
                Case EJPropertyType.Property
                    boundObject = boundObject.GetType().GetProperty(prop.Name).GetValue(boundObject, Nothing)
                Case Else
                    ' Throw error
            End Select
            If boundObject Is Nothing Then Throw New System.NullReferenceException("Part of the binding property has evaluated to null (nothing)")
        Next

        ' TODO: Throw eroor if attempting to set to method rather than property (sort out when constructing BindPropertyLists)
        boundObject.GetType().GetProperty(BindPropertyLists(columnName)(i).Name).SetValue(boundObject, value)

    End Sub

    Private Function GetBindPropertyType(ByVal propertyType As Type, ByVal propertyName As String, ByVal columnName As String) As Type
        Dim retValue As Type = Nothing

        If IsExpression(propertyName) Then
            Dim thisPropertyName As String = ""

            Dim propType = GetNextPropertyType(propertyName, thisPropertyName)
            'thisPropertyName = propertyName.Substring(0, propertyName.IndexOf("."))
            BindPropertyLists(columnName).Add(New EJProperty With {.Name = thisPropertyName, .Type = propType})
            Select Case propType
                Case EJPropertyType.Property
                    retValue = GetBindPropertyType(propertyType.GetProperty(thisPropertyName).PropertyType, propertyName, columnName)
                Case EJPropertyType.Custom
                    Dim e As New CustomDataGetSetEventArgs With {.Column = Me.Columns.Item(columnName), .RowBoundItem = Nothing, .Value = Nothing}
                    RaiseEvent CustomDataGetType(Me, e, retValue)
            End Select
        Else
            ' Return this (bottom) property type
            BindPropertyLists(columnName).Add(New EJProperty With {.Name = propertyName, .Type = EJPropertyType.Property})
            retValue = propertyType.GetProperty(propertyName).PropertyType
        End If

        Return retValue
    End Function

    Private Sub MultiSourceGrid_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Me.RowsAdded
        If Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

        ' Clear the BindPropertyLists so Add can't throw exception
        BindPropertyLists.Clear()

        For Each col As DataGridViewColumn In Columns
            If IsExpressionColumn(col) Then
                ' Create new (empty) list for this column in 
                BindPropertyLists.Add(col.Name, New List(Of EJProperty))

                ' HACK: this makes most of GetNextPropertyType obsolete
                If col.DataPropertyName.Contains("(") Then
                    BindPropertyLists(col.Name).Add(New EJProperty With
                                                    {.Name = col.DataPropertyName.Substring(1, col.DataPropertyName.LastIndexOf(")") - 2),
                                                    .Type = EJPropertyType.Custom})
                Else
                    col.ValueType = GetBindPropertyType(Rows(0).DataBoundItem.GetType, col.DataPropertyName, col.Name)
                End If

                ' Insert the values from 'complex bound' source objects
                For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
                    If BindPropertyLists(col.Name)(0).Type = EJPropertyType.Custom Then

                        Dim ev As New CustomDataGetSetEventArgs With {.Column = col,
                            .RowBoundItem = Rows.Item(i).DataBoundItem, .Value = Nothing}
                        'RaiseEvent CustomDataGet(Me, ev, Rows.Item(i).Cells.Item(col.Index).Value)
                    Else
                        Rows.Item(i).Cells.Item(col.Index).Value = GetBindProperty(Rows(i).DataBoundItem, col.Name)
                    End If
                Next

                ' HACK: TODO: make auto version where ###BindProperty() blocks work with methods as well as properties
                ' ans use MethodInfo.Invoke(Object, Args())                mi.GetType.GetMethod("MyMethod").Invoke(mi,)

#Region "Input column hack"
            ElseIf col.Name = "MC248Column" Then
                'MsgBox("col")
                For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
                    Dim mi As EJData.MachineItem = CType(Rows(i).DataBoundItem, EJData.Item).MachineItems.Where("MachineID = 248").FirstOrDefault
                    If mi Is Nothing Then Continue For
                    Rows.Item(i).Cells.Item(col.Index).Value = CType(Rows(i).DataBoundItem, EJData.Item).MachineItems.Where("MachineID = 248").FirstOrDefault.Qty
                Next
            ElseIf col.Name = "MCS248Column" Then
                For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
                    Dim mi As EJData.MachineItem = CType(Rows(i).DataBoundItem, EJData.Item).MachineItems.Where("MachineID = 248").FirstOrDefault
                    If mi Is Nothing Then Continue For
                    Rows.Item(i).Cells.Item(col.Index).Value = CType(Rows(i).DataBoundItem, EJData.Item).MachineItems.Where("MachineID = 248").FirstOrDefault.Status
                Next
#End Region
            End If

        Next
    End Sub

    Private Sub MultiSourceGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Me.DataError
        If _commitAttempt Then Exit Sub
        MsgBox(e.Exception.Message + vbNewLine + "(Press Esc to restore the previous value)")
    End Sub

    Private Sub MultiSourceGrid_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles Me.CellParsing
        ' Send null to nullable values
        If e.Value = "" Then
            ' Is type nullable?
            If Nullable.GetUnderlyingType(e.DesiredType) IsNot Nothing Then
                ' Some columns causing string conversion data error on null. TODO: try putting e.value to cell value and then to nothing?
                e.Value = Nothing
                e.ParsingApplied = True
            End If
        End If
    End Sub

    Private Sub MultiSourceGrid_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles Me.CellValidating
        ' If this is an 'complex bound' column, attempt to set the value to the source object
        If (IsExpressionColumn(Columns(e.ColumnIndex))) And e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Try
                _commitAttempt = True
                CommitEdit(DataGridViewDataErrorContexts.Formatting) 'DataGridViewDataErrorContexts.Commit Or DataGridViewDataErrorContexts.Parsing)
            Catch ex As Exception
                MsgBox("[during cell validating]" + vbNewLine + ex.Message)
                e.Cancel = True
            End Try
            _commitAttempt = False
        End If
    End Sub

    Private Sub MultiSourceGrid_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Me.CellValueChanged
        ' If this is an 'complex bound' column, attempt to set the value to the source object
        If _commitAttempt Then
            Dim cell As DataGridViewCell = Rows.Item(e.RowIndex).Cells.Item(e.ColumnIndex)
            If BindPropertyLists(Columns.Item(e.ColumnIndex).Name)(0).Type = EJPropertyType.Custom Then
                Dim ev As New CustomDataGetSetEventArgs With {.Column = Columns.Item(e.ColumnIndex),
                    .RowBoundItem = Rows.Item(e.RowIndex).DataBoundItem, .Value = cell.Value}
                RaiseEvent CustomDataSet(Me, ev)
            Else
                SetBindProperty(Rows.Item(e.RowIndex).DataBoundItem, Columns.Item(e.ColumnIndex).Name, cell.Value)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Determines whether the column binding contains expressions (including nested properties)
    ''' </summary>
    ''' <param name="column"></param>
    ''' <returns></returns>
    Private Function IsExpressionColumn(column As DataGridViewColumn) As Boolean
        Return IsExpression(column.DataPropertyName)
    End Function

    ''' <summary>
    ''' Determines whether the string contains expressions (including nested properties)
    ''' </summary>
    ''' <param name="text">String expression representing bound property</param>
    ''' <returns></returns>
    Private Function IsExpression(text As String) As Boolean
        If text.IndexOfAny({".", "("}) >= 0 Then Return True
        Return False
    End Function

    Private Function GetNextPropertyType(ByRef textInRemainderOut As String, ByRef NextProperty As String) As EJPropertyType
        Dim pos As Integer = textInRemainderOut.IndexOfAny({".", "("})
        Select Case GetChar(textInRemainderOut, pos + 1) ' IMPORTANT - GetChar index is 1-based whereas IndexOfAny is 0-based
            Case "."c
                ' the next property is a function
                NextProperty = textInRemainderOut.Substring(0, pos)
                textInRemainderOut = textInRemainderOut.Substring(pos + 1)
                Return EJPropertyType.Property
                Exit Select
            Case "("c
                ' The next property is a method
                Dim closePos As Integer = textInRemainderOut.IndexOf(")") ' TO DO: if this is > 0 throw error
                ' HACK: This doesn't allow for input strings with nested brackets or brackets in strings
                NextProperty = textInRemainderOut.Substring(0, closePos + 1)
                textInRemainderOut = textInRemainderOut.Substring(closePos + 2) ' allows for final ')' and following '.'
                Return EJPropertyType.Method
        End Select
        Return EJPropertyType.None
    End Function
End Class
