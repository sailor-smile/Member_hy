using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member_hy.Utils
{
    public class Base64Util
    {
        /// <summary>
        /// 加密为base64字符串
        /// </summary>
        /// <param name="value">加密字符串</param>
        /// <returns></returns>
        public static string EncodeBase64(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="value">解密字符串</param>
        /// <returns></returns>
        public static string DecodeBase64(string value)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
