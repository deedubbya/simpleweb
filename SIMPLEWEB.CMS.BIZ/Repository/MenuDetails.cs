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

        public IEnumerable<MenuViewModel> GetAll()
        {
            var items = db.Menus.Select(i =>
                new MenuViewModel
                {
                    ID = i.mID,
                    Name = i.mName
                }
            );
            return items.ToList();
        }

        public MenuViewModel GetByID(int id)
        {
            var result = db.Menus.Where(i => true).Select(i =>
                new MenuViewModel
                {
                    ID = i.mID,
                    Name = i.mName
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(MenuViewModel dt)
        {
            Menu dr = new Menu();
            dr.mID = dt.ID;
            dr.mName = dt.Name;
            db.Menus.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
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
            Menu dr = db.Menus.Where(i => i.mID == id).FirstOrDefault();
            db.Menus.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}