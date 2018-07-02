Imports System.Windows

''' <summary>
''' Inspired by https://github.com/RSuter/MyToolkit/blob/master/src/MyToolkit/Mvvm/ViewModelBase.cs
''' but not fully implemented
''' </summary>
Public Class ViewModelBase
    Inherits DependencyObject

    Private _IsViewLoaded As Boolean

    Public Property IsViewLoaded As Boolean
        Get
            Return _IsViewLoaded
        End Get
        Private Set
            _IsViewLoaded = Value
        End Set
    End Property

    Public Overridable Sub Initialize()
        ' Must be empty
    End Sub

    Public Overridable Sub CallOnLoaded()
        If Not IsViewLoaded Then
            OnLoaded()
            IsViewLoaded = True
        End If
    End Sub

    Public Overridable Sub OnCallUnLoaded()
        If IsViewLoaded Then
            OnUnLoaded()
            IsViewLoaded = False
        End If
    End Sub

    Public Overridable Sub OnLoaded()
        ' Must be empty
    End Sub

    Public Overridable Sub OnUnLoaded()
        ' Must be empty
    End Sub


End Class
