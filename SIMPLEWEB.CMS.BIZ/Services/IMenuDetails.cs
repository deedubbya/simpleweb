using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPLEWEB.CMS.BIZ
{
    public interface IMenuDetails : IGenericDetails<MenuViewModel>
    {
        int Insert(string title);
    }
}