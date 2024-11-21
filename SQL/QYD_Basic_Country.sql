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