
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Public.Helpers
 * 唯一标识：830e3dd1-c380-4467-86c8-782850b87304
 * 文件名：JWTHelper
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/5/14 15:45:56
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


using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PigRunner.Public.Common.Views;
using PigRunner.WebApi.Commons.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Helpers
{
    /// <summary>
    /// JWT帮助类
    /// </summary>
    public class JWTHelper
    {
        /// <summary>
        /// 创建JWT
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string CreateJWTToken(LoginUserVo user)
        {
            var jwtConfig = ConfigHelper.GetJwtConfig();
            var JWToken = new JwtSecurityToken(
                    issuer: jwtConfig.Issuer,
                    audience: jwtConfig.Audience,
                    claims: GetLoginUserClaims(user),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddSeconds(jwtConfig.Expires)).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)), SecurityAlgorithms.HmacSha256Signature)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return token;
        }
        public static string JWTToken(LoginUserVo loginUser)
        {
            var jwtConfig = ConfigHelper.GetJwtConfig();
            var JWToken = new JwtSecurityToken(
                    issuer: jwtConfig.Issuer,
                    audience: jwtConfig.Audience,
                    claims: GetLoginUserClaims(loginUser),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddSeconds(jwtConfig.Expires)).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)), SecurityAlgorithms.HmacSha256Signature)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return token;
        }
        private static IEnumerable<Claim> GetLoginUserClaims(LoginUserVo user)
        {
            IEnumerable<Claim> claims = new Claim[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("UserName", user.UserName.ToString()),
                new Claim("Nickname", user.Nickname ?? string.Empty),
                new Claim("IsAdmin", user.IsAdmin?"1":"0")
            };
            return claims;
        }

        /// <summary>
        /// 解析JWT
        /// </summary>
        /// <param name="token"></param>
        public static LoginUserVo? JWTDecode(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }
                var auth = token.Split(" ")[1].Split('.');
                var user = JsonConvert.DeserializeObject<LoginUserVo>(Base64UrlEncoder.Decode(auth[1]));
                return user;
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(LogEnum.System, "解析JWT异常", ex);
                return null;
            }
        }

        public static LoginUserVo? JWTLoginDecode(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }
                var auth = token.Split(" ")[1].Split('.');
                var loginUserView = JsonConvert.DeserializeObject<LoginUserVo>(Base64UrlEncoder.Decode(auth[1]));
                return loginUserView;
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(LogEnum.System, "解析JWT异常", ex);
                return null;
            }
        }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsExpired(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);

                if (jwt == null)
                {
                    return true;
                }

                if (jwt.ValidTo < DateTime.Now)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
