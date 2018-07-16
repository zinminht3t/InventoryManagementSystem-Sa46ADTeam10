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
    public class DisbursementController : ApiController
    {
        // to Get all Disbursements
        [HttpGet]
        [Route("api/disbursement")]
        public IHttpActionResult GetAllDisbursement()
        {

            List<DisbursementModel> reqs = DisbursementRepo.GetAllDisbursement(out string error);
            return Ok(reqs);
        }
        // to Get all Disbursements with Disbursement Details
        [HttpGet]
        [Route("api/disburdetails")]
        public IHttpActionResult GetAllDisbursementwtihDetails()
        {

            List<DisbursementModel> reqs = DisbursementRepo.GetAllDisbursementwithDetails(out string error);
            return Ok(reqs);
        }
        // to Get all Disbursements with disbursement id
        [HttpGet]
        [Route("api/disbursement/disid/{disid}")]
        public IHttpActionResult GetDisbursementByDisid(int disid)
        {
            string error = "";
            DisbursementModel dism = DisbursementRepo.GetDisbursementByDisbursementId(disid, out error);
            if (error != "" || dism == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dism);
        }
        // to Get all Disbursements with requisition id 
        [HttpGet]
        [Route("api/disbursement/reqid/{reqid}")]
        public IHttpActionResult GetDisbursementByRequisitionid(int reqid )
        {
            string error = "";
            List<DisbursementModel> dism = DisbursementRepo.GetDisbursementByRequisitionId(reqid, out error);
            if (error != "" || dism == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dism);
        }
        // to Get all Disbursements with acknowledge by id
        [HttpGet]
        [Route("api/disbursement/ackby/{ackby}")]
        public IHttpActionResult GetDisbursementByackbyid(int ackby)
        {
            string error = "";
            List<DisbursementModel> dism = DisbursementRepo.GetDisbursementByackyby(ackby, out error);
            if (error != "" || dism == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dism);
        }
        // to Get all Disbursements Details
        [HttpGet]
        [Route("api/disbursementdetails")]
        public IHttpActionResult GetAlldisbursementdetails()
        {

            List<DisbursementDetailsModel> reqds = DisbursementDetailsRepo.GetAllDisbursementDetails(out string error);
            return Ok(reqds);
        }
        // to Get all Disbursements Details with Disbursement ID
        [HttpGet]
        [Route("api/disbursementdetails/disid/{disid}")]
        public IHttpActionResult GetDisbursementDetailsBydisid(int disid)
        {
            string error = "";
            List<DisbursementDetailsModel> disdm = DisbursementDetailsRepo.GetDisbursementDetailsByDisbursementId(disid, out error);
            if (error != "" || disdm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(disdm);
        }

        // to Get all Disbursements Details with Item ID
        [HttpGet]
        [Route("api/disbursementdetails/itemid/{itemid}")]
        public IHttpActionResult GetDisbursementDetailsByreqid(int itemid)
        {
            string error = "";
            List<DisbursementDetailsModel> disdm = DisbursementDetailsRepo.GetDisbursementDetailsByItemId(itemid, out error);
            if (error != "" || disdm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(disdm);
        }
        // to create new disbursement 
        [HttpPost]
        [Route("api/disbursement/create")]
        public IHttpActionResult Createdisbursement(DisbursementModel dism)
        {
            string error = "";
            DisbursementModel disbm = DisbursementRepo.Createdisbursement(dism, out error);
            if (error != "" || disbm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(disbm);
        }



    }
}
