'
'******************************************************************************
'
'   加力制御パネルのクラス
'
'                           (2021:kanyama)
'
'******************************************************************************
'
Option Strict Off
Option Explicit On
Imports System.Text
Imports System.Math
Public Class MotorCtl
    Inherits System.Windows.Forms.Form

    Dim Speed = {0.5, 1.0, 2.0, 5.0, 10.0}          ' ピストンスピードの種類(mm/Sec)
    Dim OtherSpeed As Double
    'Dim SpeedPanel1 As SpeedPanel                   ' ピストンスピード選択パネルコントロール
    Dim ErrorString As New StringBuilder("", 256)   ' Error String
    Dim lCountPulse1 As Integer                     ' エンコーダーからのパルス
    Dim RealTimeTimer As Timer                             ' リアルタイム制御のためのタイマー
    Dim KBDFocusTimer As Timer                             ' キーボードの割り込みを優先するためのタイマー
    Dim KBDFocusTimer2 As Timer                             ' キーボードの割り込みを優先するためのタイマー
    Dim ToolTip1 As ToolTip

    Private Sub MotorCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ' パネルが最初に表示された時の初期設定サブルーチン
        '

        PulseType = 4       ' 2パルス方式：負論理
        DirTimer = 1        ' ウエイト
        EncType = 0         ' エンコーダ：A/B （90度位相差）1逓倍
        CtrlOut1 = 0        ' 汎用出力
        CtrlOut2 = 1        ' アラームクリア信号
        CtrlOut3 = 2        ' 偏差カウンタクリア信号
        CtrlIn = 3          ' 制御信号の信号
        OrgLog = 0          ' 原点入力論理
        CtrlInOutLog = &H85 ' 入出力論理［0 0 0 0 0 0 0 0 1 0 0 0 0 1 0 1 ］
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
        CC = 0.001          ' １パルス当たりのピストンの変位量（mm）

        StartSpeed = 100
        AccelTime = 50
        DecelTime = 50
        ResolveSpeed = 1

        AxisNo = 1

        Dim ErrorString As New StringBuilder("", 256)


        device = "SMC001"
        Ret = SmcWInit(device, Id)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWInit = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        lblComment.Text = "OK "

        Call Setting()      ' モーターコントロールボードの初期設定

        ' このパネルの表示位置
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(465, 40)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        ' ステータス表示パネルの表示位置
        Status1 = New Status
        Status1.Visible = True
        Status1.StartPosition = FormStartPosition.Manual
        Status1.Location = New Point(20, 40)

        ' コントロールIOパネルの表示位置
        Cltio1 = New Ctlio
        Cltio1.Visible = True
        Cltio1.StartPosition = FormStartPosition.Manual
        Cltio1.Location = New Point(20, 448)



        ' [スピード選択パネルの作成とメインパネルへの貼り付け]

        basePath = "C:\PistonSpeed"
        filePath = "speed.csv"

        '2つのパスを結合する
        SpeedFileName = System.IO.Path.Combine(basePath, filePath)
        CsvFileLoad(SpeedFileName)

        SpeedPanel1 = New SpeedPanel
        SpeedPanel1.Speed = Speed
        SpeedPanel1.OtherSpeed = OtherSpeed
        SpeedPanel1.Location = New Point(15, 124)
        AddHandler SpeedPanel1.SpeedChange, AddressOf SpeedChange_Event
        Me.Controls.Add(SpeedPanel1)
        SpeedPanel1.b1Clic()

        '［準備・片付けモードの選択]
        If TestMode = 0 Then
            Me.Size = New Size(xSize1, ySize1)
            PreModeRadioButton.Checked = True
            TestModeRadioButton.Checked = False

        ElseIf TestMode = 1 Then '[試験モード]
            Me.Size = New Size(xSize2, ySize2)
            PreModeRadioButton.Checked = False
            TestModeRadioButton.Checked = True
        End If

        ' [モーションタイプの選択（開始時は目標値移動）とイベント処理の設定]
        If MotionType = 0 Then
            Me.PTP_RadioButton1.Checked = True      ' 目標値移動    MotionType = 1
            Me.JOG_RadioButton2.Checked = False     ' 連続運転      MotionType = 2
            'Me.ORG_RadioButton3.Checked = False     ' 原点復帰      MotionType = 3
            MotionType = 1
        End If
        AddHandler PTP_RadioButton1.CheckedChanged, AddressOf PTP_RadioButton_CheckedChanged
        AddHandler JOG_RadioButton2.CheckedChanged, AddressOf JOG_RadioButton_CheckedChanged
        'AddHandler ORG_RadioButton3.CheckedChanged, AddressOf ORG_RadioButton_CheckedChanged


        ' [目標値座標の種類の選択]
        Coordinate_TypeComboBox1.Items.Add("絶対座標")
        Coordinate_TypeComboBox1.Items.Add("相対座標")
        Coordinate_TypeComboBox1.SelectedIndex = 0
        Me.txtDistance.Text = Format(0, "F3")


        lblComment.Text = "ok"

        Coordinate_Label1.Text = "目標値"

        ' [ラベル等の表示]
        Me.Coordinate_Label1.Visible = True            ' [目標値] or [増分値]ラベル
        Me.Coordinate_Label2.Visible = True            ' [座標タイプ]ラベル
        Me.txtDistance.Visible = True       ' [目標値] or [増分値]テキストボックス
        Me.Coordinate_TypeComboBox1.Visible = True     ' [座標タイプ]コンボボックス
        Me.Unit_Label.Visible = True            ' [mm]ラベル

        ' [加力スケジュール表の作成]
        LoadChart1 = New LoadChart
        LoadChart1.Location = New Point(15, 351)
        Me.Controls.Add(LoadChart1)

        ' [加力スケジュールグラフの作成]
        LoadGraph1 = New LoadGraph
        LoadGraph1.Location = New Point(LoadChart1.Location.X + LoadChart1.Width + 15, LoadChart1.Location.Y)
        Me.Controls.Add(LoadGraph1)

        ' [荷重制御時のリアルタイム制御のためのタイマー]
        RealTimeTimer = New Timer
        RealTimeTimer.Interval = RealTimeTimer1_IntTime
        'AddHandler RealTimeTimer.Tick, AddressOf RealTimeTimer1_Tick
        RealTimeTimer.Enabled = False

        ' [キーボード入力を確実に処理するためのタイマー]
        KBDFocusTimer = New Timer
        KBDFocusTimer.Interval = KBDFocusTimer_IntTime
        'AddHandler KBDFocusTimer.Tick, AddressOf KBDFocusTimer_Tick
        KBDFocusTimer.Enabled = False

        EnterKeyLabel.Visible = False   ' [EnterKey]ラベル
        SpaceKeyLabel.Visible = False   ' [SpaceKey]ラベル

        'ToolTipを作成する
        ToolTip1 = New ToolTip()
        ToolTip1.InitialDelay = 1000    'ToolTipが表示されるまでの時間
        ToolTip1.ReshowDelay = 1000     'ToolTipが表示されている時に、別のToolTipを表示するまでの時間
        ToolTip1.AutoPopDelay = 5000    'ToolTipを表示する時間
        ToolTip1.ShowAlways = True      'フォームがアクティブでない時でもToolTipを表示する

        'ButtonにToolTipが表示されるようにする
        ToolTip1.SetToolTip(CW_Button, "アクチュエータのピストンを引きます")
        ToolTip1.SetToolTip(CCW_Button, "アクチュエータのピストンを押します")
        ToolTip1.SetToolTip(STOP_Button, "アクチュエータを停止します")
        ToolTip1.SetToolTip(SpeedPanel1, "ピストンの速度を切り替えます" + vbCrLf + "動作中でも切り替え可能です")
        ToolTip1.SetToolTip(NextStepLabel, "次の目標ステップに進みます" + vbCrLf + "ステップが進まない場合に使用してください")

        KeyHintLabel.Visible = False

        'ORG_RadioButton3.Visible = False    ' 原点復帰のボタンは非表示とする（将来復帰可能とする）

        AIOCheckBox.Checked = True              ' 電圧入力チェックボックスをON
        SpeedControlCheckBox.Checked = True     ' 目標値減速調整チャックボックスをON

        For i As Integer = 0 To AIOMaxCh - 1
            If AIOCheck(i) = Nothing Then AIOCheck(i) = True
            If AIOCoef(i) = 0.0 Then AIOCoef(i) = 1.0
            If AIOPoint(i) = 0 Then AIOPoint(i) = 3
            If AIOUnit(i) = "" Then AIOUnit(i) = "V"
        Next

        ' 電圧の平均値表示のためのデータ数の設定
        MeanSampleNComboBox.Items.Add("5")
        MeanSampleNComboBox.Items.Add("7")
        MeanSampleNComboBox.Items.Add("10")
        MeanSampleNComboBox.Items.Add("15")
        MeanSampleNComboBox.Items.Add("20")
        MeanSampleNComboBox.Items.Add("30")
        MeanSampleNComboBox.SelectedIndex = 0
        MeanSampleN = Val(MeanSampleNComboBox.SelectedItem)
        ReDim AIOMeanData(AIOMaxCh - 1, MeanSampleN - 1)
        AddHandler MeanSampleNComboBox.Click, AddressOf MeanSampleNComboBox_Click

        ' ピストン微調整用ボタンはイネーブル
        PistonAdjustCheckBox.Checked = False
        PlusAdjustButton1.Enabled = False
        PlusAdjustButton2.Enabled = False
        MinusAdjustButton1.Enabled = False
        MinusAdjustButton2.Enabled = False

        BeforeLoadDir = 0     ' 加力方向は未定

    End Sub


    Private Sub SpeedChange_Event(sender As Object, e As EventArgs)
        '
        '   スピード変更処理
        '
        Ret = SmcWGetStopStatus(Id, AxisNo, bStopSts1)
        If Ret = 0 Then
            If bStopSts1 = 0 Then
                Dim TargetSpeed1 As Double = Int(SpeedPanel1.SetSpeed / CC)
                If TargetSpeed1 <> TargetSpeed Then
                    TargetSpeed = TargetSpeed1
                    ' 変更後の速度を設定
                    Ret = SmcWSetTargetSpeed(Id, AxisNo, TargetSpeed)
                    ' 変更後の加速時間を設定(10msec)
                    Ret = SmcWSetAccelTime(Id, AxisNo, 0)
                    ' 変更内容（動作速度と加減速時間を変更）を登録します。
                    Ret = SmcWSetMotionChangeReady(Id, AxisNo, 4)
                    ' モータ速度を変更します。
                    Ret = SmcWMotionChange(Id, AxisNo)

                End If
            End If
        End If

    End Sub


    Private Sub KBDFocusTimer_Tick(sender As Object, e As EventArgs)
        '
        '   タイマー２の処理
        '
        KeyTextBox.Select()     ' 常にKeyTextBoxをフォーカスする
        KeyTextBox.Text = ""
    End Sub

    Private Sub PTP_RadioButton_CheckedChanged(sender As Object, e As EventArgs)
        '
        '   目標値移動選択時の処理
        '
        If PTP_RadioButton1.Checked = True Then
            MotionType = CSMC_PTP
            Me.Coordinate_Label1.Visible = True
            Me.Coordinate_Label2.Visible = True
            Me.txtDistance.Visible = True
            Me.Coordinate_TypeComboBox1.Visible = True
            Me.Unit_Label.Visible = True
        End If
    End Sub

    Private Sub JOG_RadioButton_CheckedChanged(sender As Object, e As EventArgs)
        '
        '   連続運転選択時の処理
        '
        If JOG_RadioButton2.Checked = True Then
            MotionType = CSMC_JOG
            Me.Coordinate_Label1.Visible = False
            Me.Coordinate_Label2.Visible = False
            Me.txtDistance.Visible = False
            Me.Coordinate_TypeComboBox1.Visible = False
            Me.Unit_Label.Visible = False
        End If
    End Sub

    'Private Sub ORG_RadioButton_CheckedChanged(sender As Object, e As EventArgs)
    '    '
    '    '   原点復帰選択時の処理
    '    '
    '    If ORG_RadioButton3.Checked = True Then
    '        MotionType = CSMC_ORG
    '        Me.Coordinate_Label1.Visible = False
    '        Me.Coordinate_Label2.Visible = False
    '        Me.txtDistance.Visible = False
    '        Me.Coordinate_TypeComboBox1.Visible = False
    '        Me.Unit_Label.Visible = False
    '    End If

    'End Sub



    Function SetMoveParam() As Boolean
        '
        '   モーターの動作パラメータの設定
        '

        '----------------------------------
        ' Set Resolution to Driver
        '----------------------------------
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

        bCoordinate = Coordinate_TypeComboBox1.SelectedIndex
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
        '
        '   モーターの動作パラメータの読込
        '

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

        txtDistance.Text = Format(lDistance * CC, "F3")
        Coordinate_TypeComboBox1.SelectedIndex = bCoordinate

        GetMoveParam = True

    End Function


    Private Sub CW_Button_Click(sender As Object, e As EventArgs) Handles CW_Button.Click
        '
        '   「引き」ボタン処理
        '
        StartDir = CSMC_CW

        If TestStartFlag Then
            If SControlNo = 0 Then
                MotionType = 1
            Else
                MotionType = 2
            End If
        End If
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
        'Ret = GetMoveParam()
        'If Ret = False Then
        '    Exit Sub
        'End If

        lblComment.Text = "OK "
        BeforeLoadDir = 1
        LoadDirLabel.Text = "加力方向：引き"
        'lblComment.Text = ""
    End Sub

    Private Sub CCW_Button_Click_1(sender As Object, e As EventArgs) Handles CCW_Button.Click
        '
        '   「押し」ボタン処理
        '
        StartDir = CSMC_CCW

        If TestStartFlag Then
            If SControlNo = 0 Then
                MotionType = 1
            Else
                MotionType = 2
            End If
        End If
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
        'Ret = GetMoveParam()
        'If Ret = False Then
        '    Exit Sub
        'End If

        lblComment.Text = "OK "
        BeforeLoadDir = -1
        LoadDirLabel.Text = "加力方向：押し"
        'lblComment.Text = ""
    End Sub

    Private Sub STOP_Button_Click_1(sender As Object, e As EventArgs) Handles STOP_Button.Click
        '
        '   「停止」ボタン処理
        '

        Ret = SmcWMotionStop(Id, AxisNo)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWMotionStop = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        lblComment.Text = "OK "
    End Sub

    Private Sub TypeComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Coordinate_TypeComboBox1.SelectedIndexChanged
        '
        '   「座標タイプ」コンボボックス変更時の処理
        '
        If Coordinate_TypeComboBox1.SelectedIndex = 0 Then
            Coordinate_Label1.Text = "目標座標"
        ElseIf Coordinate_TypeComboBox1.SelectedIndex = 1 Then
            Coordinate_Label1.Text = "増分値"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles EventCheckBox.CheckedChanged
        '
        '   モーター停止イベントをフォームのイベントに追加する処理
        '
        Dim bEventMode As Byte

        If EventCheckBox.Checked = True Then
            bEventMode = CSMC_ENABLE
        ElseIf EventCheckBox.Checked = False Then
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

    'Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
    '    '
    '    '   目標到達イベントをフォームのイベントに追加する処理
    '    '
    '    Dim bEventMode As Byte

    '    Try
    '        lCountPulse1 = Int(Val(TextBox1.Text) / CC)
    '    Catch ex As Exception
    '        lCountPulse1 = 0
    '    End Try

    '    If CheckBox2.Checked = True Then
    '        bEventMode = CSMC_ENABLE
    '    ElseIf CheckBox2.Checked = False Then
    '        bEventMode = CSMC_DISABLE
    '    End If

    '    '----------------------------------
    '    ' Set Event for Encoder to Driver
    '    '----------------------------------
    '    Ret = SmcWCountEvent(Id, AxisNo, Me.Handle.ToInt32, bEventMode, CSMC_ENCODER, lCountPulse1)
    '    If Ret <> 0 Then
    '        SmcWGetErrorString(Ret, ErrorString)
    '        lblComment.Text = "SmcWCountEvent = " & Ret & " : " & ErrorString.ToString
    '        Exit Sub
    '    End If

    'End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        '
        '   モーターのイベントを処理できるよう、WndProcをオーバーライド
        '

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

            If TestStartFlag Then
                Ret = SmcWGetStopStatus(Id, AxisNo, bStopSts1)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWGetStopStatus = " & Ret & " : " & ErrorString.ToString

                End If
                If SControlNo = 0 Then
                    If bStopSts1 = 255 Then     ' 目標値到達の場合のみ次の目標を設定
                        NextLoad()
                    End If
                End If

            End If
        End If

        MyBase.WndProc(m)

    End Sub

    'Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
    '    '
    '    '   目標到達イベント用テキストボックスの変更を処理
    '    '
    '    Dim bEventMode As Byte
    '    If CheckBox2.Checked = True Then
    '        If IsNumeric(TextBox1.Text) Then

    '            Try
    '                lCountPulse1 = Int(Val(TextBox1.Text) / CC)
    '            Catch ex As Exception
    '                lCountPulse1 = 0
    '            End Try


    '            bEventMode = CSMC_ENABLE
    '            'ElseIf CheckBox2.Checked = False Then
    '            '    bEventMode = CSMC_DISABLE


    '            '----------------------------------
    '            ' Set Event for Encoder to Driver
    '            '----------------------------------
    '            Ret = SmcWCountEvent(Id, AxisNo, Me.Handle.ToInt32, bEventMode, CSMC_ENCODER, lCountPulse1)
    '            If Ret <> 0 Then
    '                SmcWGetErrorString(Ret, ErrorString)
    '                lblComment.Text = "SmcWCountEvent = " & Ret & " : " & ErrorString.ToString
    '                Exit Sub
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub PreModeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles PreModeRadioButton.CheckedChanged
        '
        '   「準備・片付け」選択時の処理
        '

        If PreModeRadioButton.Checked = True Then
            TestMode = 0
            Me.Size = New Size(xSize1, ySize1)
            KBDControlCheckBox.Visible = True
            LoadDirLabel.Visible = True
            BeforeLoadDir = 0
        End If

    End Sub

    Private Sub TestModeRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles TestModeRadioButton.CheckedChanged
        '
        '   「試験」選択時の処理
        '
        If TestModeRadioButton.Checked = True Then
            TestMode = 1
            Me.Size = New Size(xSize2, ySize2)
            Coordinate_TypeComboBox1.SelectedIndex = 0
            KBDControlCheckBox.Visible = False
            LoadDirLabel.Visible = False
            BeforeLoadDir = 0
        End If
    End Sub

    Private Sub TestStartButton_Click(sender As Object, e As EventArgs) Handles TestStartButton.Click
        's^ur/i
        '   「試験開始」ボタンの処理
        '
        'KBDFocusTimer.Enabled = False

        If PointN > 0 Then
            If TestStartFlag = False Then
                RowsIndex1 = 0
                Do
                    If LoadChart1.DataGridView1.Rows(RowsIndex1).Cells(0).Value = True Then
                        Dim s As String = LoadChart1.DataGridView1.Rows(RowsIndex1).Cells(1).Value
                        Select Case s
                            Case "ストローク"
                                SControlNo = 0
                            Case Else
                                SControlNo = Val(s.Substring(2, 1)) + 1
                        End Select
                        Exit Do
                    End If
                    RowsIndex1 += 1
                    If RowsIndex1 > LoadChart1.DataGridView1.RowCount - 1 Then
                        MessageBox.Show("有効データがありません。。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Loop

                LoadChart1.DataGridView1.CurrentCell = LoadChart1.DataGridView1.Rows(RowsIndex1).Cells(0)
                LoadGraph1.DrawGraph(0)

                If AIOCheckBox.Checked = True Then
                    AIOStartFlag = True
                    Ret = AioInit(AIODevice, AIOId)
                    If Ret <> 0 Then
                        Dim Ret2 As Integer = AioGetErrorString(Ret, ErrorString)
                        Text_ErrorString.Text = "AioInit = " & Ret & " : " & ErrorString.ToString()
                        Exit Sub
                    End If

                    Text_ErrorString.Text = "初期化処理 : 正常終了"
                    MeanDataNo = 0
                    For i As Integer = 0 To AIOMaxCh - 1
                        AIOMean(i) = 0.0
                        For j As Integer = 0 To MeanSampleN - 1
                            AIOMeanData(i, j) = 0.0
                        Next
                    Next
                End If

                Select Case SControlNo
                    Case 0  ' ストローク制御
                        InitialPulse = lOutPulse
                        InitialDisp = lOutDisp
                        'DestinationLabel.Text = Format(InitialDisp)
                        PointI2 = 1
                        lDistanceDisp = InitialDisp + LoadPoint2(PointI2)
                        txtDistance.Text = Format(lDistanceDisp, "F3")
                        DestinationLabel.Text = Format(lDistanceDisp, "F3")
                        'txtDistance.Text = Format(InitialDisp + LoadPoint2(PointI2), "F3")
                        ControlModeLabel.Text = "ストローク"
                        RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")
                        PTP_RadioButton1.PerformClick()
                        Coordinate_TypeComboBox1.SelectedIndex = 0
                        EventCheckBox.Checked = True
                        MotionType = CSMC_PTP
                        EventCheckBox.Checked = True
                        PistonAdjustCheckBox.Checked = False

                    Case Else  ' 電圧制御
                        InitialPulse = lOutPulse
                        InitialDisp = lOutDisp
                        PointI2 = 1
                        ControlChNo = SControlNo - 1
                        lDistanceDisp = LoadPoint2(PointI2)
                        txtDistance.Text = Format(lDistanceDisp, "F3")
                        DestinationLabel.Text = Format(lDistanceDisp, "F3")
                        'txtDistance.Text = Format(InitialDisp + LoadPoint2(PointI2), "F3")
                        ControlModeLabel.Text = "Ch" + Format(ControlChNo)
                        RecentValueLabel.Text = Format(AIOMean(ControlChNo), "F3")
                        JOG_RadioButton2.PerformClick()
                        Coordinate_TypeComboBox1.SelectedIndex = 0
                        EventCheckBox.Checked = True
                        MotionType = CSMC_JOG
                        EventCheckBox.Checked = False
                        PistonAdjustCheckBox.Checked = True
                End Select

                TestStartView()

            Else
                ' 試験モードを終了
                Dim result As DialogResult = MessageBox.Show("本当に試験を終了しますか？", "確認", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    If AIOStartFlag = True Then
                        AIOStartFlag = False
                        Ret = AioExit(AIOId)
                        If Ret <> 0 Then
                            Ret2 = AioGetErrorString(Ret, ErrorString)
                            Text_ErrorString.Text = "AioExit = " & Ret & " : " & ErrorString.ToString()
                            Exit Sub
                        End If

                        Text_ErrorString.Text = "終了処理 : 正常終了"
                    End If

                    TestStopView()
                End If



            End If


        Else
            ' 加力スケジュールが未入力の場合はエラーメッセージを表示

            MessageBox.Show("加力スケジュールを入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If

        'KBDFocusTimer.Enabled = True

    End Sub


    Private Sub RealTimeTimer1_Tick(sender As Object, e As EventArgs)
        '
        '   荷重制御時のリアルタイム処理
        '
        If AIOStartFlag Then
            'アナログ入力

            Ret = AioMultiAiEx(AIOId, CShort(AIOMaxCh), AiData)
            If Ret <> 0 Then
                Ret2 = AioGetErrorString(Ret, ErrorString)
                Text_ErrorString.Text = "AioMultiAiEx = " & Ret & " : " & ErrorString.ToString()
                If Ret <> 21861 Then
                    Exit Sub
                End If
            Else
                Text_ErrorString.Text = "アナログ入力 : 正常終了"
            End If

            '変換データの表示
            Dim fm1 As String
            AIODataTextBox.Text = ""
            For i As Integer = 0 To AIOMaxCh - 1
                If AIOCheck(i) Then
                    AIOData(i) = AiData(i) * AIOCoef(i)
                    AIOMeanData(i, MeanDataNo) = AIOData(i)
                    Dim s As Double = 0.0
                    For j As Integer = 0 To MeanSampleN - 1
                        s += AIOMeanData(i, j)
                    Next
                    AIOMean(i) = s / MeanSampleN

                    Select Case AIOPoint(i)
                        Case 0
                            fm1 = "+0;-0"
                        Case 1
                            fm1 = "+0.0;-0.0"
                        Case 2
                            fm1 = "+0.#0;-0.#0"
                        Case 3
                            fm1 = "+0.##0;-0.##0"
                        Case 4
                            fm1 = "+0.###0;-0.###0"
                        Case 5
                            fm1 = "+0.####0;-0.####0"
                        Case Else
                            fm1 = "F4"
                    End Select
                    AIODataTextBox.Text = AIODataTextBox.Text + Format(i) & ":" + Format(AIOMean(i), fm1) +
                        " " + AIOUnit(i) + vbCrLf

                End If
            Next i
            MeanDataNo += 1
            If MeanDataNo >= MeanSampleN Then
                MeanDataNo = 0
            End If
        End If

        Select Case SControlNo
            Case 0

                ' ストローク制御の場合、相対変位を表示
                RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")

            Case Else

                ' 電圧制御の場合、制御CHの絶対値を表示
                RecentValueLabel.Text = Format(AIOMean(ControlChNo), "F3")

                ' モータの停止状態を取得
                Ret = SmcWGetStopStatus(Id, AxisNo, bStopSts1)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWGetStopStatus = " & Ret & " : " & ErrorString.ToString
                    'Exit Sub
                End If

                If bStopSts1 = 0 Then   ' モータが動いている場合に以下を実施

                    Ret = SmcWGetReady(Id, AxisNo, MotionType, StartDir)    ' モータの回転方向を取得
                    If Ret <> 0 Then
                        SmcWGetErrorString(Ret, ErrorString)
                        lblComment.Text = "SmcWGetStopStatus = " & Ret & " : " & ErrorString.ToString
                        Exit Sub
                    End If

                    Dim StopFlag As Boolean = False
                    ' 目標値に到達しているかをチェック
                    If StartDir = 0 Then    ' 正回転の場合
                        If AIOMean(ControlChNo) >= lDistanceDisp Then
                            StopFlag = True
                        End If
                    Else                    ' 負回転の場合
                        If AIOMean(ControlChNo) <= lDistanceDisp Then
                            StopFlag = True
                        End If
                    End If

                    If StopFlag Then    ' 目標値に到達した場合はモータを停止して次の目標を設定
                        Ret = SmcWMotionStop(Id, AxisNo)
                        If Ret <> 0 Then
                            SmcWGetErrorString(Ret, ErrorString)
                            lblComment.Text = "SmcWMotionStop = " & Ret & " : " & ErrorString.ToString
                            Exit Sub
                        End If
                        System.Threading.Thread.Sleep(100)
                        NextLoad()
                        Exit Sub

                    End If

                    ' 目標値減速調整
                    If SpeedControlCheckBox.Checked = True Then

                        If Delta1 > 0 Then  ' 増分値が設定されている場合のみ速度調整を行う。

                            Dim TargetSpeed1 As Double = 0.0

                            Select Case Abs(lDistanceDisp - AIOMean(ControlChNo))
                                Case <= Delta1 * (1.0# - DeceleratePoint3)

                                    TargetSpeed1 = Int(SpeedPanel1.SetSpeed * DecelerateRate3 / CC)

                                Case <= Delta1 * (1.0# - DeceleratePoint2)

                                    TargetSpeed1 = Int(SpeedPanel1.SetSpeed * DecelerateRate2 / CC)

                                Case <= Delta1 * (1.0# - DeceleratePoint1)

                                    TargetSpeed1 = Int(SpeedPanel1.SetSpeed * DecelerateRate1 / CC)

                            End Select

                            If TargetSpeed1 >= 0.29296875 Then
                                Ret = SmcWSetTargetSpeed(Id, AxisNo, TargetSpeed1)
                                Ret = SmcWSetAccelTime(Id, AxisNo, 0)
                                Ret = SmcWSetMotionChangeReady(Id, AxisNo, 4)
                                Ret = SmcWMotionChange(Id, AxisNo)
                            End If
                        End If
                    End If

                End If
        End Select

    End Sub




    Private Sub TestStartView()
        '
        '   試験時のボタン表示等の設定
        '
        TestStartButton.Text = "試験停止"
        testModeLabel.Text = "試験中"
        testModeLabel.ForeColor = Color.Red
        TestStartFlag = True

        RealTimeTimer.Enabled = True
        KBDFocusTimer.Enabled = True
        AddHandler RealTimeTimer.Tick, AddressOf RealTimeTimer1_Tick
        AddHandler KBDFocusTimer.Tick, AddressOf KBDFocusTimer_Tick

        AddHandler KeyTextBox.KeyDown, AddressOf KeyTextBox1_KeyDown
        'Me.TopMost = True
        EnterKeyLabel.Visible = True
        SpaceKeyLabel.Visible = True

        PTP_RadioButton1.Enabled = False
        JOG_RadioButton2.Enabled = False
        'ORG_RadioButton3.Enabled = False
        PreModeRadioButton.Enabled = False
        TestModeRadioButton.Enabled = False

        Coordinate_TypeComboBox1.Enabled = False
        EventCheckBox.Enabled = False
        SpeedControlCheckBox.Enabled = False

        txtDistance.Enabled = False
        'TextBox1.Enabled = False

        LoadChart1.Button_Enabled = False
        LoadGraph1.Button_Enabled = False

        Status1.Button_Enabled = False
        Cltio1.Button_Enabled = False

        KeyHintLabel.Visible = True

    End Sub

    Private Sub TestStopView()
        '
        '   試験終了時のボタン表示等の設定
        '
        TestStartButton.Text = "試験開始"
        testModeLabel.Text = "準備中"
        testModeLabel.ForeColor = Color.Black
        TestStartFlag = False
        RealTimeTimer.Enabled = False
        KBDFocusTimer.Enabled = False

        RemoveHandler KeyTextBox.KeyDown, AddressOf KeyTextBox1_KeyDown
        'Me.TopMost = False
        EnterKeyLabel.Visible = False
        SpaceKeyLabel.Visible = False

        PTP_RadioButton1.Enabled = True
        JOG_RadioButton2.Enabled = True
        'ORG_RadioButton3.Enabled = True
        PreModeRadioButton.Enabled = True
        TestModeRadioButton.Enabled = True

        Coordinate_TypeComboBox1.Enabled = True
        EventCheckBox.Enabled = True
        SpeedControlCheckBox.Enabled = True

        txtDistance.Enabled = True
        'TextBox1.Enabled = True

        LoadChart1.Button_Enabled = True
        LoadGraph1.Button_Enabled = True

        Status1.Button_Enabled = True
        Cltio1.Button_Enabled = True

        TestStartButton.Enabled = True
        KeyHintLabel.Visible = False

        KBDFocusTimer.Enabled = False

    End Sub

    Private Sub KeyTextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)  ' Handles TextBox1.KeyDown
        '
        '   キーボードの処理h
        '
        'キーが押されたか調べる
        If TestStartFlag = True Then
            Dim key1 As String = e.KeyCode.ToString

            Ret = SmcWGetStopStatus(Id, AxisNo, bStopSts1)
            If Ret <> 0 Then
                SmcWGetErrorString(Ret, ErrorString)
                lblComment.Text = "SmcWGetStopStatus = " & Ret & " : " & ErrorString.ToString
                'Exit Sub
            End If

            Select Case key1
                Case "Return", "Enter"

                    'lblComment.Text += key1
                    If bStopSts1 <> 0 Then  ' モーターが止まっているときは動作開始
                        If SControlNo = 0 Then
                            PTP_RadioButton1.PerformClick()
                        Else
                            JOG_RadioButton2.PerformClick()
                        End If
                        If SControlNo = 0 Then
                            If (lDistanceDisp - lOutDisp) > 0 Then
                                CW_Button.PerformClick()
                            Else
                                CCW_Button.PerformClick()
                            End If
                        Else

                            If LoadDir2(PointI2) > 0 Then
                                CW_Button.PerformClick()
                            Else
                                CCW_Button.PerformClick()
                            End If
                        End If
                        KeyHintLabel.Visible = False
                        Arrive = True
                    Else                    ' モーターが動いている場合は停止
                        STOP_Button.PerformClick()
                        Arrive = False
                        KeyHintLabel.Visible = True
                    End If


                Case "Space"
                    'lblComment.Text += key1
                    STOP_Button.PerformClick()
                    KeyHintLabel.Visible = True
                    Arrive = False

                Case "F1", "S"
                    If bStopSts1 <> 0 Then  ' モーターが止まっているときは動作開始
                        Dim SpeedInputForm1 = New SpeedInputForm
                        SpeedInputForm1.StartPosition = FormStartPosition.CenterScreen
                        SpeedInputForm1.Show()
                    End If

                    'SpeedInputForm1.

                Case "Right"    ' 右矢印キー　少しプラス
                    If PistonAdjustCheckBox.Checked Then
                        MovePiston(PlusDelta1)
                    End If

                Case "Left"    ' 左矢印キー　少しマイナス
                    If PistonAdjustCheckBox.Checked Then
                        MovePiston(MinusDelta1)
                    End If

                Case "Up"      ' 上矢印キー  大きくプラス
                    If PistonAdjustCheckBox.Checked Then
                        MovePiston(PlusDelta2)
                    End If

                Case "Down"    ' 下矢印キー　大きくマイナス
                    If PistonAdjustCheckBox.Checked Then
                        MovePiston(MinusDelta2)
                    End If

            End Select

        Else
            Dim key1 As String = e.KeyCode.ToString

            Ret = SmcWGetStopStatus(Id, AxisNo, bStopSts1)
            If Ret <> 0 Then
                SmcWGetErrorString(Ret, ErrorString)
                lblComment.Text = "SmcWGetStopStatus = " & Ret & " : " & ErrorString.ToString
                'Exit Sub
            End If

            Select Case key1
                Case "Return", "Enter"

                    'lblComment.Text += key1
                    If bStopSts1 <> 0 Then  ' モーターが止まっているときは動作開始
                        'If SControlNo = 0 Then
                        '    PTP_RadioButton1.PerformClick()
                        'Else
                        '    JOG_RadioButton2.PerformClick()
                        'End If
                        'If SControlNo = 0 Then
                        '    If (lDistanceDisp - lOutDisp) > 0 Then
                        '        CW_Button.PerformClick()
                        '    Else
                        '        CCW_Button.PerformClick()
                        '    End If
                        'Else

                        '    If LoadDir2(PointI2) > 0 Then
                        '        CW_Button.PerformClick()
                        '    Else
                        '        CCW_Button.PerformClick()
                        '    End If
                        'End If
                        Select Case BeforeLoadDir
                            Case = 0
                                ' 何もしない
                            Case > 0
                                CW_Button.PerformClick()
                            Case < 0
                                CCW_Button.PerformClick()
                        End Select
                        KeyHintLabel.Visible = False
                        Arrive = True
                    Else                    ' モーターが動いている場合は停止
                        STOP_Button.PerformClick()
                        Arrive = False
                        KeyHintLabel.Visible = True
                    End If


                Case "Space"
                    'lblComment.Text += key1
                    STOP_Button.PerformClick()
                    KeyHintLabel.Visible = True
                    Arrive = False

                Case "F1", "S"
                    If bStopSts1 <> 0 Then  ' モーターが止まっているときは動作開始
                        Dim SpeedInputForm1 = New SpeedInputForm
                        SpeedInputForm1.StartPosition = FormStartPosition.CenterScreen
                        SpeedInputForm1.Show()
                    End If

                    'SpeedInputForm1.

                Case "Right"    ' 右矢印キー　少しプラス
                    If PistonAdjustCheckBox.Checked Then
                        MovePiston(PlusDelta1)
                    End If

                Case "Left"    ' 左矢印キー　少しマイナス
                    If PistonAdjustCheckBox.Checked Then
                        MovePiston(MinusDelta1)
                    End If

                Case "Up"      ' 上矢印キー  大きくプラス
                    If PistonAdjustCheckBox.Checked Then
                        MovePiston(PlusDelta2)
                    End If

                Case "Down"    ' 下矢印キー　大きくマイナス
                    If PistonAdjustCheckBox.Checked Then
                        MovePiston(MinusDelta2)
                    End If

            End Select



        End If

    End Sub
    Private Sub NextLoad()
        '
        '   次の目標値の設定
        '

        PointI2 += 1    ' 目標値カウンタをプラス

        If PointI2 < PointN2 Then           ' その加力スケジュールの行で目標値が残っている場合

            If SControlNo = 0 Then      ' ストローク制御
                lDistanceDisp = InitialDisp + LoadPoint2(PointI2)
                txtDistance.Text = Format(lDistanceDisp, "F3")
                DestinationLabel.Text = Format(lDistanceDisp, "F3")

                If PointN2 > 0 Then
                    LoadGraph1.DrawGraph(PointI2 - 1)
                    RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")
                End If

            Else      ' 電圧制御
                lDistanceDisp = LoadPoint2(PointI2)
                txtDistance.Text = Format(lDistanceDisp, "F3")
                DestinationLabel.Text = Format(lDistanceDisp, "F3")

                If PointN2 > 0 Then
                    LoadGraph1.DrawGraph(PointI2 - 1)
                    RecentValueLabel.Text = Format(AIOMean(ControlChNo), "F3")
                End If
            End If


        Else           ' その加力スケジュールの行で目標値が残っていない場合は次の行へ

            RowsIndex1 += 1     ' 行カウンタをプラス

            If RowsIndex1 <= LoadChart1.DataGridView1.RowCount - 1 Then  ' 次の行がある場合

                Do
                    If LoadChart1.DataGridView1.Rows(RowsIndex1).Cells(0).Value = True Then
                        Dim s As String = LoadChart1.DataGridView1.Rows(RowsIndex1).Cells(1).Value
                        Select Case s
                            Case "ストローク"
                                SControlNo = 0
                            Case Else
                                SControlNo = Val(s.Substring(2, 1)) + 1
                        End Select
                        Exit Do
                    End If
                    RowsIndex1 += 1
                    If RowsIndex1 > LoadChart1.DataGridView1.RowCount - 1 Then
                        MessageBox.Show("有効データがありません。。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Loop

                ' 加力スケジュール表の該当する行の先頭項目に移動
                LoadChart1.DataGridView1.CurrentCell = LoadChart1.DataGridView1.Rows(RowsIndex1).Cells(0)
                ' 加力スケジュールグラフを描画
                LoadGraph1.DrawGraph(0)

                Select Case SControlNo
                    Case 0  ' ストローク制御
                        PointI2 = 1
                        lDistanceDisp = InitialDisp + LoadPoint2(PointI2)
                        txtDistance.Text = Format(lDistanceDisp, "F3")
                        DestinationLabel.Text = Format(lDistanceDisp, "F3")
                        ControlModeLabel.Text = "ストローク"
                        RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")
                        PTP_RadioButton1.PerformClick()
                        Coordinate_TypeComboBox1.SelectedIndex = 0
                        EventCheckBox.Checked = True
                        PistonAdjustCheckBox.Checked = False

                    Case Else  ' 電圧制御
                        PointI2 = 1
                        ControlChNo = SControlNo - 1
                        lDistanceDisp = LoadPoint2(PointI2)
                        txtDistance.Text = Format(lDistanceDisp, "F3")
                        DestinationLabel.Text = Format(lDistanceDisp, "F3")
                        ControlModeLabel.Text = "Ch" + Format(ControlChNo)
                        RecentValueLabel.Text = Format(AIOMean(ControlChNo), "F3")
                        JOG_RadioButton2.PerformClick()
                        Coordinate_TypeComboBox1.SelectedIndex = 0
                        EventCheckBox.Checked = False
                        PistonAdjustCheckBox.Checked = True

                End Select

            Else        ' 次の行がない場合は試験終了
                If PointN2 > 0 Then
                    LoadGraph1.DrawGraph(PointI2 - 1)
                End If

                TestStopView()

            End If
        End If

    End Sub

    Private Sub AIOSettingButton_Click(sender As Object, e As EventArgs) Handles AIOSettingButton.Click
        '
        '   電圧入力の係数設定表を表示
        '
        Dim fm1 As New AIOSettingForm
        fm1.StartPosition = FormStartPosition.CenterScreen
        Dim Ret = fm1.ShowDialog

    End Sub

    Private Sub MeanSampleNComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MeanSampleNComboBox.SelectedIndexChanged
        '
        '   平均値計算のデータ数の変更処理
        '
        MeanSampleN = Val(MeanSampleNComboBox.SelectedItem)
        ReDim AIOMeanData(AIOMaxCh - 1, MeanSampleN - 1)
        MeanDataNo = 0
        For i As Integer = 0 To AIOMaxCh - 1
            AIOMean(i) = 0.0
            For j As Integer = 0 To MeanSampleN - 1
                AIOMeanData(i, j) = 0.0
            Next
        Next

        ' キーボードフォーカスを再開する。
        KBDFocusTimer.Enabled = True
    End Sub

    Private Sub MeanSampleNComboBox_Click(sender As Object, e As EventArgs)
        '
        '   データ数選択コンボボックスをクリックしたときにキーボードフォーカスを停止する。
        '
        KBDFocusTimer.Enabled = False

    End Sub

    Function MovePiston(ByVal DeltaPulse As Integer) As Boolean
        '
        '   ピストン微調整関数
        '
        If TestStartFlag And SControlNo <> 0 Then
            RealTimeTimer.Enabled = False   ' リアルタイム制御を停止
        End If

        If DeltaPulse <> 0 Then
            Dim bStopSts2 As Short
            Ret = SmcWGetStopStatus(Id, AxisNo, bStopSts2)
            If Ret <> 0 Then
                SmcWGetErrorString(Ret, ErrorString)
                lblComment.Text = "SmcWGetStopStatus = " & Ret & " : " & ErrorString.ToString
                'Exit Sub
            End If
            If bStopSts2 <> 0 Then

                'If TestStartFlag And SControlNo <> 0 Then

                '
                '   モーターの動作パラメータの設定
                '

                '----------------------------------
                ' Set Resolution to Driver
                '----------------------------------
                Ret = SmcWSetResolveSpeed(Id, AxisNo, ResolveSpeed)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWSetResolveSpeed = " & Ret & " : " & ErrorString.ToString
                    MovePiston = False
                    Exit Function
                End If

                '----------------------------------
                ' Set StartSpeed to Driver
                '----------------------------------
                Ret = SmcWSetStartSpeed(Id, AxisNo, StartSpeed)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWSetStartSpeed = " & Ret & " : " & ErrorString.ToString
                    MovePiston = False
                    Exit Function
                End If

                '----------------------------------
                ' Set TargetSpeed to Driver
                '----------------------------------
                Dim TargetSpeed2 As Double
                TargetSpeed2 = Int(SpeedPanel1.SetSpeed / CC)
                Ret = SmcWSetTargetSpeed(Id, AxisNo, TargetSpeed2)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWSetTargetSpeed = " & Ret & " : " & ErrorString.ToString
                    MovePiston = False
                    Exit Function
                End If

                '----------------------------------
                ' Set AccelTime to Driver
                '----------------------------------
                Ret = SmcWSetAccelTime(Id, AxisNo, AccelTime)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWSetAccelTime = " & Ret & " : " & ErrorString.ToString
                    MovePiston = False
                    Exit Function
                End If

                '----------------------------------
                ' Set DecelTime to Driver
                '----------------------------------
                Ret = SmcWSetDecelTime(Id, AxisNo, DecelTime)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWSetDecelTime = " & Ret & " : " & ErrorString.ToString
                    MovePiston = False
                    Exit Function
                End If

                Ret = SmcWSetStopPosition(Id, AxisNo, 1, DeltaPulse)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWSetStopPosition = " & Ret & " : " & ErrorString.ToString
                    MovePiston = False
                    Exit Function
                End If
                Dim StartDir2 As Short
                If DeltaPulse > 0 Then
                    StartDir2 = 0
                Else
                    StartDir2 = 1
                End If
                Ret = SmcWSetReady(Id, AxisNo, CSMC_INC, StartDir2)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWSetReady = " & Ret & " : " & ErrorString.ToString
                    MovePiston = False
                    Exit Function
                End If

                '---------------
                ' Start Motion
                '---------------
                Ret = SmcWMotionStart(Id, AxisNo)
                If Ret <> 0 Then
                    SmcWGetErrorString(Ret, ErrorString)
                    lblComment.Text = "SmcWMotionStart = " & Ret & " : " & ErrorString.ToString
                    MovePiston = False
                    Exit Function
                End If

                Do
                    Ret = SmcWGetStopStatus(Id, AxisNo, bStopSts2)
                    If Ret <> 0 Then
                        SmcWGetErrorString(Ret, ErrorString)
                        lblComment.Text = "SmcWGetStopStatus = " & Ret & " : " & ErrorString.ToString
                        'Exit Sub
                    End If
                    If bStopSts2 <> 0 Then Exit Do
                Loop
                'End If

            End If

        End If

        MovePiston = True
        If TestStartFlag And SControlNo <> 0 Then
            RealTimeTimer.Enabled = True   ' リアルタイム制御を再開
        End If
    End Function

    Private Sub PlusAdjustButton1_Click(sender As Object, e As EventArgs) Handles PlusAdjustButton1.Click
        '
        '   ピストンを少しだけプラス側へ移動
        '
        MovePiston(PlusDelta1)

    End Sub

    Private Sub MinusAdjustButton1_Click(sender As Object, e As EventArgs) Handles MinusAdjustButton1.Click
        '
        '   ピストンを少しだけマイナス側へ移動
        '
        MovePiston(MinusDelta1)

    End Sub

    Private Sub PlusAdjustButton2_Click(sender As Object, e As EventArgs) Handles PlusAdjustButton2.Click
        '
        '   ピストンを大きくプラス側へ移動
        '
        MovePiston(PlusDelta2)

    End Sub

    Private Sub MinusAdjustButton2_Click(sender As Object, e As EventArgs) Handles MinusAdjustButton2.Click
        '
        '   ピストンを大きくマイナス側へ移動
        '
        MovePiston(MinusDelta2)

    End Sub

    Private Sub PistonAdjustCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PistonAdjustCheckBox.CheckedChanged
        '
        '   ピストン微調整チェックボックスの処理
        '
        MinusAdjustButton1.Enabled = PistonAdjustCheckBox.Checked
        PlusAdjustButton1.Enabled = PistonAdjustCheckBox.Checked
        PlusAdjustButton2.Enabled = PistonAdjustCheckBox.Checked
        MinusAdjustButton2.Enabled = PistonAdjustCheckBox.Checked

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        '
        '   終了メニューの処理
        '
        If Not TestStartFlag Then
            Dim result As DialogResult = MessageBox.Show("プログラムを終了しますか？", "確認", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                End
            Else
                Dim result2 As DialogResult = MessageBox.Show("試験モードを終了してください", "エラー", MessageBoxButtons.OK)
            End If

        End If
    End Sub

    Private Sub frmClose_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '
        '   クローズボタンの処理
        '
        If Not TestStartFlag Then
            If e.CloseReason = CloseReason.UserClosing Then
                'ボタンでのクローズかチェック
                Dim result As DialogResult = MessageBox.Show("プログラムを終了しますか？", "確認", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    e.Cancel = True
                End If
            End If
        Else
            If e.CloseReason = CloseReason.UserClosing Then
                'Dim result As DialogResult = MessageBox.Show("試験モードを終了してください", "エラー", MessageBoxButtons.OK)
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub 電圧入力設定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 電圧入力設定ToolStripMenuItem.Click
        '
        '   電圧入力設定メニューの処理
        '
        Dim fm1 As New AIOSettingForm
        fm1.StartPosition = FormStartPosition.CenterScreen
        Dim Ret = fm1.ShowDialog
        If Ret = DialogResult.OK Then

        End If
    End Sub

    Private Sub Setting（）
        '
        '   モータコントロールボードの初期化
        '
        Dim ErrorString As New StringBuilder("", 256)

        Ret = SmcWSetPulseType(Id, AxisNo, PulseType, DirTimer)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetPulseType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetEncType(Id, AxisNo, EncType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetEncType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlTypeOut(Id, AxisNo, CtrlOut1, CtrlOut2, CtrlOut3)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetCtrlTypeOut = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlTypeIn(Id, AxisNo, CtrlIn)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetCtrlTypeIn = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetOrgLog(Id, AxisNo, OrgLog)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetOrgLog = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlInOutLog(Id, AxisNo, CtrlInOutLog)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetCtrlInOutLog = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcMode(Id, AxisNo, ErcMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetErcMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcAlmClearTime(Id, AxisNo, ErcTime, ErcOffTimer, AlmTime)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetErcAlmClearTime = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetOrgMode(Id, AxisNo, LimitTurn, OrgType, EndDir, ZCount)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetOrgMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcMode(Id, AxisNo, ErcMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetErcMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetSAccelType(Id, AxisNo, SAccelType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetSAccelType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetInFilterType(Id, AxisNo, FilterType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetInFilterType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetSDMode(Id, AxisNo, SDMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetSDMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCounterMode(Id, AxisNo, ClearCntLtc, LtcMode, ClearCntClr, ClrMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetCounterMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetInitParam(Id, AxisNo)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWSetInitParam = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        lblComment.Text = "OK "
    End Sub

    Private Sub ピストンスピード設定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ピストンスピード設定ToolStripMenuItem.Click
        Dim SpeedSetForm1 As New SpeedSetForm
        SpeedSetForm1.StartPosition = FormStartPosition.CenterScreen
        Dim Ret = SpeedSetForm1.ShowDialog
        If Ret = DialogResult.OK Then
            SpeedPanel1.Dispose()

            CsvFileLoad(SpeedFileName)
            SpeedPanel1 = New SpeedPanel
            SpeedPanel1.Speed = Speed
            SpeedPanel1.OtherSpeed = OtherSpeed
            SpeedPanel1.Location = New Point(15, 124)
            AddHandler SpeedPanel1.SpeedChange, AddressOf SpeedChange_Event
            Me.Controls.Add(SpeedPanel1)
            SpeedPanel1.b1Clic()
        End If

    End Sub


    Private Sub CsvFileLoad(ByVal LoadFileName As String)

        Dim DirName As String = System.IO.Path.GetDirectoryName(LoadFileName)

        If System.IO.Directory.Exists(DirName) = False Then
            '   ピストンスピード設定ファイルがない場合、新たにcsvファイルを作成する。
            System.IO.Directory.CreateDirectory(DirName)
            CsvFileCreate(LoadFileName)
        End If

        'Dim dbFileName As String = "..\..\..\data\dgvtest1.csv"     '表示するCSVファイルを指定
        Dim n As Integer

        'CSVファイルをSHIFT_JISのコードページのエンコーディングで読込み
        Using sr1 As New System.IO.StreamReader(LoadFileName, System.Text.Encoding.Default)

            'ファイルの最後までループ
            Do Until sr1.Peek = -1
                n = n + 1
                If n = 1 Then
                    '先頭行を項目として表示する場合
                    Dim cmDat() As String = Split(sr1.ReadLine, ",")

                Else
                    '２行目以降のデータの設定

                    Dim cmDat() As String = Split(sr1.ReadLine, ",")
                    ' "" で囲まれているデータは、"" を取り除く
                    For i = 0 To 4
                        cmDat(i) = cmDat(i).Trim(Chr(34))
                        Speed(i) = Val(cmDat(i))

                    Next
                    cmDat(5) = cmDat(5).Trim(Chr(34))
                    OtherSpeed = Val(cmDat(5))
                End If
            Loop
        End Using

    End Sub

    Private Sub CsvFileCreate(ByVal SaveFileName As String)
        '
        '   ピストンスピード設定ファイルがない場合、新たにcsvファイルを作成する。
        '
        Dim dbFileName As String = SaveFileName

        Using swCsv As New System.IO.StreamWriter(dbFileName, False, System.Text.Encoding.GetEncoding("UTF-8"))

            Dim WorkText As String = """Speed1"",""Speed2"",""Speed3"",""Speed4"",""Speed5"",""その他"""
            Dim LineText As String = """0.5"",""1.0"",""2.0"",""5.0"",""10.0"",""0.1"""

            swCsv.WriteLine(WorkText)

            swCsv.WriteLine(LineText)


        End Using

    End Sub

    Private Sub KBDControlCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles KBDControlCheckBox.CheckedChanged
        If KBDControlCheckBox.Checked = True Then


            TestStartFlag = False
            KBDFocusTimer.Enabled = True
            AddHandler KBDFocusTimer.Tick, AddressOf KBDFocusTimer_Tick

            AddHandler KeyTextBox.KeyDown, AddressOf KeyTextBox1_KeyDown
            EnterKeyLabel.Visible = True
            SpaceKeyLabel.Visible = True

            JOG_RadioButton2.PerformClick()

            PTP_RadioButton1.Enabled = False
            JOG_RadioButton2.Enabled = False
            PreModeRadioButton.Enabled = False
            TestModeRadioButton.Enabled = False

            Status1.Button_Enabled = False
            Cltio1.Button_Enabled = False

            KeyHintLabel.Visible = True
            PistonAdjustCheckBox.Checked = True
            BeforeLoadDir = 0
            LoadDirLabel.Text = "加力方向：なし"
        Else
            TestStartFlag = False
            KBDFocusTimer.Enabled = False
            RemoveHandler KBDFocusTimer.Tick, AddressOf KBDFocusTimer_Tick

            RemoveHandler KeyTextBox.KeyDown, AddressOf KeyTextBox1_KeyDown
            EnterKeyLabel.Visible = False
            SpaceKeyLabel.Visible = False

            PTP_RadioButton1.Enabled = True
            JOG_RadioButton2.Enabled = True
            PreModeRadioButton.Enabled = True
            TestModeRadioButton.Enabled = True

            Status1.Button_Enabled = True
            Cltio1.Button_Enabled = True

            KeyHintLabel.Visible = False

            BeforeLoadDir = 0
            LoadDirLabel.Text = "加力方向：なし"
        End If
    End Sub

    Private Sub NextStepLabel_Click(sender As Object, e As EventArgs) Handles NextStepLabel.Click
        If TestStartFlag = True Then
            NextLoad()
        End If
    End Sub











    '==================================================[ Class END ]==============================================
End Class

