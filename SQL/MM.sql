

--生产订单
IF OBJECT_ID('QYD_SCM_MO') IS NOT NULL
DROP TABLE QYD_SCM_MO
GO

CREATE TABLE QYD_SCM_MO(
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
IF OBJECT_ID('QYD_SCM_MOLine') IS NOT NULL
DROP TABLE QYD_SCM_MOLine
GO

CREATE TABLE QYD_SCM_MOLine(
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
