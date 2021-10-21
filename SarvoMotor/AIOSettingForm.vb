Public Class AIOSettingForm
    Private Sub AIOSettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If AIOChNo = 0 Then AIOChNo = AIOMaxCh

        For i As Integer = 0 To AIOMaxCh - 1
            If AIOCheck(i) = Nothing Then AIOCheck(i) = True
            If AIOCoef(i) = 0.0 Then AIOCoef(i) = 1.0
            If AIOPoint(i) = 0 Then AIOPoint(i) = 3
            If AIOUnit(i) = "" Then AIOUnit(i) = "V"
        Next

        With DataGridView1
            .AllowUserToAddRows = False

            '列数・行数を指定
            '.ColumnCount = 8
            '.RowCount = 1
            Const CellW As Integer = 100

            .Width = CellW * 4 + 55
            .Height = 250

            .RowHeadersWidth = CellW

            '列名を指定
            Dim Col0 As New DataGridViewCheckBoxColumn
            With Col0
                .Name = "select"
                .HeaderText = "有効"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 50
            End With
            .Columns.Add(Col0)


            Dim Col1 As New DataGridViewTextBoxColumn()
            With Col1
                .Name = "coef"
                .HeaderText = "係数(/V)"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col1)

            Dim Col2 As New DataGridViewTextBoxColumn()
            With Col2
                .Name = "point"
                .HeaderText = "小数点桁数"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col2)

            Dim Col3 As New DataGridViewTextBoxColumn()
            With Col3
                .Name = "coef"
                .HeaderText = "単位"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = CellW
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns.Add(Col3)

            For i As Integer = 0 To AIOChNo - 1
                .Rows.Add()
                .CurrentCell = .Rows(i).Cells(0)
                .CurrentRow.Cells(0).Value = AIOCheck(i)
                .CurrentRow.Cells(1).Value = Format(AIOCoef(i), "F3")
                .CurrentRow.Cells(2).Value = Format(AIOPoint(i), "F0")
                .CurrentRow.Cells(3).Value = AIOUnit(i)
            Next

            Dim RowCount1 As Integer = .RowCount
            If RowCount1 > 0 Then
                For i As Integer = 0 To RowCount1 - 1
                    .Rows(i).HeaderCell.Value = "ch" + Format(i)
                Next
            End If

            RowsIndex1 = 0
            .CurrentCell = .Rows(RowsIndex1).Cells(0)
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With DataGridView1
            Dim RowCount1 As Integer = .RowCount
            If RowCount1 > 0 Then
                For i As Integer = 0 To RowCount1 - 1
                    AIOCheck(i) = .Rows(i).Cells(0).Value
                    AIOCoef(i) = Val(.Rows(i).Cells(1).Value)
                    AIOPoint(i) = Val(.Rows(i).Cells(2).Value)
                    AIOUnit(i) = .Rows(i).Cells(3).Value
                Next
            End If
        End With
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class