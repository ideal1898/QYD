using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 省／自治区
    ///</summary>
    [SugarTable("QYD_Base_Province")]
    public class Province : BaseEntity<Province>
    {


        /// <summary>
        /// 备  注:省自治区编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Code")]
        public string Code { get; set; } = string.Empty; 
        
         
        
        /// <summary>
        /// 备  注:省自治区名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string Name  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:国家ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Country" ) ]
        public long Country  { get; set;  } = -1;




    }
    
}