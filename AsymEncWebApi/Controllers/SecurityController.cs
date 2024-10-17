using AsymEncWebApi.Models;
using AsymEncWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace AsymEncWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly DecryptionHelper _decryptionHelper;
        private readonly EncryptionHelper _encryptionHelper;
        private readonly KeyGenerator _keyGenerator;
        private readonly SignatureHelper _signatureHelper;
        private readonly VerificationHelper _verificationHelper;
        public SecurityController(KeyGenerator keyGenerator,
            DecryptionHelper decryptionHelper, 
            EncryptionHelper encryptionHelper, 
            SignatureHelper signatureHelper, 
            VerificationHelper verificationHelper) { 
            _keyGenerator = keyGenerator;
            _decryptionHelper = decryptionHelper;
            _encryptionHelper = encryptionHelper;
            _signatureHelper = signatureHelper;
            _verificationHelper = verificationHelper;               
        
        }

        [HttpGet]
        public IActionResult GetKeyGenerator() {
            List<string> kys=_keyGenerator.GenerateKeys();
            var pKeys = new KeysModel();
            pKeys.publicKey = kys[0];
            pKeys.privateKey = kys[1];

            return Ok(pKeys);

        }


        [HttpPost]
        public IActionResult PostEncryptData([FromForm]RequestMsg requestMsg)
        {
            byte[] encryptedData = _encryptionHelper.EncryptData(requestMsg.MsgData, requestMsg.Key);

            string base64String = Convert.ToBase64String(encryptedData);

            return Ok(base64String);
        }


        [HttpPost]
        public IActionResult PostDecryptData([FromForm] RequestMsg requestMsg)
        {
            byte[] byteArray = Convert.FromBase64String(requestMsg.MsgData);
            string decryptedData = _decryptionHelper.DecryptData(byteArray, requestMsg.Key);

            return Ok(decryptedData);
        }


        [HttpPost]
        public IActionResult PostSignData([FromForm] RequestMsg requestMsg)
        {
            
            byte[] signature = _signatureHelper.SignData(requestMsg.MsgData, requestMsg.Key);

            string base64String = Convert.ToBase64String(signature);

            return Ok(base64String);
        }


        [HttpPost]
        public IActionResult PostVerifySignatureData([FromForm] RequestSig requestMsg)
        {
            byte[] byteArray = Convert.FromBase64String(requestMsg.SigData);
            bool vStataus = _verificationHelper.VerifySignature(requestMsg.MsgData,byteArray, requestMsg.Key);

            return Ok(vStataus);
        }    

    }
}
