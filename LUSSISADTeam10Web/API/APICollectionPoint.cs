using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;


namespace LUSSISADTeam10Web.API
{
    public class APICollectionPoint
    {
        public static List<CollectionPointModel> GetAllCollectionPoints(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoints/";
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }
        public static CollectionPointModel GetCollectionPointBycpid(string token, int cpid, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoint/" + cpid;
            CollectionPointModel cpm = APIHelper.Execute<CollectionPointModel>(token, url, out error);
            return cpm;
        }
        public static List<CollectionPointModel> GetCollectionPointByReqid(string token,int reqid, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoint/requisition" + reqid;
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }
        public static List<CollectionPointModel> GetCollectionPointByDeptid(string token, int deptid, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoint/department" + deptid;
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }
        public static List<CollectionPointModel> GetCollectionPointByLockerid(string token, int lockerid, out string error)
        {
            string url = APIHelper.Baseurl + "/collectionpoint/lockercollectionpoint" + lockerid;
            List<CollectionPointModel> cpm = APIHelper.Execute<List<CollectionPointModel>>(token, url, out error);
            return cpm;
        }
        public static DepartmentCollectionPointModel GetDepartmentCollectionPointByDcpid(string token, int dcpid, out string error)
        {
            string url = APIHelper.Baseurl + "/departmentcollectionpoint/" + dcpid;
            DepartmentCollectionPointModel dcpm = APIHelper.Execute<DepartmentCollectionPointModel>(token, url, out error);
            return dcpm;
        }
        public static DepartmentCollectionPointModel GetActiveDepartmentCollectionPointByDeptID(string token, int deptid, out string error)
        {
            string url = APIHelper.Baseurl + "/departmentcollectionpoint/department/" + deptid;
            DepartmentCollectionPointModel dcpm = APIHelper.Execute<DepartmentCollectionPointModel>(token, url, out error);
            return dcpm;
        }
        public static CollectionPointModel CreateCollectionPoint(string token, CollectionPointModel cpm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/collectionpoint/create";
            string objectstring = JsonConvert.SerializeObject(cpm);
            cpm = APIHelper.Execute<CollectionPointModel>(token, objectstring, url, out error);
            return cpm;
        }
        public static CollectionPointModel UpdateCollectionPoint(string token, CollectionPointModel cpm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/collectionpoint/update";
            string objectstring = JsonConvert.SerializeObject(cpm);
            cpm = APIHelper.Execute<CollectionPointModel>(token, objectstring, url, out error);
            return cpm;
        }
        public static DepartmentCollectionPointModel CreateDepartmentCollectionPoint(string token, DepartmentCollectionPointModel dcpm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/departmentcollectionpoint/create";
            string objectstring = JsonConvert.SerializeObject(dcpm);
            dcpm = APIHelper.Execute<DepartmentCollectionPointModel>(token, objectstring, url, out error);
            return dcpm;
        }
        
        public static DepartmentCollectionPointModel ConfirmDepartmentCollectionPoint(string token, DepartmentCollectionPointModel dcpm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/departmentcollectionpoint/confirm";
            string objectstring = JsonConvert.SerializeObject(dcpm);
            dcpm = APIHelper.Execute<DepartmentCollectionPointModel>(token, objectstring, url, out error);
            return dcpm;
        }

        public static DepartmentCollectionPointModel RejectDepartmentCollectionPoint(string token, DepartmentCollectionPointModel dcpm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/departmentcollectionpoint/reject";
            string objectstring = JsonConvert.SerializeObject(dcpm);
            dcpm = APIHelper.Execute<DepartmentCollectionPointModel>(token, objectstring, url, out error);
            return dcpm;
        }

        public static List<DepartmentCollectionPointModel> GetDepartmentCollectionPointByStatus(string token, int status, out string error)
        {
            string url = APIHelper.Baseurl + "/departmentcollectionpoint/status/" + status;
            List<DepartmentCollectionPointModel> dcpm = APIHelper.Execute<List<DepartmentCollectionPointModel>>(token, url, out error);
            return dcpm;
        }


    }
}