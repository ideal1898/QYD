using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.IServices
{
    public interface ITimeZoneService : IScopedService
    {
        /// <summary>
        /// 时区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionTimeZone(EnumView request);
    }
}
