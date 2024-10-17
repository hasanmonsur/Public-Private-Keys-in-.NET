using System.Security.Cryptography;

namespace AsymEncWebApi.Services
{
    public class EncryptionHelper
    {
        public byte[] EncryptData(string dataToEncrypt, string publicKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out _);
                return rsa.Encrypt(System.Text.Encoding.UTF8.GetBytes(dataToEncrypt), RSAEncryptionPadding.Pkcs1);
            }

        }
    }
}
