<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.LoadDirLabel = New System.Windows.Forms.Label()
        Me.KBDControlCheckBox = New System.Windows.Forms.CheckBox()
        Me.PistonAdjustCheckBox = New System.Windows.Forms.CheckBox()
        Me.PlusAdjustButton2 = New System.Windows.Forms.Button()
        Me.PlusAdjustButton1 = New System.Windows.Forms.Button()
        Me.SpeedControlCheckBox = New System.Windows.Forms.CheckBox()
        Me.MinusAdjustButton2 = New System.Windows.Forms.Button()
        Me.SpaceKeyLabel = New System.Windows.Forms.Label()
        Me.MinusAdjustButton1 = New System.Windows.Forms.Button()
        Me.EnterKeyLabel = New System.Windows.Forms.Label()
        Me.KeyTextBox = New System.Windows.Forms.TextBox()
        Me.EventCheckBox = New System.Windows.Forms.CheckBox()
        Me.Unit_Label = New System.Windows.Forms.Label()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.txtDistance = New System.Windows.Forms.TextBox()
        Me.Coordinate_Label1 = New System.Windows.Forms.Label()
        Me.Coordinate_Label2 = New System.Windows.Forms.Label()
        Me.Coordinate_TypeComboBox1 = New System.Windows.Forms.ComboBox()
        Me.STOP_Button = New System.Windows.Forms.Button()
        Me.CCW_Button = New System.Windows.Forms.Button()
        Me.CW_Button = New System.Windows.Forms.Button()
        Me.JOG_RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.PTP_RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.PreModeRadioButton = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TestModeRadioButton = New System.Windows.Forms.RadioButton()
        Me.TestStartButton = New System.Windows.Forms.Button()
        Me.DestinationLabel = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ControlModeLabel = New System.Windows.Forms.Label()
        Me.NextStepLabel = New System.Windows.Forms.Label()
        Me.testModeLabel = New System.Windows.Forms.Label()
        Me.RecentValueLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.KeyHintLabel = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Text_ErrorString = New System.Windows.Forms.Label()
        Me.AIODataTextBox = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MeanSampleNComboBox = New System.Windows.Forms.ComboBox()
        Me.AIOSettingButton = New System.Windows.Forms.Button()
        Me.AIOCheckBox = New System.Windows.Forms.CheckBox()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.編集ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.電圧入力設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ピストンスピード設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LoadDirLabel)
        Me.GroupBox1.Controls.Add(Me.KBDControlCheckBox)
        Me.GroupBox1.Controls.Add(Me.PistonAdjustCheckBox)
        Me.GroupBox1.Controls.Add(Me.PlusAdjustButton2)
        Me.GroupBox1.Controls.Add(Me.PlusAdjustButton1)
        Me.GroupBox1.Controls.Add(Me.SpeedControlCheckBox)
        Me.GroupBox1.Controls.Add(Me.MinusAdjustButton2)
        Me.GroupBox1.Controls.Add(Me.SpaceKeyLabel)
        Me.GroupBox1.Controls.Add(Me.MinusAdjustButton1)
        Me.GroupBox1.Controls.Add(Me.EnterKeyLabel)
        Me.GroupBox1.Controls.Add(Me.KeyTextBox)
        Me.GroupBox1.Controls.Add(Me.EventCheckBox)
        Me.GroupBox1.Controls.Add(Me.Unit_Label)
        Me.GroupBox1.Controls.Add(Me.lblComment)
        Me.GroupBox1.Controls.Add(Me.txtDistance)
        Me.GroupBox1.Controls.Add(Me.Coordinate_Label1)
        Me.GroupBox1.Controls.Add(Me.Coordinate_Label2)
        Me.GroupBox1.Controls.Add(Me.Coordinate_TypeComboBox1)
        Me.GroupBox1.Controls.Add(Me.STOP_Button)
        Me.GroupBox1.Controls.Add(Me.CCW_Button)
        Me.GroupBox1.Controls.Add(Me.CW_Button)
        Me.GroupBox1.Controls.Add(Me.JOG_RadioButton2)
        Me.GroupBox1.Controls.Add(Me.PTP_RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(160, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 297)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ピストン操作"
        '
        'LoadDirLabel
        '
        Me.LoadDirLabel.AutoSize = True
        Me.LoadDirLabel.Location = New System.Drawing.Point(29, 126)
        Me.LoadDirLabel.Name = "LoadDirLabel"
        Me.LoadDirLabel.Size = New System.Drawing.Size(85, 15)
        Me.LoadDirLabel.TabIndex = 23
        Me.LoadDirLabel.Text = "加力方向：なし"
        '
        'KBDControlCheckBox
        '
        Me.KBDControlCheckBox.AutoSize = True
        Me.KBDControlCheckBox.Location = New System.Drawing.Point(16, 104)
        Me.KBDControlCheckBox.Name = "KBDControlCheckBox"
        Me.KBDControlCheckBox.Size = New System.Drawing.Size(90, 19)
        Me.KBDControlCheckBox.TabIndex = 22
        Me.KBDControlCheckBox.Text = "KBD Control"
        Me.KBDControlCheckBox.UseVisualStyleBackColor = True
        '
        'PistonAdjustCheckBox
        '
        Me.PistonAdjustCheckBox.AutoSize = True
        Me.PistonAdjustCheckBox.Location = New System.Drawing.Point(168, 11)
        Me.PistonAdjustCheckBox.Name = "PistonAdjustCheckBox"
        Me.PistonAdjustCheckBox.Size = New System.Drawing.Size(97, 19)
        Me.PistonAdjustCheckBox.TabIndex = 21
        Me.PistonAdjustCheckBox.Text = "ピストン微調整"
        Me.PistonAdjustCheckBox.UseVisualStyleBackColor = True
        '
        'PlusAdjustButton2
        '
        Me.PlusAdjustButton2.Location = New System.Drawing.Point(323, 36)
        Me.PlusAdjustButton2.Name = "PlusAdjustButton2"
        Me.PlusAdjustButton2.Size = New System.Drawing.Size(40, 21)
        Me.PlusAdjustButton2.TabIndex = 20
        Me.PlusAdjustButton2.Text = ">>"
        Me.PlusAdjustButton2.UseVisualStyleBackColor = True
        '
        'PlusAdjustButton1
        '
        Me.PlusAdjustButton1.Location = New System.Drawing.Point(271, 36)
        Me.PlusAdjustButton1.Name = "PlusAdjustButton1"
        Me.PlusAdjustButton1.Size = New System.Drawing.Size(40, 21)
        Me.PlusAdjustButton1.TabIndex = 20
        Me.PlusAdjustButton1.Text = ">"
        Me.PlusAdjustButton1.UseVisualStyleBackColor = True
        '
        'SpeedControlCheckBox
        '
        Me.SpeedControlCheckBox.AutoSize = True
        Me.SpeedControlCheckBox.Location = New System.Drawing.Point(169, 221)
        Me.SpeedControlCheckBox.Name = "SpeedControlCheckBox"
        Me.SpeedControlCheckBox.Size = New System.Drawing.Size(110, 19)
        Me.SpeedControlCheckBox.TabIndex = 14
        Me.SpeedControlCheckBox.Text = "目標値減速調整"
        Me.SpeedControlCheckBox.UseVisualStyleBackColor = True
        '
        'MinusAdjustButton2
        '
        Me.MinusAdjustButton2.Location = New System.Drawing.Point(167, 36)
        Me.MinusAdjustButton2.Name = "MinusAdjustButton2"
        Me.MinusAdjustButton2.Size = New System.Drawing.Size(40, 21)
        Me.MinusAdjustButton2.TabIndex = 20
        Me.MinusAdjustButton2.Text = "<<"
        Me.MinusAdjustButton2.UseVisualStyleBackColor = True
        '
        'SpaceKeyLabel
        '
        Me.SpaceKeyLabel.AutoSize = True
        Me.SpaceKeyLabel.Location = New System.Drawing.Point(286, 138)
        Me.SpaceKeyLabel.Name = "SpaceKeyLabel"
        Me.SpaceKeyLabel.Size = New System.Drawing.Size(68, 15)
        Me.SpaceKeyLabel.TabIndex = 13
        Me.SpaceKeyLabel.Text = "[Space Key]"
        '
        'MinusAdjustButton1
        '
        Me.MinusAdjustButton1.Location = New System.Drawing.Point(219, 36)
        Me.MinusAdjustButton1.Name = "MinusAdjustButton1"
        Me.MinusAdjustButton1.Size = New System.Drawing.Size(40, 21)
        Me.MinusAdjustButton1.TabIndex = 20
        Me.MinusAdjustButton1.Text = "<"
        Me.MinusAdjustButton1.UseVisualStyleBackColor = True
        '
        'EnterKeyLabel
        '
        Me.EnterKeyLabel.AutoSize = True
        Me.EnterKeyLabel.Location = New System.Drawing.Point(235, 85)
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
        Me.EventCheckBox.Location = New System.Drawing.Point(15, 221)
        Me.EventCheckBox.Name = "EventCheckBox"
        Me.EventCheckBox.Size = New System.Drawing.Size(82, 19)
        Me.EventCheckBox.TabIndex = 9
        Me.EventCheckBox.Text = "Stop Event"
        Me.EventCheckBox.UseVisualStyleBackColor = True
        '
        'Unit_Label
        '
        Me.Unit_Label.AutoSize = True
        Me.Unit_Label.Location = New System.Drawing.Point(336, 194)
        Me.Unit_Label.Name = "Unit_Label"
        Me.Unit_Label.Size = New System.Drawing.Size(27, 15)
        Me.Unit_Label.TabIndex = 8
        Me.Unit_Label.Text = "mm"
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
        Me.txtDistance.Location = New System.Drawing.Point(248, 179)
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.Size = New System.Drawing.Size(88, 36)
        Me.txtDistance.TabIndex = 4
        Me.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Coordinate_Label1
        '
        Me.Coordinate_Label1.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Coordinate_Label1.Location = New System.Drawing.Point(139, 182)
        Me.Coordinate_Label1.Name = "Coordinate_Label1"
        Me.Coordinate_Label1.Size = New System.Drawing.Size(103, 30)
        Me.Coordinate_Label1.TabIndex = 3
        Me.Coordinate_Label1.Text = "目標値"
        Me.Coordinate_Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Coordinate_Label2
        '
        Me.Coordinate_Label2.AutoSize = True
        Me.Coordinate_Label2.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Coordinate_Label2.Location = New System.Drawing.Point(29, 157)
        Me.Coordinate_Label2.Name = "Coordinate_Label2"
        Me.Coordinate_Label2.Size = New System.Drawing.Size(77, 21)
        Me.Coordinate_Label2.TabIndex = 6
        Me.Coordinate_Label2.Text = "座標タイプ"
        '
        'Coordinate_TypeComboBox1
        '
        Me.Coordinate_TypeComboBox1.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Coordinate_TypeComboBox1.FormattingEnabled = True
        Me.Coordinate_TypeComboBox1.Location = New System.Drawing.Point(14, 186)
        Me.Coordinate_TypeComboBox1.Name = "Coordinate_TypeComboBox1"
        Me.Coordinate_TypeComboBox1.Size = New System.Drawing.Size(105, 29)
        Me.Coordinate_TypeComboBox1.TabIndex = 5
        '
        'STOP_Button
        '
        Me.STOP_Button.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.STOP_Button.Location = New System.Drawing.Point(165, 126)
        Me.STOP_Button.Name = "STOP_Button"
        Me.STOP_Button.Size = New System.Drawing.Size(198, 47)
        Me.STOP_Button.TabIndex = 2
        Me.STOP_Button.Text = "停止"
        Me.STOP_Button.UseVisualStyleBackColor = True
        '
        'CCW_Button
        '
        Me.CCW_Button.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CCW_Button.Location = New System.Drawing.Point(165, 69)
        Me.CCW_Button.Name = "CCW_Button"
        Me.CCW_Button.Size = New System.Drawing.Size(87, 48)
        Me.CCW_Button.TabIndex = 1
        Me.CCW_Button.Text = "押し"
        Me.CCW_Button.UseVisualStyleBackColor = True
        '
        'CW_Button
        '
        Me.CW_Button.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CW_Button.Location = New System.Drawing.Point(276, 69)
        Me.CW_Button.Name = "CW_Button"
        Me.CW_Button.Size = New System.Drawing.Size(87, 48)
        Me.CW_Button.TabIndex = 1
        Me.CW_Button.Text = "引き"
        Me.CW_Button.UseVisualStyleBackColor = True
        '
        'JOG_RadioButton2
        '
        Me.JOG_RadioButton2.AutoSize = True
        Me.JOG_RadioButton2.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.JOG_RadioButton2.Location = New System.Drawing.Point(16, 62)
        Me.JOG_RadioButton2.Name = "JOG_RadioButton2"
        Me.JOG_RadioButton2.Size = New System.Drawing.Size(92, 25)
        Me.JOG_RadioButton2.TabIndex = 0
        Me.JOG_RadioButton2.TabStop = True
        Me.JOG_RadioButton2.Text = "連続運転"
        Me.JOG_RadioButton2.UseVisualStyleBackColor = True
        '
        'PTP_RadioButton1
        '
        Me.PTP_RadioButton1.AutoSize = True
        Me.PTP_RadioButton1.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PTP_RadioButton1.Location = New System.Drawing.Point(16, 32)
        Me.PTP_RadioButton1.Name = "PTP_RadioButton1"
        Me.PTP_RadioButton1.Size = New System.Drawing.Size(108, 25)
        Me.PTP_RadioButton1.TabIndex = 0
        Me.PTP_RadioButton1.TabStop = True
        Me.PTP_RadioButton1.Text = "目標値移動"
        Me.PTP_RadioButton1.UseVisualStyleBackColor = True
        '
        'PreModeRadioButton
        '
        Me.PreModeRadioButton.AutoSize = True
        Me.PreModeRadioButton.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PreModeRadioButton.Location = New System.Drawing.Point(6, 22)
        Me.PreModeRadioButton.Name = "PreModeRadioButton"
        Me.PreModeRadioButton.Size = New System.Drawing.Size(113, 25)
        Me.PreModeRadioButton.TabIndex = 12
        Me.PreModeRadioButton.TabStop = True
        Me.PreModeRadioButton.Text = "準備・片付け"
        Me.PreModeRadioButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TestModeRadioButton)
        Me.GroupBox2.Controls.Add(Me.PreModeRadioButton)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 85)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "操作モード"
        '
        'TestModeRadioButton
        '
        Me.TestModeRadioButton.AutoSize = True
        Me.TestModeRadioButton.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TestModeRadioButton.Location = New System.Drawing.Point(6, 53)
        Me.TestModeRadioButton.Name = "TestModeRadioButton"
        Me.TestModeRadioButton.Size = New System.Drawing.Size(60, 25)
        Me.TestModeRadioButton.TabIndex = 12
        Me.TestModeRadioButton.TabStop = True
        Me.TestModeRadioButton.Text = "試験"
        Me.TestModeRadioButton.UseVisualStyleBackColor = True
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
        Me.DestinationLabel.Location = New System.Drawing.Point(22, 200)
        Me.DestinationLabel.Name = "DestinationLabel"
        Me.DestinationLabel.Size = New System.Drawing.Size(77, 27)
        Me.DestinationLabel.TabIndex = 15
        Me.DestinationLabel.Text = "0.0"
        Me.DestinationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ControlModeLabel)
        Me.GroupBox3.Controls.Add(Me.NextStepLabel)
        Me.GroupBox3.Controls.Add(Me.testModeLabel)
        Me.GroupBox3.Controls.Add(Me.RecentValueLabel)
        Me.GroupBox3.Controls.Add(Me.DestinationLabel)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.TestStartButton)
        Me.GroupBox3.Controls.Add(Me.MenuStrip1)
        Me.GroupBox3.Location = New System.Drawing.Point(555, 36)
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
        Me.ControlModeLabel.Text = "ストローク"
        Me.ControlModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NextStepLabel
        '
        Me.NextStepLabel.AutoSize = True
        Me.NextStepLabel.Location = New System.Drawing.Point(3, 200)
        Me.NextStepLabel.Name = "NextStepLabel"
        Me.NextStepLabel.Size = New System.Drawing.Size(19, 15)
        Me.NextStepLabel.TabIndex = 21
        Me.NextStepLabel.Text = "△"
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
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 19)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(107, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'KeyHintLabel
        '
        Me.KeyHintLabel.AutoSize = True
        Me.KeyHintLabel.Location = New System.Drawing.Point(130, 312)
        Me.KeyHintLabel.Name = "KeyHintLabel"
        Me.KeyHintLabel.Size = New System.Drawing.Size(237, 15)
        Me.KeyHintLabel.TabIndex = 17
        Me.KeyHintLabel.Text = "Press 'F1' or 'S' key Then Speed Input Dialog"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Text_ErrorString)
        Me.GroupBox4.Controls.Add(Me.AIODataTextBox)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.MeanSampleNComboBox)
        Me.GroupBox4.Controls.Add(Me.AIOSettingButton)
        Me.GroupBox4.Controls.Add(Me.AIOCheckBox)
        Me.GroupBox4.Location = New System.Drawing.Point(685, 36)
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
        'MeanSampleNComboBox
        '
        Me.MeanSampleNComboBox.FormattingEnabled = True
        Me.MeanSampleNComboBox.Location = New System.Drawing.Point(117, 44)
        Me.MeanSampleNComboBox.Name = "MeanSampleNComboBox"
        Me.MeanSampleNComboBox.Size = New System.Drawing.Size(39, 23)
        Me.MeanSampleNComboBox.TabIndex = 5
        '
        'AIOSettingButton
        '
        Me.AIOSettingButton.Location = New System.Drawing.Point(16, 42)
        Me.AIOSettingButton.Name = "AIOSettingButton"
        Me.AIOSettingButton.Size = New System.Drawing.Size(89, 26)
        Me.AIOSettingButton.TabIndex = 4
        Me.AIOSettingButton.Text = "電圧入力設定"
        Me.AIOSettingButton.UseVisualStyleBackColor = True
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
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.編集ToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1084, 24)
        Me.MenuStrip2.TabIndex = 20
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ファイルToolStripMenuItem.Text = "ファイル"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '編集ToolStripMenuItem
        '
        Me.編集ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.電圧入力設定ToolStripMenuItem, Me.ピストンスピード設定ToolStripMenuItem})
        Me.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem"
        Me.編集ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.編集ToolStripMenuItem.Text = "編集"
        '
        '電圧入力設定ToolStripMenuItem
        '
        Me.電圧入力設定ToolStripMenuItem.Name = "電圧入力設定ToolStripMenuItem"
        Me.電圧入力設定ToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.電圧入力設定ToolStripMenuItem.Text = "電圧入力設定"
        '
        'ピストンスピード設定ToolStripMenuItem
        '
        Me.ピストンスピード設定ToolStripMenuItem.Name = "ピストンスピード設定ToolStripMenuItem"
        Me.ピストンスピード設定ToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ピストンスピード設定ToolStripMenuItem.Text = "ピストンスピード設定"
        '
        'MotorCtl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 681)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.KeyHintLabel)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MotorCtl"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblComment As Label
    Friend WithEvents Coordinate_Label2 As Label
    Friend WithEvents Coordinate_TypeComboBox1 As ComboBox
    Friend WithEvents txtDistance As TextBox
    Friend WithEvents Coordinate_Label1 As Label
    Friend WithEvents STOP_Button As Button
    Friend WithEvents CCW_Button As Button
    Friend WithEvents CW_Button As Button
    Friend WithEvents JOG_RadioButton2 As RadioButton
    Friend WithEvents PTP_RadioButton1 As RadioButton
    Friend WithEvents Unit_Label As Label
    Friend WithEvents EventCheckBox As CheckBox
    Friend WithEvents PreModeRadioButton As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TestModeRadioButton As RadioButton
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
    Friend WithEvents KeyHintLabel As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents AIOCheckBox As CheckBox
    Friend WithEvents AIOSettingButton As Button
    Friend WithEvents MeanSampleNComboBox As ComboBox
    Friend WithEvents AIODataTextBox As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Text_ErrorString As Label
    Friend WithEvents SpeedControlCheckBox As CheckBox
    Friend WithEvents MinusAdjustButton1 As Button
    Friend WithEvents PlusAdjustButton1 As Button
    Friend WithEvents PlusAdjustButton2 As Button
    Friend WithEvents MinusAdjustButton2 As Button
    Friend WithEvents PistonAdjustCheckBox As CheckBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ファイルToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 編集ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 電圧入力設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ピストンスピード設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KBDControlCheckBox As CheckBox
    Friend WithEvents LoadDirLabel As Label
    Friend WithEvents NextStepLabel As Label
End Class
