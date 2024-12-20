/**
国家/地区表
*/
IF OBJECT_ID('QYD_Basic_Country') IS NOT NULL
DROP TABLE QYD_Basic_Country
GO

CREATE TABLE [QYD_Basic_Country] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 地区编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	-- 时区
	[TimeZone] SMALLINT DEFAULT -1,
	-- 地区格式
	[CountryFormat] SMALLINT DEFAULT -1,
	-- 币种
	[Currency] SMALLINT DEFAULT -1,
	-- 语言
	[Language] SMALLINT DEFAULT -1,
	-- 姓名格式
	[NameFormat] SMALLINT DEFAULT -1,
	PRIMARY KEY([ID])
);
GO

/**
组织
*/
IF OBJECT_ID('QYD_Base_Organization') IS NOT NULL
DROP TABLE QYD_Base_Organization
GO

CREATE TABLE [QYD_Base_Organization] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 地区编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--是否生效
	[IsEffective] int DEFAULT 0,
		--默认语言
	[DefaultLanguage] int,
	--地址
	[Location] nvarchar(255) ,
	--注册地址
	[RegisterAddress] nvarchar(255) ,
	--社会统一信用代码
	[CCBL] nvarchar(255) ,
	--联系人
	[Contacts] nvarchar(255) ,
	--简称
	[Shortname] nvarchar(255) ,
	PRIMARY KEY([ID])
);
GO


/**
省/自治区
*/
IF OBJECT_ID('QYD_Base_Province') IS NOT NULL
DROP TABLE QYD_Base_Province
GO

CREATE TABLE [QYD_Base_Province] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--省
	[Country] bigint,
	PRIMARY KEY([ID])
);
GO


/**
客户分类
*/
IF OBJECT_ID('QYD_Basic_CustomerCategory') IS NOT NULL
DROP TABLE QYD_Basic_CustomerCategory
GO

CREATE TABLE [QYD_Basic_CustomerCategory] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--备注
	[Remark] nvarchar(255),
		--是否生效
	[IsEffective] int DEFAULT 0,
	--上级分类
	[ParentNode] bigint,
	PRIMARY KEY([ID])
);
GO


/**
供应商分类
*/
IF OBJECT_ID('QYD_Basic_SupplierCategory') IS NOT NULL
DROP TABLE QYD_Basic_SupplierCategory
GO

CREATE TABLE [QYD_Basic_SupplierCategory] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--备注
	[Remark] nvarchar(255),
		--是否生效
	[IsEffective] int DEFAULT 0,
	--上级分类
	[ParentNode] bigint,
	PRIMARY KEY([ID])
);
GO



/**
计量单位
*/
IF OBJECT_ID('QYD_Basic_UOM') IS NOT NULL
DROP TABLE QYD_Basic_UOM
GO

CREATE TABLE [QYD_Basic_UOM] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--备注
	[Remark] nvarchar(255),
		--是否基准单位
	[IsBase] int DEFAULT 0,
	--转换系数
	[RatioToBase] decimal(24,9),
		--舍位方式：1-四舍五入，2-舍位，3-入位
	[RoundWay] int DEFAULT 0,
		--精度
	[UomPrecision] int DEFAULT 0,
	PRIMARY KEY([ID])
);
GO



/**
物料分类
*/
IF OBJECT_ID('QYD_Basic_ItemCategory') IS NOT NULL
DROP TABLE QYD_Basic_ItemCategory
GO

CREATE TABLE [QYD_Basic_ItemCategory] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--备注
	[Remark] nvarchar(255),
		--是否生效
	[IsEffective] int DEFAULT 0,
	--上级分类
	[ParentNode] bigint,
	PRIMARY KEY([ID])
);
GO



/**
项目
*/
IF OBJECT_ID('QYD_Basic_Project') IS NOT NULL
DROP TABLE QYD_Basic_Project
GO

CREATE TABLE [QYD_Basic_Project] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--描述
	[Description] nvarchar(255),
		--状态
	[Status] int DEFAULT 0,
	--验收日期
	[AcceptDate] datetime,
		--质保到期日
	[QAExpireDate] datetime,
	PRIMARY KEY([ID])
);
GO



/**
部门
*/
IF OBJECT_ID('QYD_Basic_Department') IS NOT NULL
DROP TABLE QYD_Basic_Department
GO

CREATE TABLE [QYD_Basic_Department] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--备注
	[Remark] nvarchar(255),
		--是否生效
	[IsEffective] int DEFAULT 0,
	--上级分类
	[ParentNode] bigint,
	PRIMARY KEY([ID])
);
GO


/**
业务员
*/
IF OBJECT_ID('QYD_Basic_Operators') IS NOT NULL
DROP TABLE QYD_Basic_Operators
GO

CREATE TABLE [QYD_Basic_Operators] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--备注
	[Remark] nvarchar(255),
		--是否生效
	[IsEffective] int DEFAULT 0,
	--部门
	[Dept] bigint,
		--是否采购员
	[IsPurer] int DEFAULT 0,
		--是否销售人员
	[IsSaler] int DEFAULT 0,
		--是否计划人员
	[IsPlaner] int DEFAULT 0,
		--是否库存管理员
	[IsInver] int DEFAULT 0,
	PRIMARY KEY([ID])
);
GO




/**
客户
*/
IF OBJECT_ID('QYD_Basic_Customer') IS NOT NULL
DROP TABLE QYD_Basic_Customer
GO

CREATE TABLE [QYD_Basic_Customer] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--备注
	[Remark] nvarchar(255),
		--简称
	[ShortName] VARCHAR(50),
	--客户分类
	[Category] bigint,
	--地区
	[Country] bigint,
	--供应商
	[Supplier] bigint,
	--收货地址
	[RcvAddress] nvarchar(100),
	--是否内部组织
	[IsInerOrg] int DEFAULT 0,
		--部门
	[Dept] bigint,
		--业务员
	[Operators] bigint,
		--税率
	[TaxRate] decimal(24,9),
	--税号
	[TaxNum] nvarchar(100),
	--上级客户
	[ParentCustomer] bigint,
	--收货人电话
	[RcvManTell] nvarchar(50),
	--收款条件
	[RecTerm] nvarchar(50),
	--立账条件
	[AccrueTerm] nvarchar(50),
	--出货原则
	[ShipRule] nvarchar(50),
	--组织
	[Org] bigint,
	--状态
	[Status] int DEFAULT 0,
	PRIMARY KEY([ID])
);
GO