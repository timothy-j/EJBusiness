Public Class TestContainer
    Private _db As EJData.CorporateEntities

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _db = EJData.DataHelpers.GetNewDbContext
        Dim partsList = From p In _db.Parts
                        Order By p.PartNo
        PartBindingSource.DataSource = partsList.ToList
    End Sub
End Class
