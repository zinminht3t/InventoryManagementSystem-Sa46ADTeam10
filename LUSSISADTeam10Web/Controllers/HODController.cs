using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using LUSSISADTeam10Web.Models.Common;
using LUSSISADTeam10Web.Models.HOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LUSSISADTeam10Web.Controllers
{
    [Authorize(Roles = "HOD")]
    public class HODController : Controller
    {
        #region Get Methods
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RequisitionsList()
        {
            string token = GetToken();
            UserModel um = GetUser();

            List<RequisitionModel> reqms = new List<RequisitionModel>();

            try
            {
                reqms = APIRequisition.GetAllRequisition(token, out string error);

                if (error != "")
                {
                    return RedirectToAction("Index", "Error", new { error });
                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }

            return View(reqms);
        }
        public ActionResult OrderHistory()
        {

            string token = GetToken();
            UserModel um = GetUser();
            List<RequisitionModel> reqms = new List<RequisitionModel>();
            try
            {
                reqms = APIRequisition.GetRequisitionByDepid(um.Deptid, token, out string error);
                reqms = reqms.Where(p => p.Status == ConRequisition.Status.COMPLETED).ToList();

                if (error != "")
                {
                    return RedirectToAction("Index", "Error", new { error });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }

            return View(reqms);
        }
        public ActionResult TrackRequisition(int id)
        {
            string token = GetToken();
            UserModel um = GetUser();

            RequisitionModel reqm = new RequisitionModel();
            try
            {
                reqm = APIRequisition.GetRequisitionByReqid(id, token, out string error);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return View(reqm);
        }
        public ActionResult CollectionPoint()
        {
            string token = GetToken();
            UserModel um = GetUser();
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel();
            ViewBag.PendingCPR = false;
            List<CodeValue> CollectionPointsList = new List<CodeValue>();
            List<CollectionPointModel> cpms = new List<CollectionPointModel>();
            List<DepartmentCollectionPointModel> dcpms = new List<DepartmentCollectionPointModel>();

            try
            {
                // to show active collection point
                dcpms = APICollectionPoint.GetDepartmentCollectionPointByStatus(token, ConDepartmentCollectionPoint.Status.PENDING, out string error);

                dcpm = APICollectionPoint.GetActiveDepartmentCollectionPointByDeptID(token, um.Deptid, out error);
                ViewBag.ActiveCollectionPoint = dcpm.CpName;

                // to show pending list if exists
                dcpms = dcpms.Where(p => p.DeptID == um.Deptid).ToList();
                ViewBag.PendingCollectionPoints = dcpms;
                if (dcpms.Count > 0)
                    ViewBag.PendingCPR = true;


                // for radio button 
                cpms = APICollectionPoint.GetAllCollectionPoints(token, out error);
                foreach (CollectionPointModel cpm in cpms)
                {
                    CollectionPointsList.Add(new CodeValue { Code = cpm.Cpid, Value = cpm.Cpname });
                }
                ViewBag.CollectionPointsList = CollectionPointsList;

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }


            return View(cpms);
        }
        public ActionResult RequisitionDetail(int id)
        {
            string token = GetToken();
            UserModel um = GetUser();
            RequisitionModel reqm = new RequisitionModel();
            try
            {
                reqm = APIRequisition.GetRequisitionByReqid(id, token, out string error);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return View(reqm);
        }
        public ActionResult ApproveRequisition(int id)
        {
            string token = GetToken();
            UserModel um = GetUser();
            RequisitionModel reqm = new RequisitionModel();
            ViewBag.RequisitionModel = reqm;
            ApproveRequisitionViewModel viewmodel = new ApproveRequisitionViewModel();

            try
            {
                reqm = APIRequisition.GetRequisitionByReqid(id, token, out string error);
                ViewBag.RequisitionModel = reqm;
                viewmodel.ReqID = reqm.Reqid;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return View(viewmodel);
        }
        public ActionResult AssignDepartmentRep()
        {
            UserModel um = new UserModel();
            return View();
        }

        public ActionResult SearchPreviousDelegation()
        {

            string token = GetToken();
            UserModel um = GetUser();
            List<RequisitionModel> reqms = new List<RequisitionModel>();
            try
            {
                reqms = APIRequisition.GetRequisitionByDepid(um.Deptid, token, out string error);
                reqms = reqms.Where(p => p.Status == ConRequisition.Status.COMPLETED).ToList();

                if (error != "")
                {
                    return RedirectToAction("Index", "Error", new { error });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }

            return View(reqms);
        }





















        #endregion

        #region Post Methods
        [HttpPost]
        public ActionResult CollectionPoint(int id)
        {
            string token = GetToken();
            UserModel um = GetUser();
            CollectionPointModel cpm = new CollectionPointModel();
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel();
            try
            {
                cpm = APICollectionPoint.GetCollectionPointBycpid(token, id, out string error);
                dcpm.CpID = cpm.Cpid;
                dcpm.DeptID = um.Deptid;
                dcpm = APICollectionPoint.CreateDepartmentCollectionPoint(token, dcpm, out error);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return RedirectToAction("CollectionPoint");
        }

        [HttpPost]
        public ActionResult ApproveRequisition(ApproveRequisitionViewModel viewmodel)
        {
            string token = GetToken();
            UserModel um = GetUser();
            RequisitionModel reqm = new RequisitionModel();
            reqm.Status = ConRequisition.Status.APPROVED;

            reqm = APIRequisition.GetRequisitionByReqid(viewmodel.ReqID, token, out string error);

            try
            {
                if (!viewmodel.Approve)
                {
                    reqm.Status = ConRequisition.Status.REJECTED;
                }

                reqm = APIRequisition.UpdateRequisition(reqm, token, out error);

                if (viewmodel.Approve)
                {
                    return RedirectToAction("TrackRequisition", new { id = reqm.Reqid });
                }
                return RedirectToAction("RequisitionList");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }

        }
        #endregion

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