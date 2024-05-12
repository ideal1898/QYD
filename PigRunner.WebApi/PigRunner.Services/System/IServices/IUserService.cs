﻿using PigRunner.Entitys.System;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService: IScopedService
    {
        void Save(SysUser sysUser);
    }
}
