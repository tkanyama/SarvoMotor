Option Strict Off
Option Explicit On
Imports System.Text
Public Class MotorCtl
    Inherits System.Windows.Forms.Form

    Dim Speed = {0.5, 1.0, 2.0, 5.0, 10.0}
    Dim SpeedKind As Integer
    Dim rbutton() As RadioButton
    Dim rb1 As RadioButton
    Dim Speed1 As Double
    Dim SpeedPanel1 As SpeedPanel
    Dim ErrorString As New StringBuilder("", 256)  'Error String
    Dim lCountPulse1 As Integer
    Dim RowCount1 As Integer
    'Dim Chart As LoadScedule

    Private Sub MotorCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim a As Integer
        SpeedPanel1 = New SpeedPanel
        SpeedPanel1.Speed = Speed
        SpeedPanel1.Location = New Point(25, 100)

        If TestMode = 0 Then
            Me.Size = New Size(xSize1, ySize1)
            RadioButton4.Checked = True
            RadioButton5.Checked = False
        ElseIf TestMode = 1 Then
            Me.Size = New Size(xSize2, ySize2)
            RadioButton4.Checked = False
            RadioButton5.Checked = True
        End If

        Me.Controls.Add(SpeedPanel1)

        If MotionType = 0 Then
            Me.RadioButton1.Checked = True
            Me.RadioButton2.Checked = False
            Me.RadioButton3.Checked = False
            MotionType = 1
        End If
        AddHandler RadioButton1.CheckedChanged, AddressOf RadioButton1_CheckedChanged
        AddHandler RadioButton2.CheckedChanged, AddressOf RadioButton2_CheckedChanged
        AddHandler RadioButton3.CheckedChanged, AddressOf RadioButton3_CheckedChanged


        'Ret = GetMoveParam()
        TypeComboBox1.Items.Add("絶対座標")
        TypeComboBox1.Items.Add("相対座標")
        TypeComboBox1.SelectedIndex = 1
        Me.txtDistance.Text = Format(1, "F1")


        lblComment.Text = "ok"

        Label1.Text = "増分値"

        Me.Label1.Visible = True
        Me.Label2.Visible = True
        Me.txtDistance.Visible = True
        Me.TypeComboBox1.Visible = True
        Me.Label3.Visible = True

        'Call SpeedPanel(GroupBox1, Speed)

        'If PistonSpeed = 0 Then
        '    PistonSpeed = 1.0
        '    PlusSpeed = Int(PistonSpeed * CC)
        'End If

        Chart = New LoadScedule
        Chart.Location = New Point(15, 327)
        Me.Controls.Add(Chart)

        LoadGraph1 = New LoadGraph
        LoadGraph1.Location = New Point(560, 12)
        Me.Controls.Add(LoadGraph1)

    End Sub



    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        If RadioButton1.Checked = True Then
            MotionType = CSMC_PTP
            Me.Label1.Visible = True
            Me.Label2.Visible = True
            Me.txtDistance.Visible = True
            Me.TypeComboBox1.Visible = True
            Me.Label3.Visible = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
        If RadioButton2.Checked = True Then
            MotionType = CSMC_JOG
            Me.Label1.Visible = False
            Me.Label2.Visible = False
            Me.txtDistance.Visible = False
            Me.TypeComboBox1.Visible = False
            Me.Label3.Visible = False
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)
        If RadioButton3.Checked = True Then
            MotionType = CSMC_ORG
            Me.Label1.Visible = False
            Me.Label2.Visible = False
            Me.txtDistance.Visible = False
            Me.TypeComboBox1.Visible = False
            Me.Label3.Visible = False
        End If

    End Sub



    Function SetMoveParam() As Boolean

        '----------------------------------
        ' Set Resolution to Driver
        '----------------------------------
        'Try
        '    dblResolveSpeed = Val(txtResolution.Text)
        'Catch ex As Exception
        '    dblResolveSpeed = 0
        'End Try
        Ret = SmcWSetResolveSpeed(Id, AxisNo, ResolveSpeed)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetResolveSpeed = " & Ret & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '----------------------------------
        ' Set StartSpeed to Driver
        '----------------------------------
        'Try
        '    dblStartSpeed = Val(txtStartSpeed.Text)
        'Catch ex As Exception
        '    dblStartSpeed = 0
        'End Try
        Ret = SmcWSetStartSpeed(Id, AxisNo, StartSpeed)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetStartSpeed = " & Ret & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '----------------------------------
        ' Set TargetSpeed to Driver
        '----------------------------------
        'Try
        '    dblTargetSpeed = Val(txtTargetSpeed.Text)
        'Catch ex As Exception
        '    dblTargetSpeed = 0
        'End Try

        TargetSpeed = Int(SpeedPanel1.SetSpeed / CC)
        Ret = SmcWSetTargetSpeed(Id, AxisNo, TargetSpeed)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetTargetSpeed = " & Ret & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '----------------------------------
        ' Set AccelTime to Driver
        '----------------------------------
        'Try
        '    dblAccelTime = Val(txtAccelTime.Text)
        'Catch ex As Exception
        '    dblAccelTime = 0
        'End Try
        Ret = SmcWSetAccelTime(Id, AxisNo, AccelTime)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetAccelTime = " & Ret & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '----------------------------------
        ' Set DecelTime to Driver
        '----------------------------------
        'Try
        '    dblDecelTime = Val(txtDecelTime.Text)
        'Catch ex As Exception
        '    dblDecelTime = 0
        'End Try
        Ret = SmcWSetDecelTime(Id, AxisNo, DecelTime)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetDecelTime = " & Ret & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '-----------------------------
        ' Set SSpeed to Driver
        '-----------------------------
        'Try
        '    dblSSpeed = Val(txtSSpeed.Text)
        'Catch ex As Exception
        '    dblSSpeed = 0
        'End Try
        'dwRet = SmcWSetSSpeed(Id, AxisNo, dblSSpeed)
        'If dwRet <> 0 Then
        '    SmcWGetErrorString(dwRet, ErrorString)
        '    lblComment.Text = "SmcWSetSSpeed = " & dwRet & " : " & ErrorString.ToString
        '    SetMoveParam = False
        '    Exit Function
        'End If

        '-------------------------
        ' Set Distance to Driver
        '-------------------------
        'MotionType = TypeComboBox1.SelectedIndex

        If MotionType <> CSMC_PTP Then
            SetMoveParam = True
            Exit Function
        End If

        Try
            lDistance = Int(Val(txtDistance.Text) / CC)
        Catch ex As Exception
            lDistance = 0
        End Try
        If bCoordinate = CSMC_INC Then
            lDistance = System.Math.Abs(lDistance)
            If StartDir = CSMC_CCW Then
                lDistance = -(lDistance)
            End If
        End If

        bCoordinate = TypeComboBox1.SelectedIndex
        Ret = SmcWSetStopPosition(Id, AxisNo, bCoordinate, lDistance)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetStopPosition = " & Ret & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        SetMoveParam = True

    End Function

    Function GetMoveParam() As Boolean

        '----------------------------------
        ' Set default value of Resolution
        '----------------------------------
        Ret = SmcWGetResolveSpeed(Id, AxisNo, ResolveSpeed)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWGetResolveSpeed = " & Ret & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        'txtResolution.Text = Str(dblResolveSpeed)

        '----------------------------------
        ' Set default value of StartSpeed
        '----------------------------------
        Ret = SmcWGetStartSpeed(Id, AxisNo, StartSpeed)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWGetStartSpeed = " & Ret & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        'txtStartSpeed.Text = Str(dblStartSpeed)

        '----------------------------------
        ' Set default value of TargetSpeed
        '----------------------------------
        Ret = SmcWGetTargetSpeed(Id, AxisNo, TargetSpeed)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWGetTargetSpeed = " & Ret & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        'txtTargetSpeed.Text = Str(dblTargetSpeed)

        '----------------------------------
        ' Set default value of AccelTime
        '----------------------------------
        Ret = SmcWGetAccelTime(Id, AxisNo, AccelTime)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWGetAccelTime = " & Ret & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        'txtAccelTime.Text = Str(dblAccelTime)

        '----------------------------------
        ' Set default value of DecelTime
        '----------------------------------
        Ret = SmcWGetDecelTime(Id, AxisNo, DecelTime)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWGetDecelTime = " & Ret & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        'txtDecelTime.Text = Str(dblDecelTime)

        '-----------------------------
        ' Set default value of SSpeed
        '-----------------------------
        'Ret = SmcWGetSSpeed(Id, AxisNo, dblSSpeed)
        'If dwRet <> 0 Then
        '    SmcWGetErrorString(dwRet, ErrorString)
        '    lblComment.Text = "SmcWGetSSpeed = " & dwRet & " : " & ErrorString.ToString
        '    GetMoveParam = False
        '    Exit Function
        'End If

        'txtSSpeed.Text = Str(dblSSpeed)

        '----------------------------------
        ' Set default value of lDistance
        '----------------------------------
        Ret = SmcWGetStopPosition(Id, AxisNo, bCoordinate, lDistance)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWGetStopPosition = " & Ret & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        txtDistance.Text = Format(lDistance * CC, "F1")
        TypeComboBox1.SelectedIndex = bCoordinate

        GetMoveParam = True

    End Function


    Private Sub CW_Button_Click(sender As Object, e As EventArgs) Handles CW_Button.Click
        StartDir = CSMC_CW
        '----------------------------------
        ' Set parameters to Driver
        '----------------------------------
        Ret = SetMoveParam()
        If Ret = False Then
            Exit Sub
        End If

        '---------------
        ' Ready motion
        '---------------
        Ret = SmcWSetReady(Id, AxisNo, MotionType, StartDir)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetReady = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        '---------------
        ' Start Motion
        '---------------
        Ret = SmcWMotionStart(Id, AxisNo)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWMotionStart = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        '-------------------------------------
        ' Get setting parameters from Driver
        '-------------------------------------
        Ret = GetMoveParam()
        If Ret = False Then
            Exit Sub
        End If

        lblComment.Text = "OK "
        'lblComment.Text = ""
    End Sub

    Private Sub CCW_Button_Click_1(sender As Object, e As EventArgs) Handles CCW_Button.Click
        StartDir = CSMC_CCW
        '----------------------------------
        ' Set parameters to Driver
        '----------------------------------
        Ret = SetMoveParam()
        If Ret = False Then
            Exit Sub
        End If

        '---------------
        ' Ready motion
        '---------------
        Ret = SmcWSetReady(Id, AxisNo, MotionType, StartDir)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetReady = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        '---------------
        ' Start Motion
        '---------------
        Ret = SmcWMotionStart(Id, AxisNo)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWMotionStart = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        '-------------------------------------
        ' Get setting parameters from Driver
        '-------------------------------------
        Ret = GetMoveParam()
        If Ret = False Then
            Exit Sub
        End If

        lblComment.Text = "OK "
        'lblComment.Text = ""
    End Sub

    Private Sub STOP_Button_Click_1(sender As Object, e As EventArgs) Handles STOP_Button.Click

        Ret = SmcWMotionStop(Id, AxisNo)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWMotionStop = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        lblComment.Text = "OK "
    End Sub

    Private Sub TypeComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeComboBox1.SelectedIndexChanged
        If TypeComboBox1.SelectedIndex = 0 Then
            Label1.Text = "目標座標"
        ElseIf TypeComboBox1.SelectedIndex = 1 Then
            Label1.Text = "増分値"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim bEventMode As Byte

        If CheckBox1.Checked = True Then
            bEventMode = CSMC_ENABLE
        ElseIf CheckBox1.Checked = False Then
            bEventMode = CSMC_DISABLE
        End If

        '----------------------------------
        ' Set Event for StopMotion to Driver
        '----------------------------------
        Ret = SmcWStopEvent(Id, AxisNo, Me.Handle.ToInt32, bEventMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWStopEvent = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim bEventMode As Byte

        Try
            lCountPulse1 = Int(Val(TextBox1.Text) / CC)
        Catch ex As Exception
            lCountPulse1 = 0
        End Try

        If CheckBox2.Checked = True Then
            bEventMode = CSMC_ENABLE
        ElseIf CheckBox2.Checked = False Then
            bEventMode = CSMC_DISABLE
        End If

        '----------------------------------
        ' Set Event for Encoder to Driver
        '----------------------------------
        Ret = SmcWCountEvent(Id, AxisNo, Me.Handle.ToInt32, bEventMode, CSMC_ENCODER, lCountPulse1)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWCountEvent = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)

        Dim szMsg As String
        Dim Title As String

        'Bank Message Function
        'If m.Msg = CSMC_MESSAGE + 3 Then
        '    szMsg = "BankNo is " & Val(wBankNo) & "."
        '    Title = "Bank Event"
        '    MessageBox.Show(szMsg, Title, MessageBoxButtons.OK)-
        'End If

        'CountPulse Message Function
        If m.Msg = CSMC_MESSAGE + 2 Then
            szMsg = "Encoder is " & Val(lCountPulse) & "."
            Title = "Encoder Event"
            'MessageBox.Show(szMsg, Title, MessageBoxButtons.OK)
            lblComment.Text += " " + szMsg
        End If

        'OutPulse Message Function
        If m.Msg = CSMC_MESSAGE + 1 Then
            szMsg = "OutPulse is " & Val(lOutPulse) & "."
            Title = "OutPulse Event"
            'MessageBox.Show(szMsg, Title, MessageBoxButtons.OK)
            lblComment.Text += " " + szMsg
        End If

        'Stop Message Function
        If m.Msg = CSMC_MESSAGE Then
            szMsg = "AxisNo" + m.LParam.ToString + " was stop."
            Title = "Stop"
            'MessageBox.Show(szMsg, Title, MessageBoxButtons.OK)
            lblComment.Text += " " + szMsg
        End If

        MyBase.WndProc(m)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim bEventMode As Byte
        If CheckBox2.Checked = True Then
            If IsNumeric(TextBox1.Text) Then

                Try
                    lCountPulse1 = Int(Val(TextBox1.Text) / CC)
                Catch ex As Exception
                    lCountPulse1 = 0
                End Try


                bEventMode = CSMC_ENABLE
                'ElseIf CheckBox2.Checked = False Then
                '    bEventMode = CSMC_DISABLE


                '----------------------------------
                ' Set Event for Encoder to Driver
                '----------------------------------
                Ret = SmcWCountEvent(Id, AxisNo, Me.Handle.ToInt32, bEventMode, CSMC_ENCODER, lCountPulse1)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWCountEvent = " & Ret & " : " & ErrorString.ToString
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            TestMode = 0
            Me.Size = New Size(xSize1, ySize1)
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            TestMode = 1
            Me.Size = New Size(xSize2, ySize2)
        End If
    End Sub


End Class

