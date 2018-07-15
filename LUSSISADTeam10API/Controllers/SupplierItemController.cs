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

        // to create new supplier
        [HttpPost]
        [Route("api/supplieritem/create")]
        public IHttpActionResult CreateSupplier(SupplierItemModel supitem)
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
    }
}