<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheck
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
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.md5Code = New System.Windows.Forms.Label()
        Me.sha256Code = New System.Windows.Forms.Label()
        Me.sha512Code = New System.Windows.Forms.Label()
        Me.sha1Code = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(487, 47)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(100, 30)
        Me.btnEnter.TabIndex = 0
        Me.btnEnter.Text = "確認(&E)"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(381, 47)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"MD5", "SHA1", "SHA256", "SHA512"})
        Me.ComboBox1.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 26)
        Me.ComboBox1.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(139, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(448, 29)
        Me.TextBox1.TabIndex = 3
        '
        'md5Code
        '
        Me.md5Code.AutoSize = True
        Me.md5Code.Location = New System.Drawing.Point(9, 47)
        Me.md5Code.Name = "md5Code"
        Me.md5Code.Size = New System.Drawing.Size(43, 18)
        Me.md5Code.TabIndex = 4
        Me.md5Code.Text = "MD5"
        Me.md5Code.Visible = False
        '
        'sha256Code
        '
        Me.sha256Code.AutoSize = True
        Me.sha256Code.Location = New System.Drawing.Point(70, 47)
        Me.sha256Code.Name = "sha256Code"
        Me.sha256Code.Size = New System.Drawing.Size(65, 18)
        Me.sha256Code.TabIndex = 5
        Me.sha256Code.Text = "SHA256"
        Me.sha256Code.Visible = False
        '
        'sha512Code
        '
        Me.sha512Code.AutoSize = True
        Me.sha512Code.Location = New System.Drawing.Point(202, 47)
        Me.sha512Code.Name = "sha512Code"
        Me.sha512Code.Size = New System.Drawing.Size(65, 18)
        Me.sha512Code.TabIndex = 7
        Me.sha512Code.Text = "SHA512"
        Me.sha512Code.Visible = False
        '
        'sha1Code
        '
        Me.sha1Code.AutoSize = True
        Me.sha1Code.Location = New System.Drawing.Point(141, 47)
        Me.sha1Code.Name = "sha1Code"
        Me.sha1Code.Size = New System.Drawing.Size(49, 18)
        Me.sha1Code.TabIndex = 6
        Me.sha1Code.Text = "SHA1"
        Me.sha1Code.Visible = False
        '
        'frmCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 85)
        Me.Controls.Add(Me.sha512Code)
        Me.Controls.Add(Me.sha1Code)
        Me.Controls.Add(Me.sha256Code)
        Me.Controls.Add(Me.md5Code)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEnter)
        Me.Name = "frmCheck"
        Me.Text = "frmCheck"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents md5Code As System.Windows.Forms.Label
    Friend WithEvents sha256Code As System.Windows.Forms.Label
    Friend WithEvents sha512Code As System.Windows.Forms.Label
    Friend WithEvents sha1Code As System.Windows.Forms.Label
End Class
