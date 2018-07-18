using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.API
{
    public class APIInventory
    {
        public static List<InventoryModel> GetAllInventories(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventories/";
            List<InventoryModel> invm = APIHelper.Execute<List<InventoryModel>>(token, url, out error);
            return invm;
        }

        public static InventoryModel GetInventoryByInvid(int invid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventory/" + invid;
            InventoryModel invm = APIHelper.Execute<InventoryModel>(token, url, out error);
            return invm;
        }

        public static InventoryModel GetInventoryByItemid(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventory/item/" + itemid;
            InventoryModel invm = APIHelper.Execute<InventoryModel>(token, url, out error);
            return invm;
        }

        public static List<InventoryDetailModel> GetAllInventoryDetails(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorydetails/";
            List<InventoryDetailModel> invm = APIHelper.Execute<List<InventoryDetailModel>>(token, url, out error);
            return invm;
        }

        public static InventoryDetailModel GetInventoryDetailByInvid(int invid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorydetail/" + invid;
            InventoryDetailModel invm = APIHelper.Execute<InventoryDetailModel>(token, url, out error);
            return invm;
        }

        public static InventoryDetailModel GetInventoryDetailByItemid(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorydetail/item/" + itemid;
            InventoryDetailModel invm = APIHelper.Execute<InventoryDetailModel>(token, url, out error);
            return invm;
        }

        public static InventoryModel CreateInventory(string token, InventoryModel invm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/inventory/create";
            string objectstring = JsonConvert.SerializeObject(invm);
            invm = APIHelper.Execute<InventoryModel>(token, objectstring, url, out error);
            return invm;
        }

        public static InventoryModel UpdateInventory(string token, InventoryModel ivnm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/inventory/update";
            string objectstring = JsonConvert.SerializeObject(ivnm);
            ivnm = APIHelper.Execute<InventoryModel>(token, objectstring, url, out error);
            return ivnm;
        }

    }
}