Imports DevExpress.Mvvm.ModuleInjection
Imports DevExpress.Xpf.Core
Imports EJBusiness.Main
Imports NUnit.Framework
Imports System.Windows

Public MustInherit Class BaseTestFixture
    Public ReadOnly Property Manager() As IModuleManager
        Get
            Return ModuleManager.DefaultManager
        End Get
    End Property
    Protected Overridable ReadOnly Property IsFunctionalTesting() As Boolean
        Get
            Return False
        End Get
    End Property
    Private bootstrapper As TestBootstrapper
    <SetUp>
    Public Sub SetUp()
        ModuleManager.DefaultManager = New ModuleManager(False, Not IsFunctionalTesting)
        bootstrapper = New TestBootstrapper(IsFunctionalTesting)
        bootstrapper.Run()
    End Sub
    <TearDown>
    Public Sub TearDown()
        ModuleManager.DefaultManager = Nothing
    End Sub
    Protected Sub DoEvents()
        If (IsFunctionalTesting) Then
            DispatcherHelper.UpdateLayoutAndDoEvents(bootstrapper.MainWindow)
        End If
    End Sub
End Class
Public Class TestBootstrapper
    Inherits Bootstrapper

    Private ReadOnly showRealWindow As Boolean
    Public Property MainWindow() As Window
    Public Sub New(ByVal showRealWindow As Boolean)
        Me.showRealWindow = showRealWindow
    End Sub
    Protected Overrides Sub ShowMainWindow()
        If (Not showRealWindow) Then Return
        MainWindow = New MainWindow() With {
            .WindowStyle = WindowStyle.None,
            .WindowState = WindowState.Normal,
            .WindowStartupLocation = WindowStartupLocation.CenterScreen,
            .ShowActivated = False,
            .AllowsTransparency = True,
            .Opacity = 0.0,
            .ShowInTaskbar = False
        }
        MainWindow.Show()
    End Sub
End Class
