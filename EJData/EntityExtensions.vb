
Imports System.Data.Entity.Core.Objects
Imports System.Data.Entity.Infrastructure

' Partial classes containing additional entity properties etc.
' e.g. flat access to related 1:1 table properties

Partial Public Class Item

    'Public Property Stock() As Double?
    '    Get
    '        If Part.Stock.HasValue Then Return Decimal.ToDouble(Part.Stock)
    '        Return Nothing
    '    End Get
    '    Set(ByVal value As Double?)
    '        Part.Stock = value
    '    End Set
    'End Property

    Public Property Qty() As Double?
        Get
            If Me.oQty.HasValue Then Return Decimal.ToDouble(oQty)
            Return Nothing
        End Get
        Set(ByVal value As Double?)
            oQty = value
        End Set
    End Property

End Class

Partial Public Class OrderDetail

    Public Property Price() As Double?
        Get
            If Me.oPrice.HasValue Then Return Decimal.ToDouble(oPrice)
            Return Nothing
        End Get
        Set(ByVal value As Double?)
            oPrice = value
        End Set
    End Property

    Public Property UnitPrice() As Double?
        Get
            If Me.oUnitPrice.HasValue Then Return Decimal.ToDouble(oUnitPrice)
            Return Nothing
        End Get
        Set(ByVal value As Double?)
            oUnitPrice = value
        End Set
    End Property

End Class

Partial Public Class [Order]

    Public ReadOnly Property FullNameAddress() As String
        Get
            Dim str As String
            If Me.Supplier1 Is Nothing Then Return ""
            With Me.Supplier1
                str = .Supplier1 + vbNewLine
                If Not .Address1 Is Nothing Then str = str + .Address1 + vbNewLine
                If Not .Address2 Is Nothing Then str = str + .Address2 + vbNewLine
                If Not .Address3 Is Nothing Then str = str + .Address3 + vbNewLine
                If Not .Address4 Is Nothing Then str = str + .Address4 + vbNewLine
                If Not .Postcode Is Nothing Then str = str + .Postcode + vbNewLine
            End With
            Return RTrim(str)
        End Get
    End Property
End Class