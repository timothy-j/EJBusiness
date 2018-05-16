Imports EJControls

Public Class EJTextColumn
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

    ' TO DO: override Clone() method
End Class

Public Class JEntityCell
    Inherits DataGridViewTextBoxCell
    Implements IEntityCell

    Public Property Entity As Object Implements IEntityCell.Entity
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    ' TO DO: override Clone() method
End Class
