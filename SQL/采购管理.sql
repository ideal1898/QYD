--�빺��
IF OBJECT_ID('QYD_PM_Requisition') IS NOT NULL
DROP TABLE QYD_PM_Requisition
GO

CREATE TABLE QYD_PM_Requisition(
--ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	DocNo NVARCHAR(100),--���ݱ��
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--ҵ������
	DocType BIGINT,--��������
	Org BIGINT,--��֯
	Status INT, --����״̬
	SubmitDate DATETIME, --�ύ����
	SubmitBy NVARCHAR(50),--�ύ��
	ApprovedOn DATETIME, --���ʱ��
	ApprovedBy NVARCHAR(50), --�����
	Memo NVARCHAR(350), --��ע
	--ҵ���ֶ�
	RequriedDept BIGINT,--������
	RequiredMan BIGINT,--������Ա
	Currency BIGINT, --����
	TaxRate DECIMAL(24,9),--˰��
	SrcDocNo NVARCHAR(100), --��Դ���ݺ�
	IsOverPurchase BIT  --������ɹ�
)

-- ����Ψһ����
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_Requisition_DocNo' )>0
DROP INDEX IDX_Requisition_DocNo ON QYD_PM_Requisition;
GO
CREATE UNIQUE INDEX IDX_Requisition_DocNo ON QYD_PM_Requisition (DocNo);
GO

IF OBJECT_ID('QYD_PM_RequisitionLine') IS NOT NULL
DROP TABLE QYD_PM_RequisitionLine
GO

CREATE TABLE QYD_PM_RequisitionLine(
    --ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	--ҵ���ֶ�
	Requisition BIGINT, --�빺��
	Material BIGINT, --����
	ItemCode NVARCHAR(100), --���ϱ���
	ItemName NVARCHAR(255) DEFAULT '', --��������
	ItemSpec NVARCHAR(255) DEFAULT '', --���Ϲ��
	UomName NVARCHAR(100), --������λ
	Project BIGINT,--��Ŀ
	Qty DECIMAL(24,9), --��������
	Price DECIMAL(24,9), --����
	TaxRate DECIMAL(24,9),--˰��
	TotalMoney DECIMAL(24,9),--��˰�ϼ�
	NoTaxMoney DECIMAL(24,9),--δ˰���
	TaxMoney DECIMAL(24,9),--˰��	
	RequireDate DATETIME, --Ҫ������
	Memo NVARCHAR(350), --��ע
	SrcType INT, --��Դ����
	SrcDocNo NVARCHAR(50), --��Դ���ݺ�
	SrcDocLine BIGINT --��Դ������
)


--�ɹ�����
IF OBJECT_ID('QYD_PM_PurchaseOrder') IS NOT NULL
DROP TABLE QYD_PM_PurchaseOrder
GO

CREATE TABLE QYD_PM_PurchaseOrder(
	--ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	DocNo NVARCHAR(100),--���ݱ��
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--ҵ������
	DocType BIGINT,--��������
	Org BIGINT,--��֯
	Status INT, --����״̬
	SubmitDate DATETIME, --�ύ����
	SubmitBy NVARCHAR(50),--�ύ��
	ApprovedOn DATETIME, --���ʱ��
	ApprovedBy NVARCHAR(50), --�����
	Memo NVARCHAR(350), --��ע
	--ҵ���ֶ�
	Currency BIGINT DEFAULT 0,
	SrcDocType NVARCHAR(20),
	Supplier  BIGINT DEFAULT 0,
	TotalMoney DECIMAL(24,9),
	TaxMoney DECIMAL(24,9),
	NoTaxMoney DECIMAL(24,9),
	TaxRate DECIMAL(24,9)
)
GO
-- ����Ψһ����
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_PurchaseOrder_DocNo' )>0
DROP INDEX IDX_PurchaseOrder_DocNo ON QYD_PM_PurchaseOrder;
GO
CREATE UNIQUE INDEX IDX_PurchaseOrder_DocNo ON QYD_PM_PurchaseOrder (DocNo);
GO
--�ɹ�������
IF OBJECT_ID('QYD_PM_POLine') IS NOT NULL
DROP TABLE QYD_PM_POLine
GO

CREATE TABLE QYD_PM_POLine(
    ID BIGINT PRIMARY KEY,
	CreatedTime DATETIME DEFAULT GETDATE(),
	CreatedBy NVARCHAR(50),
	ModifiedTime DATETIME DEFAULT GETDATE(),
	ModifiedBy NVARCHAR(50),
	SysVersion BIGINT DEFAULT 0,
	PurchaseOrder BIGINT DEFAULT 0,
	ItemId BIGINT,
	ItemCode NVARCHAR(100) DEFAULT '',
	ItemName NVARCHAR(255) DEFAULT '',
	ItemSpec NVARCHAR(255) DEFAULT '',
	UomName NVARCHAR(50),
	TaxRate DECIMAL(24,9),
	Qty DECIMAL(24,9),
	RequireDate DATETIME,
	Price DECIMAL(24,9),
	TotalMoney DECIMAL(24,9),
	TaxMoney DECIMAL(24,9),
	NoTaxMoney DECIMAL(24,9),
	SrcType INT, --��Դ����
	SrcDocNo NVARCHAR(50), --��Դ���ݺ�
	SrcDocLine BIGINT --��Դ������
)


--�ɹ�������
IF OBJECT_ID('QYD_PM_DeliveryOrder') IS NOT NULL
DROP TABLE QYD_PM_DeliveryOrder
GO

CREATE TABLE QYD_PM_DeliveryOrder(
--ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	DocNo NVARCHAR(100),--���ݱ��
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--ҵ������
	DocType BIGINT,--��������
	Org BIGINT,--��֯
	Status INT, --����״̬
	SubmitDate DATETIME, --�ύ����
	SubmitBy NVARCHAR(50),--�ύ��
	ApprovedOn DATETIME, --���ʱ��
	ApprovedBy NVARCHAR(50), --�����
	Memo NVARCHAR(350), --��ע
	--ҵ���ֶ�
	Supplier BIGINT,--��Ӧ��
	Department BIGINT, --����
	SalesMan BIGINT, --ҵ��Ա 
	IsPriceIncludeTax BIT,--�۸�˰
	SrcDocNo NVARCHAR(100) --��Դ���ݺ�
)

-- ����Ψһ����
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_DeliveryOrder_DocNo' )>0
DROP INDEX IDX_DeliveryOrder_DocNo ON QYD_PM_DeliveryOrder;
GO
CREATE UNIQUE INDEX IDX_DeliveryOrder_DocNo ON QYD_PM_DeliveryOrder (DocNo);
GO

IF OBJECT_ID('QYD_PM_DeliveryOrderLine') IS NOT NULL
DROP TABLE QYD_PM_DeliveryOrderLine
GO

CREATE TABLE QYD_PM_DeliveryOrderLine(
    --ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	--ҵ���ֶ�
	DeliveryOrder BIGINT, --�ɹ�������
	Material BIGINT, --����
	ItemCode NVARCHAR(100), --���ϱ���
	ItemName NVARCHAR(255) DEFAULT '', --��������
	ItemSpec NVARCHAR(255) DEFAULT '', --���Ϲ��
	UomName NVARCHAR(100), --������λ
	Qty DECIMAL(24,9), --��������
	StorageQty DECIMAL(24,9), --���������
	Price DECIMAL(24,9), --����
	TaxRate DECIMAL(24,9),--˰��
	TotalMoney DECIMAL(24,9),--��˰�ϼ�
	NoTaxMoney DECIMAL(24,9),--δ˰���
	TaxMoney DECIMAL(24,9),--˰��
	LotMaster BIGINT, --����
	Wh BIGINT, --�ֿ�
	Bin BIGINT,--��λ
	ProduceDate DATETIME, --��������
	Expiration INT, --��������
	EffectiveDate DATETIME,--��Ч����
	ExpirationDate DATETIME, --ʧЧ���� 
	Memo NVARCHAR(350), --��ע
	SrcType INT, --��Դ����
	SrcDocNo NVARCHAR(50), --��Դ���ݺ�
	SrcDocLine BIGINT --��Դ������
)



--�ɹ��ջ���
IF OBJECT_ID('QYD_PM_PurchaseReceipt') IS NOT NULL
DROP TABLE QYD_PM_PurchaseReceipt
GO

CREATE TABLE QYD_PM_PurchaseReceipt(
    --ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	DocNo NVARCHAR(100),--���ݱ��
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--ҵ������
	Org BIGINT,--��֯
	DocType BIGINT,--��������
	Status INT, --����״̬
	SubmitDate DATETIME, --�ύ����
	SubmitBy NVARCHAR(50),--�ύ��
	ApprovedOn DATETIME, --���ʱ��
	ApprovedBy NVARCHAR(50), --�����
	Memo NVARCHAR(350), --��ע
	--ҵ���ֶ�
	Supplier BIGINT,--��Ӧ��
	Department BIGINT, --�ջ�����
	RequiredDept BIGINT,--������
	RequiredMan BIGINT,--������Ա
	Consignee NVARCHAR(255),--�ջ���
	DeliveryAddress NVARCHAR(255), --�ջ���ַ
	Currency BIGINT, --����
	SalesMan BIGINT, --ҵ��Ա 
	IsPriceIncludeTax BIT,--�۸�˰
	SrcDocNo NVARCHAR(350) --��Դ���ݺ�
)

-- ����Ψһ����
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_PurchaseReceipts_DocNo' )>0
DROP INDEX IDX_PurchaseReceipts_DocNo ON QYD_PM_PurchaseReceipts;
GO
CREATE UNIQUE INDEX IDX_PurchaseReceipts_DocNo ON QYD_PM_PurchaseReceipt (DocNo);
GO

IF OBJECT_ID('QYD_PM_PurchaseReceiptsLine') IS NOT NULL
DROP TABLE QYD_PM_PurchaseReceiptsLine
GO

CREATE TABLE QYD_PM_PurchaseReceiptsLine(
    --ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	--ҵ���ֶ�
	PurchaseReceipt BIGINT, --�ɹ��ջ���
	Material BIGINT, --����
	ItemCode NVARCHAR(100), --���ϱ���
	ItemName NVARCHAR(255) DEFAULT '', --��������
	ItemSpec NVARCHAR(255) DEFAULT '', --���Ϲ��
	UomName NVARCHAR(100), --������λ
	Qty DECIMAL(24,9), --�ջ�����
	RtnQty DECIMAL(24,9), --�˻�����
	Price DECIMAL(24,9), --����
	TaxRate DECIMAL(24,9),--˰��
	TotalMoney DECIMAL(24,9),--��˰�ϼ�
	NoTaxMoney DECIMAL(24,9),--δ˰���
	TaxMoney DECIMAL(24,9),--˰��
	LotMaster BIGINT, --����
	Wh BIGINT, --�ֿ�
	Bin BIGINT,--��λ
	Treasurer BIGINT,--���Ա
	Project BIGINT,--��Ŀ
	ProduceDate DATETIME, --��������
	EffectiveDate DATETIME,--��Ч����
	Expiration INT, --��������
	ExpirationDate DATETIME, --ʧЧ���� 
	Memo NVARCHAR(350), --��ע
	SrcType INT, --��Դ����
	SrcDocNo NVARCHAR(50), --��Դ���ݺ�
	SrcDocLine BIGINT, --��Դ������
	ArriveDate DATETIME, --��������
	ConfirmDate DATETIME --���ȷ������
)




--�ɹ��˻�����
IF OBJECT_ID('QYD_PM_ReturnRequisition') IS NOT NULL
DROP TABLE QYD_PM_ReturnRequisition
GO

CREATE TABLE QYD_PM_ReturnRequisition(
    --ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	DocNo NVARCHAR(100),--���ݱ��
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--ҵ������
	Org BIGINT,--��֯
	DocType BIGINT,--��������
	Status INT, --����״̬
	SubmitDate DATETIME, --�ύ����
	SubmitBy NVARCHAR(50),--�ύ��
	ApprovedOn DATETIME, --���ʱ��
	ApprovedBy NVARCHAR(50), --�����
	Memo NVARCHAR(350), --��ע
	--ҵ���ֶ�
	Supplier BIGINT,--��Ӧ��
	RtnDept BIGINT,--�˻�����
	RtnMan BIGINT,--�˻���Ա
	SalesMan BIGINT,--ҵ��Ա
	Consignee BIGINT,--�ջ���
	DeliveryAddress NVARCHAR(255), --�ջ���ַ
	Currency BIGINT, --����
	IsPriceIncludeTax BIT,--�۸�˰
	SrcDocNo NVARCHAR(350) --��Դ���ݺ�
)

-- ����Ψһ����
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_ReturnRequisition_DocNo' )>0
DROP INDEX IDX_ReturnRequisition_DocNo ON QYD_PM_ReturnRequisition;
GO
CREATE UNIQUE INDEX IDX_ReturnRequisition_DocNo ON QYD_PM_ReturnRequisition (DocNo);
GO

IF OBJECT_ID('QYD_PM_ReturnRequisitionLine') IS NOT NULL
DROP TABLE QYD_PM_ReturnRequisitionLine
GO

CREATE TABLE QYD_PM_ReturnRequisitionLine(
    --ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	--ҵ���ֶ�
	ReturnRequisition BIGINT, --�ɹ��˻����뵥
	Material BIGINT, --����
	ItemCode NVARCHAR(100), --���ϱ���
	ItemName NVARCHAR(255) DEFAULT '', --��������
	ItemSpec NVARCHAR(255) DEFAULT '', --���Ϲ��
	UomName NVARCHAR(100), --������λ
	RtnQty DECIMAL(24,9), --�˻���������
	Price DECIMAL(24,9), --����
	TaxRate DECIMAL(24,9),--˰��
	TotalMoney DECIMAL(24,9),--��˰�ϼ�
	NoTaxMoney DECIMAL(24,9),--δ˰���
	TaxMoney DECIMAL(24,9),--˰��
	LotMaster BIGINT, --����
	Wh BIGINT, --�ֿ�
	Bin BIGINT,--��λ
	Treasurer BIGINT,--���Ա
	Project BIGINT,--��Ŀ
	ProduceDate DATETIME, --��������
	EffectiveDate DATETIME,--��Ч����
	Expiration INT, --��������
	ExpirationDate DATETIME, --ʧЧ���� 
	Memo NVARCHAR(350), --��ע
	SrcType INT, --��Դ����
	SrcDocNo NVARCHAR(50), --��Դ���ݺ�
	SrcDocLine BIGINT --��Դ������
)



--�ɹ��˻���
IF OBJECT_ID('QYD_PM_ReturnBill') IS NOT NULL
DROP TABLE QYD_PM_ReturnBill
GO

CREATE TABLE QYD_PM_ReturnBill(
    --ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	DocNo NVARCHAR(100),--���ݱ��
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--ҵ������
	Org BIGINT,--��֯
	DocType BIGINT,--��������
	Status INT, --����״̬
	SubmitDate DATETIME, --�ύ����
	SubmitBy NVARCHAR(50),--�ύ��
	ApprovedOn DATETIME, --���ʱ��
	ApprovedBy NVARCHAR(50), --�����
	Memo NVARCHAR(350), --��ע
	--ҵ���ֶ�
	Supplier BIGINT,--��Ӧ��
	RtnDept BIGINT,--�˻�����
	RtnMan BIGINT,--�˻���Ա
	Consignee BIGINT,--�ջ���
	DeliveryAddress NVARCHAR(255), --�ջ���ַ
	Currency BIGINT, --����
	SalesMan BIGINT, --ҵ��Ա 
	IsPriceIncludeTax BIT,--�۸�˰
	SrcDocNo NVARCHAR(350) --��Դ���ݺ�
)

-- ����Ψһ����
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_ReturnBill_DocNo' )>0
DROP INDEX IDX_ReturnBill_DocNo ON QYD_PM_ReturnBill;
GO
CREATE UNIQUE INDEX IDX_ReturnBill_DocNo ON QYD_PM_ReturnBill (DocNo);
GO

IF OBJECT_ID('QYD_PM_ReturnBillLine') IS NOT NULL
DROP TABLE QYD_PM_ReturnBillLine
GO

CREATE TABLE QYD_PM_ReturnBillLine(
    --ͳһ�ֶ�
	ID BIGINT PRIMARY KEY, --���ʶ
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--����ʱ��
	CreatedBy NVARCHAR(50),--������
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--�޸�ʱ��
	ModifiedBy NVARCHAR(50),--�޸���
	SysVersion BIGINT,--�汾
	--ҵ���ֶ�
	ReturnBill BIGINT, --�ɹ��ջ���
	Material BIGINT, --����
	ItemCode NVARCHAR(100), --���ϱ���
	ItemName NVARCHAR(255) DEFAULT '', --��������
	ItemSpec NVARCHAR(255) DEFAULT '', --���Ϲ��
	UomName NVARCHAR(100), --������λ
	RtnQty DECIMAL(24,9), --�˻�����
	Price DECIMAL(24,9), --����
	TaxRate DECIMAL(24,9),--˰��
	TotalMoney DECIMAL(24,9),--��˰�ϼ�
	NoTaxMoney DECIMAL(24,9),--δ˰���
	TaxMoney DECIMAL(24,9),--˰��
	LotMaster BIGINT, --����
	Wh BIGINT, --�ֿ�
	Bin BIGINT,--��λ
	Treasurer BIGINT,--���Ա
	Project BIGINT,--��Ŀ
	ProduceDate DATETIME, --��������
	EffectiveDate DATETIME,--��Ч����
	Expiration INT, --��������
	ExpirationDate DATETIME, --ʧЧ���� 
	Memo NVARCHAR(350), --��ע
	SrcType INT, --��Դ����
	SrcDocNo NVARCHAR(50), --��Դ���ݺ�
	SrcDocLine BIGINT, --��Դ������
	ArriveDate DATETIME, --��������
	ConfirmDate DATETIME --���ȷ������
)


