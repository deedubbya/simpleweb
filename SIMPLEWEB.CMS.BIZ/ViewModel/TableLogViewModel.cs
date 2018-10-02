using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLEWEB.CMS.BIZ
{
    public class TableLogViewModel
    {
        public int ID { get; set; }
        public string LogType { get; set; }
        public int UserID { get; set; }
        public DateTime? LogDate { get; set; }
        public string LogDescription { get; set; }
    }
}