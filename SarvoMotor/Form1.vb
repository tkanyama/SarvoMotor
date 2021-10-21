Option Strict Off
Option Explicit On
Imports System.Text

Public Class ServoMotor


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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
        CC = 0.001

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
            Label2.Text = "SmcWInit = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Label2.Text = "OK "
        Call Setting()

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(20, 17)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        Status1 = New Status
        Status1.Visible = True
        Status1.StartPosition = FormStartPosition.Manual
        Status1.Location = New Point(20, 140)


        Cltio1 = New Ctlio
        Cltio1.Visible = True
        Cltio1.StartPosition = FormStartPosition.Manual
        Cltio1.Location = New Point(20, 548)

        Dim MotorCtl1 As New MotorCtl
        MotorCtl1.Visible = True
        MotorCtl1.StartPosition = FormStartPosition.Manual
        MotorCtl1.Location = New Point(465, 140)


        'Dim Testing1 As New Testing
        'Testing1.Visible = True
        'Testing1.StartPosition = FormStartPosition.Manual
        'Testing1.Location = New Point(580, 150)


        'Dim menuFile As New ToolStripMenuItem               'ファイル(&F)
        ''Dim menuFileNew As New ToolStripMenuItem            '新規作成(&N)
        ''Dim menuFileOpen As New ToolStripMenuItem           '開く(&O)
        'Dim menuFileSeparator1 As New ToolStripSeparator    'セパレーター
        ''Dim menuFileSaveAs As New ToolStripMenuItem         '名前を付けて保存(&A)
        ''Dim menuFileSave As New ToolStripMenuItem           '上書き保存(&S)
        ''Dim menuFileSeparator2 As New ToolStripSeparator    'セパレーター
        'Dim menuFileEnd As New ToolStripMenuItem            '終了(&X)

        ''項目の設定
        'menuFile.Text = "ファイル(&F)"
        ''menuFileNew.Text = "新規作成(&N)"
        ''menuFileOpen.Text = "開く(&O)"
        ''menuFileSaveAs.Text = "名前を付けて保存(&A)"
        ''menuFileSave.Text = "上書き保存(&S)"
        'menuFileEnd.Text = "終了(&X)"

        ''★★★ショートカットキーの作成★★★
        ''menuFileNew.ShortcutKeys = Keys.Control Or Keys.N
        ''menuFileOpen.ShortcutKeys = Keys.Control Or Keys.O
        ''menuFileSave.ShortcutKeys = Keys.Shift Or Keys.Control Or Keys.S
        'menuFileEnd.ShortcutKeys = Keys.Control Or Keys.Q

        ''[ファイル(F)]項目に子項目を追加する
        ''menuFile.DropDownItems.Add(menuFileNew)
        ''menuFile.DropDownItems.Add(menuFileOpen)
        'menuFile.DropDownItems.Add(menuFileSeparator1)
        ''menuFile.DropDownItems.Add(menuFileSaveAs)
        ''menuFile.DropDownItems.Add(menuFileSave)
        ''menuFile.DropDownItems.Add(menuFileSeparator2)
        'menuFile.DropDownItems.Add(menuFileEnd)

        'menuFileEnd.Checked += System.EventHandler.

        ''[ファイル(F)]をメニューに追加する
        'MenuStrip1.Items.Add(menuFile)

    End Sub

    Private Sub Setting（）
        Dim ErrorString As New StringBuilder("", 256)

        Ret = SmcWSetPulseType(Id, AxisNo, PulseType, DirTimer)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetPulseType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetEncType(Id, AxisNo, EncType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetEncType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlTypeOut(Id, AxisNo, CtrlOut1, CtrlOut2, CtrlOut3)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetCtrlTypeOut = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlTypeIn(Id, AxisNo, CtrlIn)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetCtrlTypeIn = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetOrgLog(Id, AxisNo, OrgLog)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetOrgLog = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCtrlInOutLog(Id, AxisNo, CtrlInOutLog)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetCtrlInOutLog = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcMode(Id, AxisNo, ErcMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetErcMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcAlmClearTime(Id, AxisNo, ErcTime, ErcOffTimer, AlmTime)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetErcAlmClearTime = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetOrgMode(Id, AxisNo, LimitTurn, OrgType, EndDir, ZCount)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetOrgMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetErcMode(Id, AxisNo, ErcMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetErcMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetSAccelType(Id, AxisNo, SAccelType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetSAccelType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetInFilterType(Id, AxisNo, FilterType)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetInFilterType = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetSDMode(Id, AxisNo, SDMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetSDMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetCounterMode(Id, AxisNo, ClearCntLtc, LtcMode, ClearCntClr, ClrMode)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetCounterMode = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Ret = SmcWSetInitParam(Id, AxisNo)
        If Ret <> 0 Then
            SmcWGetErrorString(Ret, ErrorString)
            Label2.Text = "SmcWSetInitParam = " & Ret & " : " & ErrorString.ToString
            Exit Sub
        End If

        Label2.Text = "OK "
    End Sub



    Private Sub frmClose_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub 終了XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了XToolStripMenuItem.Click
        If Not TestStartFlag Then
            Dim result As DialogResult = MessageBox.Show("プログラムを終了しますか？", "確認", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                End
            Else
                Dim result2 As DialogResult = MessageBox.Show("試験モードを終了してください", "エラー", MessageBoxButtons.OK)
            End If

        End If

    End Sub

    Private Sub 電圧入力設定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 電圧入力設定ToolStripMenuItem.Click
        Dim fm1 As New AIOSettingForm
        Dim Ret = fm1.ShowDialog
        If Ret = DialogResult.OK Then

        End If
    End Sub
End Class


