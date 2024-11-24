using PigRunner.Public.Abstract;

namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 时区
    /// </summary>
    [SqlSugar.SugarTable("QYD_Basic_TimeZone")]
    public class TimeZone : BaseEntity<TimeZone>
    {
        /// <summary>
        ///编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        ///名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
