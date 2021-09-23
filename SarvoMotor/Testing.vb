Imports System.Drawing
Imports System.Math



Public Class Testing

    'Dim Chart As LoadScedule
    Dim Valid As Boolean
    Dim SControl As String
    'Dim StartPoint As Double
    Dim PeakP As Double
    Dim PeakM As Double
    'Dim EndPoint As Double
    Dim Delta As Double
    Dim RepeatN As Integer
    Dim RowIndex1 As Integer

    Dim GXsize As Double
    Dim GYsize As Double

    Dim GXZero As Double
    Dim GXmax As Double
    Dim GYZero As Double
    Dim GYmax As Double

    Dim Xmax As Double
    Dim Ymax As Double
    Dim Xc As Double
    Dim Yc As Double
    Dim XOffSet As Double
    Dim YOffSet As Double


    Private Sub Testing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart = New LoadScedule
        Chart.Location = New Point(20, 300)
        'Chart.Size = New Size(1057, 342)
        Me.Controls.Add(Chart)

        Dim LoadGraph1 As New LoadGraph
        LoadGraph1.Location = New Point(30, 12)
        Me.Controls.Add(LoadGraph1)

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)

    '    RowIndex1 = 0
    '    With Chart
    '        If .RowCount > 0 Then
    '            '.RowIndex = RowIndex1
    '            Valid = .Valid
    '            SControl = .SControl
    '            'StartPoint = .StartPoint
    '            PeakP = .PeakP
    '            PeakM = .PeakM
    '            'EndPoint = .EndPoint
    '            Delta = .Delta
    '            RepeatN = .RepeatN

    '            Dim Kataburi As Boolean
    '            If PeakM = 0 Then
    '                Kataburi = True
    '                PointN = 3 + 2 * (RepeatN - 1)
    '            Else
    '                Kataburi = False
    '                PointN = 5 + 4 * (RepeatN - 1)
    '            End If
    '            Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
    '            'ImageオブジェクトのGraphicsオブジェクトを作成する
    '            Dim g As Graphics = Graphics.FromImage(canvas)
    '            'g.ScaleTransform(2.0, -1.0)
    '            'g.RenderingOrigin.Offset(0, 300)
    '            '(10, 20)-(100, 200)に、幅1の黒い線を引く

    '            GXsize = PictureBox1.Width
    '            GYsize = PictureBox1.Height

    '            GXZero = GXsize * 0.1
    '            GXmax = GXsize * 0.8

    '            If Kataburi Then
    '                If PeakP > 0 Then
    '                    GYZero = GYsize * 0.9
    '                    GYmax = GYsize * 0.8
    '                Else
    '                    GYZero = GYsize * 0.1
    '                    GYmax = GYsize * 0.8
    '                End If

    '            Else
    '                GYZero = GYsize * 0.5
    '                GYmax = GYsize * 0.4
    '            End If
    '            Xmax = PointN - 1
    '            Ymax = Max(Abs(PeakP), Abs(PeakM))
    '            Xc = GXmax / Xmax
    '            Yc = -GYmax / Ymax
    '            XOffSet = GXZero
    '            YOffSet = GYZero

    '            'Dim X1 As Integer, Y1 As Integer
    '            'Dim X2 As Integer, Y2 As Integer
    '            PictureBox1.Image = Nothing

    '            Dim blackPen1 As New Pen(Color.Black, 1)
    '            Dim AxisX(1) As Point
    '            AxisX(0) = TransPoint(New Point(0, 0))
    '            AxisX(1) = TransPoint(New Point(Xmax, 0))
    '            g.DrawLines(blackPen1, AxisX)

    '            If Kataburi Then
    '                If PeakP > 0 Then
    '                    Dim AxisY(1) As Point
    '                    AxisY(0) = TransPoint(New Point(0, Ymax))
    '                    AxisY(1) = TransPoint(New Point(0, 0))
    '                    g.DrawLines(blackPen1, AxisY)

    '                    Dim GrayPen1 As New Pen(Color.LightGray, 0.5)
    '                    GrayPen1.DashStyle = Drawing2D.DashStyle.Dash
    '                    Dim AxisYmax(1) As Point
    '                    AxisYmax(0) = TransPoint(New Point(0, Ymax))
    '                    AxisYmax(1) = TransPoint(New Point(Xmax, Ymax))
    '                    g.DrawLines(GrayPen1, AxisYmax)
    '                    'Dim AxisYmin(1) As Point
    '                    'AxisYmin(0) = TransPoint(New Point(0, -Ymax))
    '                    'AxisYmin(1) = TransPoint(New Point(Xmax, -Ymax))
    '                    'g.DrawLines(GrayPen1, AxisYmin)

    '                    Dim fnt As New Font("MS UI Gothic", 8)
    '                    Dim fmt As New StringFormat
    '                    fmt.Alignment = StringAlignment.Far
    '                    fmt.LineAlignment = StringAlignment.Center
    '                    '文字列を位置(0,0)、黒色で表示
    '                    g.DrawString(Format(Ymax), fnt, Brushes.Black, TransPoint(New Point(0, Ymax)), fmt)
    '                    g.DrawString(Format(0), fnt, Brushes.Black, TransPoint(New Point(0, 0)), fmt)
    '                    'g.DrawString(Format(-Ymax), fnt, Brushes.Black, TransPoint(New Point(0, -Ymax)), fmt)

    '                    If Delta > 0 Then
    '                        Dim ygrid As Integer = 0
    '                        Dim gridLind(1) As Point
    '                        Do
    '                            ygrid += Delta
    '                            If ygrid >= Ymax Then Exit Do
    '                            gridLind(0) = TransPoint(New Point(0, ygrid))
    '                            gridLind(1) = TransPoint(New Point(Xmax, ygrid))
    '                            g.DrawLines(GrayPen1, gridLind)
    '                            'gridLind(0) = TransPoint(New Point(0, -ygrid))
    '                            'gridLind(1) = TransPoint(New Point(Xmax, -ygrid))
    '                            'g.DrawLines(GrayPen1, gridLind)
    '                        Loop
    '                    End If
    '                Else
    '                    Dim AxisY(1) As Point
    '                    AxisY(0) = TransPoint(New Point(0, -Ymax))
    '                    AxisY(1) = TransPoint(New Point(0, 0))
    '                    g.DrawLines(blackPen1, AxisY)

    '                    Dim GrayPen1 As New Pen(Color.LightGray, 0.5)
    '                    GrayPen1.DashStyle = Drawing2D.DashStyle.Dash
    '                    'Dim AxisYmax(1) As Point
    '                    'AxisYmax(0) = TransPoint(New Point(0, Ymax))
    '                    'AxisYmax(1) = TransPoint(New Point(Xmax, Ymax))
    '                    'g.DrawLines(GrayPen1, AxisYmax)
    '                    Dim AxisYmin(1) As Point
    '                    AxisYmin(0) = TransPoint(New Point(0, -Ymax))
    '                    AxisYmin(1) = TransPoint(New Point(Xmax, -Ymax))
    '                    g.DrawLines(GrayPen1, AxisYmin)

    '                    Dim fnt As New Font("MS UI Gothic", 8)
    '                    Dim fmt As New StringFormat
    '                    fmt.Alignment = StringAlignment.Far
    '                    fmt.LineAlignment = StringAlignment.Center
    '                    '文字列を位置(0,0)、黒色で表示
    '                    'g.DrawString(Format(Ymax), fnt, Brushes.Black, TransPoint(New Point(0, Ymax)), fmt)
    '                    g.DrawString(Format(0), fnt, Brushes.Black, TransPoint(New Point(0, 0)), fmt)
    '                    g.DrawString(Format(-Ymax), fnt, Brushes.Black, TransPoint(New Point(0, -Ymax)), fmt)

    '                    If Delta > 0 Then
    '                        Dim ygrid As Integer = 0
    '                        Dim gridLind(1) As Point
    '                        Do
    '                            ygrid += Delta
    '                            If ygrid >= Ymax Then Exit Do
    '                            'gridLind(0) = TransPoint(New Point(0, ygrid))
    '                            'gridLind(1) = TransPoint(New Point(Xmax, ygrid))
    '                            'g.DrawLines(GrayPen1, gridLind)
    '                            gridLind(0) = TransPoint(New Point(0, -ygrid))
    '                            gridLind(1) = TransPoint(New Point(Xmax, -ygrid))
    '                            g.DrawLines(GrayPen1, gridLind)
    '                        Loop
    '                    End If

    '                End If

    '            Else
    '                Dim AxisY(1) As Point
    '                AxisY(0) = TransPoint(New Point(0, Ymax))
    '                AxisY(1) = TransPoint(New Point(0, -Ymax))
    '                g.DrawLines(blackPen1, AxisY)

    '                Dim GrayPen1 As New Pen(Color.LightGray, 0.5)
    '                GrayPen1.DashStyle = Drawing2D.DashStyle.Dash
    '                Dim AxisYmax(1) As Point
    '                AxisYmax(0) = TransPoint(New Point(0, Ymax))
    '                AxisYmax(1) = TransPoint(New Point(Xmax, Ymax))
    '                g.DrawLines(GrayPen1, AxisYmax)
    '                Dim AxisYmin(1) As Point
    '                AxisYmin(0) = TransPoint(New Point(0, -Ymax))
    '                AxisYmin(1) = TransPoint(New Point(Xmax, -Ymax))
    '                g.DrawLines(GrayPen1, AxisYmin)

    '                Dim fnt As New Font("MS UI Gothic", 8)
    '                Dim fmt As New StringFormat
    '                fmt.Alignment = StringAlignment.Far
    '                fmt.LineAlignment = StringAlignment.Center
    '                '文字列を位置(0,0)、黒色で表示
    '                g.DrawString(Format(Ymax), fnt, Brushes.Black, TransPoint(New Point(0, Ymax)), fmt)
    '                g.DrawString(Format(0), fnt, Brushes.Black, TransPoint(New Point(0, 0)), fmt)
    '                g.DrawString(Format(-Ymax), fnt, Brushes.Black, TransPoint(New Point(0, -Ymax)), fmt)

    '                If Delta > 0 Then
    '                    Dim ygrid As Integer = 0
    '                    Dim gridLind(1) As Point
    '                    Do
    '                        ygrid += Delta
    '                        If ygrid >= Ymax Then Exit Do
    '                        gridLind(0) = TransPoint(New Point(0, ygrid))
    '                        gridLind(1) = TransPoint(New Point(Xmax, ygrid))
    '                        g.DrawLines(GrayPen1, gridLind)
    '                        gridLind(0) = TransPoint(New Point(0, -ygrid))
    '                        gridLind(1) = TransPoint(New Point(Xmax, -ygrid))
    '                        g.DrawLines(GrayPen1, gridLind)
    '                    Loop
    '                End If

    '            End If

    '            'Dim PointN As Integer
    '            Dim P() As Point
    '            'If Kataburi Then
    '            '    PointN = 3 + 2 * (RepeatN - 1)
    '            'Else
    '            '    PointN = 5 + 4 * (RepeatN - 1)
    '            'End If

    '            ReDim LoadPoint(PointN - 1)
    '            ReDim P(PointN - 1)
    '            Dim m As Integer = 0
    '            If Kataburi Then
    '                For i As Integer = 0 To RepeatN - 1
    '                    If i = 0 Then
    '                        LoadPoint(m) = 0
    '                    End If
    '                    m += 1
    '                    LoadPoint(m) = PeakP
    '                    m += 1
    '                    LoadPoint(m) = 0
    '                Next
    '            Else
    '                For i As Integer = 0 To RepeatN - 1
    '                    If i = 0 Then
    '                        LoadPoint(m) = 0
    '                    End If
    '                    m += 1
    '                    LoadPoint(m) = PeakP
    '                    m += 1
    '                    LoadPoint(m) = 0
    '                    m += 1
    '                    LoadPoint(m) = PeakM
    '                    m += 1
    '                    LoadPoint(m) = 0
    '                Next
    '            End If

    '            For i As Integer = 0 To PointN - 1
    '                P(i) = TransPoint(New Point(i, LoadPoint(i)))
    '            Next

    '            'Dim X As Integer = 0
    '            'Dim P1 As Point, P2 As Point, P3 As Point, P4 As Point
    '            'For i As Integer = 0 To RepeatN - 1
    '            '    P1 = New Point(X, 0)
    '            '    X += 1
    '            '    P2 = New Point(X, PeakP)
    '            '    If PeakM = 0 Then
    '            '        X += 1
    '            '    Else
    '            '        X += 2
    '            '    End If
    '            '    P3 = New Point(X, PeakM)
    '            '    X += 1
    '            '    P4 = New Point(X, 0)

    '            '    LoadPoint(0 + i * 4) = TransPoint(P1)
    '            '    LoadPoint(1 + i * 4) = TransPoint(P2)
    '            '    LoadPoint(2 + i * 4) = TransPoint(P3)
    '            '    LoadPoint(3 + i * 4) = TransPoint(P4)
    '            'Next
    '            'g.DrawLine(Pens.Black, TransPoint(P1), TransPoint(P2))
    '            Dim blackPen3 As New Pen(Color.Black, 2)
    '            g.DrawLines(blackPen3, P)

    '            'X1 = Int(0 * Xc + XOffSet)
    '            'Y1 = Int(0 * Yc + YOffSet)
    '            'X2 = Int(1 * Xc + XOffSet)
    '            'Y2 = Int(Ymax * Yc + YOffSet)
    '            'g.DrawLine(Pens.Black, X1, Y1, X2, Y2)

    '            'g.DrawLine(Pens.Black, 10, 20, 100, 200)

    '            'リソースを解放する
    '            g.Dispose()
    '            'PictureBox1に表示する
    '            PictureBox1.Image = canvas

    '        End If
    '    End With

    'End Sub

    'Private Function TransPoint(ByVal P1 As Point) As Point
    '    Dim P2 As Point
    '    P2.X = Int(P1.X * Xc + XOffSet)
    '    P2.Y = Int(P1.Y * Yc + YOffSet)
    '    Return P2
    'End Function
End Class