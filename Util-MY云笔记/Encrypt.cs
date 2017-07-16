using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Util_MY云笔记
{
    public class Encrypt
    {
        public static string MD5ToString(params string[] texts)
        {
            string text = "";
            MD5 md5 = new MD5CryptoServiceProvider();
            for (int i = 0; i < texts.Length; i++)
            {
                text += texts[i];
            }
            byte[] data = Encoding.Default.GetBytes(text);
            byte[] result = md5.ComputeHash(data);
            String strReturn = String.Empty;
            for (int i = 0; i < result.Length; i++)
                strReturn += result[i].ToString("x").PadLeft(2, '0');
            return strReturn;
        }
    }
}
