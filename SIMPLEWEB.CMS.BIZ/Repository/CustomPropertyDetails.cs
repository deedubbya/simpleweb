using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class CustomPropertyDetails : ICustomPropertyDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<CustomPropertyViewModel> GetAll()
        {
            var items = db.CustomProperties.Select(i =>
                new CustomPropertyViewModel
                {
                    ID = i.cpID,
                    TableID = i.cpTableID,
                    TableName = i.cpTableName,
                    PropertyName = i.cpName,
                    PropertyValue = i.cpValue
                }
            );
            return items.ToList();
        }

        public CustomPropertyViewModel GetByID(int id)
        {
            var result = db.CustomProperties.Where(i => i.cpID == id).Select(i =>
                new CustomPropertyViewModel
                {
                    ID = i.cpID,
                    TableID = i.cpTableID,
                    TableName = i.cpTableName,
                    PropertyName = i.cpName,
                    PropertyValue = i.cpValue
                }
            );
            return result.FirstOrDefault();
        }

        public int Insert(CustomPropertyViewModel dt)
        {
            CustomProperty dr = new CustomProperty();
            dr.cpTableID = dt.TableID;
            dr.cpTableName = dt.TableName;
            dr.cpName = dt.PropertyName;
            dr.cpValue = dt.PropertyValue;
            db.CustomProperties.Add(dr);
            var Result = db.SaveChanges();

            return dr.cpID;
        }

        public bool Update(CustomPropertyViewModel dt, int id)
        {
            CustomProperty dr = db.CustomProperties.Where(i => i.cpID == id).FirstOrDefault();
            dr.cpID = dt.ID;
            dr.cpTableID = dt.TableID;
            dr.cpTableName = dt.TableName;
            dr.cpName = dt.PropertyName;
            dr.cpValue = dt.PropertyValue;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(CustomPropertyViewModel dt, int id)
        {
            CustomProperty dr = db.CustomProperties.Where(i => i.cpID == id).FirstOrDefault();
            db.CustomProperties.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}