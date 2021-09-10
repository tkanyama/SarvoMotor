Option Strict Off
Option Explicit On
Imports System.Text

Public Class Form1

    Private Led1 As LED
    Private Led2 As LED
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        PulseType = 4       ' 2パルス方式：負論理
        DirTimer = 1        ' ウエイト
        EncType = 0         ' エンコーダ：A/B （90度位相差）1逓倍
        CtrlOut1 = 0        ' 汎用出力
        CtrlOut2 = 1        ' アラームクリア信号
        CtrlOut3 = 2        ' 偏差カウンタクリア信号
        CtrlIn = 3          ' 制御信号の信号
        OrgLog = 0          ' 原点入力論理
        CtrlInOutLog = &H8F ' 入出力論理
        ErcMode = 0         ' ERC信号自動出力の設定
        ErcTime = 0         ' 偏差カウンタクリア信号幅
        ErcOffTimer = 0     ' 偏差カウンタクリア信号OFFタイマ時間
        AlmTime = 0         ' アラームクリア信号幅
        LimitTurn = 1       ' リミット反転有効
        OrgType = 0         ' Z相の使用有無
        EndDir = 0          ' 原点復帰時の原点突入方向
        ZCount = 0          ' 原点復帰時のZ相の数
        SAccelType = 0      ' S字加減速の使用
        FilterType = 0      ' 入力フィルターの特性
        SDMode = 0          ' SD信号時の動作
        ClearCntLtc = 0     ' LTC信号が変化したときのクリア動作
        LtcMode = 0         ' LTC信号入力時にラッチするカウンタの種類
        ClearCntClr = 0     ' CLR信号が変化したときのカウンダの種類
        ClrMode = 0         ' 0で固定
        CC = 0.001

        AxisNo = 1

        Dim ErrorString As New StringBuilder("", 256)

        Led1 = New LED
        With Led1
            .Location = New Point(50, 50)
            '.Size = New Size(50, 50)
            .kind = 1
            .Value = False
        End With
        Panel2.Controls.Add(Led1)

        Led2 = New LED
        With Led2
            .Location = New Point(100, 50)
            '.Size = New Size(50, 50)
            .kind = 2
            .Value = False
        End With
        Panel2.Controls.Add(Led2)
        device = "SMC000"
        Ret = SmcWInit(device, Id)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWInit = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        TextBox1.Text = "OK "
        Call Setting()

        Dim Status1 As New Status
        Status1.Location = New Point(500, 200)
        Status1.Visible = True


    End Sub

    Private Sub Setting（）
        Dim ErrorString As New StringBuilder("", 256)

        Ret = SmcWSetPulseType(Id, AxisNo, PulseType, DirTimer)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetPulseType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetEncType(Id, AxisNo, EncType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetEncType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlTypeOut(Id, AxisNo, CtrlOut1, CtrlOut2, CtrlOut3)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetCtrlTypeOut = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlTypeIn(Id, AxisNo, CtrlIn)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetCtrlTypeIn = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetOrgLog(Id, AxisNo, OrgLog)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetOrgLog = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlInOutLog(Id, AxisNo, CtrlInOutLog)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetCtrlInOutLog = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcMode(Id, AxisNo, ErcMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetErcMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcAlmClearTime(Id, AxisNo, ErcTime, ErcOffTimer, AlmTime)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetErcAlmClearTime = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetOrgMode(Id, AxisNo, LimitTurn, OrgType, EndDir, ZCount)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetOrgMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcMode(Id, AxisNo, ErcMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetErcMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetSAccelType(Id, AxisNo, SAccelType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetSAccelType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetInFilterType(Id, AxisNo, FilterType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetInFilterType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetSDMode(Id, AxisNo, SDMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetSDMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCounterMode(Id, AxisNo, ClearCntLtc, LtcMode, ClearCntClr, ClrMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetCounterMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetInitParam(Id, AxisNo)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            TextBox1.Text = "SmcWSetInitParam = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        TextBox1.Text = "OK "
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Led1.Value Then
            Led1.Value = False
        Else
            Led1.Value = True
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Led2.Value Then
            Led2.Value = False
        Else
            Led2.Value = True
        End If

    End Sub
End Class


