using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace LUSSISADTeam10Web.API
{
    public static class APIHelper
    {
        public static string Baseurl = System.Configuration.ConfigurationManager.AppSettings["apiURL"];

        // for GET Methods
        public static T Execute<T>(string _token, string url, out string error) where T : new()
        {
            error = "";
            var request = new RestRequest();
            var client = new RestClient
            {
                BaseUrl = new System.Uri(url)
            };
            if (_token == null)
            {
                _token = "";
            }

            request.AddParameter("Authorization", "Bearer " + _token.Trim(), ParameterType.HttpHeader);
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                // if the error exists
                error += response.ErrorMessage.ToString();
            }
            return response.Data;
        }

        // for POST Methods
        public static T Execute<T>(string _token, string objectstring, string url, out string error) where T : new()
        {
            error = "";
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", objectstring, ParameterType.RequestBody);
            var client = new RestClient
            {
                BaseUrl = new System.Uri(url)
            };
            request.AddParameter("Authorization", "Bearer " + _token.Trim(), ParameterType.HttpHeader);
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                error += response.ErrorMessage.ToString();
            }
            return response.Data;
        }

    }
}