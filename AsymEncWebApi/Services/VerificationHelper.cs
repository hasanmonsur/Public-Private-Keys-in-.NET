using System.Security.Cryptography;

namespace AsymEncWebApi.Services
{
    public class VerificationHelper
    {
        public bool VerifySignature(string originalData, byte[] signature, string publicKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out _);
                byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(originalData);
                return rsa.VerifyData(dataBytes, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
    }
}
