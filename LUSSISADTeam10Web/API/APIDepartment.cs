using LUSSISADTeam10Web.Models.APIModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace LUSSISADTeam10Web.API
{
    public class APIDepartment
    {
        public static List<DepartmentModel> GetAllDepartments(string token, out string error)
        {
            error = "";
            const string contentType = "application/json";
            List<DepartmentModel> dms = null;
            string url = APIHelper.Baseurl + "/departments";
            RestClient client = new RestClient(url);
            RestRequest Request = new RestRequest(Method.GET);
            Request.AddParameter("Authorization", "Bearer " + token.Trim(), ParameterType.HttpHeader);
            IRestResponse Response = client.Execute(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var response = client.Execute<List<DepartmentModel>>(Request);
                dms = response.Data;
            }
            else
            {
                error = Response.StatusCode.ToString();
            }
            return dms;
        }

        public static DepartmentModel GetDepartmentByDeptid(string token, int deptid, out string error)
        {
            error = "";
            const string contentType = "application/json";
            DepartmentModel dm = null;
            string url = APIHelper.Baseurl + "/department/" + deptid;
            RestClient client = new RestClient(url);
            RestRequest Request = new RestRequest(Method.GET);
            Request.AddParameter("Authorization", "Bearer " + token.Trim(), ParameterType.HttpHeader);
            IRestResponse Response = client.Execute(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var response = client.Execute<DepartmentModel>(Request);
                dm = response.Data;
            }
            else
            {
                error = Response.StatusCode.ToString();
            }
            return dm;
        }
    }
}