using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.API
{
    public class APISupplier
    {
        public static List<SupplierModel> GetAllSuppliers(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/suppliers/";
            List<SupplierModel> smlist = APIHelper.Execute<List<SupplierModel>>(token, url, out error);
            return smlist;
        }
        public static SupplierModel GetSupplierById(int supid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/supplier/"+supid;
            SupplierModel sm = APIHelper.Execute<SupplierModel>(token, url, out error);
            return sm;
        }
        public static List<SupplierModel> GetSupplierByItemId(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/supplier/item/" + itemid;
            List<SupplierModel> smlist = APIHelper.Execute<List<SupplierModel>>(token, url, out error);
            return smlist;
        }
        public static SupplierModel UpdateSupplier(SupplierModel sm, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplier/update";
            string objectstring = JsonConvert.SerializeObject(sm);
            sm = APIHelper.Execute<SupplierModel>(token, objectstring, url, out error);
            return sm;
        }
        public static SupplierModel CreateSupplier(SupplierModel sm, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplier/create";
            string objectstring = JsonConvert.SerializeObject(sm);
            sm = APIHelper.Execute<SupplierModel>(token, objectstring, url, out error);
            return sm;
        }
        public static SupplierModel DeactivateSupplier(SupplierModel sm, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplier/deactivate";
            string objectstring = JsonConvert.SerializeObject(sm);
            sm = APIHelper.Execute<SupplierModel>(token, objectstring, url, out error);
            return sm;
        }
        public static SupplierModel ActivateSupplier(SupplierModel sm, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplier/activate";
            string objectstring = JsonConvert.SerializeObject(sm);
            sm = APIHelper.Execute<SupplierModel>(token, objectstring, url, out error);
            return sm;
        }
        public static List<SupplierItemModel> GetItemsBySupplierId(int supid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/supplier/"+supid+"/items";
            List<SupplierItemModel> smlist = APIHelper.Execute<List<SupplierItemModel>>(token, url, out error);
            return smlist;
        }
        public static List<SupplierModel> GetSupplierByStatus (int status, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/supplier/status/" + status;
            List<SupplierModel> smlist = APIHelper.Execute<List<SupplierModel>>(token, url, out error);
            return smlist;
        }
        public static List<SupplierItemModel> GetAllSupplierItems(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/supplieritems/";
            List<SupplierItemModel> simlist = APIHelper.Execute<List<SupplierItemModel>>(token, url, out error);
            return simlist;
        }
        public static SupplierItemModel GetItemPrice(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/itemprice/"+itemid;
            SupplierItemModel sim = APIHelper.Execute<SupplierItemModel>(token, url, out error);
            return sim;
        }
        public static SupplierItemModel UpdateSupplierItem(SupplierItemModel sim, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplieritem/update";
            string objectstring = JsonConvert.SerializeObject(sim);
            sim = APIHelper.Execute<SupplierItemModel>(token, objectstring, url, out error);
            return sim;
        }
        public static SupplierItemModel CreateSupplierItem(SupplierItemModel sim, string token, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplieritem/create";
            string objectstring = JsonConvert.SerializeObject(sim);
            sim = APIHelper.Execute<SupplierItemModel>(token, objectstring, url, out error);
            return sim;
        }
        public static List<SupplierItemModel> GetSupplierItemByItemId(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/supplieritem/item/" + itemid;
            List<SupplierItemModel> simlist = APIHelper.Execute<List<SupplierItemModel>>(token, url, out error);
            return simlist;
        }
        public static SupplierItemModel GetOneSupplierItemByItemId(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/supplieritem/getitem/"+itemid;
            SupplierItemModel sim = APIHelper.Execute<SupplierItemModel>(token, url, out error);
            return sim;
        }
        public static List<SupplierItemModel> csvsupplier(string token ,List<SupplierItemModel> csp, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplieritem/csv" ;
            string objectstring = JsonConvert.SerializeObject(csp);
            csp = APIHelper.Execute<List<SupplierItemModel>>(token, objectstring, url, out error);
            return csp;
        }
        public static List<SupplierItemModel> importsupplieritem(string token, List<SupplierItemModel> csp, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplieritem/importsupplieritem";
            string objectstring = JsonConvert.SerializeObject(csp);
            csp = APIHelper.Execute<List<SupplierItemModel>>(token, objectstring, url, out error);
            return csp;
        }
        public static List<SupplierModel> importsupplier(string token, List<SupplierModel> csp, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/supplier/importsupplier";
            string objectstring = JsonConvert.SerializeObject(csp);
            csp = APIHelper.Execute<List<SupplierModel>>(token, objectstring, url, out error);
            return csp;
        }
    }
}