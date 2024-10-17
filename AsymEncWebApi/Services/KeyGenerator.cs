using System.Security.Cryptography;

namespace AsymEncWebApi.Services
{
    public class KeyGenerator
    {
        public List<string> GenerateKeys()
        {
            var kys = new List<string>();

            string publicKey="",privateKey = "";

            using (RSA rsa = RSA.Create(2048))
            {
                publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
                privateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());

                kys.Add(publicKey);
                kys.Add(privateKey);
            }

            return kys;

        }
    }
}
