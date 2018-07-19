using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models.Common;
using LUSSISADTeam10Web.Models.Clerk;
using System.Reflection;
using System.Security.Claims;
namespace LUSSISADTeam10Web.Controllers
{
    [Authorize(Roles = "Clerk")]
    public class ClerkController : Controller
    {
        // GET: Clerk
        public ActionResult Index()
        {
            return View("ClerkDashboard");
        }

        // Start AM

        // End AM

        // Start TAZ
        public ActionResult ApproveCollectionPoint(int id)
        {
            string token = GetToken();
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel();
            ViewBag.DepartmentCollectionPointModel = dcpm;
            ApproveCollectionPointViewModel viewmodel = new ApproveCollectionPointViewModel();

            try
            {
                dcpm = APICollectionPoint.GetDepartmentCollectionPointByDcpid(token, id ,out string error);
                ViewBag.DepartmentCollectionModel = dcpm;
                viewmodel.CpID =dcpm.DeptCpID;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return View(viewmodel);
        }

        //[HttpPost]
        //public ActionResult ApproveCollectionPoint(ApproveCollectionPointViewModel viewmodel)
        //{
        //    string token = GetToken();
        //    UserModel um = GetUser();
        //    DepartmentCollectionPointModel cpm = new DepartmentCollectionPointModel();
        //    cpm.Status = ConDepartmentCollectionPoint.Status.ACTIVE;

        //    cpm = APICollectionPoint.GetDepartmentCollectionPointByDcpid(token, viewmodel.CpID , out string error);

        //    try
        //    {
        //        if (!viewmodel.Approve)
        //        {
        //            cpm.Status = ConDepartmentCollectionPoint.Status.REJECTED;
        //        }

        //        cpm = APICollectionPoint.ConfirmDepartmentCollectionPoint(token, cpm, out error);

        //        if (viewmodel.Approve)
        //        {
        //            return RedirectToAction("TrackRequisition", new { id = cpm.CpID });
        //        }
        //        return RedirectToAction("CollectionPointList");
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("Index", "Error", new { error = ex.Message });
        //    }

        //}
        // END TAZ

        // Start Mahsu

        // End MaHus

        // Start ZMH

        // End ZMH

        // Start Phyo2

        // End Phyo2

        #region Utilities
        public string GetToken()
        {
            string token = "";
            token = (string)Session["token"];
            return token;
        }
        public UserModel GetUser()
        {
            UserModel um = new UserModel();
            um = (UserModel)Session["user"];
            return um;
        }
        #endregion
    }
}