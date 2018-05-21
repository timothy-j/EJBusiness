Imports EJData.AnonymousTypeExtensions
Imports System.IO
Imports System.Net.Mail
Imports EJEmail

Public Class OrderView

    Private _OrderNo As Integer = 0

    Public Property Order() As Integer
        Get
            If _OrderNo > 0 Then
                Return _OrderNo
            Else
                Dim Ord As Integer = 0
                While Ord = 0
                    Try
                        Ord = CInt(InputBox("Please enter an order number (without suffix)"))
                    Catch
                    End Try
                End While
                _OrderNo = Ord
                Return Ord
            End If
        End Get
        Set(ByVal value As Integer)
            _OrderNo = value
        End Set
    End Property

    Private _db As EJData.CorporateEntities

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _db = EJData.DataHelpers.GetNewDbContext

        ' If there are problems with binding to the report dataset, uncomment the following:
        'Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        'ReportDataSource1.Name = "OrderDS"
        'ReportDataSource1.Value = Me.FlatOrderBindingSource
        'Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

        Dim bs = From o In _db.FlatOrders
                 Where o.Order = Me.Order
                 Select o
        If bs.Count = 0 Then
            MsgBox("Order " & Me.Order & " does not exist.")
            Exit Sub
        End If
        Me.Text = "Order " & Me.Order
        FlatOrderBindingSource.DataSource = bs.ToList
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub SendReportToEmail(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tempPath As String = Path.GetTempPath ' gets User's temp folder url

        File.WriteAllBytes(tempPath & "Order.pdf", ReportViewer1.LocalReport.Render("PDF"))

        Dim mapi As MAPI = New MAPI()
        mapi.AddAttachment(tempPath & "Order.pdf")
        'mapi.AddAttachment("c:\\temp\\file2.txt")
        'mapi.AddRecipientTo("person1@somewhere.com")
        'mapi.AddRecipientTo("person2@somewhere.com")
        mapi.SendMailPopup("testing", "body text")
    End Sub
End Class
