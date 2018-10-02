using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLEWEB.CMS.BIZ
{
    public class PageViewModel
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public bool IsHomePage { get; set; }
        public string Visibility { get; set; }
        public string HeaderTitle { get; set; }
        public string HtmlContent { get; set; }
    }
}