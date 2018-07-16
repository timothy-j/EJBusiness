Imports DevExpress.Mvvm
Imports EJBusiness.Common
Imports System

Namespace ViewModels
    <Serializable>
    Public Class NavigationItem
        Implements INavigationItem, ISupportState(Of NavigationItem)

        Public Property Caption() As String Implements INavigationItem.Caption
        Public Sub New()
        End Sub
        Public Sub New(ByVal caption As String)
            Me.Caption = caption
        End Sub

#Region "Serialization"
        Private Function ISupportSerializationGeneric_SaveState() As NavigationItem Implements ISupportState(Of NavigationItem).SaveState
            Return Me
        End Function
        Private Sub ISupportSerializationGeneric_RestoreState(ByVal state As NavigationItem) Implements ISupportState(Of NavigationItem).RestoreState
            Caption = state.Caption
        End Sub
#End Region
    End Class
End Namespace
