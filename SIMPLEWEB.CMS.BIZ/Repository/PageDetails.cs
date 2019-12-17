using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIMPLEWEB.CMS.COMMON;
using SIMPLEWEB.CMS.DATA;

namespace SIMPLEWEB.CMS.BIZ
{
    public class PageDetails : IPageDetails
    {
        SimpleWebDBContext db = new SimpleWebDBContext();

        public IEnumerable<PageViewModel> GetAll()
        {
            var items = db.Pages.Select(i =>
                new PageViewModel
                {
                    ID = i.pID,
                    Status = i.pStatus,
                    IsHomePage = i.pIsHomePage,
                    Visibility = i.pVisibility,
                    HeaderTitle = i.pHeaderTitle,
                    HtmlContent = i.pHtmlContent
                }
            );
            return items.ToList();
        }

        public PageViewModel GetByID(int id)
        {
            var result = db.Pages.Where(i => i.pID == id).Select(i =>
                new PageViewModel
                {
                    ID = i.pID,
                    Status = i.pStatus,
                    IsHomePage = i.pIsHomePage,
                    Visibility = i.pVisibility,
                    HeaderTitle = i.pHeaderTitle,
                    HtmlContent = i.pHtmlContent
                }
            );
            return result.FirstOrDefault();
        }

        public int Insert(PageViewModel dt)
        {
            Page dr = new Page();
            dr.pStatus = dt.Status;
            dr.pIsHomePage = dt.IsHomePage;
            dr.pVisibility = dt.Visibility;
            dr.pHeaderTitle = dt.HeaderTitle;
            dr.pHtmlContent = dt.HtmlContent;
            db.Pages.Add(dr);
            var Result = db.SaveChanges();

            return dr.pID;
        }

        public bool Update(PageViewModel dt, int id)
        {
            Page dr = db.Pages.Where(i => i.pID == id).FirstOrDefault();
            dr.pID = dt.ID;
            dr.pStatus = dt.Status;
            dr.pIsHomePage = dt.IsHomePage;
            dr.pVisibility = dt.Visibility;
            dr.pHeaderTitle = dt.HeaderTitle;
            dr.pHtmlContent = dt.HtmlContent;
            var Result = db.SaveChanges();

            return Result == 1;
        }

        public bool Delete(PageViewModel dt, int id)
        {
            Page dr = db.Pages.Where(i => i.pID == id).FirstOrDefault();
            dr.pStatus = Constants.PageStatus.INACTIVE.ToString();
            var Result = db.SaveChanges();

            return Result == 1;
        }

    }
}