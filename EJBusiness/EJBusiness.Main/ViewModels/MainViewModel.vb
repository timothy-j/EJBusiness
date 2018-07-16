Imports DevExpress.Mvvm.ModuleInjection ' Added for module injection test
Imports DevExpress.Mvvm.POCO
Imports EJBusiness.Common ' Added for module injection test
Imports EJBusiness.Modules ' Added for module injection test

Namespace ViewModels
    Public Class MainViewModel
        Public Sub New()
            Dim machines As String() = {"HX", "R2", "F2", "W3", "All"}
            For Each machine In machines
                ModuleManager.DefaultManager.Register(Regions.Navigation, New [Module](machine & "_Table", Function() New NavigationItem(machine)))
                ModuleManager.DefaultManager.Register(Regions.Documents, New [Module](machine & "_Table", Function() Modules.ViewModels.BomViewModel.Create(machine, machine), GetType(BomView)))
                ModuleManager.DefaultManager.Inject(Regions.Navigation, machine & "_Table")
            Next

        End Sub

        Public Shared Function Create() As MainViewModel
            Return ViewModelSource.Create(Function() New MainViewModel())
        End Function
    End Class
End Namespace
