using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace OmegaC
{
    public class Encryptor
    {
        public static string EncryptText(string plainText)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            ASCIIEncoding ascii = new ASCIIEncoding();
            StringBuilder str = new StringBuilder();

            byte[] hash = md5.ComputeHash(ascii.GetBytes(plainText));

            for (int i = 0; i < hash.Length; i++)
            {
                str.Append(hash[i].ToString("x2"));
            }

            return str.ToString();
        }


    }
}