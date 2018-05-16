Imports EJControls

Public Class EJEntityColumn
    Inherits DataGridViewTextBoxColumn
    Implements IEntityColumn

    Public Property EntityType As Type Implements IEntityColumn.EntityType
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Type)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property EntityProperty As String Implements IEntityColumn.EntityProperty
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property
End Class
