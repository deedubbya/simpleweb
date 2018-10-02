using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class AddressDetails : IAddressDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();
        
        public IEnumerable<AddressViewModel> GetAll()
        {
            var items = db.Addresses.Select(i =>
                new AddressViewModel
                {
                    ID = i.adrID,
                    LineOne = i.adrLine1,
                    LineTwo = i.adrLine2,
                    LineThree = i.adrLine3,
                    City = i.adrCity,
                    State = i.adrState,
                    ZipCode = i.adrZipCode,
                    ZipPlusFour = i.adrZipPlusFour
                }
            );
            return items.ToList();
        }

        public AddressViewModel GetByID(int id)
        {
            var result = db.Addresses.Where(i => true).Select(i =>
                new AddressViewModel
                {
                    ID = i.adrID,
                    LineOne = i.adrLine1,
                    LineTwo = i.adrLine2,
                    LineThree = i.adrLine3,
                    City = i.adrCity,
                    State = i.adrState,
                    ZipCode = i.adrZipCode,
                    ZipPlusFour = i.adrZipPlusFour
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(AddressViewModel dt)
        {
            Address dr = new Address();
            dr.adrID = dt.ID;
            dr.adrLine1 = dt.LineOne;
            dr.adrLine2 = dt.LineTwo;
            dr.adrLine3 = dt.LineThree;
            dr.adrCity = dt.City;
            dr.adrState = dt.State;
            dr.adrZipCode = dt.ZipCode;
            dr.adrZipPlusFour = dt.ZipPlusFour;
            db.Addresses.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Update(AddressViewModel dt, int id)
        {
            Address dr = db.Addresses.Where(i => i.adrID == id).FirstOrDefault();
            dr.adrID = dt.ID;
            dr.adrLine1 = dt.LineOne;
            dr.adrLine2 = dt.LineTwo;
            dr.adrLine3 = dt.LineThree;
            dr.adrCity = dt.City;
            dr.adrState = dt.State;
            dr.adrZipCode = dt.ZipCode;
            dr.adrZipPlusFour = dt.ZipPlusFour;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(AddressViewModel dt, int id)
        {
            Address dr = db.Addresses.Where(i => i.adrID == id).FirstOrDefault();
            db.Addresses.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }
    }
}