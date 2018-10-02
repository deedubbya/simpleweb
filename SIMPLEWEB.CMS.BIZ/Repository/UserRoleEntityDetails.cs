using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class UserRoleEntityDetails : IUserRoleEntityDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<UserRoleEntityViewModel> GetAll()
        {
            var items = db.UserRoleEntities.Select(i =>
                new UserRoleEntityViewModel
                {
                    ID = i.ureID,
                    UserID = i.ureUserID,
                    UserRoleID = i.ureUserRoleID
                }
            );
            return items.ToList();
        }

        public UserRoleEntityViewModel GetByID(int id)
        {
            var result = db.UserRoleEntities.Where(i => true).Select(i =>
                new UserRoleEntityViewModel
                {
                    ID = i.ureID,
                    UserID = i.ureUserID,
                    UserRoleID = i.ureUserRoleID
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(UserRoleEntityViewModel dt)
        {
            UserRoleEntity dr = new UserRoleEntity();
            dr.ureID = dt.ID;
            dr.ureUserID = dt.UserID;
            dr.ureUserRoleID = dt.UserRoleID;
            db.UserRoleEntities.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Update(UserRoleEntityViewModel dt, int id)
        {
            UserRoleEntity dr = db.UserRoleEntities.Where(i => i.ureID == id).FirstOrDefault();
            dr.ureID = dt.ID;
            dr.ureUserID = dt.UserID;
            dr.ureUserRoleID = dt.UserRoleID;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(UserRoleEntityViewModel dt, int id)
        {
            UserRoleEntity dr = db.UserRoleEntities.Where(i => i.ureID == id).FirstOrDefault();
            db.UserRoleEntities.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}