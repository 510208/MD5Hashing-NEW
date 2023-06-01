Public Class frmInfo

    Private Sub frmInfo_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
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

    Private Sub frmInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 初始化前一次的表單大小
        Me.PreviousSize = Me.Size
        Me.Icon = Form1.Icon
    End Sub

    Private Property PreviousSize As Size
End Class