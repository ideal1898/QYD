using PigRunner.Public.Common.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Context
{
    /// <summary>
    /// 当前登录信息:组织,用户
    /// </summary>
    public interface ILoginAppContext
    {
        /// <summary>
        /// 登录上下文信息:用户+组织
        /// </summary>
        LoginUserVo LoginToken { get; }
        /// <summary>
        /// 用户有效token
        /// </summary>
        string CurrentToken { get; }

        /// <summary>
        /// 是否已认证
        /// </summary>
        /// <returns></returns>
        bool IsAuthenticated { get; }
    }
}
