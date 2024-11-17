using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Basic
{

    public class DepartmentVo
    {
        
         
         
        
        /// <summary>
        /// 备  注:编码
        /// 默认值:
        ///</summary>

        public string? Code  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:名称
        /// 默认值:
        ///</summary>

        public string? Name  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:生效
        /// 默认值:
        ///</summary>

        public bool? IsEffective  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>

        public string? Remark  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:上级部门
        /// 默认值:
        ///</summary>

        public long? ParentNode  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:部门分类
        /// 默认值:
        ///</summary>

        public string? Depclass  { get; set;  } 
        
        
         
         
         
         
         
        
        public int OptType { get; set; } = -1;

    }
    
}