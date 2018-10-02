using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLEWEB.CMS.BIZ
{
    public class CustomPropertyViewModel
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public int? TableID { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
}