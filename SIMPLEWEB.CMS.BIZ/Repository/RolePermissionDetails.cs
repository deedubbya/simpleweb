using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class RolePermissionDetails : IRolePermissionDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<RolePermissionViewModel> GetAll()
        {
            var items = db.RolePermissions.Select(i =>
                new RolePermissionViewModel
                {
                    ID = i.rpID,
                    Name = i.rpPermissionName,
                    Description = i.rpPermissionDescription
                }
            );
            return items.ToList();
        }

        public RolePermissionViewModel GetByID(int id)
        {
            var result = db.RolePermissions.Where(i => true).Select(i =>
                new RolePermissionViewModel
                {
                    ID = i.rpID,
                    Name = i.rpPermissionName,
                    Description = i.rpPermissionDescription
                }
            );
            return result.FirstOrDefault();
        }

        public int Insert(RolePermissionViewModel dt)
        {
            RolePermission dr = new RolePermission();
            dr.rpPermissionName = dr.rpPermissionName;
            dr.rpPermissionDescription = dr.rpPermissionDescription;
            db.RolePermissions.Add(dr);
            var Result = db.SaveChanges();

            return dr.rpID;
        }

        public bool Update(RolePermissionViewModel dt, int id)
        {
            RolePermission dr = db.RolePermissions.Where(i => i.rpID == id).FirstOrDefault();
            dr.rpID = dr.rpID;
            dr.rpPermissionName = dr.rpPermissionName;
            dr.rpPermissionDescription = dr.rpPermissionDescription;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(RolePermissionViewModel dt, int id)
        {
            RolePermission dr = db.RolePermissions.Where(i => i.rpID == id).FirstOrDefault();
            db.RolePermissions.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}