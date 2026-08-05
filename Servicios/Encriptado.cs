using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class Encriptado
    {
        public static string Hashear(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(value));
            return (new ASCIIEncoding()).GetString(md5data);
        }

        private static readonly string Key = "1234567890123456";
        private static readonly string IV = "6543210987654321";

        public static string Encriptar(string plainText)
        {
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);

            sw.Write(plainText);
            sw.Close();
            cs.Close();
            ms.Close();

            byte[] encryptedBytes = ms.ToArray();
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Desencriptrar(string cipherText)
        {
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] buffer = Convert.FromBase64String(cipherText);

            MemoryStream ms = new MemoryStream(buffer);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);

            string plaintext = sr.ReadToEnd();
            sr.Close();
            cs.Close();
            ms.Close();

            return plaintext;
        }
    }
}
