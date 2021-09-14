Public Class MotorCtl

    Dim Speed = {1.0, 2.0, 5.0, 10.0}
    Dim SpeedKind As Integer
    Dim rbutton() As RadioButton
    Dim rb1 As RadioButton
    Dim Speed1 As Double
    Dim SpeedPanel1 As SpeedPanel
    Private Sub MotorCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SpeedPanel1 = New SpeedPanel
        SpeedPanel1.Speed = Speed
        SpeedPanel1.Location = New Point(60, 30)
        Me.TabPage1.Controls.Add(SpeedPanel1)
        'Call SpeedPanel(GroupBox1, Speed)

        'If PistonSpeed = 0 Then
        '    PistonSpeed = 1.0
        '    PlusSpeed = Int(PistonSpeed * CC)
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = Format(SpeedPanel1.SetSpeed, "F1")
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

