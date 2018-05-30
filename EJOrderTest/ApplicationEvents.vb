Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            ' TODO: check the command line args and perform the relevant action(s)
            ProcessArgs(e.CommandLine.ToArray)
            ' HACK: make ProcessArgs a Function and bring application to foreground
            ' only if no other action is taken
            e.BringToForeground = False
        End Sub

        Public Sub ProcessArgs(cmdArgs() As String)
            ' The first argument is the file name, so only one arg means no user args
            Dim args As List(Of String) = cmdArgs.ToList
            If args.Count <= 1 Then Exit Sub

            For Each arg As String In args
                ' If a table is specified (in the form 'Table [machine type]'), open it
                If arg = "Table" Then
                    ' Ignore if this is the last argument (i.e. there is no machine type)
                    If args.IndexOf(arg) = args.Count - 1 Then Exit Sub
                    Dim o = New GeneralBOMTable
                    o.MachineType = args(args.IndexOf(arg) + 1)
                    o.Show()
                End If
            Next
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            ProcessArgs(e.CommandLine.ToArray)
        End Sub
    End Class
End Namespace
