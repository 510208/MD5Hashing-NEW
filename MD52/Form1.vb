Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Windows.Forms.Clipboard

Public Class Form1
    Public hashThings As New hashChecking
    Public Shared filePath
    Public Shared mdHash, shaHash, shaIHash, shaFITHash, nowTime, fileSize

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        OpenFileDialog1.ShowDialog()
        filePath = OpenFileDialog1.FileName
        If filePath = "" Then
            Exit Sub
        End If
        mdHash = hashChecking.md5(filePath)
        shaHash = hashChecking.sha256(filePath)
        shaIHash = hashChecking.sha1(filePath)
        shaFITHash = hashChecking.sha512(filePath)
        nowTime = Now.Hour & ":" & Now.Minute & ":" & Now.Second
        fileSize = FileLen(filePath) / 1024
        txtList.Text = "Time：" & nowTime & vbCrLf & "FileSize：" & Str(Math.Round(fileSize, 2)) & "MB" & vbCrLf & "MD5：" & mdHash & vbCrLf & "SHA256：" & shaHash & vbCrLf & "SHA1：" & shaIHash & vbCrLf & "SHA512：" & shaFITHash
        txtPath.Text = filePath
        frmCheck.md5Code.Text = mdHash
        frmCheck.sha256Code.Text = shaHash
        frmCheck.sha512Code.Text = shaFITHash
        frmCheck.sha1Code.Text = shaIHash
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AllowDrop = True
    End Sub

    Private Sub Form1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim DragFilePath As String = CType(e.Data.GetData("FileNameW"), Array).GetValue(0)
        MsgBox(DragFilePath)
    End Sub

    Private Sub Form1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Clipboard.SetText(txtPath.Text & vbCrLf & txtList.Text)
    End Sub

    Private Sub btnCheckFile_Click(sender As Object, e As EventArgs) Handles btnCheckFile.Click
        frmCheck.Show()
    End Sub
End Class

Public Class hashChecking
    Public Shared Function md5(ByVal path As String) As String
        Dim hash = System.Security.Cryptography.MD5.Create()
        Return ComputeHash(hash, path)
    End Function

    Public Shared Function sha256(ByVal path As String) As String
        Dim hash = System.Security.Cryptography.SHA256.Create()
        Return ComputeHash(hash, path)
    End Function

    Public Shared Function sha1(ByVal path As String) As String
        Dim hash = System.Security.Cryptography.SHA1.Create()
        Return ComputeHash(hash, path)
    End Function

    Public Shared Function sha512(ByVal path As String) As String
        Dim hash = System.Security.Cryptography.SHA512.Create()
        Return ComputeHash(hash, path)
    End Function

    Private Shared Function ComputeHash(ByVal hashAlgorithm As HashAlgorithm, ByVal path As String) As String
        Using stream = File.OpenRead(path)
            Dim hash = hashAlgorithm.ComputeHash(stream)
            Return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant()
        End Using
    End Function
End Class