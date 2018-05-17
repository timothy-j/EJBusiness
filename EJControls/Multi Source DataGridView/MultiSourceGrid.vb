Imports System.Reflection

Public Class MultiSourceGrid

    Private _commitAttempt As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DoubleBuffered = True
    End Sub

    Private Function GetBindProperty(ByVal [property] As Object, ByVal propertyName As String) As Object
        Dim retValue As Object = Nothing

        ' LOW: extend this (and Set version) to work with more complicated property bindings

        If propertyName.Contains(".") Then
            Dim arrayProperties() As PropertyInfo
            Dim leftPropertyName As String

            leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."))
            arrayProperties = [property].GetType().GetProperties()

            For Each propertyInfo As PropertyInfo In arrayProperties
                If propertyInfo.Name = leftPropertyName Then
                    retValue = GetBindProperty(propertyInfo.GetValue([property], Nothing), propertyName.Substring(propertyName.IndexOf(".") + 1))
                    Exit For
                End If
            Next propertyInfo
        Else
            Dim propertyType As Type
            Dim propertyInfo As PropertyInfo

            propertyType = [property].GetType()
            propertyInfo = propertyType.GetProperty(propertyName)
            Dim tempValue = propertyInfo.GetValue([property], Nothing)
            If tempValue Is Nothing Then Return ""
            retValue = propertyInfo.GetValue([property], Nothing)
        End If

        Return retValue
    End Function

    Private Sub SetBindProperty(ByVal [property] As Object, ByVal propertyName As String, ByVal value As Object)

        If propertyName.Contains(".") Then
            Dim arrayProperties() As PropertyInfo
            Dim leftPropertyName As String

            leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."))
            arrayProperties = [property].GetType().GetProperties()

            For Each propertyInfo As PropertyInfo In arrayProperties
                If propertyInfo.Name = leftPropertyName Then
                    SetBindProperty(propertyInfo.GetValue([property], Nothing), propertyName.Substring(propertyName.IndexOf(".") + 1), value)
                    Exit For
                End If
            Next propertyInfo
        Else
            Dim propertyType As Type
            Dim propertyInfo As PropertyInfo

            propertyType = [property].GetType()
            propertyInfo = propertyType.GetProperty(propertyName)
            propertyInfo.SetValue([property], value)
        End If

    End Sub

    Private Function GetBindPropertyType(ByVal propertyType As Type, ByVal propertyName As String) As Type
        Dim retValue As Type = Nothing

        If propertyName.Contains(".") Then
            Dim arrayProperties() As PropertyInfo
            Dim leftPropertyName As String

            leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."))
            arrayProperties = propertyType.GetProperties()

            For Each propertyInfo As PropertyInfo In arrayProperties
                If propertyInfo.Name = leftPropertyName Then
                    retValue = GetBindPropertyType(propertyInfo.PropertyType, propertyName.Substring(propertyName.IndexOf(".") + 1))
                    Exit For
                End If
            Next propertyInfo
        Else
            Dim propertyInfo As PropertyInfo

            propertyInfo = propertyType.GetProperty(propertyName)
            retValue = propertyInfo.PropertyType
        End If

        Return retValue
    End Function

    Private Sub MultiSourceGrid_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Me.RowsAdded
        If Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

        For Each col As DataGridViewColumn In Columns
            If col.DataPropertyName.Contains(".") Then
                ' HACK: testing adding column valuetype
                col.ValueType = GetBindPropertyType(Rows(0).DataBoundItem.GetType, col.DataPropertyName)

                ' Insert the values from 'complex bound' source objects
                For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
                    Rows.Item(i).Cells.Item(col.Index).Value = GetBindProperty(Rows(i).DataBoundItem, col.DataPropertyName)
                Next
            End If

        Next
    End Sub

    Private Sub MultiSourceGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Me.DataError
        If _commitAttempt Then Exit Sub
        MsgBox(e.Exception.Message + vbNewLine + "(Press Esc to restore the previous value)")
    End Sub

    Private Sub MultiSourceGrid_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles Me.ColumnAdded
        If e.Column.DataPropertyName.Contains(".") Then
            ' e.Column.ValueType = GetBindPropertyType()
        End If
    End Sub

    Private Sub MultiSourceGrid_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles Me.CellParsing
        ' Send null to nullable values
        If e.Value = "" Then
            ' Is type nullable?
            If Nullable.GetUnderlyingType(e.DesiredType) IsNot Nothing Then
                ' Som columns causing string conversion data error on null. TODO: try putting e.value to cell value and then to nothing?
                e.Value = Nothing
                e.ParsingApplied = True
            End If
        End If
    End Sub

    Private Sub MultiSourceGrid_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles Me.CellValidating
        ' If this is an 'complex bound' column, attempt to set the value to the source object
        If (Columns(e.ColumnIndex).DataPropertyName.Contains(".")) And e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
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
End Class
