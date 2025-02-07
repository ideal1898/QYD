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
        public string TimeZone { get; set; } =  string.Empty;

        /// <summary>
        /// 地区格式名称
        /// </summary>
        public string CountryFormatName { get; set; } =string.Empty;

        /// <summary>
        /// 地区格式名称
        /// </summary>
        public string CountryFormat { get; set; } =  string.Empty;

        /// <summary>
        /// 币种名称
        /// </summary>
        public string CurrencyName{ get; set; } = string.Empty ;

        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; } =  string.Empty;

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; } =   string.Empty;

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
        public string NameFormat { get; set; } =  string.Empty;


    }
}
