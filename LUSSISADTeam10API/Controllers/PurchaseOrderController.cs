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


        // to show adjustment list
        [HttpGet]
        [Route("api/purchaseorders")]
        public IHttpActionResult GetAllPurchaseOrders()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from departmentrepo and will insert the error if there is one
            List<PurchaseOrderModel> poms = PurchaseOrderRepo.GetAllPurchaseOrders(out error);
            // if the erorr is not blank or the department list is null
            if (error != "" || poms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Departments Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(poms);

        }

        // to create new department
        [HttpPost]
        [Route("api/purchaseorder/create")]
        public IHttpActionResult CreateDepartment(PurchaseOrderModel pom)
        {
            string error = "";
            PurchaseOrderModel newpom = PurchaseOrderRepo.CreatePurchaseOrder(pom, pom.podms, out error);
            if (error != "" || newpom == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(newpom);
        }
    }
}
