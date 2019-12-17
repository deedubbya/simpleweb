using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLEWEB.CMS.BIZ
{
    public class MenuViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<MenuNavigationItemViewModel> NavigationItems {get;set;}
    }
}