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
    public class SupplierItemController : ApiController
    {
        // get all items with related supplier and price
        [HttpGet]
        [Route("api/supplieritems")]
        public IHttpActionResult GetAllSupplierItems()
        {
            string error = "";
            List<SupplierItemModel> sims = SupplierItemRepo
                .GetAllSupplierItem(out error);
            if (error != "" || sims == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Items and suppliers NOT FOUND!");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sims);
        }

        // get price by itemid
        [HttpGet]
        [Route("api/itemprice/{itemid}")]
        public IHttpActionResult GetItemPrice(int itemid)
        {
            string error = "";
            SupplierItemModel sim = SupplierItemRepo
                .GetSupplierItemByItemId(itemid, out error);
            if (error != "" || sim == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Items and suppliers NOT FOUND!");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sim);
        }

        // to update existing item of specific supplier
        [HttpPost]
        [Route("api/supplieritem/update")]
        public IHttpActionResult UpdateSupplierItem(SupplierItemModel supitem)
        {
            string error = "";
            SupplierItemModel sim = SupplierItemRepo
                .UpdateSupplierItem(supitem, out error);
            if (error != "" || sim == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Supplier Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sim);
        }

        // to create new item by supplier
        [HttpPost]
        [Route("api/supplieritem/create")]
        public IHttpActionResult CreateSupplierItem(SupplierItemModel supitem)
        {
            string error = "";
            SupplierItemModel sim = SupplierItemRepo
                .AddItemOfSupplier(supitem, out error);
            if (error != "" || sim == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sim);
        }

        [HttpGet]
        [Route("api/supplieritem/item/{itemid}")]
        public IHttpActionResult GetSupplierItemByItemId(int itemid)
        {
            string error = "";
            List<SupplierItemModel> sims = SupplierItemRepo
                .GetSupplierItemListByItemId(itemid, out error);
            if (error != "" || sims == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sims);
        }
        [HttpGet]
        [Route("api/supplieritem/getitem/{itemid}")]
        public IHttpActionResult GetOneSupplierItemByItemId(int itemid)
        {
            string error = "";
            SupplierItemModel sim = SupplierItemRepo.GetSupplierItemByItemId(itemid, out error);
            if(error != "" || sim == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sim);
        }


        // get items by supplier list
        [HttpGet]
        [Route("api/supplieritem/sup/{supid}")]
        public IHttpActionResult GetSupplierItemBySupid(int supid)
        {
            string error = "";
            List<SupplierItemModel> sims = SupplierItemRepo
                .GetItemsBySupplier(supid, out error);
            if (error != "" || sims == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sims);
        }

        // to import with csv
        [HttpPost]
        [Route("api/supplieritem/csv")]
        public IHttpActionResult csvsupplier(List<SupplierItemModel> supitemlist)
        {
            string error = "";
            List<SupplierItemModel> sim = SupplierItemRepo
                .csvsupplier(supitemlist, out error);
            if (error != "" || sim == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Supplier Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sim);
        }


        // to import with excel file
        [HttpPost]
        [Route("api/supplieritem/importsupplier")]
        public IHttpActionResult importsupplier(List<SupplierItemModel> supitemlist)
        {
            string error = "";
            List<SupplierItemModel> sim = SupplierItemRepo
                .importsupplier(supitemlist, out error);
            if (error != "" || sim == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Supplier Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sim);
        }
    }
}