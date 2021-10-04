Public Class SpeedInputForm
    Private Sub SpeedInputForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Format(SpeedPanel1.OtherSpeed, "F3")
        'Me.StartPosition = FormStartPosition.CenterScreen
        TextBox1.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(TextBox1.Text) Then
            SpeedPanel1.OtherSpeed = Val(TextBox1.Text)
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TexBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー

            If IsNumeric(TextBox1.Text) Then
                SpeedPanel1.OtherSpeed = Val(TextBox1.Text)
            End If
            Me.Close()

            e.KeyChar = "" 'キーをクリアする(必要であれば)
        End If
    End Sub
    'Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    '    If IsNumeric(TextBox1.Text) Then
    '        SpeedPanel1.OtherSpeed = Val(TextBox1.Text)
    '    End If
    '    Me.Close()
    'End Sub

    'Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    'End Sub
End Class