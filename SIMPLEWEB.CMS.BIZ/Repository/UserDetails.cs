using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class UserDetails : IUserDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<UserViewModel> GetAll()
        {
            var items = db.Users.Select(i =>
                new UserViewModel
                {
                    ID = i.uID,
                    Status = i.uStatus,
                    FirstName = i.uFirstName,
                    LastName = i.uLastName,
                    EmailAddress = i.uEmailAddress,
                    Password = i.uPassword
                }
            );
            return items.ToList();
        }

        public UserViewModel GetByID(int id)
        {
            var result = db.Users.Where(i => i.uID == id).Select(i =>
                new UserViewModel
                {
                    ID = i.uID,
                    Status = i.uStatus,
                    FirstName = i.uFirstName,
                    LastName = i.uLastName,
                    EmailAddress = i.uEmailAddress,
                    Password = i.uPassword
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(UserViewModel dt)
        {
            User dr = new User();
            dr.uID = dt.ID;
            dr.uStatus = dt.Status;
            dr.uFirstName = dt.FirstName;
            dr.uLastName = dt.LastName;
            dr.uEmailAddress = dt.EmailAddress;
            dr.uPassword = dt.Password;
            db.Users.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Update(UserViewModel dt, int id)
        {
            User dr = db.Users.Where(i => i.uID == id).FirstOrDefault();
            dr.uID = dt.ID;
            dr.uStatus = dt.Status;
            dr.uFirstName = dt.FirstName;
            dr.uLastName = dt.LastName;
            dr.uEmailAddress = dt.EmailAddress;
            dr.uPassword = dt.Password;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(UserViewModel dt, int id)
        {
            User dr = db.Users.Where(i => i.uID == id).FirstOrDefault();
            dr.uStatus = Constants.UserStatus.INACTIVE.ToString();
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}