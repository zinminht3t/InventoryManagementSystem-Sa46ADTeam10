using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10Web.APIModels;
using LUSSISADTeam10Web.Models.APIModels;

// Author : Khin Yadana Phyo | Htet Wai Yan | Zin Min Htet
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

        // Item Usage Report
        public static List<ItemUsageModel> GetItemUsage(string token, int s1, int s2, int s3, int itemid, out string error)
        {
            string url = APIHelper.Baseurl + "/itemusage/" + s1 + "/" + s2 + "/" + s3 + "/" + itemid; 
            List<ItemUsageModel> iums = APIHelper.Execute<List<ItemUsageModel>>(token, url, out error);
            return iums;
        }

        // Item Trend report
        public static List<TrendAnalysisModel> GetItemTrendsByDeptCategory(string token, int d1, int d2, int d3, int catid, out string error)
        {
            string url = APIHelper.Baseurl + "/itemtrendanalysis/" + d1 + "/" + d2 + "/" + d3 + "/" + catid;
            List<TrendAnalysisModel> tams = APIHelper.Execute<List<TrendAnalysisModel>>(token, url, out error);
            return tams;
        }

        public static List<FrequentItemHodModel> GetFrequentItemsHod(string token, int deptid, out string error)
        {
            string url = APIHelper.Baseurl + "/frequentlyordered5hod/" + deptid;
            List<FrequentItemHodModel> fihms = APIHelper.Execute<List<FrequentItemHodModel>>(token, url, out error);
            return fihms;
        }

        public static List<FrequentlyTop5ItemsModel> FrequentlyItemList(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/FrequentlyItemList/";
            List<FrequentlyTop5ItemsModel> ftopit = APIHelper.Execute<List<FrequentlyTop5ItemsModel>>(token, url, out error);
            return ftopit;
        }
        


    }
}