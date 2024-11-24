using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Basic
{

    public class OperatorsVo
    {
        
         
         
        
        /// <summary>
        /// 备  注:人员编码
        /// 默认值:
        ///</summary>

        public string? Code  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:人员名称
        /// 默认值:
        ///</summary>

        public string? Name  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:部门ID
        /// 默认值:
        ///</summary>

        public long? Dept  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:是否采购员
        /// 默认值:
        ///</summary>

        public int? IsPurer  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:是否销售人员
        /// 默认值:
        ///</summary>

        public int? IsSaler  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:是否计划人员
        /// 默认值:
        ///</summary>

        public int? IsPlaner  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:是否生产人员
        /// 默认值:
        ///</summary>

        public int? IsMoer  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:是否库存管理员
        /// 默认值:
        ///</summary>

        public int? IsInver  { get; set;  } 
        
        
         
         
         
         
         
        
        public int OptType { get; set; } = -1;

    }
    
}