using System.Security.Cryptography;

namespace TLMManager.Utils
{
    public class Md5Encrypt
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="code">默认为16位加密</param>
        /// <returns></returns>
        public static string Md5(string str, int code = 16)
        {
            return code == 16 ? MD5.Create(str).ToString().ToLower().Substring(8, 16) : MD5.Create(str).ToString().ToLower();
        }
    }
}
