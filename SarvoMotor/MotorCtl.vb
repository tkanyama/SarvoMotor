Option Strict Off
Option Explicit On
Imports System.Text
Public Class MotorCtl

    Dim Speed = {1.0, 2.0, 5.0, 10.0}
    Dim SpeedKind As Integer
    Dim rbutton() As RadioButton
    Dim rb1 As RadioButton
    Dim Speed1 As Double
    Dim SpeedPanel1 As SpeedPanel
    Dim ErrorString As New StringBuilder("", 256)  'Error String
    Private Sub MotorCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SpeedPanel1 = New SpeedPanel
        SpeedPanel1.Speed = Speed
        SpeedPanel1.Location = New Point(30, 30)
        Me.TabPage1.Controls.Add(SpeedPanel1)

        If MotionType = 0 Then
            Me.RadioButton1.Checked = True
            Me.RadioButton2.Checked = False
            Me.RadioButton3.Checked = False
            MotionType = 1
        End If
        StartSpeed = 100
        AccelTime = 50
        DecelTime = 50
        ResolveSpeed = 1

        TypeComboBox1.Items.Add("絶対座標")
        TypeComboBox1.Items.Add("相対座標")
        TypeComboBox1.SelectedIndex = 1



        'Call SpeedPanel(GroupBox1, Speed)

        'If PistonSpeed = 0 Then
        '    PistonSpeed = 1.0
        '    PlusSpeed = Int(PistonSpeed * CC)
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = Format(SpeedPanel1.SetSpeed, "F1")
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        MotionType = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        MotionType = 2
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        MotionType = 3
    End Sub

    Private Sub CW_Button_Click_1(sender As Object, e As EventArgs) Handles CW_Button.Click
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
            lblComment.Text = "SmcWSetReady = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        '---------------
        ' Start Motion
        '---------------
        dwRet = SmcWMotionStart(Id, AxisNo)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWMotionStart = " & dwRet & " : " & ErrorString.ToString
            Exit Sub
        End If

        '-------------------------------------
        ' Get setting parameters from Driver
        '-------------------------------------
        bRet = GetMoveParam()
        If bRet = False Then
            Exit Sub
        End If

        lblComment.Text = "OK "
    End Sub


    Function SetMoveParam() As Boolean

        '----------------------------------
        ' Set Resolution to Driver
        '----------------------------------
        Try
            dblResolveSpeed = Val(txtResolution.Text)
        Catch ex As Exception
            dblResolveSpeed = 0
        End Try
        dwRet = SmcWSetResolveSpeed(Id, AxisNo, dblResolveSpeed)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetResolveSpeed = " & dwRet & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '----------------------------------
        ' Set StartSpeed to Driver
        '----------------------------------
        Try
            dblStartSpeed = Val(txtStartSpeed.Text)
        Catch ex As Exception
            dblStartSpeed = 0
        End Try
        dwRet = SmcWSetStartSpeed(Id, AxisNo, dblStartSpeed)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetStartSpeed = " & dwRet & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '----------------------------------
        ' Set TargetSpeed to Driver
        '----------------------------------
        Try
            dblTargetSpeed = Val(txtTargetSpeed.Text)
        Catch ex As Exception
            dblTargetSpeed = 0
        End Try
        dwRet = SmcWSetTargetSpeed(Id, AxisNo, dblTargetSpeed)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetTargetSpeed = " & dwRet & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '----------------------------------
        ' Set AccelTime to Driver
        '----------------------------------
        Try
            dblAccelTime = Val(txtAccelTime.Text)
        Catch ex As Exception
            dblAccelTime = 0
        End Try
        dwRet = SmcWSetAccelTime(Id, AxisNo, dblAccelTime)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetAccelTime = " & dwRet & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '----------------------------------
        ' Set DecelTime to Driver
        '----------------------------------
        Try
            dblDecelTime = Val(txtDecelTime.Text)
        Catch ex As Exception
            dblDecelTime = 0
        End Try
        dwRet = SmcWSetDecelTime(Id, AxisNo, dblDecelTime)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetDecelTime = " & dwRet & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '-----------------------------
        ' Set SSpeed to Driver
        '-----------------------------
        Try
            dblSSpeed = Val(txtSSpeed.Text)
        Catch ex As Exception
            dblSSpeed = 0
        End Try
        dwRet = SmcWSetSSpeed(Id, AxisNo, dblSSpeed)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetSSpeed = " & dwRet & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        '-------------------------
        ' Set Distance to Driver
        '-------------------------
        If MotionType <> CSMC_PTP Then
            SetMoveParam = True
            Exit Function
        End If

        Try
            lDistance = Val(txtDistance.Text)
        Catch ex As Exception
            lDistance = 0
        End Try
        If bCoordinate = CSMC_INC Then
            lDistance = System.Math.Abs(lDistance)
            If StartDir = CSMC_CCW Then
                lDistance = -(lDistance)
            End If
        End If

        dwRet = SmcWSetStopPosition(Id, AxisNo, bCoordinate, lDistance)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWSetStopPosition = " & dwRet & " : " & ErrorString.ToString
            SetMoveParam = False
            Exit Function
        End If

        SetMoveParam = True

    End Function

    Function GetMoveParam() As Boolean

        '----------------------------------
        ' Set default value of Resolution
        '----------------------------------
        dwRet = SmcWGetResolveSpeed(Id, AxisNo, dblResolveSpeed)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetResolveSpeed = " & dwRet & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        txtResolution.Text = Str(dblResolveSpeed)

        '----------------------------------
        ' Set default value of StartSpeed
        '----------------------------------
        dwRet = SmcWGetStartSpeed(Id, AxisNo, dblStartSpeed)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetStartSpeed = " & dwRet & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        txtStartSpeed.Text = Str(dblStartSpeed)

        '----------------------------------
        ' Set default value of TargetSpeed
        '----------------------------------
        dwRet = SmcWGetTargetSpeed(Id, AxisNo, dblTargetSpeed)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetTargetSpeed = " & dwRet & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        txtTargetSpeed.Text = Str(dblTargetSpeed)

        '----------------------------------
        ' Set default value of AccelTime
        '----------------------------------
        dwRet = SmcWGetAccelTime(Id, AxisNo, dblAccelTime)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetAccelTime = " & dwRet & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        txtAccelTime.Text = Str(dblAccelTime)

        '----------------------------------
        ' Set default value of DecelTime
        '----------------------------------
        dwRet = SmcWGetDecelTime(Id, AxisNo, dblDecelTime)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetDecelTime = " & dwRet & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        txtDecelTime.Text = Str(dblDecelTime)

        '-----------------------------
        ' Set default value of SSpeed
        '-----------------------------
        dwRet = SmcWGetSSpeed(Id, AxisNo, dblSSpeed)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetSSpeed = " & dwRet & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        txtSSpeed.Text = Str(dblSSpeed)

        '----------------------------------
        ' Set default value of lDistance
        '----------------------------------
        dwRet = SmcWGetStopPosition(Id, AxisNo, bCoordinate, lDistance)
        If dwRet <> 0 Then
            SmcWGetErrorString(dwRet, ErrorString)
            lblComment.Text = "SmcWGetStopPosition = " & dwRet & " : " & ErrorString.ToString
            GetMoveParam = False
            Exit Function
        End If

        txtDistance.Text = Str(lDistance)

        GetMoveParam = True

    End Function

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

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

