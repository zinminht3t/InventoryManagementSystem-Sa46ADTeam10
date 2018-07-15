using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LUSSISADTeam10API.Controllers
{
    public class InventoryController : ApiController
    {
        // to show inventory list
        [HttpGet]
        [Route("api/inventories")]
        public IHttpActionResult GetAllInventories()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from inventoryrepo and will insert the error if there is one
            List<InventoryModel> dms = InventoryRepo.GetAllInventories(out error);

            // if the erorr is not blank or the inventory list is null
            if (error != "" || dms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(dms);

        }
        
        // to get inventory by inventory id
        [HttpGet]
        [Route("api/inventory/{invid}")]
        public IHttpActionResult GetInventoryByInvid(int invid)
        {
            string error = "";
            InventoryModel dm = InventoryRepo.GetInventoryByInventoryid(invid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }
        
        // to get inventory by item id
        [HttpGet]
        [Route("api/inventory/item/{itemid}")]
        public IHttpActionResult GetInventoryByItemid(int itemid)
        {
            string error = "";
            InventoryModel dm = InventoryRepo.GetInventoryByItemid(itemid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }
        
        // to show inventory detail list
        [HttpGet]
        [Route("api/inventorydetails")]
        public IHttpActionResult GetAllInventoryDetails()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from inventoryrepo and will insert the error if there is one
            List<InventoryDetailModel> dms = InventoryRepo.GetAllInventoryDetails(out error);

            // if the erorr is not blank or the inventory detail list is null
            if (error != "" || dms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(dms);

        }

        // to get inventory by inventory id
        [HttpGet]
        [Route("api/inventorydetail/{invid}")]
        public IHttpActionResult GetInventoryDetailByInvid(int invid)
        {
            string error = "";
            InventoryDetailModel ivndm = InventoryRepo.GetInventoryDetailByInventoryid(invid, out error);
            if (error != "" || ivndm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(ivndm);
        }

        // to get inventory by item id
        [HttpGet]
        [Route("api/inventorydetail/item/{itemid}")]
        public IHttpActionResult GetInventoryDetailByItemid(int itemid)
        {
            string error = "";
            InventoryDetailModel dm = InventoryRepo.GetInventoryDetailByItemid(itemid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }

        // to update inventory
        [HttpPost]
        [Route("api/inventory/update")]
        public IHttpActionResult UpdateInventory(InventoryModel inv)
        {
            string error = "";
            InventoryModel dm = InventoryRepo.UpdateInventory(inv, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }

        // to create new inventory
        [HttpPost]
        [Route("api/inventory/create")]
        public IHttpActionResult CreateInventory(InventoryModel inv)
        {
            string error = "";

            // since there is only one inventory for one item, we need to delete the existing one before creating new one.
            InventoryRepo.RemoveInventory(inv, out error);

            InventoryModel dm = InventoryRepo.CreateInventory(inv, out error);
            if (error != "" || dm == null)
            {
                if(error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Item Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }

    }
}
