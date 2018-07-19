using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;


namespace LUSSISADTeam10Web.API
{
    public class APIDelegation
    {
        public static List<DelegationModel> GetAllDelegation(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/delegation /";
            List<DelegationModel> delelist = APIHelper.Execute<List<DelegationModel>>(token, url, out error);
            return delelist;
        }

        public static DelegationModel GetDelegationByDeleid(string token, int id , out string error)
        {
            string url = APIHelper.Baseurl + "/delegation/deleid/" + id;
            DelegationModel delelist = APIHelper.Execute<DelegationModel>(token, url, out error);
            return delelist;
        }
        public static List<DelegationModel> GetDelegationByAssignedbyid(string token,int id, out string error)
        {
            string url = APIHelper.Baseurl + "/delegation/assignedby/" + id;
            List<DelegationModel> delelist = APIHelper.Execute<List<DelegationModel>>(token, url, out error);
            return delelist;
        }
        public static List<DelegationModel> GetDelegationByUserid(string token, int id, out string error)
        {
            string url = APIHelper.Baseurl + "/delegation /userid/" + id;
            List<DelegationModel> delelist = APIHelper.Execute<List<DelegationModel>>(token, url, out error);
            return delelist;
        }

        public static DelegationModel CreateDepartment(string token, DelegationModel dm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/delegation/create/";
            string objectstring = JsonConvert.SerializeObject(dm);
            dm = APIHelper.Execute<DelegationModel>(token, objectstring, url, out error);
            return dm;
        }
        public static DelegationModel UpdateDelegation(string token, DelegationModel dm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/delegation/update/";
            string objectstring = JsonConvert.SerializeObject(dm);
            dm = APIHelper.Execute<DelegationModel>(token, objectstring, url, out error);
            return dm;
        }
        public static DelegationModel CancelDelegation(string token, DelegationModel dm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/delegation/cancel/";
            string objectstring = JsonConvert.SerializeObject(dm);
            dm = APIHelper.Execute<DelegationModel>(token, objectstring, url, out error);
            return dm;
        }


        public static DelegationModel GetPreviousDelegationByDepid(string token, int id, out string error)
        {
            string url = APIHelper.Baseurl + "/delegation/search/" + id;
           DelegationModel delelist = APIHelper.Execute<DelegationModel>(token, url, out error);
            return delelist;
        }


    }
}