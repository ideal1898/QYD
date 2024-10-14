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
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
//��־
LoggerHelper.Configure();


#region ���������

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
});

//���ȫ��Ȩ����֤
builder.Services.AddMvc(a =>
{
    a.Filters.Add<AuthorizationFilter>();
});

//ȥ��������Ч����֤
builder.Services.Configure<ApiBehaviorOptions>((o) =>
{
    o.SuppressModelStateInvalidFilter = true;
});

#endregion


#region swagger ��Jwt��֤

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
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

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi�ӿ��ĵ�", Version = "v1" });
    var path = Path.Combine(AppContext.BaseDirectory, "PigRunner.WebApi.xml");
    //��ʾ��������ע��
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
    token.Events = new JwtBearerEvents {
        OnChallenge = context => {
            //�˴�����Ϊ��ֹ.Net CoreĬ�ϵķ������ͺ����ݽ�����������ҪŶ������
            context.HandleResponse();
            //�Զ����Լ���Ҫ���ص����ݽ����������Ҫ���ص���Json����ͨ������Newtonsoft.Json�����ת��
            var payload = JsonConvert.SerializeObject(new { Code = 401, Message = "�ܱ�Ǹ������Ȩ���ʸýӿ�" });
            //�Զ��巵�ص���������
            context.Response.ContentType = "application/json";
            //�Զ��巵��״̬�룬Ĭ��Ϊ401 ������ĳ� 200
            context.Response.StatusCode = StatusCodes.Status200OK;
            //context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //���Json���ݽ��
            context.Response.WriteAsync(payload);
            return Task.FromResult(0);
        }
    };
});

#endregion

#region SqlSugar

SugarIocServices.AddSqlSugar(new IocConfig()
{
    ConnectionString = ConfigHelper.GetSection("DB:masterConnString"),//��ʱд������
    DbType = IocDbType.SqlServer,
    IsAutoCloseConnection = true,
});

// ��ӡsql���
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

#region �ϴ��ļ���̬Ŀ¼

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

app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
