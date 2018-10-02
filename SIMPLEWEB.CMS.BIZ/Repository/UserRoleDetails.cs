using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class UserRoleDetails : IUserRoleDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<UserRoleViewModel> GetAll()
        {
            var items = db.UserRoles.Select(i =>
                new UserRoleViewModel
                {
                    ID = i.urID,
                    RoleName = i.urRoleName
                }
            );
            return items.ToList();
        }

        public UserRoleViewModel GetByID(int id)
        {
            var result = db.UserRoles.Where(i => true).Select(i =>
                new UserRoleViewModel
                {
                    ID = i.urID,
                    RoleName = i.urRoleName
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(UserRoleViewModel dt)
        {
            UserRole dr = new UserRole();
            dr.urID = dt.ID;
            dr.urRoleName = dt.RoleName;
            db.UserRoles.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Update(UserRoleViewModel dt, int id)
        {
            UserRole dr = db.UserRoles.Where(i => i.urID == id).FirstOrDefault();
            dr.urID = dt.ID;
            dr.urRoleName = dt.RoleName;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(UserRoleViewModel dt, int id)
        {
            UserRole dr = db.UserRoles.Where(i => i.urID == id).FirstOrDefault();
            db.UserRoles.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}