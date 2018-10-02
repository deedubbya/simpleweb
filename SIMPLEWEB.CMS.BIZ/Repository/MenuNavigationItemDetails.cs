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

        public IEnumerable<MenuNavigationItemViewModel> GetAll()
        {
            var items = db.MenuNavigationItems.Select(i =>
                new MenuNavigationItemViewModel
                {
                    ID = i.mniID,
                    MenuID = i.mniMenuID,
                    MenuHeirarchy = i.mniMenuHierarchy,
                    MenuSort = i.mniMenuSort,
                    Title = i.mniTitle,
                    LinkType = i.mniLinkType,
                    ExternalLink = i.mniExternalLink,
                    PageID = i.mniPageID
                }
            );
            return items.ToList();
        }

        public MenuNavigationItemViewModel GetByID(int id)
        {
            var result = db.MenuNavigationItems.Where(i => true).Select(i =>
                new MenuNavigationItemViewModel
                {
                    ID = i.mniID,
                    MenuID = i.mniMenuID,
                    MenuHeirarchy = i.mniMenuHierarchy,
                    MenuSort = i.mniMenuSort,
                    Title = i.mniTitle,
                    LinkType = i.mniLinkType,
                    ExternalLink = i.mniExternalLink,
                    PageID = i.mniPageID
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(MenuNavigationItemViewModel dt)
        {
            MenuNavigationItem dr = new MenuNavigationItem();
            dr.mniID = dt.ID;
            dr.mniMenuID = dt.MenuID;
            dr.mniMenuHierarchy = dt.MenuHeirarchy;
            dr.mniMenuSort = dt.MenuSort;
            dr.mniTitle = dt.Title;
            dr.mniLinkType = dt.LinkType;
            dr.mniExternalLink = dt.ExternalLink;
            dr.mniPageID = dt.PageID;
            db.MenuNavigationItems.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
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