Option Strict Off
Option Explicit On 
Imports System.Runtime.InteropServices
Imports System.Text

Module AIO
	'===============================================================================================
	' API-AIO(WDM)用定義ファイル
	'===============================================================================================
	
	'-----------------------------------------------------------------------------------------------
	' 外部制御信号
	'-----------------------------------------------------------------------------------------------
	Public Const AIO_AIF_CLOCK As Short = 0							'アナログ入力外部クロック
	Public Const AIO_AIF_START As Short = 1							'アナログ入力外部開始トリガ
	Public Const AIO_AIF_STOP As Short = 2							'アナログ入力外部停止トリガ
	Public Const AIO_AOF_CLOCK As Short = 3							'アナログ出力外部クロック
	Public Const AIO_AOF_START As Short = 4							'アナログ出力外部開始トリガ
	Public Const AIO_AOF_STOP As Short = 5							'アナログ出力外部停止トリガ
	
	'-----------------------------------------------------------------------------------------------
	' 入力レンジ
	'-----------------------------------------------------------------------------------------------
	Public Const PM10 As Short = 0									'±10V
	Public Const PM5 As Short = 1									'±5V
	Public Const PM25 As Short = 2									'±2.5V
	Public Const PM125 As Short = 3									'±1.25V
	Public Const PM1 As Short = 4									'±1V
	Public Const PM0625 As Short = 5								'±0.625V
	Public Const PM05 As Short = 6									'±0.5V
	Public Const PM03125 As Short = 7								'±0.3125V
	Public Const PM025 As Short = 8									'±0.25V
	Public Const PM0125 As Short = 9								'±0.125V
	Public Const PM01 As Short = 10									'±0.1V
	Public Const PM005 As Short = 11								'±0.05V
	Public Const PM0025 As Short = 12								'±0.025V
	Public Const PM00125 As Short = 13								'±0.0125V
	Public Const PM001 As Short = 14								'±0.01V
	Public Const P10 As Short = 50									'0～10V
	Public Const P5 As Short = 51									'0～5V
	Public Const P4095 As Short = 52								'0～4.095V
	Public Const P25 As Short = 53									'0～2.5V
	Public Const P125 As Short = 54									'0～1.25V
	Public Const P1 As Short = 55									'0～1V
	Public Const P05 As Short = 56									'0～0.5V
	Public Const P025 As Short = 57									'0～0.25V
	Public Const P01 As Short = 58									'0～0.1V
	Public Const P005 As Short = 59									'0～0.05V
	Public Const P0025 As Short = 60								'0～0.025V
	Public Const P00125 As Short = 61								'0～0.0125V
	Public Const P001 As Short = 62									'0～0.01V
	Public Const P20MA As Short = 100								'0～20mA
	Public Const P4TO20MA As Short = 101							'4～20mA
	Public Const P1TO5 As Short = 150								'1～5V
	
	'-----------------------------------------------------------------------------------------------
	' アナログ入力イベント
	'-----------------------------------------------------------------------------------------------
	Public Const AIE_START As Short = &H2S							'AD変換開始条件成立イベント
	Public Const AIE_RPTEND As Short = &H10S						'リピート終了イベント
	Public Const AIE_END As Short = &H20S							'デバイス動作終了イベント
	Public Const AIE_DATA_NUM As Short = &H80S						'データ指定個数格納イベント
	Public Const AIE_DATA_TSF As Short = &H100S						'指定転送数毎イベント
	Public Const AIE_OFERR As Integer = &H10000						'オーバーフローイベント
	Public Const AIE_SCERR As Integer = &H20000						'サンプリングクロックエラーイベント
	Public Const AIE_ADERR As Integer = &H40000						'AD変換エラーイベント
	
	'-----------------------------------------------------------------------------------------------
	' アナログ出力イベント
	'-----------------------------------------------------------------------------------------------
	Public Const AOE_START As Short = &H2S							'DA変換開始条件成立イベント
	Public Const AOE_RPTEND As Short = &H10S						'リピート終了イベント
	Public Const AOE_END As Short = &H20S							'デバイス動作終了イベント
	Public Const AOE_DATA_NUM As Short = &H80S						'データ指定個数格納イベント
	Public Const AOE_DATA_TSF As Short = &H100S						'指定転送数毎イベント
	Public Const AOE_SCERR As Integer = &H20000						'サンプリングクロックエラーイベント
	Public Const AOE_DAERR As Integer = &H40000						'DA変換エラーイベント
	
	'-----------------------------------------------------------------------------------------------
	' カウンタイベント
	'-----------------------------------------------------------------------------------------------
	Public Const CNTE_DATA_NUM As Short = &H10S						'比較カウント一致イベント
	Public Const CNTE_ORERR As Integer = &H10000					'カウントオーバーランイベント
	Public Const CNTE_ERR As Integer = &H20000						'カウンタ動作エラー
	
	'-----------------------------------------------------------------------------------------------
	' タイマイベント
	'-----------------------------------------------------------------------------------------------
	Public Const TME_INT As Short = &H1S							'インターバル成立イベント
	
	'-----------------------------------------------------------------------------------------------
	' アナログ入力ステータス
	'-----------------------------------------------------------------------------------------------
	Public Const AIS_BUSY As Short = &H1S							'デバイス動作中
	Public Const AIS_START_TRG As Short = &H2S						'開始トリガ待ち
	Public Const AIS_DATA_NUM As Short = &H10S						'指定個数以上データ格納
	Public Const AIS_OFERR As Integer = &H10000						'オーバーフロー
	Public Const AIS_SCERR As Integer = &H20000						'サンプリングクロックエラー
	Public Const AIS_ADERR As Integer = &H40000						'AD変換エラー
	Public Const AIS_DRVERR As Integer = &H80000					'ドライバスペックエラー
	
	'-----------------------------------------------------------------------------------------------
	' アナログ出力ステータス
	'-----------------------------------------------------------------------------------------------
	Public Const AOS_BUSY As Short = &H1S							'デバイス動作中
	Public Const AOS_START_TRG As Short = &H2S						'開始トリガ待ち
	Public Const AOS_DATA_NUM As Short = &H10S						'指定個数以上データ格納
	Public Const AOS_SCERR As Integer = &H20000						'サンプリングクロックエラー
	Public Const AOS_DAERR As Integer = &H40000						'DA変換エラー
	Public Const AOS_DRVERR As Integer = &H80000					'ドライバスペックエラー
	
	'-----------------------------------------------------------------------------------------------
	' カウンタステータス
	'-----------------------------------------------------------------------------------------------
	Public Const CNTS_BUSY As Short = &H1S							'カウンタ動作中
	Public Const CNTS_DATA_NUM As Short = &H10S						'比較カウント一致
	Public Const CNTS_ORERR As Integer = &H10000					'オーバーラン
	Public Const CNTS_ERR As Integer = &H20000						'カウンタ動作エラー
	
	'-----------------------------------------------------------------------------------------------
	' アナログ入力メッセージ
	'-----------------------------------------------------------------------------------------------
	Public Const AIOM_AIE_START As Short = &H1000S					'AD変換開始条件成立イベント
	Public Const AIOM_AIE_RPTEND As Short = &H1001S					'リピート終了イベント
	Public Const AIOM_AIE_END As Short = &H1002S					'デバイス動作終了イベント
	Public Const AIOM_AIE_DATA_NUM As Short = &H1003S				'データ指定個数格納イベント
	Public Const AIOM_AIE_DATA_TSF As Short = &H1007S				'指定転送数毎イベント
	Public Const AIOM_AIE_OFERR As Short = &H1004S					'オーバーフローイベント
	Public Const AIOM_AIE_SCERR As Short = &H1005S					'サンプリングクロックエラーイベント
	Public Const AIOM_AIE_ADERR As Short = &H1006S					'AD変換エラーイベント
	
	'-----------------------------------------------------------------------------------------------
	' アナログ出力メッセージ
	'-----------------------------------------------------------------------------------------------
	Public Const AIOM_AOE_START As Short = &H1020S					'DA変換開始条件成立イベント
	Public Const AIOM_AOE_RPTEND As Short = &H1021S					'リピート終了イベント
	Public Const AIOM_AOE_END As Short = &H1022S					'デバイス動作終了イベント
	Public Const AIOM_AOE_DATA_NUM As Short = &H1023S				'データ指定個数格納イベント
	Public Const AIOM_AOE_DATA_TSF As Short = &H1027S				'指定転送数毎イベント
	Public Const AIOM_AOE_SCERR As Short = &H1025S					'サンプリングクロックエラーイベント
	Public Const AIOM_AOE_DAERR As Short = &H1026S					'DA変換エラーイベント
	
	'-----------------------------------------------------------------------------------------------
	' カウンタメッセージ
	'-----------------------------------------------------------------------------------------------
	Public Const AIOM_CNTE_DATA_NUM As Short = &H1042S				'比較カウント一致イベント
	Public Const AIOM_CNTE_ORERR As Short = &H1043S					'カウントオーバーランイベント
	Public Const AIOM_CNTE_ERR As Short = &H1044S					'カウント動作エラーイベント
	
	'-----------------------------------------------------------------------------------------------
	' タイマメッセージ
	'-----------------------------------------------------------------------------------------------
	Public Const AIOM_TME_INT As Short = &H1060S					'インターバル成立イベント
	
	'-----------------------------------------------------------------------------------------------
	' アナログ入力添付データ
	'-----------------------------------------------------------------------------------------------
	Public Const AIAT_AI As Short = &H1S							'アナログ入力付属情報
	Public Const AIAT_AO0 As Short = &H100S							'アナログ出力データ
	Public Const AIAT_DIO0 As Integer = &H10000						'デジタル入出力データ
	Public Const AIAT_CNT0 As Integer = &H1000000					'カウンタチャネル０データ
	Public Const AIAT_CNT1 As Integer = &H2000000					'カウンタチャネル１データ

	'-----------------------------------------------------------------------------------------------
	' カウンタ動作モード
	'-----------------------------------------------------------------------------------------------
	Public Const CNT_LOADPRESET As Short = &H1S						'プリセットカウント値のロード
	Public Const CNT_LOADCOMP As Short = &H2S						'比較カウント値のロード
	
	'-----------------------------------------------------------------------------------------------
	' イベントコントローラ接続先信号
	'-----------------------------------------------------------------------------------------------
	Public Const AIOECU_DEST_AI_CLK As Short = 4					'アナログ入力サンプリングクロック
	Public Const AIOECU_DEST_AI_START As Short = 0					'アナログ入力変換開始信号
	Public Const AIOECU_DEST_AI_STOP As Short = 2					'アナログ入力変換停止信号
	Public Const AIOECU_DEST_AO_CLK As Short = 36					'アナログ出力サンプリングクロック
	Public Const AIOECU_DEST_AO_START As Short = 32					'アナログ出力変換開始信号
	Public Const AIOECU_DEST_AO_STOP As Short = 34					'アナログ出力変換停止信号
	Public Const AIOECU_DEST_CNT0_UPCLK As Short = 134				'カウンタ０アップクロック信号
	Public Const AIOECU_DEST_CNT1_UPCLK As Short = 135				'カウンタ１アップクロック信号
	Public Const AIOECU_DEST_CNT0_START As Short = 128				'カウンタ０、タイマ０動作開始信号
	Public Const AIOECU_DEST_CNT1_START As Short = 129				'カウンタ１、タイマ１動作開始信号
	Public Const AIOECU_DEST_CNT0_STOP As Short = 130				'カウンタ０、タイマ０動作停止信号
	Public Const AIOECU_DEST_CNT1_STOP As Short = 131				'カウンタ１、タイマ１動作停止信号
	Public Const AIOECU_DEST_MASTER1 As Short = 104					'同期バスマスタ信号１
	Public Const AIOECU_DEST_MASTER2 As Short = 105					'同期バスマスタ信号２
	Public Const AIOECU_DEST_MASTER3 As Short = 106					'同期バスマスタ信号３
	
	'-----------------------------------------------------------------------------------------------
	' イベントコントローラ接続元信号
	'-----------------------------------------------------------------------------------------------
	Public Const AIOECU_SRC_OPEN As Short = -1						'未接続
	Public Const AIOECU_SRC_AI_CLK As Short = 4						'アナログ入力内部クロック信号
	Public Const AIOECU_SRC_AI_EXTCLK As Short = 146				'アナログ入力外部クロック信号
	Public Const AIOECU_SRC_AI_TRGSTART As Short = 144				'アナログ入力外部トリガ開始信号
	Public Const AIOECU_SRC_AI_LVSTART As Short = 28				'アナログ入力レベルトリガ開始信号
	Public Const AIOECU_SRC_AI_STOP As Short = 17					'アナログ入力変換回数終了信号（遅延なし）
	Public Const AIOECU_SRC_AI_STOP_DELAY As Short = 18				'アナログ入力変換回数終了信号（遅延あり）
	Public Const AIOECU_SRC_AI_LVSTOP As Short = 29					'アナログ入力レベルトリガ停止信号
	Public Const AIOECU_SRC_AI_TRGSTOP As Short = 145				'アナログ入力外部トリガ停止信号
	Public Const AIOECU_SRC_AO_CLK As Short = 66					'アナログ出力内部クロック信号
	Public Const AIOECU_SRC_AO_EXTCLK As Short = 149				'アナログ出力外部クロック信号
	Public Const AIOECU_SRC_AO_TRGSTART As Short = 147				'アナログ出力外部トリガ開始信号
	Public Const AIOECU_SRC_AO_STOP_FIFO As Short = 352				'アナログ出力指定回数出力終了信号（FIFO使用）
	Public Const AIOECU_SRC_AO_STOP_RING As Short = 80				'アナログ出力指定回数出力終了信号（RING使用）
	Public Const AIOECU_SRC_AO_TRGSTOP As Short = 148				'アナログ出力外部トリガ停止信号
	Public Const AIOECU_SRC_CNT0_UPCLK As Short = 150				'カウンタ０アップクロック信号
	Public Const AIOECU_SRC_CNT1_UPCLK As Short = 152				'カウンタ１アップクロック信号
	Public Const AIOECU_SRC_CNT0_CMP As Short = 288					'カウンタ０比較カウント一致
	Public Const AIOECU_SRC_CNT1_CMP As Short = 289					'カウンタ１比較カウント一致
	Public Const AIOECU_SRC_SLAVE1 As Short = 136					'同期バススレーブ信号１
	Public Const AIOECU_SRC_SLAVE2 As Short = 137					'同期バススレーブ信号２
	Public Const AIOECU_SRC_SLAVE3 As Short = 138					'同期バススレーブ信号３
	Public Const AIOECU_SRC_START As Short = 384					'Ai, Ao, Cnt, Tmソフトウェア開始信号
	Public Const AIOECU_SRC_STOP As Short = 385						'Ai, Ao, Cnt, Tmソフトウェア停止信号

    '-------------------------------------------------
    ' Mデバイス用カウンタメッセージ
    '-------------------------------------------------
    Public Const AIOM_CNTM_COUNTUP_CH0 As Short = &H1070            'カウントアップ、チャネル番号0
    Public Const AIOM_CNTM_COUNTUP_CH1 As Short = &H1071            '			"				1

    Public Const AIOM_CNTM_TIME_UP As Short = &H1090                'タイムアップ
    Public Const AIOM_CNTM_COUNTER_ERROR As Short = &H1091S         'カウンタエラー
    Public Const AIOM_CNTM_CARRY_BORROW As Short = &H1092S          'キャリー／ボロー	

    '-------------------------------------------------------------
    ' Delegate
    '-------------------------------------------------------------
    Public Delegate Sub PAICALLBACK(ByVal Id As Short, ByVal Message As Short, ByVal wParam As Integer, ByVal lParam As Integer, ByVal Param As IntPtr)
    Public Delegate Sub PAOCALLBACK(ByVal Id As Short, ByVal Message As Short, ByVal wParam As Integer, ByVal lParam As Integer, ByVal Param As IntPtr)
    Public Delegate Sub PCNTCALLBACK(ByVal Id As Short, ByVal Message As Short, ByVal wParam As Integer, ByVal lParam As Integer, ByVal Param As IntPtr)
    Public Delegate Sub PTMCALLBACK(ByVal Id As Short, ByVal Message As Short, ByVal wParam As Integer, ByVal lParam As Integer, ByVal Param As IntPtr)
    ' Mデバイス用 Start
    Public Delegate Sub PAIOCNTMCOUNTUPCALLBACK(ByVal Id As Short, ByVal wParam As Integer, ByVal lParam As Integer, ByVal Param As IntPtr)
    Public Delegate Sub PAIOCNTMCOUNTERERRORCALLBACK(ByVal Id As Short, ByVal wParam As Integer, ByVal lParam As Integer, ByVal Param As IntPtr)
    Public Delegate Sub PAIOCNTMCARRYBORROWCALLBACK(ByVal Id As Short, ByVal wParam As Integer, ByVal lParam As Integer, ByVal Param As IntPtr)
    Public Delegate Sub PAIOCNTMTMCALLBACK(ByVal Id As Short, ByVal wParam As Integer, ByVal lParam As Integer, ByVal Param As IntPtr)
    ' Mデバイス用 End

    '-----------------------------------------------------------------------------------------------
    ' 関数プロトタイプ
    '-----------------------------------------------------------------------------------------------
    '共通関数
    Declare Function AioInit Lib "CAIO.DLL" (ByVal DeviceName As String, ByRef Id As Short) As Integer
    Declare Function AioExit Lib "CAIO.DLL" (ByVal Id As Short) As Integer
    Declare Function AioResetDevice Lib "CAIO.DLL" (ByVal Id As Short) As Integer
    Declare Function AioGetErrorString Lib "CAIO.DLL" (ByVal ErrorCode As Integer, ByVal ErrorString As StringBuilder) As Integer
    Declare Function AioQueryDeviceName Lib "CAIO.DLL" (ByVal Index As Short, ByVal DeviceName As String, ByVal Device As String) As Integer
    Declare Function AioGetDeviceType Lib "CAIO.DLL" (ByVal Device As String, ByRef DeviceType As Short) As Integer
    Declare Function AioSetControlFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal Signal As Short, ByVal Value As Single) As Integer
    Declare Function AioGetControlFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal Signal As Short, ByRef Value As Single) As Integer
    Declare Function AioResetProcess Lib "CAIO.DLL" (ByVal Id As Short) As Integer

    ' アナログ入力関数
    Declare Function AioSingleAi Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiData As Integer) As Integer
    Declare Function AioSingleAiEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiData As Single) As Integer
    Declare Function AioMultiAi Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannels As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal AiData() As Integer) As Integer
    Declare Function AioMultiAiEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannels As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal AiData() As Single) As Integer
    Declare Function AioSingleAiSR Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiData As Integer, ByRef Timestamp As UShort, ByVal Mode As Byte) As Integer
    Declare Function AioSingleAiExSR Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiData As Single, ByRef Timestamp As UShort, ByVal Mode As Byte) As Integer
    Declare Function AioMultiAiSR Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannels As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal AiData() As Integer, ByRef Timestamp As UShort, ByVal Mode As Byte) As Integer
    Declare Function AioMultiAiExSR Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannels As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal AiData() As Single, ByRef Timestamp As UShort, ByVal Mode As Byte) As Integer
    Declare Function AioGetAiMaxChannels Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiMaxChannels As Short) As Integer
    Declare Function AioGetAiResolution Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiResolution As Short) As Integer
    Declare Function AioSetAiInputMethod Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiInputMethod As Short) As Integer
    Declare Function AioGetAiInputMethod Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiInputMethod As Short) As Integer
    Declare Function AioSetAiChannel Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannels As Short, ByVal Enabled As Short) As Integer
    Declare Function AioGetAiChannel Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannels As Short, ByRef Enabled As Short) As Integer
    Declare Function AioSetAiChannels Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannels As Short) As Integer
    Declare Function AioGetAiChannels Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiChannels As Short) As Integer
    Declare Function AioSetAiChannelSequence Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiSequence As Short, ByVal AiChannel As Short) As Integer
    Declare Function AioGetAiChannelSequence Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiSequence As Short, ByRef AiChannel As Short) As Integer
    Declare Function AioSetAiRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal AiRange As Short) As Integer
    Declare Function AioGetAiRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiRange As Short) As Integer
    Declare Function AioSetAiTransferMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiTransferMode As Short) As Integer
    Declare Function AioGetAiTransferMode Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiTransferMode As Short) As Integer
    Declare Function AioSetAiDeviceBufferMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiDeviceBufferMode As Short) As Integer
    Declare Function AioGetAiDeviceBufferMode Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiDeviceBufferMode As Short) As Integer
    Declare Function AioSetAiMemorySize Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiMemorySize As Integer) As Integer
    Declare Function AioGetAiMemorySize Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiMemorySize As Integer) As Integer
    Declare Function AioSetAiTransferData Lib "CAIO.DLL" (ByVal Id As Short, ByVal DataNumber As Integer, ByVal Buffer As IntPtr) As Integer
    Declare Function AioSetAiAttachedData Lib "CAIO.DLL" (ByVal Id As Short, ByVal AttachedData As Integer) As Integer
    Declare Function AioGetAiSamplingDataSize Lib "CAIO.DLL" (ByVal Id As Short, ByRef DataSize As Short) As Integer
    Declare Function AioSetAiRangeAll Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiRange As Short) As Integer
    Declare Function AioSetAiMemoryType Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiMemoryType As Short) As Integer
    Declare Function AioGetAiMemoryType Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiMemoryType As Short) As Integer
    Declare Function AioSetAiRepeatTimes Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiRepeatTimes As Integer) As Integer
    Declare Function AioGetAiRepeatTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiRepeatTimes As Integer) As Integer
    Declare Function AioSetAiClockType Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiClockType As Short) As Integer
    Declare Function AioGetAiClockType Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiClockType As Short) As Integer
    Declare Function AioSetAiSamplingClock Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiSamplingClock As Single) As Integer
    Declare Function AioGetAiSamplingClock Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiSamplingClock As Single) As Integer
    Declare Function AioSetAiScanClock Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiScanClock As Single) As Integer
    Declare Function AioGetAiScanClock Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiScanClock As Single) As Integer
    Declare Function AioSetAiClockEdge Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiClockEdge As Short) As Integer
    Declare Function AioGetAiClockEdge Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiClockEdge As Short) As Integer
    Declare Function AioSetAiStartTrigger Lib "CAIO.DLL" (ByVal Id As Short, ByVal AIStartTrigger As Short) As Integer
    Declare Function AioGetAiStartTrigger Lib "CAIO.DLL" (ByVal Id As Short, ByRef AIStartTrigger As Short) As Integer
    Declare Function AioSetAiStartLevel Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal AiStartLevel As Integer, ByVal AiDirection As Short) As Integer
    Declare Function AioSetAiStartLevelEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal AiStartLevel As Single, ByVal AiDirection As Short) As Integer
    Declare Function AioGetAiStartLevel Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiStartLevel As Integer, ByRef AiDirection As Short) As Integer
    Declare Function AioGetAiStartLevelEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiStartLevel As Single, ByRef AiDirection As Short) As Integer
    Declare Function AioSetAiStartInRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal Level1 As Integer, ByVal Level2 As Integer, ByVal StateTimes As Integer) As Integer
    Declare Function AioSetAiStartInRangeEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal Level1 As Single, ByVal Level2 As Single, ByVal StateTimes As Integer) As Integer
    Declare Function AioGetAiStartInRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef Level1 As Integer, ByRef Level2 As Integer, ByRef StateTimes As Integer) As Integer
    Declare Function AioGetAiStartInRangeEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef Level1 As Single, ByRef Level2 As Single, ByRef StateTimes As Integer) As Integer
    Declare Function AioSetAiStartOutRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal Level1 As Integer, ByVal Level2 As Integer, ByVal StateTimes As Integer) As Integer
    Declare Function AioSetAiStartOutRangeEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal Level1 As Single, ByVal Level2 As Single, ByVal StateTimes As Integer) As Integer
    Declare Function AioGetAiStartOutRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef Level1 As Integer, ByRef Level2 As Integer, ByRef StateTimes As Integer) As Integer
    Declare Function AioGetAiStartOutRangeEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef Level1 As Single, ByRef Level2 As Single, ByRef StateTimes As Integer) As Integer
    Declare Function AioSetAiStopTrigger Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiStopTrigger As Short) As Integer
    Declare Function AioGetAiStopTrigger Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiStopTrigger As Short) As Integer
    Declare Function AioSetAiStopTimes Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiStopTimes As Integer) As Integer
    Declare Function AioGetAiStopTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiStopTimes As Integer) As Integer
    Declare Function AioSetAiStopLevel Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal AiStopLevel As Integer, ByVal AiDirection As Short) As Integer
    Declare Function AioSetAiStopLevelEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal AiStopLevel As Single, ByVal AiDirection As Short) As Integer
    Declare Function AioGetAiStopLevel Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiStopLevel As Integer, ByRef AiDirection As Short) As Integer
	Declare Function AioGetAiStopLevelEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef AiStopLevel As Single, ByRef AiDirection As Short) As Integer
	Declare Function AioSetAiStopInRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal Level1 As Integer, ByVal Level2 As Integer, ByVal StateTimes As Integer) As Integer
	Declare Function AioSetAiStopInRangeEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal Level1 As Single, ByVal Level2 As Single, ByVal StateTimes As Integer) As Integer
	Declare Function AioGetAiStopInRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef Level1 As Integer, ByRef Level2 As Integer, ByRef StateTimes As Integer) As Integer
	Declare Function AioGetAiStopInRangeEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef Level1 As Single, ByRef Level2 As Single, ByRef StateTimes As Integer) As Integer
	Declare Function AioSetAiStopOutRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal Level1 As Integer, ByVal Level2 As Integer, ByVal StateTimes As Integer) As Integer
	Declare Function AioSetAiStopOutRangeEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal Level1 As Single, ByVal Level2 As Single, ByVal StateTimes As Integer) As Integer
	Declare Function AioGetAiStopOutRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef Level1 As Integer, ByRef Level2 As Integer, ByRef StateTimes As Integer) As Integer
	Declare Function AioGetAiStopOutRangeEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef Level1 As Single, ByRef Level2 As Single, ByRef StateTimes As Integer) As Integer
	Declare Function AioSetAiStopDelayTimes Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiStopDelayTimes As Integer) As Integer
	Declare Function AioGetAiStopDelayTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiStopDelayTimes As Integer) As Integer
	Declare Function AioSetAiEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal hWnd As Integer, ByVal AiEvent As Integer) As Integer
	Declare Function AioGetAiEvent Lib "CAIO.DLL" (ByVal Id As Short, ByRef hWnd As Integer, ByRef AiEvent As Integer) As Integer
    Declare Function AioSetAiCallBackProc Lib "CAIO.DLL" (ByVal Id As Short, ByVal PAICALLBACK As IntPtr, ByVal AiEvent As Integer, ByVal Param As IntPtr) As Integer
	Declare Function AioSetAiEventSamplingTimes Lib "CAIO.DLL" (ByVal Id As Short, ByVal AIEventSamplingTimes As Integer) As Integer
	Declare Function AioGetAiEventSamplingTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AIEventSamplingTimes As Integer) As Integer
	Declare Function AioSetAiEventTransferTimes Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiTransferTimes As Integer) As Integer
	Declare Function AioGetAiEventTransferTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiTransferTimes As Integer) As Integer
	Declare Function AioSetAiCondition Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	Declare Function AioStartAi Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	Declare Function AioStartAiSync Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimeOut As Integer) As Integer
	Declare Function AioStopAi Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	Declare Function AioGetAiStatus Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiStatus As Integer) As Integer
	Declare Function AioGetAiSamplingCount Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiSamplingCount As Integer) As Integer
	Declare Function AioGetAiRepeatCount Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiRepeatCount As Integer) As Integer
	Declare Function AioGetAiStopTriggerCount Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiStopTriggerCount As Integer) As Integer
	Declare Function AioGetAiTransferCount Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiTransferCount As Integer) As Integer
	Declare Function AioGetAiTransferLap Lib "CAIO.DLL" (ByVal Id As Short, ByRef Lap As Integer) As Integer
	Declare Function AioGetAiSamplingData Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiSamplingTimes As Integer, <MarshalAs(UnmanagedType.LPArray)> ByVal AiData() As Integer) As Integer
	Declare Function AioGetAiSamplingDataEx Lib "CAIO.DLL" (ByVal Id As Short, ByRef AiSamplingTimes As Integer, <MarshalAs(UnmanagedType.LPArray)> ByVal AiData() As Single) As Integer
	Declare Function AioResetAiStatus Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	Declare Function AioResetAiMemory Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	Declare Function AioSetAiDigitalFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByVal FilterType As Short, ByVal FilterValue As Short) As Integer
	Declare Function AioGetAiDigitalFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiChannel As Short, ByRef FilterType As Short, ByRef FilterValue As Short) As Integer
	
	' アナログ出力関数
	Declare Function AioSingleAo Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannel As Short, ByVal AoData As Integer) As Integer
	Declare Function AioSingleAoEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannel As Short, ByVal AoData As Single) As Integer
	Declare Function AioMultiAo Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannels As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal AoData() As Integer) As Integer
	Declare Function AioMultiAoEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannels As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal AoData() As Single) As Integer
	Declare Function AioGetAoResolution Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoResolution As Short) As Integer
	Declare Function AioSetAoChannels Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannels As Short) As Integer
	Declare Function AioGetAoChannels Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoChannels As Short) As Integer
	Declare Function AioGetAoMaxChannels Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoMaxChannels As Short) As Integer
	Declare Function AioSetAoRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannel As Short, ByVal AoRange As Short) As Integer
	Declare Function AioSetAoRangeAll Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoRange As Short) As Integer
	Declare Function AioGetAoRange Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannel As Short, ByRef AoRange As Short) As Integer
	Declare Function AioSetAoTransferMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoTransferMode As Short) As Integer
	Declare Function AioGetAoTransferMode Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoTransferMode As Short) As Integer
	Declare Function AioSetAoDeviceBufferMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoDeviceBufferMode As Short) As Integer
	Declare Function AioGetAoDeviceBufferMode Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoDeviceBufferMode As Short) As Integer
	Declare Function AioSetAoMemorySize Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoMemorySize As Integer) As Integer
	Declare Function AioGetAoMemorySize Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoMemorySize As Integer) As Integer
	Declare Function AioSetAoTransferData Lib "CAIO.DLL" (ByVal Id As Short, ByVal DataNumber As Integer, ByVal Buffer As IntPtr) As Integer
	Declare Function AioGetAoSamplingDataSize Lib "CAIO.DLL" (ByVal Id As Short, ByRef DataSize As Short) As Integer
	Declare Function AioSetAoMemoryType Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoMemoryType As Short) As Integer
	Declare Function AioGetAoMemoryType Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoMemoryType As Short) As Integer
	Declare Function AioSetAoRepeatTimes Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoRepeatTimes As Integer) As Integer
	Declare Function AioGetAoRepeatTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoRepeatTimes As Integer) As Integer
	Declare Function AioSetAoClockType Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoClockType As Short) As Integer
	Declare Function AioGetAoClockType Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoClockType As Short) As Integer
	Declare Function AioSetAoSamplingClock Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoSamplingClock As Single) As Integer
	Declare Function AioGetAoSamplingClock Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoSamplingClock As Single) As Integer
	Declare Function AioSetAoClockEdge Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoClockEdge As Short) As Integer
	Declare Function AioGetAoClockEdge Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoClockEdge As Short) As Integer
	Declare Function AioSetAoSamplingData Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoSamplingTimes As Integer, <MarshalAs(UnmanagedType.LPArray)> ByVal AoData() As Integer) As Integer
	Declare Function AioSetAoSamplingDataEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoSamplingTimes As Integer, <MarshalAs(UnmanagedType.LPArray)> ByVal AoData() As Single) As Integer
	Declare Function AioGetAoSamplingTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoSamplingTimes As Integer) As Integer
	Declare Function AioSetAoStartTrigger Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoStartTrigger As Short) As Integer
	Declare Function AioGetAoStartTrigger Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoStartTrigger As Short) As Integer
	Declare Function AioSetAoStopTrigger Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoStopTrigger As Short) As Integer
	Declare Function AioGetAoStopTrigger Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoStopTrigger As Short) As Integer
	Declare Function AioSetAoEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal hWnd As Integer, ByVal AoEvent As Integer) As Integer
	Declare Function AioGetAoEvent Lib "CAIO.DLL" (ByVal Id As Short, ByRef hWnd As Integer, ByRef AoEvent As Integer) As Integer
    Declare Function AioSetAoCallBackProc Lib "CAIO.DLL" (ByVal Id As Short, ByVal PAOCALLBACK As IntPtr, ByVal AoEvent As Integer, ByVal Param As IntPtr) As Integer
	Declare Function AioSetAoEventSamplingTimes Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoSamplingTimes As Integer) As Integer
	Declare Function AioGetAoEventSamplingTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoSamplingTimes As Integer) As Integer
	Declare Function AioSetAoEventTransferTimes Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoTransferTimes As Integer) As Integer
	Declare Function AioGetAoEventTransferTimes Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoTransferTimes As Integer) As Integer
	Declare Function AioStartAo Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	Declare Function AioStopAo Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	Declare Function AioEnableAo Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannel As Short) As Integer
	Declare Function AioDisableAo Lib "CAIO.DLL" (ByVal Id As Short, ByVal AoChannel As Short) As Integer
	Declare Function AioGetAoStatus Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoStatus As Integer) As Integer
	Declare Function AioGetAoSamplingCount Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoSamplingCount As Integer) As Integer
	Declare Function AioGetAoTransferCount Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoTransferCount As Integer) As Integer
	Declare Function AioGetAoTransferLap Lib "CAIO.DLL" (ByVal Id As Short, ByRef Lap As Integer) As Integer
	Declare Function AioGetAoRepeatCount Lib "CAIO.DLL" (ByVal Id As Short, ByRef AoRepeatCount As Integer) As Integer
	Declare Function AioResetAoStatus Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	Declare Function AioResetAoMemory Lib "CAIO.DLL" (ByVal Id As Short) As Integer
	
	' デジタル入出力関数
	Declare Function AioSetDiFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal Bit As Short, ByVal Value As Single) As Integer
	Declare Function AioGetDiFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal Bit As Short, ByRef Value As Single) As Integer
	Declare Function AioInputDiBit Lib "CAIO.DLL" (ByVal Id As Short, ByVal DiBit As Short, ByRef DiData As Short) As Integer
	Declare Function AioOutputDoBit Lib "CAIO.DLL" (ByVal Id As Short, ByVal DoBit As Short, ByVal DoData As Short) As Integer
	Declare Function AioInputDiByte Lib "CAIO.DLL" (ByVal Id As Short, ByVal DiPort As Short, ByRef DiData As Short) As Integer
	Declare Function AioOutputDoByte Lib "CAIO.DLL" (ByVal Id As Short, ByVal DoPort As Short, ByVal DoData As Short) As Integer
	Declare Function AioSetDioDirection Lib "CAIO.DLL" (ByVal Id As Short, ByVal DiPort As Integer) As Integer
	Declare Function AioGetDioDirection Lib "CAIO.DLL" (ByVal Id As Short, ByRef DoPort As Integer) As Integer

	' カウンタ関数
	Declare Function AioGetCntMaxChannels Lib "CAIO.DLL" (ByVal Id As Short, ByRef CntMaxChannels As Short) As Integer
	Declare Function AioSetCntComparisonMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal CntMode As Short) As Integer
	Declare Function AioGetCntComparisonMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByRef CntMode As Short) As Integer
	Declare Function AioSetCntPresetReg Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal PresetNumber As Integer, <MarshalAs(UnmanagedType.LPArray)> ByVal PresetData() As Integer, ByVal Flag As Short) As Integer
	Declare Function AioSetCntComparisonReg Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal ComparisonNumber As Integer, <MarshalAs(UnmanagedType.LPArray)> ByVal ComparisonData() As Integer, ByVal Flag As Short) As Integer
	Declare Function AioSetCntInputSignal Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal CntInputSignal As Short) As Integer
	Declare Function AioGetCntInputSignal Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByRef CntInputSignal As Short) As Integer
	Declare Function AioSetCntEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal hWnd As Integer, ByVal CntEvent As Integer) As Integer
	Declare Function AioGetCntEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByRef hWnd As Integer, ByRef CntEvent As Integer) As Integer
    Declare Function AioSetCntCallBackProc Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal PCNTCALLBACK As IntPtr, ByVal CntEvent As Integer, ByVal Param As IntPtr) As Integer
	Declare Function AioSetCntFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal Signal As Short, ByVal Value As Single) As Integer
	Declare Function AioGetCntFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal Signal As Short, ByRef Value As Single) As Integer
	Declare Function AioStartCnt Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short) As Integer
	Declare Function AioStopCnt Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short) As Integer
	Declare Function AioPresetCnt Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal PresetData As Integer) As Integer
	Declare Function AioGetCntStatus Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByRef CntStatus As Integer) As Integer
	Declare Function AioGetCntCount Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByRef Count As Integer) As Integer
	Declare Function AioResetCntStatus Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntChannel As Short, ByVal CntStatus As Integer) As Integer
	
	' タイマ関数
	Declare Function AioSetTmEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short, ByVal hWnd As Integer, ByVal TmEvent As Integer) As Integer
	Declare Function AioGetTmEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short, ByRef hWnd As Integer, ByRef TmEvent As Integer) As Integer
    Declare Function AioSetTmCallBackProc Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short, ByVal PTMCALLBACK As IntPtr, ByVal TmEvent As Integer, ByVal Param As IntPtr) As Integer
	Declare Function AioStartTmTimer Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short, ByVal Interval As Single) As Integer
	Declare Function AioStopTmTimer Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short) As Integer
	Declare Function AioStartTmCount Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short) As Integer
	Declare Function AioStopTmCount Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short) As Integer
	Declare Function AioLapTmCount Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short, ByRef Lap As Integer) As Integer
	Declare Function AioResetTmCount Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short) As Integer
	Declare Function AioTmWait Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimerId As Short, ByVal Wait As Integer) As Integer
	
	' イベントコントローラ
	Declare Function AioSetEcuSignal Lib "CAIO.DLL" (ByVal Id As Short, ByVal Destination As Short, ByVal Source As Short) As Integer
	Declare Function AioGetEcuSignal Lib "CAIO.DLL" (ByVal Id As Short, ByVal Destination As Short, ByRef Source As Short) As Integer

	' Setting function (set)
	Declare Function AioGetCntmMaxChannels Lib "CAIO.DLL" (ByVal Id As Short, ByRef CntmMaxChannels As Short) As Integer
	Declare Function AioSetCntmZMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal Mode As Short) As Integer
	Declare Function AioSetCntmZLogic Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal ZLogic As Short) As Integer
	Declare Function AioSelectCntmChannelSignal Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal SigType As Short) As Integer
	Declare Function AioSetCntmCountDirection Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal Dir As Short) As Integer
	Declare Function AioSetCntmOperationMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal Phase As Short, ByVal Mul As Short, ByVal SyncClr As Short) As Integer
	Declare Function AioSetCntmDigitalFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal FilterValue As Short) As Integer
	Declare Function AioSetCntmPulseWidth Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal PlsWidth As Short) As Integer
	Declare Function AioSetCntmDIType Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal InputType As Short) As Integer
	Declare Function AioSetCntmOutputHardwareEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal OutputLogic As Short, ByVal EventType As Integer, ByVal PulseWidth As Short) As Integer
	Declare Function AioSetCntmInputHardwareEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal EventType As Integer, ByVal RF0 As Short, ByVal RF1 As Short, ByVal Reserved As Short) As Integer
	Declare Function AioSetCntmCountMatchHardwareEvent Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal RegisterNo As Short, ByVal EventType As Integer, ByVal Reserved As Short) As Integer
	Declare Function AioSetCntmPresetRegister Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal PresetData As Integer, ByVal Reserved As Short) As Integer
	Declare Function AioSetCntmTestPulse Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntmInternal As Short, ByVal CntmOut As Short, ByVal CntmReserved As Short) As Integer

	' Setting function (get)
	Declare Function AioGetCntmZMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByRef Mode As Short) As Integer
	Declare Function AioGetCntmZLogic Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByRef ZLogic As Short) As Integer
	Declare Function AioGetCntmChannelSignal Lib "CAIO.DLL" (ByVal Id As Short, ByVal CntmChNo As Short, ByRef CntmSigType As Short) As Integer
	Declare Function AioGetCntmCountDirection Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByRef Dir As Short) As Integer
	Declare Function AioGetCntmOperationMode Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByRef Phase As Short, ByRef Mul As Short, ByRef SyncClr As Short) As Integer
	Declare Function AioGetCntmDigitalFilter Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByRef FilterValue As Short) As Integer
	Declare Function AioGetCntmPulseWidth Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByRef PlsWidth As Short) As Integer

	' Counter function
    Declare Function AioCntmStartCount Lib "CAIO.DLL" (ByVal Id As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal ChNo() As Short, ByVal ChNum As Short) As Integer
    Declare Function AioCntmStopCount Lib "CAIO.DLL" (ByVal Id As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal ChNo() As Short, ByVal ChNum As Short) As Integer
    Declare Function AioCntmPreset Lib "CAIO.DLL" (ByVal Id As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal ChNo() As Short, ByVal ChNum As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal PresetData() As Integer) As Integer
    Declare Function AioCntmZeroClearCount Lib "CAIO.DLL" (ByVal Id As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal ChNo() As Short, ByVal ChNum As Short) As Integer
    Declare Function AioCntmReadCount Lib "CAIO.DLL" (ByVal Id As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal ChNo() As Short, ByVal ChNum As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal CntDat() As Integer) As Integer
    Declare Function AioCntmReadStatus Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByRef Sts As Short) As Integer
    Declare Function AioCntmReadStatusEx Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByRef Sts As Integer) As Integer

	' Notify function
	Declare Function AioCntmNotifyCountUp Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal RegNo As Short, ByVal Count As Integer, ByVal hWnd As Integer) As Integer
    Declare Function AioCntmStopNotifyCountUp Lib "CAIO.DLL" (ByVal Id As Short, ByVal ChNo As Short, ByVal RegNo As Short) As Integer
    Declare Function AioCntmCountUpCallbackProc Lib "CAIO.DLL" (ByVal Id As Short, ByVal pAioCntmCountUpCallBack As IntPtr, ByVal Param As IntPtr) As Integer
	Declare Function AioCntmNotifyCounterError Lib "CAIO.DLL" (ByVal Id As Short, ByVal hWnd As Integer) As Integer
    Declare Function AioCntmStopNotifyCounterError Lib "CAIO.DLL" (ByVal Id As Short) As Integer
    Declare Function AioCntmCounterErrorCallbackProc Lib "CAIO.DLL" (ByVal Id As Short, ByVal pAioCntmCounterErrorCallBack As IntPtr, ByVal Param As IntPtr) As Integer
	Declare Function AioCntmNotifyCarryBorrow Lib "CAIO.DLL" (ByVal Id As Short, ByVal hWnd As Integer) As Integer
    Declare Function AioCntmStopNotifyCarryBorrow Lib "CAIO.DLL" (ByVal Id As Short) As Integer
    Declare Function AioCntmCarryBorrowCallbackProc Lib "CAIO.DLL" (ByVal Id As Short, ByVal pAioCntmCarryBorrowCallBack As IntPtr, ByVal Param As IntPtr) As Integer
    Declare Function AioCntmNotifyTimer Lib "CAIO.DLL" (ByVal Id As Short, ByVal TimeValue As Integer, ByVal hWnd As Integer) As Integer
    Declare Function AioCntmStopNotifyTimer Lib "CAIO.DLL" (ByVal Id As Short) As Integer
    Declare Function AioCntmTimerCallbackProc Lib "CAIO.DLL" (ByVal Id As Short, ByVal pAioCntmTmCallBack As IntPtr, ByVal Param As IntPtr) As Integer
	
	' General purpose input function
	Declare Function AioCntmInputDIByte Lib "CAIO.DLL" (ByVal Id As Short, ByVal Reserved As Short, ByRef bData As Byte) As Integer
	Declare Function AioCntmOutputDOBit Lib "CAIO.DLL" (ByVal Id As Short, ByVal AiomChNo As Short, ByVal Reserved As Short, ByVal OutData As Byte) As Integer

End Module