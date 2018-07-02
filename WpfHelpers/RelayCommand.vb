Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Input

Public Class RelayCommand
    Implements ICommand

#Region "Fields"

    Private ReadOnly _execute As Action(Of Object)
    Private ReadOnly _canExecute As Predicate(Of Object)

#End Region ' Fields

#Region "Constructors"

    Public Sub New(ByVal execute As Action(Of Object))
        Me.New(execute, Nothing)
    End Sub

    Public Sub New(ByVal execute As Action(Of Object), ByVal canExecute As Predicate(Of Object))
        If execute Is Nothing Then
            Throw New ArgumentNullException("execute")
        End If

        _execute = execute
        _canExecute = canExecute
    End Sub
#End Region ' Constructors

#Region "ICommand Members"

    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
        Return If(_canExecute Is Nothing, True, _canExecute(parameter))
    End Function

    Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
        AddHandler(ByVal value As EventHandler)
            AddHandler CommandManager.RequerySuggested, value
        End AddHandler
        RemoveHandler(ByVal value As EventHandler)
            RemoveHandler CommandManager.RequerySuggested, value
        End RemoveHandler
        RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End RaiseEvent
    End Event

    Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
        _execute(parameter)
    End Sub

#End Region ' ICommand Members
End Class
