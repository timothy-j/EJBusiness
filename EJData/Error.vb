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

Partial Public Class [Error]
    Public Property ID As Integer
    Public Property PartID As Nullable(Of Integer)
    Public Property ErrorDescription As String
    Public Property OrderID As Nullable(Of Integer)
    Public Property ActionTaken As String

    Public Overridable Property Order As Order
    Public Overridable Property Part As Part

End Class