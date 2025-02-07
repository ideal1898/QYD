
--币种
IF OBJECT_ID('QYD_Basic_Currency') IS NOT NULL
DROP TABLE QYD_Basic_Currency
GO

CREATE TABLE QYD_Basic_Currency(
ID BIGINT PRIMARY KEY, --标识
SysVersion BIGINT DEFAULT 0, --版本
CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
CreatedBy VARCHAR(50) DEFAULT '',--创建人
	--修改人
	[ModifiedBy] VARCHAR(50),
	--修改时间
	[ModifiedTime] datetime,
Code VARCHAR(50) DEFAULT '',--编码
Name VARCHAR(50) DEFAULT ''--名称
)
GO

--插入币种数据
insert into QYD_Basic_Currency values(1,0,GETDATE(),'系统管理员','CNY','人民币')
insert into QYD_Basic_Currency values(2,0,GETDATE(),'系统管理员','TWD','新台币')
insert into QYD_Basic_Currency values(3,0,GETDATE(),'系统管理员','HKD','港元')
insert into QYD_Basic_Currency values(4,0,GETDATE(),'系统管理员','JPY','日元')
insert into QYD_Basic_Currency values(5,0,GETDATE(),'系统管理员','EUR','欧元')
insert into QYD_Basic_Currency values(6,0,GETDATE(),'系统管理员','DEM','马克')
insert into QYD_Basic_Currency values(7,0,GETDATE(),'系统管理员','GBP','英镑')
insert into QYD_Basic_Currency values(8,0,GETDATE(),'系统管理员','FRF','法郎')
insert into QYD_Basic_Currency values(9,0,GETDATE(),'系统管理员','USD','美元')
insert into QYD_Basic_Currency values(10,0,GETDATE(),'系统管理员','CAD','加元')

--时区
IF OBJECT_ID('QYD_Basic_TimeZone') IS NOT NULL
DROP TABLE QYD_Basic_TimeZone
GO

CREATE TABLE QYD_Basic_TimeZone(
ID BIGINT PRIMARY KEY, --标识
SysVersion BIGINT DEFAULT 0, --版本
CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
CreatedBy VARCHAR(50) DEFAULT '',--创建人
--修改人
[ModifiedBy] VARCHAR(50),
--修改时间
[ModifiedTime] datetime,
Code VARCHAR(100) DEFAULT '',--编码
Name VARCHAR(100) DEFAULT ''--名称
)
GO

insert into QYD_Basic_TimeZone values(1,0,GETDATE(),'系统管理员','Afghanistan Standard Time','(UTC+04:30)喀布尔')
insert into QYD_Basic_TimeZone values(2,0,GETDATE(),'系统管理员','Alaskan Standard Time','(UTC-09:00)阿拉斯加')
insert into QYD_Basic_TimeZone values(3,0,GETDATE(),'系统管理员','Arab Standard Time','(UTC+03:00)科威特，利雅得')
insert into QYD_Basic_TimeZone values(4,0,GETDATE(),'系统管理员','Arabian Standard Time','(UTC+04:00)阿布扎比，马斯喀特')
insert into QYD_Basic_TimeZone values(5,0,GETDATE(),'系统管理员','Arabic Standard Time','(UTC+03:00)巴格达')

insert into QYD_Basic_TimeZone values(6,0,GETDATE(),'系统管理员','Argentina Standard Time','(UTC-03:00)布宜诺斯艾利斯')

insert into QYD_Basic_TimeZone values(7,0,GETDATE(),'系统管理员', 'Atlantic Standard Time','(UTC-04:00)大西洋时间(加拿大)')
insert into QYD_Basic_TimeZone values(8,0,GETDATE(),'系统管理员','AUS Central Standard Time','(UTC+09:30)达尔文')
insert into QYD_Basic_TimeZone values(9,0,GETDATE(),'系统管理员','AUS Eastern Standard Time','(UTC+10:00)堪培拉，墨尔本，悉尼')
insert into QYD_Basic_TimeZone values(10,0,GETDATE(),'系统管理员','Azerbaijan Standard Time','(UTC+04:00)巴库')
insert into QYD_Basic_TimeZone values(11,0,GETDATE(),'系统管理员','Azores Standard Time','(UTC-01:00)亚速尔群岛')
insert into QYD_Basic_TimeZone values(12,0,GETDATE(),'系统管理员','Bahia Standard Time','(UTC-03:00)萨尔瓦多')
insert into QYD_Basic_TimeZone values(13,0,GETDATE(),'系统管理员','Bangladesh Standard Time','(UTC+06:00)达卡')
insert into QYD_Basic_TimeZone values(14,0,GETDATE(),'系统管理员','Belarus Standard Time','(UTC+03:00)明斯克')
insert into QYD_Basic_TimeZone values(15,0,GETDATE(),'系统管理员','Canada Central Standard Time','(UTC-06:00)萨斯喀彻温')
insert into QYD_Basic_TimeZone values(16,0,GETDATE(),'系统管理员','Cape Verde Standard Time','(UTC-01:00)佛得角群岛')
insert into QYD_Basic_TimeZone values(17,0,GETDATE(),'系统管理员','Caucasus Standard Time','(UTC+04:00)埃里温')
insert into QYD_Basic_TimeZone values(18,0,GETDATE(),'系统管理员','Cen. Australia Standard Time','(UTC+09:30)阿德莱德')
insert into QYD_Basic_TimeZone values(19,0,GETDATE(),'系统管理员','Central America Standard Time','(UTC-06:00)中美洲')
insert into QYD_Basic_TimeZone values(20,0,GETDATE(),'系统管理员','Central Asia Standard Time','(UTC+06:00)阿斯塔纳')
insert into QYD_Basic_TimeZone values(21,0,GETDATE(),'系统管理员','Central Brazilian Standard Time','(UTC-04:00)库亚巴')
insert into QYD_Basic_TimeZone values(22,0,GETDATE(),'系统管理员','Central Europe Standard Time','(UTC+01:00)贝尔格莱德，布拉迪斯拉发，布达佩斯，卢布尔雅那，布拉格')
insert into QYD_Basic_TimeZone values(23,0,GETDATE(),'系统管理员','Central European Standard Time','(UTC+01:00)萨拉热窝，斯科普里，华沙，萨格勒布')
insert into QYD_Basic_TimeZone values(24,0,GETDATE(),'系统管理员','Central Pacific Standard Time','(UTC+11:00)所罗门群岛，新喀里多尼亚')
insert into QYD_Basic_TimeZone values(25,0,GETDATE(),'系统管理员','Central Standard Time','(UTC-06:00)中部时间(美国和加拿大)')
insert into QYD_Basic_TimeZone values(26,0,GETDATE(),'系统管理员','Central Standard Time (Mexico)','(UTC-06:00)瓜达拉哈拉，墨西哥城，蒙特雷')
insert into QYD_Basic_TimeZone values(27,0,GETDATE(),'系统管理员','China Standard Time','(UTC+08:00)北京，重庆，香港特别行政区，乌鲁木齐')
insert into QYD_Basic_TimeZone values(28,0,GETDATE(),'系统管理员','Dateline Standard Time','(UTC-12:00)国际日期变更线西')
insert into QYD_Basic_TimeZone values(29,0,GETDATE(),'系统管理员','E. Africa Standard Time','(UTC+03:00)内罗毕')
insert into QYD_Basic_TimeZone values(30,0,GETDATE(),'系统管理员','E. Australia Standard Time','(UTC+10:00)布里斯班')
insert into QYD_Basic_TimeZone values(31,0,GETDATE(),'系统管理员','E. Europe Standard Time','(UTC+02:00)东欧')
insert into QYD_Basic_TimeZone values(32,0,GETDATE(),'系统管理员','E. South America Standard Time','(UTC-03:00)巴西利亚')
insert into QYD_Basic_TimeZone values(33,0,GETDATE(),'系统管理员','Eastern Standard Time','(UTC-05:00)东部时间(美国和加拿大)')
insert into QYD_Basic_TimeZone values(34,0,GETDATE(),'系统管理员','Eastern Standard Time (Mexico)','(UTC-05:00)切图马尔')
insert into QYD_Basic_TimeZone values(35,0,GETDATE(),'系统管理员','Egypt Standard Time','(UTC+02:00)开罗')
insert into QYD_Basic_TimeZone values(36,0,GETDATE(),'系统管理员','Ekaterinburg Standard Time','(UTC+05:00)叶卡捷琳堡(RTZ 4)')
insert into QYD_Basic_TimeZone values(37,0,GETDATE(),'系统管理员','Fiji Standard Time','(UTC+12:00)斐济')
insert into QYD_Basic_TimeZone values(38,0,GETDATE(),'系统管理员','FLE Standard Time','(UTC+02:00)赫尔辛基，基辅，里加，索非亚，塔林，维尔纽斯')
insert into QYD_Basic_TimeZone values(39,0,GETDATE(),'系统管理员','Georgian Standard Time','(UTC+04:00)第比利斯')
insert into QYD_Basic_TimeZone values(40,0,GETDATE(),'系统管理员','GMT Standard Time','(UTC)都柏林，爱丁堡，里斯本，伦敦')
insert into QYD_Basic_TimeZone values(41,0,GETDATE(),'系统管理员','Greenland Standard Time','(UTC-03:00)格陵兰')
insert into QYD_Basic_TimeZone values(42,0,GETDATE(),'系统管理员','Greenwich Standard Time','(UTC)蒙罗维亚，雷克雅未克')
insert into QYD_Basic_TimeZone values(43,0,GETDATE(),'系统管理员','GTB Standard Time','(UTC+02:00)雅典，布加勒斯特')
insert into QYD_Basic_TimeZone values(44,0,GETDATE(),'系统管理员','Hawaiian Standard Time','(UTC-10:00)夏威夷')
insert into QYD_Basic_TimeZone values(45,0,GETDATE(),'系统管理员','India Standard Time','(UTC+05:30)钦奈，加尔各答，孟买，新德里')
insert into QYD_Basic_TimeZone values(46,0,GETDATE(),'系统管理员','Iran Standard Time','(UTC+03:30)德黑兰')
insert into QYD_Basic_TimeZone values(47,0,GETDATE(),'系统管理员','Israel Standard Time','(UTC+02:00)耶路撒冷')
insert into QYD_Basic_TimeZone values(48,0,GETDATE(),'系统管理员','Jordan Standard Time','(UTC+02:00)安曼')
insert into QYD_Basic_TimeZone values(49,0,GETDATE(),'系统管理员','Kaliningrad Standard Time','(UTC+02:00)加里宁格勒(RTZ 1)')
insert into QYD_Basic_TimeZone values(50,0,GETDATE(),'系统管理员','Kamchatka Standard Time','(UTC+12:00)彼得罗巴甫洛夫斯克-堪察加 - 旧用')
insert into QYD_Basic_TimeZone values(51,0,GETDATE(),'系统管理员','Korea Standard Time','(UTC+09:00)首尔')
insert into QYD_Basic_TimeZone values(52,0,GETDATE(),'系统管理员','Libya Standard Time','(UTC+02:00)的黎波里')
insert into QYD_Basic_TimeZone values(53,0,GETDATE(),'系统管理员','Line Islands Standard Time','(UTC+14:00)圣诞岛')
insert into QYD_Basic_TimeZone values(54,0,GETDATE(),'系统管理员','Magadan Standard Time','(UTC+10:00)马加丹')
insert into QYD_Basic_TimeZone values(55,0,GETDATE(),'系统管理员','Mauritius Standard Time','(UTC+04:00)路易港')
insert into QYD_Basic_TimeZone values(56,0,GETDATE(),'系统管理员','Mid-Atlantic Standard Time','(UTC-02:00)中大西洋 - 旧用')
insert into QYD_Basic_TimeZone values(57,0,GETDATE(),'系统管理员','Middle East Standard Time','(UTC+02:00)贝鲁特')
insert into QYD_Basic_TimeZone values(58,0,GETDATE(),'系统管理员','Montevideo Standard Time','(UTC-03:00)蒙得维的亚')
insert into QYD_Basic_TimeZone values(59,0,GETDATE(),'系统管理员','Morocco Standard Time','(UTC)卡萨布兰卡')
insert into QYD_Basic_TimeZone values(60,0,GETDATE(),'系统管理员','Mountain Standard Time','(UTC-07:00)山地时间(美国和加拿大)')
insert into QYD_Basic_TimeZone values(61,0,GETDATE(),'系统管理员','Mountain Standard Time (Mexico)','(UTC-07:00)奇瓦瓦，拉巴斯，马萨特兰')
insert into QYD_Basic_TimeZone values(62,0,GETDATE(),'系统管理员','Myanmar Standard Time','(UTC+06:30)仰光')
insert into QYD_Basic_TimeZone values(63,0,GETDATE(),'系统管理员','N. Central Asia Standard Time','(UTC+06:00)新西伯利亚(RTZ 5)')
insert into QYD_Basic_TimeZone values(64,0,GETDATE(),'系统管理员','Namibia Standard Time','(UTC+01:00)温得和克')
insert into QYD_Basic_TimeZone values(65,0,GETDATE(),'系统管理员','Nepal Standard Time','(UTC+05:45)加德满都')
insert into QYD_Basic_TimeZone values(66,0,GETDATE(),'系统管理员','New Zealand Standard Time','(UTC+12:00)奥克兰，惠灵顿')
insert into QYD_Basic_TimeZone values(67,0,GETDATE(),'系统管理员','Newfoundland Standard Time','(UTC-03:30)纽芬兰')
insert into QYD_Basic_TimeZone values(68,0,GETDATE(),'系统管理员','North Asia East Standard Time','(UTC+08:00)伊尔库茨克(RTZ 7)')
insert into QYD_Basic_TimeZone values(69,0,GETDATE(),'系统管理员','North Asia Standard Time','(UTC+07:00)克拉斯诺亚尔斯克(RTZ 6)')
insert into QYD_Basic_TimeZone values(70,0,GETDATE(),'系统管理员','Pacific SA Standard Time','(UTC-03:00)圣地亚哥')
insert into QYD_Basic_TimeZone values(71,0,GETDATE(),'系统管理员','Pacific Standard Time','(UTC-08:00)太平洋时间(美国和加拿大)')
insert into QYD_Basic_TimeZone values(72,0,GETDATE(),'系统管理员','Pacific Standard Time (Mexico)','(UTC-08:00)下加利福尼亚州')
insert into QYD_Basic_TimeZone values(73,0,GETDATE(),'系统管理员','Pakistan Standard Time','(UTC+05:00)伊斯兰堡，卡拉奇')
insert into QYD_Basic_TimeZone values(74,0,GETDATE(),'系统管理员','Paraguay Standard Time','(UTC-04:00)亚松森')
insert into QYD_Basic_TimeZone values(75,0,GETDATE(),'系统管理员','Romance Standard Time','(UTC+01:00)布鲁塞尔，哥本哈根，马德里，巴黎')
insert into QYD_Basic_TimeZone values(76,0,GETDATE(),'系统管理员','Russia Time Zone 10','(UTC+11:00)乔库尔达赫(RTZ 10)')
insert into QYD_Basic_TimeZone values(77,0,GETDATE(),'系统管理员','Russia Time Zone 11','(UTC+12:00)阿纳德尔，彼得罗巴甫洛夫斯克-堪察加(RTZ 11)')
insert into QYD_Basic_TimeZone values(78,0,GETDATE(),'系统管理员','Russia Time Zone 3','(UTC+04:00)伊热夫斯克，萨马拉(RTZ 3)')
insert into QYD_Basic_TimeZone values(79,0,GETDATE(),'系统管理员','Russian Standard Time','(UTC+03:00)莫斯科，圣彼得堡，伏尔加格勒(RTZ 2)')
insert into QYD_Basic_TimeZone values(80,0,GETDATE(),'系统管理员','SA Eastern Standard Time','(UTC-03:00)卡宴，福塔雷萨')
insert into QYD_Basic_TimeZone values(81,0,GETDATE(),'系统管理员','SA Pacific Standard Time','(UTC-05:00)波哥大，利马，基多，里奥布朗库')
insert into QYD_Basic_TimeZone values(82,0,GETDATE(),'系统管理员','SA Western Standard Time','(UTC-04:00)乔治敦，拉巴斯，马瑙斯，圣胡安')
insert into QYD_Basic_TimeZone values(83,0,GETDATE(),'系统管理员','Samoa Standard Time','(UTC+13:00)萨摩亚群岛')
insert into QYD_Basic_TimeZone values(84,0,GETDATE(),'系统管理员','SE Asia Standard Time','(UTC+07:00)曼谷，河内，雅加达')
insert into QYD_Basic_TimeZone values(85,0,GETDATE(),'系统管理员','Singapore Standard Time','(UTC+08:00)吉隆坡，新加坡')
insert into QYD_Basic_TimeZone values(86,0,GETDATE(),'系统管理员','South Africa Standard Time','(UTC+02:00)哈拉雷，比勒陀利亚')
insert into QYD_Basic_TimeZone values(87,0,GETDATE(),'系统管理员','Sri Lanka Standard Time','(UTC+05:30)斯里加亚渥登普拉')
insert into QYD_Basic_TimeZone values(88,0,GETDATE(),'系统管理员','Syria Standard Time','(UTC+02:00)大马士革')
insert into QYD_Basic_TimeZone values(89,0,GETDATE(),'系统管理员','Taipei Standard Time','(UTC+08:00)台北')
insert into QYD_Basic_TimeZone values(90,0,GETDATE(),'系统管理员','Tasmania Standard Time','(UTC+10:00)霍巴特')
insert into QYD_Basic_TimeZone values(91,0,GETDATE(),'系统管理员','Tokyo Standard Time','(UTC+09:00)大阪，札幌，东京')
insert into QYD_Basic_TimeZone values(92,0,GETDATE(),'系统管理员','Tonga Standard Time','(UTC+13:00)努库阿洛法')
insert into QYD_Basic_TimeZone values(93,0,GETDATE(),'系统管理员','Turkey Standard Time','(UTC+02:00)伊斯坦布尔')
insert into QYD_Basic_TimeZone values(94,0,GETDATE(),'系统管理员','Ulaanbaatar Standard Time','(UTC+08:00)乌兰巴托')
insert into QYD_Basic_TimeZone values(95,0,GETDATE(),'系统管理员','US Eastern Standard Time','(UTC-05:00)印地安那州(东部)')
insert into QYD_Basic_TimeZone values(96,0,GETDATE(),'系统管理员','US Mountain Standard Time','(UTC-07:00)亚利桑那')
insert into QYD_Basic_TimeZone values(97,0,GETDATE(),'系统管理员','UTC','(UTC)协调世界时')
insert into QYD_Basic_TimeZone values(98,0,GETDATE(),'系统管理员','UTC+12','(UTC+12:00)协调世界时+12')
insert into QYD_Basic_TimeZone values(99,0,GETDATE(),'系统管理员','UTC-02','(UTC-02:00)协调世界时-02')
insert into QYD_Basic_TimeZone values(100,0,GETDATE(),'系统管理员','UTC-11','(UTC-11:00)协调世界时-11')
insert into QYD_Basic_TimeZone values(101,0,GETDATE(),'系统管理员','Venezuela Standard Time','(UTC-04:30)加拉加斯')
insert into QYD_Basic_TimeZone values(102,0,GETDATE(),'系统管理员','Vladivostok Standard Time','(UTC+10:00)符拉迪沃斯托克，马加丹(RTZ 9)')
insert into QYD_Basic_TimeZone values(103,0,GETDATE(),'系统管理员','W. Australia Standard Time','(UTC+08:00)珀斯')
insert into QYD_Basic_TimeZone values(104,0,GETDATE(),'系统管理员','W. Central Africa Standard Time','(UTC+01:00)中非西部')
insert into QYD_Basic_TimeZone values(105,0,GETDATE(),'系统管理员','W. Europe Standard Time','(UTC+01:00)阿姆斯特丹，柏林，伯尔尼，罗马，斯德哥尔摩，维也纳')
insert into QYD_Basic_TimeZone values(106,0,GETDATE(),'系统管理员','West Asia Standard Time','(UTC+05:00)阿什哈巴德，塔什干')
insert into QYD_Basic_TimeZone values(107,0,GETDATE(),'系统管理员','West Pacific Standard Time','(UTC+10:00)关岛，莫尔兹比港')
insert into QYD_Basic_TimeZone values(108,0,GETDATE(),'系统管理员','Yakutsk Standard Time','(UTC+09:00)雅库茨克(RTZ 8)')
insert into QYD_Basic_TimeZone values(109,0,GETDATE(),'系统管理员','UTC','UTC+8:00(北京、上海、重庆、乌鲁木齐)')



--地址格式
IF OBJECT_ID('QYD_Basic_CountryFormat') IS NOT NULL
DROP TABLE QYD_Basic_CountryFormat
GO

CREATE TABLE QYD_Basic_CountryFormat(
ID BIGINT PRIMARY KEY, --标识
SysVersion BIGINT DEFAULT 0, --版本
CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
CreatedBy VARCHAR(50) DEFAULT '',--创建人
--修改人
[ModifiedBy] VARCHAR(50),
--修改时间
[ModifiedTime] datetime,
Code VARCHAR(50) DEFAULT '',--编码
Name VARCHAR(50) DEFAULT ''--名称
)
GO

insert into QYD_Basic_CountryFormat values(1,0,GETDATE(),'系统管理员','China','中国')
insert into QYD_Basic_CountryFormat values(2,0,GETDATE(),'系统管理员','TaiWan','中国台湾')
insert into QYD_Basic_CountryFormat values(3,0,GETDATE(),'系统管理员','America','美国')
insert into QYD_Basic_CountryFormat values(4,0,GETDATE(),'系统管理员','Hongkong','中国香港')
insert into QYD_Basic_CountryFormat values(5,0,GETDATE(),'系统管理员','Thailand','泰国')
insert into QYD_Basic_CountryFormat values(6,0,GETDATE(),'系统管理员','Australia','澳大利亚')

--语言
IF OBJECT_ID('QYD_Basic_Language') IS NOT NULL
DROP TABLE QYD_Basic_Language
GO

CREATE TABLE QYD_Basic_Language(
ID BIGINT PRIMARY KEY, --标识
SysVersion BIGINT DEFAULT 0, --版本
CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
CreatedBy VARCHAR(50) DEFAULT '',--创建人
--修改人
[ModifiedBy] VARCHAR(50),
--修改时间
[ModifiedTime] datetime,
Code VARCHAR(50) DEFAULT '',--编码
Name VARCHAR(50) DEFAULT ''--名称
)
GO

insert into QYD_Basic_Language values(1,0,GETDATE(),'系统管理员','zh-CN','简体中文')

--姓名格式
IF OBJECT_ID('QYD_Basic_NameFormat') IS NOT NULL
DROP TABLE QYD_Basic_NameFormat
GO

CREATE TABLE QYD_Basic_NameFormat(
ID BIGINT PRIMARY KEY, --标识
SysVersion BIGINT DEFAULT 0, --版本
CreatedTime DATETIME DEFAULT GETDATE(),--创建时间
CreatedBy VARCHAR(50) DEFAULT '',--创建人
--修改人
[ModifiedBy] VARCHAR(50),
--修改时间
[ModifiedTime] datetime,
Code VARCHAR(50) DEFAULT '',--编码
Name VARCHAR(50) DEFAULT ''--名称
)
GO

insert into QYD_Basic_NameFormat values(1,0,GETDATE(),'系统管理员','001','姓-名')
insert into QYD_Basic_NameFormat values(2,0,GETDATE(),'系统管理员','002','名-姓')