using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using LUSSISADTeam10API.Constants;

namespace LUSSISADTeam10API.Controllers
{
    // to allow access only by login user
    [Authorize]
    public class AdjustmentController : ApiController
    {
        // to show adjustment list
        [HttpGet]
        [Route("api/adjustments")]
        public IHttpActionResult GetAllAdjustments()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from departmentrepo and will insert the error if there is one
            List<AdjustmentModel> adj = AdjustmentRepo.GetAllAdjustments(out error);

            // if the erorr is not blank or the department list is null
            if (error != "" || adj == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Departments Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(adj);

        }
    }
}