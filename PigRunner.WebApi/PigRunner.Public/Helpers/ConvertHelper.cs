namespace PigRunner.Public.Helpers
{
    /// <summary>
    /// 类型转换帮助类
    /// </summary>
    public static class ConvertHelper
    {
        /// <summary>
        /// 时间转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string str)
        {
            try
            {
                return Convert.ToDateTime(str);
            }
            catch
            {
                return null;
            }
        }
    }
}
