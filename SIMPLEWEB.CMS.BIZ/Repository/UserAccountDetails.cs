using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class UserAccountDetails : IUserAccountDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<UserAccountViewModel> GetAll()
        {
            var items = db.UserAccounts.Select(i =>
                new UserAccountViewModel
                {
                    ID = i.uaId
                }
            );
            return items.ToList();
        }

        public UserAccountViewModel GetByID(int id)
        {
            var result = db.UserAccounts.Where(i => true).Select(i =>
                new UserAccountViewModel
                {
                    ID = i.uaId
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(UserAccountViewModel dt)
        {
            UserAccount dr = new UserAccount();
            dr.uaId = dt.ID;
            db.UserAccounts.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Update(UserAccountViewModel dt, int id)
        {
            UserAccount dr = db.UserAccounts.Where(i => i.uaId == id).FirstOrDefault();
            dr.uaId = dt.ID;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(UserAccountViewModel dt, int id)
        {
            UserAccount dr = db.UserAccounts.Where(i => i.uaId == id).FirstOrDefault();
            db.UserAccounts.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}