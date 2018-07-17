using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.API
{
    public class APIRequisition
    {
        public static List<RequisitionModel> GetAllRequisition(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/";
            List<RequisitionModel> rmlist = APIHelper.Execute<List<RequisitionModel>>(token, url, out error);
            return rmlist;
        }
        public static List<RequisitionModel> GetAllRequisitionwtihDetails(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/reqDetails/";
            List<RequisitionModel> rmlist = APIHelper.Execute<List<RequisitionModel>>(token, url, out error);
            return rmlist;
        }
        public static RequisitionModel GetRequisitionByReqid(int reqid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/reqid/{reqid}/";
            RequisitionModel rm = APIHelper.Execute<RequisitionModel>(token, url, out error);
            return rm;
        }
        //
        public static List<RequisitionModel> GetRequisitionByRaisedid(int raisedid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/raisedbyid/{raisedid}/";
            List<RequisitionModel> rmlist = APIHelper.Execute<List<RequisitionModel>>(token, url, out error);
            return rmlist;
        }
        public static List<RequisitionModel> GetRequisitionByApprovedbyid(int approvedbyid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/approvedbyid/{approvedbyid}/";
            List<RequisitionModel> rmlist = APIHelper.Execute<List<RequisitionModel>>(token, url, out error);
            return rmlist;
        }
        public static List<RequisitionModel> GetRequisitionByDepid(int depid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/depid/{depid}/";
            List<RequisitionModel> rmlist = APIHelper.Execute<List<RequisitionModel>>(token, url, out error);
            return rmlist;
        }
        public static List<RequisitionModel> GetRequisitionByStatus(int status, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/status/{status}/";
            List<RequisitionModel> rmlist = APIHelper.Execute<List<RequisitionModel>>(token, url, out error);
            return rmlist;
        }
        public static List<RequisitionModel> GetRequisitionByReqDate(DateTime reqdate, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/reqdate/{reqdate}/";
            List<RequisitionModel> rmlist = APIHelper.Execute<List<RequisitionModel>>(token, url, out error);
            return rmlist;
        }
        public static List<RequisitionDetailsModel> GetAllRequisitionDetails(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisitiondetails/";
            List<RequisitionDetailsModel> rdmlist = APIHelper.Execute<List<RequisitionDetailsModel>>(token, url, out error);
            return rdmlist;
        }
        public static List<RequisitionDetailsModel> GetRequisitionDetailsByReqId(int reqid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisitiondetails/reqid/{reqid}/";
            List<RequisitionDetailsModel> rdmlist = APIHelper.Execute<List<RequisitionDetailsModel>>(token, url, out error);
            return rdmlist;
        }
        public static List<RequisitionDetailsModel> GetRequisitionDetailsByItemId(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisitiondetails/itemid/{itemid}/";
            List<RequisitionDetailsModel> rdmlist = APIHelper.Execute<List<RequisitionDetailsModel>>(token, url, out error);
            return rdmlist;
        }
        public static List<RequisitionDetailsModel> CreateRequisitionDetails(RequisitionDetailsModel reqdm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisitiondetails/create/";
            List<RequisitionDetailsModel> rdmlist = APIHelper.Execute<List<RequisitionDetailsModel>>(token, url, out error);
            return rdmlist;
        }
        public static RequisitionModel CreateRequisition(RequisitionModel reqm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/create/";
            RequisitionModel rm = APIHelper.Execute<RequisitionModel>(token, url, out error);
            return rm;
        }
        public static RequisitionModel CreateRequisitionwithDetails(RequisitionModel reqm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/createdetails/";
            RequisitionModel rm = APIHelper.Execute<RequisitionModel>(token, url, out error);
            return rm;
        }
        public static RequisitionModel UpdateRequisition(RequisitionModel reqm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/update/";
            RequisitionModel rm = APIHelper.Execute<RequisitionModel>(token, url, out error);
            return rm;
        }
        public static RequisitionDetailsModel UpdateRequisitionDetails(RequisitionDetailsModel reqdm, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisitiondetails/update/";
            RequisitionDetailsModel rdm = APIHelper.Execute<RequisitionDetailsModel>(token, url, out error);
            return rdm;
        }
        public static RequisitionModel UpdateRequisitionStatus(RequisitionModel po, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/requisition/preparing/";
            RequisitionModel rdm = APIHelper.Execute<RequisitionModel>(token, url, out error);
            return rdm;
        }
    }
}