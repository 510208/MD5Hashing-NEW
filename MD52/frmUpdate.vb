Imports System.Diagnostics

Public Class frmUpdate

    Private Sub btnNoUpdate_Click(sender As Object, e As EventArgs) Handles btnNoUpdate.Click
        ' 關閉視窗
        Me.Close()
    End Sub

    Public Function ExecutePythonScript() As String
        Dim pythonPath As String = "python" ' 如果您的Python執行檔案路徑不是預設的，請修改為正確的路徑
        Dim scriptPath As String = "MD5HashingUpdate.py" ' 將路徑替換為您的Python腳本路徑

        Dim process As New Process()
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = pythonPath
        startInfo.Arguments = scriptPath
        startInfo.UseShellExecute = False
        startInfo.RedirectStandardOutput = True
        startInfo.CreateNoWindow = True
        process.StartInfo = startInfo
        process.Start()

        Dim output As String = process.StandardOutput.ReadToEnd()
        process.WaitForExit()

        Return output
    End Function

    Private Function GetLatestVersion(output As String) As String
        ' 解析Python腳本回傳值中的最新版本號
        ' 根據您的回傳值格式進行解析，這裡僅提供示例
        ' 請根據您的回傳值進行適當的處理
        Dim versionLine As String = output.Trim()
        Dim latestVersion As String = versionLine.Substring(versionLine.IndexOf(":") + 1).Trim()
        Return latestVersion
    End Function

    Private Function GetChangelog(output As String) As String
        ' 解析Python腳本回傳值中的更新日誌
        ' 根據您的回傳值格式進行解析，這裡僅提供示例
        ' 請根據您的回傳值進行適當的處理
        Dim lines() As String = output.Split(vbCrLf)
        Dim changelog As String = lines(1).Trim()
        Return changelog
    End Function

    Private Function GetFirstLine(text As String) As String
        Dim lines() As String = text.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        If lines.Length > 0 Then
            Return lines(0)
        Else
            Return String.Empty
        End If
    End Function

    Private Function RemoveFirstLineAndReturnRemainingLines(text As String) As String
        Dim lines() As String = text.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        If lines.Length > 1 Then
            Return String.Join(Environment.NewLine, lines, 1, lines.Length - 1)
        Else
            Return String.Empty
        End If
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' 開啟更新介面
        ' 在這裡實現打開更新檔所在的介面的程式碼
        Dim url As String = "https://github.com/510208/MD5Hashing-NEW/releases/latest"
        ' 使用預設的瀏覽器打開網址
        Process.Start(url)
    End Sub

    Private Sub frmUpdate_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
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
    End Sub

    Private Sub frmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 初始化前一次的表單大小
        Me.PreviousSize = Me.Size
        Me.Icon = Form1.Icon
        Dim latestVersion = GetLatestVersion(GetFirstLine(ExecutePythonScript()))
        Dim changeLog = GetChangelog(ExecutePythonScript())
        Dim localVersion = Application.ProductVersion
        If localVersion < latestVersion Then
            txtNewVersionInfo.Text = ExecutePythonScript()
            Me.Text = "有更新版本：" & latestVersion
        Else
            MsgBox("目前版本已是最新，不須再次更新為更新版本")
            Me.Close()
        End If
    End Sub

    Private Property PreviousSize As Size
End Class
