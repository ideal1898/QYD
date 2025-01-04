using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    public class CountryView: PubView
    {

        /// <summary>
        /// 时区名称
        /// </summary>
        public string TimeZoneName { get; set; } = string.Empty;

        /// <summary>
        /// 时区
        /// </summary>
        public int TimeZone { get; set; } = -1;

        /// <summary>
        /// 地区格式名称
        /// </summary>
        public string CountryFormatName { get; set; } =string.Empty;

        /// <summary>
        /// 地区格式名称
        /// </summary>
        public int CountryFormat { get; set; } = -1;

        /// <summary>
        /// 币种名称
        /// </summary>
        public string CurrencyName{ get; set; } = string.Empty ;

        /// <summary>
        /// 币种
        /// </summary>
        public int Currency { get; set; } = -1;

        /// <summary>
        /// 语言
        /// </summary>
        public int Language { get; set; } =  -1;

        /// <summary>
        /// 语言
        /// </summary>
        public string LanguageName { get; set; } = string.Empty;

     

        /// <summary>
        /// 姓名格式
        /// </summary>
        public string NameFormatName { get; set; } =string.Empty;

        /// <summary>
        /// 姓名格式
        /// </summary>
        public int NameFormat { get; set; } = -1;


    }
}
