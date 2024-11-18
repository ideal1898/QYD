using PigRunner.Public.Abstract;

namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 地址格式
    /// </summary>
    [SqlSugar.SugarTable("QYD_Basic_CountryFormat")]
    public class CountryFormat : BaseEntity<CountryFormat>
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
