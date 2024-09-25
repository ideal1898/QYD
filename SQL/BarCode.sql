IF OBJECT_ID('QYD_BC_LotMaster') IS NOT NULL
DROP TABLE QYD_BC_LotMaster
GO

CREATE TABLE QYD_BC_LotMaster(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	ItemMaster BIGINT,--料品ID
	LotCode VARCHAR(100),--批号
	Org BIGINT,--组织ID
	EffectiveDate DATETIME,--生效日期
	ValidDate int,--生效天数
	InvalidDate DATETIME,--生效日期
	SrcDocNo VARCHAR(50),--创建人
	AutoCode BIGINT,--自动编码ID
	Memo VARCHAR(500)--备注
)
GO