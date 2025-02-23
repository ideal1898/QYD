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
    [SugarTable("Qyd_InvDoc_TransferForm")]
    public class TransferForm : BaseEntity<TransferForm>
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
        public long? DocType  { get; set;  } 
        
         
        
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
        [SugarColumn(ColumnName="Remark" ) ]
        public string? Remark  { get; set;  }

        public List<TransferFormLine> Lines { get; set; }


    }

    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Qyd_InvDoc_TransferFormL")]
    public class TransferFormLine : BaseEntity<TransferFormLine>
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
        [SugarColumn(ColumnName = "TransferForm")]
        public long? TransferForm { get; set; }



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "TransferFormType")]
        public int? TransferFormType { get; set; }



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