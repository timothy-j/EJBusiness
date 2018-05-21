''' <summary>
''' Common EJ functions and classes
''' </summary>
Public Module EJHelpers

    ''' <summary>
    ''' Opens the part's specified drawing/file/folder in it's default program
    ''' The machine folder is automatically calculated from the part name
    ''' </summary>
    ''' <param name="DrawingType">File type without dot (e.g. dwg) or #[relative file/folder address] (e.g. #../Pictures or #../Pictures/001.jpg)</param>
    ''' <param name="Part">The full part number, e.g. F2-FR26B</param>
    ''' <remarks></remarks>
    Function FollowDrawingLink(DrawingType As String, Part As String) As Boolean
        'On Error GoTo Err
        'DoCmd.SetWarnings False
        Dim dwgString As String = ""
        Try

            If IsNothing(DrawingType) Then
                MsgBox("No drawing type or filename has been entered for this file")
                Return False
            ElseIf InStr(DrawingType, "#") Then '> 0 Then
                ' TO DO: put base path in user settings
                ' Converts #MC-AS00 to MC\MC-AS00
                Dim partString As String = DrawingType.Substring(DrawingType.IndexOf("#") + 1) 'Right(DrawingType, Len(DrawingType) - InStr(DrawingType, "#"))
                Dim folderString As String = ""
                'If Not (InStr(partString, "\") Or InStr(partString, "/")) Then folderString = partString.Substring(0, partString.IndexOf("-")) + "\"
                If Not (partString.Contains("\") Or partString.Contains("/")) Then folderString = partString.Substring(0, partString.IndexOf("-")) + "\"
                dwgString = "\\SERVER2\Business\Drawings\" + folderString + partString
                Process.Start(dwgString)
                Return False
            End If

            Select Case DrawingType
                Case "pdm"
                    MsgBox("Code hasn't been written to view pdm parts yet.")
                Case Else
                    dwgString = "\\SERVER2\Business\Drawings\" + Part.Substring(0, Part.IndexOf("-")) + "\" + Part + "." + DrawingType
                    Process.Start(dwgString)
            End Select

        Catch ex As Exception
            MsgBox("Error opening drawing '" + dwgString + "': " + vbNewLine + ex.Message)
            Return False
        End Try
        '        If IsNothing(DrawingType) Then
        '            MsgBox("No drawing type or filename has been entered for this file")
        '        ElseIf DrawingType = "tif" Then
        '            DoCmd.OpenForm "DrawingDisplay"
        '            Form_DrawingDisplay.Picture = "Z:\Drawings\" + Part + "." + DrawingType
        '        ElseIf DrawingType = "pdm" Then
        '            'MsgBox "[displays options regarding opening file...]"
        '            DoCmd.OpenForm("PDMWorks Options", , , , , , Part)
        '        ElseIf InStr(DrawingType, "#") > 0 Then
        '            'Check for pdm part...
        '            If Right(DrawingType, 3) = "pdm" Then
        '                Dim dwg As String
        '                dwg = Mid(DrawingType, 2, Len(DrawingType) - 5)
        '                DoCmd.OpenForm("PDMWorks Options", , , , , , dwg)
        '                Exit Sub
        '            End If

        '            DoCmd.OpenForm "OpeningLink"
        '            'Opens file as specified in Drawing Type
        '            FollowHyperlink Right(DrawingType, Len(DrawingType) - InStr(DrawingType, "#"))
        '            DoCmd.Close(acForm, "OpeningLink")
        '        Else
        '            DoCmd.OpenForm "OpeningLink"
        '            'Opens file by part number
        '            FollowHyperlink Part + "." + DrawingType ' + "#"
        '            DoCmd.Close(acForm, "OpeningLink")
        '        End If
        '        DoCmd.SetWarnings True
        '        Exit Sub
        'Err:
        '        DoCmd.SetWarnings True
        '        'MsgBox err.Number & err.Description
        '        If Err.Number = 490 Then 'The file has not been found
        '            DoCmd.Close(acForm, "OpeningLink")
        '            MsgBox("File does not exist." + Chr(13) + "Check that the drawing name has been entered correctly and that it isn't a 'GE' drawing" + Chr(13) + _
        '                "(in which case type # and the correct drawing name into the Drawing Type field)", vbExclamation)
        '        ElseIf Err.Number = 2220 Then
        '            DoCmd.Close(acForm, "DrawingDisplay")
        '            MsgBox("File does not exist." + Chr(13) + "Check that the drawing name has been entered correctly and that it isn't a 'GE' drawing" + Chr(13) + _
        '                "(in which case type # and the correct drawing name into the Drawing Type field)", vbExclamation)
        '        End If
        Return True
    End Function

    ''' <summary>
    ''' Gets the URL of the part's specified drawing/file as a string
    ''' The machine folder is automatically calculated from the part name
    ''' </summary>
    ''' <param name="DrawingType">File type without dot (e.g. dwg) or #[relative file/folder address] (e.g. #../Pictures or #../Pictures/001.jpg)</param>
    ''' <param name="Part">The full part number, e.g. F2-FR26B</param>
    ''' <returns>Full file URL</returns>
    Function GetDrawingLink(DrawingType As String, Part As String) As String
        'On Error GoTo Err
        'DoCmd.SetWarnings False
        Dim dwgString As String = ""
        'Try

        If IsNothing(DrawingType) Then
            Throw New Exception("No drawing type or filename has been entered for this file")
            'MsgBox("No drawing type or filename has been entered for this file")
            Return ""
        ElseIf InStr(DrawingType, "#") Then '> 0 Then
            ' TO DO: put base path in user settings
            ' Converts #MC-AS00 to MC\MC-AS00
            Dim partString As String = Right(DrawingType, Len(DrawingType) - InStr(DrawingType, "#"))
            Dim folderString As String = ""
            If Not (InStr(partString, "\") Or InStr(partString, "/")) Then folderString = partString.Substring(0, partString.IndexOf("-")) + "\"
            dwgString = "\\SERVER2\Business\Drawings\" + folderString + partString
            'Process.Start(dwgString)
            Return dwgString
        End If

        Select Case DrawingType
            Case "pdm"
                Throw New Exception("Code hasn't been written to access drawing files for pdm parts yet.")
                'MsgBox("Code hasn't been written to access drawing files for pdm parts yet.")
            Case Else
                dwgString = "\\SERVER2\Business\Drawings\" + Part.Substring(0, Part.IndexOf("-")) + "\" + Part + "." + DrawingType
                'Process.Start(dwgString)
                Return dwgString
        End Select

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Return ""
        'End Try
        Return dwgString
    End Function

    Function OpenOrderView(Status As String) As Boolean
        ' HACK: TODO: get order number from string or warn if not available
        Dim order As String = CInt(Status.Substring(Status.IndexOf("-") + 1))
        If order = 0 Then
            MsgBox("No order number specified")
            Return False
        End If
        Dim frm As New EJOrderView.OrderView
        frm.Order = order
        frm.Show()
        Return True
    End Function

End Module
