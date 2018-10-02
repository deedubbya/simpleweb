using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLEWEB.CMS.BIZ
{
    public class AddressViewModel
    {
        public int ID { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string LineThree { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int? ZipPlusFour { get; set; }
    }
}