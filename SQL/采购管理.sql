
--采购订单
IF OBJECT_ID('QYD_PM_PurchaseOrder') IS NOT NULL
DROP TABLE QYD_PM_PurchaseOrder
GO

CREATE TABLE QYD_PM_PurchaseOrder(
	ID BIGINT PRIMARY KEY,
	CreatedTime DATETIME DEFAULT GETDATE(),
	CreatedBy NVARCHAR(50),
	SysVersion BIGINT DEFAULT 0,
	DocNo NVARCHAR(100) NOT NULL,
	Org BIGINT,
	BusinessDate DATETIME DEFAULT GETDATE(),
	CurrencyId BIGINT DEFAULT 0,
	SrcDocType NVARCHAR(20),
	SupplierId  BIGINT DEFAULT 0,
	TotalMoney DECIMAL(24,9),
	TaxMoney DECIMAL(24,9),
	NoTaxMoney DECIMAL(24,9),
	TaxRate DECIMAL(24,9),
	Status INT
)
GO
-- 创建唯一索引
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_PurchaseOrder_DocNo' )>0
DROP INDEX IDX_PurchaseOrder_DocNo ON QYD_PM_PurchaseOrder;
GO
CREATE UNIQUE INDEX IDX_PurchaseOrder_DocNo ON QYD_PM_PurchaseOrder (DocNo);
GO
--采购订单行
IF OBJECT_ID('QYD_PM_POLine') IS NOT NULL
DROP TABLE QYD_PM_POLine
GO

CREATE TABLE QYD_PM_POLine(
    ID BIGINT PRIMARY KEY,
	CreatedTime DATETIME DEFAULT GETDATE(),
	CreatedBy NVARCHAR(50),
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
	NoTaxMoney DECIMAL(24,9)
)