

--��������
IF OBJECT_ID('QYD_MM_MO') IS NOT NULL
DROP TABLE QYD_MM_MO
GO

CREATE TABLE QYD_MM_MO(
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
IF OBJECT_ID('QYD_MM_MOLine') IS NOT NULL
DROP TABLE QYD_MM_MOLine
GO

CREATE TABLE QYD_MM_MOLine(
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




--���ϵ�
IF OBJECT_ID('QYD_MM_Issue') IS NOT NULL
DROP TABLE QYD_MM_Issue
GO

CREATE TABLE QYD_MM_Issue(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	Org BIGINT,--��֯ID
	DocType VARCHAR(100),--��������
	DocNo VARCHAR(100),--����
	BusinessDate DATETIME,--��������
	HandleDeptID BIGINT,--���ϲ���
	HandlePersonID BIGINT,--������
	BusinessCreatedOn DATETIME,--ȷ������
	ModifiedTime DATETIME,--�޸�����
	ModifiedBy VARCHAR(50),--�޸���
	[Status] int,--����״̬
	Memo VARCHAR(500)--��ע
)
GO


--���ϵ���ϸ��
IF OBJECT_ID('QYD_MM_IssueLine') IS NOT NULL
DROP TABLE QYD_MM_IssueLine
GO

CREATE TABLE QYD_MM_IssueLine(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	IssueID BIGINT,--���ϵ�ID
	LineNum int,--�к�
	MOID BIGINT,--��������ID
	MODocNo VARCHAR(50),--��������
	ItemID BIGINT,--��Ʒ
	MoQty DECIMAL(24,9),--��������
	IssueQty DECIMAL(24,9),--Ӧ������
	IssuedQty DECIMAL(24,9),--ʵ������
	IssueUomID BIGINT,--���ϵ�λ
	IssueWhID BIGINT,--���ϲֿ�
	LotMasterID BIGINT,--����
	WhShID BIGINT,--��λ
	ModifiedTime DATETIME,--�޸�����
	ModifiedBy VARCHAR(50)--�޸���
)
GO




--���ϵ�
IF OBJECT_ID('QYD_MM_RtnIssue') IS NOT NULL
DROP TABLE QYD_MM_RtnIssue
GO

CREATE TABLE QYD_MM_RtnIssue(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	Org BIGINT,--��֯ID
	DocType VARCHAR(100),--��������
	DocNo VARCHAR(100),--����
	BusinessDate DATETIME,--��������
	HandleDeptID BIGINT,--���ϲ���
	HandlePersonID BIGINT,--������
	BusinessCreatedOn DATETIME,--ȷ������
	ModifiedTime DATETIME,--�޸�����
	ModifiedBy VARCHAR(50),--�޸���
	[Status] int,--����״̬
	Memo VARCHAR(500)--��ע
)
GO


--���ϵ���ϸ��
IF OBJECT_ID('QYD_MM_RtnIssueLine') IS NOT NULL
DROP TABLE QYD_MM_RtnIssueLine
GO

CREATE TABLE QYD_MM_RtnIssueLine(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	RtnIssueID BIGINT,--���ϵ�ID
	LineNum int,--�к�
	IssueLineID BIGINT,--������ID
	IssueDocNo VARCHAR(50),--���ϵ���
	IssueLineNum VARCHAR(50),--���ϵ���
	RecedeReason int,--��������
	ItemID BIGINT,--��Ʒ
	MoQty DECIMAL(24,9),--��������
	IssueQty DECIMAL(24,9),--Ӧ������
	IssuedQty DECIMAL(24,9),--ʵ������
	IssueUomID BIGINT,--���ϵ�λ
	IssueWhID BIGINT,--���ϲֿ�
	LotMasterID BIGINT,--����
	WhShID BIGINT,--��λ
	ModifiedTime DATETIME,--�޸�����
	ModifiedBy VARCHAR(50)--�޸���
)
GO



--�깤��ⵥ
IF OBJECT_ID('QYD_MM_RcvRpt') IS NOT NULL
DROP TABLE QYD_MM_RcvRpt
GO

CREATE TABLE QYD_MM_RcvRpt(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	Org BIGINT,--��֯ID
	DocType VARCHAR(100),--��������
	DocNo VARCHAR(100),--����
	BusinessDate DATETIME,--��������
	RcvDeptID BIGINT,--��ⲿ��
	RcvPersonID BIGINT,--�ֹ�Ա
	ActualRcvTime DATETIME,--�������
	ModifiedTime DATETIME,--�޸�����
	ModifiedBy VARCHAR(50),--�޸���
	[Status] int,--����״̬
	Memo VARCHAR(500)--��ע
)
GO


--�깤�����ϸ��
IF OBJECT_ID('QYD_MM_RcvRptLine') IS NOT NULL
DROP TABLE QYD_MM_RcvRptLine
GO

CREATE TABLE QYD_MM_RcvRptLine(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	RcvRptID BIGINT,--��ⵥID
	LineNum int,--�к�
	MOLineID BIGINT,--������ID
	MODocNo VARCHAR(50),--��������
	MOLineNum VARCHAR(50),--�������к�
	BOMItemID BIGINT,--ĸ����Ʒ
	ItemID BIGINT,--�Ӽ���Ʒ
	RcvQty DECIMAL(24,9),--�������
	RcvUomID BIGINT,--��ⵥλ
	RcvWhID BIGINT,--���ֿ�
	LotMasterID BIGINT,--����
	WhShID BIGINT,--��λ
	ModifiedTime DATETIME,--�޸�����
	ModifiedBy VARCHAR(50)--�޸���
)
GO
