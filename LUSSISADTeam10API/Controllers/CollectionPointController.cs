using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LUSSISADTeam10API.Controllers
{
    // to allow access only by login user
    [Authorize]
    public class CollectionPointController : ApiController
    {
        // to show collectionpoint list
        [HttpGet]
        [Route("api/collectionpoints")]
        public IHttpActionResult GetAllCollectionPoints()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from collectionpointrepo and will insert the error if there is one
            List<CollectionPointModel> cpm = CollectionPointRepo.GetAllCollectionPoint(out error);

            // if the erorr is not blank or the collectionpoint list is null
            if (error != "" || cpm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "CollectionsPoints Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(cpm);

        }
        // to get collectoinpoint by collectionpoint id
        [HttpGet]
        [Route("api/collectionpoint/{cpid}")]
        public IHttpActionResult GetCollectionPointByCpid(int cpid)
        {
            string error = "";
            CollectionPointModel cpm = CollectionPointRepo.GetCollectionPointByCpid(cpid, out error);
            if (error != "" || cpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "CollectionPoint Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(cpm);
        }
        // to get department by requisition id
        [HttpGet]
        [Route("api/collectionpoint/requisition/{reqid}")]
        public IHttpActionResult GetCollectionPointByReqid(int reqid)
        {
            string error = "";
            List<CollectionPointModel> cpm = CollectionPointRepo.GetCollectionPointByReqid(reqid, out error);
            if (error != "" || cpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(cpm);
        }
        // to get collectionpoint by department id
        [HttpGet]
        [Route("api/collectionpoint/department/{deptid}")]
        public IHttpActionResult GetCollectionPointByDeptid(int deptid)
        {
            string error = "";
            List<CollectionPointModel> cpm = CollectionPointRepo.GetCollectionPointByDeptid(deptid, out error);
            if (error != "" || cpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Department Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(cpm);
        }
        // to get collectionpoint by locker id
        [HttpGet]
        [Route("api/collectionpoint/lockercollectionpoint/{lockerid}")]
        public IHttpActionResult GetCollectionPointByLockerid(int lockerid)
        {
            string error = "";
            List<CollectionPointModel> cpm = CollectionPointRepo.GetCollectionPointByLockerid(lockerid, out error);
            if (error != "" || cpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Locker Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(cpm);
        }
        // to update collectionpoint
        [HttpPost]
        [Route("api/collectionpoint/update")]
        public IHttpActionResult UpdateCollectionPoint(CollectionPointModel cp)
        {
            string error = "";
            CollectionPointModel cpm = CollectionPointRepo.UpdateCollectionPoint(cp, out error);
            if (error != "" || cpm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "CollectionPoint Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(cpm);
        }

        // to create new collectionpoint
        [HttpPost]
        [Route("api/collectionpoint/create")]
        public IHttpActionResult CreateCollectionPoint(CollectionPointModel cp)
        {
            string error = "";
            CollectionPointModel cpm = CollectionPointRepo.CreateCollectionPoint(cp, out error);
            if (error != "" || cpm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(cpm);
        }
    }
}