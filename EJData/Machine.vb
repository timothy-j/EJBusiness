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

Partial Public Class Machine
    Public Property Type As String
    Public Property Number As Short
    Public Property Year As Nullable(Of Short)
    Public Property Supplied_to As String
    Public Property OwnerID As Nullable(Of Integer)
    Public Property Edward_s_notes As String
    Public Property Rachel_s_notes As String
    Public Property Supplied As Boolean
    Public Property Model As String
    Public Property OrderDetailID As Nullable(Of Integer)

    Public Overridable Property Customer As Customer
    Public Overridable Property MachineItems As ObservableListSource(Of MachineItem) = New ObservableListSource(Of MachineItem)
    Public Overridable Property CustOrderDetail As CustOrderDetail

End Class
