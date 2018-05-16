Imports System.Data.Common
Imports System.Data.Entity.Core.Objects
Imports System.Dynamic
Imports System.Linq.Expressions
Imports System.Linq.Dynamic
Imports System.Linq
Imports System.Data.Entity
Imports System.Reflection
'Imports System.Reflection
Imports System.Runtime.CompilerServices


Public Class DGTest
    Private _db As EJData.CorporateEntities

    'Function CreateNewStatement(fields As String) As Expression(Of Func(Of IQueryable, IQueryable))
    '    Dim xParameter = Expression.Parameter(GetType(EJData.MachineItem), "o")
    '    Dim xNew = Expression.New(New GetType(EJData.MachineItem))

    'End Function

    Structure SuppliedMachineItem
        Private _i As EJData.Item
        Public Property Item() As EJData.Item
            Get
                Return _i
            End Get
            Set(ByVal value As EJData.Item)
                _i = value
            End Set
        End Property
        Private _mi As EJData.MachineItem
        Public Property MachineItem() As EJData.MachineItem
            Get
                Return _mi
            End Get
            Set(ByVal value As EJData.MachineItem)
                _mi = value
            End Set
        End Property
    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Fill data sources
        _db = EJData.DataHelpers.GetNewDbContext

        Try

            'Must fill combobox source before form source otherwise combobox will initially contain wrong value

            ' As IQueryable(Of SuppliedMachineItem)
            Dim items2 As IQueryable(Of SuppliedMachineItem) = (From i In _db.Items, mi In _db.MachineItems
                                                                Where mi.Machine.Supplied = False And i.MachineItems.Contains(mi)
                                                                Order By mi.MachineID, i.Item1
                                                                Select i, mi).AsQueryable 'i.ID, Item1 = i.Model + "-" + i.Item1, Q250 = mi.Qty, S250 = mi.Status, mi.MachineID


            Dim parameters(-1) As ObjectParameter

            Dim columnsToSelect() As Integer = New Integer() {1, 2, 4, 5}
            'Dim items3 = items2.Select("new (ID, MachineID)")



            'From i In _db.Items, mi In _db.MachineItems
            'Where mi.Machine.Supplied = False And i.MachineItems.Contains(mi)
            'Order By mi.MachineID, i.Item1
            'Select i.ID, Item = i.Model + "-" + i.Item1, Q250 = mi.Qty, S250 = mi.Status, mi.MachineID


            'Dim qStr As String = "SELECT i.ID, i.Item1, m.Qty, m.Status " +
            '    "FROM CorporateEntities.Items AS i, CorporateEntities.MachineItems AS m " +
            '    "WHERE m.ItemID = i.ID AND m.MachineId = 250"

            'Dim myContext As ObjectContext = _db.ObjectContext()
            'Dim items As ObjectQuery
            'Try
            '    items = myContext.CreateQuery(Of DbDataRecord)(qStr, parameters)
            '    TableBindingSource.DataSource = items
            'Catch ex As Exception
            '    MsgBox("Please show Tim the following message:" & vbNewLine & vbNewLine & ex.Message)
            '    Me.Close()
            'End Try

            TableGridView.DataSource = items2.ToList '.Select("new (Item1, MachineID)") 'TableBindingSource

        Catch ex As Exception
        End Try
    End Sub

End Class

