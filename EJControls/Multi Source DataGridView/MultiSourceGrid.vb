﻿Imports System.Reflection
Imports System.Linq.Dynamic

Public Class MultiSourceGrid

    Private _commitAttempt As Boolean

    ''' <summary>
    ''' Stores list of properties for nested property bound columns
    ''' Key = column name
    ''' </summary>
    Dim BindPropertyLists As New Dictionary(Of String, List(Of String))

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DoubleBuffered = True
    End Sub

    Private Function GetBindProperty(ByVal [property] As Object, ByVal propertyName As String) As Object
        Dim retValue As Object = Nothing

        If propertyName.Contains(".") Then
            Dim thisPropertyName As String

            thisPropertyName = propertyName.Substring(0, propertyName.IndexOf("."))
            propertyName = propertyName.Substring(propertyName.IndexOf(".") + 1)

            retValue = GetBindProperty([property].GetType().GetProperty(thisPropertyName).GetValue([property], Nothing), propertyName)
        Else
            ' Return this (bottom) property value
            Dim tempValue = [property].GetType().GetProperty(propertyName).GetValue([property], Nothing)
            If tempValue Is Nothing Then Return ""
            retValue = tempValue
        End If

        Return retValue
    End Function

    Private Sub SetBindProperty(ByVal [property] As Object, ByVal propertyName As String, ByVal value As Object)

        ' If there are further property nest levels
        If propertyName.Contains(".") Then
            Dim thisPropertyName As String

            thisPropertyName = propertyName.Substring(0, propertyName.IndexOf("."))
            propertyName = propertyName.Substring(propertyName.IndexOf(".") + 1)

            SetBindProperty([property].GetType().GetProperty(thisPropertyName).GetValue([property], Nothing), propertyName, value)
        Else ' Bottom property level
            ' Set the value to this (bottom) property
            [property].GetType().GetProperty(propertyName).SetValue([property], value)
        End If

    End Sub

    Private Function GetBindPropertyType(ByVal propertyType As Type, ByVal propertyName As String, ByVal columnName As String) As Type
        Dim retValue As Type = Nothing

        ' If there are further property nest levels
        If propertyName.Contains(".") Then
            Dim thisPropertyName As String

            thisPropertyName = propertyName.Substring(0, propertyName.IndexOf("."))
            propertyName = propertyName.Substring(propertyName.IndexOf(".") + 1)

            retValue = GetBindPropertyType(propertyType.GetProperty(thisPropertyName).PropertyType, propertyName, columnName)
        Else ' Bottom property level
            Dim propertyInfo As PropertyInfo

            propertyInfo = propertyType.GetProperty(propertyName)
            retValue = propertyInfo.PropertyType
        End If

        Return retValue
    End Function

    Private Sub MultiSourceGrid_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Me.RowsAdded
        If Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub

        ' Clear the BindPropertyLists so Add can't throw exception
        BindPropertyLists.Clear()

        For Each col As DataGridViewColumn In Columns
            If col.DataPropertyName.Contains(".") Then
                ' HACK: testing adding column valuetype
                ' Create new (empty) list for this column in 
                BindPropertyLists.Add(col.Name, New List(Of String))
                col.ValueType = GetBindPropertyType(Rows(0).DataBoundItem.GetType, col.DataPropertyName, col.Name)

                ' Insert the values from 'complex bound' source objects
                For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
                    Rows.Item(i).Cells.Item(col.Index).Value = GetBindProperty(Rows(i).DataBoundItem, col.DataPropertyName)
                Next

                ' HACK: TODO: make auto version where ###BindProperty() blocks work with methods as well as properties
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
