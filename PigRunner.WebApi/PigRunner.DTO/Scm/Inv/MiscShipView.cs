﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Scm.Inv
{

    public class MiscShipView : DocBaseView
    {
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Id  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Org  { get; set;  } 
        
        
         
         
         
         
         
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? DocType  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public DateTime? Date  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public string? Docno  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Dept  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Wh  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? SrcDocno  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public int? Status  { get; set;  } 
        
        
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public string? Remark  { get; set;  } 
        
        
        
        public int OptType { get; set; } = -1;

        public List<MiscShipLineView> Lines { get; set; } = new List<MiscShipLineView>();

    }

    public class MiscShipLineView : BaseView
    {



        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Id { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Org { get; set; }









        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public string? Remark { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? MiscShip { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? ItemInfo { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? StoreUOM { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public decimal? StoreUOMQty { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Wh { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Dept { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? SrcDocno { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? Lot { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public long? WhBin { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public DateTime? Modate { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public decimal? QgDay { get; set; }




        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>

        public DateTime? OutDate { get; set; }



        public int OptType { get; set; } = -1;

    }

}