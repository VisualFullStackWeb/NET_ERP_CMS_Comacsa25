Imports System.IO
Imports Scripting
Imports System.Text
Public Class FrmActualizar
    Private Sub FrmActualizar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tFiles() As String
        Dim fs As New Object
        Dim f As New Object
        Dim sPath As String = "C:\ERP_Comacsa\dlls"

        Dim sFile = "\\10.10.10.33\SISCOMACSA$\Ejecutables\ERP_Comacsa\dlls"
        'Dim obj As New FileSystemObject
        If Not System.IO.Directory.Exists(sFile) Then
            sFile = "\\10.10.10.35\SISCOMACSA$\Ejecutables\ERP_Comacsa\dlls"
        End If

        Dim FSO As New FileSystemObject
        Dim I As Integer
        Dim lNameFile As String = String.Empty
        Dim lNameFile2 As String = String.Empty
        FSO = New FileSystemObject
        Dim xFiles As Integer = Directory.GetFiles(sFile).Length
        ReDim tFiles(xFiles)
        tFiles = Directory.GetFiles(sFile)
        Dim X As Integer
        Barra.Maximum = xFiles
        Me.Show()
        For I = 0 To xFiles - 1
            lNameFile = String.Empty
            lNameFile2 = String.Empty
            For X = Len(tFiles(I)) To 0 Step -1
                If Mid(tFiles(I), X, 1) = "\" Then
                    Exit For
                Else
                    lNameFile = Mid(tFiles(I), X, 1) + lNameFile
                End If
            Next
            lNameFile2 = sPath & "\" & lNameFile
            lNameFile = sFile & "\" & lNameFile

            If lNameFile.ToString.Substring(lNameFile.Length - 3, 3) <> "xls" Then
                If FSO.FileExists(lNameFile2) Then
                    If FileSystem.FileDateTime(lNameFile) <> FileSystem.FileDateTime(lNameFile2) Then
                        fs = CreateObject("Scripting.FileSystemObject")
                        f = fs.getfile(lNameFile)
                        f.Copy(lNameFile2, True)
                    End If
                Else
                    fs = CreateObject("Scripting.FileSystemObject")
                    f = fs.getfile(lNameFile)
                    f.Copy(lNameFile2, True)
                End If
                Barra.Value = I
                Me.Refresh()
            End If
        Next
        Process.Start(sPath & "\SIP_Presentacion.exe")
        Me.Dispose()
        Me.Close()
        End
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class
