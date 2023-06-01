Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Windows.Forms.Clipboard
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Diagnostics

Public Class Form1
    Public hashThings As New hashChecking
    Public Shared filePath
    Public Shared mdHash, shaHash, shaIHash, shaFITHash, nowTime, fileSize

    Private Function GetLatestVersion(repository As String) As String
        Dim apiUrl As String = "https://api.github.com/repos/" & repository & "/releases/latest"

        Try
            Dim client As New WebClient()
            client.Headers.Add("User-Agent", "Mozilla/5.0") ' 設定使用者代理

            ' 發送 HTTP GET 請求並獲取回應
            Dim response As String = client.DownloadString(apiUrl)

            ' 解析 JSON 回應，獲取最新版本號
            Dim regex As New Regex("""tag_name"": ""(.*?)""")
            Dim match As Match = regex.Match(response)
            If match.Success Then
                Return match.Groups(1).Value
            Else
                Return "無法獲取版本號"
            End If
        Catch ex As Exception
            Return "檢查更新時發生錯誤: " & ex.Message
        End Try
    End Function

    Sub updateChecker()
        Dim repository As String = "510208/MD5Hashing-NEW" ' 請替換為實際的 GitHub 存儲庫

        Dim latestVersion As String = GetLatestVersion(repository)
        MessageBox.Show("最新版本號:" & latestVersion)
    End Sub

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
        ' 初始化前一次的表單大小
        Me.PreviousSize = Me.Size
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Clipboard.SetText(txtPath.Text & vbCrLf & txtList.Text)
    End Sub

    Private Sub btnCheckFile_Click(sender As Object, e As EventArgs) Handles btnCheckFile.Click
        frmCheck.Show()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveFileDialog1.ShowDialog()
        ' 取得 TextBox 的文字內容
        Dim textContent As String = txtList.Text

        ' 將文字內容寫入到檔案
        File.WriteAllText(SaveFileDialog1.FileName, textContent)

        MessageBox.Show("檔案已儲存")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("Rundll32.exe url.dll, FileProtocolHandler https://github.com/510208/md5hashing-new", vbNormalFocus)
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        End
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' 開啟更新介面
        ' 在這裡實現打開更新檔所在的介面的程式碼
        frmUpdate.Show()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        For Each control As Control In Me.Controls
            ' 只處理可見的控制項
            If control.Visible Then
                ' 計算控制項的新位置和大小
                Dim newLocation As New Point(control.Location.X * Me.Width / Me.PreviousSize.Width, control.Location.Y * Me.Height / Me.PreviousSize.Height)
                Dim newSize As New Size(control.Width * Me.Width / Me.PreviousSize.Width, control.Height * Me.Height / Me.PreviousSize.Height)

                ' 設定控制項的新位置和大小
                control.Location = newLocation
                control.Size = newSize
            End If
        Next

        ' 更新前一次的表單大小
        Me.PreviousSize = Me.Size

        ' 將line長度設為總長
        LineShape1.X2 = Me.Width

    End Sub

    Private Sub Form1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim DragFilePath As String = CType(e.Data.GetData("FileNameW"), Array).GetValue(0)
        MsgBox(DragFilePath)
    End Sub

    Private Property PreviousSize As Size

    Private Sub gpbDropFile_DragEnter(sender As Object, e As DragEventArgs)
        ' 確定拖曳的資料是檔案
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            ' 允許拖曳動作
            e.Effect = DragDropEffects.Copy
        Else
            ' 禁止拖曳動作
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub gpbDropFile_DragDrop(sender As Object, e As DragEventArgs)
        ' 取得拖曳進來的檔案路徑
        Dim files As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length > 0 Then
            ' 取得第一個檔案的路徑
            filePath = files(0)
            ' 在這裡可以進一步處理 filePath 變數
            ' 例如顯示檔案路徑或進行其他相關操作
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
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmInfo.Show()
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