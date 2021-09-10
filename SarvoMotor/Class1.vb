Class OnOffLabel
    Inherits Label
    Private OnOff As Boolean
    Private kind1 As Integer
    Sub New()
        MyBase.New()
        MyBase.Size = New Size(32, 18)
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
