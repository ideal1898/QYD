using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Basic
{

    public class WhBinVo
    {
        
         
         
         
         
         
         
        
        /// <summary>
        /// 备  注:有效性
        /// 默认值:
        ///</summary>

        public int? IsEffective  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:库位编码
        /// 默认值:
        ///</summary>

        public string? Code  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:库位名称
        /// 默认值:
        ///</summary>

        public string? Name  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:组织ID
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
        /// 备  注:仓库ID
        /// 默认值:
        ///</summary>

        public long? Wh  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:库区ID
        /// 默认值:
        ///</summary>

        public long? WhbinGroup  { get; set;  } 
        
        
         
        
        public int OptType { get; set; } = -1;

    }
    
}