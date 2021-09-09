Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        PulseType = 4       ' 2パルス方式：負論理
        DirTimer = 1        ' ウエイト
        EncType = 0         ' エンコーダ：A/B （90度位相差）1逓倍
        CtrlOut1 = 0        ' 汎用出力
        CtrlOut2 = 1        ' アラームクリア信号
        CtrlOut3 = 2        ' 偏差カウンタクリア信号
        CtrlIn = 3          ' 制御信号の信号
        OrgLog = 0          ' 原点入力論理
        CtrlInOutLog = &H83 ' 入出力論理
        ErcMode = 0         ' ERC信号自動出力の設定
        ErcTime = 0         ' 偏差カウンタクリア信号幅
        ErcOffTimer = 0     ' 偏差カウンタクリア信号OFFタイマ時間
        AlmTime = 0         ' アラームクリア信号幅











    End Sub
End Class
