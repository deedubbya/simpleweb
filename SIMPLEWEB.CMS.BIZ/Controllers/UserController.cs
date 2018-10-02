using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMPLEWEB.CMS.BIZ.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserDetails ud;
        
        public UserController()
        {
            ud = new UserDetails();
        }

        public UserController(IUserDetails userDetails)
        {
            ud = userDetails;
        }

        [HttpGet]
        [Route("api/User/Get")]
        public IEnumerable<UserViewModel> Get()
        {
            var details = ud.GetAll();
            return details;
        }

        [HttpGet]
        [Route("api/User/GetUserByID/{id}")]
        public UserViewModel GetDetailsByID(int id)
        {
            var detailsbyId = ud.GetByID(id);
            return detailsbyId;
        }

        [HttpPost]
        [Route("api/User/AddUser")]
        public IHttpActionResult AddUser(UserViewModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ud.Insert(userModel);
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
