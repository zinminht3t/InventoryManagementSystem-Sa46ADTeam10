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
    public class SupplierController : ApiController
    {
        // to show supplier list
        [HttpGet]
        [Route("api/suppliers")]
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

        // to get supplier by supplier status
        [HttpGet]
        [Route("api/supplier/status/{status}")]
        public IHttpActionResult GetSupplierByStatus(int status)
        {
            string error = "";
            List<SupplierModel> sms = SupplierRepo.GetSupplierByStatus(status, out error);
            if (error != "" || sms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Supplier Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sms);
        }

        // to get department by user id
        [HttpGet]
        [Route("api/supplier/item/{itemid}")]
        public IHttpActionResult GetSupplierByItemId(int itemid)
        {
            string error = "";
            List<SupplierModel> sms = SupplierRepo.GetSuppliersByItemId(itemid, out error);
            if (error != "" || sms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Item Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sms);
        }
        
        // to update Supplier
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

        // to deactivate supplier
        [HttpPost]
        [Route("api/supplier/deactivate")]
        public IHttpActionResult DeactivateSupplier(SupplierModel sup)
        {
            string error = "";
            SupplierModel sm = SupplierRepo.DeactivateSupplier(sup, out error);
            if (error != "" || sm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sm);
        }

        //to activate supplier
        [HttpPost]
        [Route("api/supplier/activate")]
        public IHttpActionResult ActivateSupplier(SupplierModel sup)
        {
            string error = "";
            SupplierModel sm = SupplierRepo.ActivateSupplier(sup, out error);
            if (error != "" || sm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(sm);
        }

        //to get items by supplier id
        [HttpGet]
        [Route("api/supplier/{supid}/items")]
        public IHttpActionResult GetItemsBySupplierId(int supid)
        {
            string error = "";
            List<SupplierItemModel> ims = SupplierItemRepo.GetItemsBySupplier(supid, out error);
            if (error != "" || ims == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Items Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(ims);
        }


        [HttpPost]
        [Route("api/supplier/importsupplier")]
        public IHttpActionResult importsupplier(List<SupplierModel> sup)
        {
            string error = "";
            List<SupplierModel> sim = SupplierRepo
                .importsupplier(sup , out error);
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
