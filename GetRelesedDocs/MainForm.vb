Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt_FilePath.Text = "\\whidbey\data_server\Released Documents"
    End Sub

    Private Sub Btn_Go_Click(sender As Object, e As EventArgs) Handles Btn_Go.Click
        Try

            If Trim(Me.SearchValues.Text) = "" Then
                Err.Raise(1,, "Please enter values before running this macro.")
            End If

            Dim partsList() As String
            partsList = Split(Me.SearchValues.Text, ",")

            For i = 0 To UBound(partsList)
                partsList(i) = Trim(partsList(i))
            Next

            Call getFilesAtDir(partsList)

            ToolStripStatusLabel1.Text = "Status"
            StatusStrip1.Update()
        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try
    End Sub

    Sub getFilesAtDir(nameList() As String)
        If Not IO.Directory.Exists(Txt_FilePath.Text) Then
            Call dirCheck()
            MsgBox("Directory does not exist",, "Error")
            Exit Sub
        End If

        Dim releasedDocsPath As String = Txt_FilePath.Text

        Dim filesToCopy() As String
        ReDim filesToCopy(0)

        ToolStripStatusLabel1.Text = "Searching for your numbers"
        StatusStrip1.Update()

        For Each filename As String In IO.Directory.GetFiles(releasedDocsPath, "*", IO.SearchOption.AllDirectories)
            For i = 0 To UBound(nameList)
                If nameList(i) <> "" And Len(nameList(i)) = 5 Then
                    If InStr(IO.Path.GetFileName(filename), nameList(i)) Then
                        If filesToCopy(0) <> "" Then
                            ReDim Preserve filesToCopy(UBound(filesToCopy) + 1)
                        End If
                        filesToCopy(UBound(filesToCopy)) = filename
                    End If
                End If
            Next
        Next



        Dim errMsg As String = ""

        For i = 0 To UBound(nameList)
            Dim foundEntity As Boolean = 0
            If nameList(i) <> "" And Len(nameList(i)) = 5 Then
                For z = 0 To UBound(filesToCopy)
                    If InStr(IO.Path.GetFileName(filesToCopy(z)), nameList(i)) > 0 Then
                        foundEntity = 1
                    End If
                Next
            End If

            If foundEntity = 0 Then
                errMsg = errMsg & nameList(i) & vbNewLine
            End If
        Next


        Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        desktopPath = desktopPath & "\" & "outputFiles_" & Now.Hour.ToString & Now.Minute.ToString & Now.Second.ToString

        IO.Directory.CreateDirectory(desktopPath)

        If filesToCopy(0) <> "" Then
            For i = 0 To UBound(filesToCopy)
                ToolStripStatusLabel1.Text = "Copying: " & i + 1 & " Of " & UBound(filesToCopy) + 1
                StatusStrip1.Update()

                My.Computer.FileSystem.CopyFile(filesToCopy(i), desktopPath & "\" & System.IO.Path.GetFileName(filesToCopy(i)), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            Next
        End If

        If errMsg <> "" Then
            MsgBox("Files have been copied to your desktop." & vbNewLine & "The following files were not located:" & vbNewLine & errMsg,, "Error")
        Else
            MsgBox("Files have been copied to your desktop.",, "Complete")
        End If


    End Sub

    Private Sub Txt_FilePath_TextChanged(sender As Object, e As EventArgs) Handles Txt_FilePath.TextChanged
        Call dirCheck()
    End Sub

    Private Sub dirCheck()
        If IO.Directory.Exists(Txt_FilePath.Text) Then
            Txt_FilePath.BackColor = Color.White
            SearchValues.Enabled = True
            Btn_Go.Enabled = True
        Else
            Txt_FilePath.BackColor = Color.Red
            SearchValues.Enabled = False
            Btn_Go.Enabled = False
        End If
    End Sub


End Class
