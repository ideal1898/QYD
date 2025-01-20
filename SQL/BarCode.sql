
insert into QYD_Sys_Menu(id,CreatedTime,CreatedBy,SysVersion,Path,Name,Component,Redirect,IsActive,Icon,Title,IsLink,IsHide,IsFull,IsAffix,IsKeepAlive,Parent) values(605049656549446,GETDATE(),'管理员',0,'/mm','MM',null,null,0,'Lock','制造管理',null,0,0,0,1,0)

insert into QYD_Sys_Menu(id,CreatedTime,CreatedBy,SysVersion,Path,Name,Component,Redirect,IsActive,Icon,Title,IsLink,IsHide,IsFull,IsAffix,IsKeepAlive,Parent) values(605049656549447,GETDATE(),'管理员',0,'/mm/pm','PM',null,null,0,'Menu','生产管理',null,0,0,0,1,605049656549446)

insert into QYD_Sys_Menu(id,CreatedTime,CreatedBy,SysVersion,Path,Name,Component,Redirect,IsActive,Icon,Title,IsLink,IsHide,IsFull,IsAffix,IsKeepAlive,Parent) values(605049656549448,GETDATE(),'管理员',0,'/mm/pm/mo','MO','/mm/pm/mo/index',null,0,'Menu','生产订单',null,0,0,0,1,605049656549447)


--批号主档表
IF OBJECT_ID('QYD_BCP_LotMaster') IS NOT NULL
DROP TABLE QYD_BCP_LotMaster
GO

CREATE TABLE QYD_BCP_LotMaster(
	ID BIGINT NOT NULL UNIQUE, --标识
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
	AutoCode int,--是否自动编码
	Remark VARCHAR(500),--备注
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	PRIMARY KEY([ID])
)
GO

--批次规则表
IF OBJECT_ID('QYD_BC_LotRule') IS NOT NULL
DROP TABLE QYD_BC_LotRule
GO

CREATE TABLE QYD_BC_LotRule(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	RuleCode VARCHAR(100),--规则编码
	RuleName VARCHAR(100),--规则名称
	Org BIGINT,--组织ID
	RuleDes VARCHAR(500),--创建人
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	Memo VARCHAR(500)--备注
)
GO


--批次规则明细表
IF OBJECT_ID('QYD_BC_LotRuleLine') IS NOT NULL
DROP TABLE QYD_BC_LotRuleLine
GO

CREATE TABLE QYD_BC_LotRuleLine(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	LotRule BIGINT,--批次规则ID
	DsType int,--数据源类型
	DtFormat int,--数据源类型
	FillInCode VARCHAR(50),--补位符
	SplitCode VARCHAR(50),--分隔符
	IsFlow BIT,--是否流水依据
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	Memo VARCHAR(500)--数据源类型
)
GO
