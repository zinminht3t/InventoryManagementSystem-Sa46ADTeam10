using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author : Zin Min Htet
namespace LUSSISADTeam10Web.API
{
    public class APIOutstandingReq
    {
        public static List<OutstandingReqModel> GetAllOutReqs(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreqs/";
            List<OutstandingReqModel> outm = APIHelper.Execute<List<OutstandingReqModel>>(token, url, out error);
            return outm;
        }
        public static OutstandingReqModel GetOutstandingReqById(string token, int outreqid, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreq/" + outreqid;
            OutstandingReqModel outm = APIHelper.Execute<OutstandingReqModel>(token, url, out error);
            return outm;
        }
        public static OutstandingReqModel GetOutReqByReqId(string token, int reqid, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreq/requisition/" + reqid;
            OutstandingReqModel outm = APIHelper.Execute<OutstandingReqModel>(token, url, out error);
            return outm;
        }
        public static bool CheckInventoryStock(string token, int outreqid, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreqs/checkstock/" + outreqid;
            bool outm = APIHelper.Execute<bool>(token, url, out error);
            return outm;
        }
        public static OutstandingReqModel UpdateOutReq(OutstandingReqModel outreq, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreq/update/";
            string objectstring = JsonConvert.SerializeObject(outreq);
            OutstandingReqModel outm = APIHelper.Execute<OutstandingReqModel>(token, objectstring, url, out error);
            return outm;
        }
        public static OutstandingReqModel CreateOutReq(OutstandingReqModel outreq, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreq/create/";
            string objectstring = JsonConvert.SerializeObject(outreq);
            OutstandingReqModel outm = APIHelper.Execute<OutstandingReqModel>(token, objectstring, url, out error);
            return outm;
        }
        public static OutstandingReqModel CompleteOutstanding(string token, OutstandingReqModel outreq, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreq/complete/";
            string objectstring = JsonConvert.SerializeObject(outreq);
            OutstandingReqModel outm = APIHelper.Execute<OutstandingReqModel>(token, objectstring, url, out error);
            return outm;
        }
        public static List<OutstandingReqDetailModel> GetAllOutReqDetails(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreqdetails/";
            List<OutstandingReqDetailModel> outm = APIHelper.Execute<List<OutstandingReqDetailModel>>(token, url, out error);
            return outm;
        }
        public static OutstandingReqDetailModel UpdateOutReqDetail(OutstandingReqDetailModel outreqdetail, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreqdetail/update/";
            string objectstring = JsonConvert.SerializeObject(outreqdetail);
            OutstandingReqDetailModel outm = APIHelper.Execute<OutstandingReqDetailModel>(token, objectstring, url, out error);
            return outm;
        }
        public static OutstandingReqDetailModel CreateOutReqDetail(OutstandingReqDetailModel outreqdetail, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingreqdetail/create/";
            string objectstring = JsonConvert.SerializeObject(outreqdetail);
            OutstandingReqDetailModel outm = APIHelper.Execute<OutstandingReqDetailModel>(token, objectstring, url, out error);
            return outm;
        }
        public static List<OutstandingItemModel> GetOutstandingItemList(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/outstandingitemlist/";
            List<OutstandingItemModel> outm = APIHelper.Execute<List<OutstandingItemModel>>(token, url, out error);
            return outm;
        }
    }
}