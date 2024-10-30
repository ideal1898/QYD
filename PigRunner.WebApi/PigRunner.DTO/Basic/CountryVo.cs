using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    public class CountryVo
    {

        public int LineNum { get; set; } = -1;
        /// <summary>
        /// 国家/地区编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 国家/地区名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 时区名称
        /// </summary>
        public string TimeZone { get; set; } = string.Empty;

        /// <summary>
        /// 时区
        /// </summary>
        public int TimeZoneV { get; set; } = -1;

        /// <summary>
        /// 地区格式名称
        /// </summary>
        public string CountryFormat { get; set; } =string.Empty;

        /// <summary>
        /// 地区格式名称
        /// </summary>
        public int CountryFormatV { get; set; } = -1;

        /// <summary>
        /// 币种名称
        /// </summary>
        public string Currency { get; set; } = string.Empty ;

        /// <summary>
        /// 币种
        /// </summary>
        public int CurrencyV { get; set; } = -1;

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// 语言
        /// </summary>
        public int LanguageV { get; set; } = -1;

        /// <summary>
        /// id
        /// </summary>
        public long ID { get; set; } = -1;

        /// <summary>
        /// 姓名格式
        /// </summary>
        public string NameFormat { get; set; } =string.Empty;

        /// <summary>
        /// 姓名格式
        /// </summary>
        public int NameFormatV { get; set; } = -1;


        /// <summary>
        /// 操作类型
        /// </summary>
        public int OptType { get; set; } = -1;
    }
}
