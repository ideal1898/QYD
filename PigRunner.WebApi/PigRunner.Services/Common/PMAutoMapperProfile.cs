using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml.Drawing.Controls;
using PigRunner.DTO.SCM.PM;
using PigRunner.Entitys.SCM.PM;
using PigRunner.Public;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Context;
using PigRunner.Public.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Common
{
    public class PMAutoMapperProfile : Profile
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="session"></param>
        public PMAutoMapperProfile()
        {
            CreateMap<string, decimal>().ConvertUsing(item => item.Length > 0 ? Convert.ToDecimal(item.Replace(",", "")) : 0);
            CreateMap<decimal, string>().ConvertUsing(item => item.ToString("N2").Replace(",", ""));
            CreateMap<DateTime, string>().ConvertUsing(item => item > DateTime.MinValue ? item.ToString("yyyy-MM-dd") : "");
            CreateMap<string, int>().ConvertUsing(item => item.Length > 0 ? Convert.ToInt32(item.Replace(",", "")) : 0);
            #region 采购订单
            CreateMap<PurchaseOrderView, PurchaseOrder>()
               .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.id > 0 ? (!string.IsNullOrEmpty(src.CreatedTime) ? DateTime.Now : DateTime.Parse(src.CreatedTime)) : DateTime.Now))
               .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.SysVersion, opt => opt.Ignore())
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id > 0 ? src.id : IdGeneratorHelper.GetNextId()))
               .ForMember(dest => dest.DocNo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.DocNo) ? src.DocNo : $"PO{DateTime.Now.ToString("yyyyMMddHHss")}"))
               .ReverseMap()
               .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.ID))
               .ForPath(dest => dest.SupplierCode, opt => opt.MapFrom(src => src.Supp != null ? src.Supp.Code : ""))
               .ForPath(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supp != null ? src.Supp.Name : ""))
               .ForPath(dest => dest.CurrencyName, opt => opt.MapFrom(src => src.Symbols != null ? src.Symbols.Name : ""));
            CreateMap<POLineView, POLine>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id > 0 ? src.id : IdGeneratorHelper.GetNextId()))
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap()
                .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForPath(dest => dest.ItemCode, opt => opt.MapFrom(src => src.Item != null ? src.Item.Code : ""))
                .ForPath(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item != null ? src.Item.Name : ""))
                .ForPath(dest => dest.ItemSpec, opt => opt.MapFrom(src => src.Item != null ? src.Item.SPECS : ""));
            #endregion

            #region 送货单
            CreateMap<DeliveryOrderView, DeliveryOrder>()
                .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.id > 0 ? (!string.IsNullOrEmpty(src.CreatedTime) ? DateTime.Now : DateTime.Parse(src.CreatedTime)) : DateTime.Now))
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id > 0 ? src.id : IdGeneratorHelper.GetNextId()))
                .ForMember(dest => dest.DocNo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.DocNo) ? src.DocNo : $"DHD{DateTime.Now.ToString("yyyyMMddHHss")}"))
                .ForMember(dest => dest.SubmitDate, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.SubmitDate) ? src.SubmitDate : null))
                .ForMember(dest => dest.ApprovedOn, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.ApprovedOn) ? src.ApprovedOn : null))
                .ReverseMap()
                .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForPath(dest => dest.DepartmentCode, opt => opt.MapFrom(src => src.Dept != null ? src.Dept.Code : ""))
                .ForPath(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Dept != null ? src.Dept.Name : ""))
                .ForPath(dest => dest.SalesManCode, opt => opt.MapFrom(src => src.Operators != null ? src.Operators.Code : ""))
                .ForPath(dest => dest.SaleManName, opt => opt.MapFrom(src => src.Operators != null ? src.Operators.Name : ""))
                .ForPath(dest => dest.SupplierCode, opt => opt.MapFrom(src => src.Supp != null ? src.Supp.Name : ""))
                .ForPath(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supp != null ? src.Supp.Name : ""))
                .ForPath(dest => dest.SubmitDate, opt => opt.MapFrom(src => src.SubmitDate > DateTime.Parse("1900.01.01") ? src.SubmitDate.Value.ToString("yyyy-MM-dd") : ""))
                .ForPath(dest => dest.ApprovedOn, opt => opt.MapFrom(src => src.ApprovedOn > DateTime.Parse("1900.01.01") ? src.ApprovedOn.Value.ToString("yyyy-MM-dd") : ""));

            CreateMap<DeliveryOrderLineView, DeliveryOrderLine>()
                 .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.id > 0 ? src.CreatedTime:DateTime.Now))
                 .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(src => DateTime.Now))
                 .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id > 0 ? src.id : IdGeneratorHelper.GetNextId()))
                 .ReverseMap()
                 .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                 .ForPath(dest => dest.ItemCode, opt => opt.MapFrom(src => src.Item != null ? src.Item.Code : ""))
                 .ForPath(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item != null ? src.Item.Name : ""))
                 .ForPath(dest => dest.ItemSpec, opt => opt.MapFrom(src => src.Item != null ? src.Item.SPECS : ""))
                 .ForPath(dest => dest.LotCode, opt => opt.MapFrom(src => src.Lot != null ? src.Lot.LotCode : ""))
                 .ForPath(dest => dest.WhCode, opt => opt.MapFrom(src => src.Warehouse != null ? src.Warehouse.Code : ""))
                 .ForPath(dest => dest.WhName, opt => opt.MapFrom(src => src.Warehouse != null ? src.Warehouse.Name : ""))
                 .ForPath(dest => dest.BinCode, opt => opt.MapFrom(src => src.Freight != null ? src.Freight.Code : ""))
                 .ForPath(dest => dest.BinName, opt => opt.MapFrom(src => src.Freight != null ? src.Freight.Name : ""));
            #endregion

            #region 收货单

            CreateMap<ReceiptView, PurchaseReceipt>()
                .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.id > 0 ? (!string.IsNullOrEmpty(src.CreatedTime) ? DateTime.Now : DateTime.Parse(src.CreatedTime)) : DateTime.Now))
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id > 0 ? src.id : IdGeneratorHelper.GetNextId()))
                .ForMember(dest => dest.DocNo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.DocNo) ? src.DocNo : $"RCV{DateTime.Now.ToString("yyyyMMddHHmmss")}"))
                .ForMember(dest => dest.SubmitDate, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.SubmitDate) ? src.SubmitDate : null))
                .ForMember(dest => dest.ApprovedOn, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.ApprovedOn) ? src.ApprovedOn : null))
                .ReverseMap()
                .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForPath(dest => dest.DepartmentCode, opt => opt.MapFrom(src => src.Dept != null ? src.Dept.Code : ""))
                .ForPath(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Dept != null ? src.Dept.Name : ""))
                .ForPath(dest => dest.SalesManCode, opt => opt.MapFrom(src => src.Operators != null ? src.Operators.Code : ""))
                .ForPath(dest => dest.SalesManName, opt => opt.MapFrom(src => src.Operators != null ? src.Operators.Name : ""))
                .ForPath(dest => dest.SupplierCode, opt => opt.MapFrom(src => src.Supp != null ? src.Supp.Name : ""))
                .ForPath(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supp != null ? src.Supp.Name : ""))
                .ForPath(dest => dest.RequiredManCode, opt => opt.MapFrom(src => src.ReqMan != null ? src.ReqMan.Code : ""))
                .ForPath(dest => dest.RequiredManName, opt => opt.MapFrom(src => src.ReqMan != null ? src.ReqMan.Name : ""))
                .ForPath(dest => dest.CurrencyName, opt => opt.MapFrom(src => src.Symbol != null ? src.Symbol.Name : ""))
                .ForPath(dest => dest.SubmitDate, opt => opt.MapFrom(src => src.SubmitDate > DateTime.Parse("1900.01.01") ? src.SubmitDate.Value.ToString("yyyy-MM-dd") : ""))
                .ForPath(dest => dest.ApprovedOn, opt => opt.MapFrom(src => src.ApprovedOn > DateTime.Parse("1900.01.01") ? src.ApprovedOn.Value.ToString("yyyy-MM-dd") : ""));

            CreateMap<ReceiptLineView, PurchaseReceiptLine>()
                .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.id > 0 ? src.CreatedTime : DateTime.Now))
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest=>dest.Expiration,opt=>opt.MapFrom(src=>!string.IsNullOrEmpty(src.Expiration)?Convert.ToInt32(Convert.ToDecimal(src.Expiration)):0))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id > 0 ? src.id : IdGeneratorHelper.GetNextId()))
                .ReverseMap()
                .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForPath(dest => dest.LotCode, opt => opt.MapFrom(src => src.Lot != null ? src.Lot.LotCode : ""))
                .ForPath(dest => dest.WhCode, opt => opt.MapFrom(src => src.Warehouse != null ? src.Warehouse.Code : ""))
                .ForPath(dest => dest.WhName, opt => opt.MapFrom(src => src.Warehouse != null ? src.Warehouse.Name : ""))
                .ForPath(dest => dest.BinCode, opt => opt.MapFrom(src => src.Freight != null ? src.Freight.Code : ""))
                .ForPath(dest => dest.BinName, opt => opt.MapFrom(src => src.Freight != null ? src.Freight.Name : ""))
                .ForPath(dest => dest.TreasurerCode, opt => opt.MapFrom(src => src.Operator != null ? src.Operator.Code : ""))
                .ForPath(dest => dest.TreasurerName, opt => opt.MapFrom(src => src.Operator != null ? src.Operator.Name : ""))
                .ForPath(dest => dest.ProjectCode, opt => opt.MapFrom(src => src.Pro != null ? src.Pro.Code : ""))
                .ForPath(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Pro != null ? src.Pro.Code : ""));
            
            #endregion
        }
    }
}
