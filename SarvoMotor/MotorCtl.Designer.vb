﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MotorCtl
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SpeedControlCheckBox = New System.Windows.Forms.CheckBox()
        Me.SpaceKeyLabel = New System.Windows.Forms.Label()
        Me.EnterKeyLabel = New System.Windows.Forms.Label()
        Me.KeyTextBox = New System.Windows.Forms.TextBox()
        Me.EventCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.TestStartButton = New System.Windows.Forms.Button()
        Me.DestinationLabel = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ControlModeLabel = New System.Windows.Forms.Label()
        Me.testModeLabel = New System.Windows.Forms.Label()
        Me.RecentValueLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Text_ErrorString = New System.Windows.Forms.Label()
        Me.AIODataTextBox = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.AIOCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SpeedControlCheckBox)
        Me.GroupBox1.Controls.Add(Me.SpaceKeyLabel)
        Me.GroupBox1.Controls.Add(Me.EnterKeyLabel)
        Me.GroupBox1.Controls.Add(Me.KeyTextBox)
        Me.GroupBox1.Controls.Add(Me.EventCheckBox)
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
        Me.GroupBox1.Size = New System.Drawing.Size(380, 297)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ピストン操作"
        '
        'SpeedControlCheckBox
        '
        Me.SpeedControlCheckBox.AutoSize = True
        Me.SpeedControlCheckBox.Location = New System.Drawing.Point(170, 209)
        Me.SpeedControlCheckBox.Name = "SpeedControlCheckBox"
        Me.SpeedControlCheckBox.Size = New System.Drawing.Size(110, 19)
        Me.SpeedControlCheckBox.TabIndex = 14
        Me.SpeedControlCheckBox.Text = "目標値減速調整"
        Me.SpeedControlCheckBox.UseVisualStyleBackColor = True
        '
        'SpaceKeyLabel
        '
        Me.SpaceKeyLabel.AutoSize = True
        Me.SpaceKeyLabel.Location = New System.Drawing.Point(288, 104)
        Me.SpaceKeyLabel.Name = "SpaceKeyLabel"
        Me.SpaceKeyLabel.Size = New System.Drawing.Size(68, 15)
        Me.SpaceKeyLabel.TabIndex = 13
        Me.SpaceKeyLabel.Text = "[Space Key]"
        '
        'EnterKeyLabel
        '
        Me.EnterKeyLabel.AutoSize = True
        Me.EnterKeyLabel.Location = New System.Drawing.Point(228, 42)
        Me.EnterKeyLabel.Name = "EnterKeyLabel"
        Me.EnterKeyLabel.Size = New System.Drawing.Size(64, 15)
        Me.EnterKeyLabel.TabIndex = 13
        Me.EnterKeyLabel.Text = "[Enter Key]"
        '
        'KeyTextBox
        '
        Me.KeyTextBox.Location = New System.Drawing.Point(327, 243)
        Me.KeyTextBox.Multiline = True
        Me.KeyTextBox.Name = "KeyTextBox"
        Me.KeyTextBox.Size = New System.Drawing.Size(38, 38)
        Me.KeyTextBox.TabIndex = 12
        '
        'EventCheckBox
        '
        Me.EventCheckBox.AutoSize = True
        Me.EventCheckBox.Location = New System.Drawing.Point(16, 209)
        Me.EventCheckBox.Name = "EventCheckBox"
        Me.EventCheckBox.Size = New System.Drawing.Size(82, 19)
        Me.EventCheckBox.TabIndex = 9
        Me.EventCheckBox.Text = "Stop Event"
        Me.EventCheckBox.UseVisualStyleBackColor = True
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
        'lblComment
        '
        Me.lblComment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblComment.Location = New System.Drawing.Point(16, 243)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(305, 38)
        Me.lblComment.TabIndex = 7
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
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(141, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 30)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "目標値"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioButton4.Location = New System.Drawing.Point(6, 22)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(113, 25)
        Me.RadioButton4.TabIndex = 12
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "準備・片付け"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton5)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 85)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "操作モード"
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioButton5.Location = New System.Drawing.Point(6, 53)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(60, 25)
        Me.RadioButton5.TabIndex = 12
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "試験"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'TestStartButton
        '
        Me.TestStartButton.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TestStartButton.Location = New System.Drawing.Point(13, 26)
        Me.TestStartButton.Name = "TestStartButton"
        Me.TestStartButton.Size = New System.Drawing.Size(86, 40)
        Me.TestStartButton.TabIndex = 14
        Me.TestStartButton.Text = "試験開始"
        Me.TestStartButton.UseVisualStyleBackColor = True
        '
        'DestinationLabel
        '
        Me.DestinationLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DestinationLabel.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DestinationLabel.Location = New System.Drawing.Point(13, 200)
        Me.DestinationLabel.Name = "DestinationLabel"
        Me.DestinationLabel.Size = New System.Drawing.Size(86, 27)
        Me.DestinationLabel.TabIndex = 15
        Me.DestinationLabel.Text = "0.0"
        Me.DestinationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ControlModeLabel)
        Me.GroupBox3.Controls.Add(Me.testModeLabel)
        Me.GroupBox3.Controls.Add(Me.RecentValueLabel)
        Me.GroupBox3.Controls.Add(Me.DestinationLabel)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.TestStartButton)
        Me.GroupBox3.Location = New System.Drawing.Point(555, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(113, 297)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "試験"
        '
        'ControlModeLabel
        '
        Me.ControlModeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ControlModeLabel.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ControlModeLabel.Location = New System.Drawing.Point(13, 146)
        Me.ControlModeLabel.Name = "ControlModeLabel"
        Me.ControlModeLabel.Size = New System.Drawing.Size(86, 27)
        Me.ControlModeLabel.TabIndex = 15
        Me.ControlModeLabel.Text = "変位制御"
        Me.ControlModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'testModeLabel
        '
        Me.testModeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.testModeLabel.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.testModeLabel.Location = New System.Drawing.Point(13, 92)
        Me.testModeLabel.Name = "testModeLabel"
        Me.testModeLabel.Size = New System.Drawing.Size(86, 27)
        Me.testModeLabel.TabIndex = 15
        Me.testModeLabel.Text = "準備中"
        Me.testModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RecentValueLabel
        '
        Me.RecentValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RecentValueLabel.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RecentValueLabel.Location = New System.Drawing.Point(13, 254)
        Me.RecentValueLabel.Name = "RecentValueLabel"
        Me.RecentValueLabel.Size = New System.Drawing.Size(86, 27)
        Me.RecentValueLabel.TabIndex = 15
        Me.RecentValueLabel.Text = "0.0"
        Me.RecentValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 236)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "現在値"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 15)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "状態"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "制御"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "目標値"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(130, 312)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(237, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Press 'F1' or 'S' key Then Speed Input Dialog"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Text_ErrorString)
        Me.GroupBox4.Controls.Add(Me.AIODataTextBox)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.AIOCheckBox)
        Me.GroupBox4.Location = New System.Drawing.Point(685, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(170, 296)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "電圧入力"
        '
        'Text_ErrorString
        '
        Me.Text_ErrorString.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Text_ErrorString.Location = New System.Drawing.Point(16, 254)
        Me.Text_ErrorString.Name = "Text_ErrorString"
        Me.Text_ErrorString.Size = New System.Drawing.Size(140, 36)
        Me.Text_ErrorString.TabIndex = 8
        '
        'AIODataTextBox
        '
        Me.AIODataTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AIODataTextBox.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AIODataTextBox.Location = New System.Drawing.Point(16, 74)
        Me.AIODataTextBox.Name = "AIODataTextBox"
        Me.AIODataTextBox.Size = New System.Drawing.Size(140, 177)
        Me.AIODataTextBox.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Yu Gothic UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label7.Location = New System.Drawing.Point(111, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "平均個数"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(117, 44)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(39, 23)
        Me.ComboBox1.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 26)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "電圧入力設定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'AIOCheckBox
        '
        Me.AIOCheckBox.AutoSize = True
        Me.AIOCheckBox.Location = New System.Drawing.Point(16, 22)
        Me.AIOCheckBox.Name = "AIOCheckBox"
        Me.AIOCheckBox.Size = New System.Drawing.Size(98, 19)
        Me.AIOCheckBox.TabIndex = 2
        Me.AIOCheckBox.Text = "電圧入力有効"
        Me.AIOCheckBox.UseVisualStyleBackColor = True
        '
        'MotorCtl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 681)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MotorCtl"
        Me.Text = "MotorCtl"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents EventCheckBox As CheckBox
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents TestStartButton As Button
    Friend WithEvents DestinationLabel As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ControlModeLabel As Label
    Friend WithEvents testModeLabel As Label
    Friend WithEvents RecentValueLabel As Label
    Friend WithEvents KeyTextBox As TextBox
    Friend WithEvents SpaceKeyLabel As Label
    Friend WithEvents EnterKeyLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents AIOCheckBox As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents AIODataTextBox As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Text_ErrorString As Label
    Friend WithEvents SpeedControlCheckBox As CheckBox
End Class
