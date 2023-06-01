<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdate
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtNewVersionInfo = New System.Windows.Forms.TextBox()
        Me.btnNoUpdate = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtNewVersionInfo
        '
        Me.txtNewVersionInfo.Location = New System.Drawing.Point(12, 12)
        Me.txtNewVersionInfo.Multiline = True
        Me.txtNewVersionInfo.Name = "txtNewVersionInfo"
        Me.txtNewVersionInfo.Size = New System.Drawing.Size(456, 352)
        Me.txtNewVersionInfo.TabIndex = 1
        '
        'btnNoUpdate
        '
        Me.btnNoUpdate.Location = New System.Drawing.Point(243, 370)
        Me.btnNoUpdate.Name = "btnNoUpdate"
        Me.btnNoUpdate.Size = New System.Drawing.Size(128, 31)
        Me.btnNoUpdate.TabIndex = 2
        Me.btnNoUpdate.Text = "不升級(&N)"
        Me.btnNoUpdate.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(109, 370)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(128, 31)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "確認升級(&U)"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'frmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 414)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnNoUpdate)
        Me.Controls.Add(Me.txtNewVersionInfo)
        Me.Name = "frmUpdate"
        Me.Text = "frmUpdate"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txtNewVersionInfo As System.Windows.Forms.TextBox
    Friend WithEvents btnNoUpdate As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
End Class
