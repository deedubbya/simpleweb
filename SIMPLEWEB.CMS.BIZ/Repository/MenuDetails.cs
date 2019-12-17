using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class MenuDetails : IMenuDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();
        IMenuNavigationItemDetails mnavRepository = new MenuNavigationItemDetails();
        public IEnumerable<MenuViewModel> GetAll()
        {
            List<MenuViewModel> items = db.Menus.Select(m =>
                new MenuViewModel
                {
                    ID = m.mID,
                    Name = m.mName
                }
            ).ToList();
            items.ForEach(m => m.NavigationItems = mnavRepository.GetAll().Where(mn => mn.MenuID == m.ID).ToList());

            return items;
        }

        public MenuViewModel GetByID(int id)
        {
            MenuViewModel item = db.Menus.Where(i => i.mID == id).Select(i =>
                new MenuViewModel
                {
                    ID = i.mID,
                    Name = i.mName
                }
            ).FirstOrDefault();
            item.NavigationItems = mnavRepository.GetAll().Where(mn => mn.MenuID == id).ToList();
            return item;
        }

        public int Insert(MenuViewModel dt)
        {
            Menu dr = new Menu();
            dr.mName = dt.Name;
            db.Menus.Add(dr);
            var Result = db.SaveChanges();

            return dr.mID;
        }

        public int Insert(string menuName)
        {
            Menu dr = new Menu() { mName = menuName };
            db.Menus.Add(dr);
            db.SaveChanges();

            return dr.mID;
        }
        
        public bool Update(MenuViewModel dt, int id)
        {
            Menu dr = db.Menus.Where(i => i.mID == id).FirstOrDefault();
            dr.mID = dt.ID;
            dr.mName = dt.Name;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(MenuViewModel dt, int id)
        {
            return DeleteByID(id);
        }

        public bool DeleteByID(int id)
        {
            Menu dr = db.Menus.Where(i => i.mID == id).FirstOrDefault();
            db.Menus.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }
    }
}