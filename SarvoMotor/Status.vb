Option Strict Off
Option Explicit On 
Imports System.Text
Public Class Status
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnComEncPulse As System.Windows.Forms.Button
    Friend WithEvents btnComOutPulse As System.Windows.Forms.Button
	Friend WithEvents lblStopSts As System.Windows.Forms.Label
	Friend WithEvents lblMoveSts As System.Windows.Forms.Label
	Friend WithEvents lblPulseSts As System.Windows.Forms.Label
	Friend WithEvents lblBankNo As System.Windows.Forms.Label
	Friend WithEvents lblCountPulse As System.Windows.Forms.Label
	Friend WithEvents lblOutPulse As System.Windows.Forms.Label
	Friend WithEvents lblComment As System.Windows.Forms.Label
    Friend WithEvents btnComEnd As System.Windows.Forms.Button
    Public WithEvents Timer1 As Timer
    Public WithEvents timer As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnComEncPulse = New System.Windows.Forms.Button()
        Me.btnComOutPulse = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblStopSts = New System.Windows.Forms.Label()
        Me.lblMoveSts = New System.Windows.Forms.Label()
        Me.lblPulseSts = New System.Windows.Forms.Label()
        Me.lblBankNo = New System.Windows.Forms.Label()
        Me.lblCountPulse = New System.Windows.Forms.Label()
        Me.lblOutPulse = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.btnComEnd = New System.Windows.Forms.Button()
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.btnComEncPulse)
        Me.GroupBox1.Controls.Add(Me.btnComOutPulse)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.lblStopSts)
        Me.GroupBox1.Controls.Add(Me.lblMoveSts)
        Me.GroupBox1.Controls.Add(Me.lblPulseSts)
        Me.GroupBox1.Controls.Add(Me.lblBankNo)
        Me.GroupBox1.Controls.Add(Me.lblCountPulse)
        Me.GroupBox1.Controls.Add(Me.lblOutPulse)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 272)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "STATUS"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(344, 216)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 15)
        Me.Label22.TabIndex = 21
        Me.Label22.Text = "ALM"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(288, 216)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 15)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "+LIM"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(232, 216)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 15)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "-LIM"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(176, 216)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 15)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "ORG"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(120, 216)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 15)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "RD"
        '
        'btnComEncPulse
        '
        Me.btnComEncPulse.Location = New System.Drawing.Point(288, 56)
        Me.btnComEncPulse.Name = "btnComEncPulse"
        Me.btnComEncPulse.Size = New System.Drawing.Size(96, 24)
        Me.btnComEncPulse.TabIndex = 16
        Me.btnComEncPulse.Text = "Zero Reset"
        '
        'btnComOutPulse
        '
        Me.btnComOutPulse.Location = New System.Drawing.Point(288, 24)
        Me.btnComOutPulse.Name = "btnComOutPulse"
        Me.btnComOutPulse.Size = New System.Drawing.Size(96, 24)
        Me.btnComOutPulse.TabIndex = 15
        Me.btnComOutPulse.Text = "Zero Reset"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(232, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 15)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "[mm]"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(232, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 15)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "[mm]"
        '
        'lblStopSts
        '
        Me.lblStopSts.BackColor = System.Drawing.SystemColors.Control
        Me.lblStopSts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStopSts.Location = New System.Drawing.Point(120, 184)
        Me.lblStopSts.Name = "lblStopSts"
        Me.lblStopSts.Size = New System.Drawing.Size(264, 24)
        Me.lblStopSts.TabIndex = 12
        Me.lblStopSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMoveSts
        '
        Me.lblMoveSts.BackColor = System.Drawing.SystemColors.Control
        Me.lblMoveSts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMoveSts.Location = New System.Drawing.Point(120, 152)
        Me.lblMoveSts.Name = "lblMoveSts"
        Me.lblMoveSts.Size = New System.Drawing.Size(264, 24)
        Me.lblMoveSts.TabIndex = 11
        Me.lblMoveSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPulseSts
        '
        Me.lblPulseSts.BackColor = System.Drawing.SystemColors.Control
        Me.lblPulseSts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPulseSts.Location = New System.Drawing.Point(120, 120)
        Me.lblPulseSts.Name = "lblPulseSts"
        Me.lblPulseSts.Size = New System.Drawing.Size(264, 24)
        Me.lblPulseSts.TabIndex = 10
        Me.lblPulseSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBankNo
        '
        Me.lblBankNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblBankNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBankNo.Location = New System.Drawing.Point(120, 88)
        Me.lblBankNo.Name = "lblBankNo"
        Me.lblBankNo.Size = New System.Drawing.Size(96, 24)
        Me.lblBankNo.TabIndex = 9
        Me.lblBankNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCountPulse
        '
        Me.lblCountPulse.BackColor = System.Drawing.SystemColors.Control
        Me.lblCountPulse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCountPulse.Location = New System.Drawing.Point(120, 56)
        Me.lblCountPulse.Name = "lblCountPulse"
        Me.lblCountPulse.Size = New System.Drawing.Size(96, 24)
        Me.lblCountPulse.TabIndex = 8
        Me.lblCountPulse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOutPulse
        '
        Me.lblOutPulse.BackColor = System.Drawing.SystemColors.Control
        Me.lblOutPulse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOutPulse.Location = New System.Drawing.Point(120, 24)
        Me.lblOutPulse.Name = "lblOutPulse"
        Me.lblOutPulse.Size = New System.Drawing.Size(96, 24)
        Me.lblOutPulse.TabIndex = 7
        Me.lblOutPulse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 15)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Limit Status"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Stop Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Move Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Outpulse Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Bank No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Encoder Count"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Outpulse Count"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblComment)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 328)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 128)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COMMENT"
        '
        'lblComment
        '
        Me.lblComment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblComment.Location = New System.Drawing.Point(16, 24)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(368, 88)
        Me.lblComment.TabIndex = 0
        '
        'btnComEnd
        '
        Me.btnComEnd.Location = New System.Drawing.Point(256, 464)
        Me.btnComEnd.Name = "btnComEnd"
        Me.btnComEnd.Size = New System.Drawing.Size(96, 24)
        Me.btnComEnd.TabIndex = 7
        Me.btnComEnd.Text = "E&XIT"
        '
        'timer
        '
        Me.timer.Interval = 200
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Status
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(432, 502)
        Me.Controls.Add(Me.btnComEnd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Status"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STATUS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dwRet As Integer
    Dim lOutPulse As Integer
    Dim lCountPulse As Integer
    Dim wBankNo As Short
    Dim bPulseSts As Short
    Dim bMoveSts As Short
    Dim bStopSts As Short
    Dim bLimitSts As Short
    Dim szComment As String
    'Dim Id As Short
    'Dim AxisNo As Short
    Dim ErrorString As New StringBuilder("", 256)  'Error String
    Const T1 As Integer = 10

    Dim LedRD As LED
    Dim LedORG As LED
    Dim LedMLIM As LED
    Dim LedPLIM As LED
    Dim LedALM As LED


    'Private Sub cboTargetAxis_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    AxisNo = cboTargetAxis.SelectedIndex + 1

    'End Sub

    Private Sub btnComEnd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComEnd.Click

        SmcWExit(Id)
        End

    End Sub

    Private Sub btnComOutPulse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComOutPulse.Click

        '---------------------------
        ' Set OutPulse for Driver
        '---------------------------
        dwRet = SmcWSetOutPulse(Id, AxisNo, 0)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetOutPulse = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        lblComment.Text = "OK "

    End Sub

    Private Sub btnComEncPulse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComEncPulse.Click

        '---------------------------
        ' Set CountPulse for Driver
        '---------------------------
        dwRet = SmcWSetCountPulse(Id, AxisNo, 0)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetCountPulse = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        lblComment.Text = "OK "

    End Sub

    Private Sub Status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim n As Short

        ' Centering
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2

        LedRD = New LED
        With LedRD
            .Location = New Point(112, 232)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(LedRD)
        LedRD.BringToFront()

        LedORG = New LED
        With LedORG
            .Location = New Point(168, 232)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(LedORG)
        LedORG.BringToFront()

        LedMLIM = New LED
        With LedMLIM
            .Location = New Point(224, 232)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(LedMLIM)
        LedMLIM.BringToFront()

        LedPLIM = New LED
        With LedPLIM
            .Location = New Point(280, 232)
            .kind = 2
            .Value = False
        End With
        GroupBox1.Controls.Add(LedPLIM)
        LedPLIM.BringToFront()

        LedALM = New LED
        With LedALM
            .Location = New Point(336, 232)
            .kind = 1
            .Value = False
        End With
        GroupBox1.Controls.Add(LedALM)
        LedALM.BringToFront()
        '-------------
        ' Initialize
        '-------------
        'AxisNo = 1

        ' AxisNo ComboBox
        'cboTargetAxis.Items.Clear()
        'For n = 1 To 8
        '    cboTargetAxis.Items.Add(Str(n))
        'Next

        ' ComboBox Initialise
        'cboTargetAxis.SelectedIndex = AxisNo - 1

        'dwRet = SmcWInit(txtDeviceName.Text, Id)
        dwRet = SmcWInit(device, Id)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWInit = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        timer.Enabled = True
        timer.Interval = T1

        lblComment.Text = "OK "

    End Sub

    Private Sub timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer.Tick


        '---------------------------
        ' Get OutPulse from Driver
        '---------------------------
        dwRet = SmcWGetOutPulse(Id, AxisNo, lOutPulse)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetOutPulse = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        'lblOutPulse.Text = Str(lOutPulse)
        lblOutPulse.Text = (lOutPulse * CC).ToString("F3")

        '---------------------------
        ' Get CountPulse from Driver
        '---------------------------
        dwRet = SmcWGetCountPulse(Id, AxisNo, lCountPulse)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcGetCountPulse = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        'lblCountPulse.Text = Str(lCountPulse)
        lblCountPulse.Text = (lCountPulse * CC).ToString("F3")

        '---------------------------
        ' Get BankNo from Driver
        '---------------------------
        dwRet = SmcWGetBankNo(Id, AxisNo, wBankNo)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetBankNo = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        lblBankNo.Text = Str(wBankNo)

        '-------------------------------
        ' Get Pulse Status from Driver
        '-------------------------------
        dwRet = SmcWGetPulseStatus(Id, AxisNo, bPulseSts)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetPulseStatus = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        Select Case bPulseSts
            Case CSMC_PLS_STOP
                lblPulseSts.Text = "Pulse Stop"
            Case CSMC_PLS_FLCONST
                lblPulseSts.Text = "Pulse FL Constant"
            Case CSMC_PLS_FHCONST
                lblPulseSts.Text = "Pulse FH Constant"
            Case CSMC_PLS_READY
                lblPulseSts.Text = "Pulse Ready"
            Case CSMC_PLS_ERCW
                lblPulseSts.Text = "Pulse ERC Timer"
            Case CSMC_PLS_DTMW
                lblPulseSts.Text = "Pulse Dir Timer"
            Case CSMC_PLS_ACCEL
                lblPulseSts.Text = "Pulse Accel"
            Case CSMC_PLS_DECEL
                lblPulseSts.Text = "Pulse Decel"
            Case CSMC_PLS_INPW
                lblPulseSts.Text = "Pulse INP Wait"
            Case CSMC_PLS_PAPBW
                lblPulseSts.Text = "Pulser Input Wait"
        End Select

        '-------------------------------
        ' Get Move Status from Driver
        '-------------------------------
        dwRet = SmcWGetMoveStatus(Id, AxisNo, bMoveSts)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetMoveStatus = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        Select Case bMoveSts
            Case CSMC_STOP
                lblMoveSts.Text = "Stop Motion"
            Case CSMC_PTP
                lblMoveSts.Text = "PTP Motion"
            Case CSMC_JOG
                lblMoveSts.Text = "JOG Motion"
            Case CSMC_ORG
                lblMoveSts.Text = "ORG Motion"
            Case CSMC_SINGLE
                lblMoveSts.Text = "Single (Bank) Motion"
            Case CSMC_LOOP
                lblMoveSts.Text = "Loop (Bank) Motion"
            Case CSMC_ZMOVE
                lblMoveSts.Text = "Z-phase count Motion"
            Case CSMC_PLSER
                lblMoveSts.Text = "Pulser Motion"
        End Select

        '-------------------------------
        ' Get Stop Status from Driver
        '-------------------------------
        dwRet = SmcWGetStopStatus(Id, AxisNo, bStopSts)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetStopStatus = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        Select Case bStopSts
            Case CSMC_MOVE
                lblStopSts.Text = "Moving"
            Case CSMC_STOP_COMMAND
                lblStopSts.Text = "Stop Command"
            Case CSMC_SD_COMMAND
                lblStopSts.Text = "Slowdown Stop Command"
            Case CSMC_STOP_OTHER
                lblStopSts.Text = "Stop by other axis"
            Case CSMC_STOP_ALARM
                lblStopSts.Text = "Stop by alarm"
            Case CSMC_STOP_PLIM
                lblStopSts.Text = "Stop by +LIM"
            Case CSMC_STOP_MLIM
                lblStopSts.Text = "Stop by -LIM"
            Case CSMC_STOP_SD
                lblStopSts.Text = "Stop by SD"
            Case CSMC_ERROR_ORG
                lblStopSts.Text = "Stop by ORG ERROR"
            Case CSMC_ERROR_PULSER
                lblStopSts.Text = "Stop by PULSER ERROR"
            Case CSMC_STOP_NORMAL
                lblStopSts.Text = "Normal Stop"
        End Select

        '-------------------------------
        ' Get Limit Status from Driver
        '-------------------------------
        dwRet = SmcWGetLimitStatus(Id, AxisNo, bLimitSts)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetLimitStatus = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        If (bLimitSts And CSMC_SD) = CSMC_SD Then
            'lblSD.Text = "ON"
            LedRD.Value = True
        Else
            'lblSD.Text = "OFF"
            LedRD.Value = False
        End If
        If (bLimitSts And CSMC_ORGLIM) = CSMC_ORGLIM Then
            'lblORG.Text = "ON"
            LedORG.Value = True
        Else
            'lblORG.Text = "OFF"
            LedORG.Value = False
        End If
        If (bLimitSts And CSMC_MLIM) = CSMC_MLIM Then
            'lblMLIM.Text = "ON"
            LedMLIM.Value = True
        Else
            'lblMLIM.Text = "OFF"
            LedMLIM.Value = False
        End If
        If (bLimitSts And CSMC_PLIM) = CSMC_PLIM Then
            'lblPLIM.Text = "ON"
            LedPLIM.Value = True
        Else
            'lblPLIM.Text = "OFF"
            LedPLIM.Value = False
        End If
        If (bLimitSts And CSMC_ALM) = CSMC_ALM Then
            'lblALM.Text = "ON"
            LedALM.Value = True
        Else
            'lblALM.Text = "OFF"
            LedALM.Value = False
        End If

        lblComment.Text = "OK "
        timer.Enabled = True

    End Sub

    'Private Sub txtDeviceName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    dwRet = SmcWInit(txtDeviceName.Text, Id)
    '    If dwRet <> 0 Then
    '        SmcWGetErrorString(dwRet, ErrorString)
    '        lblComment.Text = "SmcWInit = " & dwRet & " : " & ErrorString.ToString
    '        Exit Sub
    '    End If

    '    timer.Enabled = True
    '    timer.Interval = T1
    '    lblComment.Text = "OK "

    'End Sub



End Class
