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

Partial Public Class Spare_Part
    Public Property PartID As Integer
    Public Property Price As Nullable(Of Decimal)
    Public Property Price_Updated As Nullable(Of Date)
    Public Property Dollar_Price As Nullable(Of Decimal)
    Public Property C_Price_Updated As Nullable(Of Date)
    Public Property Notes As String
    Public Property Customer_Notes As String
    Public Property upsize_ts As Byte()

    Public Overridable Property Part As Part

End Class