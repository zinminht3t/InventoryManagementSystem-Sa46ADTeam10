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
            PurchaseOrderModel dm = APIHelper.Execute<PurchaseOrderModel>(token, url, out error);
            return dm;
        }
        public static PurchaseOrderModel CreatePurchaseOrder(string token, PurchaseOrderModel pom, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/purchaseorder/create";
            string objectstring = JsonConvert.SerializeObject(pom);
            pom = APIHelper.Execute<PurchaseOrderModel>(token, objectstring, url, out error);
            return pom;
        }
    }
}