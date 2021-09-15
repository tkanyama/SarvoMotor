<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MotorCtl
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.txtDistance = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TypeComboBox1 = New System.Windows.Forms.ComboBox()
        Me.STOP_Button = New System.Windows.Forms.Button()
        Me.CCW_Button = New System.Windows.Forms.Button()
        Me.CW_Button = New System.Windows.Forms.Button()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblComment)
        Me.GroupBox1.Controls.Add(Me.txtDistance)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TypeComboBox1)
        Me.GroupBox1.Controls.Add(Me.STOP_Button)
        Me.GroupBox1.Controls.Add(Me.CCW_Button)
        Me.GroupBox1.Controls.Add(Me.CW_Button)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(160, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 262)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ピストン操作"
        '
        'lblComment
        '
        Me.lblComment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblComment.Location = New System.Drawing.Point(16, 206)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(349, 35)
        Me.lblComment.TabIndex = 7
        Me.lblComment.Text = "Label3"
        '
        'txtDistance
        '
        Me.txtDistance.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtDistance.Location = New System.Drawing.Point(250, 156)
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.Size = New System.Drawing.Size(88, 36)
        Me.txtDistance.TabIndex = 4
        Me.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(165, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 30)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "目標値"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(31, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 21)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "座標タイプ"
        '
        'TypeComboBox1
        '
        Me.TypeComboBox1.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TypeComboBox1.FormattingEnabled = True
        Me.TypeComboBox1.Location = New System.Drawing.Point(16, 163)
        Me.TypeComboBox1.Name = "TypeComboBox1"
        Me.TypeComboBox1.Size = New System.Drawing.Size(105, 29)
        Me.TypeComboBox1.TabIndex = 5
        '
        'STOP_Button
        '
        Me.STOP_Button.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.STOP_Button.Location = New System.Drawing.Point(167, 92)
        Me.STOP_Button.Name = "STOP_Button"
        Me.STOP_Button.Size = New System.Drawing.Size(198, 47)
        Me.STOP_Button.TabIndex = 2
        Me.STOP_Button.Text = "停止"
        Me.STOP_Button.UseVisualStyleBackColor = True
        '
        'CCW_Button
        '
        Me.CCW_Button.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CCW_Button.Location = New System.Drawing.Point(278, 26)
        Me.CCW_Button.Name = "CCW_Button"
        Me.CCW_Button.Size = New System.Drawing.Size(87, 48)
        Me.CCW_Button.TabIndex = 1
        Me.CCW_Button.Text = "押し"
        Me.CCW_Button.UseVisualStyleBackColor = True
        '
        'CW_Button
        '
        Me.CW_Button.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CW_Button.Location = New System.Drawing.Point(167, 26)
        Me.CW_Button.Name = "CW_Button"
        Me.CW_Button.Size = New System.Drawing.Size(87, 48)
        Me.CW_Button.TabIndex = 1
        Me.CW_Button.Text = "引き"
        Me.CW_Button.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioButton3.Location = New System.Drawing.Point(16, 92)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(92, 25)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "原点復帰"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioButton2.Location = New System.Drawing.Point(16, 62)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(92, 25)
        Me.RadioButton2.TabIndex = 0
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "連続運転"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioButton1.Location = New System.Drawing.Point(16, 32)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(108, 25)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "目標値移動"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(338, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "mm"
        '
        'MotorCtl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 295)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MotorCtl"
        Me.Text = "MotorCtl"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblComment As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TypeComboBox1 As ComboBox
    Friend WithEvents txtDistance As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents STOP_Button As Button
    Friend WithEvents CCW_Button As Button
    Friend WithEvents CW_Button As Button
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label3 As Label
End Class
