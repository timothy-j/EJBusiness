Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports EJBusiness.Common
Imports System

Namespace ViewModels
    Public Class ModuleViewModel
        Implements IDocumentModule, ISupportState(Of ModuleViewModel.Info)

        Public Overridable Property Caption() As String Implements IDocumentModule.Caption
        Public Overridable Property IsActive() As Boolean Implements IDocumentModule.IsActive
        Public Overridable Property Content() As String

        Public Shared Function Create(ByVal caption As String, ByVal content As String) As ModuleViewModel
            Return ViewModelSource.Create(Function() New ModuleViewModel() With {.Caption = caption, .Content = content})
        End Function
        Protected Sub New()
        End Sub

#Region "Serialization"
        <Serializable>
        Public Class Info
            Public Property Content() As String
            Public Property Caption() As String
        End Class
        Private Function ISupportSerializationGeneric_SaveState() As Info Implements ISupportState(Of Info).SaveState
            Return New Info() With {.Content = Me.Content, .Caption = Me.Caption}
        End Function
        Private Sub ISupportSerializationGeneric_RestoreState(ByVal state As Info) Implements ISupportState(Of Info).RestoreState
            Me.Content = state.Content
            Me.Caption = state.Caption
        End Sub
#End Region
    End Class
End Namespace
