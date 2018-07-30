using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10Web.APIModels;
using LUSSISADTeam10Web.Models.APIModels;

namespace LUSSISADTeam10Web.API
{
    public class APIReport
    {
        // Manager PO report
        public static List<POCountList> GetPoForfiveMonths(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/poforfivemonths/";
            List<POCountList> poList = APIHelper.Execute<List<POCountList>>(token, url, out error);
            return poList;
        }

        // Item Trend report
        public static List<TrendAnalysisModel> GetItemTrendsByDeptCategory(string token, int d1, int d2, int d3, int catid, out string error)
        {
            string url = APIHelper.Baseurl + "/itemtrendanalysis/" + d1 + "/" + d2 + "/" + d3 + "/" + catid;
            List<TrendAnalysisModel> tams = APIHelper.Execute<List<TrendAnalysisModel>>(token, url, out error);
            return tams;
        }


        public static List<ReportsModel> MonthlyItemUsageReportByHOD(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/MonthlyItemUsageByHOD/";
            List<ReportsModel> mtul = APIHelper.Execute<List<ReportsModel>>(token, url, out error);
            return mtul;
        }

        public static List<RequsitionListReportModel> RequisitionList(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requistionalist/";
            List<RequsitionListReportModel> rlm = APIHelper.Execute<List<RequsitionListReportModel>>(token, url, out error);
            return rlm;
        }


        public static List<MonthlyItemUsageByClerkModel> ItemUsageByClerk(string token, out string error, int suppliername1, int suppliername2, int suppliername3)
        {
            string url = APIHelper.Baseurl + "/ItemUsageByClerk/"+suppliername1+"/"+suppliername2+"/"+suppliername3;
            List<MonthlyItemUsageByClerkModel> micl = APIHelper.Execute<List<MonthlyItemUsageByClerkModel>>(token, url, out error);
            return micl;
        }

        public static List<MonthlyItemUsageByClerkModel> GetItemUsageByClerk(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/ItemUsageByClerk/";
            List<MonthlyItemUsageByClerkModel> micl = APIHelper.Execute<List<MonthlyItemUsageByClerkModel>>(token, url, out error);
            return micl;
        }


        public static List<RequsitionListReportModel> RequsitionList(string token ,out string error,int deptid,DateTime startdate,DateTime enddate)
        {
            string url = APIHelper.Baseurl + "/requistionalist/"+deptid+"/"+startdate.ToString("yyyy-MM-dd")+"/"+enddate.ToString("yyyy-MM-dd");
            var a = startdate.Date;
            List<RequsitionListReportModel> micl = APIHelper.Execute<List<RequsitionListReportModel>>(token, url, out error);
            return micl;
        }
        

        //public static List<ItemTrendAnalysisModel> GetItemTrendAnalysis(string token, out string error)
        //{
        //    string url = APIHelper.Baseurl + "/ItemTrendAnalysis/";
        //    List<ItemTrendAnalysisModel> itam = APIHelper.Execute<List<ItemTrendAnalysisModel>>(token, url, out error);
        //    return itam;
        //}



        public static List<ItemTrendAnalysisModel> ItemTrendAnalysis(string token, out string error, int d1, int d2, int d3,int month)
        {
            string url = APIHelper.Baseurl + "/ItemTrendAnalysis/" + d1 + "/" + d2 + "/" + d3 + "/" + month;
            List<ItemTrendAnalysisModel> micl = APIHelper.Execute<List<ItemTrendAnalysisModel>>(token, url, out error);
            return micl;
        }


        public static List<FrequentlyTop5ItemsModel> FrequentlyItemList(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/FrequentlyItemList/";
            List<FrequentlyTop5ItemsModel> ftopit = APIHelper.Execute<List<FrequentlyTop5ItemsModel>>(token, url, out error);
            return ftopit;
        }


        public static List<OrderByDepartmentModel> OrderByDepartment(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/OrderByDepartment/";
            List<OrderByDepartmentModel> odm = APIHelper.Execute<List<OrderByDepartmentModel>>(token, url, out error);
            return odm;
            
        }


    }
}