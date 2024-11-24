using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 组织
    ///</summary>
    [SugarTable("QYD_Base_Organization")]
    public class Organization : BaseEntity<Organization>
    {

        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public int IsEffective { get; set; } = 1;



        /// <summary>
        /// 备  注:组织编码
        /// 默认值:
        ///</summary>
        public string Code { get; set; } = string.Empty;
        
         
        
        /// <summary>
        /// 备  注:组织名称
        /// 默认值:
        ///</summary>
        public string Name  { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:默认语言
        /// 默认值:
        ///</summary>
        public int DefaultLanguage  { get; set; } = 0;



        /// <summary>
        /// 备  注:办公地址
        /// 默认值:
        ///</summary>
        public string Location  { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:注册地址
        /// 默认值:
        ///</summary>
        public string RegisterAddress  { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:社会统一信用代码
        /// 默认值:
        ///</summary>
        public string CCBL  { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:联系人
        /// 默认值:
        ///</summary>
        public string Contacts  { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:组织简码
        /// 默认值:
        ///</summary>
        public string Shortname { get; set; } = string.Empty; 
        
    }
    
}