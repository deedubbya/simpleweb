using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMPLEWEB.CMS.BIZ.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountDetails ad;
        
        public AccountController()
        {
            ad = new AccountDetails();
        }

        public AccountController(IAccountDetails accountDetails)
        {
            ad = accountDetails;
        }

        [HttpGet]
        [Route("api/Account/GetAccounts")]
        public IEnumerable<AccountViewModel> GetAccounts()
        {
            var details = ad.GetAll();
            return details;
        }

        [HttpGet]
        [Route("api/Account/GetAccountByID/{id}")]
        public AccountViewModel GetAccountByID(int id)
        {
            var detailsbyId = ad.GetByID(id);
            return detailsbyId;
        }

        [HttpPost]
        [Route("api/Account/AddAccount")]
        public IHttpActionResult AddAccount(AccountViewModel accountModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ad.Insert(accountModel);
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
