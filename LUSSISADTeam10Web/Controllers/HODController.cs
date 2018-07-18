using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using LUSSISADTeam10Web.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LUSSISADTeam10Web.Controllers
{
    [Authorize(Roles = "HOD")]
    public class HODController : Controller
    {
        // GET: HOD
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RequisitionsList()
        {
            string token = GetToken();
            UserModel um = GetUser();

            List<RequisitionModel> reqms = APIRequisition.GetAllRequisition(token, out string error);

            if (error == "")
            {
                return View(reqms);
            }

            return View(new List<RequisitionModel>());
        }
        public ActionResult OrderHistory()
        {
            string token = GetToken();
            UserModel um = GetUser();

            List<RequisitionModel> reqms = APIRequisition.GetRequisitionByDepid(um.Deptid, token, out string error);
            reqms = reqms.Where(p => p.status == ConRequisition.Status.COMPLETED).ToList();
            if (error == "")
            {
                return View(reqms);
            }

            return View(new List<RequisitionModel>());
        }
        public ActionResult TrackRequisition(int id)
        {
            string token = GetToken();
            UserModel um = GetUser();

            RequisitionModel reqm = APIRequisition.GetRequisitionByReqid(id, token, out string error);
            return View(reqm);
        }
        public ActionResult CollectionPoint()
        {
            string token = GetToken();
            UserModel um = GetUser();

            // to show active collection point
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel();
            dcpm = APICollectionPoint.GetActiveDepartmentCollectionPointByDeptID(token, um.Deptid, out string error);
            ViewBag.ActiveCollectionPoint = dcpm.CpName;

            // to show pending list if exists
            ViewBag.PendingCPR = false;
            List<DepartmentCollectionPointModel> dcpms = APICollectionPoint.GetDepartmentCollectionPointByStatus(token, ConDepartmentCollectionPoint.Status.PENDING, out error);
            try
            {
                dcpms = dcpms.Where(p => p.DeptID == um.Deptid).ToList();
                ViewBag.PendingCollectionPoints = dcpms;
                if(dcpms.Count > 0)
                    ViewBag.PendingCPR = true;
            }
            catch (Exception)
            {
                dcpms = null;
            }

            // for radio button 
            List<CollectionPointModel> cpms = APICollectionPoint.GetAllCollectionPoints(token, out error);
            List<CodeValue> CollectionPointsList = new List<CodeValue>();
            foreach (CollectionPointModel cpm in cpms)
            {
                CollectionPointsList.Add(new CodeValue { Code = cpm.cpid, Value = cpm.cpname });
            }
            ViewBag.CollectionPointsList = CollectionPointsList;

            return View(cpms);
        }

        [HttpPost]
        public ActionResult CollectionPoint(int id)
        {
            string token = GetToken();
            UserModel um = GetUser();
            CollectionPointModel cpm = APICollectionPoint.GetCollectionPointBycpid(token, id, out string error);
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel
            {
                CpID = cpm.cpid,
                DeptID = um.Deptid
            };
            dcpm = APICollectionPoint.CreateDepartmentCollectionPoint(token, dcpm, out error);
            return RedirectToAction("CollectionPoint");
        }
        public ActionResult RequisitionDetail(int id)
        {
            string token = GetToken();
            UserModel um = GetUser();
            RequisitionModel reqm = APIRequisition.GetRequisitionByReqid(id, token, out string error);
            return View(reqm);
        }
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
    }
}