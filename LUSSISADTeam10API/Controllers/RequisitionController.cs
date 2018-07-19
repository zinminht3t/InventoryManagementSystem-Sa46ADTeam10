using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Repositories;
using LUSSISADTeam10API.Constants;

namespace LUSSISADTeam10API.Controllers
{
    // to allow access only by login user
    [Authorize]
    public class RequisitionController : ApiController
    {
        // to get the requisition
        [HttpGet]
        [Route("api/requisition")]
        public IHttpActionResult GetAllRequisition()
        {
            // retrive all requisition list
            List<RequisitionModel> reqs = RequisitionRepo.GetAllRequisition(out string error);
            return Ok(reqs);
        }
        // to get the requisition with its requisiton details
        [HttpGet]
        [Route("api/reqDetails")]
        public IHttpActionResult GetAllRequisitionwtihDetails()
        {
            //retrive all requisition list with its details
            List<RequisitionModel> reqs = RequisitionRepo.GetAllRequisitionwithDetails(out string error);
            return Ok(reqs);
        }
        // to get the requisiton with its requisiton id
        [HttpGet]
        [Route("api/requisition/reqid/{reqid}")]
        public IHttpActionResult GetRequisitionByReqid(int reqid )
        {
            string error = "";
            RequisitionModel reqm = RequisitionRepo.GetRequisitionByRequisitionId(reqid, out error);
            if (error != "" || reqm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqm);
        }
        // to get the requisiton list with its raised by id
        [HttpGet]
        [Route("api/requisition/raisedbyid/{raisedid}")]
        public IHttpActionResult GetRequisitionByRaisedid(int raisedid)
        {
            string error = "";
            List<RequisitionModel> reqs = RequisitionRepo.GetRequisitionByRaisedbyid(raisedid, out error);
            if (error != "" || reqs == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqs);
        }

        // to get the requisiton list with its approvedby id
        [HttpGet]
        [Route("api/requisition/approvedbyid/{approvedbyid}")]
        public IHttpActionResult GetRequisitionByApprovedbyid(int approvedbyid)
        {
            string error = "";
            List<RequisitionModel> reqs = RequisitionRepo.GetRequisitionByApprovedbyid(approvedbyid, out error);
            if (error != "" || reqs == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqs);
        }

        // to get the requisiton list with its departement id
        [HttpGet]
        [Route("api/requisition/depid/{depid}")]
        public IHttpActionResult GetRequisitionByDepid(int depid)
        {
            string error = "";
            List<RequisitionModel> reqs = RequisitionRepo.GetRequisitionByDepid(depid, out error);
            if (error != "" || reqs == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqs);
        }

        // to get the requisiton list with its status
        [HttpGet]
        [Route("api/requisition/status/{status}")]
        public IHttpActionResult GetRequisitionByStatus(int status)
        {
            string error = "";
            List<RequisitionModel> reqs = RequisitionRepo.GetRequisitionByStatus(status, out error);
            if (error != "" || reqs == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqs);
        }
        // to get the requisiton list with its requisitonn date
        [HttpGet]
        [Route("api/requisition/reqdate/{reqdate}")]
        public IHttpActionResult GetRequisitionByReqDate(DateTime reqdate)
        {
            string error = "";
            List<RequisitionModel> reqs = RequisitionRepo.GetRequisitionByReqDate(reqdate, out error);
            if (error != "" || reqs == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqs);
        }
        // to get the requisiton details list 
        [HttpGet]
        [Route("api/requisitiondetails")]
        public IHttpActionResult GetAllRequisitionDetails()
        {

            List<RequisitionDetailsModel> reqds = RequisitionDetailsRepo.GetAllRequisitionDetails(out string error);
            return Ok(reqds);
        }

        // to get the requisiton details list with its requisiton id
        [HttpGet]
        [Route("api/requisitiondetails/reqid/{reqid}")]
        public IHttpActionResult GetRequisitionDetailsByReqId(int reqid)
        {
            string error = "";
            List<RequisitionDetailsModel> reqds = RequisitionDetailsRepo.GetRequisitionDetailsByRequisitionId(reqid, out error);
            if (error != "" || reqds == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "RequisitionDetails Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqds);
        }
        // to get the requisiton details list with its item id
        [HttpGet]
        [Route("api/requisitiondetails/itemid/{itemid}")]
        public IHttpActionResult GetRequisitionDetailsByItemId(int itemid)
        {
            string error = "";
            List<RequisitionDetailsModel> reqds = RequisitionDetailsRepo.GetRequisitionDetailsByItemId(itemid, out error);
            if (error != "" || reqds == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "RequisitionDetails Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqds);
        }

        // to create new requisition Details
        [HttpPost]
        [Route("api/requisitiondetails/create")]
        public IHttpActionResult CreateRequisitionDetails(RequisitionDetailsModel reqdm)
        {
            string error = "";
           List< RequisitionDetailsModel> reqden = RequisitionDetailsRepo.CreateRequisitionDetails(reqdm, out error);
            if (error != "" || reqden == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(reqden);
        }

        // to create new requisition 
        [HttpPost]
        [Route("api/requisition/create")]
        public IHttpActionResult CreateRequisition(RequisitionModel reqm)
        {
            string error = "";
            RequisitionModel req = RequisitionRepo.CreateRequisition(reqm, out error);
            if (error != "" || req == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(req);
        }

        // to create new requisition with details
        [HttpPost]
        [Route("api/requisition/createdetails")]
        public IHttpActionResult CreateRequisitionwithDetails(RequisitionModel reqm)
        {
            string error = "";
            RequisitionModel req = RequisitionRepo.CreateRequisitionwithDetails(reqm, reqm.Requisitiondetails, out error);
            if (error != "" || req == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(req);
        }




        // to update requisition
        [HttpPost]
        [Route("api/requisition/update")]
        public IHttpActionResult UpdateRequisition(RequisitionModel reqm)
        {
            string error = "";
            RequisitionModel rm = RequisitionRepo.UpdateRequisition(reqm, out error);
            if (error != "" || rm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(rm);
        }
        // to update requisition Details
        [HttpPost]
        [Route("api/requisitiondetails/update")]
        public IHttpActionResult UpdateRequisitionDetails(RequisitionDetailsModel reqdm)
        {
            string error = "";
            RequisitionDetailsModel rdm = RequisitionDetailsRepo.UpdateRequisitionDetail(reqdm, out error);
            if (error != "" || rdm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Inventory Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(rdm);
        }

        // to update inventory in preparing state
        [HttpPost]
        [Route("api/requisition/preparing")]
        public IHttpActionResult UpdateRequisitionStatus(RequisitionModel po)
        {
            string error = "";

            po = RequisitionRepo.GetRequisitionByRequisitionId(po.Reqid, out error);

            // if the staff has already updated the status to "preparing"
            if (po.Status == ConRequisition.Status.PREPARING)
            {
                return Ok(po);
            }
            po.Status = ConRequisition.Status.PREPARING;

            List<RequisitionDetailsModel> podms = RequisitionDetailsRepo.GetRequisitionDetailsByRequisitionId(po.Reqid, out error);

            // if the requisiton preparing is completed, the stock must be updated according to  qty.
            foreach (RequisitionDetailsModel podm in podms)
            {
                // get the inventory using the item id from Requisition details
                InventoryModel invm = InventoryRepo.GetInventoryByItemid(podm.Itemid, out error);

                // subtract  the stock accoring to  qty
                invm.Stock -= podm.Qty;

                // update the inventory
                invm = InventoryRepo.UpdateInventory(invm, out error);
            }

            // updating the status
            RequisitionModel pom = RequisitionRepo.UpdateRequisition(po, out error);
            if (error != "" || pom == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(pom);
        }
    }
}
