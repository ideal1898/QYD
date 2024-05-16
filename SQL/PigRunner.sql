
--������SQL SERVER
--��¼
IF OBJECT_ID('Base_Sys_Login') IS NOT NULL
DROP TABLE Base_Sys_Login
GO

CREATE TABLE Base_Sys_Login(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	Account BIGINT,--�û�ID
	Username VARCHAR(50),--�û���
	NickName VARCHAR(50),--�ǳ�
	Token VARCHAR(800),--����
	Expiretime DATETIME,--����ʱ��
	IsAdmin BIT,--����Ա
	IsActive BIT--��Ч
)
GO
--�û�
IF OBJECT_ID('Base_Sys_User') IS NOT NULL
DROP TABLE Base_Sys_User
GO

CREATE TABLE Base_Sys_User(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	Username VARCHAR(50),--�û���
	NickName VARCHAR(50),--�ǳ�
	Password VARCHAR(100),--����
	IsAdmin BIT,--����Ա
	IsActive BIT,--��Ч
	Email VARCHAR(50),--�ʼ�
	Phone VARCHAR(20),--�ֻ���
	MainUrl VARCHAR(20),--��ҳ
	Avatar VARCHAR(120)--��ҳ
)
GO

--�˵�
--�û�
IF OBJECT_ID('Base_Sys_Menu') IS NOT NULL
DROP TABLE Base_Sys_Menu
GO

CREATE TABLE Base_Sys_Menu(
	ID BIGINT PRIMARY KEY, --��ʶ
	SysVersion BIGINT DEFAULT 0, --�汾
	CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
	CreatedBy VARCHAR(50) DEFAULT '',--������
	Path VARCHAR(50),--�û���
	Name VARCHAR(50),--�ǳ�
	Component VARCHAR(100),--���
	Redirect VARCHAR(50), --����
	IsActive BIT,--��Ч
	Icon VARCHAR(50), --ͼ��
	Title VARCHAR(150), --����
	IsLink BIT, --�ⲿ����
	IsHide BIT,--��ʾ
	IsFull BIT,--ȫ��
	IsAffix BIT,--
	IsKeepAlive BIT--����
)
