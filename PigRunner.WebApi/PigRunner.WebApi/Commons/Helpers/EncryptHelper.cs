using System.Security.Cryptography;
using System.Text;

namespace PigRunner.WebApi.Commons.Helpers
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public class EncryptHelper
    {
        private const string KeyEncrypt = "!@#WebApi.8";

        private static byte[] Keys = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

        #region AES

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <param name="encryptKey"></param>
        /// <returns></returns>
        public static string DESEncrypt(string encryptString, string encryptKey = KeyEncrypt)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 16));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                var DCSP = Aes.Create();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(LogEnum.System, "AES加密异常", ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="decryptString"></param>
        /// <param name="decryptKey"></param>
        /// <returns></returns>
        public static string DESDecrypt(string decryptString, string decryptKey = KeyEncrypt)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 16));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                var DCSP = Aes.Create();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                byte[] inputByteArrays = new byte[inputByteArray.Length];
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(LogEnum.System, "AES解密异常", ex);
                return string.Empty;
            }

        }

        #endregion

        #region MD5

        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string value)
        {
            try
            {
                var result = string.Empty;
                if (string.IsNullOrEmpty(value))
                {
                    return result;
                }
                using (var md5 = MD5.Create())
                {
                    byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
                    var sBuilder = new StringBuilder();
                    foreach (byte t in data)
                    {
                        sBuilder.Append(t.ToString("x2"));
                    }
                    return sBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(LogEnum.System, "MD5加密异常", ex);
                return string.Empty;
            }
        }

        #endregion

    }
}
