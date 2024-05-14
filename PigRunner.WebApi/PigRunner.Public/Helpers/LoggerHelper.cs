using log4net.Config;
using log4net.Repository;
using log4net;

namespace PigRunner.Public.Helpers
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LoggerHelper
    {
        private static ILoggerRepository? repository { get; set; }
        private static ILog? _log;

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="repositoryName"></param>
        /// <param name="configFile"></param>
        public static void Configure(string repositoryName = "PigRunner.WebApi", string configFile = "Config/Log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));
            _log = LogManager.GetLogger(repository.Name, "logger");
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="msg">消息</param>
        /// <param name="filter1">过滤字段1</param>
        /// <param name="filter2">过滤字段2</param>
        public static void Info(LogEnum category, string msg, string filter1 = "", string filter2 = "")
        {
            _log?.Info(GetMessage(category, filter1, filter2) + msg);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="msg">消息</param>
        /// <param name="filter1">过滤字段1</param>
        /// <param name="filter2">过滤字段2</param>
        public static void Warn(LogEnum category, string msg, string filter1 = "", string filter2 = "")
        {
            _log?.Warn(GetMessage(category, filter1, filter2) + msg);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="msg">消息</param>
        /// <param name="ex">异常</param>
        /// <param name="filter1">过滤字段1</param>
        /// <param name="filter2">过滤字段2</param>
        public static void Error(LogEnum category, string msg, Exception ex, string filter1 = "", string filter2 = "")
        {
            _log?.Error(GetMessage(category, filter1, filter2) + msg, ex);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="msg">消息</param>
        /// <param name="filter1">过滤字段1</param>
        /// <param name="filter2">过滤字段2</param>
        public static void Error(LogEnum category, string msg, string filter1 = "", string filter2 = "")
        {
            _log?.Error(GetMessage(category, filter1, filter2) + msg);
        }

        /// <summary>
        /// 获取消息体
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="filter1">过滤字段1</param>
        /// <param name="filter2">过滤字段2</param>
        /// <returns></returns>
        private static string GetMessage(LogEnum category, string filter1, string filter2)
        {
            filter1 = filter1?.Replace("|", "") ?? string.Empty;
            filter2 = filter2?.Replace("|", "") ?? string.Empty;
            return $"【{category}|{filter1}|{filter2}】";
        }
    }

    /// <summary>
    /// 日志枚举
    /// </summary>
    public enum LogEnum
    {
        /// <summary>
        /// 公共分类
        /// </summary>
        Common,

        /// <summary>
        /// 系统
        /// </summary>
        System
    }

}
