IF OBJECT_ID('QYD_BC_LotMaster') IS NOT NULL
DROP TABLE QYD_BC_LotMaster
GO

CREATE TABLE QYD_BC_LotMaster(
	ID BIGINT PRIMARY KEY, --��ʶ
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
	AutoCode BIGINT,--�Զ�����ID
	Memo VARCHAR(500)--��ע
)
GO