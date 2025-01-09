﻿using PigRunner.DTO.SCM.MM;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.SCM.MM.IServices
{
    public interface IMOService : IScopedService
    {
        /// <summary>
        /// 生产订单保存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse MOSave(MOView request);


        /// <summary>
        /// 生产订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse MOQuery(MOQueryView request);

        /// <summary>
        /// 根据ID查询单据信息：用于修改单据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse MOQueryByID(MOLineQueryView request);
    }
}
