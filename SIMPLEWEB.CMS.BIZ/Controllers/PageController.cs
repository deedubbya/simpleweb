using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SIMPLEWEB.CMS.BIZ.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PageController : ApiController
    {
        private readonly IPageDetails pd;
        
        public PageController()
        {
            pd = new PageDetails();
        }

        public PageController(IPageDetails pageDetails)
        {
            pd = pageDetails;
        }

        [HttpGet]
        [Route("api/Page/GetPages")]
        public IEnumerable<PageViewModel> GetPages()
        {
            var details = pd.GetAll();
            return details;
        }

        [HttpGet]
        [Route("api/Page/GetPageByID/{id}")]
        public PageViewModel GetPageByID(int id)
        {
            var detailsbyId = pd.GetByID(id);
            return detailsbyId;
        }

        [HttpPost]
        [Route("api/Page/AddPage")]
        public IHttpActionResult AddPage(PageViewModel pageModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pd.Insert(pageModel);
                    return Ok("Successfully added");
                }
                else
                {
                    return BadRequest("Error please check");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("api/Page/UpdatePage")]
        public IHttpActionResult UpdatePage(PageViewModel pageModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pd.Update(pageModel, pageModel.ID);
                    return Ok("Successfully updated");
                }
                else
                {
                    return BadRequest("Error please check");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
