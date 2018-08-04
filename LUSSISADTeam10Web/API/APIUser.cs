using LUSSISADTeam10Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

// Author : Zin Min Htet
namespace LUSSISADTeam10Web.API
{
    public class APIUser
    {
        public static List<UserModel> GetAllItems(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/users/";
            List<UserModel> um = APIHelper.Execute<List<UserModel>>(token, url, out error);
            return um;
        }

        public static UserModel GetUserByUserID(int userid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/user/" + userid;
            UserModel um = APIHelper.Execute<UserModel>(token, url, out error);
            return um;
        }

        public static List<UserModel> GetUserByRoleAndDeptID(int role, int deptid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/user/role/" + role + "/" + deptid;
            List<UserModel> um = APIHelper.Execute<List<UserModel>>(token, url, out error);
            return um;
        }

        public static List<UserModel> GetUserByDeptID(int deptid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/user/department/" + deptid;
            List<UserModel> um = APIHelper.Execute<List<UserModel>>(token, url, out error);
            return um;
        }

        public static List<UserModel> GetUsersForHOD(int deptid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/user/hod/" + deptid;
            List<UserModel> um = APIHelper.Execute<List<UserModel>>(token, url, out error);
            return um;
        }
        public static UserModel AssignDepRep(string token, int id, out string error)
        {
            error = ""; 
            string url = APIHelper.Baseurl + "/user/assign/" + id;
            string objectstring = JsonConvert.SerializeObject(id);
            UserModel um = APIHelper.Execute<UserModel>(token, objectstring, url, out error);
            return um;
        }
        public static List<UserModel> GetAssignRepUserList(string token, int id, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/user/assigndepreplist/" + id;
            List<UserModel> um = APIHelper.Execute<List<UserModel>>(token,  url, out error);
            return um;
        }
    }
}