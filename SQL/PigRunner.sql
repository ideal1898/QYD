
--创建表：SQL SERVER
--登录
IF OBJECT_ID('Base_Sys_Login') IS NOT NULL
DROP TABLE Base_Sys_Login
GO

CREATE TABLE Base_Sys_Login(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	Account BIGINT,--用户ID
	Username VARCHAR(50),--用户名
	NickName VARCHAR(50),--昵称
	Token VARCHAR(800),--令牌
	Expiretime DATETIME,--过期时间
	IsAdmin BIT,--管理员
	IsActive BIT--生效
)
GO
--用户
IF OBJECT_ID('Base_Sys_User') IS NOT NULL
DROP TABLE Base_Sys_User
GO

CREATE TABLE Base_Sys_User(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	Username VARCHAR(50),--用户名
	NickName VARCHAR(50),--昵称
	Password VARCHAR(100),--密码
	IsAdmin BIT,--管理员
	IsActive BIT,--生效
	Email VARCHAR(50),--邮件
	Phone VARCHAR(20),--手机号
	MainUrl VARCHAR(20),--主页
	Avatar VARCHAR(120)--主页
)
GO

--菜单
--用户
IF OBJECT_ID('Base_Sys_Menu') IS NOT NULL
DROP TABLE Base_Sys_Menu
GO

CREATE TABLE Base_Sys_Menu(
	ID BIGINT PRIMARY KEY, --标识
	SysVersion BIGINT DEFAULT 0, --版本
	CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
	CreatedBy VARCHAR(50) DEFAULT '',--创建人
	Path VARCHAR(50),--用户名
	Name VARCHAR(50),--昵称
	Component VARCHAR(100),--组件
	Redirect VARCHAR(50), --定向
	IsActive BIT,--生效
	Icon VARCHAR(50), --图标
	Title VARCHAR(150), --标题
	IsLink BIT, --外部连接
	IsHide BIT,--显示
	IsFull BIT,--全屏
	IsAffix BIT,--
	IsKeepAlive BIT--缓存
)
