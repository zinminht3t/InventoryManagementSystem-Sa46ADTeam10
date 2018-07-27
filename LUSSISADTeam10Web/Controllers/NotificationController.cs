using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LUSSISADTeam10Web.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index(int id)
        {

            string error = "";
            string token = GetToken();
            UserModel um = GetUser();

            NotificationModel notim = new NotificationModel();
            notim = APINotification.UpdateNotificationAsRead(token, id, out error);

            switch (notim.NotiType)
            {
                case ConNotification.NotiType.Adjustment:
                    if(notim.Role == ConUser.Role.SUPERVISOR)
                    {
                        return RedirectToAction("Approve", "Supervisor");
                    }
                    else
                    return RedirectToAction("Approve", "Manager");

                case ConNotification.NotiType.ClerkApprovedCollectionPointChange:
                    return RedirectToAction("CollectionPoint", "HOD");
                case ConNotification.NotiType.ClerkApprovedRequisiton:
                    return RedirectToAction("CollectionPoint", "HOD");
                case ConNotification.NotiType.ClerkRejectedCollectionPointChange:
                    return RedirectToAction("CollectionPoint", "HOD");
                case ConNotification.NotiType.CollectedRequistion:
                    return RedirectToAction("DisbursementDetail", "Clerk", new { id = notim.ResID });
                case ConNotification.NotiType.CollectionPointChangeRequestApproval:
                    return RedirectToAction("ApproveCollectionPoint", "Clerk", new { id = notim.ResID });
                case ConNotification.NotiType.DelegationAssigned:
                    return RedirectToAction("Index", "Home");
                case ConNotification.NotiType.DelegationCancelled:
                    return RedirectToAction("Index", "Home");
                case ConNotification.NotiType.DeliveredRequisition:
                    return RedirectToAction("Index", "Home");
                case ConNotification.NotiType.DeptRepAssigned:
                    return RedirectToAction("Index", "Home");
                case ConNotification.NotiType.HODApprovedRequistion:
                    return RedirectToAction("RequisitionDetail", "Clerk", new { id = notim.ResID });
                case ConNotification.NotiType.OutstandingItemsCollected:
                    return RedirectToAction("OutstandingDetail", "Clerk", new { id = notim.ResID });
                case ConNotification.NotiType.OutstandingItemsReadyToCollect:
                    return RedirectToAction("Index", "Home");
                case ConNotification.NotiType.RejectedRequistion:
                    return RedirectToAction("Index", "Home");
                case ConNotification.NotiType.RequisitionApproval:
                    return RedirectToAction("ApproveRequisition", "HOD", new { id = notim.ResID });
            }
            return View();
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