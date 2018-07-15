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
    public class OutstandingReqController : ApiController
    {
        // to show supplier list
        [HttpGet]
        [Route("api/outstandingreqs")]
        public IHttpActionResult GetAllSuppliers()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from supplierRepo and will insert the error if there is one
            List<SupplierModel> sms = SupplierRepo.GetAllSuppliers(out error);

            // if the erorr is not blank or the supplier list is null
            if (error != "" || sms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Suppliers Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(sms);

        }

        // to get supplier by supplier id
        [HttpGet]
        [Route("api/supplier/{supid}")]
        public IHttpActionResult GetSupplierById(int supid)
        {
            string error = "";
            SupplierModel sm = SupplierRepo.GetSupplierById(supid, out error);
            if (error != "" || sm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Supplier Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sm);
        }

        [HttpPost]
        [Route("api/supplier/update")]
        public IHttpActionResult UpdateSupplier(SupplierModel sup)
        {
            string error = "";
            SupplierModel sm = SupplierRepo.UpdateSupplier(sup, out error);
            if (error != "" || sm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Supplier Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sm);
        }

        // to create new supplier
        [HttpPost]
        [Route("api/supplier/create")]
        public IHttpActionResult CreateSupplier(SupplierModel sup)
        {
            string error = "";
            SupplierModel sm = SupplierRepo.CreateSupplier(sup, out error);
            if (error != "" || sm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sm);
        }

        [HttpPost]
        [Route("api/outstandingreq/complete")]
        public IHttpActionResult DeactivateSupplier(Outstand sup)
        {
            string error = "";
            SupplierModel sm = SupplierRepo.DeactivateSupplier(sup, out error);
            if (error != "" || sm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sm);
        }
    }
}