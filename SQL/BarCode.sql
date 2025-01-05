
--����������
IF OBJECT_ID('QYD_BCP_LotMaster') IS NOT NULL
DROP TABLE QYD_BCP_LotMaster
GO

CREATE TABLE QYD_BCP_LotMaster(
	ID BIGINT NOT NULL UNIQUE, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	ItemMaster BIGINT,--��ƷID
	LotCode VARCHAR(100),--����
	Org BIGINT,--��֯ID
	EffectiveDate DATETIME,--��Ч����
	ValidDate int,--��Ч����
	InvalidDate DATETIME,--��Ч����
	SrcDocNo VARCHAR(50),--������
	AutoCode int,--�Ƿ��Զ�����
	Remark VARCHAR(500),--��ע
	--�޸���
	[ModifiedBy] VARCHAR(50),
	--�޸�ʱ��
	[ModifiedTime] datetime,
	PRIMARY KEY([ID])
)
GO

--���ι����
IF OBJECT_ID('QYD_BC_LotRule') IS NOT NULL
DROP TABLE QYD_BC_LotRule
GO

CREATE TABLE QYD_BC_LotRule(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	RuleCode VARCHAR(100),--�������
	RuleName VARCHAR(100),--��������
	Org BIGINT,--��֯ID
	RuleDes VARCHAR(500),--������
	Memo VARCHAR(500)--��ע
)
GO


--���ι�����ϸ��
IF OBJECT_ID('QYD_BC_LotRuleLine') IS NOT NULL
DROP TABLE QYD_BC_LotRuleLine
GO

CREATE TABLE QYD_BC_LotRuleLine(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	LotRule BIGINT,--���ι���ID
	DsType int,--����Դ����
	DtFormat int,--����Դ����
	FillInCode VARCHAR(50),--��λ��
	SplitCode VARCHAR(50),--�ָ���
	IsFlow BIT,--�Ƿ���ˮ����
	Memo VARCHAR(500)--����Դ����
)
GO
