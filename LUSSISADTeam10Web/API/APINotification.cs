using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;

namespace LUSSISADTeam10Web.API
{
    public class APINotification
    {
        public static List<NotificationModel> GerAllNotification(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/notis/";
            List<NotificationModel> nom = APIHelper.Execute<List<NotificationModel>>(token, url, out error);
            return nom;
        }

        public static NotificationModel GetNotificationByid(string token, int notiid, out string error)
        {
            string url = APIHelper.Baseurl + "/noti/" + notiid;
            NotificationModel nm = APIHelper.Execute<NotificationModel>(token, url, out error);
            return nm;
        }

        public static List<NotificationModel> GetNotiByisread(bool isread,int deptid,int role,string token, out string error)
        {
            string url = APIHelper.Baseurl + "/noti/isread/" + isread + "/" + deptid + "/" + role;
            List<NotificationModel> nom = APIHelper.Execute<List<NotificationModel>>(token, url, out error);
            return nom;
        }


        public static List<NotificationModel> GetNotiByunread(bool isread, int deptid, int role, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/notification/unread/" + isread + "/" + deptid + "/" + role;
            List<NotificationModel> nom = APIHelper.Execute<List<NotificationModel>>(token, url, out error);
            return nom;
        }


        public static NotificationModel CreateNoti(string token,NotificationModel mns, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/notification/create";
            string objectstring = JsonConvert.SerializeObject(mns);
            mns = APIHelper.Execute<NotificationModel>(token, objectstring, url, out error);
            return mns;
        }


    }
}