
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.API
{
    public class APIPurchaseOrder
    {
        public static List<PurchaseOrderModel> GetAllPurchaseOrders(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/purchaseorders/";
            List<PurchaseOrderModel> pos = APIHelper.Execute<List<PurchaseOrderModel>>(token, url, out error);
            return pos;
        }
        public static PurchaseOrderModel GetPurchaseOrderByID(string token, int poid, out string error)
        {
            string url = APIHelper.Baseurl + "/purchaseorder/" + poid;
            PurchaseOrderModel pom = APIHelper.Execute<PurchaseOrderModel>(token, url, out error);
            return pom;
        }
        public static List<PurchaseOrderModel> GetPurchaseOrderByPODate(DateTime podate, string token, out string error)
        {
            string url = APIHelper.Baseurl + "purchaseorder/podate/" + podate;
            List<PurchaseOrderModel> pomlist = APIHelper.Execute<List<PurchaseOrderModel>>(token, url, out error);
            return pomlist;
        }
        public static List<PurchaseOrderModel> GetPurchaseOrderByUserID(int userid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "purchaseorder/user/"+ userid;
            List<PurchaseOrderModel> pomlist = APIHelper.Execute<List<PurchaseOrderModel>>(token, url, out error);
            return pomlist;
        }
        public static List<PurchaseOrderModel> GetPurchaseOrderByStatus(int status, string token, out string error)
        {
            string url = APIHelper.Baseurl + "purchaseorder/status/" + status;
            List<PurchaseOrderModel> pomlist = APIHelper.Execute<List<PurchaseOrderModel>>(token, url, out error);
            return pomlist;
        }
        public static PurchaseOrderModel UpdatePO(PurchaseOrderModel pom, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/purchaseorder/update";
            string objectstring = JsonConvert.SerializeObject(pom);
            pom = APIHelper.Execute<PurchaseOrderModel>(token, objectstring, url, out error);
            return pom;
        }
        public static PurchaseOrderModel UpdatePOStatusComplete(PurchaseOrderModel pom, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/purchaseorder/complete";
            string objectstring = JsonConvert.SerializeObject(pom);
            pom = APIHelper.Execute<PurchaseOrderModel>(token, objectstring, url, out error);
            return pom;
        }
        public static PurchaseOrderModel CreatePurchaseOrder( PurchaseOrderModel pom, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/purchaseorder/create";
            string objectstring = JsonConvert.SerializeObject(pom);
            pom = APIHelper.Execute<PurchaseOrderModel>(token, objectstring, url, out error);
            return pom;
        }
        public static List<PurchaseOrderModel> GetPurchaseOrderDetailById(int poid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "purchaseorderdetail/" + poid;
            List<PurchaseOrderModel> pomlist = APIHelper.Execute<List<PurchaseOrderModel>>(token, url, out error);
            return pomlist;
        }
        public static PurchaseOrderDetailModel GetPurchaseOrderDetailByIdAndItemId(int poid, int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "purchaseorderdetail/" + poid+"/"+itemid;
            PurchaseOrderDetailModel podm = APIHelper.Execute<PurchaseOrderDetailModel>(token, url, out error);
            return podm;
        }
        public static PurchaseOrderDetailModel UpdatePODetail(PurchaseOrderDetailModel podm, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/purchaseorderdetail/update";
            string objectstring = JsonConvert.SerializeObject(podm);
            podm = APIHelper.Execute<PurchaseOrderDetailModel>(token, objectstring, url, out error);
            return podm;
        }
        public static PurchaseOrderDetailModel CreatePODetail(PurchaseOrderDetailModel podm, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/purchaseorderdetail/create";
            string objectstring = JsonConvert.SerializeObject(podm);
            podm = APIHelper.Execute<PurchaseOrderDetailModel>(token, objectstring, url, out error);
            return podm;
        }
    }
}