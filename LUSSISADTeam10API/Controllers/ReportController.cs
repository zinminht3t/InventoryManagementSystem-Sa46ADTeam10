using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
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
        [HttpGet]
        [Route("api/MonthlyItemUsageByHOD")]
        public IHttpActionResult MonthlyItemUsageReportByHOD()
        {
            string error = "";
            List<ReportsModel> rm = ReportRepo.MonthlyItemUsageByHOD(out error);
            // if the erorr is not blank or the category list is null
            if (error != "" || rm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(rm);
        }




        [HttpGet]
        [Route("api/requistionalist")]
        public IHttpActionResult RequisitionList()
        {
            string error = "";
            List<RequsitionListReportModel> reqm = ReportRepo.RequsitionList(out error);
            // if the erorr is not blank or the category list is null
            if (error != "" || reqm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(reqm);
        }


        [HttpGet]
        [Route("api/ItemUsageByClerk/")]
        public IHttpActionResult ItemUsageByClerk()
        {
            string error = "";
            List<MonthlyItemUsageByClerkModel> reqm = ReportRepo.ItemUsageByClerk(out error);
            // if the erorr is not blank or the category list is null
            if (error != "" || reqm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(reqm);
        }


        [HttpGet]
        [Route("api/ItemUsageByClerk/{suppliername1}/{suppliername2}/{suppliername3}/{month}")]
        public IHttpActionResult ItemUsageByClerk(int suppliername1, int suppliername2, int suppliername3,int month)
        {
            string error = "";
            List<MonthlyItemUsageByClerkModel> reqm = ReportRepo.ItemUsageByClerk(out error,suppliername1,suppliername2,suppliername3,month);
            // if the erorr is not blank or the category list is null
            if (error != "" || reqm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(reqm);
        }


        //[HttpGet]
        //[Route("api/ItemUsageByClerk/")]
        //public IHttpActionResult GetItemUsageByClerk()
        //{
        //    string error = "";
        //    List<MonthlyItemUsageByClerkModel> reqm = ReportRepo.ItemUsageByClerk(out error);
        //    // if the erorr is not blank or the category list is null
        //    if (error != "" || reqm == null)
        //    {
        //        // if the error is 404
        //        if (error == ConError.Status.NOTFOUND)
        //            return Content(HttpStatusCode.NotFound, "Report Is Not Found");
        //        // if the error is other one
        //        return Content(HttpStatusCode.BadRequest, error);
        //    }
        //    // if there is no error
        //    return Ok(reqm);
        //}


        [HttpGet]
        [Route("api/ItemTrendAnalysis/{fristdepartname}/{seconddepartname}/{thirddepartname}/{itemid}")]
        public IHttpActionResult ItemTrendAnalysis(int fristdepartname,int seconddepartname,int thirddepartname, int itemid )
        {
            string error = "";
            List<ItemTrendAnalysisModel> reqm = ReportRepo.ItemTrendAnalysis(out error, fristdepartname, seconddepartname, thirddepartname, itemid);
            // if the erorr is not blank or the category list is null
            if (error != "" || reqm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(reqm);
        }

        [HttpGet]
        [Route("api/ItemTrendAnalysis/")]
        public IHttpActionResult ItemTrendAnalysis()
        {
            string error = "";
            List<ItemTrendAnalysisModel> reqm = ReportRepo.ItemTrendAnalysis(out error);
            // if the erorr is not blank or the category list is null
            if (error != "" || reqm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(reqm);
        }

        //[HttpGet]
        //[Route("api/ItemTrendAnalysis/")]
        //public IHttpActionResult GetItemTrendAnalysis()
        //{
        //    string error = "";
        //    List<ItemTrendAnalysisModel> reqm = ReportRepo.ItemTrendAnalysis(out error);
        //    // if the erorr is not blank or the category list is null
        //    if (error != "" || reqm == null)
        //    {
        //        // if the error is 404
        //        if (error == ConError.Status.NOTFOUND)
        //            return Content(HttpStatusCode.NotFound, "Report Is Not Found");
        //        // if the error is other one
        //        return Content(HttpStatusCode.BadRequest, error);
        //    }
        //    // if there is no error
        //    return Ok(reqm);
        //}



        [HttpGet]
        [Route("api/FrequentlyItemList")]
        public IHttpActionResult FrequentlyItemList()
        {
            string error = "";
            List<FrequentlyTop5ItemsModel> reqm = ReportRepo.FrequentlyTop5Items(out error);
            // if the erorr is not blank or the category list is null
            if (error != "" || reqm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(reqm);
        }


        [HttpGet]
        [Route("api/OrderByDepartment")]
        public IHttpActionResult OrderByDepartment()
        {
            string error = "";
            List<OrderByDepartmentModel> odm = ReportRepo.OrderByDept(out error);
            // if the erorr is not blank or the category list is null
            if (error != "" || odm == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Report Is Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(odm);
        }
    }
}