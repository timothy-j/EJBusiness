Public NotInheritable Class Modules

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Main() As String
        Get
            Return "Main"
        End Get
    End Property
    Public Shared ReadOnly Property Module1() As String
        Get
            Return "Module1"
        End Get
    End Property
    Public Shared ReadOnly Property Module2() As String
        Get
            Return "Module2"
        End Get
    End Property
End Class