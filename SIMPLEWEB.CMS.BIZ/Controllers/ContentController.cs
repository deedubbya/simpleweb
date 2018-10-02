using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMPLEWEB.CMS.BIZ.Controllers
{
    public class ContentController : ApiController
    {
        private readonly IContentDetails cd;
        
        public ContentController()
        {
            cd = new ContentDetails();
        }

        public ContentController(IContentDetails contentDetails)
        {
            cd = contentDetails;
        }

        [HttpGet]
        [Route("api/Content/Get")]
        public IEnumerable<ContentViewModel> Get()
        {
            var details = cd.GetAll();
            return details;
        }

        [HttpGet]
        [Route("api/Content/GetContentByID/{id}")]
        public ContentViewModel GetDetailsByID(int id)
        {
            var detailsbyId = cd.GetByID(id);
            return detailsbyId;
        }

        [HttpPost]
        [Route("api/Content/AddContent")]
        public IHttpActionResult AddAccount(ContentViewModel contentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cd.Insert(contentModel);
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
    }
}
