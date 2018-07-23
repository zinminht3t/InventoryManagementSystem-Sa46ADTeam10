﻿using LUSSISADTeam10API.Constants;
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
        [Route("api/ItemUsageByClerk/{suppliername}/{month}")]
        public IHttpActionResult ItemUsageByClerk(string suppliername,int month)
        {
            string error = "";
            List<MonthlyItemUsageByClerkModel> reqm = ReportRepo.ItemUsageByClerk(out error,suppliername,month);
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
        [Route("api/ItemTrendAnalysis/{fristdepartname}/{seconddepartname}/{thirddepartname}/{description}")]
        public IHttpActionResult ItemTrendAnalysis(string fristdepartname,string seconddepartname,string thirddepartname, string description )
        {
            string error = "";
            List<ItemTrendAnalysisModel> reqm = ReportRepo.ItemTrendAnalysis(out error, fristdepartname, seconddepartname, thirddepartname, description);
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