'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Quote
    Public Property ID As Integer
    Public Property CustomerID As Nullable(Of Integer)
    Public Property Ref As String
    Public Property [Date] As Nullable(Of Date)
    Public Property Currency As String = "GBP"
    Public Property CarriageText As String
    Public Property CarriageCost As Nullable(Of Decimal)
    Public Property Notes As String
    Public Property GBPEquiv As Nullable(Of Decimal)
    Public Property DiscountFraction As Nullable(Of Decimal)

    Public Overridable Property Customer As Customer
    Public Overridable Property QuoteDetails As ICollection(Of QuoteDetail) = New HashSet(Of QuoteDetail)

End Class
