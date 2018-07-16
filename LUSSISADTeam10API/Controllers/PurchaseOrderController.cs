using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace LUSSISADTeam10API.Controllers
{
    public class PurchaseOrderController : ApiController
    {
        // to show purchase order list
        [HttpGet]
        [Route("api/purchaseorders")]
        public IHttpActionResult GetAllPurchaseOrders()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from purchase orderrepo and will insert the error if there is one
            List<PurchaseOrderModel> poms = PurchaseOrderRepo.GetAllPurchaseOrders(out error);
            // if the erorr is not blank or the purchase order list is null
            if (error != "" || poms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Purchase Order Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(poms);

        }
    }
}
