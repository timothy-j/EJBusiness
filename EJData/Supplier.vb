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

Partial Public Class Supplier
    Public Property Entry As Integer
    Public Property Supplier1 As String
    Public Property Code As String
    Public Property TelephoneNumber As String
    Public Property MobileNumber As String
    Public Property FaxNumber As String
    Public Property E_mail As String
    Public Property Website As String
    Public Property Address1 As String
    Public Property Address2 As String
    Public Property Address3 As String
    Public Property Address4 As String
    Public Property Postcode As String
    Public Property Contact_s_ As String
    Public Property Archived As Boolean

    Public Overridable Property Orders As ObservableListSource(Of Order) = New ObservableListSource(Of Order)

End Class