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

Partial Public Class QuoteItemDetail
    Public Property ID As Integer
    Public Property DetailID As Integer
    Public Property ItemID As Nullable(Of Integer)
    Public Property Description As String
    Public Property Quantity As Nullable(Of Decimal)
    Public Property ParentID As Nullable(Of Integer)

    Public Overridable Property Item As Item
    Public Overridable Property QuoteDetail As QuoteDetail
    Public Overridable Property Children As ObservableListSource(Of QuoteItemDetail) = New ObservableListSource(Of QuoteItemDetail)
    Public Overridable Property Parent As QuoteItemDetail

End Class
