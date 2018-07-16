Public NotInheritable Class Regions

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property MainWindow() As String
        Get
            Return "MainWindow"
        End Get
    End Property
    Public Shared ReadOnly Property Documents() As String
        Get
            Return "Documents"
        End Get
    End Property
    Public Shared ReadOnly Property Navigation() As String
        Get
            Return "Navigation"
        End Get
    End Property
End Class