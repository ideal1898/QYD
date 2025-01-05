﻿using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.SCM.PM
{
    /// <summary>
    /// 请购单
    /// </summary>
    [SqlSugar.SugarTable("QYD_Pr_Pr")]
    public class Requisition:BaseEntity<Requisition>
    {

    }
    /// <summary>
    /// 请购单行
    /// </summary>
    [SqlSugar.SugarTable("QYD_Pr_Prline")]
    public class RequisitionLine:BaseEntity<RequisitionLine> { 
    
    }
}
