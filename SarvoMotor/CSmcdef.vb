Option Strict Off
Option Explicit On 
Module CSMCDEF
	'*******************************************************
	'		API-SMC(WDM)
	'		FILE NAME		CSMCDEF.VB
	'********************************************************

	Public Const CSMC_PTP As Short = 1
	Public Const CSMC_JOG As Short = 2
	Public Const CSMC_ORG As Short = 3
	Public Const CSMC_SINGLE As Short = 4
	Public Const CSMC_LOOP As Short = 5
	Public Const CSMC_ZMOVE As Short = 6
	Public Const CSMC_PTP_EX As Short = 7
	Public Const CSMC_SINGLE_EX As Short = 8
	Public Const CSMC_LOOP_EX As Short = 9
	Public Const CSMC_PLSER As Short = 10

	Public Const CSMC_CW As Short = 0
	Public Const CSMC_CCW As Short = 1

	Public Const CSMC_ABS As Short = 0
	Public Const CSMC_INC As Short = 1

	Public Const CSMC_STOP As Short = 0
	Public Const CSMC_PASS As Short = 1

	Public Const CSMC_OUT1 As Short = 1
	Public Const CSMC_OUT2 As Short = 2
	Public Const CSMC_OUT3 As Short = 4

	Public Const CSMC_IN1 As Short = 1
	Public Const CSMC_IN2 As Short = 2
	Public Const CSMC_IN3 As Short = 4
	Public Const CSMC_IN4 As Short = 8
	Public Const CSMC_IN5 As Short = &H10S
	Public Const CSMC_IN6 As Short = &H20S
	Public Const CSMC_IN7 As Short = &H40S

	Public Const CSMC_HOLD As Short = 0
	Public Const CSMC_HOLDOFF As Short = 1

	Public Const CSMC_PLS_STOP As Short = 0
	Public Const CSMC_PLS_FLCONST As Short = 1
	Public Const CSMC_PLS_FHCONST As Short = 2
	Public Const CSMC_PLS_READY As Short = 3
	Public Const CSMC_PLS_ERCW As Short = 4
	Public Const CSMC_PLS_DTMW As Short = 5
	Public Const CSMC_PLS_ACCEL As Short = 6
	Public Const CSMC_PLS_DECEL As Short = 7
	Public Const CSMC_PLS_INPW As Short = 8
	Public Const CSMC_PLS_PAPBW As Short = 9

	Public Const CSMC_MOVE As Short = 0
	Public Const CSMC_STOP_COMMAND As Short = 1
	Public Const CSMC_SD_COMMAND As Short = 2
	Public Const CSMC_STOP_OTHER As Short = 3
	Public Const CSMC_STOP_ALARM As Short = 4
	Public Const CSMC_STOP_PLIM As Short = 5
	Public Const CSMC_STOP_MLIM As Short = 6
	Public Const CSMC_STOP_SD As Short = 7
	Public Const CSMC_ERROR_ORG As Short = 8
	Public Const CSMC_ERROR_PULSER As Short = 9
	Public Const CSMC_STOP_NORMAL As Short = &HFFS

	Public Const CSMC_MESSAGE As Integer = &H8700

	Public Const CSMC_DISABLE As Short = 0
	Public Const CSMC_ENABLE As Short = 1

	Public Const CSMC_OUTPULSE As Short = 0
	Public Const CSMC_ENCODER As Short = 1

	Public Const CSMC_LTC As Short = 0

	Public Const CSMC_TRGERR As Short = 0
	Public Const CSMC_TRGSTATUS As Short = 1
	
	Public Const CSMC_TIMER As Short = 1

	Public Const CSMC_ALM As Short = 1
	Public Const CSMC_PLIM As Short = 2
	Public Const CSMC_MLIM As Short = 4
	Public Const CSMC_ORGLIM As Short = 8
	Public Const CSMC_SD As Short = &H10S

	Public Const CSMC_2PULSE As Short = 0
	Public Const CSMC_1PULSE As Short = 1

	Public Const CSMC_AB As Short = 0
	Public Const CSMC_UD As Short = 1

	Public Const CSMC_HOFF As Short = 1
	Public Const CSMC_ALMCLR As Short = 2
	Public Const CSMC_CNTCLR As Short = 4

	Public Const CSMC_DISTANCE As Short = 0
	Public Const CSMC_ANGLE As Short = 1

	Public Const CSMC_ALLTIME As Short = 0
	Public Const CSMC_LIM As Short = 1

	Public Const CSMC_CTRL_PCS As Short = 1
	Public Const CSMC_CTRL_ERC As Short = 2
	Public Const CSMC_CTRL_EZ As Short = 4
	Public Const CSMC_CTRL_CLR As Short = 8
	Public Const CSMC_CTRL_LTC As Short = &H10S
	Public Const CSMC_CTRL_SD As Short = &H20S
	Public Const CSMC_CTRL_INP As Short = &H40S
	Public Const CSMC_CTRL_DIRCCW As Short = &H80S
	
	Public Const CSMC_PULSER_PTP As Short = 1
	Public Const CSMC_PULSER_JOG As Short = 2
	
	Public Const CSMC_PULSER_HOME_PULSE As Short = 4
	Public Const CSMC_PULSER_HOME_ORG As Short = 5
	Public Const CSMC_PULSER_INTER_LINE As Short = 6
	Public Const CSMC_PULSER_INTER_ARC As Short = 7
End Module