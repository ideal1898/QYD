using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 项目
    ///</summary>
    [SugarTable("QYD_Basic_Project")]
    public class Project : BaseEntity<Project>
    {
        /// <summary>
        /// 备  注:项目状态
        /// 默认值:
        ///</summary>
        public int Status { get; set; } = 0;



        /// <summary>
        /// 备  注:项目编码
        /// 默认值:
        ///</summary>
        public string Code { get; set; } = string.Empty;
        
        
        /// <summary>
        /// 备  注:项目名称
        /// 默认值:
        ///</summary>
        public string Name  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:描述
        /// 默认值:
        ///</summary>
        public string Description  { get; set;  } = string.Empty;

        
        /// <summary>
        /// 备  注:验收日期
        /// 默认值:
        ///</summary>
        public DateTime AcceptDate  { get; set;  } 
         
        
        /// <summary>
        /// 备  注:质保到期日
        /// 默认值:
        ///</summary>
        public DateTime QAExpireDate  { get; set;  }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;

    }
    
}