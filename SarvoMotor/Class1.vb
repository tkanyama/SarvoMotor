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
                .Location = New Point(12, 26 + 25 * (Speed_N + 1))
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