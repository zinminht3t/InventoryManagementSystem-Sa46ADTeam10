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
    // to allow access only by login user
    [Authorize]
    public class ItemController : ApiController
    {
        // to show item list
        [HttpGet]
        [Route("api/items")]
        public IHttpActionResult GetAllItems()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from itemrepo and will insert the error if there is one
            List<ItemModel> ims = ItemRepo.GetAllItems(out error);

            // if the erorr is not blank or the item list is null
            if (error != "" || ims == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Items Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(ims);

        }

        // to get item by item id
        [HttpGet]
        [Route("api/item/{itemid}")]
        public IHttpActionResult GetItemByItemid(int itemid)
        {
            string error = "";
            ItemModel im = ItemRepo.GetItemByItemid(itemid, out error);
            if (error != "" || im == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Item Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(im);
        }

        // to get item by category id
        [HttpGet]
        [Route("api/item/category/{catid}")]
        public IHttpActionResult GetItemByCatid(int catid)
        {
            string error = "";
            List<ItemModel> im = ItemRepo.GetItemByCatid(catid, out error);
            if (error != "" || im == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Item Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(im);
        }

        // to update item
        [HttpPost]
        [Route("api/item/update")]
        public IHttpActionResult UpdateItem(ItemModel item)
        {
            string error = "";
            ItemModel im = ItemRepo.UpdateItem(item, out error);
            if (error != "" || im == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Item Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(im);
        }

        // to create new item
        [HttpPost]
        [Route("api/item/create")]
        public IHttpActionResult CreateItem(ItemModel item)
        {
            string error = "";
            ItemModel im = ItemRepo.CreateItem(item, out error);
            if (error != "" || im == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(im);
        }

    }
}
