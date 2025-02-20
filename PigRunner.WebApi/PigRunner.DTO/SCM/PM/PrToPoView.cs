using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.SCM.PM
{
    /// <summary>
    /// 请购转采购
    /// </summary>
    public class PrToPoView
    {
        /// <summary>
        /// 请购单ID
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public string BusinessDate { get; set; } = string.Empty;

        /// <summary>
        /// 请购单号
        /// </summary>
        public string DocNo { get; set; }=string.Empty;
        /// <summary>
        /// 供应商ID
        /// </summary>
        public long Supplier { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string SupplierCode { get; set; } = string.Empty;
    }
    /// <summary>
    /// 请购单明细
    /// </summary>
    public class PrToPoLineView { 
        /// <summary>
        /// 请购单ID
        /// </summary>
        public long id { get; set; }
         
    
    
    }
}
