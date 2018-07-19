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

//Hsu Yee Phyo
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
                    return Content(HttpStatusCode.NotFound, "Adjustment Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(adj);

        }
        //show adjustment and detail by adjustment ID
        [HttpGet]
        [Route("api/adjustment/{adjid}")]        
        public IHttpActionResult GetAdjustmentbyAdjId(int adjid)
        {
            string error = "";
            AdjustmentModel adj = AdjustmentRepo.GetAdjustmentByID(adjid, out error);
            if (error != "" || adj == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Adjustment Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(adj);
        }
        //find adjustment by status
        [HttpGet]
        [Route("api/adjustment/status/{status}")]
        public IHttpActionResult GetAdjustmentByStatus(int status)
        {
            string error = "";
            List<AdjustmentModel> adj = AdjustmentRepo.GetAdjustmentByStatus(status, out error);
            if (error != "" || adj == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Adjustment Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(adj);
        }
        //find adjustment by issuedate
        [HttpGet]
        [Route("api/adjustment/issuedate/{issuedate}")]
        public IHttpActionResult GetAdjustmentByDate(DateTime issuedate)
        {
            string error = "";
            List<AdjustmentModel> adj = AdjustmentRepo.GetAdjustmentByIssuedDate(issuedate, out error);
            if (error != "" || adj == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Adjustment Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(adj);
        }       
        //show adjustment raisedby
        [HttpGet]
        [Route("api/adjustment/raisedby/{raisedby}")]
        public IHttpActionResult GetAdjustmentRaisedBy(int raisedby)
        {
            string error = "";
            List<AdjustmentModel> adjus = AdjustmentRepo.GetAdjustmentByRaisedById(raisedby, out error);
            if (error != "" || adjus == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Adjustment Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(adjus);
        }
        //show adjustment raisedto
        [HttpGet]
        [Route("api/adjustment/raisedto/{raisedto}")]
        public IHttpActionResult GetAdjustmentRaisedTo(int raisedto)
        {
            string error = "";
            List<AdjustmentModel> adjus = AdjustmentRepo.GetAdjustmentByRaisedToId(raisedto, out error);
            if (error != "" || adjus == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Adjustment Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(adjus);
        }
        

        //create adjustment
        [HttpPost]
        [Route("api/adjustment/create")]
        public IHttpActionResult CreateAdjustment(AdjustmentModel adj)
        {
            string error = "";
            AdjustmentModel adjm = AdjustmentRepo.CreateAdjustment(adj, out error);
            //List<AdjustmentDetailModel> adjds = adjm.adjds;           
            //foreach (AdjustmentDetailModel adjd in adjds)
            //{
            //    AdjustmentDetailModel adjdm = AdjustmentDetailRepo.CreateAdjustmentDetail(adjd, out error);
            //}
            if (error != "" || adjm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(adjm);
        }
       
        //update adjustment
        [HttpPost]
        [Route("api/adjustment/update")]
        public IHttpActionResult UpdateAdjustment(AdjustmentModel adj)
        {
            string error = "";
            AdjustmentModel adjm = AdjustmentRepo.UpdateAdjustment(adj, out error);
            if (error != "" || adjm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Adjustment Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(adjm);          
        }
        //update adjustment detail
        [HttpPost]
        [Route("api/adjustment/detail/update")]
        public IHttpActionResult UpdateAdjustmentDetail(AdjustmentDetailModel adjd)
        {
            string error = "";
            AdjustmentDetailModel adjdm = AdjustmentDetailRepo.UpdateAdjustmentDetail(adjd, out error);
            if(error !="" || adjdm == null)
            {
                if(error== ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Adjustment detail is Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
                    }
            return Ok(adjdm);
        }
        
    }
}