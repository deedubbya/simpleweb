using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLEWEB.CMS.BIZ
{
    public class AddressEntityViewModel
    {
        public int ID { get; set; }
        public int AddressID { get; set; }
        public string TableName { get; set; }
        public int TableID { get; set; }
        public string AddressType { get; set; }
    }
}