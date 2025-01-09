

--��������
IF OBJECT_ID('QYD_SCM_MO') IS NOT NULL
DROP TABLE QYD_SCM_MO
GO

CREATE TABLE QYD_SCM_MO(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	Org BIGINT,--��֯ID
	DocType VARCHAR(100),--��������
	DocNo VARCHAR(100),--����
	StartDate DATETIME,--�ƻ�������
	BusinessDate DATETIME,--��������
	MoDept BIGINT,--��������
	BusinessPerson BIGINT,--ҵ��Ա
	CompleteDate DATETIME,--�ƻ��깤��
	CompleteWh BIGINT,--�깤�ֿ�
	ModifiedTime DATETIME,--�޸�����
	ModifiedBy VARCHAR(50),--�޸���
	[Status] int,--����״̬
	Memo VARCHAR(500)--��ע
)
GO


--����������ϸ��
IF OBJECT_ID('QYD_SCM_MOLine') IS NOT NULL
DROP TABLE QYD_SCM_MOLine
GO

CREATE TABLE QYD_SCM_MOLine(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	MO BIGINT,--��������ID
	LineNum int,--�к�
	Item BIGINT,--��Ʒ
	MoQty DECIMAL(24,9),--��������
	MoUom BIGINT,--������λ
	StartDate DATETIME,--�ƻ�������
	CompleteDate DATETIME,--�ƻ��깤��
	ModifiedTime DATETIME,--�޸�����
	ModifiedBy VARCHAR(50),--�޸���
	SrcDocType VARCHAR(50),--��Դ����
	SrcDocNo VARCHAR(100),--��Դ����
	ActualStartDate DATETIME,--ҵ��ʼʱ��
	ActualCompleteDate DATETIME,--ҵ�����ʱ��
	BomVersion VARCHAR(100),--bom�汾��
	Routing VARCHAR(100),--����·��
	LotMaster BIGINT--����
)
GO
