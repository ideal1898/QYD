using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using PigRunner.WebApi.Commons.Helpers;
using Microsoft.OpenApi.Models;
using PigRunner.WebApi.Commons.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SqlSugar.IOC;
using System.Text;
using Microsoft.Extensions.FileProviders;
using PigRunner.Public.Helpers;

var builder = WebApplication.CreateBuilder(args);
//日志
LoggerHelper.Configure();


#region 过滤器相关

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
});

//添加全局权限验证
builder.Services.AddMvc(a =>
{
    a.Filters.Add<AuthorizationFilter>();
});

//去除参数有效性验证
builder.Services.Configure<ApiBehaviorOptions>((o) =>
{
    o.SuppressModelStateInvalidFilter = true;
});

#endregion


#region swagger 用Jwt验证

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                }
            },
            new string[] { }
        }
    });

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi接口文档", Version = "v1" });
    var path = Path.Combine(AppContext.BaseDirectory, "PigRunner.WebApi.xml");
    //显示控制器层注释
    options.IncludeXmlComments(path, true);
});

#endregion


#region JWT

var jwtConfig = ConfigHelper.GetJwtConfig();
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(token =>
{
    token.RequireHttpsMetadata = false;
    token.SaveToken = true;
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)),
        ValidateIssuer = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtConfig.Audience,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

#endregion

#region SqlSugar

SugarIocServices.AddSqlSugar(new IocConfig()
{
    ConnectionString = ConfigHelper.GetSection("DB:masterConnString"),//临时写死加密
    DbType = IocDbType.SqlServer,
    IsAutoCloseConnection = true,
});

// 打印sql语句
SugarIocServices.ConfigurationSugar(db =>
{
    db.Aop.OnLogExecuting = (sql, p) =>
    {
        Console.WriteLine(sql);
    };
});

#endregion

#region IOC

builder.Services.InjectionAllServices();


#endregion


var app = builder.Build();

#region 上传文件静态目录

var staticPath = Path.Combine(Directory.GetCurrentDirectory(), "files/UploadTemp");
if (!Directory.Exists(staticPath))
{
    Directory.CreateDirectory(staticPath);
}
app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = new PathString("/files/UploadTemp"),
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files/UploadTemp")),
});

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
