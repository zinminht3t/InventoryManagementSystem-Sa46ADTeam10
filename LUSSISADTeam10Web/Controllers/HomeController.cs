using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.Account;
using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LUSSISADTeam10Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int Role = -1;
            if (Session["Role"] != null)
                Role = (int)Session["Role"];
            switch (Role)
            {
                case -1:
                    return RedirectToAction("login", "account");
                case ConUser.Role.CLERK:
                    return RedirectToAction("Index", "Clerk");
                case ConUser.Role.SUPERVISOR:
                    return RedirectToAction("Index", "Supervisor");
                case ConUser.Role.DEPARTMENTREP:
                    return RedirectToAction("Index", "Employee");
                case ConUser.Role.EMPLOYEE:
                    return RedirectToAction("Index", "Employee");
                case ConUser.Role.HOD:
                    return RedirectToAction("Index", "HOD");
                case ConUser.Role.MANAGER:
                    return RedirectToAction("Index", "Supervisor");
                case ConUser.Role.TEMPHOD:
                    return RedirectToAction("Index", "Employee");
            }
            return RedirectToAction("login", "account");
        }

        public PartialViewResult GetNotifications()
        {
            string token = GetToken();
            UserModel um = GetUser();
            string error = "";
            List<NotificationModel> notis = new List<NotificationModel>();
            notis = APINotification.GetNotiByunread(false, um.Deptid, um.Role, token, out error);
            notis = notis.OrderByDescending(x => x.Datetime).ToList();
            foreach(NotificationModel noti in notis)
            {
                noti.RelativeTime = Utilities.Utility.GetRelativeTime(noti.Datetime);
            }
            ViewBag.NotiCount = notis.Count;
            ViewBag.Notifications = notis;
            return PartialView();
        }

        #region Utilities
        public string GetToken()
        {
            string token = "";
            token = (string)Session["token"];
            if (string.IsNullOrEmpty(token))
            {
                token = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                Session["token"] = token;
                UserModel um = APIAccount.GetUserProfile(token, out string error);
                Session["user"] = um;
                Session["role"] = um.Role;
                Session["department"] = um.Deptname;
            }
            return token;
        }
        public UserModel GetUser()
        {
            UserModel um = (UserModel)Session["user"];
            if (um == null)
            {
                GetToken();
                um = (UserModel)Session["user"];
            }
            return um;
        }
        #endregion
    }
}