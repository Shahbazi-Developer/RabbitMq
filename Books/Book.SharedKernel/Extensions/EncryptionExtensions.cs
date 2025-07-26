using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Book.SharedKernel.Extensions
{
    public static class EncryptionExtensions
    {

        private static string GetKey()
        {
            //TODO: move to a secure address
            var keyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "aes.key");
            var key = File.ReadAllText(keyPath);
            return key;
        }

        public static string Encrypt(string plainText)
        {
            try
            {
                var key = GetKey();
                var iv = new byte[16];
                using var aes = Aes.Create();
                aes.Key = Convert.FromBase64String(key);
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using var encryptor = aes.CreateEncryptor();
                using var ms = new MemoryStream();
                using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public static string Decrypt(string cipherText)
        {
            try
            {
                var key = GetKey();
                var iv = new byte[16];
                var buffer = Convert.FromBase64String(cipherText);

                using var aes = Aes.Create();
                aes.Key = Convert.FromBase64String(key);
                aes.IV = iv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using var ms = new MemoryStream(buffer);
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
