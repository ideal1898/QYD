using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Basic
{

    public class WhBinGroupVo
    {
        
         
         
        
        /// <summary>
        /// 备  注:库区编码
        /// 默认值:
        ///</summary>

        public string? Code  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:库区名称
        /// 默认值:
        ///</summary>

        public string? Name  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:仓库
        /// 默认值:
        ///</summary>

        public long? Wh  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>

        public long? Org  { get; set;  } 
        
        
         
         
         
         
         
        
        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>

        public string? Area  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:体积
        /// 默认值:
        ///</summary>

        public string? Volume  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>

        public string? Remark  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:有效性
        /// 默认值:
        ///</summary>

        public int? IsEffective  { get; set;  } 
        
        
         
        
        public int OptType { get; set; } = -1;

    }
    
}