Option Strict Off
Option Explicit On 
Imports System.Text
Public Class Ctlio
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnComOut1 As System.Windows.Forms.Button
    Friend WithEvents btnComOut2 As System.Windows.Forms.Button
    Friend WithEvents btnComOut3 As System.Windows.Forms.Button
    Friend WithEvents btnComHoldOff As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnComAlarmClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblComment As System.Windows.Forms.Label
    Public WithEvents timer As System.Windows.Forms.Timer
    Friend WithEvents lblHoldOff As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblHoldOff = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnComHoldOff = New System.Windows.Forms.Button()
        Me.btnComOut3 = New System.Windows.Forms.Button()
        Me.btnComOut2 = New System.Windows.Forms.Button()
        Me.btnComOut1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnComAlarmClear = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblHoldOff)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnComHoldOff)
        Me.GroupBox1.Controls.Add(Me.btnComOut3)
        Me.GroupBox1.Controls.Add(Me.btnComOut2)
        Me.GroupBox1.Controls.Add(Me.btnComOut1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(402, 144)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control I/O"
        '
        'lblHoldOff
        '
        Me.lblHoldOff.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblHoldOff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHoldOff.Location = New System.Drawing.Point(280, 64)
        Me.lblHoldOff.Name = "lblHoldOff"
        Me.lblHoldOff.Size = New System.Drawing.Size(72, 20)
        Me.lblHoldOff.TabIndex = 24
        Me.lblHoldOff.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(336, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 15)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "ZSP"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(280, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 15)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "TLC"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(224, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 15)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "RD"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(168, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 15)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "INP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(112, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 15)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "ALM"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Input Data"
        '
        'btnComHoldOff
        '
        Me.btnComHoldOff.Location = New System.Drawing.Point(280, 36)
        Me.btnComHoldOff.Name = "btnComHoldOff"
        Me.btnComHoldOff.Size = New System.Drawing.Size(60, 22)
        Me.btnComHoldOff.TabIndex = 8
        Me.btnComHoldOff.Text = "Hold Off"
        '
        'btnComOut3
        '
        Me.btnComOut3.Location = New System.Drawing.Point(216, 36)
        Me.btnComOut3.Name = "btnComOut3"
        Me.btnComOut3.Size = New System.Drawing.Size(48, 22)
        Me.btnComOut3.TabIndex = 7
        Me.btnComOut3.Text = "CR"
        '
        'btnComOut2
        '
        Me.btnComOut2.Location = New System.Drawing.Point(160, 36)
        Me.btnComOut2.Name = "btnComOut2"
        Me.btnComOut2.Size = New System.Drawing.Size(48, 22)
        Me.btnComOut2.TabIndex = 6
        Me.btnComOut2.Text = "RES"
        '
        'btnComOut1
        '
        Me.btnComOut1.Location = New System.Drawing.Point(104, 36)
        Me.btnComOut1.Name = "btnComOut1"
        Me.btnComOut1.Size = New System.Drawing.Size(48, 22)
        Me.btnComOut1.TabIndex = 5
        Me.btnComOut1.Text = "SON"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Output Data"
        '
        'btnComAlarmClear
        '
        Me.btnComAlarmClear.Location = New System.Drawing.Point(258, 162)
        Me.btnComAlarmClear.Name = "btnComAlarmClear"
        Me.btnComAlarmClear.Size = New System.Drawing.Size(136, 24)
        Me.btnComAlarmClear.TabIndex = 6
        Me.btnComAlarmClear.Text = "Alm Clear OutPut"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblComment)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 192)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 71)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COMMENT"
        '
        'lblComment
        '
        Me.lblComment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblComment.Location = New System.Drawing.Point(8, 24)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(370, 31)
        Me.lblComment.TabIndex = 0
        '
        'timer
        '
        '
        'Ctlio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(432, 273)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnComAlarmClear)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Ctlio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONTROL I/O"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dwRet As Integer
    Dim OutData As Short
    Dim InData As Short
    Dim szComment As String
    'Dim Id As Short
    'Dim AxisNo As Short
    Dim ErcOn As Short
    Dim ErrorString As New StringBuilder("", 256)  'Error String

    Dim IN1 As LED
    Dim IN2 As LED
    Dim IN3 As LED
    Dim IN4 As LED
    Dim IN5 As LED
    Dim OUT1 As LED
    Dim OUT2 As LED
    Dim OUT3 As LED

    Dim ToolTip1 As ToolTip

    'Private Sub cboTargetAxis_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    AxisNo = cboTargetAxis.SelectedIndex + 1

    'End Sub

    Private Sub btnComEnd_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        SmcWExit(Id)
        End

    End Sub

    Private Sub btnComHoldOff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComHoldOff.Click

        Dim HoldOff As Short

        dwRet = SmcWGetHoldOff(Id, AxisNo, HoldOff)
        If (HoldOff And CSMC_HOLDOFF) = CSMC_HOLDOFF Then
            dwRet = SmcWSetHoldOff(Id, AxisNo, CSMC_HOLD)
        Else
            dwRet = SmcWSetHoldOff(Id, AxisNo, CSMC_HOLDOFF)
        End If

    End Sub

    Private Sub btnComErcOut_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        ErcOn = 0
        dwRet = SmcWSetErcOut(Id, AxisNo, ErcOn)

    End Sub

    Private Sub btnComErcClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        ErcOn = 1
        dwRet = SmcWSetErcOut(Id, AxisNo, ErcOn)

    End Sub

    Private Sub btnComAlarmClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComAlarmClear.Click

        dwRet = SmcWSetAlarmClear(Id, AxisNo)

    End Sub

    Private Sub btnComOut1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComOut1.Click

        '-----------------------------------
        ' Set Ctrl Output Data to Driver
        '-----------------------------------
        dwRet = SmcWGetDigitalOut(Id, AxisNo, OutData)
        If (OutData And CSMC_OUT1) = CSMC_OUT1 Then
            dwRet = SmcWSetDigitalOut(Id, AxisNo, 0, CSMC_OUT1)
        Else
            dwRet = SmcWSetDigitalOut(Id, AxisNo, CSMC_OUT1, CSMC_OUT1)
        End If

    End Sub

    Private Sub btnComOut2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComOut2.Click

        '-----------------------------------
        ' Set Ctrl Output Data to Driver
        '-----------------------------------
        dwRet = SmcWGetDigitalOut(Id, AxisNo, OutData)
        If (OutData And CSMC_OUT2) = CSMC_OUT2 Then
            dwRet = SmcWSetDigitalOut(Id, AxisNo, 0, CSMC_OUT2)
        Else
            dwRet = SmcWSetDigitalOut(Id, AxisNo, CSMC_OUT2, CSMC_OUT2)
        End If

    End Sub

    Private Sub btnComOut3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComOut3.Click

        '-----------------------------------
        ' Set Ctrl Output Data to Driver
        '-----------------------------------
        dwRet = SmcWGetDigitalOut(Id, AxisNo, OutData)
        If (OutData And CSMC_OUT3) = CSMC_OUT3 Then
            dwRet = SmcWSetDigitalOut(Id, AxisNo, 0, CSMC_OUT3)
        Else
            dwRet = SmcWSetDigitalOut(Id, AxisNo, CSMC_OUT3, CSMC_OUT3)
        End If

    End Sub

    Private Sub Ctlio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim n As Short

        ' Centering
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2

        IN1 = New LED
        With IN1
            .Location = New Point(104, 110)
            .kind = 1
            .Value = False
        End With
        GroupBox1.Controls.Add(IN1)
        IN1.BringToFront()

        IN2 = New LED
        With IN2
            .Location = New Point(160, 110)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(IN2)
        IN2.BringToFront()

        IN3 = New LED
        With IN3
            .Location = New Point(216, 110)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(IN3)
        IN3.BringToFront()

        IN4 = New LED
        With IN4
            .Location = New Point(272, 110)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(IN4)
        IN4.BringToFront()

        IN5 = New LED
        With IN5
            .Location = New Point(326, 110)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(IN5)
        IN5.BringToFront()

        OUT1 = New LED
        With OUT1
            .Location = New Point(104, 64)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(OUT1)
        OUT1.BringToFront()

        OUT2 = New LED
        With OUT2
            .Location = New Point(160, 64)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(OUT2)
        OUT2.BringToFront()

        OUT3 = New LED
        With OUT3
            .Location = New Point(216, 64)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(OUT3)
        OUT3.BringToFront()

        '-------------
        ' Initialize
        '-------------
        AxisNo = 1

        '------------
        ' Initialize
        '------------
        dwRet = SmcWInit(device, Id)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWInit = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        '' AxisNo ComboBox
        'cboTargetAxis.Items.Clear()
        'For n = 1 To 8
        '    cboTargetAxis.Items.Add(Str(n))
        'Next

        '' ComboBox Initialise
        'cboTargetAxis.SelectedIndex = AxisNo - 1

        timer.Enabled = True
        timer.Interval = 10

        lblComment.Text = "OK "

        ToolTip1 = New ToolTip()
        'ToolTipの設定を行う
        'ToolTipが表示されるまでの時間
        ToolTip1.InitialDelay = 1000
        'ToolTipが表示されている時に、別のToolTipを表示するまでの時間
        ToolTip1.ReshowDelay = 1000
        'ToolTipを表示する時間
        ToolTip1.AutoPopDelay = 10000
        'フォームがアクティブでない時でもToolTipを表示する
        ToolTip1.ShowAlways = True

        'Button1とButton2にToolTipが表示されるようにする
        ToolTip1.SetToolTip(btnComOut1, "最初に必ずオンにしてください。")

    End Sub

    Private Sub timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer.Tick

        Dim HoldOff As Short

        '-------------------------------
        ' Get Ctrl Output Data from Driver
        '-------------------------------
        dwRet = SmcWGetDigitalOut(Id, AxisNo, OutData)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetDigitalOut = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        If (OutData And CSMC_OUT1) = CSMC_OUT1 Then
            'lblOUT1.Text = "ON"
            OUT1.Value = True
        Else
            'lblOUT1.Text = "OFF"
            OUT1.Value = False
        End If
        If (OutData And CSMC_OUT2) = CSMC_OUT2 Then
            'lblOUT2.Text = "ON"
            OUT2.Value = True
        Else
            'lblOUT2.Text = "OFF"
            OUT2.Value = False
        End If
        If (OutData And CSMC_OUT3) = CSMC_OUT3 Then
            'lblOUT3.Text = "ON"
            OUT3.Value = True
        Else
            'lblOUT3.Text = "OFF"
            OUT3.Value = False
        End If

        '-------------------------------
        ' Get Ctrl Input Data from Driver
        '-------------------------------
        dwRet = SmcWGetDigitalIn(Id, AxisNo, InData)
        If (InData And CSMC_IN1) = CSMC_IN1 Then
            'lblIN1.Text = "ON"
            IN1.Value = True
        Else
            'lblIN1.Text = "OFF"
            IN1.Value = False
        End If
        If (InData And CSMC_IN2) = CSMC_IN2 Then
            'lblIN2.Text = "ON"
            IN2.Value = True
        Else
            'lblIN2.Text = "OFF"
            IN2.Value = False
        End If
        If (InData And CSMC_IN3) = CSMC_IN3 Then
            'lblIN3.Text = "ON"
            IN3.Value = True
        Else
            'lblIN3.Text = "OFF"
            IN3.Value = False
        End If
        If (InData And CSMC_IN4) = CSMC_IN4 Then
            'lblIN4.Text = "ON"
            IN4.Value = True
        Else
            'lblIN4.Text = "OFF"
            IN4.Value = False
        End If
        If (InData And CSMC_IN5) = CSMC_IN5 Then
            'lblIN5.Text = "ON"
            IN5.Value = True
        Else
            'lblIN5.Text = "OFF"
            IN5.Value = False
        End If
        'If (InData And CSMC_IN6) = CSMC_IN6 Then
        '    lblIN6.Text = "ON"
        'Else
        '    lblIN6.Text = "OFF"
        'End If
        'If (InData And CSMC_IN7) = CSMC_IN7 Then
        '    lblIN7.Text = "ON"
        'Else
        '    lblIN7.Text = "OFF"
        'End If

        dwRet = SmcWGetHoldOff(Id, AxisNo, HoldOff)
        If (HoldOff And CSMC_HOLDOFF) = CSMC_HOLDOFF Then
            lblHoldOff.Text = "HOLDOFF"
        Else
            lblHoldOff.Text = "HOLD"
        End If

        lblComment.Text = "OK "

    End Sub

    Public WriteOnly Property Button_Enabled() As Boolean
        Set(value As Boolean)
            btnComAlarmClear.Enabled = value
            btnComHoldOff.Enabled = value
            btnComOut1.Enabled = value
            btnComOut2.Enabled = value
            btnComOut3.Enabled = value
        End Set
    End Property

    'Private Sub txtDeviceName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim n As Short

    '    dwRet = SmcWInit(txtDeviceName.Text, Id)
    '    If dwRet <> 0 Then
    '        SmcWGetErrorString(dwRet, ErrorString)
    '        lblComment.Text = "SmcWInit = " & dwRet & " : " & ErrorString.ToString
    '        timer.Enabled = False
    '        Exit Sub
    '    End If

    '    ' AxisNo ComboBox
    '    cboTargetAxis.Items.Clear()
    '    For n = 1 To 8
    '        cboTargetAxis.Items.Add(Str(n))
    '    Next

    '    ' ComboBox Initialise
    '    cboTargetAxis.SelectedIndex = AxisNo - 1

    '    timer.Enabled = True
    '    timer.Interval = 1

    '    lblComment.Text = "OK "

    'End Sub
End Class
