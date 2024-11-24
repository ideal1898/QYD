using PigRunner.Public.Abstract;

namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 币种
    /// </summary>
    [SqlSugar.SugarTable("QYD_Basic_Currency")]
    public class Currency : BaseEntity<Currency>
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
