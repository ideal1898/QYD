﻿using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.IServices
{
    public interface INameFormatService : IScopedService
    {
        /// <summary>
        /// 姓名格式
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionNameFormat(EnumView request);
    }
}
