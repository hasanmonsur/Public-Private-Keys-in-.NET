using System.Security.Cryptography;

namespace AsymEncWebApi.Services
{
    public class SignatureHelper
    {
        public byte[] SignData(string dataToSign, string privateKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(privateKey), out _);
                byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(dataToSign);
                return rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
    }
}
