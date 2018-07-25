using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10web.Models.APIModels;
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;

namespace LUSSISADTeam10Web.API
{
    public class APIReport
    {

        public static List<ReportsModel> MonthlyItemUsageReportByHOD(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/api/MonthlyItemUsageByHOD/";
            List<ReportsModel> mtul = APIHelper.Execute<List<ReportsModel>>(token, url, out error);
            return mtul;
        }


        public static List<RequsitionListReportModel> RequisitionList(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requistionalist/";
            List<RequsitionListReportModel> rlm = APIHelper.Execute<List<RequsitionListReportModel>>(token, url, out error);
            return rlm;
        }


        public static List<MonthlyItemUsageByClerkModel> ItemUsageByClerk(string token, out string error, int suppliername1, int suppliername2, int suppliername3, int month)
        {
            string url = APIHelper.Baseurl + "/ItemUsageByClerk/ " + suppliername1 + suppliername2 +suppliername3+ month;
            List<MonthlyItemUsageByClerkModel> micl = APIHelper.Execute<List<MonthlyItemUsageByClerkModel>>(token, url, out error);
            return micl;
        }

        public static List<MonthlyItemUsageByClerkModel> GetItemUsageByClerk(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/ItemUsageByClerk/";
            List<MonthlyItemUsageByClerkModel> micl = APIHelper.Execute<List<MonthlyItemUsageByClerkModel>>(token, url, out error);
            return micl;
        }





        public static List<ItemTrendAnalysisModel> ItemTrendAnalysis(string token, out string error, string fristdepartname, string seconddepartname, string thirddepartname, string description)
        {
            string url = APIHelper.Baseurl + "/api/ItemTrendAnalysis/" + fristdepartname + seconddepartname + thirddepartname + description;
            List<ItemTrendAnalysisModel> itam = APIHelper.Execute<List<ItemTrendAnalysisModel>>(token, url, out error);
            return itam;
        }


        public static List<ItemTrendAnalysisModel> GetItemTrendAnalysis(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/api/ItemTrendAnalysis/";
            List<ItemTrendAnalysisModel> itam = APIHelper.Execute<List<ItemTrendAnalysisModel>>(token, url, out error);
            return itam;
        }


        public static List<FrequentlyTop5ItemsModel> FrequentlyItemList(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/api/FrequentlyItemList/";
            List<FrequentlyTop5ItemsModel> ftopit = APIHelper.Execute<List<FrequentlyTop5ItemsModel>>(token, url, out error);
            return ftopit;
        }


        public static List<OrderByDepartmentModel> OrderByDepartment(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/api/OrderByDepartment/";
            List<OrderByDepartmentModel> odm = APIHelper.Execute<List<OrderByDepartmentModel>>(token, url, out error);
            return odm;
            
        }


    }
}