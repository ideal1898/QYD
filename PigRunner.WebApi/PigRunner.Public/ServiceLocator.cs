using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public
{
    /// <summary>
    /// 服务获取容器
    /// </summary>
    public static class ServiceLocator
    {
        /// <summary>
        /// ServiceProvider实例
        /// </summary>
        public static IServiceProvider? Instance { get; set; }
    }
}
