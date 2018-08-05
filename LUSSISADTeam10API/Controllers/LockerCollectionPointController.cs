using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

// Author : Khin Yadana Phyo
namespace LUSSISADTeam10API.Controllers
{
    // to allow access only by login user
    [Authorize]
    public class LockerCollectionPointController : ApiController
    {
        // to show locker list
        [HttpGet]
        [Route("api/lockercollectionpoints")]
        public IHttpActionResult GetAllLockerCP()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from lockercollectionpointrepo and will insert the error if there is one
            List<LockerCollectionPointModel> lcpms = LockerCollectionPointRepo.GetAllLockerCP(out error);

            // if the erorr is not blank or the locker list is null
            if (error != "" || lcpms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Locker Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(lcpms);

        }
        // to get lockerdetail by locker id
        [HttpGet]
        [Route("api/lockercollectionpoint/lockerid/{lockerid}")]
        public IHttpActionResult GetLockerCPByLockerid(int lockerid)
        {
            string error = "";
            LockerCollectionPointModel lcpm = LockerCollectionPointRepo.GetLockerCPByLockerid(lockerid, out error);
            if (error != "" || lcpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(lcpm);
        }
        // to get lockerdetail by lockername
        [HttpGet]
        [Route("api/lockercollectionpoint/lockername/{lockername}")]
        public IHttpActionResult GetLockerCPByLockername(string lockername)
        {
            string error = "";
            LockerCollectionPointModel lcpm = LockerCollectionPointRepo.GetLockerCPByLockername(lockername, out error);
            if (error != "" || lcpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(lcpm);
        }
        // to get lockerdetail by lockersize
        [HttpGet]
        [Route("api/lockercollectionpoint/lockersize/{lockersize}")]
        public IHttpActionResult GetLockerCPByLockerSize(string lockersize)
        {
            string error = "";
            List<LockerCollectionPointModel> lcpm = LockerCollectionPointRepo.GetLockerCPByLockersize(lockersize, out error);
            if (error != "" || lcpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(lcpm);
        }
        // to get lockerdetail by collection point 
        [HttpGet]
        [Route("api/lockercollectionpoint/cp/{cpid}")]
        public IHttpActionResult GetLockerCPBycpid(int cpid)
        {
            string error = "";
            List<LockerCollectionPointModel> lcpm = LockerCollectionPointRepo.GetLockerCPBycpid(cpid, out error);
            if (error != "" || lcpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(lcpm);
        }
        // to update lockerdetail
        [HttpPost]
        [Route("api/lockercollectionpoint/update")]
        public IHttpActionResult UpdateLockerCP(LockerCollectionPointModel lcp)
        {
            string error = "";
            LockerCollectionPointModel lcpm = LockerCollectionPointRepo.UpdateLockerCP(lcp, out error);
            if (error != "" || lcpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(lcpm);
        }
        // to create new lockerdetail
        [HttpPost]
        [Route("api/lockercollectionpoint/create")]
        public IHttpActionResult CreateLockerCP(LockerCollectionPointModel lcp)
        {
            string error = "";
            LockerCollectionPointModel lcpm = LockerCollectionPointRepo.CreateLockerCP(lcp, out error);
            if (error != "" || lcpm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(lcpm);
        }
        [HttpGet]
        [Route("api/lockercollectionpoint/cpname/{cpname}")]
        public IHttpActionResult GetLockerCPByCPName(string cpname)
        {
            string error = "";
            List<LockerCollectionPointModel> lcpm = LockerCollectionPointRepo.GetLockerCPByCPName(cpname, out error);
            if (error != "" || lcpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(lcpm);
        }

        [HttpGet]
        [Route("api/disbursementlocker/reqid/{reqid}")]
        public IHttpActionResult GetDisbursementLockerByReqID(int reqid)
        {
            string error = "";
            DisbursementLockerModel dislm = LockerCollectionPointRepo.GetDisbursementLockerByReqID(reqid, out error);
            if (error != "" || dislm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Disbursement Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dislm);
        }

        [HttpGet]
        [Route("api/disbursementlocker/disid/{disid}")]
        public IHttpActionResult GetDisbursementLockerByDisID(int disid)
        {
            string error = "";
            DisbursementLockerModel dislm = LockerCollectionPointRepo.GetDisbursementLockerByDisID(disid, out error);
            if (error != "" || dislm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Disbursement Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dislm);
        }

        [HttpGet]
        [Route("api/disbursementlocker/lockerreq/{lockerid}/{reqid}")]
        public IHttpActionResult GetDisbursementLockerByLockerIDAndReqID(int lockerid, int reqid)
        {
            string error = "";
            DisbursementLockerModel dislm = LockerCollectionPointRepo.GetDisbursementLockerByReqIDAndLockerID(reqid, lockerid, out error);
            if (error != "" || dislm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Disbursement Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dislm);
        }

        [HttpGet]
        [Route("api/disbursementlockers/lockerid/{lockerid}")]
        public IHttpActionResult GetDisbursementsLockerByLockerID(int lockerid)
        {
            string error = "";
            List<DisbursementLockerModel> dislms = LockerCollectionPointRepo.GetDisbursementLockersByLockerID(lockerid, out error);
            if (error != "" || dislms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Disbursement Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dislms);
        }

        [HttpPost]
        [Route("api/disbursementlockers/create")]
        public IHttpActionResult CreateDisbursementLocker(DisbursementLockerModel disl)
        {
            string error = "";
            DisbursementLockerModel dislm = LockerCollectionPointRepo.CreateDisbursementLocker(disl, out error);
            if (error != "" || dislm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dislm);
        }


        [HttpPost]
        [Route("api/disbursementlockers/update")]
        public IHttpActionResult UpdateDisbursementLocker(DisbursementLockerModel disl)
        {
            string error = "";
            DisbursementLockerModel dislm = LockerCollectionPointRepo.UpdateDisbursementLocker(disl, out error);
            if (error != "" || dislm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dislm);
        }

        [HttpPost]
        [Route("api/disbursementlockers/collected")]
        public IHttpActionResult UpdateDisbursementLockerToCollected(DisbursementLockerModel disl)
        {
            string error = "";
            DisbursementLockerModel dislm = LockerCollectionPointRepo.UpdateDisbursementLocker(disl, out error);

            LockerCollectionPointModel lcpm = LockerCollectionPointRepo.GetLockerCPByLockerid(dislm.LockerID, out error);
            lcpm.Status = ConLockerCollectionPoint.Active.AVAILABLE;
            lcpm = LockerCollectionPointRepo.UpdateLockerCP(lcpm, out error);

            if (error != "" || dislm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }


            return Ok(dislm);
        }
    }
}