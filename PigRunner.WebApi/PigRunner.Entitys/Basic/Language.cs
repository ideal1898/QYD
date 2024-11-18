using PigRunner.Public.Abstract;

namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 语言
    /// </summary>
    [SqlSugar.SugarTable("QYD_Basic_Language")]
    public class Language : BaseEntity<Language>
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
