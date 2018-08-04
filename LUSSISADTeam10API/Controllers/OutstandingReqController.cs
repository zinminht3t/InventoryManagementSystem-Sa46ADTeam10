using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

// Author : Htet Wai Yan
namespace LUSSISADTeam10API.Controllers
{
    [Authorize]
    public class OutstandingReqController : ApiController
    {
        // to show outstanding list
        [HttpGet]
        [Route("api/outstandingreqs")]
        public IHttpActionResult GetAllOutReqs()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from outstandingreqRepo and will insert the error if there is one
            List<OutstandingReqModel> orm =
                OutstandingReqRepo.GetAllOutstandingReq(out error);

            // if the erorr is not blank or the outstanding list is null
            if (error != "" || orm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Outstanding list Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(orm);

        }


        [HttpGet]
        [Route("api/outstandingreqs/pending")]
        public IHttpActionResult GetPendingOutstandingReqs()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from outstandingreqRepo and will insert the error if there is one
            List<OutstandingReqModel> orm =
                OutstandingReqRepo.GetAllOutstandingReq(out error);

            orm = orm.Where(x => x.Status == ConOutstandingsRequisition.Status.PENDING).ToList();

            // if the erorr is not blank or the outstanding list is null
            if (error != "" || orm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Outstanding list Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(orm);

        }

        [HttpGet]
        [Route("api/outstandingreqs/checkstock/{outreqid}")]
        public IHttpActionResult CheckInventoryStock(int outreqid)
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from outstandingreqRepo and will insert the error if there is one
            bool result =
                OutstandingReqRepo.CheckInventoryStock(outreqid, out error);


            // if the erorr is not blank or the outstanding list is null
            if (error != "")
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Outstanding list Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(result);

        }

        // to get outstanding by outstandingreq id
        [HttpGet]
        [Route("api/outstandingreq/{outreqid}")]
        public IHttpActionResult GetOutstandingReqById(int outreqid)
        {
            string error = "";
            OutstandingReqModel orm =
                OutstandingReqRepo.GetOutstandingReqById(outreqid, out error);
            if (error != "" || orm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Outstanding Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }

        // to get outstandingreq of specific requisition
        [HttpGet]
        [Route("api/outstandingreq/requisition/{reqid}")]
        public IHttpActionResult GetOutReqByReqId(int reqid)
        {
            string error = "";
            OutstandingReqModel orm =
                OutstandingReqRepo.GetOutstandingReqByReqId(reqid, out error);
            if (error != "" || orm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Outstanding Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }


        [HttpGet]
        [Route("api/completedoutstandingreq/requisition/{reqid}")]
        public IHttpActionResult GetCompletedOutstaingReqByReqID(int reqid)
        {
            string error = "";
            RequisitionWithOutstandingModel orm =
                OutstandingReqRepo.GetCompletedOutstaingReqByReqID(reqid, out error);
            if (error != "" || orm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Outstanding Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }

        // to update outstanding req
        [HttpPost]
        [Route("api/outstandingreq/update")]
        public IHttpActionResult UpdateOutReq(OutstandingReqModel outreq)
        {
            string error = "";
            OutstandingReqModel orm = OutstandingReqRepo.UpdateOutReq(outreq, out error);
            if (error != "" || orm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Outstanding Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }

        // to create new outstanding req
        [HttpPost]
        [Route("api/outstandingreq/create")]
        public IHttpActionResult CreateOutReq(OutstandingReqModel outreq)
        {
            string error = "";
            OutstandingReqModel orm = OutstandingReqRepo.CreateOutReq(outreq, out error);
            if (error != "" || orm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }

        // to complete the exisiting outstanding
        [HttpPost]
        [Route("api/outstandingreq/complete")]
        public IHttpActionResult CompleteOutstanding(RequisitionWithOutstandingModel outreq)
        {
            string error = "";
            RequisitionWithOutstandingModel orm = OutstandingReqRepo.Complete(outreq, out error);
            if (error != "" || orm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Outstanding Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }

        // to show outstanding detail list
        [HttpGet]
        [Route("api/outstandingreqdetails")]
        public IHttpActionResult GetAllOutReqDetails()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from outstandingreqdetailRepo and will insert the error if there is one
            List<OutstandingReqDetailModel> ordms =
                OutstandingReqDetailRepo.GetAllOutReqDetails(out error);

            // if the erorr is not blank or the outstanding detail list is null
            if (error != "" || ordms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Outstanding detail list Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(ordms);
        }

        // to update outstanding req details
        [HttpPost]
        [Route("api/outstandingreqdetail/update")]
        public IHttpActionResult UpdateOutReqDetail(OutstandingReqDetailModel outreqdetail)
        {
            string error = "";
            OutstandingReqDetailModel ordm =
                OutstandingReqDetailRepo.UpdateOutReqDetail(outreqdetail, out error);
            if (error != "" || ordm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Outstanding Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(ordm);
        }

        // to create new outstanding req details
        [HttpPost]
        [Route("api/outstandingreqdetail/create")]
        public IHttpActionResult CreateOutReqDetail(OutstandingReqDetailModel outreqdetail)
        {
            string error = "";
            OutstandingReqDetailModel ordm =
                OutstandingReqDetailRepo.CreateOutReqDetail(outreqdetail, out error);
            if (error != "" || ordm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(ordm);
        }

        // to get all outstanding items and total quantities
        [HttpGet]
        [Route("api/outstandingitemlist")]
        public IHttpActionResult GetOutstandingItemList()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from Repo and convert it into outstanding item list
            List<OutstandingItemModel> items = OutstandingReqDetailRepo.GetAllPendingOutstandingItems(out error);

            // if the erorr is not blank or the outstanding list is null
            if (error != "" || items == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Outstanding list Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(items);

        }
    }
}