insert into QYD_Sys_Menu(id,CreatedTime,CreatedBy,SysVersion,Path,Name,Component,Redirect,IsActive,Icon,Title,IsLink,IsHide,IsFull,IsAffix,IsKeepAlive,Parent) values(605049656549446,GETDATE(),'管理员',0,'/mm','MM',null,null,0,'Lock','制造管理',null,0,0,0,1,0)

insert into QYD_Sys_Menu(id,CreatedTime,CreatedBy,SysVersion,Path,Name,Component,Redirect,IsActive,Icon,Title,IsLink,IsHide,IsFull,IsAffix,IsKeepAlive,Parent) values(605049656549447,GETDATE(),'管理员',0,'/mm/pm','PM',null,null,0,'Menu','生产管理',null,0,0,0,1,605049656549446)

insert into QYD_Sys_Menu(id,CreatedTime,CreatedBy,SysVersion,Path,Name,Component,Redirect,IsActive,Icon,Title,IsLink,IsHide,IsFull,IsAffix,IsKeepAlive,Parent) values(605049656549448,GETDATE(),'管理员',0,'/mm/pm/mo','MO','/mm/pm/mo/index',null,0,'Menu','生产订单',null,0,0,0,1,605049656549447)

insert into QYD_Sys_Menu(id,CreatedTime,CreatedBy,SysVersion,Path,Name,Component,Redirect,IsActive,Icon,Title,IsLink,IsHide,IsFull,IsAffix,IsKeepAlive,Parent) values(605049656549449,GETDATE(),'管理员',0,'/mm/pm/issue','Issue','/mm/pm/issue/index',null,0,'Menu','领料单',null,0,0,0,1,605049656549447)

insert into QYD_Sys_Menu(id,CreatedTime,CreatedBy,SysVersion,Path,Name,Component,Redirect,IsActive,Icon,Title,IsLink,IsHide,IsFull,IsAffix,IsKeepAlive,Parent) values(605049656549450,GETDATE(),'管理员',0,'/mm/pm/rtnissue','RtnIssue','/mm/pm/rtnissue/index',null,0,'Menu','退料单',null,0,0,0,1,605049656549447)