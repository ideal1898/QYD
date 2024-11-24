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
    public class OrganizationView
    {
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public int IsEffective { get; set; } = 0;



        /// <summary>
        /// 备  注:组织编码
        /// 默认值:
        ///</summary>
        public string Code { get; set; }=string.Empty;


        /// <summary>
        /// id
        /// </summary>
        public long ID { get; set; } = -1;

        /// <summary>
        /// 备  注:组织名称
        /// 默认值:
        ///</summary>
        public string Name { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:默认语言
        /// 默认值:
        ///</summary>
        public int DefaultLanguage { get; set; } = 0;

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


        /// <summary>
        /// 操作类型
        /// </summary>
        public string OptType { get; set; } = string.Empty;

        /// <summary>
        /// 当前页
        /// </summary>
        public int Current { get; set; } = 1;

        /// <summary>
        /// 每页几行
        /// </summary>
        public int Size { get; set; } = 2;

        /// <summary>
        /// 编号集合
        /// </summary>
        public List<string> Codes { get; set; } = new List<string>();


        public int LineNum { get; set; } = -1;

    }
}
