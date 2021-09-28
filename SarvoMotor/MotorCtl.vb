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
    Dim SpeedPanel1 As SpeedPanel                   ' ピストンスピード選択パネルコントロール
    Dim ErrorString As New StringBuilder("", 256)   ' Error String
    Dim lCountPulse1 As Integer                     ' エンコーダーからのパルス
    Dim Timer1 As Timer                             ' リアルタイム制御のためのタイマー
    Dim Timer2 As Timer                             ' キーボードの割り込みを優先するためのタイマー


    Private Sub MotorCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ' パネルが最初に表示された時の初期設定サブルーチン
        '
        ' [スピード選択パネルの作成とメインパネルへの貼り付け]
        SpeedPanel1 = New SpeedPanel
        SpeedPanel1.Speed = Speed
        SpeedPanel1.Location = New Point(25, 100)
        Me.Controls.Add(SpeedPanel1)

        '［準備・片付けモードの選択]
        If TestMode = 0 Then
            Me.Size = New Size(xSize1, ySize1)
            RadioButton4.Checked = True
            RadioButton5.Checked = False
        ElseIf TestMode = 1 Then
            Me.Size = New Size(xSize2, ySize2)
            RadioButton4.Checked = False
            RadioButton5.Checked = True
        End If

        ' [モーションタイプの選択（開始時は目標値移動）とイベント処理の設定]
        If MotionType = 0 Then
            Me.RadioButton1.Checked = True      ' 目標値移動    MotionType = 1
            Me.RadioButton2.Checked = False     ' 連続運転      MotionType = 2
            Me.RadioButton3.Checked = False     ' 原点復帰      MotionType = 3
            MotionType = 1
        End If
        AddHandler RadioButton1.CheckedChanged, AddressOf RadioButton1_CheckedChanged
        AddHandler RadioButton2.CheckedChanged, AddressOf RadioButton2_CheckedChanged
        AddHandler RadioButton3.CheckedChanged, AddressOf RadioButton3_CheckedChanged


        ' [目標値座標の種類の選択]
        TypeComboBox1.Items.Add("絶対座標")
        TypeComboBox1.Items.Add("相対座標")
        TypeComboBox1.SelectedIndex = 0
        Me.txtDistance.Text = Format(0, "F3")


        lblComment.Text = "ok"

        Label1.Text = "目標値"

        ' [ラベル等の表示]
        Me.Label1.Visible = True            ' [目標値] or [増分値]ラベル
        Me.Label2.Visible = True            ' [座標タイプ]ラベル
        Me.txtDistance.Visible = True       ' [目標値] or [増分値]テキストボックス
        Me.TypeComboBox1.Visible = True     ' [座標タイプ]コンボボックス
        Me.Label3.Visible = True            ' [mm]ラベル

        ' [加力スケジュール表の作成]
        Chart = New LoadScedule
        Chart.Location = New Point(15, 327)
        Me.Controls.Add(Chart)

        ' [加力スケジュールグラフの作成]
        LoadGraph1 = New LoadGraph
        LoadGraph1.Location = New Point(Chart.Location.X + Chart.Width + 10, Chart.Location.Y)
        Me.Controls.Add(LoadGraph1)

        ' [荷重制御時のリアルタイム制御のためのタイマー]
        Timer1 = New Timer
        Timer1.Interval = 100
        Timer1.Enabled = False
        AddHandler Timer1.Tick, AddressOf Timer1_Tick

        ' [キーボード入力を確実に処理するためのタイマー]
        Timer2 = New Timer
        Timer2.Interval = 500
        Timer2.Enabled = False
        AddHandler Timer2.Tick, AddressOf Timer2_Tick

        EnterKeyLabel.Visible = False   ' [EnterKey]ラベル
        SpaceKeyLabel.Visible = False   ' [SpaceKey]ラベル
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        '
        '   荷重制御時のリアルタイム処理
        '
        RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)
        '
        '   タイマー２の処理
        '
        KeyTextBox.Select()     ' 常にKeyTextBoxをフォーカスする
        KeyTextBox.Text = ""
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        '
        '   目標値移動選択時の処理
        '
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
        '
        '   連続運転選択時の処理
        '
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
        '
        '   原点復帰選択時の処理
        '
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
        TypeComboBox1.SelectedIndex = bCoordinate

        GetMoveParam = True

    End Function


    Private Sub CW_Button_Click(sender As Object, e As EventArgs) Handles CW_Button.Click
        '
        '   「引き」ボタン処理
        '
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
        '
        '   「押し」ボタン処理
        '
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

    Private Sub TypeComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeComboBox1.SelectedIndexChanged
        '
        '   「座標タイプ」コンボボックス変更時の処理
        '
        If TypeComboBox1.SelectedIndex = 0 Then
            Label1.Text = "目標座標"
        ElseIf TypeComboBox1.SelectedIndex = 1 Then
            Label1.Text = "増分値"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        '
        '   モーター停止イベントをフォームのイベントに追加する処理
        '
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
        '
        '   目標到達イベントをフォームのイベントに追加する処理
        '
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
                NextLoad()
            End If
        End If

        MyBase.WndProc(m)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        '
        '   目標到達イベント用テキストボックスの変更を処理
        '
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
        '
        '   「準備・片付け」選択時の処理
        '
        If RadioButton4.Checked = True Then
            TestMode = 0
            Me.Size = New Size(xSize1, ySize1)
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        '
        '   「試験」選択時の処理
        '
        If RadioButton5.Checked = True Then
            TestMode = 1
            Me.Size = New Size(xSize2, ySize2)
            'RadioButton1.Select()
            RadioButton1.PerformClick()
            TypeComboBox1.SelectedIndex = 0
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub TestStartButton_Click(sender As Object, e As EventArgs) Handles TestStartButton.Click
        '
        '   「試験開始」ボタンの処理
        '

        If PointN > 0 Then
            If TestStartFlag = False Then
                RowsIndex1 = 0
                Do
                    If Chart.DataGridView1.Rows(RowsIndex1).Cells(0).Value = True Then
                        Exit Do
                    End If
                    RowsIndex1 += 1
                    If RowsIndex1 > Chart.DataGridView1.RowCount - 1 Then
                        MessageBox.Show("有効データがありません。。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Loop

                Chart.DataGridView1.CurrentCell = Chart.DataGridView1.Rows(RowsIndex1).Cells(0)
                LoadGraph1.DrawGraph(0)

                'PointI2 = 1
                'lDistanceDisp = InitialDisp + LoadPoint2(PointI2)
                'txtDistance.Text = Format(lDistanceDisp, "F3")

                Select Case SControlNo
                    Case 0  ' 変位制御
                        InitialPulse = lOutPulse
                        InitialDisp = lOutDisp
                        InitialLabel.Text = Format(InitialDisp)
                        PointI2 = 1
                        lDistanceDisp = InitialDisp + LoadPoint2(PointI2)
                        txtDistance.Text = Format(lDistanceDisp, "F3")
                        'txtDistance.Text = Format(InitialDisp + LoadPoint2(PointI2), "F3")
                        ControlModeLabel.Text = "変位制御"
                        RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")
                        RadioButton1.PerformClick()
                        TypeComboBox1.SelectedIndex = 0
                        CheckBox1.Checked = True

                    Case 1  ' 荷重制御

                End Select

                TestStartButton.Text = "試験停止"
                testModeLabel.Text = "試験中"
                testModeLabel.ForeColor = Color.Red
                TestStartFlag = True
                Timer1.Enabled = True
                Timer2.Enabled = True

                AddHandler KeyTextBox.KeyDown, AddressOf KeyTextBox1_KeyDown
                Me.TopMost = True
                EnterKeyLabel.Visible = True
                SpaceKeyLabel.Visible = True

            Else
                TestStartButton.Text = "試験開始"
                testModeLabel.Text = "準備中"
                testModeLabel.ForeColor = Color.Black
                TestStartFlag = False
                Timer1.Enabled = False
                Timer2.Enabled = False

                AddHandler KeyTextBox.KeyDown, AddressOf KeyTextBox1_KeyDown
                Me.TopMost = False
                EnterKeyLabel.Visible = False
                SpaceKeyLabel.Visible = False

            End If


        Else
            MessageBox.Show("加力スケジュールを入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub KeyTextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)  ' Handles TextBox1.KeyDown
        '
        '   キーボードの処理
        '
        'キーが押されたか調べる
        If TestStartFlag = True Then
            Dim key1 As String = e.KeyCode.ToString
            Select Case key1
                Case "Return", "Enter"
                    'lblComment.Text += key1
                    If (lDistanceDisp - lOutDisp) > 0 Then
                        CW_Button.PerformClick()
                    Else
                        CCW_Button.PerformClick()
                    End If

                Case "Space"
                    'lblComment.Text += key1
                    STOP_Button.PerformClick()
            End Select
        End If

        'Label1.Text += e.KeyCode.ToString
        'If e.KeyCode = Keys.F1 Then
        '    Console.WriteLine("F1キーが押されました。")
        'End If
    End Sub
    Private Sub NextLoad()
        '
        '   次の目標値の設定
        '
        Ret = SmcWGetStopStatus(Id, AxisNo, bStopSts1)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            lblComment.Text = "SmcWGetStopStatus = " & Ret & " : " & ErrorString.ToString
            'Exit Sub
        End If

        Select Case SControlNo

            Case 0      ' 変位制御

                If Ret = 0 And bStopSts1 = 255 Then     ' 目標値到達による通常停止の場合

                    PointI2 += 1

                    If PointI2 < PointN2 Then           ' その加力スケジュールの行で目標値が残っている場合

                        lDistanceDisp = InitialDisp + LoadPoint2(PointI2)
                        txtDistance.Text = Format(lDistanceDisp, "F3")
                        If PointN2 > 0 Then
                            LoadGraph1.DrawGraph(PointI2 - 1)
                            Select Case SControlNo
                                Case 0  ' 変位制御
                                    ControlModeLabel.Text = "変位制御"
                                    RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")
                            End Select
                        End If

                    Else           ' その加力スケジュールの行で目標値が残っていない場合は次の行へ

                        RowsIndex1 += 1

                        If RowsIndex1 <= Chart.DataGridView1.RowCount - 1 Then  ' 次の行がある場合
                            Do
                                If Chart.DataGridView1.Rows(RowsIndex1).Cells(0).Value = True Then
                                    Exit Do
                                End If
                                RowsIndex1 += 1
                                If RowsIndex1 > Chart.DataGridView1.RowCount - 1 Then
                                    If PointN2 > 0 Then
                                        LoadGraph1.DrawGraph(PointI2 - 1)
                                    End If
                                    System.Threading.Thread.Sleep(500)
                                    TestStartButton.Text = "試験開始"
                                    testModeLabel.Text = "準備中"
                                    RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")
                                    testModeLabel.ForeColor = Color.Black
                                    TestStartFlag = False
                                    Timer1.Enabled = False
                                    Timer2.Enabled = False
                                    RemoveHandler KeyTextBox.KeyDown, AddressOf KeyTextBox1_KeyDown
                                    Me.TopMost = False
                                    EnterKeyLabel.Visible = False
                                    SpaceKeyLabel.Visible = False
                                    Exit Sub
                                End If
                            Loop
                            Chart.DataGridView1.CurrentCell = Chart.DataGridView1.Rows(RowsIndex1).Cells(0)
                            LoadGraph1.DrawGraph(0)
                            PointI2 = 1
                            lDistanceDisp = InitialDisp + LoadPoint2(PointI2)
                            txtDistance.Text = Format(lDistanceDisp, "F3")

                        Else        ' 次の行がない場合は試験終了
                            If PointN2 > 0 Then
                                LoadGraph1.DrawGraph(PointI2 - 1)
                            End If
                            System.Threading.Thread.Sleep(500)
                            TestStartButton.Text = "試験開始"
                            testModeLabel.Text = "準備中"
                            RecentValueLabel.Text = Format(lOutDisp - InitialDisp, "F3")
                            testModeLabel.ForeColor = Color.Black
                            TestStartFlag = False
                            Timer1.Enabled = False
                            Timer2.Enabled = False
                            RemoveHandler KeyTextBox.KeyDown, AddressOf KeyTextBox1_KeyDown
                            Me.TopMost = False
                            EnterKeyLabel.Visible = False
                            SpaceKeyLabel.Visible = False
                        End If
                    End If
                End If

            Case 1      ' 荷重制御







        End Select






    End Sub
End Class

