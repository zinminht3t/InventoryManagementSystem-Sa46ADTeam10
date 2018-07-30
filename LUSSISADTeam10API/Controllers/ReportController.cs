using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
namespace LUSSISADTeam10API.Controllers
{
    [Authorize]
    public class ReportController :ApiController
    {
        // start zmh
        [HttpGet]
        [Route("api/poforfivemonths")]
        public IHttpActionResult GetPOFor5Months()
        {
            string error = "";
            List<PurchaseOrderFor5MonthModel> rl = ReportRepo.GetPOFor5Months(out error);
            if (error != "" || rl == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(rl);
        }

        [HttpGet]
        [Route("api/itemtrendanalysis/{d1}/{d2}/{d3}/{category}")]
        public IHttpActionResult ItemTrend(int d1, int d2, int d3, int category)
        {
            string error = "";
            List<ItemTrendAnalysisModel> rl = ReportRepo.ItemTrendAnalysis(d1, d2, d3, category, out error);
            if (error != "" || rl == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(rl);
        }

        // end zmh

        // start hwy

        // end hwy


    }
}