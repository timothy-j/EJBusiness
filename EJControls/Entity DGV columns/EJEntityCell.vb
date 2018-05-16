Imports EJControls

Public Class EJEntityCell
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
