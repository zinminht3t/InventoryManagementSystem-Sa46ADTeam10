using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;

// Author : Hsu Yee Phyo
namespace LUSSISADTeam10Web.API
{
    public class APIAdjustment
    {
        public static List<AdjustmentModel> GetAllAdjustments(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/adjustments/";
            List<AdjustmentModel> adm = APIHelper.Execute<List<AdjustmentModel>>(token, url, out error);
            return adm;
        }
        public static AdjustmentModel GetAdjustmentbyAdjId(string token, int adjid, out string error)
        {
            string url = APIHelper.Baseurl + "/adjustment/" + adjid;
            AdjustmentModel adm = APIHelper.Execute<AdjustmentModel>(token, url, out error);
            return adm;
        }

        public static List<AdjustmentModel> GetAdjustmentByStatus(string token, int status, out string error)
        {
            string url = APIHelper.Baseurl + "/adjustment/status/" + status;
            List<AdjustmentModel> adm = APIHelper.Execute<List<AdjustmentModel>>(token, url, out error);
            return adm;
        }

        public static AdjustmentModel GetAdjustmentByDate(string token, DateTime date, out string error)
        {
            string url = APIHelper.Baseurl + "/adjustment/issuedate/" + date;
            AdjustmentModel adm = APIHelper.Execute<AdjustmentModel>(token, url, out error);
            return adm;
        }

        public static AdjustmentModel GetAdjustmentRaisedBy(string token, int raisedby, out string error)
        {
            string url = APIHelper.Baseurl + "/adjustment/raisedby" + raisedby;
            AdjustmentModel adm = APIHelper.Execute<AdjustmentModel>(token, url, out error);
            return adm;
        }

        public static List<AdjustmentModel> GetAdjustmentRaisedTo(string token, int raisedto, out string error)
        {
            string url = APIHelper.Baseurl + "/adjustment/raisedto" + raisedto;
            List<AdjustmentModel> adm = APIHelper.Execute<List<AdjustmentModel>>(token, url, out error);
            return adm;
        }

        public static AdjustmentModel CreateAdjustment(string token, AdjustmentModel ajm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/adjustment/create";
            string objectstring = JsonConvert.SerializeObject(ajm);
            ajm = APIHelper.Execute<AdjustmentModel>(token, objectstring, url, out error);
            return ajm;
        }

        public static AdjustmentModel UpdateAdjustment(string token, AdjustmentModel ajm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/adjustment/update";
            string objectstring = JsonConvert.SerializeObject(ajm);
            ajm = APIHelper.Execute<AdjustmentModel>(token, objectstring, url, out error);
            return ajm;
        }

        public static AdjustmentDetailModel UpdateAdjustmentDetail(string token, AdjustmentDetailModel ajm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/adjustment/detail/update";
            string objectstring = JsonConvert.SerializeObject(ajm);
            ajm = APIHelper.Execute<AdjustmentDetailModel>(token, objectstring, url, out error);
            return ajm;
        }


    }
}