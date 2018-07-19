using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LUSSISADTeam10Web.API
{
    public class APIDisbursement
    {
        public static List<DisbursementModel> GetAllDisbursement(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursement/";
            List<DisbursementModel> dblist = APIHelper.Execute<List<DisbursementModel>>(token, url, out error);
            return dblist;
        }
        public static List<DisbursementModel> GetAllDisbursementwithDetails(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disburdetails/";
            List<DisbursementModel> dblist = APIHelper.Execute<List<DisbursementModel>>(token, url, out error);
            return dblist;
        }
        public static DisbursementModel GetDisbursementByDisid(string token, int id, out string error)
        {
            string url = APIHelper.Baseurl + "disbursement/disid/" + id;
            DisbursementModel dblist = APIHelper.Execute<DisbursementModel>(token, url, out error);
            return dblist;
        }
        public static List<DisbursementModel> GetDisbursementByRequisitionid(string token, int id, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursement/reqid/" + id;
            List<DisbursementModel> dblist = APIHelper.Execute<List<DisbursementModel>>(token, url, out error);
            return dblist;
        }

        public static List<DisbursementModel> GetDisbursementByackbyid(string token, int id, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursement/ackby/" + id;
            List<DisbursementModel> dblist = APIHelper.Execute<List<DisbursementModel>>(token, url, out error);
            return dblist;
        }

        public static DisbursementModel Createdisbursement(DisbursementModel reqm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursement/create/";
            string objectstring = JsonConvert.SerializeObject(reqm);
            DisbursementModel db = APIHelper.Execute<DisbursementModel>(token, objectstring, url, out error);
            return db;
        }
        public static DisbursementModel UpadateDisbursement(DisbursementModel reqm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursement/update/";
            string objectstring = JsonConvert.SerializeObject(reqm);
            DisbursementModel db = APIHelper.Execute<DisbursementModel>(token, objectstring, url, out error);
            return db;
        }

        public static DisbursementModel CreateRequisitionwithDetails(DisbursementModel reqm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursement/createdetails/";
            string objectstring = JsonConvert.SerializeObject(reqm);
            DisbursementModel db = APIHelper.Execute<DisbursementModel>(token, objectstring, url, out error);
            return db;
        }

        public static List<DisbursementDetailsModel> GetAlldisbursementdetails(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursementdetails/";
            List<DisbursementDetailsModel> dbdlist = APIHelper.Execute<List<DisbursementDetailsModel>>(token, url, out error);
            return dbdlist;
        }

        public static List<DisbursementDetailsModel> GetDisbursementDetailsBydisid(string token, int id, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursement/disid/" + id;
            List<DisbursementDetailsModel> dbdlist = APIHelper.Execute<List<DisbursementDetailsModel>>(token, url, out error);
            return dbdlist;
        }
        public static List<DisbursementDetailsModel> GetDisbursementDetailsByreqid(string token, int id, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursementdetails/itemid/" + id;
            List<DisbursementDetailsModel> dbdlist = APIHelper.Execute<List<DisbursementDetailsModel>>(token, url, out error);
            return dbdlist;

        }
        public static DisbursementDetailsModel CreateDisbursementDetails(DisbursementDetailsModel reqm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursementdetails/create/";
            string objectstring = JsonConvert.SerializeObject(reqm);
            DisbursementDetailsModel db = APIHelper.Execute<DisbursementDetailsModel>(token, objectstring, url, out error);
            return db;
        }
        public static DisbursementDetailsModel UpadateDisbursementDetails(DisbursementDetailsModel reqm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursementdetails/update/";
            string objectstring = JsonConvert.SerializeObject(reqm);
            DisbursementDetailsModel db = APIHelper.Execute<DisbursementDetailsModel>(token, objectstring, url, out error);
            return db;
        }
        public static List<OutstandingItemModel> GetRetriveItemListforClerk(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/disbursement/clerk/" ;
            List<OutstandingItemModel> dbdlist = APIHelper.Execute<List<OutstandingItemModel>>(token, url, out error);
            return dbdlist;

        }


    }
}