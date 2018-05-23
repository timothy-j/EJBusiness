Public Module DataHelpers

    ''' <summary>
    ''' Creates a new CorporateEntities from centralised connection string
    ''' </summary>
    ''' <returns></returns>
    Function GetNewDbContext() As CorporateEntities

        ' Specify the provider name, server and database. 
        Dim providerName As String = "System.Data.SqlClient"
        Dim serverName As String = "TIMLAPTOP2015"
        Dim databaseName As String = "CorporatePlus"

        ' Initialize the connection string builder for the 
        ' underlying provider. 
        Dim sqlBuilder As New SqlClient.SqlConnectionStringBuilder()

        ' Set the properties for the data source. 
        sqlBuilder.DataSource = serverName
        sqlBuilder.InitialCatalog = databaseName
        sqlBuilder.IntegratedSecurity = True

        ' Build the SqlConnection connection string. 
        Dim providerString As String = sqlBuilder.ToString()

        ' Initialize the EntityConnectionStringBuilder. 
        Dim entityBuilder As New Entity.Core.EntityClient.EntityConnectionStringBuilder()

        'Set the provider name. 
        entityBuilder.Provider = providerName

        ' Set the provider-specific connection string. 
        entityBuilder.ProviderConnectionString = providerString

        ' Set the Metadata location. 
        entityBuilder.Metadata = "res://*/AllData.csdl|res://*/AllData.ssdl|res://*/AllData.msl"

        ' NOTE: if this does not compile, add the following custom constructor to CorporateEntities
        ' Class, ideally via AllData.Context.tt file
        '         Public Sub New(connectionString As String)
        '             MyBase.New(connectionString)
        '         End Sub
        ' This may be necessary if the data model has been rebuilt
        Return New EJData.CorporateEntities(entityBuilder.ToString)
    End Function

End Module
