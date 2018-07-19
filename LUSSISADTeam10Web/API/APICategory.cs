using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.API
{
    public class APICategory
    {
        public static List<CategoryModel> GetAllCategories(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/categories/";
            List<CategoryModel> dms = APIHelper.Execute<List<CategoryModel>>(token, url, out error);
            return dms;
        }
        public static CategoryModel GetCategoryByCatID(string token, int catid, out string error)
        {
            string url = APIHelper.Baseurl + "/category/" + catid;
            CategoryModel dm = APIHelper.Execute<CategoryModel>(token, url, out error);
            return dm;
        }
        public static CategoryModel GetCategoryByItemID(string token, int itemid, out string error)
        {
            string url = APIHelper.Baseurl + "/category/item/" + itemid;
            CategoryModel dm = APIHelper.Execute<CategoryModel>(token, url, out error);
            return dm;
        }
        public static CategoryModel CreateCategory(string token, CategoryModel catm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/category/create";
            string objectstring = JsonConvert.SerializeObject(catm);
            catm = APIHelper.Execute<CategoryModel>(token, objectstring, url, out error);
            return catm;
        }
        public static CategoryModel UpdateCategory(string token, CategoryModel catm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/category/update";
            string objectstring = JsonConvert.SerializeObject(catm);
            catm = APIHelper.Execute<CategoryModel>(token, objectstring, url, out error);
            return catm;
        }
    }
}