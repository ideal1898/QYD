using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Scm.Inv
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Qyd_InvDoc_Transfer")]
    public class Transfer : BaseEntity<Transfer>
    {
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Id" ) ]
        public long? Id  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Org" ) ]
        public long? Org  { get; set;  } 
        
         
         
         
         
         
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="DocType" ) ]
        public string? DocType  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Date" ) ]
        public DateTime? Date  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Docno" ) ]
        public string? Docno  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RcvDept" ) ]
        public long? RcvDept  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ShipDept" ) ]
        public long? ShipDept  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RcvWh" ) ]
        public long? RcvWh  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ShipWh" ) ]
        public long? ShipWh  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Status" ) ]
        public int? Status  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Remark" ) ]
        public string? Remark  { get; set;  }

        public List<TransferLine> Lines { get; set; }


    }
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Qyd_InvDoc_TransferL")]
    public class TransferLine : BaseEntity<TransferLine>
    {



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Id")]
        public long? Id { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Org")]
        public long? Org { get; set; }








        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Remark")]
        public string? Remark { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Transfer")]
        public long? Transfer { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "ItemInfo")]
        public long? ItemInfo { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "StoreUOM")]
        public long? StoreUOM { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "StoreUOMQty")]
        public decimal? StoreUOMQty { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Dept")]
        public long? Dept { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "SrcDocno")]
        public long? SrcDocno { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Lot")]
        public long? Lot { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "RcvDept")]
        public long? RcvDept { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "ShipDept")]
        public long? ShipDept { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "RcvWh")]
        public long? RcvWh { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "ShipWh")]
        public long? ShipWh { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "RcvWhBin")]
        public long? RcvWhBin { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "ShipWhBin")]
        public long? ShipWhBin { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Modate")]
        public DateTime? Modate { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "QgDay")]
        public decimal? QgDay { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "OutDate")]
        public DateTime? OutDate { get; set; }



    }

}