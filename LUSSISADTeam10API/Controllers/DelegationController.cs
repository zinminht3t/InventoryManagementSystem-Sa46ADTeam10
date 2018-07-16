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
    public class DelegationController : ApiController

    {
        [HttpGet]
        [Route("api/delegation")]
        public IHttpActionResult GetAllDelegation()
        {
           
            List<DelegationModel> dels = DelegationRepo.GetAllDelegations();
            return Ok(dels);
        }

        // to create new delegation
        [HttpPost]
        [Route("api/delegation/create")]
        public IHttpActionResult CreateDelegation(DelegationModel dele)
        {
            string error = "";
            DelegationModel dm = DelegationRepo.CreateDelegation(dele, out error);
            if (error != "" || dm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }


        // to get delegation by delegation id
        [HttpGet]
        [Route("api/delegation/deleid/{deleid}")]
        public IHttpActionResult GetDelegationByDeleid(int deleid)
        {
            string error = "";
            DelegationModel dm = DelegationRepo.GetDelegationByDelegationID( deleid , out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }
        // to get delegation by user id
        [HttpGet]
        [Route("api/delegation/userid/{userid}")]
        public IHttpActionResult GetDelegationByUserid(int userid)
        {
            string error = "";
            List<DelegationModel> dm = DelegationRepo.GetDelegationByUserId(userid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }
        // to get delegation by assginedby id
        [HttpGet]
        [Route("api/delegation/assignedby/{assignedbyid}")]
        public IHttpActionResult GetDelegationByAssignedbyid(int assignedbyid)
        {
            string error = "";
          List< DelegationModel> dm = DelegationRepo.GetDelegationByassignedby(assignedbyid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }
        // to update delegation
        [HttpPost]
        [Route("api/delegation/update")]
        public IHttpActionResult UpdateDelegationi(DelegationModel del)
        {
            string error = "";
            DelegationModel dele = DelegationRepo.UpdateDelegation(del, out error);
            if (error != "" || dele == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Delegation Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dele);
        }



       


    }
}
