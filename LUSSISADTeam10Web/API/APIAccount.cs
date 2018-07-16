using LUSSISADTeam10Web.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace LUSSISADTeam10Web.API
{
    public class APIAccount
    {

        public static string getToken(string username, string password, out string error)
        {
            error = "";
            string token = "";
            string url = APIHelper.Baseurl + "/token";
            RestClient client = new RestClient(url);
            RestRequest Request = new RestRequest(Method.POST);
            Request.AddParameter("username", username);
            Request.AddParameter("password", password);
            Request.AddParameter("grant_type", "password");
            IRestResponse Response = client.Execute(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var Res = Response.Content;
                JObject jR = JObject.Parse(Res);
                token = jR["access_token"].ToString();
            }
            else
            {
                error = Response.StatusCode.ToString();
            }
            return token;
        }

        public static UserModel GetUserProfile(string token, out string error)
        {
            error = "";
            UserModel um = null;
            string url = APIHelper.Baseurl + "/user";
            RestClient client = new RestClient(url);
            RestRequest Request = new RestRequest(Method.GET);
            Request.AddParameter("Authorization", "Bearer " + token.Trim(), ParameterType.HttpHeader);
            IRestResponse Response = client.Execute(Request);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var response = client.Execute<UserModel>(Request);
                um = response.Data;
            }
            else
            {
                error = Response.StatusCode.ToString();
            }
            return um;
        }
    }
}