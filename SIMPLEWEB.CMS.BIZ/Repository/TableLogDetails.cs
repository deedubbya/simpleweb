using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class TableLogDetails : ITableLogDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<TableLogViewModel> GetAll()
        {
            var items = db.TableLogs.Select(i =>
                new TableLogViewModel
                {
                    ID = i.tlID,
                    LogType = i.tlType,
                    LogDate = i.tlDate,
                    LogDescription = i.tlDescription
                }
            );
            return items.ToList();
        }

        public TableLogViewModel GetByID(int id)
        {
            var result = db.TableLogs.Where(i => true).Select(i =>
                new TableLogViewModel
                {
                    ID = i.tlID,
                    LogType = i.tlType,
                    LogDate = i.tlDate,
                    LogDescription = i.tlDescription
                }
            );
            return result.FirstOrDefault();
        }

        public int Insert(TableLogViewModel dt)
        {
            TableLog dr = new TableLog();
            dr.tlType = dt.LogType;
            dr.tlDate = dt.LogDate;
            dr.tlDescription = dt.LogDescription;
            db.TableLogs.Add(dr);
            var Result = db.SaveChanges();

            return dr.tlID;
        }

        public bool Update(TableLogViewModel dt, int id)
        {
            TableLog dr = db.TableLogs.Where(i => i.tlID == id).FirstOrDefault();
            dr.tlID = dt.ID;
            dr.tlType = dt.LogType;
            dr.tlDate = dt.LogDate;
            dr.tlDescription = dt.LogDescription;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(TableLogViewModel dt, int id)
        {
            TableLog dr = db.TableLogs.Where(i => i.tlID == id).FirstOrDefault();
            db.TableLogs.Remove(dr);
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}