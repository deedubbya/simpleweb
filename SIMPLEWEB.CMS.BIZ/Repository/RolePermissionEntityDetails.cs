using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class RolePermissionEntityDetails : IRolePermissionEntityDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<RolePermissionEntityViewModel> GetAll()
        {
            var items = db.RolePermissionEntities.Select(i =>
                new RolePermissionEntityViewModel
                {
                    ID = i.rpeID,
                    UserRoleID = i.rpeUserRoleID,
                    RolePermissionID = i.rpeRolePermissionID
                }
            );
            return items.ToList();
        }

        public RolePermissionEntityViewModel GetByID(int id)
        {
            var result = db.RolePermissionEntities.Where(i => true).Select(i =>
                new RolePermissionEntityViewModel
                {
                    ID = i.rpeID,
                    UserRoleID = i.rpeUserRoleID,
                    RolePermissionID = i.rpeRolePermissionID
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(RolePermissionEntityViewModel dt)
        {
            RolePermissionEntity dr = new RolePermissionEntity();
            dr.rpeID = dt.ID;
            dr.rpeUserRoleID = dt.UserRoleID;
            dr.rpeRolePermissionID = dt.RolePermissionID;
            db.RolePermissionEntities.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Update(RolePermissionEntityViewModel dt, int id)
        {
            RolePermissionEntity dr = db.RolePermissionEntities.Where(i => i.rpeID == id).FirstOrDefault();
            dr.rpeID = dt.ID;
            dr.rpeUserRoleID = dt.UserRoleID;
            dr.rpeRolePermissionID = dt.RolePermissionID;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(RolePermissionEntityViewModel dt, int id)
        {
            RolePermissionEntity dr = db.RolePermissionEntities.Where(i => i.rpeID == id).FirstOrDefault();
            db.RolePermissionEntities.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}