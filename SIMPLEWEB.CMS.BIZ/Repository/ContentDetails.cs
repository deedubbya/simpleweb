using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class ContentDetails : IContentDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<ContentViewModel> GetAll()
        {
            var items = db.Contents.Select(i =>
                new ContentViewModel
                {
                    ID = i.Id
                }
            );
            return items.ToList();
        }

        public ContentViewModel GetByID(int id)
        {
            var result = db.Contents.Where(i => true).Select(i =>
                new ContentViewModel
                {
                    ID = i.Id
                }
            );
            return result.FirstOrDefault();
        }

        public bool Insert(ContentViewModel dt)
        {
            Content dr = new Content();
            dr.Id = dt.ID;            
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Update(ContentViewModel dt, int id)
        {
            Content dr = db.Contents.Where(i => i.Id == id).FirstOrDefault();
            dr.Id = dt.ID;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(ContentViewModel dt, int id)
        {
            Content dr = db.Contents.Where(i => i.Id == id).FirstOrDefault();
            db.Contents.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}