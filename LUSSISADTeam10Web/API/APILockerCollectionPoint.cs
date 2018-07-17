using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;


namespace LUSSISADTeam10Api.API
{
    public class APILockerCollectionPoint
    {
        public static List<LockerCollectionPointModel> GetAllLockerCP(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/lockercollectionpoints/";
            List<LockerCollectionPointModel> lcps = APIHelper.Execute<List<LockerCollectionPointModel>>(token, url, out error);
            return lcps;
        }

        public static LockerCollectionPointModel GetLockerCPByLockerid(int lockerid,string token, out string error)
        {
            string url = APIHelper.Baseurl + "/lockercollectionpoint/lockerid/{lockerid}/";
            LockerCollectionPointModel lcp = APIHelper.Execute<LockerCollectionPointModel>(token, url, out error);
            return lcp;
        }

        public static LockerCollectionPointModel GetLockerCPByLockername(string lockername, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/lockercollectionpoint/lockername/{lockername}/";
            LockerCollectionPointModel lcp = APIHelper.Execute<LockerCollectionPointModel>(token, url, out error);
            return lcp;
        }

        public static List<LockerCollectionPointModel> GetLockerCPByLockerSize(string lockersize,string token, out string error)
        {
            string url = APIHelper.Baseurl + "/lockercollectionpoint/lockersize/{lockersize}/";
            List<LockerCollectionPointModel> lcps = APIHelper.Execute<List<LockerCollectionPointModel>>(token, url, out error);
            return lcps;
        }

        public static List<LockerCollectionPointModel> GetLockerCPBycpid(int cpid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/lockercollectionpoint/cp/{cpid}/";
            List<LockerCollectionPointModel> lcps = APIHelper.Execute<List<LockerCollectionPointModel>>(token, url, out error);
            return lcps;
        }

        public static LockerCollectionPointModel UpdateLockerCP(LockerCollectionPointModel lcp, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/lockercollectionpoint/update/";
            LockerCollectionPointModel Lcp = APIHelper.Execute<LockerCollectionPointModel>(token, url, out error);
            return Lcp;
        }

        public static LockerCollectionPointModel CreateLockerCP(LockerCollectionPointModel lcp, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/api/lockercollectionpoint/create/";
            LockerCollectionPointModel lpc = APIHelper.Execute<LockerCollectionPointModel>(token, url, out error);
            return lcp;
        }

        public static List<LockerCollectionPointModel> GetLockerCPByCPName(string cpname, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/lockercollectionpoint/cpname/{cpname}/";
            List<LockerCollectionPointModel> lcps = APIHelper.Execute<List<LockerCollectionPointModel>>(token, url, out error);
            return lcps;
        }


    }
}