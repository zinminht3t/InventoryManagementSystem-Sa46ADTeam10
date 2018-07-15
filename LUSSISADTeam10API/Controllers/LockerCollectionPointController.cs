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
            LockerCollectionPointModel lcpm = LockerCollectionPointRepo.GetLockerCPBycpid(cpid, out error);
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
            LockerCollectionPointModel lcpm = LockerCollectionPointRepo.GetLockerCPByCPName(cpname, out error);
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


    }
}