Imports DevExpress.Mvvm.POCO

Namespace ViewModels
    Public Class MainViewModel
        Public Shared Function Create() As MainViewModel
            Return ViewModelSource.Create(Function() New MainViewModel())
        End Function
    End Class
End Namespace
