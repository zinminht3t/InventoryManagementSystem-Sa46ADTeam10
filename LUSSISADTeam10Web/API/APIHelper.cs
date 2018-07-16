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
    public class APIHelper
    {
        public static string Baseurl = System.Configuration.ConfigurationManager.AppSettings["apiURL"];


    }
}