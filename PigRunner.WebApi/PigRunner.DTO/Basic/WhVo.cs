using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Basic
{

    public class WhVo
    {
        
         
         
        
        /// <summary>
        /// 备  注:编码
        /// 默认值:
        ///</summary>

        public string Code  { get; set;  } = string.Empty;
        /// <summary>
        /// 备  注:ID
        /// 默认值:
        ///</summary>

        public long Id { get; set; }


        /// <summary>
        /// 备  注:名称
        /// 默认值:
        ///</summary>

        public string Name  { get; set;  } = string.Empty;




        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>

        public long Org  { get; set;  }




        /// <summary>
        /// 备  注:是否库位
        /// 默认值:
        ///</summary>

        public int IsStoreBin { get; set; } = -1;
        
        
         
        
        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>

        public decimal Area  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:容积
        /// 默认值:
        ///</summary>

        public decimal Volume  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:供应商
        /// 默认值:
        ///</summary>

        public long Supplier  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:客户
        /// 默认值:
        ///</summary>

        public long Customer  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:地址
        /// 默认值:
        ///</summary>

        public string Address  { get; set;  } = string.Empty;




        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>

        public string Remark  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>

        public int IsEffective  { get; set;  } 
        
        
         
         
         
         
         
        
        public int OptType { get; set; } = -1;

    }
    
}