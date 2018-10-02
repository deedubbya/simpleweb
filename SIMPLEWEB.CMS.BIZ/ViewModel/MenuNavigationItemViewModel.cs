using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLEWEB.CMS.BIZ
{
    public class MenuNavigationItemViewModel
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public int MenuHeirarchy { get; set; }
        public int MenuSort { get; set; }
        public string LinkType { get; set; }
        public int? PageID { get; set; }
        public string ExternalLink { get; set; }
        public string Title { get; set; }
    }
}