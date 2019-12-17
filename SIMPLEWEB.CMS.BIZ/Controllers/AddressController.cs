using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMPLEWEB.CMS.BIZ.Controllers
{
    public class AddressController : ApiController
    {
        private readonly IAddressDetails ad;
        private readonly IAddressEntityDetails aed;
        
        public AddressController()
        {
            ad = new AddressDetails();
            aed = new AddressEntityDetails();
        }

        public AddressController(IAddressDetails addressDetails, IAddressEntityDetails addressEntityDetails)
        {
            ad = addressDetails;
            aed = addressEntityDetails;
        }

        [HttpGet]
        [Route("api/Address/GetAddressByID/{id}")]
        public AddressViewModel GetAddressByID(int id)
        {
            var detailsbyId = ad.GetByID(id);
            return detailsbyId;
        }

        [HttpGet]
        [Route("api/Address/GetAddressEntityByID/{id}")]
        public AddressEntityViewModel GetAddressEntityByID(int id)
        {
            var detailsbyId = aed.GetByID(id);
            return detailsbyId;
        }

        [HttpPost]
        [Route("api/Address/AddAddress")]
        public IHttpActionResult AddAddress(AddressViewModel addressModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ad.Insert(addressModel);
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
