Imports System.Reflection
Imports System.Linq.Dynamic
Imports System.Text.RegularExpressions

Public Class MultiSourceGrid

    Private _commitAttempt As Boolean

    ''' <summary>
    ''' Stores list of properties/methods for complex bound columns
    ''' Key = column name
    ''' </summary>
    Dim BindPropertyLists As New Dictionary(Of String, List(Of EJProperty))

    Enum EJPropertyType
        None = 0
        [Property]
        [Method]
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

    Private Function GetBindProperty(ByVal [property] As Object, ByVal propertyName As String) As Object
        Dim retValue As Object = Nothing

        ' LOW: extend this (and Set version) to work with more complicated property bindings

        If IsExpression(propertyName) Then
            Dim thisPropertyName As String = ""

            If GetNextPropertyType(propertyName, thisPropertyName) = EJPropertyType.Property Then
                ' Get the next property name (before the next '.')
                retValue = GetBindProperty([property].GetType().GetProperty(thisPropertyName).GetValue([property], Nothing), propertyName)
            Else
                ' TODO: deal with method 'property'
            End If
        Else
            ' Return this (bottom) property value
            Dim tempValue = [property].GetType().GetProperty(propertyName).GetValue([property], Nothing)
            If tempValue Is Nothing Then Return ""
            retValue = tempValue
        End If

        Return retValue
    End Function

    Private Sub SetBindProperty(ByVal [property] As Object, ByVal propertyName As String, ByVal value As Object)

        If IsExpression(propertyName) Then
            Dim thisPropertyName As String = ""

            If GetNextPropertyType(propertyName, thisPropertyName) = EJPropertyType.Property Then
                ' Get the next property name (before the next '.')
                SetBindProperty([property].GetType().GetProperty(thisPropertyName).GetValue([property], Nothing), propertyName, value)
            Else
                ' TODO: deal with method 'property'
            End If

        Else
            ' Set the value to this (bottom) property
            [property].GetType().GetProperty(propertyName).SetValue([property], value)
        End If

    End Sub

    Private Function GetBindPropertyType(ByVal propertyType As Type, ByVal propertyName As String, ByVal columnName As String) As Type
        Dim retValue As Type = Nothing

        If IsExpression(propertyName) Then
            Dim thisPropertyName As String = ""

            Dim propType = GetNextPropertyType(propertyName, thisPropertyName)
            'thisPropertyName = propertyName.Substring(0, propertyName.IndexOf("."))
            BindPropertyLists(columnName).Add(New EJProperty With {.Name = thisPropertyName, .Type = propType})
            retValue = GetBindPropertyType(propertyType.GetProperty(thisPropertyName).PropertyType, propertyName, columnName)
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
                ' HACK: testing adding column valuetype
                ' Create new (empty) list for this column in 
                BindPropertyLists.Add(col.Name, New List(Of EJProperty))
                col.ValueType = GetBindPropertyType(Rows(0).DataBoundItem.GetType, col.DataPropertyName, col.Name)

                ' Insert the values from 'complex bound' source objects
                For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
                    ' LOW: work out whether same bind property can be used for each column, rather than parsing string for every row
                    Rows.Item(i).Cells.Item(col.Index).Value = GetBindProperty(Rows(i).DataBoundItem, col.DataPropertyName)
                Next

                ' HACK: TODO: make auto version where ###BindProperty() blocks work with methods as well as properties
                ' use regex - see https://stackoverflow.com/questions/29725739/python-regex-get-everything-within-parentheses-unless-in-quotes
                ' and regex.split(string) https://msdn.microsoft.com/en-us/library/ze12yx1d(v=vs.110).aspx
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
            SetBindProperty(Rows.Item(e.RowIndex).DataBoundItem, Columns.Item(e.ColumnIndex).DataPropertyName, cell.Value)
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

                NextProperty = Regex.Split(textInRemainderOut, "((?:""[^""]*""|[^()])*)\)")(0)
                Return EJPropertyType.Method
        End Select
        Return EJPropertyType.None
    End Function
End Class
