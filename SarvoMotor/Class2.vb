Imports System.Drawing
Imports System.Math

Public Class LoadGraph
    Inherits GroupBox

    Dim g As Graphics
    Dim canvas As Bitmap

    Private PictureBox1 As PictureBox
    Private DrawButton As Button

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

    Public Sub New()

        MyBase.New()
        Me.Text = "加力スケジュール"

        PictureBox1 = New PictureBox
        With PictureBox1
            .Location = New Point(10, 51)
            .Size = New Size(280, 270)
            .BorderStyle = BorderStyle.Fixed3D
        End With
        MyBase.Controls.Add(PictureBox1)

        DrawButton = New Button
        With DrawButton
            .Location = New Point(10, 21)
            .Size = New Size(74, 27)
            .Text = "作図"
        End With
        AddHandler DrawButton.Click, AddressOf DrawButton_Click
        MyBase.Controls.Add(DrawButton)

        MyBase.Size = New Size(PictureBox1.Width + 20, PictureBox1.Height + 70)


    End Sub

    Public WriteOnly Property Button_Enabled() As Boolean
        Set(value As Boolean)
            DrawButton.Enabled = value
        End Set
    End Property
    Private Sub DrawButton_Click(sender As Object, e As EventArgs)
        DrawGraph(0)
    End Sub

    Public Sub DrawGraph(ByVal PStep As Integer)
        'RowIndex1 = 0
        With LoadChart1
            If .RowCount > 0 Then
                '.RowIndex = RowIndex1
                Valid = .Valid
                SControl = .SControl
                Select Case SControl
                    Case "変位"
                        SControlNo = 0
                    Case "荷重"
                        SControlNo = 1
                End Select

                'StartPoint = .StartPoint
                PeakP = .PeakP
                PeakM = .PeakM
                'EndPoint = .EndPoint
                Delta = .Delta
                Delta1 = Delta
                RepeatN = .RepeatN

                If Abs(PeakP) > 0.0 Then
                    'Dim Kataburi As Boolean
                    If PeakM = 0 Then
                        Kataburi = True
                        If RepeatN > 0 Then
                            PointN = 3 + 2 * (RepeatN - 1)
                        Else
                            PointN = 2
                        End If
                    Else
                        If RepeatN = 0 Then RepeatN = 1
                        Kataburi = False
                        PointN = 5 + 4 * (RepeatN - 1)
                    End If
                    canvas = New Bitmap(PictureBox1.Width, PictureBox1.Height)
                    'ImageオブジェクトのGraphicsオブジェクトを作成する
                    g = Graphics.FromImage(canvas)


                    GXsize = PictureBox1.Width
                    GYsize = PictureBox1.Height

                    GXZero = GXsize * 0.15
                    GXmax = GXsize * 0.8

                    If Kataburi Then
                        If PeakP > 0 Then
                            GYZero = GYsize * 0.9
                            GYmax = GYsize * 0.8
                        Else
                            GYZero = GYsize * 0.1
                            GYmax = GYsize * 0.8
                        End If

                    Else
                        GYZero = GYsize * 0.5
                        GYmax = GYsize * 0.4
                    End If
                    Xmax = PointN - 1
                    Ymax = Max(Abs(PeakP), Abs(PeakM))
                    Xc = GXmax / Xmax
                    Yc = -GYmax / Ymax
                    XOffSet = GXZero
                    YOffSet = GYZero

                    'Dim X1 As Integer, Y1 As Integer
                    'Dim X2 As Integer, Y2 As Integer
                    PictureBox1.Image = Nothing

                    Dim blackPen1 As New Pen(Color.Black, 1)
                    Dim AxisX(1) As PointF
                    AxisX(0) = TransPoint(New PointF(0, 0))
                    AxisX(1) = TransPoint(New PointF(Xmax, 0))
                    g.DrawLines(blackPen1, AxisX)

                    If Kataburi Then
                        If PeakP > 0 Then
                            Dim AxisY(1) As PointF
                            AxisY(0) = TransPoint(New PointF(0, Ymax))
                            AxisY(1) = TransPoint(New PointF(0, 0))
                            g.DrawLines(blackPen1, AxisY)

                            Dim GrayPen1 As New Pen(Color.LightGray, 0.5)
                            GrayPen1.DashStyle = Drawing2D.DashStyle.Dash
                            Dim AxisYmax(1) As PointF
                            AxisYmax(0) = TransPoint(New PointF(0, Ymax))
                            AxisYmax(1) = TransPoint(New PointF(Xmax, Ymax))
                            g.DrawLines(GrayPen1, AxisYmax)
                            'Dim AxisYmin(1) As Point
                            'AxisYmin(0) = TransPoint(New Point(0, -Ymax))
                            'AxisYmin(1) = TransPoint(New Point(Xmax, -Ymax))
                            'g.DrawLines(GrayPen1, AxisYmin)

                            Dim fnt As New Font("MS UI Gothic", 8)
                            Dim fmt As New StringFormat
                            fmt.Alignment = StringAlignment.Far
                            fmt.LineAlignment = StringAlignment.Center
                            '文字列を位置(0,0)、黒色で表示
                            g.DrawString(Format(Ymax), fnt, Brushes.Black, TransPoint(New PointF(0, Ymax)), fmt)
                            g.DrawString(Format(0), fnt, Brushes.Black, TransPoint(New PointF(0, 0)), fmt)
                            'g.DrawString(Format(-Ymax), fnt, Brushes.Black, TransPoint(New Point(0, -Ymax)), fmt)

                            If Delta > 0 Then
                                Dim ygrid As Integer = 0
                                Dim gridLind(1) As PointF
                                Do
                                    ygrid += Delta
                                    If ygrid >= Ymax Then Exit Do
                                    gridLind(0) = TransPoint(New PointF(0, ygrid))
                                    gridLind(1) = TransPoint(New PointF(Xmax, ygrid))
                                    g.DrawLines(GrayPen1, gridLind)
                                    'gridLind(0) = TransPoint(New PointF(0, -ygrid))
                                    'gridLind(1) = TransPoint(New PointF(Xmax, -ygrid))
                                    'g.DrawLines(GrayPen1, gridLind)
                                Loop
                            End If
                        Else
                            Dim AxisY(1) As PointF
                            AxisY(0) = TransPoint(New PointF(0, -Ymax))
                            AxisY(1) = TransPoint(New PointF(0, 0))
                            g.DrawLines(blackPen1, AxisY)

                            Dim GrayPen1 As New Pen(Color.LightGray, 0.5)
                            GrayPen1.DashStyle = Drawing2D.DashStyle.Dash
                            'Dim AxisYmax(1) As PointF
                            'AxisYmax(0) = TransPoint(New PointF(0, Ymax))
                            'AxisYmax(1) = TransPoint(New PointF(Xmax, Ymax))
                            'g.DrawLines(GrayPen1, AxisYmax)
                            Dim AxisYmin(1) As PointF
                            AxisYmin(0) = TransPoint(New PointF(0, -Ymax))
                            AxisYmin(1) = TransPoint(New PointF(Xmax, -Ymax))
                            g.DrawLines(GrayPen1, AxisYmin)

                            Dim fnt As New Font("MS UI Gothic", 8)
                            Dim fmt As New StringFormat
                            fmt.Alignment = StringAlignment.Far
                            fmt.LineAlignment = StringAlignment.Center
                            '文字列を位置(0,0)、黒色で表示
                            'g.DrawString(Format(Ymax), fnt, Brushes.Black, TransPointF(New Point(0, Ymax)), fmt)
                            g.DrawString(Format(0), fnt, Brushes.Black, TransPoint(New PointF(0, 0)), fmt)
                            g.DrawString(Format(-Ymax), fnt, Brushes.Black, TransPoint(New PointF(0, -Ymax)), fmt)

                            If Delta > 0 Then
                                Dim ygrid As Double = 0
                                Dim gridLind(1) As PointF
                                Do
                                    ygrid += Delta
                                    If ygrid >= Ymax Then Exit Do
                                    'gridLind(0) = TransPoint(New PointF(0, ygrid))
                                    'gridLind(1) = TransPoint(New PointF(Xmax, ygrid))
                                    'g.DrawLines(GrayPen1, gridLind)
                                    gridLind(0) = TransPoint(New PointF(0, -ygrid))
                                    gridLind(1) = TransPoint(New PointF(Xmax, -ygrid))
                                    g.DrawLines(GrayPen1, gridLind)
                                Loop
                            End If

                        End If

                    Else
                        Dim AxisY(1) As PointF
                        AxisY(0) = TransPoint(New PointF(0, Ymax))
                        AxisY(1) = TransPoint(New PointF(0, -Ymax))
                        g.DrawLines(blackPen1, AxisY)

                        Dim GrayPen1 As New Pen(Color.LightGray, 0.5)
                        GrayPen1.DashStyle = Drawing2D.DashStyle.Dash
                        Dim AxisYmax(1) As PointF
                        AxisYmax(0) = TransPoint(New PointF(0, Ymax))
                        AxisYmax(1) = TransPoint(New PointF(Xmax, Ymax))
                        g.DrawLines(GrayPen1, AxisYmax)
                        Dim AxisYmin(1) As PointF
                        AxisYmin(0) = TransPoint(New PointF(0, -Ymax))
                        AxisYmin(1) = TransPoint(New PointF(Xmax, -Ymax))
                        g.DrawLines(GrayPen1, AxisYmin)

                        Dim fnt As New Font("MS UI Gothic", 8)
                        Dim fmt As New StringFormat
                        fmt.Alignment = StringAlignment.Far
                        fmt.LineAlignment = StringAlignment.Center
                        '文字列を位置(0,0)、黒色で表示
                        g.DrawString(Format(Ymax), fnt, Brushes.Black, TransPoint(New PointF(0, Ymax)), fmt)
                        g.DrawString(Format(0), fnt, Brushes.Black, TransPoint(New PointF(0, 0)), fmt)
                        g.DrawString(Format(-Ymax), fnt, Brushes.Black, TransPoint(New PointF(0, -Ymax)), fmt)

                        If Delta > 0 Then
                            Dim ygrid As Double = 0
                            Dim gridLind(1) As PointF
                            Do
                                ygrid += Delta
                                If ygrid >= Ymax Then Exit Do
                                gridLind(0) = TransPoint(New PointF(0, ygrid))
                                gridLind(1) = TransPoint(New PointF(Xmax, ygrid))
                                g.DrawLines(GrayPen1, gridLind)
                                gridLind(0) = TransPoint(New PointF(0, -ygrid))
                                gridLind(1) = TransPoint(New PointF(Xmax, -ygrid))
                                g.DrawLines(GrayPen1, gridLind)
                            Loop
                        End If

                    End If

                    'Dim PointFN As Integer
                    Dim P() As PointF
                    'If Kataburi Then
                    '    PointN = 3 + 2 * (RepeatN - 1)
                    'Else
                    '    PointN = 5 + 4 * (RepeatN - 1)
                    'End If

                    ReDim LoadPoint(PointN - 1)
                    ReDim P(PointN - 1)
                    Dim m As Integer = 0
                    If Kataburi Then
                        If RepeatN > 0 Then
                            For i As Integer = 0 To RepeatN - 1
                                If i = 0 Then
                                    LoadPoint(m) = 0
                                End If
                                m += 1
                                LoadPoint(m) = PeakP
                                m += 1
                                LoadPoint(m) = 0
                            Next
                        Else
                            LoadPoint(0) = 0
                            LoadPoint(1) = PeakP
                        End If
                    Else
                        For i As Integer = 0 To RepeatN - 1
                            If i = 0 Then
                                LoadPoint(m) = 0
                            End If
                            m += 1
                            LoadPoint(m) = PeakP
                            m += 1
                            LoadPoint(m) = 0
                            m += 1
                            LoadPoint(m) = PeakM
                            m += 1
                            LoadPoint(m) = 0
                        Next
                    End If

                    PointN2 = 0
                    ReDim LoadPoint2(1000), LoadX(1000), LoadDir2(1000)
                    LoadPoint2(0) = 0.0
                    LoadX(0) = 0.0

                    If Delta > 0.0 Then

                        PointN2 += 1
                        Dim L1 As Double, L2 As Double, P1 As Double, m1 As Integer
                        For i As Integer = 1 To PointN - 1
                            L1 = LoadPoint(i - 1)
                            L2 = LoadPoint(i)

                            If Abs(L2) > Abs(L1) Then
                                m1 = 1
                                Do
                                    P1 = L1 + Sign(L2 - L1) * Delta * m1
                                    If Abs(P1) >= Abs(L2) Then Exit Do
                                    LoadPoint2(PointN2) = P1
                                    LoadDir2(PointN2) = Sign(LoadPoint2(PointN2) - LoadPoint2(PointN2 - 1))
                                    LoadX(PointN2) = (P1 - L1) / (L2 - L1) + i - 1
                                    PointN2 += 1
                                    m1 += 1
                                Loop
                                LoadPoint2(PointN2) = L2
                                LoadDir2(PointN2) = Sign(LoadPoint2(PointN2) - LoadPoint2(PointN2 - 1))
                                LoadX(PointN2) = i
                                PointN2 += 1
                            Else
                                m1 = Int(Abs(L2 - L1) / Delta)
                                If m1 * Delta = Abs(L1) Then m1 -= 1
                                Do
                                    P1 = L2 - Sign(L2 - L1) * Delta * m1
                                    If Abs(P1) <= 0 Then Exit Do
                                    LoadPoint2(PointN2) = P1
                                    LoadDir2(PointN2) = Sign(LoadPoint2(PointN2) - LoadPoint2(PointN2 - 1))
                                    LoadX(PointN2) = (P1 - L1) / (L2 - L1) + i - 1
                                    PointN2 += 1
                                    m1 -= 1
                                Loop
                                LoadPoint2(PointN2) = L2
                                LoadDir2(PointN2) = Sign(LoadPoint2(PointN2) - LoadPoint2(PointN2 - 1))
                                LoadX(PointN2) = i
                                PointN2 += 1
                            End If

                        Next

                    Else
                        PointN2 += 1
                        For i As Integer = 1 To PointN - 1
                            LoadPoint2(PointN2) = LoadPoint(i)
                            LoadDir2(PointN2) = Sign(LoadPoint2(PointN2) - LoadPoint2(PointN2 - 1))
                            LoadX(PointN2) = i
                            PointN2 += 1
                        Next

                    End If
                    ReDim Preserve LoadPoint2(PointN2 - 1), LoadX(PointN2 - 1), LoadDir2(PointN2 - 1)


                    For i As Integer = 0 To PointN - 1
                        P(i) = TransPoint(New PointF(i, LoadPoint(i)))
                    Next

                    Dim GreenPen3 As New Pen(Color.Green, 2)
                    g.DrawLines(GreenPen3, P)

                    If PStep > 0 And PointN2 > 0 Then
                        Dim P2(PStep) As PointF
                        For i As Integer = 0 To PStep
                            P2(i) = TransPoint(New PointF(LoadX(i), LoadPoint2(i)))
                        Next
                        Dim RedPen3 As New Pen(Color.Red, 3)
                        g.DrawLines(RedPen3, P2)
                    End If



                    'リソースを解放する
                    g.Dispose()
                    'PictureBox1に表示する
                    PictureBox1.Image = canvas

                End If
            End If
        End With
    End Sub



    Private Function TransPoint(ByVal P1 As PointF) As PointF
        Dim P2 As PointF
        P2.X = Int(P1.X * Xc + XOffSet)
        P2.Y = Int(P1.Y * Yc + YOffSet)
        Return P2
    End Function




End Class
