Option Strict Off
Option Explicit On 
Module [Global]

	Public Ret As Integer       ' �֐��̖߂�l�i0�ȊO�̓G���[)
	Public Ret2 As Integer
	Public Id As Short          ' �{�[�h�̔ԍ��@"SMC000"�̏ꍇ��0
	Public AxisNo As Short      ' 1 ���ԍ�
	Public device As String

	Public PulseType As Short   ' 4 (2�p���X���� �F���_��)
	'								0:���ʃp���X���� OUT �F  ���_���CDIR+�FHigh�CDIR-�FLow
	'								1:���ʃp���X���� OUT �F  ���_���CDIR+�FHigh�CDIR-�FLow
	'								2:���ʃp���X���� OUT �F  ���_���CDIR+�FLow�CDIR-�FHigh 
	'								3:���ʃp���X���� OUT �F  ���_���CDIR+�FLow�CDIR-�FHigh
	'								4:2�p���X���� �F���_�� 
	'								5:2�p���X���� �F���_��
	'								6:90�x�ʑ������[�h OUT�F�i�ݐM��. DIR�F�x��M�� 
	'								7:90�x�ʑ������[�h OUT�F�x��M��. DIR�F�i�ݐM��


	Public DirTimer As Short    ' 1 (�E�G�C�g�}��ON)
	'���ʃp���X�����ݒ莞�ADIR�ω��̕ω��ɂ���ĕ������ω�����ۂ�200[��sec]�̃E�F�C�g(�x��)���p���X�o�͑O�ɑ}�����܂��B�i���ʃp���X�����̏ꍇ�̂ݗL���j


	Public EncType As Short     ' 0 (�G���R�[�_�̓��͕����FA/B (90�x�ʑ���) 1���{)
	'								0:A/B (90�x�ʑ���) 1���{
	'								1:A/B (90�x�ʑ���) 2���{
	'								2:A/B (90�x�ʑ���) 4���{
	'								3:U/D��2�p���X����
	'								4:�g�p���Ȃ�

	Public CtrlOut1 As Short    ' 0 (����o��OUT1:�ėp�o��)
	Public CtrlOut2 As Short    ' 1 (����o��OUT2:�A���[���N���A�M��)
	Public CtrlOut3 As Short    ' 2 (����o��OUT3:�΍��J�E���^�N���A�M���iERC�j)
	'								0:�ėp�o��
	'								1:�A���[���N���A�M��
	'								2:�΍��J�E���^�N���A�M���iERC�j
	'								3:�o�̓p���X�J�E���^�J�E���g��v�M���iCP1�j
	'								4:�G���R�[�_�J�E���^�J�E���g��v�M���iCP2�j
	'								5:�z�[���h�I�t�M��

	Public CtrlIn As Short      ' 3 (00000011) (������͐M���`����ݒ�)([ 0 | 0 | IN6/CLR | IN5/PCS | IN4/LTC | IN3/SD | IN2/INP | IN1/ALM ]
	'								IN1/ALM=0
	'									0: IN1(�ėp����)�Ƃ��Ďg�p
	'									1: �A���[��(ALM)�M�����͂Ƃ��Ďg�p

	'								IN2/INP=1
	'									0: IN2(�ėp����)�Ƃ��Ďg�p
	'									1: �T�[�{�h���C�o�̈ʒu���ߊ���(INP)�M�����͂Ƃ��Ďg�p

	'								IN3/SD=0
	'									0: IN3(�ėp����)�Ƃ��Ďg�p
	'									1: ����(������~)(SD)�M�����͂Ƃ��Ďg�p

	'								IN4/LTC=1
	'									0: IN4(�ėp����)�Ƃ��Ďg�p
	'									1:LTC�M�����͂Ƃ��Ďg�p
	'									�@ �o�̓p���X/�G���R�[�_�J�E���^�̒l�����b�`���܂��B

	'								IN5/PCS=1
	'									0: IN5(�ėp����)�Ƃ��Ďg�p
	'									1: PCS�M�����͂Ƃ��Ďg�p
	'									�@�@���̐M�����͂ňʒu���ߓ�����J�n���܂��B(�ڕW�ʒu�̃I�[�o�[���C�h2�p)

	'								IN6/CLR=0
	'									0: IN6(�ėp����)�Ƃ��Ďg�p
	'									1: CLR�M�����͂Ƃ��Ďg�p
	'									�@�@�o�̓p���X/�G���R�[�_�J�E���^�̒l�����Z�b�g���܂��B
	'									�@�@�iSMC-2/4/8DL �V���[�Y�ł�IN6�Œ�BCLR�M���ݒ�s�j

	Public OrgLog As Short      ' 0 (���_���͘_��)

	Public CtrlInOutLog As Short    ' &H83 (����o�͐M���_����ݒ�) [ 0 | 0 | 0 | 0 | 0 | OUT3 | OUT2 | OUT1| LIM | IN7 | IN6 | IN5 | IN4 | IN3 | IN2 | IN1 ]�@�ݒ�͈́F0�`7FF(Hex)
	'									LIM�ȊO�͕��_��

	Public ErcMode As Short         ' 0 (ERC�M�������o�͂̐ݒ�)[ 0 | 0 | 0 | 0 | 0 | 0 | bit1 | bit0 ]�@�ݒ�͈́F0�`3(Hex)
	'									bit0
	'									0: LIM�AALM�M�����͂ɂ���~����ERC�M�����o�͂��Ȃ�
	'									1: LIM�AALM�M�����͂ɂ���~����ERC�M���������o��
	'									bit1
	'									0: ���_���A���슮������ERC�M�����o�͂��Ȃ�
	'									1: ���_���A���슮������ERC�M���������o��

	Public ErcTime As Short         ' 0 (�΍��J�E���^�N���A�M����)
	'									0:12[��sec]
	'									1:102[��sec]
	'									2:408[��sec]
	'									3:1.6[msec]
	'									4:13[msec]
	'									5:52[msec]
	'									6:104[msec]
	'									7:���x���o��

	Public ErcOffTimer As Short     ' 0 (�΍��J�E���^�N���A�M��OFF�^�C�}����)
	'									0:0[��sec]
	'									1: 12[��sec]
	'									2:1.6[msec]
	'									3:104[msec]

	Public AlmTime As Short         ' 0 (�A���[���N���A�M����)
	'									0:12[��sec]
	'									1:102[��sec]
	'									2:408[��sec]
	'									3:1.6[msec]
	'									4:13[msec]
	'									5:52[msec]
	'									6:104[msec]

	Public LimitTurn As Short       ' 1 (���_���A���쒆��+LIM/-LIM���~�b�g���]�̗L����ݒ�)
	'									0:LIM�M�����]����
	'									1:LIM�M�����]�L��
	'									2:LIM�M��ON���_���A�J�n�\
	'									3:LIM�M�����͌��_���A

	Public OrgType As Short         ' 0 (Z���̎g�p�L����ݒ�)
	'									0:�g�p���Ȃ��iORG�̂݁j
	'									1:�g�p����iORG + Z���j

	Public EndDir As Short          ' 0 (���_���A���̌��_�˓����� (���_���A�I������) ��ݒ�)
	'									0:���w��
	'									1:������ (CW)
	'									2:������ (CCW)

	Public ZCount As Short          ' 0 (���_���A����Z���̐���ݒ肵�܂��B�i�ݒ�͈́@1�`16�j)

	Public SAccelType As Short      ' 0 (S���������̎g�p/���g�p��ݒ�)
	'									0:�g�p���Ȃ�
	'									1:�g�p����

	Public FilterType As Short      ' 0 (���̓t�B���^������ݒ�)
	'									0:�t�B���^��}�����Ȃ�
	'									1: 3.2[��sec]
	'									2:25[��sec]
	'									3:200[��sec]
	'									4:1.6[msec]

	Public SDMode As Short          ' 0 (SD�M�����͎��̓���)
	'									0:������~���܂��B��������SD�M����OFF�ɂȂ�ƖڕW���x�ɉ������܂��B
	'									1:�������܂��B������A�܂��͌�������SD�M����OFF�ɂȂ�ƖڕW���x�ɉ������܂��B
	'									2:������~���܂��B��������SD�M����OFF�ɂȂ��Ă��������܂���B
	'									3:�������܂��B������A�܂��͌�������SD�M����OFF�ɂȂ��Ă��J�n���x���ێ����܂��B

	Public ClearCntLtc As Short     ' 0 (LTC�M����OFF��ON�֕ω��������ɃN���A����J�E���^�̎�ނ�ݒ�)
	'									0:�J�E���^���N���A���Ȃ�
	'									1:�o�̓p���X�J�E���^���N���A
	'									2:�G���R�[�_�J�E���^���N���A
	'									3:�o�̓p���X�J�E���^����уG���R�[�_�J�E���^���N���A

	Public LtcMode As Short         ' 0 (LTC�M�����͎��Ƀ��b�`����J�E���^�̎�ނ�ݒ�)
	'									0:���b�`�@�\���g�p���Ȃ�
	'									1:�o�̓p���X�J�E���^�����b�`
	'									2:�G���R�[�_�J�E���^�����b�`
	'									3:�o�̓p���X�J�E���^����уG���R�[�_�J�E���^�����b�`

	Public ClearCntClr As Short     ' 0 (CLR�M����OFF��ON�֕ω��������ɃN���A����J�E���^�̎�ނ�ݒ�)
	'									0:�J�E���^���N���A���Ȃ�
	'									1:�o�̓p���X�J�E���^���N���A
	'									2:�G���R�[�_�J�E���^���N���A
	'									3:�o�̓p���X�J�E���^����уG���R�[�_�J�E���^���N���A

	Public ClrMode As Short         ' 0 �Œ� (�\��)

	Public InitParam As Short       ' SmcWSetInitParam�֐����s�̗L�����i�[����ϐ�
	'									0:�����s
	'									1:���s��

	Public CC As Double             ' �p���X��mm�ɕϊ�����W��

	Public PlusSpeed As Integer     ' �p���X�X�s�[�h
	Public PistonSpeed As Double    ' �s�X�g���̃X�s�[�h(mm/sec)
	Public MotionType As Short      ' ���[�^����^�C�v�i0:����Ȃ�,1:PTP����,2:JOG����,3:���_���A����)
	Public StartDir As Short        ' ���[�^����J�n�����i0:CW,1:CCW)
	Public StartSpeed As Double     ' �X�^�[�g�����x
	Public TargetSpeed As Double    ' �ڕW���x
	Public AccelTime As Double      ' ��������
	Public DecelTime As Double      ' ��������
	Public ResolveSpeed As Double   ' ���x����\
	Public StopPosition As Integer  ' ��~�ʒu

	Public lOutPulse As Integer     ' �{�[�h����o�͂����p���X��
	Public lOutDisp As Double       ' ���s�X�g���ψ� (lOutPulse * CC)
	Public lCountPulse As Integer   ' �G���R�[�_�����o�����p���X��
	Public lCountDisp As Double     ' ���s�X�g���ψ� (lCountDisp * CC)
	Public lDistance As Integer     ' ��΂܂��͑��ΖڕW�p���X��
	Public lDistanceDisp As Double  ' ���s�X�g���ψ� (lDistanceDisp * CC)
	Public bCoordinate As Short     ' ���΃p���X�܂��͐�΃p���X�̎w�W�i1:���΁A0:��΁j
	Public bStopSts1 As Short       ' ��~�����̎w�W�i0:���쒆�A1:��~�R�}���h�ɂ���~�A255;�ڕW�l���B�ɂ��ʏ��~)
	Public NextFlag As Boolean
	Public Arrive As Boolean

	Public InitialPulse As Integer  ' �����J�n���̐�΃p���X���i�C�j�V�����l�j
	Public InitialDisp As Double    ' ���s�X�g���ψ� (InitialPulse * CC)

	Public TestMode As Integer      ' 0:�����E�Еt���@1:�������[�h
	Public Const xSize1 As Integer = 570    ' �������̑���p�l���̕�
	Public Const ySize1 As Integer = 360    ' �������̑���p�l���̍���
	Public Const xSize2 As Integer = 1080   ' �������̑���p�l���̕�
	Public Const ySize2 As Integer = 720    ' �������̑���p�l���̍���

	Public SpeedPanel1 As SpeedPanel                   ' �s�X�g���X�s�[�h�I���p�l���R���g���[��

	Public RowsIndex1 As Integer    ' ���̓X�P�W���[���\�̌��݂̍s

	Public PointN As Integer        ' ���͏㉺���ڕW�l�̐�
	Public PointN2 As Integer       ' �������ꂽ���͖ڕW�l�̐�
	Public PointI As Integer        ' ���݂̉��͏㉺���l�̔ԍ�
	Public PointI2 As Integer       ' ���݂̕������ꂽ���͖ڕW�l�̔ԍ�
	Public LoadPoint() As Double    ' ���͏㉺���ڕW�l
	Public LoadPoint2() As Double   ' �������ꂽ���͖ڕW�l
	Public LoadX() As Double        ' �������ꂽ���͖ڕW�l��X���W
	Public Delta1 As Double         ' �����̑����l
	Public Chart As LoadScedule     ' ���̓X�P�W���[���̕\
	Public LoadGraph1 As LoadGraph  ' ���̓X�P�W���[���̃O���t
	Public TestStartFlag As Boolean ' �������t���O�iTrue:�������j
	Public SControlNo As Integer    ' ����ԍ�(0:�ψʐ���A1:�׏d����)
	Public Kataburi As Boolean      ' �АU��t���O(True:�АU��AFalse:���U��)

	Public Const Strokelimit = 151.18   ' �s�X�g���̃v���X�����~�b�g�ψ�

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