using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class AddressEntityDetails : IAddressEntityDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<AddressEntityViewModel> GetAll()
        {
            var items = db.AddressEntities.Select(i =>
                new AddressEntityViewModel
                { 
                    ID = i.aeID,
                    TableID = i.aeTableID,
                    TableName = i.aeTableName,                    
                    AddressID = i.aeAddressID,
                    AddressType = i.aeAddressType
                }
            );
            return items.ToList();
        }

        public AddressEntityViewModel GetByID(int id)
        {
            var result = db.AddressEntities.Where(i => true).Select(i =>
                new AddressEntityViewModel
                {
                    ID = i.aeID,
                    TableID = i.aeTableID,
                    TableName = i.aeTableName,
                    AddressID = i.aeAddressID,
                    AddressType = i.aeAddressType
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(AddressEntityViewModel dt)
        {
            AddressEntity dr = new AddressEntity();
            dr.aeID = dt.ID;
            dr.aeTableID = dt.TableID;
            dr.aeTableName = dt.TableName;
            dr.aeAddressID = dt.AddressID;
            dr.aeAddressType = dt.AddressType;
            db.AddressEntities.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Update(AddressEntityViewModel dt, int id)
        {
            AddressEntity dr = db.AddressEntities.Where(i => i.aeID == id).FirstOrDefault();
            dr.aeID = dt.ID;
            dr.aeTableID = dt.TableID;
            dr.aeTableName = dt.TableName;
            dr.aeAddressID = dt.AddressID;
            dr.aeAddressType = dt.AddressType;
            db.AddressEntities.Add(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(AddressEntityViewModel dt, int id)
        {
            AddressEntity dr = db.AddressEntities.Where(i => i.aeID == id).FirstOrDefault();            
            db.AddressEntities.Remove(dr);

            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}