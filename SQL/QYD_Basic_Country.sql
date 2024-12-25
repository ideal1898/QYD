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



/**
供应商
*/
IF OBJECT_ID('QYD_Basic_Supplier') IS NOT NULL
DROP TABLE QYD_Basic_Supplier
GO

CREATE TABLE [QYD_Basic_Supplier] (
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
	--分类
	[Category] bigint,
	--地区
	[Country] bigint,
	--供应商
	[Customer] bigint,
	--公众号
	[WeChat] nvarchar(100),
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
	--上级供应商
	[ParentSuppiler] bigint,
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



/**
仓库
*/
IF OBJECT_ID('QYD_Basic_Wh') IS NOT NULL
DROP TABLE QYD_Basic_Wh
GO

CREATE TABLE [QYD_Basic_Wh] (
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
		--是否是否库位
	[IsStoreBin] int DEFAULT 0,
		--面积
	[Area] decimal(24,9),
	--容积
	[Volume] decimal(24,9),
	--供应商
	[Supplier] bigint,
		--客户
	[Customer] bigint,
		--组织
	[Org] bigint,
	--地址
	[Address] nvarchar(100),
	PRIMARY KEY([ID])
);
GO


/**
库区
*/
IF OBJECT_ID('QYD_Basic_WhBinGroup') IS NOT NULL
DROP TABLE QYD_Basic_WhBinGroup
GO

CREATE TABLE [QYD_Basic_WhBinGroup] (
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
		--面积
	[Area] decimal(24,9),
	--容积
	[Volume] decimal(24,9),
	--仓库
	[Wh] bigint,
		--组织
	[Org] bigint,
	--地址
	PRIMARY KEY([ID])
);
GO



/**
货位
*/
IF OBJECT_ID('QYD_Basic_WhSh') IS NOT NULL
DROP TABLE QYD_Basic_WhSh
GO

CREATE TABLE [QYD_Basic_WhSh] (
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
		--是否拣货货位
	[IsWhSh] int DEFAULT 0,
		--面积
	[Area] decimal(24,9),
	--容积
	[Volume] decimal(24,9),
	--仓库
	[Wh] bigint,
	--库位
	[WhBinGroup] bigint,
		--组织
	[Org] bigint,
	PRIMARY KEY([ID])
);
GO



/**
物料
*/
IF OBJECT_ID('QYD_Basic_Item') IS NOT NULL
DROP TABLE QYD_Basic_Item
GO

CREATE TABLE [QYD_Basic_Item] (
	[ID] BIGINT NOT NULL UNIQUE,
	-- 版本号
	[SysVersion] BIGINT DEFAULT 0,
	-- 创建时间
	[CreatedTime] DATETIME DEFAULT GETDATE(),
	-- 创建人
	[CreatedBy] VARCHAR(50),
	-- 编码
	[Code] VARCHAR(50),
		-- 旧编码
	[Code1] VARCHAR(50),
	-- 名称
	[Name] VARCHAR(50),
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
	--规格
	[SPECS] nvarchar(100),
		--是否生效
	[IsEffective] int DEFAULT 0,
		--库存分类
	[StockCategory] bigint,
	--单位
	[UOM] bigint,
	--副单位
	[BaseUOM] bigint,
		--组织
	[Org] bigint,
	--主副单位转化系数
	[RatioToBase] decimal(24,9),
	--描述
	[Description] VARCHAR(255),
		--物料形态属性
	[ItemFormAttribute] int DEFAULT 0,
		--可销售
	[IsSalesEnable] int DEFAULT 0,
			--可生产
	[IsBuildEnable] int DEFAULT 0,
			--可采购
	[IsPurchaseEnable] int DEFAULT 0,
			--可委外
	[IsOutsideOperationEnable] int DEFAULT 0,
	--图片
	[Picture] VARCHAR(255),
				--是否批次管理
	[IsLot] int DEFAULT 0,
				--是否质检
	[IsQc] int DEFAULT 0,
				--是否质保期管理
	[IsQgPeriod] int DEFAULT 0,
		--质保天数
	[QgDay] int,
		--质保预警天数
	[QgAlterDay] int,
		--质保期单位
	[QgAlterDayUom] bigint,
		--默认存储地点
	[Warehouse] bigint,
		--标准包装数量
	[PackagQty] decimal(24,9),
		--最小采购量
	[MinRcvQty] decimal(24,9),
		--采购周期
	[PurPeriod] int,
		--供应商
	[Supplier] bigint,
		--采购周期单位
	[PurPeriodUom] bigint,
		--生产批量
	[MoBatch] int,
		--生产部门
	[MoDept] bigint,
	PRIMARY KEY([ID])
);
GO