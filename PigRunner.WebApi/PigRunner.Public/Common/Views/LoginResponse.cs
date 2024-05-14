
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Public.Common.Views
 * 唯一标识：38c97f12-a066-4837-a81c-9c941cd24e4d
 * 文件名：LoginResponse
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/5/14 9:13:41
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Views
{
    /// <summary>
    /// 登录返回响应
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }=false;
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }=string.Empty;
        /// <summary>
        /// token（令牌）
        /// </summary>
        public string Token { get; set; } = string.Empty;
        public LoginUserVo LoginUser { get; set; }=new LoginUserVo();

        public static LoginResponse Error(string msg) { 
            return new LoginResponse { Success = false, Message = msg };        
        }
    }
}
