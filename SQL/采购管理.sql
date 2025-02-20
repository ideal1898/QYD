--请购单
IF OBJECT_ID('QYD_PM_Requisition') IS NOT NULL
DROP TABLE QYD_PM_Requisition
GO

CREATE TABLE QYD_PM_Requisition(
--统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	DocNo NVARCHAR(100),--单据编号
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--业务日期
	DocType BIGINT,--单据类型
	Org BIGINT,--组织
	Status INT, --单据状态
	SubmitDate DATETIME, --提交日期
	SubmitBy NVARCHAR(50),--提交人
	ApprovedOn DATETIME, --审核时间
	ApprovedBy NVARCHAR(50), --审核人
	Memo NVARCHAR(350), --备注
	--业务字段
	RequriedDept BIGINT,--需求部门
	RequiredMan BIGINT,--需求人员
	Currency BIGINT, --币种
	TaxRate DECIMAL(24,9),--税率
	SrcDocNo NVARCHAR(100), --来源单据号
	IsOverPurchase BIT  --允许超额采购
)

-- 创建唯一索引
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_Requisition_DocNo' )>0
DROP INDEX IDX_Requisition_DocNo ON QYD_PM_Requisition;
GO
CREATE UNIQUE INDEX IDX_Requisition_DocNo ON QYD_PM_Requisition (DocNo);
GO

IF OBJECT_ID('QYD_PM_RequisitionLine') IS NOT NULL
DROP TABLE QYD_PM_RequisitionLine
GO

CREATE TABLE QYD_PM_RequisitionLine(
    --统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	--业务字段
	Requisition BIGINT, --请购单
	Material BIGINT, --物料
	ItemCode NVARCHAR(100), --物料编码
	ItemName NVARCHAR(255) DEFAULT '', --物料名称
	ItemSpec NVARCHAR(255) DEFAULT '', --物料规格
	UomName NVARCHAR(100), --计量单位
	Project BIGINT,--项目
	Qty DECIMAL(24,9), --到货数量
	Price DECIMAL(24,9), --单价
	TaxRate DECIMAL(24,9),--税率
	TotalMoney DECIMAL(24,9),--价税合计
	NoTaxMoney DECIMAL(24,9),--未税金额
	TaxMoney DECIMAL(24,9),--税额	
	RequireDate DATETIME, --要货日期
	Memo NVARCHAR(350), --备注
	SrcType INT, --来源类型
	SrcDocNo NVARCHAR(50), --来源单据号
	SrcDocLine BIGINT --来源单据行
)


--采购订单
IF OBJECT_ID('QYD_PM_PurchaseOrder') IS NOT NULL
DROP TABLE QYD_PM_PurchaseOrder
GO

CREATE TABLE QYD_PM_PurchaseOrder(
	--统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	DocNo NVARCHAR(100),--单据编号
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--业务日期
	DocType BIGINT,--单据类型
	Org BIGINT,--组织
	Status INT, --单据状态
	SubmitDate DATETIME, --提交日期
	SubmitBy NVARCHAR(50),--提交人
	ApprovedOn DATETIME, --审核时间
	ApprovedBy NVARCHAR(50), --审核人
	Memo NVARCHAR(350), --备注
	--业务字段
	Currency BIGINT DEFAULT 0,
	SrcDocType NVARCHAR(20),
	Supplier  BIGINT DEFAULT 0,
	TotalMoney DECIMAL(24,9),
	TaxMoney DECIMAL(24,9),
	NoTaxMoney DECIMAL(24,9),
	TaxRate DECIMAL(24,9)
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
	SrcType INT, --来源类型
	SrcDocNo NVARCHAR(50), --来源单据号
	SrcDocLine BIGINT --来源单据行
)


--采购到货单
IF OBJECT_ID('QYD_PM_DeliveryOrder') IS NOT NULL
DROP TABLE QYD_PM_DeliveryOrder
GO

CREATE TABLE QYD_PM_DeliveryOrder(
--统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	DocNo NVARCHAR(100),--单据编号
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--业务日期
	DocType BIGINT,--单据类型
	Org BIGINT,--组织
	Status INT, --单据状态
	SubmitDate DATETIME, --提交日期
	SubmitBy NVARCHAR(50),--提交人
	ApprovedOn DATETIME, --审核时间
	ApprovedBy NVARCHAR(50), --审核人
	Memo NVARCHAR(350), --备注
	--业务字段
	Supplier BIGINT,--供应商
	Department BIGINT, --部门
	SalesMan BIGINT, --业务员 
	IsPriceIncludeTax BIT,--价格含税
	SrcDocNo NVARCHAR(100) --来源单据号
)

-- 创建唯一索引
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_DeliveryOrder_DocNo' )>0
DROP INDEX IDX_DeliveryOrder_DocNo ON QYD_PM_DeliveryOrder;
GO
CREATE UNIQUE INDEX IDX_DeliveryOrder_DocNo ON QYD_PM_DeliveryOrder (DocNo);
GO

IF OBJECT_ID('QYD_PM_DeliveryOrderLine') IS NOT NULL
DROP TABLE QYD_PM_DeliveryOrderLine
GO

CREATE TABLE QYD_PM_DeliveryOrderLine(
    --统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	--业务字段
	DeliveryOrder BIGINT, --采购到货单
	Material BIGINT, --物料
	ItemCode NVARCHAR(100), --物料编码
	ItemName NVARCHAR(255) DEFAULT '', --物料名称
	ItemSpec NVARCHAR(255) DEFAULT '', --物料规格
	UomName NVARCHAR(100), --计量单位
	Qty DECIMAL(24,9), --到货数量
	StorageQty DECIMAL(24,9), --已入库数量
	Price DECIMAL(24,9), --单价
	TaxRate DECIMAL(24,9),--税率
	TotalMoney DECIMAL(24,9),--价税合计
	NoTaxMoney DECIMAL(24,9),--未税金额
	TaxMoney DECIMAL(24,9),--税额
	LotMaster BIGINT, --批次
	Wh BIGINT, --仓库
	Bin BIGINT,--货位
	ProduceDate DATETIME, --生产日期
	Expiration INT, --保质天数
	EffectiveDate DATETIME,--生效日期
	ExpirationDate DATETIME, --失效日期 
	Memo NVARCHAR(350), --备注
	SrcType INT, --来源类型
	SrcDocNo NVARCHAR(50), --来源单据号
	SrcDocLine BIGINT --来源单据行
)



--采购收货单
IF OBJECT_ID('QYD_PM_PurchaseReceipt') IS NOT NULL
DROP TABLE QYD_PM_PurchaseReceipt
GO

CREATE TABLE QYD_PM_PurchaseReceipt(
    --统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	DocNo NVARCHAR(100),--单据编号
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--业务日期
	Org BIGINT,--组织
	DocType BIGINT,--单据类型
	Status INT, --单据状态
	SubmitDate DATETIME, --提交日期
	SubmitBy NVARCHAR(50),--提交人
	ApprovedOn DATETIME, --审核时间
	ApprovedBy NVARCHAR(50), --审核人
	Memo NVARCHAR(350), --备注
	--业务字段
	Supplier BIGINT,--供应商
	Department BIGINT, --收货部门
	RequiredDept BIGINT,--需求部门
	RequiredMan BIGINT,--需求人员
	Consignee NVARCHAR(255),--收货人
	DeliveryAddress NVARCHAR(255), --收货地址
	Currency BIGINT, --币种
	SalesMan BIGINT, --业务员 
	IsPriceIncludeTax BIT,--价格含税
	SrcDocNo NVARCHAR(350) --来源单据号
)

-- 创建唯一索引
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_PurchaseReceipts_DocNo' )>0
DROP INDEX IDX_PurchaseReceipts_DocNo ON QYD_PM_PurchaseReceipts;
GO
CREATE UNIQUE INDEX IDX_PurchaseReceipts_DocNo ON QYD_PM_PurchaseReceipt (DocNo);
GO

IF OBJECT_ID('QYD_PM_PurchaseReceiptsLine') IS NOT NULL
DROP TABLE QYD_PM_PurchaseReceiptsLine
GO

CREATE TABLE QYD_PM_PurchaseReceiptsLine(
    --统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	--业务字段
	PurchaseReceipt BIGINT, --采购收货单
	Material BIGINT, --物料
	ItemCode NVARCHAR(100), --物料编码
	ItemName NVARCHAR(255) DEFAULT '', --物料名称
	ItemSpec NVARCHAR(255) DEFAULT '', --物料规格
	UomName NVARCHAR(100), --计量单位
	Qty DECIMAL(24,9), --收货数量
	RtnQty DECIMAL(24,9), --退货数量
	Price DECIMAL(24,9), --单价
	TaxRate DECIMAL(24,9),--税率
	TotalMoney DECIMAL(24,9),--价税合计
	NoTaxMoney DECIMAL(24,9),--未税金额
	TaxMoney DECIMAL(24,9),--税额
	LotMaster BIGINT, --批次
	Wh BIGINT, --仓库
	Bin BIGINT,--货位
	Treasurer BIGINT,--库管员
	Project BIGINT,--项目
	ProduceDate DATETIME, --生产日期
	EffectiveDate DATETIME,--生效日期
	Expiration INT, --保质天数
	ExpirationDate DATETIME, --失效日期 
	Memo NVARCHAR(350), --备注
	SrcType INT, --来源类型
	SrcDocNo NVARCHAR(50), --来源单据号
	SrcDocLine BIGINT, --来源单据行
	ArriveDate DATETIME, --到货日期
	ConfirmDate DATETIME --入库确认日期
)




--采购退货申请
IF OBJECT_ID('QYD_PM_ReturnRequisition') IS NOT NULL
DROP TABLE QYD_PM_ReturnRequisition
GO

CREATE TABLE QYD_PM_ReturnRequisition(
    --统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	DocNo NVARCHAR(100),--单据编号
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--业务日期
	Org BIGINT,--组织
	DocType BIGINT,--单据类型
	Status INT, --单据状态
	SubmitDate DATETIME, --提交日期
	SubmitBy NVARCHAR(50),--提交人
	ApprovedOn DATETIME, --审核时间
	ApprovedBy NVARCHAR(50), --审核人
	Memo NVARCHAR(350), --备注
	--业务字段
	Supplier BIGINT,--供应商
	RtnDept BIGINT,--退货部门
	RtnMan BIGINT,--退货人员
	SalesMan BIGINT,--业务员
	Consignee BIGINT,--收货人
	DeliveryAddress NVARCHAR(255), --收货地址
	Currency BIGINT, --币种
	IsPriceIncludeTax BIT,--价格含税
	SrcDocNo NVARCHAR(350) --来源单据号
)

-- 创建唯一索引
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_ReturnRequisition_DocNo' )>0
DROP INDEX IDX_ReturnRequisition_DocNo ON QYD_PM_ReturnRequisition;
GO
CREATE UNIQUE INDEX IDX_ReturnRequisition_DocNo ON QYD_PM_ReturnRequisition (DocNo);
GO

IF OBJECT_ID('QYD_PM_ReturnRequisitionLine') IS NOT NULL
DROP TABLE QYD_PM_ReturnRequisitionLine
GO

CREATE TABLE QYD_PM_ReturnRequisitionLine(
    --统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	--业务字段
	ReturnRequisition BIGINT, --采购退货申请单
	Material BIGINT, --物料
	ItemCode NVARCHAR(100), --物料编码
	ItemName NVARCHAR(255) DEFAULT '', --物料名称
	ItemSpec NVARCHAR(255) DEFAULT '', --物料规格
	UomName NVARCHAR(100), --计量单位
	RtnQty DECIMAL(24,9), --退货申请数量
	Price DECIMAL(24,9), --单价
	TaxRate DECIMAL(24,9),--税率
	TotalMoney DECIMAL(24,9),--价税合计
	NoTaxMoney DECIMAL(24,9),--未税金额
	TaxMoney DECIMAL(24,9),--税额
	LotMaster BIGINT, --批次
	Wh BIGINT, --仓库
	Bin BIGINT,--货位
	Treasurer BIGINT,--库管员
	Project BIGINT,--项目
	ProduceDate DATETIME, --生产日期
	EffectiveDate DATETIME,--生效日期
	Expiration INT, --保质天数
	ExpirationDate DATETIME, --失效日期 
	Memo NVARCHAR(350), --备注
	SrcType INT, --来源类型
	SrcDocNo NVARCHAR(50), --来源单据号
	SrcDocLine BIGINT --来源单据行
)



--采购退货单
IF OBJECT_ID('QYD_PM_ReturnBill') IS NOT NULL
DROP TABLE QYD_PM_ReturnBill
GO

CREATE TABLE QYD_PM_ReturnBill(
    --统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	DocNo NVARCHAR(100),--单据编号
	BusinessDate DATETIME NOT NULL DEFAULT GETDATE(),--业务日期
	Org BIGINT,--组织
	DocType BIGINT,--单据类型
	Status INT, --单据状态
	SubmitDate DATETIME, --提交日期
	SubmitBy NVARCHAR(50),--提交人
	ApprovedOn DATETIME, --审核时间
	ApprovedBy NVARCHAR(50), --审核人
	Memo NVARCHAR(350), --备注
	--业务字段
	Supplier BIGINT,--供应商
	RtnDept BIGINT,--退货部门
	RtnMan BIGINT,--退货人员
	Consignee BIGINT,--收货人
	DeliveryAddress NVARCHAR(255), --收货地址
	Currency BIGINT, --币种
	SalesMan BIGINT, --业务员 
	IsPriceIncludeTax BIT,--价格含税
	SrcDocNo NVARCHAR(350) --来源单据号
)

-- 创建唯一索引
IF (SELECT  COUNT(1) FROM sys.sysindexes WHERE Name='IDX_ReturnBill_DocNo' )>0
DROP INDEX IDX_ReturnBill_DocNo ON QYD_PM_ReturnBill;
GO
CREATE UNIQUE INDEX IDX_ReturnBill_DocNo ON QYD_PM_ReturnBill (DocNo);
GO

IF OBJECT_ID('QYD_PM_ReturnBillLine') IS NOT NULL
DROP TABLE QYD_PM_ReturnBillLine
GO

CREATE TABLE QYD_PM_ReturnBillLine(
    --统一字段
	ID BIGINT PRIMARY KEY, --表标识
	CreatedTime DATETIME NOT NULL DEFAULT GETDATE(),--创建时间
	CreatedBy NVARCHAR(50),--创建人
	ModifiedTime DATETIME NOT NULL DEFAULT GETDATE(),--修改时间
	ModifiedBy NVARCHAR(50),--修改人
	SysVersion BIGINT,--版本
	--业务字段
	ReturnBill BIGINT, --采购收货单
	Material BIGINT, --物料
	ItemCode NVARCHAR(100), --物料编码
	ItemName NVARCHAR(255) DEFAULT '', --物料名称
	ItemSpec NVARCHAR(255) DEFAULT '', --物料规格
	UomName NVARCHAR(100), --计量单位
	RtnQty DECIMAL(24,9), --退货数量
	Price DECIMAL(24,9), --单价
	TaxRate DECIMAL(24,9),--税率
	TotalMoney DECIMAL(24,9),--价税合计
	NoTaxMoney DECIMAL(24,9),--未税金额
	TaxMoney DECIMAL(24,9),--税额
	LotMaster BIGINT, --批次
	Wh BIGINT, --仓库
	Bin BIGINT,--货位
	Treasurer BIGINT,--库管员
	Project BIGINT,--项目
	ProduceDate DATETIME, --生产日期
	EffectiveDate DATETIME,--生效日期
	Expiration INT, --保质天数
	ExpirationDate DATETIME, --失效日期 
	Memo NVARCHAR(350), --备注
	SrcType INT, --来源类型
	SrcDocNo NVARCHAR(50), --来源单据号
	SrcDocLine BIGINT, --来源单据行
	ArriveDate DATETIME, --到货日期
	ConfirmDate DATETIME --入库确认日期
)


