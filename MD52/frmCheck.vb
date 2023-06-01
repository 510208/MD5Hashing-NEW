Public Class frmCheck

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        If ComboBox1.Text = "" Then
            Return
        End If
        Dim hashCode = UCase(TextBox1.Text)
        Select Case ComboBox1.SelectedIndex
            Case 0
                ' MD5
                If UCase(md5Code.Text) = hashCode Then
                    MsgBox("恭喜！" & vbCrLf & "MD5正確，此檔案與您給予的code值是同一檔案", MsgBoxStyle.Information)
                Else
                    MsgBox("錯誤！" & vbCrLf & "MD5錯誤，此檔案與您給予的code值不是同一檔案", MsgBoxStyle.Critical)
                End If
            Case 1
                'SHA1
                If UCase(sha1Code.Text) = hashCode Then
                    MsgBox("恭喜！" & vbCrLf & "SHA1正確，此檔案與您給予的code值是同一檔案", MsgBoxStyle.Information)
                Else
                    MsgBox("錯誤！" & vbCrLf & "SHA1錯誤，此檔案與您給予的code值不是同一檔案", MsgBoxStyle.Critical)
                End If
            Case 2
                ' SHA256
                If UCase(sha256Code.Text) = hashCode Then
                    MsgBox("恭喜！" & vbCrLf & "SHA256正確，此檔案與您給予的code值是同一檔案", MsgBoxStyle.Information)
                Else
                    MsgBox("錯誤！" & vbCrLf & "SHA256錯誤，此檔案與您給予的code值不是同一檔案", MsgBoxStyle.Critical)
                End If
            Case 3
                'SHA512
                If UCase(sha512Code.Text) = hashCode Then
                    MsgBox("恭喜！" & vbCrLf & "SHA512正確，此檔案與您給予的code值是同一檔案", MsgBoxStyle.Information)
                Else
                    MsgBox("錯誤！" & vbCrLf & "SHA512錯誤，此檔案與您給予的code值不是同一檔案", MsgBoxStyle.Critical)
                End If
            Case Else
                MsgBox("錯誤！" & vbCrLf & "請先選取您給予的Hash值類型", MsgBoxStyle.Question)
        End Select
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = 13 Then
            Select Case Len(TextBox1.Text)
                Case 32
                    ' MD5
                    ComboBox1.SelectedIndex = 0
                Case 40
                    'SHA1
                    ComboBox1.SelectedIndex = 1
                Case 64
                    ' SHA256
                    ComboBox1.SelectedIndex = 2
                Case 128
                    'SHA512
                    ComboBox1.SelectedIndex = 3
                Case Else
                    ComboBox1.SelectedText = ""
            End Select
        End If
    End Sub

    Private Sub frmCheck_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Form1.txtList.Text = "" Then
            MsgBox("錯誤！" & vbCrLf & "你還未開啟新檔案做驗證", MsgBoxStyle.Critical)
            Me.Close()
        End If
        Me.Icon = Form1.Icon
    End Sub
End Class