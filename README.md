# pigrunnerbackground

#### 介绍
集成了JWT，SqlSugar，Redis等框架的完整.net 6 webapi项目。内置了很多帮助类，可以直接当作项目使用。


环境配置
开发工具：visual studio 2022
目标框架：.NET 6.0

版本管理
   git
远程仓库地址：
   git clone https://gitee.com/desperadas/pigrunnerbackground.git

使用说明
  修改appsettings.json中Development.json环境，配置数据库连接（自行加密）。
  在mssql中执行根目录中的【创建demo表.sql】文件，创建demo需要的表。
  启动项目。

集成功能
    JWT登录验证，登录过期设置（24小时过期，45分钟不操作自动过期）。
    集成了轻量级的ORM框架SqlSugar 5.X，具体使用请看官网说明SqlSugar 5.X。
    集成了Redis的常用方法（哨兵模式连接）。
    继承了log4net日志组件（默认按天分组）。
    封装了IOC，接口或类继承Scoped,Transient,Singletion接口后 可直接在构造函数中注入。
    封装了常用帮助类：枚举操作，Excel读取写入，加密解密，上传文件，类型转换等。

目录结构
    Commons
    Attribute 存放自定义特性
    Helpers 存放一些帮助类
    Config  存放配置文件
    Views 内部接口请求响应实体
    Controllers 控制器文件夹
    appsettings.json 配置文件（公共配置）
    appsettings.Development.json 开发配置文件
    appsettings.Staging.json Qa测试文件
    appsettings.Porduction.json 正式测试文件


