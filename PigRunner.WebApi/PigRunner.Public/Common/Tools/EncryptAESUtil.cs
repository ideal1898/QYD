
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Public.Common.Tools
 * 唯一标识：9a09edda-f6d2-44e8-805d-f260edebfa35
 * 文件名：EncryptAESUtil
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/15 1:41:43
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Tools
{
    public class EncryptAESUtil
    {
        /// <summary>
        /// 使用AES加密
        /// </summary>
        /// <param name="EncryptCiphertext">加密明文</param>
        /// <returns></returns>
        public static string EncryptByAES(string EncryptCiphertext)
        {
            string SourceKey = "qerhg!@#$1234562";
            string TargetKey = "poiuy!@#$6543213";
            if (string.IsNullOrWhiteSpace(EncryptCiphertext))
            {
                return EncryptCiphertext;
            }
            EncryptCiphertext = System.Web.HttpUtility.UrlEncode(EncryptCiphertext);
            EncryptCiphertext = System.Web.HttpUtility.UrlDecode(EncryptCiphertext);
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.FeedbackSize = 128;
                rijndaelManaged.Key = Encoding.UTF8.GetBytes(SourceKey);
                rijndaelManaged.IV = Encoding.UTF8.GetBytes(TargetKey);
                ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(EncryptCiphertext);
                        }
                        byte[] bytes = msEncrypt.ToArray();
                        return Convert.ToBase64String(bytes);
                    }
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="DecipherCiphertext">解密密文</param>
        /// <returns></returns>
        public static string DecryptByAES(string DecipherCiphertext)
        {
            string SourceKey = "qerhg!@#$1234562";
            string TargetKey = "poiuy!@#$6543213";

            if (string.IsNullOrWhiteSpace(DecipherCiphertext))
            {
                return DecipherCiphertext;
            }
            DecipherCiphertext = System.Web.HttpUtility.UrlEncode(DecipherCiphertext);
            string str = System.Web.HttpUtility.UrlDecode(DecipherCiphertext);
            var buffer = Convert.FromBase64String(str);
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.FeedbackSize = 128;
                rijndaelManaged.Key = Encoding.UTF8.GetBytes(SourceKey);
                rijndaelManaged.IV = Encoding.UTF8.GetBytes(TargetKey);
                ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
                using (MemoryStream msEncrypt = new MemoryStream(buffer))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srEncrypt = new StreamReader(csEncrypt))
                        {
                            return srEncrypt.ReadToEnd();
                        }
                    }
                }
            }

        }
    }
}
