
--����
IF OBJECT_ID('QYD_Basic_Currency') IS NOT NULL
DROP TABLE QYD_Basic_Currency
GO

CREATE TABLE QYD_Basic_Currency(
ID BIGINT PRIMARY KEY, --��ʶ
SysVersion BIGINT DEFAULT 0, --�汾
CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
CreatedBy VARCHAR(50) DEFAULT '',--������
	--�޸���
	[ModifiedBy] VARCHAR(50),
	--�޸�ʱ��
	[ModifiedTime] datetime,
Code VARCHAR(50) DEFAULT '',--����
Name VARCHAR(50) DEFAULT ''--����
)
GO

--�����������
insert into QYD_Basic_Currency values(1,0,GETDATE(),'ϵͳ����Ա','CNY','�����')
insert into QYD_Basic_Currency values(2,0,GETDATE(),'ϵͳ����Ա','TWD','��̨��')
insert into QYD_Basic_Currency values(3,0,GETDATE(),'ϵͳ����Ա','HKD','��Ԫ')
insert into QYD_Basic_Currency values(4,0,GETDATE(),'ϵͳ����Ա','JPY','��Ԫ')
insert into QYD_Basic_Currency values(5,0,GETDATE(),'ϵͳ����Ա','EUR','ŷԪ')
insert into QYD_Basic_Currency values(6,0,GETDATE(),'ϵͳ����Ա','DEM','���')
insert into QYD_Basic_Currency values(7,0,GETDATE(),'ϵͳ����Ա','GBP','Ӣ��')
insert into QYD_Basic_Currency values(8,0,GETDATE(),'ϵͳ����Ա','FRF','����')
insert into QYD_Basic_Currency values(9,0,GETDATE(),'ϵͳ����Ա','USD','��Ԫ')
insert into QYD_Basic_Currency values(10,0,GETDATE(),'ϵͳ����Ա','CAD','��Ԫ')

--ʱ��
IF OBJECT_ID('QYD_Basic_TimeZone') IS NOT NULL
DROP TABLE QYD_Basic_TimeZone
GO

CREATE TABLE QYD_Basic_TimeZone(
ID BIGINT PRIMARY KEY, --��ʶ
SysVersion BIGINT DEFAULT 0, --�汾
CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
CreatedBy VARCHAR(50) DEFAULT '',--������
--�޸���
[ModifiedBy] VARCHAR(50),
--�޸�ʱ��
[ModifiedTime] datetime,
Code VARCHAR(100) DEFAULT '',--����
Name VARCHAR(100) DEFAULT ''--����
)
GO

insert into QYD_Basic_TimeZone values(1,0,GETDATE(),'ϵͳ����Ա','Afghanistan Standard Time','(UTC+04:30)������')
insert into QYD_Basic_TimeZone values(2,0,GETDATE(),'ϵͳ����Ա','Alaskan Standard Time','(UTC-09:00)����˹��')
insert into QYD_Basic_TimeZone values(3,0,GETDATE(),'ϵͳ����Ա','Arab Standard Time','(UTC+03:00)�����أ����ŵ�')
insert into QYD_Basic_TimeZone values(4,0,GETDATE(),'ϵͳ����Ա','Arabian Standard Time','(UTC+04:00)�������ȣ���˹����')
insert into QYD_Basic_TimeZone values(5,0,GETDATE(),'ϵͳ����Ա','Arabic Standard Time','(UTC+03:00)�͸��')

insert into QYD_Basic_TimeZone values(6,0,GETDATE(),'ϵͳ����Ա','Argentina Standard Time','(UTC-03:00)����ŵ˹����˹')

insert into QYD_Basic_TimeZone values(7,0,GETDATE(),'ϵͳ����Ա', 'Atlantic Standard Time','(UTC-04:00)������ʱ��(���ô�)')
insert into QYD_Basic_TimeZone values(8,0,GETDATE(),'ϵͳ����Ա','AUS Central Standard Time','(UTC+09:30)�����')
insert into QYD_Basic_TimeZone values(9,0,GETDATE(),'ϵͳ����Ա','AUS Eastern Standard Time','(UTC+10:00)��������ī������Ϥ��')
insert into QYD_Basic_TimeZone values(10,0,GETDATE(),'ϵͳ����Ա','Azerbaijan Standard Time','(UTC+04:00)�Ϳ�')
insert into QYD_Basic_TimeZone values(11,0,GETDATE(),'ϵͳ����Ա','Azores Standard Time','(UTC-01:00)���ٶ�Ⱥ��')
insert into QYD_Basic_TimeZone values(12,0,GETDATE(),'ϵͳ����Ա','Bahia Standard Time','(UTC-03:00)�����߶�')
insert into QYD_Basic_TimeZone values(13,0,GETDATE(),'ϵͳ����Ա','Bangladesh Standard Time','(UTC+06:00)�￨')
insert into QYD_Basic_TimeZone values(14,0,GETDATE(),'ϵͳ����Ա','Belarus Standard Time','(UTC+03:00)��˹��')
insert into QYD_Basic_TimeZone values(15,0,GETDATE(),'ϵͳ����Ա','Canada Central Standard Time','(UTC-06:00)��˹������')
insert into QYD_Basic_TimeZone values(16,0,GETDATE(),'ϵͳ����Ա','Cape Verde Standard Time','(UTC-01:00)��ý�Ⱥ��')
insert into QYD_Basic_TimeZone values(17,0,GETDATE(),'ϵͳ����Ա','Caucasus Standard Time','(UTC+04:00)������')
insert into QYD_Basic_TimeZone values(18,0,GETDATE(),'ϵͳ����Ա','Cen. Australia Standard Time','(UTC+09:30)��������')
insert into QYD_Basic_TimeZone values(19,0,GETDATE(),'ϵͳ����Ա','Central America Standard Time','(UTC-06:00)������')
insert into QYD_Basic_TimeZone values(20,0,GETDATE(),'ϵͳ����Ա','Central Asia Standard Time','(UTC+06:00)��˹����')
insert into QYD_Basic_TimeZone values(21,0,GETDATE(),'ϵͳ����Ա','Central Brazilian Standard Time','(UTC-04:00)���ǰ�')
insert into QYD_Basic_TimeZone values(22,0,GETDATE(),'ϵͳ����Ա','Central Europe Standard Time','(UTC+01:00)���������£�������˹������������˹��¬�������ǣ�������')
insert into QYD_Basic_TimeZone values(23,0,GETDATE(),'ϵͳ����Ա','Central European Standard Time','(UTC+01:00)�������ѣ�˹�������ɳ�������ղ�')
insert into QYD_Basic_TimeZone values(24,0,GETDATE(),'ϵͳ����Ա','Central Pacific Standard Time','(UTC+11:00)������Ⱥ�����¿��������')
insert into QYD_Basic_TimeZone values(25,0,GETDATE(),'ϵͳ����Ա','Central Standard Time','(UTC-06:00)�в�ʱ��(�����ͼ��ô�)')
insert into QYD_Basic_TimeZone values(26,0,GETDATE(),'ϵͳ����Ա','Central Standard Time (Mexico)','(UTC-06:00)�ϴ���������ī����ǣ�������')
insert into QYD_Basic_TimeZone values(27,0,GETDATE(),'ϵͳ����Ա','China Standard Time','(UTC+08:00)���������죬����ر�����������³ľ��')
insert into QYD_Basic_TimeZone values(28,0,GETDATE(),'ϵͳ����Ա','Dateline Standard Time','(UTC-12:00)�������ڱ������')
insert into QYD_Basic_TimeZone values(29,0,GETDATE(),'ϵͳ����Ա','E. Africa Standard Time','(UTC+03:00)���ޱ�')
insert into QYD_Basic_TimeZone values(30,0,GETDATE(),'ϵͳ����Ա','E. Australia Standard Time','(UTC+10:00)����˹��')
insert into QYD_Basic_TimeZone values(31,0,GETDATE(),'ϵͳ����Ա','E. Europe Standard Time','(UTC+02:00)��ŷ')
insert into QYD_Basic_TimeZone values(32,0,GETDATE(),'ϵͳ����Ա','E. South America Standard Time','(UTC-03:00)��������')
insert into QYD_Basic_TimeZone values(33,0,GETDATE(),'ϵͳ����Ա','Eastern Standard Time','(UTC-05:00)����ʱ��(�����ͼ��ô�)')
insert into QYD_Basic_TimeZone values(34,0,GETDATE(),'ϵͳ����Ա','Eastern Standard Time (Mexico)','(UTC-05:00)��ͼ���')
insert into QYD_Basic_TimeZone values(35,0,GETDATE(),'ϵͳ����Ա','Egypt Standard Time','(UTC+02:00)����')
insert into QYD_Basic_TimeZone values(36,0,GETDATE(),'ϵͳ����Ա','Ekaterinburg Standard Time','(UTC+05:00)Ҷ�����ձ�(RTZ 4)')
insert into QYD_Basic_TimeZone values(37,0,GETDATE(),'ϵͳ����Ա','Fiji Standard Time','(UTC+12:00)쳼�')
insert into QYD_Basic_TimeZone values(38,0,GETDATE(),'ϵͳ����Ա','FLE Standard Time','(UTC+02:00)�ն���������������ӣ������ǣ����֣�ά��Ŧ˹')
insert into QYD_Basic_TimeZone values(39,0,GETDATE(),'ϵͳ����Ա','Georgian Standard Time','(UTC+04:00)�ڱ���˹')
insert into QYD_Basic_TimeZone values(40,0,GETDATE(),'ϵͳ����Ա','GMT Standard Time','(UTC)�����֣�����������˹�����׶�')
insert into QYD_Basic_TimeZone values(41,0,GETDATE(),'ϵͳ����Ա','Greenland Standard Time','(UTC-03:00)������')
insert into QYD_Basic_TimeZone values(42,0,GETDATE(),'ϵͳ����Ա','Greenwich Standard Time','(UTC)����ά�ǣ��׿���δ��')
insert into QYD_Basic_TimeZone values(43,0,GETDATE(),'ϵͳ����Ա','GTB Standard Time','(UTC+02:00)�ŵ䣬������˹��')
insert into QYD_Basic_TimeZone values(44,0,GETDATE(),'ϵͳ����Ա','Hawaiian Standard Time','(UTC-10:00)������')
insert into QYD_Basic_TimeZone values(45,0,GETDATE(),'ϵͳ����Ա','India Standard Time','(UTC+05:30)���Σ��Ӷ����������µ���')
insert into QYD_Basic_TimeZone values(46,0,GETDATE(),'ϵͳ����Ա','Iran Standard Time','(UTC+03:30)�º���')
insert into QYD_Basic_TimeZone values(47,0,GETDATE(),'ϵͳ����Ա','Israel Standard Time','(UTC+02:00)Ү·����')
insert into QYD_Basic_TimeZone values(48,0,GETDATE(),'ϵͳ����Ա','Jordan Standard Time','(UTC+02:00)����')
insert into QYD_Basic_TimeZone values(49,0,GETDATE(),'ϵͳ����Ա','Kaliningrad Standard Time','(UTC+02:00)����������(RTZ 1)')
insert into QYD_Basic_TimeZone values(50,0,GETDATE(),'ϵͳ����Ա','Kamchatka Standard Time','(UTC+12:00)�˵��ް͸����˹��-����� - ����')
insert into QYD_Basic_TimeZone values(51,0,GETDATE(),'ϵͳ����Ա','Korea Standard Time','(UTC+09:00)�׶�')
insert into QYD_Basic_TimeZone values(52,0,GETDATE(),'ϵͳ����Ա','Libya Standard Time','(UTC+02:00)���貨��')
insert into QYD_Basic_TimeZone values(53,0,GETDATE(),'ϵͳ����Ա','Line Islands Standard Time','(UTC+14:00)ʥ����')
insert into QYD_Basic_TimeZone values(54,0,GETDATE(),'ϵͳ����Ա','Magadan Standard Time','(UTC+10:00)��ӵ�')
insert into QYD_Basic_TimeZone values(55,0,GETDATE(),'ϵͳ����Ա','Mauritius Standard Time','(UTC+04:00)·�׸�')
insert into QYD_Basic_TimeZone values(56,0,GETDATE(),'ϵͳ����Ա','Mid-Atlantic Standard Time','(UTC-02:00)�д����� - ����')
insert into QYD_Basic_TimeZone values(57,0,GETDATE(),'ϵͳ����Ա','Middle East Standard Time','(UTC+02:00)��³��')
insert into QYD_Basic_TimeZone values(58,0,GETDATE(),'ϵͳ����Ա','Montevideo Standard Time','(UTC-03:00)�ɵ�ά����')
insert into QYD_Basic_TimeZone values(59,0,GETDATE(),'ϵͳ����Ա','Morocco Standard Time','(UTC)����������')
insert into QYD_Basic_TimeZone values(60,0,GETDATE(),'ϵͳ����Ա','Mountain Standard Time','(UTC-07:00)ɽ��ʱ��(�����ͼ��ô�)')
insert into QYD_Basic_TimeZone values(61,0,GETDATE(),'ϵͳ����Ա','Mountain Standard Time (Mexico)','(UTC-07:00)�����ߣ�����˹����������')
insert into QYD_Basic_TimeZone values(62,0,GETDATE(),'ϵͳ����Ա','Myanmar Standard Time','(UTC+06:30)����')
insert into QYD_Basic_TimeZone values(63,0,GETDATE(),'ϵͳ����Ա','N. Central Asia Standard Time','(UTC+06:00)����������(RTZ 5)')
insert into QYD_Basic_TimeZone values(64,0,GETDATE(),'ϵͳ����Ա','Namibia Standard Time','(UTC+01:00)�µúͿ�')
insert into QYD_Basic_TimeZone values(65,0,GETDATE(),'ϵͳ����Ա','Nepal Standard Time','(UTC+05:45)�ӵ�����')
insert into QYD_Basic_TimeZone values(66,0,GETDATE(),'ϵͳ����Ա','New Zealand Standard Time','(UTC+12:00)�¿����������')
insert into QYD_Basic_TimeZone values(67,0,GETDATE(),'ϵͳ����Ա','Newfoundland Standard Time','(UTC-03:30)Ŧ����')
insert into QYD_Basic_TimeZone values(68,0,GETDATE(),'ϵͳ����Ա','North Asia East Standard Time','(UTC+08:00)������Ŀ�(RTZ 7)')
insert into QYD_Basic_TimeZone values(69,0,GETDATE(),'ϵͳ����Ա','North Asia Standard Time','(UTC+07:00)����˹ŵ�Ƕ�˹��(RTZ 6)')
insert into QYD_Basic_TimeZone values(70,0,GETDATE(),'ϵͳ����Ա','Pacific SA Standard Time','(UTC-03:00)ʥ���Ǹ�')
insert into QYD_Basic_TimeZone values(71,0,GETDATE(),'ϵͳ����Ա','Pacific Standard Time','(UTC-08:00)̫ƽ��ʱ��(�����ͼ��ô�)')
insert into QYD_Basic_TimeZone values(72,0,GETDATE(),'ϵͳ����Ա','Pacific Standard Time (Mexico)','(UTC-08:00)�¼�����������')
insert into QYD_Basic_TimeZone values(73,0,GETDATE(),'ϵͳ����Ա','Pakistan Standard Time','(UTC+05:00)��˹������������')
insert into QYD_Basic_TimeZone values(74,0,GETDATE(),'ϵͳ����Ա','Paraguay Standard Time','(UTC-04:00)����ɭ')
insert into QYD_Basic_TimeZone values(75,0,GETDATE(),'ϵͳ����Ա','Romance Standard Time','(UTC+01:00)��³�������籾��������������')
insert into QYD_Basic_TimeZone values(76,0,GETDATE(),'ϵͳ����Ա','Russia Time Zone 10','(UTC+11:00)�ǿ�����(RTZ 10)')
insert into QYD_Basic_TimeZone values(77,0,GETDATE(),'ϵͳ����Ա','Russia Time Zone 11','(UTC+12:00)���ɵ¶����˵��ް͸����˹��-�����(RTZ 11)')
insert into QYD_Basic_TimeZone values(78,0,GETDATE(),'ϵͳ����Ա','Russia Time Zone 3','(UTC+04:00)���ȷ�˹�ˣ�������(RTZ 3)')
insert into QYD_Basic_TimeZone values(79,0,GETDATE(),'ϵͳ����Ա','Russian Standard Time','(UTC+03:00)Ī˹�ƣ�ʥ�˵ñ��������Ӹ���(RTZ 2)')
insert into QYD_Basic_TimeZone values(80,0,GETDATE(),'ϵͳ����Ա','SA Eastern Standard Time','(UTC-03:00)���磬��������')
insert into QYD_Basic_TimeZone values(81,0,GETDATE(),'ϵͳ����Ա','SA Pacific Standard Time','(UTC-05:00)������������࣬��²��ʿ�')
insert into QYD_Basic_TimeZone values(82,0,GETDATE(),'ϵͳ����Ա','SA Western Standard Time','(UTC-04:00)���ζأ�����˹�����˹��ʥ����')
insert into QYD_Basic_TimeZone values(83,0,GETDATE(),'ϵͳ����Ա','Samoa Standard Time','(UTC+13:00)��Ħ��Ⱥ��')
insert into QYD_Basic_TimeZone values(84,0,GETDATE(),'ϵͳ����Ա','SE Asia Standard Time','(UTC+07:00)���ȣ����ڣ��żӴ�')
insert into QYD_Basic_TimeZone values(85,0,GETDATE(),'ϵͳ����Ա','Singapore Standard Time','(UTC+08:00)��¡�£��¼���')
insert into QYD_Basic_TimeZone values(86,0,GETDATE(),'ϵͳ����Ա','South Africa Standard Time','(UTC+02:00)�����ף�����������')
insert into QYD_Basic_TimeZone values(87,0,GETDATE(),'ϵͳ����Ա','Sri Lanka Standard Time','(UTC+05:30)˹������׵�����')
insert into QYD_Basic_TimeZone values(88,0,GETDATE(),'ϵͳ����Ա','Syria Standard Time','(UTC+02:00)����ʿ��')
insert into QYD_Basic_TimeZone values(89,0,GETDATE(),'ϵͳ����Ա','Taipei Standard Time','(UTC+08:00)̨��')
insert into QYD_Basic_TimeZone values(90,0,GETDATE(),'ϵͳ����Ա','Tasmania Standard Time','(UTC+10:00)������')
insert into QYD_Basic_TimeZone values(91,0,GETDATE(),'ϵͳ����Ա','Tokyo Standard Time','(UTC+09:00)���棬���ϣ�����')
insert into QYD_Basic_TimeZone values(92,0,GETDATE(),'ϵͳ����Ա','Tonga Standard Time','(UTC+13:00)Ŭ�Ⱒ�巨')
insert into QYD_Basic_TimeZone values(93,0,GETDATE(),'ϵͳ����Ա','Turkey Standard Time','(UTC+02:00)��˹̹����')
insert into QYD_Basic_TimeZone values(94,0,GETDATE(),'ϵͳ����Ա','Ulaanbaatar Standard Time','(UTC+08:00)��������')
insert into QYD_Basic_TimeZone values(95,0,GETDATE(),'ϵͳ����Ա','US Eastern Standard Time','(UTC-05:00)ӡ�ذ�����(����)')
insert into QYD_Basic_TimeZone values(96,0,GETDATE(),'ϵͳ����Ա','US Mountain Standard Time','(UTC-07:00)����ɣ��')
insert into QYD_Basic_TimeZone values(97,0,GETDATE(),'ϵͳ����Ա','UTC','(UTC)Э������ʱ')
insert into QYD_Basic_TimeZone values(98,0,GETDATE(),'ϵͳ����Ա','UTC+12','(UTC+12:00)Э������ʱ+12')
insert into QYD_Basic_TimeZone values(99,0,GETDATE(),'ϵͳ����Ա','UTC-02','(UTC-02:00)Э������ʱ-02')
insert into QYD_Basic_TimeZone values(100,0,GETDATE(),'ϵͳ����Ա','UTC-11','(UTC-11:00)Э������ʱ-11')
insert into QYD_Basic_TimeZone values(101,0,GETDATE(),'ϵͳ����Ա','Venezuela Standard Time','(UTC-04:30)������˹')
insert into QYD_Basic_TimeZone values(102,0,GETDATE(),'ϵͳ����Ա','Vladivostok Standard Time','(UTC+10:00)��������˹�пˣ���ӵ�(RTZ 9)')
insert into QYD_Basic_TimeZone values(103,0,GETDATE(),'ϵͳ����Ա','W. Australia Standard Time','(UTC+08:00)��˹')
insert into QYD_Basic_TimeZone values(104,0,GETDATE(),'ϵͳ����Ա','W. Central Africa Standard Time','(UTC+01:00)�з�����')
insert into QYD_Basic_TimeZone values(105,0,GETDATE(),'ϵͳ����Ա','W. Europe Standard Time','(UTC+01:00)��ķ˹�ص������֣������ᣬ����˹�¸��Ħ��άҲ��')
insert into QYD_Basic_TimeZone values(106,0,GETDATE(),'ϵͳ����Ա','West Asia Standard Time','(UTC+05:00)��ʲ���͵£���ʲ��')
insert into QYD_Basic_TimeZone values(107,0,GETDATE(),'ϵͳ����Ա','West Pacific Standard Time','(UTC+10:00)�ص���Ī���ȱȸ�')
insert into QYD_Basic_TimeZone values(108,0,GETDATE(),'ϵͳ����Ա','Yakutsk Standard Time','(UTC+09:00)�ſ�Ŀ�(RTZ 8)')
insert into QYD_Basic_TimeZone values(109,0,GETDATE(),'ϵͳ����Ա','UTC','UTC+8:00(�������Ϻ������졢��³ľ��)')



--��ַ��ʽ
IF OBJECT_ID('QYD_Basic_CountryFormat') IS NOT NULL
DROP TABLE QYD_Basic_CountryFormat
GO

CREATE TABLE QYD_Basic_CountryFormat(
ID BIGINT PRIMARY KEY, --��ʶ
SysVersion BIGINT DEFAULT 0, --�汾
CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
CreatedBy VARCHAR(50) DEFAULT '',--������
--�޸���
[ModifiedBy] VARCHAR(50),
--�޸�ʱ��
[ModifiedTime] datetime,
Code VARCHAR(50) DEFAULT '',--����
Name VARCHAR(50) DEFAULT ''--����
)
GO

insert into QYD_Basic_CountryFormat values(1,0,GETDATE(),'ϵͳ����Ա','China','�й�')
insert into QYD_Basic_CountryFormat values(2,0,GETDATE(),'ϵͳ����Ա','TaiWan','�й�̨��')
insert into QYD_Basic_CountryFormat values(3,0,GETDATE(),'ϵͳ����Ա','America','����')
insert into QYD_Basic_CountryFormat values(4,0,GETDATE(),'ϵͳ����Ա','Hongkong','�й����')
insert into QYD_Basic_CountryFormat values(5,0,GETDATE(),'ϵͳ����Ա','Thailand','̩��')
insert into QYD_Basic_CountryFormat values(6,0,GETDATE(),'ϵͳ����Ա','Australia','�Ĵ�����')

--����
IF OBJECT_ID('QYD_Basic_Language') IS NOT NULL
DROP TABLE QYD_Basic_Language
GO

CREATE TABLE QYD_Basic_Language(
ID BIGINT PRIMARY KEY, --��ʶ
SysVersion BIGINT DEFAULT 0, --�汾
CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
CreatedBy VARCHAR(50) DEFAULT '',--������
--�޸���
[ModifiedBy] VARCHAR(50),
--�޸�ʱ��
[ModifiedTime] datetime,
Code VARCHAR(50) DEFAULT '',--����
Name VARCHAR(50) DEFAULT ''--����
)
GO

insert into QYD_Basic_Language values(1,0,GETDATE(),'ϵͳ����Ա','zh-CN','��������')

--������ʽ
IF OBJECT_ID('QYD_Basic_NameFormat') IS NOT NULL
DROP TABLE QYD_Basic_NameFormat
GO

CREATE TABLE QYD_Basic_NameFormat(
ID BIGINT PRIMARY KEY, --��ʶ
SysVersion BIGINT DEFAULT 0, --�汾
CreatedTime DATETIME DEFAULT GETDATE(),--����ʱ��
CreatedBy VARCHAR(50) DEFAULT '',--������
--�޸���
[ModifiedBy] VARCHAR(50),
--�޸�ʱ��
[ModifiedTime] datetime,
Code VARCHAR(50) DEFAULT '',--����
Name VARCHAR(50) DEFAULT ''--����
)
GO

insert into QYD_Basic_NameFormat values(1,0,GETDATE(),'ϵͳ����Ա','001','��-��')
insert into QYD_Basic_NameFormat values(2,0,GETDATE(),'ϵͳ����Ա','002','��-��')