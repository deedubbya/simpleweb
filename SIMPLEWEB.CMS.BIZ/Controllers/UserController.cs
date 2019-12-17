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
        [Route("api/User/GetUsers")]
        public IEnumerable<UserViewModel> GetUsers()
        {
            var details = ud.GetAll();
            return details;
        }

        [HttpGet]
        [Route("api/User/GetUserByID/{id}")]
        public UserViewModel GetUserByID(int id)
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
                    int id = ud.Insert(userModel);
                    return Content(HttpStatusCode.OK, new { ID = id });
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "User Object not valid!");
                }
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/User/UpdateUser")]
        public IHttpActionResult UpdateUser(UserViewModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ud.Update(userModel, userModel.ID);
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
