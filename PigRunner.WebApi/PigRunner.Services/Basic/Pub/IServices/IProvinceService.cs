using PigRunner.DTO.Basic.Pub;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.Pub.IServices
{
  public interface IProvinceService : IScopedService
    {
        /// <summary>
        /// 省/自治区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionProvince(ProvinceView request);


        PubResponse UploadProvince(MemoryStream file);
    }
}
