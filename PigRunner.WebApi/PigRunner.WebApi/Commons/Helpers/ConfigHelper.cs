using PigRunner.WebApi.Views.Config;

namespace PigRunner.WebApi.Commons.Helpers
{
    /// <summary>
    /// 配置帮助类
    /// </summary>
    public class ConfigHelper
    {
        private static readonly IConfiguration Configuration;

        private static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Development;

        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{Env}.json", true)
                .Build();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSection(string key)
        {
            return Configuration.GetValue<string>(key);
        }

        /// <summary>
        /// 获取集合配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string[] GetSections(string key)
        {
            return (string[])Configuration.GetSection(key).Get(typeof(string[]));
        }

        /// <summary>
        /// 获取上传路径
        /// </summary>
        /// <returns></returns>
        public static string GetUploadTempPath()
        {
            return GetSection("shareFilePaths:uploadFileTemp");
        }

        /// <summary>
        /// 获取JWT配置
        /// </summary>
        /// <returns></returns>
        public static JWTConfig GetJwtConfig()
        {
            return new JWTConfig
            {
                Audience = GetSection("JWT:Audience"),
                Issuer = GetSection("JWT:Issuer"),
                Secret = GetSection("JWT:Secret"),
                Expires = Convert.ToInt32(GetSection("JWT:Expires")),
            };
        }
        /// <summary>
        /// 取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IConfigurationSection GetConfigurationSection(string key)
        {
            return Configuration.GetSection(key);
        }
    }

}
