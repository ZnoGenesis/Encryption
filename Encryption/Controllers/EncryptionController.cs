using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppCtrl.Encryption;
using Encryption.Models;
namespace Encryption.Controllers
{
    public class EncryptionController : Controller
    {
        // GET: Encrytion
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Encrypt(Encrypt encrypt)
        {
            GenericEncryption.key = encrypt.Key;
            GenericEncryption.vector = encrypt.Vector;
            var output = GenericEncryption.Encrypt(encrypt.Data, LevelEncrypt.medium);
            return Json(output, JsonRequestBehavior.AllowGet);   
           
        }
        [HttpPost]
        public ActionResult Decrypt(Encrypt decrypt)
        {
            GenericEncryption.key = decrypt.Key;
            GenericEncryption.vector = decrypt.Vector;
            var output = GenericEncryption.Decrypt(decrypt.Data, LevelEncrypt.medium);
            return Json(output, JsonRequestBehavior.AllowGet);   
        }
        [HttpPost]
        public ActionResult Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Json(System.Convert.ToBase64String(plainTextBytes),JsonRequestBehavior.AllowGet);
        
        }
        [HttpPost]
        public ActionResult Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return Json(System.Text.Encoding.UTF8.GetString(base64EncodedBytes), JsonRequestBehavior.AllowGet); 
        }
    }
}