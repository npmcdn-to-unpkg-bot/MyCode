using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMManager.Utils
{
    public class MD5Encrypt
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="code">默认为16位加密</param>
        /// <returns></returns>
        public static string MD5(string str, int code = 16)
        {
            if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                return System.Security.Cryptography.MD5.Create(str).ToString().ToLower().Substring(8, 16);
            }
            else//32位加密 
            {
                return System.Security.Cryptography.MD5.Create(str).ToString().ToLower();
            }
        }
    }
}
