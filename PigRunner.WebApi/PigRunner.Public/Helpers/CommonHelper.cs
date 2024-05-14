using System.Reflection;

namespace PigRunner.Public.Helpers
{
    /// <summary>
    /// 常用帮助类
    /// </summary>
    public class CommonHelper
    {
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <typeparam name="Source"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Target? Mapper<Target, Source>(Source source)
        {
            if (source == null)
            {
                return default;
            }
            Target d = Activator.CreateInstance<Target>();
            try
            {
                var Types = source.GetType();
                var Typed = typeof(Target);
                foreach (PropertyInfo sp in Types.GetProperties())
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name && dp.PropertyType == sp.PropertyType && dp.Name != "Error" && dp.Name != "Item")
                        {
                            dp.SetValue(d, sp.GetValue(source, null), null);
                        }
                    }
                }
                return d;
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// 加密账号
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetMD5Password(string account, string password)
        {
            var str = account + ":" + password + "account";
            return EncryptHelper.MD5Encrypt(str);
        }
    }
}
