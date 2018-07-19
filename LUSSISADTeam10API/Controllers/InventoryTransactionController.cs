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
    [Authorize]
    public class InventoryTransactionController : ApiController
    {
        // to show inventorytransaction list
        [HttpGet]
        [Route("api/inventorytransactions")]
        public IHttpActionResult GetAllInventoryTransactions()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from inventorytransactionrepo and will insert the error if there is one
            List<InventoryTransactionModel> invtms = InventoryTransactionRepo.GetAllInventoryTransactions(out error);

            // if the erorr is not blank or the inventorytransaction list is null
            if (error != "" || invtms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "InventoryTransactions Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(invtms);

        }

        // to get inventorytransaction by inventorytransaction id
        [HttpGet]
        [Route("api/inventorytransaction/{invtid}")]
        public IHttpActionResult GetInventoryTransactionByInvtID(int invtid)
        {
            string error = "";
            InventoryTransactionModel invtm = InventoryTransactionRepo.GetInventoryTransactionByTransID(invtid, out error);
            if (error != "" || invtm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "InventoryTransaction Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(invtm);
        }

        // to get inventorytransaction by inventory id
        [HttpGet]
        [Route("api/inventorytransaction/inventory/{invid}")]
        public IHttpActionResult GetInventoryTransactionByInvID(int invid)
        {
            string error = "";
            List<InventoryTransactionModel> invtms = InventoryTransactionRepo.GetInventoryTransactionsByInvID(invid, out error);
            if (error != "" || invtms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "InventoryTransaction Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(invtms);
        }

        [HttpGet]
        [Route("api/inventorytransaction/item/{itemid}")]
        public IHttpActionResult GetInventoryTransactionByItemID(int itemid)
        {
            string error = "";
            List<InventoryTransactionModel> invtms = InventoryTransactionRepo.GetInventoryTransactionsByItemID(itemid, out error);
            if (error != "" || invtms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "InventoryTransaction Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(invtms);
        }

        [HttpGet]
        [Route("api/inventorytransaction/transtype/{transtype}")]
        public IHttpActionResult GetInventoryTransactionByTransType(int transtype)
        {
            string error = "";
            List<InventoryTransactionModel> invtms = InventoryTransactionRepo.GetInventoryTransactionsByTransType(transtype, out error);
            if (error != "" || invtms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "InventoryTransaction Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(invtms);
        }

        [HttpGet]
        [Route("api/inventorytransaction/transdate/{transdate}")]
        public IHttpActionResult GetInventoryTransactionByTransDate(DateTime transdate)
        {
            string error = "";
            List<InventoryTransactionModel> invtms = InventoryTransactionRepo.GetInventoryTransactionsByTransDate(transdate, out error);
            if (error != "" || invtms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "InventoryTransaction Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(invtms);
        }

        [HttpGet]
        [Route("api/inventorytransaction/transdaterange/{startdate}/{enddate}")]
        public IHttpActionResult GetInventoryTransactionByTransDate(DateTime startdate, DateTime enddate)
        {
            string error = "";
            List<InventoryTransactionModel> invtms = InventoryTransactionRepo.GetInventoryTransactionsByTransDateRange(startdate, enddate, out error);
            if (error != "" || invtms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "InventoryTransaction Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(invtms);
        }

        // to update inventorytransaction
        [HttpPost]
        [Route("api/inventorytransaction/update")]
        public IHttpActionResult UpdateInventoryTransaction(InventoryTransactionModel invt)
        {
            string error = "";
            InventoryTransactionModel invtm = InventoryTransactionRepo.UpdateInventoryTransaction(invt, out error);
            if (error != "" || invtm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "InventoryTransaction Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(invtm);
        }

        // to create new inventorytransaction
        [HttpPost]
        [Route("api/inventorytransaction/create")]
        public IHttpActionResult CreateInventoryTransaction(InventoryTransactionModel invt)
        {
            string error = "";
            InventoryTransactionModel invtm = InventoryTransactionRepo.CreateInventoryTransaction(invt, out error);
            if (error != "" || invtm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(invtm);
        }

    }
}
