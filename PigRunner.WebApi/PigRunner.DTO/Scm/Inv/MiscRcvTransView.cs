using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Scm.Inv
{

    public class MiscRcvTransView : DocBaseView
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

        public int? Status  { get; set;  } 
        
        
         
        
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

        public string? Remark  { get; set;  } 
        
        
        
        public int OptType { get; set; } = -1;

        public List<MiscRcvTransLineView> Lines { get; set; } = new List<MiscRcvTransLineView>();

    }
    public class MiscRcvTransLineView : BaseView
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

        public long? MiscRcvTrans { get; set; }




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