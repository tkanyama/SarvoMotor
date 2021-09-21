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

    Private Sub MotorCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a As Integer
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

        GroupBox3.Width = 900
        With DataGridView1
            .AllowUserToAddRows = False

            '列数・行数を指定
            '.ColumnCount = 8
            '.RowCount = 1
            Const CellW As Integer = 100

            .Width = CellW * 7 + 95
            .Height = 270



            '列名を指定

            Dim col1 As New DataGridViewCheckBoxColumn
            With col1
                .Name = "select"
                .HeaderText = "有効"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 50
            End With
            .Columns.Add(col1)

            'Dim Col1 As New DataGridViewTextBoxColumn()
            'Col1.HeaderText = "No"
            'Col1.Name = "No"
            ''Col1.Items.Add("")
            'Col1.Width = 100
            '.Columns.Add(Col1)

            Dim Col2 As New DataGridViewComboBoxColumn()
            With Col2
                .Name = "control"
                .HeaderText = "制御"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.Items.Add("")
                .Items.Add("変位")
                .Items.Add("荷重")
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col2)

            Dim Col3 As New DataGridViewTextBoxColumn()
            With Col3
                .Name = "start"
                .HeaderText = "　開始値"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col3)

            Dim Col4 As New DataGridViewTextBoxColumn()
            With Col4
                .Name = "peakp"
                .HeaderText = "上限値"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col4)

            Dim Col5 As New DataGridViewTextBoxColumn()
            With Col5
                .Name = "peakm"
                .HeaderText = "下限値"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col5)

            Dim Col6 As New DataGridViewTextBoxColumn()
            With Col6
                .Name = "end"
                .HeaderText = "終了値"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col6)

            Dim Col7 As New DataGridViewTextBoxColumn()
            With Col7
                .Name = "delta"
                .HeaderText = "増分値"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col7)

            Dim Col8 As New DataGridViewTextBoxColumn()
            With Col8
                .Name = "repeat"
                .HeaderText = "繰り返し回数"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col8)

            '.Columns(0).HeaderText = "No"
            '.Columns(0).Width = 100
            '.Columns(1).HeaderText = "制御"
            '.Columns(1).Width = 100
            '.Columns(2).HeaderText = "開始値"
            '.Columns(2).Width = 100
            '.Columns(3).HeaderText = "上限値"
            '.Columns(3).Width = 100
            '.Columns(4).HeaderText = "下限値"
            '.Columns(4).Width = 100
            '.Columns(5).HeaderText = "終了値"
            '.Columns(5).Width = 100
            '.Columns(6).HeaderText = "増分値"
            '.Columns(6).Width = 100
            '.Columns(7).HeaderText = "回数"
            '.Columns(7).Width = 100


        End With
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

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        With DataGridView1
            RowCount1 = .RowCount
            .Rows.Add()
            RowCount1 += 1
            .Rows(RowCount1 - 1).HeaderCell.Value = Format(RowCount1)
            .Rows(RowCount1 - 1).Cells(0).Value = True
            .Rows(RowCount1 - 1).Cells(0).Selected = True
            .CurrentCell = DataGridView1(0, RowCount1 - 1)
        End With
    End Sub

    Private Sub DelButton_Click(sender As Object, e As EventArgs) Handles DelButton.Click
        With DataGridView1
            Dim row1 As Integer = .CurrentRow.Index
            .Rows.RemoveAt(row1)
            RowCount1 = .RowCount
            If RowCount1 > 0 Then
                For i As Integer = 0 To RowCount1 - 1
                    .Rows(i).HeaderCell.Value = Format(i + 1)
                Next
            End If
        End With
    End Sub

    Private Sub InsButton_Click(sender As Object, e As EventArgs) Handles InsButton.Click
        With DataGridView1
            Dim row1 As Integer
            If RowCount1 > 0 Then
                row1 = .CurrentRow.Index
                .Rows.Insert(row1)
            Else
                .Rows.Add()
                row1 = 0
            End If
            .Rows(row1).Cells(0).Value = True
            RowCount1 = .RowCount
            If RowCount1 > 0 Then
                For i As Integer = 0 To RowCount1 - 1
                    .Rows(i).HeaderCell.Value = Format(i + 1)
                Next
            End If

        End With
    End Sub

    Private Sub DupButton_Click(sender As Object, e As EventArgs) Handles DupButton.Click
        With DataGridView1
            If RowCount1 > 0 Then
                Dim row1 As Integer = .CurrentRow.Index
                'Dim clonedrow As DataGridViewRow
                'clonedrow = DataGridView1.Rows(row1).Clone()
                .Rows.Insert(row1 + 1)
                For i As Integer = 0 To .Rows(row1).Cells.Count - 1
                    .Rows(row1 + 1).Cells(i).Value = .Rows(row1).Cells(i).Value
                Next
                RowCount1 = .RowCount
                If RowCount1 > 0 Then
                    For i As Integer = 0 To RowCount1 - 1
                        .Rows(i).HeaderCell.Value = Format(i + 1)
                    Next
                End If
            End If
        End With
    End Sub


    'Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    '    '09．DataGridView に表示中のデータを CSV 形式で保存
    '    CsvFileSave("saveTest1.csv")
    'End Sub

    Private Sub CsvFileSave(ByVal SaveFileName As String)
        'DataGridView に表示中のデータを CSV 形式で保存用のプロシージャ
        'VB のソースコードのようなデータも保存できるように設定してあり、普通のCSVファイルも保存できます。
        Dim dbFileName As String = SaveFileName
        '現在のファイルに上書き保存
        Using swCsv As New System.IO.StreamWriter(dbFileName, False, System.Text.Encoding.GetEncoding("SHIFT_JIS"))
            Dim sf As String = Chr(34)          'データの前側の括り
            Dim se As String = Chr(34) & ","    'データの後ろの括りとデータの区切りの ","　
            Dim i, j As Integer
            Dim WorkText As String = ""         '1個分のデータ保持用
            Dim LineText As String = ""         '1列分のデータ保持用

            With DataGridView1
                'ヘッダー部分の取得・保存(保存する必要がなければいらない）
                For i = 0 To .Columns.Count - 1
                    WorkText = .Columns.Item(i).HeaderText
                    If WorkText.IndexOf(Chr(34)) > -1 Then                  'データ内に " があるか検索
                        WorkText = WorkText.Replace("""", """""")           'あれば " を "" に置換える
                    End If
                    If i = .Columns.Count - 1 Then                          'ヘッダー行を列分連結
                        LineText &= sf & .Columns.Item(i).HeaderText & sf   '最後の列の場合
                    Else
                        LineText &= sf & .Columns.Item(i).HeaderText & se
                    End If
                Next i
                swCsv.WriteLine(LineText)                               'ヘッダーの部分の書き込み
                '最下部の新しい行（追加オプション）を非表示にする
                DataGridView1.AllowUserToAddRows = False
                '実データ部分の取得・保存処理
                For i = 0 To .RowCount - 1
                    LineText = ""                                       '１行分のデータをクリア
                    For j = 0 To .Columns.Count - 1                     '１行分のデータを取得処理
                        WorkText = .Item(j, i).Value.ToString           '１個セルデータを取得
                        If WorkText.IndexOf(Chr(34)) > -1 Then          'データ内に " があるか検索
                            WorkText = WorkText.Replace("""", """""")   'あれば " を "" に置換える
                        End If
                        If j = .Columns.Count - 1 Then                  '１行分の列データを連結
                            LineText &= sf & WorkText & sf              '最後の列の場合
                        Else
                            LineText &= sf & WorkText & se
                        End If
                    Next j
                    swCsv.WriteLine(LineText)                           '1行分のデータを書き込み
                Next i
            End With
        End Using
        MessageBox.Show("現在表示中のデータを " & dbFileName & " で保存しました。")
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '04．CSV ファイルを StreamReader を使って DataGridView に読み込み表示
        DGVClear(DataGridView1)                                     '初期化のSub プロシージャを Call

        'Dim sTime0 As DateTime = Now　　                           '読み込み表示の計測時間の開始

        Dim DS As New DataSet
        Dim TB As DataTable = DS.Tables.Add                         'データセットにテーブルを追加する
        Dim dbFileName As String = "..\..\..\data\dgvtest1.csv"     '表示するCSVファイルを指定
        Dim n As Integer

        'CSVファイルをSHIFT_JISのコードページのエンコーディングで読込み
        Using sr1 As New System.IO.StreamReader(dbFileName, System.Text.Encoding.GetEncoding("SHIFT_JIS"))
            ' Dim sr1 As New System.IO.StreamReader(filePath, System.Text.Encoding.Default)
            '項目行を別途設定する場合
            'TB.Columns.Add("No", Type.GetType("System.Int16"))
            'TB.Columns.Add("氏名", Type.GetType("System.String"))
            'TB.Columns.Add("国語", Type.GetType("System.String"))
            'TB.Columns.Add("数学", Type.GetType("System.String"))
            'TB.Columns.Add("英語", Type.GetType("System.String"))
            'TB.Columns.Add("合計点", Type.GetType("System.String"))

            'ファイルの最後までループ
            Do Until sr1.Peek = -1
                n = n + 1
                If n = 1 Then
                    '先頭行を項目として表示する場合
                    Dim cmDat() As String = Split(sr1.ReadLine, ",")
                    ' TB.Columns.Add("No", Type.GetType("System.Int16"))
                    'テーブルにフィールドを追加する
                    For i As Integer = 0 To UBound(cmDat)
                        ' "" で囲まれているデータは、"" を取り除く
                        cmDat(i) = cmDat(i).Trim(Chr(34))
                        Select Case i
                            Case 1, 7, 13, 19  '文字列
                                TB.Columns.Add(cmDat(i), Type.GetType("System.String"))
                            Case Else      '整数型
                                TB.Columns.Add(cmDat(i), Type.GetType("System.Int16"))
                        End Select
                    Next
                Else
                    '２行目以降のデータの設定
                    Dim cmDat() As String = Split(sr1.ReadLine, ",")
                    ' "" で囲まれているデータは、"" を取り除く
                    For i = LBound(cmDat) To UBound(cmDat)
                        cmDat(i) = cmDat(i).Trim(Chr(34))
                    Next
                    TB.Rows.Add(cmDat)
                End If
            Loop
        End Using

        'データグリッドにテーブルを表示する
        DataGridView1.DataSource = TB
        'Dim eTime0 As DateTime = Now　　 '計測終了
        'MessageBox.Show(eTime0.Subtract(sTime0).TotalSeconds & " 秒かかりました。")
    End Sub

    Private Sub DGVClear(ByVal dgv As DataGridView)
        'DataGridView を初期値に設定するプロシージャ
        With dgv
            '列数が>0なら表示されていると判断し、一旦消去(表示速度には影響なし)
            If .Rows.Count > 0 Then
                .Columns.Clear()                            'コレクションを空にします(行・列削除)
                .DataSource = Nothing                       'DataSource に既定値を設定
                .DefaultCellStyle = Nothing                 'セルスタイルを初期値に設定
                .RowHeadersDefaultCellStyle = Nothing       '行ヘッダーを初期値に設定
                .RowHeadersVisible = True                   '行ヘッダーを表示
                'フォントの高さ＋9 (フォントサイズ 9 の場合、12+9= 21 となる
                .RowTemplate.Height = 21                    'デフォルトの行の高さを設定(表示後では有効にならない)
                .ColumnHeadersDefaultCellStyle = Nothing    '列ヘッダーを初期値に設定
                .ColumnHeadersVisible = True                '列ヘッダーを表示
                .ColumnHeadersHeight = 23                   '列ヘッダーの高さを既定値に設定
                .TopLeftHeaderCell = Nothing                '左端上端のヘッダーを初期値に設定
                '奇数行に適用される既定のセルスタイルを初期値に設定　
                .AlternatingRowsDefaultCellStyle = Nothing
                'セルの境界線スタイルを初期値(一重線の境界線)に設定
                .AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
                .GridColor = SystemColors.ControlDark       'セルを区切るグリッド線の色を初期値に設定
                .Refresh()                                  '再描画
            End If
        End With
        '※ 上記設定は、必要により、追加・削除してください。
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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

