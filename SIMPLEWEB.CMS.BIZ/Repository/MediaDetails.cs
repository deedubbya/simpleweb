using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class MediaDetails : IMediaDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<MediaViewModel> GetAll()
        {
            var items = db.Media.Select(i =>
                new MediaViewModel
                {
                    ID = i.medID,
                    FileName = i.medFileName,
                    FileType = i.medType
                }
            );
            return items.ToList();
        }

        public MediaViewModel GetByID(int id)
        {
            var result = db.Media.Where(i => true).Select(i =>
                new MediaViewModel
                {
                    ID = i.medID,
                    FileName = i.medFileName,
                    FileType = i.medType
                }
            );
            return result.FirstOrDefault();
        }

        public int Insert(MediaViewModel dt)
        {
            Media dr = new Media();
            dr.medFileName = dt.FileName;
            dr.medType = dt.FileType;
            db.Media.Add(dr);
            var Result = db.SaveChanges();

            return dr.medID;
        }

        public bool Update(MediaViewModel dt, int id)
        {
            Media dr = db.Media.Where(i => i.medID == id).FirstOrDefault();
            dr.medID = dt.ID;
            dr.medFileName = dt.FileName;
            dr.medType = dt.FileType;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(MediaViewModel dt, int id)
        {
            Media dr = db.Media.Where(i => i.medID == id).FirstOrDefault();
            db.Media.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}