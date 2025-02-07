using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    /// <summary>
    /// 组织视图
    /// </summary>
    public class OrganizationView : PubView
    {
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public string IsEffective { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:默认语言
        /// 默认值:
        ///</summary>
        public string DefaultLanguage { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:默认语言名称
        /// 默认值:
        ///</summary>
        public string DefaultLanguageName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:办公地址
        /// 默认值:
        ///</summary>
        public string Location { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:注册地址
        /// 默认值:
        ///</summary>
        public string RegisterAddress { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:社会统一信用代码
        /// 默认值:
        ///</summary>
        public string CCBL { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:联系人
        /// 默认值:
        ///</summary>
        public string Contacts { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:组织简称
        /// 默认值:
        ///</summary>
        public string Shortname { get; set; } = string.Empty;
    }
}
