using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author : Zin Min Htet
namespace LUSSISADTeam10Web.API
{
    public class APIItem
    {
        public static List<ItemModel> GetAllItems(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/items/";
            List<ItemModel> invm = APIHelper.Execute<List<ItemModel>>(token, url, out error);
            return invm;
        }
        public static List<ItemModel> GetAllActiveSupplierItems(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/activesupplieritems/";
            List<ItemModel> invm = APIHelper.Execute<List<ItemModel>>(token, url, out error);
            return invm;
        }

        public static ItemModel GetItemByItemID(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/item/" + itemid;
            ItemModel invm = APIHelper.Execute<ItemModel>(token, url, out error);
            return invm;
        }
        public static ItemModel GetItemByCatID(int catid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/item/category/" + catid;
            ItemModel invm = APIHelper.Execute<ItemModel>(token, url, out error);
            return invm;
        }

        public static ItemModel CreateItem(string token, ItemModel item, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/item/create";
            string objectstring = JsonConvert.SerializeObject(item);
            item = APIHelper.Execute<ItemModel>(token, objectstring, url, out error);
            return item;
        }

        public static ItemModel UpdateItem(string token, ItemModel item, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/item/update";
            string objectstring = JsonConvert.SerializeObject(item);
            item = APIHelper.Execute<ItemModel>(token, objectstring, url, out error);
            return item;
        }
    }
}