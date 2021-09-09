Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices
Imports System.Text

Module CSMC
	'*******************************************************
	'		API-SMC(WDM)
	'		FILE NAME		CSMC.VB
	'********************************************************
	'-----------------------------
	' API-SMC(WDM) Function List
	'-----------------------------

	'---------------------------------------
	' Initial Parameters Setting Functions
	'---------------------------------------
	Declare Function SmcWSetPulseType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal PulseType As Short, ByVal DirTimer As Short) As Integer
	Declare Function SmcWGetPulseType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef PulseType As Short, ByRef DirTimer As Short) As Integer
	Declare Function SmcWSetPulseDuty Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal Duty As Short) As Integer
	Declare Function SmcWGetPulseDuty Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef Duty As Short) As Integer
	Declare Function SmcWSetEncType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal EncType As Short) As Integer
	Declare Function SmcWGetEncType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef EncType As Short) As Integer
	Declare Function SmcWSetCtrlTypeOut Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal OutType1 As Short, ByVal OutType2 As Short, ByVal OutType3 As Short) As Integer
	Declare Function SmcWGetCtrlTypeOut Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef CtrlOut1 As Short, ByRef CtrlOut2 As Short, ByRef CtrlOut3 As Short) As Integer
	Declare Function SmcWSetCtrlTypeIn Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal CtrlIn As Short) As Integer
	Declare Function SmcWGetCtrlTypeIn Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef CtrlIn As Short) As Integer
	Declare Function SmcWSetOrgLog Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal OrgLog As Short) As Integer
	Declare Function SmcWGetOrgLog Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef OrgLog As Short) As Integer
	Declare Function SmcWSetCtrlInOutLog Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal CtrlInOutLog As Short) As Integer
	Declare Function SmcWGetCtrlInOutLog Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef CtrlInOutLog As Short) As Integer
	Declare Function SmcWSetErcMode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal ErcMode As Short) As Integer
	Declare Function SmcWGetErcMode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef ErcMode As Short) As Integer
	Declare Function SmcWSetErcAlmClearTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal ErcTime As Short, ByVal ErcOffTimer As Short, ByVal AlmTime As Short) As Integer
	Declare Function SmcWGetErcAlmClearTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef ErcTime As Short, ByRef ErcOffTimer As Short, ByRef AlmTime As Short) As Integer
	Declare Function SmcWSetOrgMode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal LimitTurn As Short, ByVal OrgType As Short, ByVal EndDir As Short, ByVal ZCount As Short) As Integer
	Declare Function SmcWGetOrgMode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef LimitTurn As Short, ByRef OrgType As Short, ByRef EndDir As Short, ByRef ZCount As Short) As Integer
	Declare Function SmcWSetSAccelType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal SAccelType As Short) As Integer
	Declare Function SmcWGetSAccelType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef SAccelType As Short) As Integer
	Declare Function SmcWSetInFilterType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal FilterType As Short) As Integer
	Declare Function SmcWGetInFilterType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef FilterType As Short) As Integer
	Declare Function SmcWSetSDMode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal SDMode As Short) As Integer
	Declare Function SmcWGetSDMode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef SDMode As Short) As Integer
	Declare Function SmcWSetCounterMode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal ClearCntLtc As Short, ByVal LtcMode As Short, ByVal ClearCntClr As Short, ByVal ClrMode As Short) As Integer
	Declare Function SmcWGetCounterMode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef ClearCntLtc As Short, ByRef LtcMode As Short, ByRef ClearCntClr As Short, ByRef ClrMode As Short) As Integer
	Declare Function SmcWSetSoftLimit Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal PLimMode As Short, ByVal MLimMode As Short, ByVal PLimCount As Integer, ByVal MLimCount As Integer) As Integer
	Declare Function SmcWGetSoftLimit Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef PLimMode As Short, ByRef MLimMode As Short, ByRef PLimCount As Integer, ByRef MLimCount As Integer) As Integer
	Declare Function SmcWSetInitParam Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer
	Declare Function SmcWGetInitParam Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef InitParam As Short) As Integer

	'------------------------------------
	' Basic Operation Setting Functions
	'------------------------------------
	Declare Function SmcWSetReady Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal bMotionType As Short, ByVal bStartDir As Short) As Integer
	Declare Function SmcWGetReady Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef bMotionType As Short, ByRef bStartDir As Short) As Integer
	Declare Function SmcWSetStartSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal dblStartSpeed As Double) As Integer
	Declare Function SmcWGetStartSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef dblStartSpeed As Double) As Integer
	Declare Function SmcWSetTargetSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal dblTargetSpeed As Double) As Integer
	Declare Function SmcWGetTargetSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef dblTargetSpeed As Double) As Integer
	Declare Function SmcWSetAccelTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal dblAccelTime As Double) As Integer
	Declare Function SmcWGetAccelTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef dblAccelTime As Double) As Integer
	Declare Function SmcWSetDecelTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal dblDecelTime As Double) As Integer
	Declare Function SmcWGetDecelTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef dblDecelTime As Double) As Integer
	Declare Function SmcWSetSSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal dblSSpeed As Double) As Integer
	Declare Function SmcWGetSSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef dblSSpeed As Double) As Integer
	Declare Function SmcWSetStopPosition Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal bCoordinate As Short, ByVal lStopPosition As Integer) As Integer
	Declare Function SmcWGetStopPosition Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal bCoordinate As Short, ByRef lStopPosition As Integer) As Integer
	Declare Function SmcWSetResolveSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal dblResolveSpeed As Double) As Integer
	Declare Function SmcWGetResolveSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef dblResolveSpeed As Double) As Integer
	Declare Function SmcWSetSync Lib "CSmc.DLL" (ByVal Id As Short, ByVal bSyncAxis As Short, ByVal bSyncChip As Short, ByVal bSyncBoard As Short) As Integer
	Declare Function SmcWGetSync Lib "CSmc.DLL" (ByVal Id As Short, ByRef bSyncAxis As Short, ByRef bSyncChip As Short, ByRef bSyncBoard As Short) As Integer
	Declare Function SmcWSetZCountMotion Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal ZMoveCount As Short, ByVal ZLog As Short) As Integer
	Declare Function SmcWGetZCountMotion Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef ZMoveCount As Short, ByRef ZLog As Short) As Integer

	'----------------------------------------
	'  Extended Operation Setting Functions
	'----------------------------------------
	Declare Function SmcWSetBankNumber Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNum As Short) As Integer
	Declare Function SmcWGetBankNumber Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef BankNum As Short) As Integer
	Declare Function SmcWSetBankReady Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal MotionType As Short) As Integer
	Declare Function SmcWGetBankReady Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef MotionType As Short) As Integer
	Declare Function SmcWSetBankDistance Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal lStopPosition As Integer) As Integer
	Declare Function SmcWGetBankDistance Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef lStopPosition As Integer) As Integer
	Declare Function SmcWSetBankResolveSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal dblResolveSpeed As Double) As Integer
	Declare Function SmcWGetBankResolveSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef dblResolveSpeed As Double) As Integer
	Declare Function SmcWSetBankStartSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal dblStartSpeed As Double) As Integer
	Declare Function SmcWGetBankStartSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef dblStartSpeed As Double) As Integer
	Declare Function SmcWSetBankTargetSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal dblTargetSpeed As Double) As Integer
	Declare Function SmcWGetBankTargetSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef dblTargetSpeed As Double) As Integer
	Declare Function SmcWSetBankAccelTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal dblAccelTime As Double) As Integer
	Declare Function SmcWGetBankAccelTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef dblAccelTime As Double) As Integer
	Declare Function SmcWSetBankDecelTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal dblDecelTime As Double) As Integer
	Declare Function SmcWGetBankDecelTime Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef dblDecelTime As Double) As Integer
	Declare Function SmcWSetBankSSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal dblSSpeed As Double) As Integer
	Declare Function SmcWGetBankSSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef dblSSpeed As Double) As Integer
	Declare Function SmcWSetBankInterpolation Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal InterType As Short, ByVal InterAxis As Short, ByVal Reserved As Short) As Integer
	Declare Function SmcWGetBankInterpolation Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef InterType As Short, ByRef InterAxis As Short, ByRef Reserved As Short) As Integer
	Declare Function SmcWSetBankArcPoint Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal ArcSpeed As Double, ByVal Center_X As Integer, ByVal Center_Y As Integer, ByVal End_X As Integer, ByVal End_Y As Integer) As Integer
	Declare Function SmcWGetBankArcPoint Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef ArcSpeed As Double, ByRef lCenter_X As Integer, ByRef Center_Y As Integer, ByRef End_X As Integer, ByRef End_Y As Integer) As Integer
	Declare Function SmcWSetBankArcParam Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal ArcStrtDir As Short, ByVal AutoEndPointPull As Short) As Integer
	Declare Function SmcWGetBankArcParam Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef ArcStartDir As Short, ByRef AutoEndPointPull As Short) As Integer
	Declare Function SmcWSetBankContinuation Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByVal ContType As Short) As Integer
	Declare Function SmcWGetBankContinuation Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal BankNo As Short, ByRef ContType As Short) As Integer

	'-----------------------------------
	' Control Signal Setting Functions
	'-----------------------------------
	Declare Function SmcWSetAlarmClear Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer
	Declare Function SmcWSetErcOut Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal ErcOn As Short) As Integer
	Declare Function SmcWSetDigitalOut Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal OutData As Short, ByVal OutDataEndble As Short) As Integer
	Declare Function SmcWGetDigitalOut Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef OutData As Short) As Integer
	Declare Function SmcWSetLimitMask Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal LimMask As Short, ByVal LimMaskEnable As Short) As Integer
	Declare Function SmcWGetLimitMask Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef LimMask As Short) As Integer
	Declare Function SmcWGetDigitalIn Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef InData As Short) As Integer
	Declare Function SmcWSetHoldOff Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal HoldOff As Short) As Integer
	Declare Function SmcWGetHoldOff Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef HoldOff As Short) As Integer
	Declare Function SmcWGetAlarmCode Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef AlarmCode As Short) As Integer

	'--------------------------------------
	' Operation Status Read/Write Functions
	'--------------------------------------
	Declare Function SmcWGetOutPulse Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef lOutPulse As Integer) As Integer
	Declare Function SmcWSetOutPulse Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal lOutPulse As Integer) As Integer
	Declare Function SmcWGetCountPulse Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef lCountPulse As Integer) As Integer
	Declare Function SmcWSetCountPulse Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal lCountPulse As Integer) As Integer
	Declare Function SmcWGetPulseStatus Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef bPulseSts As Short) As Integer
	Declare Function SmcWGetMoveStatus Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef bMoveSts As Short) As Integer
	Declare Function SmcWGetStopStatus Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef bStopSts As Short) As Integer
	Declare Function SmcWGetLimitStatus Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef bLimitSts As Short) As Integer
	Declare Function SmcWGetLatchOutPulse Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef lOutPulse As Integer) As Integer
	Declare Function SmcWGetLatchCountPulse Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef lCountPulse As Integer) As Integer
	Declare Function SmcWGetBankNo Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef wBankNo As Short) As Integer
	Declare Function SmcWGetMoveSpeed Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef dblMoveSpeed As Double) As Integer
	Declare Function SmcWGetZCount Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef bMoveZCount As Short) As Integer
	Declare Function SmcWGetCtrlInOutStatus Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef bCtrlSts As Short) As Integer

	'---------------------------
	' Initialization Functions
	'---------------------------
	Declare Function SmcWInit Lib "CSmc.DLL" (ByVal DeviceName As String, ByRef Id As Short) As Integer
	Declare Function SmcWExit Lib "CSmc.DLL" (ByVal Id As Short) As Integer
	Declare Function SmcWGetErrorString Lib "CSmc.DLL" (ByVal ErrorCode As Integer, ByVal ErrorString As StringBuilder) As Integer
	Declare Function SmcWQueryDeviceName Lib "CSmc.DLL" (ByVal Index As Short, ByVal DeviceName As String, ByVal Device As String) As Integer

	'----------------------------
	' Motor Operation Functions
	'----------------------------
	Declare Function SmcWMotionStart Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer
	Declare Function SmcWMotionStop Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer
	Declare Function SmcWMotionDecStop Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer
	Declare Function SmcWMotionChange Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer
	Declare Function SmcWSetMotionChangeReady Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal Change As Short) As Integer
	Declare Function SmcWGetMotionChangeReady Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef Change As Short) As Integer
	Declare Function SmcWSyncMotionStart Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer

	'------------------
	' Event Functions
	'------------------
	Declare Function SmcWStopEvent Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal hWnd As Integer, ByVal bEventMode As Short) As Integer
	Declare Function SmcWBankEvent Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal hWnd As Integer, ByVal bEventMode As Short, ByVal BankNo As Short) As Integer
	Declare Function SmcWCountEvent Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal hWnd As Integer, ByVal bEventMode As Short, ByVal bCountType As Short, ByVal lCount As Integer) As Integer
	Declare Function SmcWIrqEvent Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal hWnd As Integer, ByVal bEventMode As Short, ByVal bEventType As Short) As Integer

	'------------------
	' FIFOLatch Functions
	'------------------
	Declare Function SmcWResetLatchFIFO Lib "CSmc.DLL" (ByVal Id As Short) As Integer
	Declare Function SmcWSetFIFOLatchSrc Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal LatchAxisNo As Short, ByVal Enable As Short) As Integer
	Declare Function SmcWGetFIFOLatchSrc Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef LatchAxisNo As Short, ByRef Enable As Short) As Integer
	Declare Function SmcWGetLatchDataFromBuffer Lib "CSmc.DLL" (ByVal Id As Short, ByVal BufferNo As Short, ByRef AxisCounterNo As Short, ByRef LatchDataCnt As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal LatchDataTable() As Integer) As Integer
	Declare Function SmcWGetLatchFIFOLength Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef length As Short) As Integer
	Declare Function SmcWGetLatchDataFromBufferEx Lib "CSmc.DLL" (ByVal Id As Short, ByVal BufferNo As Short, ByRef AxisCounterNo As Short, ByRef LatchDataCnt As Short, <MarshalAs(UnmanagedType.LPArray)> ByVal LatchDataTable() As Integer, ByRef UpCnt As Short, ByRef DownCnt As Short) As Integer
	Declare Function SmcWResetAxisLatchFIFO Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisBitNo As Short, ByVal Reserved As Short ) As Integer
	Declare Function SmcWResetFIFOLatchSrc Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short ) As Integer

	'------------------
	' TriggerOut Functions
	'------------------
	Declare Function SmcWSetTrgOutCPWidth Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal Width As Short ) As Integer
	Declare Function SmcWGetTrgOutCPWidth Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef Width As Short ) As Integer
	Declare Function SmcWSetTrgOutCPDelay Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal DelayTime As Short ) As Integer
	Declare Function SmcWGetTrgOutCPDelay Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef DelayTime As Short ) As Integer
	Declare Function SmcWSetTrgOutData Lib "CSmc.DLL" (ByVal Id As Short, ByVal FifoNo As Short, ByVal CntType As Short, ByVal OutAxisEnable As Short, ByVal FifoData As Integer) As Integer
    Declare Function SmcWTrgOutEvent Lib "CSmc.DLL" (ByVal Id As Short, ByVal hWnd As Integer, ByVal bEventMode As Short, ByVal bEventType As Short) As Integer
	Declare Function SmcWGetTrgOutStatus Lib "CSmc.DLL" (ByVal Id As Short, ByRef TrgOutSts As Short, ByRef TrgOutErrSts As Short) As Integer
	Declare Function SmcWResetTrgOutStatus Lib "CSmc.DLL" (ByVal Id As Short, ByVal EnableStsReset As Short, ByVal EnableErrStsReset As Short, ByRef TrgOutSts As Short, ByRef TrgOutErrSts As Short) As Integer
	Declare Function SmcWGetTrgOutDataRemainNum Lib "CSmc.DLL" (ByVal Id As Short, ByVal FifoNo As Short, ByRef DataNum As Integer) As Integer
	Declare Function SmcWResetTrgOutFIFO Lib "CSmc.DLL" (ByVal Id As Short, ByVal FifoBitNo As Short) As Integer
	Declare Function SmcWSetTrgOutStart Lib "CSmc.DLL" (ByVal Id As Short) As Integer
	Declare Function SmcWSetTrgOutStop Lib "CSmc.DLL" (ByVal Id As Short) As Integer
	Declare Function SmcWSetTrgOutAxis Lib "CSmc.DLL" (ByVal Id As Short, ByVal FifoNo As Short, ByVal CmpAxis As Short, ByVal OutAxis As Short) As Integer
	Declare Function SmcWGetTrgOutAxis Lib "CSmc.DLL" (ByVal Id As Short, ByVal FifoNo As Short, ByRef CmpAxis As Short, ByRef OutAxis As Short) As Integer
	Declare Function SmcWResetTrgOutAxis Lib "CSmc.DLL" (ByVal Id As Short, ByVal FifoBitNo As Short) As Integer

	'------------------
	' Manual Pulser Functions
	'------------------
	Declare Function SmcWSetPulserType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal InputType As Short, ByVal PulserDir As Short) As Integer
	Declare Function SmcWGetPulserType Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef InputType As Short, ByRef PulserDir As Short) As Integer
	Declare Function SmcWSetPulserParam Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal SpeedLimit As Double, ByVal Distance As Integer) As Integer
	Declare Function SmcWGetPulserParam Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef SpeedLimit As Double, ByRef Distance As Integer) As Integer
	Declare Function SmcWSetPulserRatio Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal Magnification As Short, ByVal Division As Short) As Integer
	Declare Function SmcWGetPulserRatio Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef Magnification As Short, ByRef Division As Short) As Integer
	Declare Function SmcWSetPulserReady Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal PulserMode As Short) As Integer
	Declare Function SmcWGetPulserReady Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef PulserMode As Short) As Integer
	Declare Function SmcWStartPulser Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer
	Declare Function SmcWStopPulser Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short) As Integer
	Declare Function SmcWSetPulserLine Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal InterAxis As Short) As Integer
	Declare Function SmcWGetPulserLine Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef InterAxis As Short) As Integer
	Declare Function SmcWSetPulserArc Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByVal InterAxis As Short, ByVal Center_X As Integer, ByVal Center_Y As Integer, ByVal End_X As Integer, ByVal End_Y As Integer, ByVal ArcSpeedLimit As Double, ByVal ArcStrtDir As Short) As Integer
	Declare Function SmcWGetPulserArc Lib "CSmc.DLL" (ByVal Id As Short, ByVal AxisNo As Short, ByRef InterAxis As Short, ByRef Center_X As Integer, ByRef Center_Y As Integer, ByRef End_X As Integer, ByRef End_Y As Integer, ByRef ArcSpeedLimit As Double, ByRef ArcStrtDir As Short) As Integer

	Declare Function LpByte Lib "VBAdd32.dll" (ByRef bparam As Byte) As Integer
	Declare Function LpWord Lib "VBAdd32.dll" (ByRef wparam As Short) As Integer
	Declare Function LpDWord Lib "VBAdd32.dll" (ByRef dwparam As Integer) As Integer
	Declare Function LpStr Lib "VBAdd32.dll" (ByVal szparam As String) As Integer
End Module