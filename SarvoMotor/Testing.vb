Public Class Testing
    Private Sub Testing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Chart As New LoadScedule
        Chart.Location = New Point(20, 20)
        'Chart.Size = New Size(1057, 342)
        Me.Controls.Add(Chart)
    End Sub
End Class