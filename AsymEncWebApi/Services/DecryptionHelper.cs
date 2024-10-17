using System.Security.Cryptography;

namespace AsymEncWebApi.Services
{
    public class DecryptionHelper
    {
        public string DecryptData(byte[] encryptedData, string privateKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(privateKey), out _);
                byte[] decryptedBytes = rsa.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);
                return System.Text.Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
