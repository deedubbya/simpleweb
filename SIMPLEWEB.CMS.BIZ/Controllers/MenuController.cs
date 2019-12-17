using System;
using System.Text;
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
    public class MenuController : ApiController
    {
        private readonly IMenuDetails md;
        private readonly IMenuNavigationItemDetails mnd;
        public MenuController()
        {
            md = new MenuDetails();
            mnd = new MenuNavigationItemDetails();
        }

        public MenuController(IMenuDetails menuDetails, IMenuNavigationItemDetails menuNavigationItemDetails)
        {
            md = menuDetails;
            mnd = menuNavigationItemDetails;
        }

        [HttpGet]
        [Route("api/Menu/GetMenus")]
        public IEnumerable<MenuViewModel> GetMenus()
        {
            var details = md.GetAll();
            return details;
        }

        [HttpGet]
        [Route("api/Menu/GetMenuByID/{id}")]
        public MenuViewModel GetMenuByID(int id)
        {
            var detailsbyId = md.GetByID(id);
            return detailsbyId;
        }
        
        [HttpPost]
        [Route("api/Menu/AddMenu")]
        public IHttpActionResult AddMenu(MenuViewModel menuModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    md.Insert(menuModel);
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
        [Route("api/Menu/UpdateMenu")]
        public IHttpActionResult UpdateMenu(MenuViewModel menuModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    md.Update(menuModel, menuModel.ID);
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

        [HttpPut]
        [Route("api/Menu/UpdateMenuNavigationItem")]
        public IHttpActionResult UpdateMenuNavigationItem(MenuNavigationItemViewModel menuNavigationItemModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mnd.Update(menuNavigationItemModel, menuNavigationItemModel.ID);
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

        [HttpDelete]
        [Route("api/Menu/DeleteMenuByID/{id}")]
        public IHttpActionResult DeleteMenu(int id)
        {
            try
            {
                md.Delete(new MenuViewModel(), id);
                return Ok("Successfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
