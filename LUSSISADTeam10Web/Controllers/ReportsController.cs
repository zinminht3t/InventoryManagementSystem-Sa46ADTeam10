using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.APIModels;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using LUSSISADTeam10Web.Models.Employee;
using LUSSISADTeam10Web.Models.Report;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static LUSSISADTeam10Web.Models.Report.ItemTrendAnalysisViewModel;

// Authors: Khin Yadana Phyo | Zin Min Htet | Htet Wai Yan
namespace LUSSISADTeam10Web.Controllers
{
    [Authorize(Roles = "Clerk, Supervisor, Manager")]
    public class ReportsController : Controller
    {
        #region Authors: Khin Yadana Phyo | Zin Min Htet | Htet Wai Yan

        public ActionResult ItemUsageReport()
        {

            string token = GetToken();
            SupplierModel sm = new SupplierModel();
            string error = "";

            UserModel um = GetUser();
            ViewBag.SupplierModel = sm;
            MonthlyItemUsageViewModel viewmodel = new MonthlyItemUsageViewModel();
            List<SupplierModel> sml = new List<SupplierModel>();
            sml = APISupplier.GetAllSuppliers(token, out error);

            try
            {

                //ViewBag.SupplierModel = APISupplier.GetAllSuppliers(token, out error);
                ViewBag.count = 0;
                viewmodel.supplier1 = sm.SupId;
                viewmodel.supplier2 = sm.SupId;
                viewmodel.supplier3 = sm.SupId;
                List<int> suppliername = new List<int>();

                ViewBag.supplier = sml;

                foreach (SupplierModel s in sml)
                {
                    suppliername.Add(s.SupId);

                }
                List<SupplierModel> sups = APISupplier.GetAllSuppliers(token, out error);
                ViewBag.slist = sups;
                ViewBag.ilist = APIItem.GetAllItems(token, out error);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new
                {
                    error = ex.Message
                });
            }
            ViewBag.count = 0;
            return View(viewmodel);
        }

        public ActionResult ItemTrendAnalysisReport()
        {

            string token = GetToken();
            DepartmentModel dm = new DepartmentModel();
            string error = "";
            ItemTrendAnalysisViewModel viewmodel = new ItemTrendAnalysisViewModel();

            List<DepartmentModel> mm = APIDepartment.GetAllDepartments(token, out error);
            viewmodel.itd = new List<ItemTrendDetailViewModel>();



            foreach (DepartmentModel m in mm)
            {
                var result = new ItemTrendDetailViewModel();
                result.d1 = m.Deptid;
                result.d2 = m.Deptid;
                result.d3 = m.Deptid;
                result.d1Name = m.Deptname;
                result.d2Name = m.Deptname;
                result.d3Name = m.Deptname;
                viewmodel.itd.Add(result);
            }
            ViewBag.catlist = APICategory.GetAllCategories(token, out error);
            ViewBag.deptlist = APIDepartment.GetAllDepartments(token, out error);
            ViewBag.count = 0;
            return View(viewmodel);
        }

        [HttpPost]
        public JsonResult GetItemUsageData(int s1, int s2, int s3, int item)
        {
            string error = "";
            UserModel um = GetUser();
            string token = GetToken();

            List<ItemUsageModel> result = APIReport.GetItemUsage(token, s1, s2, s3, item, out error);
            int[] past2mon = new int[] { result[2].Sup1Data, result[2].Sup2Data, result[2].Sup3Data };
            int[] past1mon = new int[] { result[1].Sup1Data, result[1].Sup2Data, result[1].Sup3Data };
            int[] current = new int[] { result[0].Sup1Data, result[0].Sup2Data, result[0].Sup3Data };

            return Json(new
            {
                p2 = past2mon,
                p1 = past1mon,
                cur = current
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetItemTrendData(int d1, int d2, int d3, int catid)
        {
            string error = "";
            UserModel um = GetUser();
            string token = GetToken();

            List<TrendAnalysisModel> result = APIReport.GetItemTrendsByDeptCategory(token, d1, d2, d3, catid, out error);

            int[] past2mon = new int[] { result[2].Dept1Data, result[2].Dept2Data, result[2].Dept3Data };
            int[] past1mon = new int[] { result[1].Dept1Data, result[1].Dept2Data, result[1].Dept3Data };
            int[] current = new int[] { result[0].Dept1Data, result[0].Dept2Data, result[0].Dept3Data };

            return Json(new
            {
                p2 = past2mon,
                p1 = past1mon,
                cur = current
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion

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