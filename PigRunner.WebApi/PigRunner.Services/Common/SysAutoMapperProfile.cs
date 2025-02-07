
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.Common
 * 唯一标识：5c03dbf0-9722-429e-a8b9-7667d3f6f0e9
 * 文件名：SysAutoMapperProfile
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/26 16:21:02
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>


using AutoMapper;
using OfficeOpenXml.Drawing.Controls;
using PigRunner.DTO.Basic;
using PigRunner.DTO.SCM.PM;
using PigRunner.DTO.Views.Sys;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.SCM.PM;
using PigRunner.Entitys.Sys;
using PigRunner.Public.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Common
{
    public class SysAutoMapperProfile : Profile
    {
        public SysAutoMapperProfile()
        {
            CreateMap<string, decimal>().ConvertUsing(item => item.Length > 0 ? Convert.ToDecimal(item.Replace(",", "")) : 0);
            CreateMap<decimal, string>().ConvertUsing(item => item.ToString("N2").Replace(",", ""));
            CreateMap<DateTime, string>().ConvertUsing(item => item > DateTime.MinValue ? item.ToString("yyyy-MM-dd") : "");
            CreateMap<UserView, SysUser>();
            CreateMap<SupplierCategoryView, SupplierCategory>().ReverseMap();
            CreateMap<SupplierCategoryView[], SupplierCategory[]>().ReverseMap();
            

        }
    }
}
