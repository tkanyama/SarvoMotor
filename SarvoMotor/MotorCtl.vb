Option Strict Off
Option Explicit On
Imports System.Text
Public Class MotorCtl

    Dim Speed = {0.5, 1.0, 2.0, 5.0, 10.0}
    Dim SpeedKind As Integer
    Dim rbutton() As RadioButton
    Dim rb1 As RadioButton
    Dim Speed1 As Double
    Dim SpeedPanel1 As SpeedPanel
    Dim ErrorString As New StringBuilder("", 256)  'Error String
    Private Sub MotorCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a As Integer
        SpeedPanel1 = New SpeedPanel
        SpeedPanel1.Speed = Speed
        SpeedPanel1.Location = New Point(25, 12)
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








    'Private Sub SpeedChange()

    'End Sub

    'Private Sub SpeedPanel(ByRef GBox As GroupBox, ByRef Sp() As Double)
    '    Dim n As Integer
    '    'Dim rbutton() As RadioButton
    '    n = Sp.Length
    '    ReDim rbutton(n - 1)
    '    For i As Integer = 0 To n - 1
    '        rbutton(i) = New RadioButton
    '        With rbutton(i)
    '            .Location = New Point(12, 26 + 25 * i)
    '            .Text = Format(Sp(i), "F1") + "mm/s"
    '        End With
    '        AddHandler rbutton(i).Click, AddressOf rb1_CheckedChanged
    '        GBox.Controls.Add(rbutton(i))
    '    Next
    'End Sub

    'Private Sub rb1_CheckedChanged(sender As Object, e As EventArgs)
    '    Console.WriteLine("Button1がクリックされました")
    'End Sub
End Class

