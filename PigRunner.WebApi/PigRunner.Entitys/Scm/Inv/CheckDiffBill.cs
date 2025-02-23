using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.SCM.INV
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Qyd_InvDoc_CheckDiffBill")]
    public class CheckDiffBill : BaseDocEntity<CheckDiffBill>
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
        [SugarColumn(ColumnName="Dept" ) ]
        public long? Dept  { get; set;  } 
        
         
        
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
        [SugarColumn(ColumnName="wh" ) ]
        public long? Wh  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="SrcDocno" ) ]
        public long? SrcDocno  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Remark" ) ]
        public string? Remark  { get; set;  }

        public List<CheckDiffBillLine> Lines { get; set; }


    }
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Qyd_InvDoc_CheckDiffBillL")]
    public class CheckDiffBillLine : LineBaseEntity
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
        [SugarColumn(ColumnName = "CheckDiffBill")]
        public long? CheckDiffBill { get; set; }



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
        [SugarColumn(ColumnName = "qty")]
        public decimal? Qty { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "AdjQtySU")]
        public decimal? AdjQtySU { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "wh")]
        public long? Wh { get; set; }



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
        [SugarColumn(ColumnName = "WhBin")]
        public long? WhBin { get; set; }



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