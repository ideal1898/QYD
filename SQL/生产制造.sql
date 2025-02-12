

--生产订单
IF OBJECT_ID('QYD_MM_MO') IS NOT NULL
DROP TABLE QYD_MM_MO
GO

CREATE TABLE QYD_MM_MO(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	Org BIGINT,--组织ID
	DocType VARCHAR(100),--单据类型
	DocNo VARCHAR(100),--单号
	StartDate DATETIME,--计划开工日
	BusinessDate DATETIME,--单据日期
	MoDept BIGINT,--生产部门
	BusinessPerson BIGINT,--业务员
	CompleteDate DATETIME,--计划完工日
	CompleteWh BIGINT,--完工仓库
	ModifiedTime DATETIME,--修改日期
	ModifiedBy VARCHAR(50),--修改人
	[Status] int,--单据状态
	Memo VARCHAR(500)--备注
)
GO


--生产订单明细表
IF OBJECT_ID('QYD_MM_MOLine') IS NOT NULL
DROP TABLE QYD_MM_MOLine
GO

CREATE TABLE QYD_MM_MOLine(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	MO BIGINT,--生产订单ID
	LineNum int,--行号
	Item BIGINT,--料品
	MoQty DECIMAL(24,9),--生产数量
	MoUom BIGINT,--生产单位
	StartDate DATETIME,--计划开工日
	CompleteDate DATETIME,--计划完工日
	ModifiedTime DATETIME,--修改日期
	ModifiedBy VARCHAR(50),--修改人
	SrcDocType VARCHAR(50),--来源单据
	SrcDocNo VARCHAR(100),--来源单号
	ActualStartDate DATETIME,--业务开始时间
	ActualCompleteDate DATETIME,--业务结束时间
	BomVersion VARCHAR(100),--bom版本号
	Routing VARCHAR(100),--工艺路线
	LotMaster BIGINT--批号
)
GO




--领料单
IF OBJECT_ID('QYD_MM_Issue') IS NOT NULL
DROP TABLE QYD_MM_Issue
GO

CREATE TABLE QYD_MM_Issue(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	Org BIGINT,--组织ID
	DocType VARCHAR(100),--单据类型
	DocNo VARCHAR(100),--单号
	BusinessDate DATETIME,--单据日期
	HandleDeptID BIGINT,--发料部门
	HandlePersonID BIGINT,--发料人
	BusinessCreatedOn DATETIME,--确认日期
	ModifiedTime DATETIME,--修改日期
	ModifiedBy VARCHAR(50),--修改人
	[Status] int,--单据状态
	Memo VARCHAR(500)--备注
)
GO


--领料单明细表
IF OBJECT_ID('QYD_MM_IssueLine') IS NOT NULL
DROP TABLE QYD_MM_IssueLine
GO

CREATE TABLE QYD_MM_IssueLine(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	IssueID BIGINT,--领料单ID
	LineNum int,--行号
	MOID BIGINT,--生产订单ID
	MODocNo VARCHAR(50),--生产单号
	ItemID BIGINT,--料品
	MoQty DECIMAL(24,9),--生产数量
	IssueQty DECIMAL(24,9),--应发数量
	IssuedQty DECIMAL(24,9),--实发数量
	IssueUomID BIGINT,--发料单位
	IssueWhID BIGINT,--发料仓库
	LotMasterID BIGINT,--批次
	WhShID BIGINT,--货位
	ModifiedTime DATETIME,--修改日期
	ModifiedBy VARCHAR(50)--修改人
)
GO




--退料单
IF OBJECT_ID('QYD_MM_RtnIssue') IS NOT NULL
DROP TABLE QYD_MM_RtnIssue
GO

CREATE TABLE QYD_MM_RtnIssue(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	Org BIGINT,--组织ID
	DocType VARCHAR(100),--单据类型
	DocNo VARCHAR(100),--单号
	BusinessDate DATETIME,--单据日期
	HandleDeptID BIGINT,--发料部门
	HandlePersonID BIGINT,--发料人
	BusinessCreatedOn DATETIME,--确认日期
	ModifiedTime DATETIME,--修改日期
	ModifiedBy VARCHAR(50),--修改人
	[Status] int,--单据状态
	Memo VARCHAR(500)--备注
)
GO


--退料单明细表
IF OBJECT_ID('QYD_MM_RtnIssueLine') IS NOT NULL
DROP TABLE QYD_MM_RtnIssueLine
GO

CREATE TABLE QYD_MM_RtnIssueLine(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	RtnIssueID BIGINT,--领料单ID
	LineNum int,--行号
	IssueLineID BIGINT,--领料行ID
	IssueDocNo VARCHAR(50),--领料单号
	IssueLineNum VARCHAR(50),--领料单号
	RecedeReason int,--退料理由
	ItemID BIGINT,--料品
	MoQty DECIMAL(24,9),--生产数量
	IssueQty DECIMAL(24,9),--应发数量
	IssuedQty DECIMAL(24,9),--实发数量
	IssueUomID BIGINT,--发料单位
	IssueWhID BIGINT,--发料仓库
	LotMasterID BIGINT,--批次
	WhShID BIGINT,--货位
	ModifiedTime DATETIME,--修改日期
	ModifiedBy VARCHAR(50)--修改人
)
GO



--完工入库单
IF OBJECT_ID('QYD_MM_RcvRpt') IS NOT NULL
DROP TABLE QYD_MM_RcvRpt
GO

CREATE TABLE QYD_MM_RcvRpt(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	Org BIGINT,--组织ID
	DocType VARCHAR(100),--单据类型
	DocNo VARCHAR(100),--单号
	BusinessDate DATETIME,--单据日期
	RcvDeptID BIGINT,--入库部门
	RcvPersonID BIGINT,--仓管员
	ActualRcvTime DATETIME,--入库日期
	ModifiedTime DATETIME,--修改日期
	ModifiedBy VARCHAR(50),--修改人
	[Status] int,--单据状态
	Memo VARCHAR(500)--备注
)
GO


--完工入库明细表
IF OBJECT_ID('QYD_MM_RcvRptLine') IS NOT NULL
DROP TABLE QYD_MM_RcvRptLine
GO

CREATE TABLE QYD_MM_RcvRptLine(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	RcvRptID BIGINT,--入库单ID
	LineNum int,--行号
	MOLineID BIGINT,--生产行ID
	MODocNo VARCHAR(50),--生产单号
	MOLineNum VARCHAR(50),--生产单行号
	BOMItemID BIGINT,--母件料品
	ItemID BIGINT,--子件料品
	RcvQty DECIMAL(24,9),--入库数量
	RcvUomID BIGINT,--入库单位
	RcvWhID BIGINT,--入库仓库
	LotMasterID BIGINT,--批次
	WhShID BIGINT,--货位
	ModifiedTime DATETIME,--修改日期
	ModifiedBy VARCHAR(50)--修改人
)
GO
