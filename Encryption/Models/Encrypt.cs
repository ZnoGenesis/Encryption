using AppCtrl.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Encryption.Models
{
    public class Encrypt
    {
        public string Key { get; set; }
        public string Vector { get; set; }
        public string Data { get; set; }
        public string level { get; set; }
    }
}