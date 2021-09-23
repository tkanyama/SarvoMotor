Class LED
    '============================================================================================
    '
    '   LEDを表示するクラス kind=1 （赤） ,kind=2（緑）,kind=3（青）
    '
    '============================================================================================
    Inherits Label
    Private OnOff As Boolean
    Private kind1 As Integer
    Sub New()
        MyBase.New()
        MyBase.Size = New Size(48, 20)
        MyBase.TextAlign = 2
        kind1 = 1
        'Call LabelOff()
    End Sub
    Private Sub LabelOn()
        MyBase.Text = "ON"
        OnOff = True
        Select Case kind1
            Case 1
                MyBase.BackColor = Color.Red
                MyBase.ForeColor = Color.White
            Case 2
                MyBase.BackColor = Color.LawnGreen
                MyBase.ForeColor = Color.White
            Case 3
                MyBase.BackColor = Color.Cyan
                MyBase.ForeColor = Color.White
        End Select

    End Sub
    Private Sub LabelOff()
        MyBase.Text = "OFF"
        OnOff = False
        Select Case kind1
            Case 1
                MyBase.BackColor = Color.Maroon
                MyBase.ForeColor = Color.Black
            Case 2
                MyBase.BackColor = Color.DarkGreen
                MyBase.ForeColor = Color.Black
            Case 3
                MyBase.BackColor = Color.Navy
                MyBase.ForeColor = Color.Black
        End Select
    End Sub

    Public Property Value() As Boolean
        Get
            Return OnOff
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Me.LabelOn()
            Else
                Me.LabelOff()
            End If
        End Set
    End Property

    Public Property kind() As Integer
        Get
            Return kind1
        End Get
        Set(value As Integer)
            kind1 = value
        End Set
    End Property


End Class


Public Class SpeedPanel
    Inherits GroupBox

    Private _Speed() As Double
    Private _SetSpeed As Double
    Private Speed_N As Integer
    Private rbutton As RadioButton()
    Private Tbox1 As TextBox
    Private _OtherSpeed As Double
    Sub New()
        MyBase.New
        MyBase.Text = "ピストン速度"
        If _OtherSpeed = 0 Then
            _OtherSpeed = 0.1
        End If
    End Sub

    Public Property Speed() As Double()
        Get
            Return _Speed
        End Get
        Set(value As Double())
            _Speed = value
            Speed_N = _Speed.Length
            MyBase.Size = New Size(118, 60 + 25 * (Speed_N + 1))
            ReDim rbutton(Speed_N)

            If _SetSpeed = 0 Then
                _SetSpeed = _Speed(0)
            End If
            For i As Integer = 0 To Speed_N - 1
                rbutton(i) = New RadioButton
                With rbutton(i)
                    .Location = New Point(12, 26 + 25 * i)
                    .Text = Format(_Speed(i), "F1") + "mm/s"
                    If _SetSpeed = _Speed(i) Then
                        .Checked = True
                    Else
                        .Checked = False
                    End If
                End With
                AddHandler rbutton(i).Click, AddressOf rb1_CheckedChanged
                Me.Controls.Add(rbutton(i))
            Next

            rbutton(Speed_N) = New RadioButton
            With rbutton(Speed_N)
                .Location = New Point(12, 26 + 25 * Speed_N)
                .Text = "その他"
                If _SetSpeed = _OtherSpeed Then
                    .Checked = True
                Else
                    .Checked = False
                End If
            End With
            AddHandler rbutton(Speed_N).Click, AddressOf rb1_CheckedChanged
            Me.Controls.Add(rbutton(Speed_N))

            Tbox1 = New TextBox
            With Tbox1
                .Location = New Point(25, 26 + 25 * (Speed_N + 1))
                .Size = New Size(60, 23)
                .Text = Format(_OtherSpeed, "F1")
                .TextAlign = HorizontalAlignment.Center
            End With
            AddHandler Tbox1.TextChanged, AddressOf TBox1Changed
            Me.Controls.Add(Tbox1)
        End Set
    End Property

    Public Property OtherSpeed() As Double
        Get
            Return _OtherSpeed
        End Get
        Set(value As Double)
            _OtherSpeed = value
        End Set
    End Property

    Public ReadOnly Property SetSpeed() As Double
        Get
            Return _SetSpeed
        End Get
    End Property
    Private Sub rb1_CheckedChanged(sender As Object, e As EventArgs)
        Console.WriteLine("Button1がクリックされました")
        Dim flag As Boolean = False
        For i As Integer = 0 To Speed_N - 1
            If rbutton(i).Checked = True Then
                _SetSpeed = _Speed(i)
                flag = True
                Exit For
            End If
        Next
        If flag = False Then
            _SetSpeed = _OtherSpeed
        End If
    End Sub

    Private Sub TBox1Changed(sender As Object, e As EventArgs)
        Console.WriteLine("数値が変更されました")
        If IsNumeric(Tbox1.Text) Then
            _OtherSpeed = Val(Tbox1.Text)
            If _OtherSpeed > 0.0 Then
                For i As Integer = 0 To Speed_N - 1
                    rbutton(i).Checked = False
                Next
                rbutton(Speed_N).Checked = True
                _SetSpeed = _OtherSpeed
            End If
        End If
    End Sub
End Class



Class LoadScedule
    Inherits GroupBox
    Public DataGridView1 As DataGridView
    Dim AddButton As Button
    Dim DelButton As Button
    Dim InsButton As Button
    Dim DupButton As Button
    Dim SaveButton As Button
    Dim LoadButton As Button
    Public RowCount1 As Integer
    Dim BSize As Size
    Dim BXStart As Integer
    Dim BYStart As Integer
    Dim BPitch As Integer
    Public Sub New()

        MyBase.New()

        DataGridView1 = New DataGridView

        With DataGridView1
            .Location = New Point(100, 50)
            .Size = New Size(740, 270)
        End With
        Me.Controls.Add(DataGridView1)

        MyBase.Width = DataGridView1.Width + DataGridView1.Location.X + 20
        Me.Text = "加力スケジュール"
        With DataGridView1
            .AllowUserToAddRows = False

            '列数・行数を指定
            '.ColumnCount = 8
            '.RowCount = 1
            Const CellW As Integer = 80

            .Width = CellW * 5 + 95
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

            'Dim Col3 As New DataGridViewTextBoxColumn()
            'With Col3
            '    .Name = "start"
            '    .HeaderText = "　開始値"
            '    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    .Width = CellW
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'End With
            '.Columns.Add(Col3)

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

            'Dim Col6 As New DataGridViewTextBoxColumn()
            'With Col6
            '    .Name = "end"
            '    .HeaderText = "終了値"
            '    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    .Width = CellW
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'End With
            '.Columns.Add(Col6)

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

        End With

        'Me.AutoSize = False
        MyBase.Width = DataGridView1.Width + DataGridView1.Location.X + 20
        MyBase.Height = DataGridView1.Height + DataGridView1.Location.Y + 20
        'MyBase.Size = New Size(800, 200)

        BSize = New Size(74, 27)
        BXStart = 15
        BYStart = 60
        BPitch = 40

        AddButton = New Button
        With AddButton
            .Location = New Point(BXStart, BYStart)
            .Size = BSize
            .Text = "行追加"
            .TextAlign = HorizontalAlignment.Center
        End With
        AddHandler AddButton.Click, AddressOf AddButton_Click
        Me.Controls.Add(AddButton)

        BYStart += BPitch
        DelButton = New Button
        With DelButton
            .Location = New Point(BXStart, BYStart)
            .Size = BSize
            .Text = "行削除"
            .TextAlign = HorizontalAlignment.Center
        End With
        AddHandler DelButton.Click, AddressOf DelButton_Click
        Me.Controls.Add(DelButton)

        BYStart += BPitch
        InsButton = New Button
        With InsButton
            .Location = New Point(BXStart, BYStart)
            .Size = BSize
            .Text = "行挿入"
            .TextAlign = HorizontalAlignment.Center
        End With
        AddHandler InsButton.Click, AddressOf InsButton_Click
        Me.Controls.Add(InsButton)

        BYStart += BPitch
        DupButton = New Button
        With DupButton
            .Location = New Point(BXStart, BYStart)
            .Size = BSize
            .Text = "行複製"
            .TextAlign = HorizontalAlignment.Center
        End With
        AddHandler DupButton.Click, AddressOf DupButton_Click
        Me.Controls.Add(DupButton)

        BYStart += BPitch
        SaveButton = New Button
        With SaveButton
            .Location = New Point(BXStart, BYStart)
            .Size = BSize
            .Text = "データ保存"
            .TextAlign = HorizontalAlignment.Center
        End With
        AddHandler SaveButton.Click, AddressOf SaveButton_Click
        Me.Controls.Add(SaveButton)

        BYStart += BPitch
        LoadButton = New Button
        With LoadButton
            .Location = New Point(BXStart, BYStart)
            .Size = BSize
            .Text = "データ読込"
            .TextAlign = HorizontalAlignment.Center
        End With
        AddHandler LoadButton.Click, AddressOf LoadButton_Click
        Me.Controls.Add(LoadButton)




    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs)
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

    Private Sub DelButton_Click(sender As Object, e As EventArgs)
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

    Private Sub InsButton_Click(sender As Object, e As EventArgs)
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

    Private Sub DupButton_Click(sender As Object, e As EventArgs)
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

    Private Sub SaveButton_Click(sender As Object, e As EventArgs)

        Dim DirName As String = "C:\加力スケジュール"
        If System.IO.File.Exists(DirName) = False Then
            System.IO.Directory.CreateDirectory(DirName)
        End If
        'SaveFileDialogクラスのインスタンスを作成
        Dim sfd As New SaveFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        sfd.FileName = "data1.csv"
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        sfd.InitialDirectory = DirName
        '[ファイルの種類]に表示される選択肢を指定する
        sfd.Filter = "csvファイル(*.csv)|*.csv"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        sfd.FilterIndex = 0
        'タイトルを設定する
        sfd.Title = "保存先のファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        sfd.RestoreDirectory = True
        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            CsvFileSave(sfd.FileName)
        End If

    End Sub


    Private Sub LoadButton_Click(sender As Object, e As EventArgs)
        Dim DirName As String = "C:\加力スケジュール"

        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = "data1.csv"
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        ofd.InitialDirectory = DirName
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "csvファイル(*.csv)|*.csv"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        ofd.FilterIndex = 0
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckFileExists = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckPathExists = True

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            CsvFileLoad(ofd.FileName)
        End If

    End Sub

    Private Sub CsvFileSave(ByVal SaveFileName As String)
        'DataGridView に表示中のデータを CSV 形式で保存用のプロシージャ
        'VB のソースコードのようなデータも保存できるように設定してあり、普通のCSVファイルも保存できます。
        Dim dbFileName As String = SaveFileName

        '現在のファイルに上書き保存
        Using swCsv As New System.IO.StreamWriter(dbFileName, False, System.Text.Encoding.GetEncoding("UTF-8"))
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


    Private Sub CsvFileLoad(ByVal LoadFileName As String)
        '初期化のSub プロシージャを Call
        With DataGridView1
            If .RowCount > 0 Then
                For i As Integer = 0 To .RowCount - 1
                    .Rows.RemoveAt(0)
                Next
            End If


            'Dim sTime0 As DateTime = Now　　                           '読み込み表示の計測時間の開始

            'Dim DS As New DataSet
            'Dim TB As DataTable = DS.Tables.Add                         'データセットにテーブルを追加する
            'Dim dbFileName As String = "..\..\..\data\dgvtest1.csv"     '表示するCSVファイルを指定
            Dim n As Integer

            'CSVファイルをSHIFT_JISのコードページのエンコーディングで読込み
            Using sr1 As New System.IO.StreamReader(LoadFileName, System.Text.Encoding.GetEncoding("UTF-8"))
                ' Dim sr1 As New System.IO.StreamReader(filePath, System.Text.Encoding.Default)


                'ファイルの最後までループ
                'Dim row1 As DataGridViewRow
                Do Until sr1.Peek = -1
                    n = n + 1
                    If n = 1 Then
                        '先頭行を項目として表示する場合
                        Dim cmDat() As String = Split(sr1.ReadLine, ",")

                    Else
                        '２行目以降のデータの設定
                        .Rows.Add()
                        .CurrentCell = .Rows(n - 2).Cells(0)

                        Dim cmDat() As String = Split(sr1.ReadLine, ",")
                        ' "" で囲まれているデータは、"" を取り除く
                        For i = LBound(cmDat) To UBound(cmDat)
                            cmDat(i) = cmDat(i).Trim(Chr(34))
                            Select Case i
                                Case 0          'ブール型
                                    If cmDat(i) = "TRUE" Then
                                        .CurrentRow.Cells(i).Value = True
                                    Else
                                        .CurrentRow.Cells(i).Value = False
                                    End If

                                Case Else       '文字列
                                    'TB.Rows.Add(cmDat(i), Type.GetType("System.String"))
                                    .CurrentRow.Cells(i).Value = cmDat(i)
                            End Select

                        Next
                        'TB.Rows.Add(cmDat)
                    End If
                Loop
            End Using


            RowCount1 = .RowCount
            .CurrentCell = .Rows(0).Cells(0)

            LoadGraph1.DrawGraph()

        End With
    End Sub

    Public Property RowIndex() As Integer
        Get
            Return DataGridView1.CurrentRow.Index
        End Get
        Set(value As Integer)
            DataGridView1.CurrentCell = DataGridView1.Rows(value).Cells(0)
        End Set
    End Property

    Public ReadOnly Property Valid() As Boolean
        Get
            Return DataGridView1.CurrentRow.Cells(0).Value
        End Get
    End Property

    Public ReadOnly Property SControl() As String
        Get
            Return DataGridView1.CurrentRow.Cells(1).Value
        End Get
    End Property

    'Public ReadOnly Property StartPoint() As Double
    '    Get
    '        Return Val(DataGridView1.CurrentRow.Cells(2).Value)
    '    End Get
    'End Property

    Public ReadOnly Property PeakP() As Double
        Get
            Return Val(DataGridView1.CurrentRow.Cells(2).Value)
        End Get
    End Property

    Public ReadOnly Property PeakM() As Double
        Get
            Return Val(DataGridView1.CurrentRow.Cells(3).Value)
        End Get
    End Property

    'Public ReadOnly Property EndPoint() As Double
    '    Get
    '        Return Val(DataGridView1.CurrentRow.Cells(5).Value)
    '    End Get
    'End Property

    Public ReadOnly Property Delta() As Double
        Get
            Return Val(DataGridView1.CurrentRow.Cells(4).Value)
        End Get
    End Property

    Public ReadOnly Property RepeatN() As Double
        Get
            Return Val(DataGridView1.CurrentRow.Cells(5).Value)
        End Get
    End Property

    Public ReadOnly Property RowCount() As Double
        Get
            Return DataGridView1.RowCount
        End Get
    End Property

End Class