using LUSSISADTeam10Web.API;
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

namespace LUSSISADTeam10Web.Controllers
{
    [Authorize(Roles = "Clerk")]
    public class ReportsController : Controller
    {

        #region Get Method
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ItemUsageByClerk()
        {

            string token = GetToken();
            SupplierModel sm = new SupplierModel();
            string error = "";
           
            UserModel um = GetUser();
            ViewBag.SupplierModel = sm;
            MonthlyItemUsageViewModel viewmodel = new MonthlyItemUsageViewModel();
            List<SupplierModel> sml = new List<SupplierModel>();
            sml = APISupplier.GetAllSuppliers(token, out  error);

            try
            {

                ViewBag.SupplierModel = sml;
                viewmodel.supplier1 = sm.SupId;
                viewmodel.supplier2 = sm.SupId;
                viewmodel.supplier3 = sm.SupId;
                List<int> suppliername = new List<int>();

                ViewBag.supplier = sml;

                foreach (SupplierModel s in sml)
                {
                    suppliername.Add(s.SupId);
                    
                }
                ViewBag.supplierlist = suppliername;

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


        public ActionResult ItemTrendAnalysis()
        {

            string token = GetToken();
            DepartmentModel dm = new DepartmentModel();
            string error = "";

            UserModel um = GetUser();
            ViewBag.DepartmnetModel = dm;
            ItemTrendAnalysisViewModel viewmodel = new ItemTrendAnalysisViewModel();
            List<DepartmentModel> dml = new List<DepartmentModel>();
            dml = APIDepartment.GetAllDepartments(token, out error);

            try
            {

                ViewBag.DepartmnetModel = dml;
                viewmodel.d1 = dm.Deptid;
                viewmodel.d2 = dm.Deptid;
                viewmodel.d3 = dm.Deptid;
                List<int> departmentname = new List<int>();

                ViewBag.departmentname = dml;

                foreach (DepartmentModel d in dml)
                {
                    departmentname.Add(d.Deptid);

                }
                ViewBag.departmentlist = departmentname;

                List<int> month = new List<int>();
                for(int i = 1; i<= 12; i++)
                {
                    month.Add(i);
                }
                ViewBag.monthlist = month;


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

        

        #endregion


        #region POST Method

        [HttpPost]
        public ActionResult ItemUsageByClerk(MonthlyItemUsageViewModel viewModel)
        {

            string error = "";

            UserModel um = GetUser();
         
            string token = GetToken();

            int suppliername1 = viewModel.supplier1;
            int suppliername2 = viewModel.supplier2;
            int suppliername3 = viewModel.supplier3;
            MonthlyItemUsageViewModel viewmodel = new MonthlyItemUsageViewModel();
            List<MonthlyItemUsageByClerkModel> mm = APIReport.ItemUsageByClerk(token, out error, suppliername1, suppliername2, suppliername3);
            viewmodel.mtu = new List<MonthlyItemResultUsageViewModel>();


            foreach (MonthlyItemUsageByClerkModel m in mm)
            {
                var result = new MonthlyItemResultUsageViewModel();
                result.Item_ = m.Item_;
                result.UsageItem = m.UsageItem;
                result.MonthName = m.MonthName;
                result.year = m.year;
                result.supname = m.supname;
                result.supid = m.supid;
                viewmodel.mtu.Add(result);
            }




            ViewBag.count = viewmodel.mtu.Count;

            ViewBag.mtu = viewmodel.mtu;


            return View(viewmodel);
           



            



        }




        [HttpPost]
        public ActionResult ItemTrendAnalysis(ItemTrendAnalysisViewModel viewModel)
        {

            string error = "";

            UserModel um = GetUser();

            string token = GetToken();

            int d1 = viewModel.d1;
            int d2 = viewModel.d2;
            int d3 = viewModel.d3;
            int month = viewModel.month;
            ItemTrendAnalysisViewModel viewmodel = new ItemTrendAnalysisViewModel();
            List<ItemTrendAnalysisModel> itm = APIReport.ItemTrendAnalysis(token, out error, d1, d2, d3,month);
            viewmodel.itd = new List<ItemTrendDetailViewModel>();


            foreach (ItemTrendAnalysisModel trend in itm)
            {
                var result = new ItemTrendDetailViewModel();
          

                result.Deptid = trend.Deptid;
                result.DepartmentName = trend.DepartmentName;
                result.Item_Name = trend.Item_Name;
                result.Itemid = trend.Itemid;
                result.Item_Usage = trend.Item_Usage;
                result.Monthofreq = trend.Monthofreq;
                result.Yearofreq = trend.Yearofreq;
                viewmodel.itd.Add(result);
            }

            ViewBag.count = viewmodel.itd.Count;

            ViewBag.itd = viewmodel.itd;


            return View(viewmodel);
        }
            public ActionResult testingview()
        {
            return View();
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