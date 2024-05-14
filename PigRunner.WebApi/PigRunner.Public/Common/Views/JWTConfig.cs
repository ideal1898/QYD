namespace PigRunner.Public.Common.Views
{
    /// <summary>
    /// JWT配置文件
    /// </summary>
    public class JWTConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string Secret { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>

        public string Issuer { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>

        public string Audience { get; set; } = string.Empty;

        /// <summary>
        /// 过期时间（秒）
        /// </summary>
        public int Expires { get; set; }
    }
}
