﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.SCM.INV
{

    public class CheckDiffBillView : DocBaseView
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

    }
    
}