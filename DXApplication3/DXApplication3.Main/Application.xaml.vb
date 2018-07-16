Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.ModuleInjection
Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Core
Imports DXApplication3.Common
Imports DXApplication3.Main.My
Imports DXApplication3.Main.ViewModels
Imports DXApplication3.Modules
Imports DXApplication3.Modules.ViewModels
Imports AppModules = DXApplication3.Common.Modules
Imports InjectionModule = DevExpress.Mvvm.ModuleInjection.Module

Public Class App
    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        MyBase.OnStartup(e)
        ApplicationThemeHelper.UpdateApplicationThemeName()
        Dim bootstrapper = New Bootstrapper()
        bootstrapper.Run()
    End Sub
    Protected Overrides Sub OnExit(ByVal e As ExitEventArgs)
        ApplicationThemeHelper.SaveApplicationThemeName()
        MyBase.OnExit(e)
    End Sub
End Class


Public Class Bootstrapper
    Const StateVersion As String = "1.0"
    Public Overridable Sub Run()
        ConfigureTypeLocators()
        RegisterModules()
        If Not RestoreState() Then
            InjectModules()
        End If
        ConfigureNavigation()
        ShowMainWindow()
    End Sub

    Protected ReadOnly Property Manager() As IModuleManager
        Get
            Return ModuleManager.DefaultManager
        End Get
    End Property
    Protected Overridable Sub ConfigureTypeLocators()
        Dim mainAssembly = GetType(MainViewModel).Assembly
        Dim modulesAssembly = GetType(ModuleViewModel).Assembly
        Dim assemblies = {mainAssembly, modulesAssembly}
        ViewModelLocator.[Default] = New ViewModelLocator(assemblies)
        ViewLocator.[Default] = New ViewLocator(assemblies)
    End Sub
    Protected Overridable Sub RegisterModules()
        Manager.Register(Regions.MainWindow, New InjectionModule(AppModules.Main, Function() MainViewModel.Create, GetType(MainView)))
        Manager.Register(Regions.Navigation, New InjectionModule(AppModules.Module1, Function() New NavigationItem("Module1")))
        Manager.Register(Regions.Navigation, New InjectionModule(AppModules.Module2, Function() New NavigationItem("Machine Table")))
        Manager.Register(Regions.Documents, New InjectionModule(AppModules.Module1, Function() ModuleViewModel.Create("Module1", "Module1 Content"), GetType(ModuleView)))
        Manager.Register(Regions.Documents, New InjectionModule(AppModules.Module2, Function() BomViewModel.Create("Machine Table", "R2"), GetType(BomView)))
    End Sub
    Protected Overridable Function RestoreState() As Boolean
#If Not DEBUG Then
        If Settings.[Default].StateVersion <> StateVersion Then
            Return False
        End If
        Return Manager.Restore(Settings.[Default].LogicalState, Settings.[Default].VisualState)
#Else
	    Return False
#End If
    End Function
    Protected Overridable Sub InjectModules()
        Manager.Inject(Regions.MainWindow, AppModules.Main)
        Manager.Inject(Regions.Navigation, AppModules.Module1)
        Manager.Inject(Regions.Navigation, AppModules.Module2)
    End Sub
    Protected Overridable Sub ConfigureNavigation()
        AddHandler Manager.GetEvents(Regions.Navigation).Navigation, AddressOf OnNavigation
        AddHandler Manager.GetEvents(Regions.Documents).Navigation, AddressOf OnDocumentsNavigation
    End Sub
    Protected Overridable Sub ShowMainWindow()
        App.Current.MainWindow = New MainWindow()
        App.Current.MainWindow.Show()
        AddHandler App.Current.MainWindow.Closing, AddressOf OnClosing
    End Sub
    Private Sub OnNavigation(sender As Object, e As NavigationEventArgs)
        If e.NewViewModelKey Is Nothing Then
            Return
        End If
        Manager.InjectOrNavigate(Regions.Documents, e.NewViewModelKey)
    End Sub
    Private Sub OnDocumentsNavigation(sender As Object, e As NavigationEventArgs)
        Manager.Navigate(Regions.Navigation, e.NewViewModelKey)
    End Sub
    Private Sub OnClosing(sender As Object, e As CancelEventArgs)
        Dim logicalState As String = Nothing
        Dim visualState As String = Nothing
        Manager.Save(logicalState, visualState)
        Settings.[Default].StateVersion = StateVersion
        Settings.[Default].LogicalState = logicalState
        Settings.[Default].VisualState = visualState
        Settings.[Default].Save()
    End Sub
End Class