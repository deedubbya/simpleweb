using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class MenuNavigationItemDetails : IMenuNavigationItemDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();
        IPageDetails pRepository = new PageDetails();

        public IEnumerable<MenuNavigationItemViewModel> GetAll()
        {
            List<MenuNavigationItemViewModel> items = db.MenuNavigationItems.Select(i =>
                new MenuNavigationItemViewModel
                {
                    ID = i.mniID,
                    MenuID = i.mniMenuID,
                    MenuHeirarchy = i.mniMenuHierarchy,
                    MenuSort = i.mniMenuSort,
                    Title = i.mniTitle,
                    LinkType = i.mniLinkType,
                    PageID = i.mniPageID,
                    PageUrl = i.mniPageUrl,
                    ExternalLink = i.mniExternalLink
                }
            ).ToList();
            return items.ToList();
        }

        public MenuNavigationItemViewModel GetByID(int id)
        {
            MenuNavigationItemViewModel result = db.MenuNavigationItems.Where(i => true).Select(i =>
                new MenuNavigationItemViewModel
                {
                    ID = i.mniID,
                    MenuID = i.mniMenuID,
                    MenuHeirarchy = i.mniMenuHierarchy,
                    MenuSort = i.mniMenuSort,
                    Title = i.mniTitle,
                    LinkType = i.mniLinkType,
                    PageID = i.mniPageID,
                    PageUrl = i.mniPageUrl,
                    ExternalLink = i.mniExternalLink
                }
            ).FirstOrDefault();
            return result;
        }

        public int Insert(MenuNavigationItemViewModel dt)
        {
            MenuNavigationItem dr = new MenuNavigationItem();
            dr.mniMenuID = dt.MenuID;
            dr.mniMenuHierarchy = dt.MenuHeirarchy;
            dr.mniMenuSort = dt.MenuSort;
            dr.mniTitle = dt.Title;
            dr.mniLinkType = dt.LinkType;
            dr.mniExternalLink = dt.ExternalLink;
            dr.mniPageID = dt.PageID;
            dr.mniPageUrl = dt.PageUrl;
            db.MenuNavigationItems.Add(dr);
            var Result = db.SaveChanges();

            return dr.mniID;
        }

        public bool Update(MenuNavigationItemViewModel dt, int id)
        {
            MenuNavigationItem dr = db.MenuNavigationItems.Where(i => i.mniID == id).FirstOrDefault();
            dr.mniID = dt.ID;
            dr.mniMenuID = dt.MenuID;
            dr.mniMenuHierarchy = dt.MenuHeirarchy;
            dr.mniMenuSort = dt.MenuSort;
            dr.mniTitle = dt.Title;
            dr.mniLinkType = dt.LinkType;
            dr.mniExternalLink = dt.ExternalLink;
            dr.mniPageID = dt.PageID;
            dr.mniPageUrl = dt.PageUrl;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(MenuNavigationItemViewModel dt, int id)
        {
            MenuNavigationItem dr = db.MenuNavigationItems.Where(i => i.mniID == id).FirstOrDefault();
            db.MenuNavigationItems.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}