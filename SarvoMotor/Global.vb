Option Strict Off
Option Explicit On 
Module [Global]

	Public Ret As Integer       ' 関数の戻り値（0以外はエラー)
	Public Ret2 As Integer
	Public Id As Short          ' ボードの番号　"SMC000"の場合は0
	Public AxisNo As Short      ' 1 軸番号
	Public device As String

	Public PulseType As Short   ' 4 (2パルス方式 ：負論理)
	'								0:共通パルス方式 OUT ：  負論理，DIR+：High，DIR-：Low
	'								1:共通パルス方式 OUT ：  正論理，DIR+：High，DIR-：Low
	'								2:共通パルス方式 OUT ：  負論理，DIR+：Low，DIR-：High 
	'								3:共通パルス方式 OUT ：  正論理，DIR+：Low，DIR-：High
	'								4:2パルス方式 ：負論理 
	'								5:2パルス方式 ：正論理
	'								6:90度位相差モード OUT：進み信号. DIR：遅れ信号 
	'								7:90度位相差モード OUT：遅れ信号. DIR：進み信号


	Public DirTimer As Short    ' 1 (ウエイト挿入ON)
	'共通パルス方式設定時、DIR変化の変化によって方向が変化する際に200[μsec]のウェイト(遅延)をパルス出力前に挿入します。（共通パルス方式の場合のみ有効）


	Public EncType As Short     ' 0 (エンコーダの入力方式：A/B (90度位相差) 1逓倍)
	'								0:A/B (90度位相差) 1逓倍
	'								1:A/B (90度位相差) 2逓倍
	'								2:A/B (90度位相差) 4逓倍
	'								3:U/Dの2パルス入力
	'								4:使用しない

	Public CtrlOut1 As Short    ' 0 (制御出力OUT1:汎用出力)
	Public CtrlOut2 As Short    ' 1 (制御出力OUT2:アラームクリア信号)
	Public CtrlOut3 As Short    ' 2 (制御出力OUT3:偏差カウンタクリア信号（ERC）)
	'								0:汎用出力
	'								1:アラームクリア信号
	'								2:偏差カウンタクリア信号（ERC）
	'								3:出力パルスカウンタカウント一致信号（CP1）
	'								4:エンコーダカウンタカウント一致信号（CP2）
	'								5:ホールドオフ信号

	Public CtrlIn As Short      ' 3 (00000011) (制御入力信号形式を設定)([ 0 | 0 | IN6/CLR | IN5/PCS | IN4/LTC | IN3/SD | IN2/INP | IN1/ALM ]
	'								IN1/ALM=0
	'									0: IN1(汎用入力)として使用
	'									1: アラーム(ALM)信号入力として使用

	'								IN2/INP=1
	'									0: IN2(汎用入力)として使用
	'									1: サーボドライバの位置決め完了(INP)信号入力として使用

	'								IN3/SD=0
	'									0: IN3(汎用入力)として使用
	'									1: 減速(減速停止)(SD)信号入力として使用

	'								IN4/LTC=1
	'									0: IN4(汎用入力)として使用
	'									1:LTC信号入力として使用
	'									　 出力パルス/エンコーダカウンタの値をラッチします。

	'								IN5/PCS=1
	'									0: IN5(汎用入力)として使用
	'									1: PCS信号入力として使用
	'									　　この信号入力で位置決め動作を開始します。(目標位置のオーバーライド2用)

	'								IN6/CLR=0
	'									0: IN6(汎用入力)として使用
	'									1: CLR信号入力として使用
	'									　　出力パルス/エンコーダカウンタの値をリセットします。
	'									　　（SMC-2/4/8DL シリーズではIN6固定。CLR信号設定不可）

	Public OrgLog As Short      ' 0 (原点入力論理)

	Public CtrlInOutLog As Short    ' &H83 (制御出力信号論理を設定) [ 0 | 0 | 0 | 0 | 0 | OUT3 | OUT2 | OUT1| LIM | IN7 | IN6 | IN5 | IN4 | IN3 | IN2 | IN1 ]　設定範囲：0～7FF(Hex)
	'									LIM以外は負論理

	Public ErcMode As Short         ' 0 (ERC信号自動出力の設定)[ 0 | 0 | 0 | 0 | 0 | 0 | bit1 | bit0 ]　設定範囲：0～3(Hex)
	'									bit0
	'									0: LIM、ALM信号入力による停止時にERC信号を出力しない
	'									1: LIM、ALM信号入力による停止時にERC信号を自動出力
	'									bit1
	'									0: 原点復帰動作完了時にERC信号を出力しない
	'									1: 原点復帰動作完了時にERC信号を自動出力

	Public ErcTime As Short         ' 0 (偏差カウンタクリア信号幅)
	'									0:12[μsec]
	'									1:102[μsec]
	'									2:408[μsec]
	'									3:1.6[msec]
	'									4:13[msec]
	'									5:52[msec]
	'									6:104[msec]
	'									7:レベル出力

	Public ErcOffTimer As Short     ' 0 (偏差カウンタクリア信号OFFタイマ時間)
	'									0:0[μsec]
	'									1: 12[μsec]
	'									2:1.6[msec]
	'									3:104[msec]

	Public AlmTime As Short         ' 0 (アラームクリア信号幅)
	'									0:12[μsec]
	'									1:102[μsec]
	'									2:408[μsec]
	'									3:1.6[msec]
	'									4:13[msec]
	'									5:52[msec]
	'									6:104[msec]

	Public LimitTurn As Short       ' 1 (原点復帰動作中の+LIM/-LIMリミット反転の有無を設定)
	'									0:LIM信号反転無効
	'									1:LIM信号反転有効
	'									2:LIM信号ON原点復帰開始可能
	'									3:LIM信号入力原点復帰

	Public OrgType As Short         ' 0 (Z相の使用有無を設定)
	'									0:使用しない（ORGのみ）
	'									1:使用する（ORG + Z相）

	Public EndDir As Short          ' 0 (原点復帰時の原点突入方向 (原点復帰終了方向) を設定)
	'									0:未指定
	'									1:正方向 (CW)
	'									2:負方向 (CCW)

	Public ZCount As Short          ' 0 (原点復帰時のZ相の数を設定します。（設定範囲　1～16）)

	Public SAccelType As Short      ' 0 (S字加減速の使用/未使用を設定)
	'									0:使用しない
	'									1:使用する

	Public FilterType As Short      ' 0 (入力フィルタ特性を設定)
	'									0:フィルタを挿入しない
	'									1: 3.2[μsec]
	'									2:25[μsec]
	'									3:200[μsec]
	'									4:1.6[msec]

	Public SDMode As Short          ' 0 (SD信号入力時の動作)
	'									0:減速停止します。減速中にSD信号がOFFになると目標速度に加速します。
	'									1:減速します。減速後、または減速中にSD信号がOFFになると目標速度に加速します。
	'									2:減速停止します。減速中にSD信号がOFFになっても加速しません。
	'									3:減速します。減速後、または減速中にSD信号がOFFになっても開始速度を維持します。

	Public ClearCntLtc As Short     ' 0 (LTC信号がOFF→ONへ変化した時にクリアするカウンタの種類を設定)
	'									0:カウンタをクリアしない
	'									1:出力パルスカウンタをクリア
	'									2:エンコーダカウンタをクリア
	'									3:出力パルスカウンタおよびエンコーダカウンタをクリア

	Public LtcMode As Short         ' 0 (LTC信号入力時にラッチするカウンタの種類を設定)
	'									0:ラッチ機能を使用しない
	'									1:出力パルスカウンタをラッチ
	'									2:エンコーダカウンタをラッチ
	'									3:出力パルスカウンタおよびエンコーダカウンタをラッチ

	Public ClearCntClr As Short     ' 0 (CLR信号がOFF→ONへ変化した時にクリアするカウンタの種類を設定)
	'									0:カウンタをクリアしない
	'									1:出力パルスカウンタをクリア
	'									2:エンコーダカウンタをクリア
	'									3:出力パルスカウンタおよびエンコーダカウンタをクリア

	Public ClrMode As Short         ' 0 固定 (予約)

	Public InitParam As Short       ' SmcWSetInitParam関数実行の有無を格納する変数
	'									0:未実行
	'									1:実行済

	Public CC As Double             ' パルスをmmに変換する係数

	Public PlusSpeed As Integer     ' パルススピード
	Public PistonSpeed As Double    ' ピストンのスピード(mm/sec)
	Public MotionType As Short      ' モータ動作タイプ（0:動作なし,1:PTP動作,2:JOG動作,3:原点復帰動作)
	Public StartDir As Short        ' モータ動作開始方向（0:CW,1:CCW)
	Public StartSpeed As Double     ' スタート時速度
	Public TargetSpeed As Double    ' 目標速度
	Public AccelTime As Double      ' 加速時間
	Public DecelTime As Double      ' 減速時間
	Public ResolveSpeed As Double   ' 速度分解能
	Public StopPosition As Integer  ' 停止位置

	Public lOutPulse As Integer     ' ボードから出力したパルス数
	Public lOutDisp As Double       ' 同ピストン変位 (lOutPulse * CC)
	Public lCountPulse As Integer   ' エンコーダが検出したパルス数
	Public lCountDisp As Double     ' 同ピストン変位 (lCountDisp * CC)
	Public lDistance As Integer     ' 絶対または相対目標パルス数
	Public lDistanceDisp As Double  ' 同ピストン変位 (lDistanceDisp * CC)
	Public bCoordinate As Short     ' 相対パルスまたは絶対パルスの指標（1:相対、0:絶対）
	Public bStopSts1 As Short       ' 停止原因の指標（0:動作中、1:停止コマンドによる停止、255;目標値到達による通常停止)
	Public NextFlag As Boolean
	Public Arrive As Boolean

	Public InitialPulse As Integer  ' 試験開始時の絶対パルス数（イニシャル値）
	Public InitialDisp As Double    ' 同ピストン変位 (InitialPulse * CC)

	Public TestMode As Integer      ' 0:準備・片付け　1:試験モード
	Public Const xSize1 As Integer = 570    ' 準備時の操作パネルの幅
	Public Const ySize1 As Integer = 360    ' 準備時の操作パネルの高さ
	Public Const xSize2 As Integer = 1080   ' 試験時の操作パネルの幅
	Public Const ySize2 As Integer = 720    ' 試験時の操作パネルの高さ

	Public SpeedPanel1 As SpeedPanel                   ' ピストンスピード選択パネルコントロール

	Public RowsIndex1 As Integer    ' 加力スケジュール表の現在の行

	Public PointN As Integer        ' 加力上下限目標値の数
	Public PointN2 As Integer       ' 分割された加力目標値の数
	Public PointI As Integer        ' 現在の加力上下限値の番号
	Public PointI2 As Integer       ' 現在の分割された加力目標値の番号
	Public LoadPoint() As Double    ' 加力上下限目標値
	Public LoadPoint2() As Double   ' 分割された加力目標値
	Public LoadX() As Double        ' 分割された加力目標値のX座標
	Public Delta1 As Double         ' 分割の増分値
	Public Chart As LoadScedule     ' 加力スケジュールの表
	Public LoadGraph1 As LoadGraph  ' 加力スケジュールのグラフ
	Public TestStartFlag As Boolean ' 試験時フラグ（True:試験時）
	Public SControlNo As Integer    ' 制御番号(0:変位制御、1:荷重制御)
	Public Kataburi As Boolean      ' 片振りフラグ(True:片振り、False:両振り)

	Public Const Strokelimit = 151.18   ' ピストンのプラス側リミット変位

	Public Status1 As Status
	Public Cltio1 As Ctlio

	Public Const AIOMaxCh As Integer = 8
	Public MeanSampleN As Integer = 10
	Public Const AIODevice = "AIO000"
	Public AIOCheck(AIOMaxCh - 1) As Boolean
	Public AIOCoef(AIOMaxCh - 1) As Double
	Public AIOPoint(AIOMaxCh - 1) As Integer
	Public AIOUnit(AIOMaxCh - 1) As String

	Public ControlChNo As Integer
	Public AIOChNo As Integer
	Public AIOStartFlag As Boolean
	Public AIOId As Short
	Public AIOData(AIOMaxCh - 1) As Double
	Public AIOMeanData(AIOMaxCh - 1, MeanSampleN - 1) As Double
	Public AIOMean(AIOMaxCh - 1) As Double
	Public MeanDataNo As Integer
	Public AiData(256) As Single
End Module