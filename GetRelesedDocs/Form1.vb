Public Class Form1
    Private Sub Btn_Go_Click(sender As Object, e As EventArgs) Handles Btn_Go.Click
        Try
            Dim partsList() As String
            partsList = Split(Me.SearchValues.Text, ",")

            For i = 0 To UBound(partsList)
                partsList(i) = Trim(partsList(i))
            Next

            Call getFilesAtDir(partsList)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try
    End Sub

    Sub getFilesAtDir(nameList() As String)

        Dim releasedDocsPath As String = "\\whidbey\data_server\Released Documents"


        If System.IO.Directory.Exists(releasedDocsPath) Then

            Dim filesToCopy() As String
            ReDim filesToCopy(UBound(nameList))

            For i = 0 To UBound(nameList)
                For Each filename As String In IO.Directory.GetFiles(releasedDocsPath, nameList(i) & " * ", IO.SearchOption.AllDirectories)
                    If IO.Path.GetExtension(filename) = ".zip" Then
                        filesToCopy(i) = filename
                    End If
                Next
            Next

            Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            desktopPath = desktopPath & "\" & "outputFiles_" & Now.Hour.ToString & Now.Minute.ToString & Now.Second.ToString

            IO.Directory.CreateDirectory(desktopPath)

            Dim errMsg As String = ""

            For i = 0 To UBound(filesToCopy)
                If filesToCopy(i) <> "" Then
                    My.Computer.FileSystem.CopyFile(filesToCopy(i), desktopPath & "\" & System.IO.Path.GetFileName(filesToCopy(i)), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                Else
                    errMsg = errMsg & nameList(i) & vbNewLine
                End If
            Next

            If errMsg <> "" Then
                MsgBox("Files have been copied to your desktop. The following files were not located:" & vbNewLine & errMsg,, "Error")
            Else
                MsgBox("Files have been copied to your desktop.",, "Complete")
            End If
        Else
            Err.Raise(1,, "Cannot locate released documents on server and path '" & releasedDocsPath)
        End If

    End Sub
End Class
