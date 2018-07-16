Imports EJBusiness.Common
Imports NUnit.Framework
Imports System.Threading
Imports AppModules = EJBusiness.Common.Modules

<TestFixture>
Public Class NavigationTests
    Inherits BaseTestFixture

    <Test>
    Public Sub InitialModules()
        Assert.IsNotNull(Manager.GetRegion(Regions.MainWindow).GetViewModel(AppModules.Main))
        Assert.IsNotNull(Manager.GetRegion(Regions.Navigation).GetViewModel(AppModules.Module1))
        Assert.IsNotNull(Manager.GetRegion(Regions.Navigation).GetViewModel(AppModules.Module2))
        Assert.IsNull(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module1))
        Assert.IsNull(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module2))
    End Sub
    <Test>
    Public Sub Navigation()
        Assert.IsNull(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module1))
        Assert.IsNull(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module2))

        Manager.Navigate(Regions.Navigation, AppModules.Module1)
        Assert.IsNotNull(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module1))
        Assert.IsNull(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module2))

        Manager.Navigate(Regions.Navigation, AppModules.Module2)
        Assert.IsNotNull(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module1))
        Assert.IsNotNull(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module2))

        Manager.Navigate(Regions.Documents, AppModules.Module1)
        Assert.AreEqual(AppModules.Module1, Manager.GetRegion(Regions.Navigation).SelectedKey)
    End Sub
End Class
<TestFixture, Category("Functional"), Apartment(ApartmentState.STA)>
Public Class FunctionalNavigationTests
    Inherits BaseTestFixture

    Protected Overrides ReadOnly Property IsFunctionalTesting() As Boolean
        Get
            Return True
        End Get
    End Property
    <Test>
    Public Sub Navigation()
        Manager.Navigate(Regions.Navigation, AppModules.Module1)
        DoEvents()
        Dim document1 = DirectCast(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module1), IDocumentModule)
        Assert.IsTrue(document1.IsActive)

        Manager.Navigate(Regions.Navigation, AppModules.Module2)
        DoEvents()
        Dim document2 = DirectCast(Manager.GetRegion(Regions.Documents).GetViewModel(AppModules.Module2), IDocumentModule)
        Assert.IsFalse(document1.IsActive)
        Assert.IsTrue(document2.IsActive)

        document1.IsActive = True
        DoEvents()
        Assert.IsTrue(document1.IsActive)
        Assert.IsFalse(document2.IsActive)
        Assert.AreEqual(AppModules.Module1, Manager.GetRegion(Regions.Navigation).SelectedKey)
    End Sub
End Class