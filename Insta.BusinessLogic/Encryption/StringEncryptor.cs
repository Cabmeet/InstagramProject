using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Insta.BusinessLogic.Encryption
{
    public static class StringEncryptor
    {
        private const string EncryptionKey = "abc123";

        private static readonly byte[] slat = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

        public static string Decrypt(string encryptedString)
        {
            encryptedString = encryptedString.Replace(" ", "+");
            var bytes = Convert.FromBase64String(encryptedString);

            using var encryptor = Aes.Create();

            var pdb = new Rfc2898DeriveBytes(
                EncryptionKey,
                slat);
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);

            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.Close();

            return Encoding.Unicode.GetString(ms.ToArray());
        }

        public static string Encrypt(string text)
        {
            var bytes = Encoding.Unicode.GetBytes(text);

            using var encryptor = Aes.Create();

            var pdb = new Rfc2898DeriveBytes(
                EncryptionKey,
                slat);
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);

            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}