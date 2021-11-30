Public Class SpeedSetForm

    Dim RowCount1 As Integer
    Dim DataGridView1 As DataGridView
    Dim Speed = {0.0, 0.0, 0.0, 0.0, 0.0}
    Dim OtherSpeed As Double
    'Dim basePath As String
    'Dim filePath As String
    'Dim FileName As String
    Private Sub SpeedSetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1 = New DataGridView

        With DataGridView1
            .Location = New Point(25, 25)
            .Size = New Size(500, 95)
        End With
        Me.Controls.Add(DataGridView1)

        MyBase.Width = DataGridView1.Width + DataGridView1.Location.X + 20
        Me.Text = "ピストン速度設定"
        With DataGridView1
            .AllowUserToAddRows = False

            '列数・行数を指定
            '.ColumnCount = 8
            '.RowCount = 1
            Const CellW As Integer = 62

            .Width = CellW * 6 + 50
            .Height = 60

            DataGridView1.ColumnHeadersHeight = 25

            '列名を指定

            Dim Col1 As New DataGridViewTextBoxColumn
            With Col1
                .Name = "Speed1"
                .HeaderText = "Speed1"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
            End With
            .Columns.Add(Col1)

            Dim Col2 As New DataGridViewTextBoxColumn
            With Col2
                .Name = "Speed21"
                .HeaderText = "Speed2"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
            End With
            .Columns.Add(Col2)

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .Name = "Speed3"
                .HeaderText = "Speed3"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
            End With
            .Columns.Add(Col3)

            Dim Col4 As New DataGridViewTextBoxColumn
            With Col4
                .Name = "Speed4"
                .HeaderText = "Speed4"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
            End With
            .Columns.Add(Col4)

            Dim Col5 As New DataGridViewTextBoxColumn
            With Col5
                .Name = "Speed5"
                .HeaderText = "Speed5"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
            End With
            .Columns.Add(Col5)

            Dim Col6 As New DataGridViewTextBoxColumn
            With Col6
                .Name = "Speed6"
                .HeaderText = "その他"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
            End With
            .Columns.Add(Col6)

        End With

        'Me.AutoSize = False
        MyBase.Width = DataGridView1.Width + DataGridView1.Location.X + 50
        MyBase.Height = DataGridView1.Height + DataGridView1.Location.Y + 100
        'MyBase.Size = New Size(800, 200)

        Dim OkButton = New Button
        With OkButton
            .Location = New Point(100, 100)
            .Size = New Size(100, 30)
            .Text = "OK"
            .TextAlign = HorizontalAlignment.Center
        End With
        AddHandler OkButton.Click, AddressOf OKButton_Click
        Me.Controls.Add(OkButton)

        Dim CancelButton = New Button
        With CancelButton
            .Location = New Point(300, 100)
            .Size = New Size(100, 30)
            .Text = "Cancel"
            .TextAlign = HorizontalAlignment.Center
        End With
        AddHandler CancelButton.Click, AddressOf CancelButton_Click
        Me.Controls.Add(CancelButton)


        basePath = "C:\PistonSpeed"
        filePath = "speed.csv"

        '2つのパスを結合する
        SpeedFileName = System.IO.Path.Combine(basePath, filePath)
        'Dim FileName As String = "C:¥PistonSpeed¥speed.csv"
        'If System.IO.File.Exists(FileName) = False Then
        CsvFileLoad(SpeedFileName)
        'End If


    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs)
        With DataGridView1
            For i As Integer = 0 To 4

                Speed(i) = Val(.Rows(0).Cells(i).Value)

            Next
            OtherSpeed = Val(.Rows(0).Cells(5).Value)
        End With
        CsvFileSave(SpeedFileName)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs)
        If Not TestStartFlag Then
            Dim DirName As String = "C:\加力スケジュール"
            If System.IO.Directory.Exists(DirName) = False Then
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
        Else
            MessageBox.Show("試験中は操作できません！",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub LoadButton_Click(sender As Object, e As EventArgs)
        If Not TestStartFlag Then
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

        Else
            MessageBox.Show("試験中は操作できません！",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
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
        'MessageBox.Show("現在表示中のデータを " & dbFileName & " で保存しました。")
    End Sub


    Private Sub CsvFileLoad(ByVal LoadFileName As String)
        '初期化のSub プロシージャを Call
        With DataGridView1
            If .RowCount > 0 Then
                For i As Integer = 0 To .RowCount - 1
                    .Rows.RemoveAt(0)
                Next
            End If
            'Dim LoadFileName As String = "C:\ピストンスピード¥speed.csv"

            'Dim sTime0 As DateTime = Now　　                           '読み込み表示の計測時間の開始

            'Dim DS As New DataSet
            'Dim TB As DataTable = DS.Tables.Add                         'データセットにテーブルを追加する
            'Dim dbFileName As String = "..\..\..\data\dgvtest1.csv"     '表示するCSVファイルを指定
            Dim n As Integer

            'CSVファイルをSHIFT_JISのコードページのエンコーディングで読込み
            Using sr1 As New System.IO.StreamReader(LoadFileName, System.Text.Encoding.Default)
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
                            .CurrentRow.Cells(i).Value = cmDat(i)
                            'Select Case i
                            '    Case 0          'ブール型
                            '        If cmDat(i) = "TRUE" Or cmDat(i) = "True" Then
                            '            .CurrentRow.Cells(i).Value = True
                            '        Else
                            '            .CurrentRow.Cells(i).Value = False
                            '        End If

                            '    Case Else       '文字列
                            '        'TB.Rows.Add(cmDat(i), Type.GetType("System.String"))
                            '        .CurrentRow.Cells(i).Value = cmDat(i)
                            'End Select

                        Next
                        'TB.Rows.Add(cmDat)
                    End If
                Loop
            End Using

            RowCount1 = .RowCount
            If RowCount1 > 0 Then
                For i As Integer = 0 To RowCount1 - 1
                    .Rows(i).HeaderCell.Value = Format(i + 1)
                Next
            End If

            RowsIndex1 = 0
            .CurrentCell = .Rows(RowsIndex1).Cells(0)



        End With
    End Sub

End Class