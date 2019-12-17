using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class AccountDetails : IAccountDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<AccountViewModel> GetAll()
        {
            var items = db.Accounts.Select(i =>
                new AccountViewModel
                {
                    ID = i.aID,
                    Status = i.aStatus,
                    CompanyName = i.aCompanyName
                }
            );
            return items.ToList();
        }

        public AccountViewModel GetByID(int id)
        {
            var result = db.Accounts.Where(i => i.aID == id).Select(i =>
                new AccountViewModel
                {
                    ID = i.aID,
                    Status = i.aStatus,
                    CompanyName = i.aCompanyName
                }
            );
            return result.FirstOrDefault();
        }

        public int Insert(AccountViewModel dt)
        {
            Account dr = new Account();
            dr.aStatus = dt.Status;
            dr.aCompanyName = dt.CompanyName;
            db.Accounts.Add(dr);
            var Result = db.SaveChanges();
            return dr.aID;
        }

        public bool Update(AccountViewModel dt, int id)
        {
            Account dr = db.Accounts.Where(i => i.aID == id).FirstOrDefault();
            dr.aID = dt.ID;
            dr.aStatus = dt.Status;
            dr.aCompanyName = dt.CompanyName;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(AccountViewModel dt, int id)
        {
            Account dr = db.Accounts.Where(i => i.aID == id).FirstOrDefault();
            dr.aStatus = Constants.AccountStatus.INACTIVE.ToString();
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}