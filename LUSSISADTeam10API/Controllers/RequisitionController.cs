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

        [HttpGet]
        [Route("api/requisition")]
        public IHttpActionResult GetAllRequisition()
        {

            List<RequisitionModel> reqs = RequisitionRepo.GetAllRequisition(out string error);
            return Ok(reqs);
        }
        [HttpGet]
        [Route("api/requisition/reqid/{reqid}")]
        public IHttpActionResult GetRequisitionByReqid(int reqid)
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

        [HttpGet]
        [Route("api/requisitiondetail")]
        public IHttpActionResult GetAllRequisitionDetails()
        {

            List<RequisitionDetailsModel> reqds = RequisitionRepo.GetAllRequisitionDetails(out string error);
            return Ok(reqds);
        }


        [HttpGet]
        [Route("api/requisitiondetail/reqid/{reqid}")]
        public IHttpActionResult GetRequisitionDetailsByReqId(int reqid)
        {
            string error = "";
            List<RequisitionDetailsModel> reqds = RequisitionRepo.GetRequisitionDetailsByRequisitionId(reqid, out error);
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

        [HttpGet]
        [Route("api/requisitiondetail/itemid/{itemid}")]
        public IHttpActionResult GetRequisitionDetailsByItemId(int itemid)
        {
            string error = "";
            List<RequisitionDetailsModel> reqds = RequisitionRepo.GetRequisitionDetailsByItemId(itemid, out error);
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

    }
}
