Option Strict Off
Option Explicit On 
Module [Global]

	Public Ret As Integer       ' �֐��̖߂�l�i0�ȊO�̓G���[)
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

End Module