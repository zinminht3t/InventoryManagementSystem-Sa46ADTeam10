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
                List<SupplierModel> sups = APISupplier.GetAllSuppliers(token, out  error);
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

        //public ActionResult ItemTrendAnalysis()
        //{

        //    string token = GetToken();
        //    DepartmentModel dm = new DepartmentModel();
        //    string error = "";

        //    UserModel um = GetUser();

        //    ItemTrendAnalysisViewModel viewModel = new ItemTrendAnalysisViewModel();
        //    viewModel.itd = GetDept();
        //    ViewBag.Count = 0;
        //    ViewBag.qq = viewModel.itd;
        //    List<int> month = new List<int>();
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        month.Add(i);
        //    }
        //    ViewBag.monthlist = month;



        //    return View(viewModel);
        //}

        public List<ItemTrendDetailViewModel> GetDept()
        {
            string token = GetToken();
            DepartmentModel dm = new DepartmentModel();
            string error = "";
            List<ItemTrendDetailViewModel> viewModels = new List<ItemTrendDetailViewModel>();
            List<DepartmentModel> dept = APIDepartment.GetAllDepartments(token, out error);
            string text = "";
            int value = 0;
            foreach(DepartmentModel d in dept)
            {
                 text = d.Deptname;
                 value = d.Deptid;

                viewModels.Add(new ItemTrendDetailViewModel
                {
                    DepartmentName = d.Deptname.ToString(),
                    Deptid = d.Deptid
            });
              

                

            }

            return (viewModels);
        }

        #endregion


        #region POST Method

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

            return Json(new {
                p2 = past2mon, p1 = past1mon, cur = current
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ItemUsageByClerk(int s1, int s2, int s3)
        {

            string error = "";

            UserModel um = GetUser();

            string token = GetToken();

            
            MonthlyItemUsageViewModel viewmodel = new MonthlyItemUsageViewModel();
            List<MonthlyItemUsageByClerkModel> mm = APIReport.ItemUsageByClerk(token, out error, s1, s2, s3);
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

            if(ViewBag.mtu == null)
            {
                ViewBag.mtu = new List<MonthlyItemResultUsageViewModel>();
            }

            return View(viewmodel);


        }




        [HttpPost]
        public ActionResult ItemTrendAnalysis(int month, int d1,int d2,int d3)
        {

            string error = "";

            UserModel um = GetUser();

            string token = GetToken();
           
            List<ItemTrendDetailViewModel> lm = new List<ItemTrendDetailViewModel>();
            ItemTrendAnalysisViewModel viewmodel = new ItemTrendAnalysisViewModel();
            List<ItemTrendAnalysisModel> itm = APIReport.ItemTrendAnalysis(token, out error, d1, d2, d3, month);
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

            ViewBag.deptlist = APIDepartment.GetAllDepartments(token, out error);
            
            return View(viewmodel);
        }




        //[HttpPost]
       
        //public ActionResult RequisitionListPost(RequisitionListViewModel viewmodel)

        //{
        //    string token = GetToken();
        //    DateTime startdate = viewmodel.startdate;
        //    DateTime enddate = viewmodel.enddate;
        //    string error = "";
        //    //RequisitionListViewModel viewmodel = new RequisitionListViewModel();
        //    List<RequsitionListReportModel> reql = new List<RequsitionListReportModel>();
        //    if (startdate == null)
        //        startdate = new DateTime(1900, 01, 01);
        //    if (enddate == null)
        //        enddate = new DateTime(2900, 01, 01);
        //    try
        //    {

        //       int deptid = viewmodel.deptid;
        //        reql = APIReport.RequsitionList(token, out error, deptid, (DateTime)startdate, (DateTime)enddate);
        //        viewmodel.rd = new List<RequisitionDetailViewModel>();

        //        foreach (RequsitionListReportModel i in reql)
        //        {

        //            var result = new RequisitionDetailViewModel();



        //            result.deptid = i.Deptid;
        //            result.reqdate = i.Reqdate;
        //            result.status = i.Status;
        //            viewmodel.rd.Add(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("Index", "Error", new { error = ex.Message });
        //    }

        //    ViewBag.count = viewmodel.rd.Count;

        //    ViewBag.itd = viewmodel.rd;
        //    return View(viewmodel);
        //}
        public ActionResult testingview()
        {
            return View();
        }


        //public ActionResult RequisitioListByDept ()
        //{

        //    string token = GetToken();
        //    DepartmentModel dm = new DepartmentModel();
        //    string error = "";

        //    UserModel um = GetUser();
        //    ViewBag.DepartmnetModel = dm;
        //    RequisitionListViewModel viewmodel = new RequisitionListViewModel();
        //    List<DepartmentModel> dml = new List<DepartmentModel>();
        //    dml = APIDepartment.GetAllDepartments(token, out error);

        //    try
        //    {

        //        ViewBag.DepartmnetModel = dml;
        //        viewmodel.deptid = dm.Deptid;

        //        List<int> departmentname = new List<int>();

        //        ViewBag.departmentname = dml;

        //        foreach (DepartmentModel d in dml)
        //        {
        //            departmentname.Add(d.Deptid);

        //        }
        //        ViewBag.departmentlist = departmentname;

        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("Index", "Error", new
        //        {
        //            error = ex.Message
        //        });
        //    }
        //    ViewBag.count = 0;
        //    return View(viewmodel);

        //}

         public ActionResult RequisitionList()
        {
            string token = GetToken();
            DepartmentModel dm = new DepartmentModel();
            string error = "";

            UserModel um = GetUser();
            ViewBag.DepartmnetModel = dm;
            RequisitionListViewModel viewmodel = new RequisitionListViewModel();
            List<DepartmentModel> dml = new List<DepartmentModel>();
            dml = APIDepartment.GetAllDepartments(token, out error);

            try
            {

                ViewBag.DepartmnetModel = dml;
                viewmodel.Deptid = dm.Deptid;

                List<int> departmentname = new List<int>();

                ViewBag.departmentname = dml;

                foreach (DepartmentModel d in dml)
                {
                    departmentname.Add(d.Deptid);

                }
                ViewBag.departmentlist = departmentname;

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


        [HttpPost]
        
        public ActionResult RequisitionList(RequisitionListViewModel viewModel)
        {

            string error = "";

            UserModel um = GetUser();

            string token = GetToken();
            int deptid = um.Deptid;

            //DateTime startdate = new DateTime(2018, 07, 01, 0, 0, 0);
            //DateTime enddate = new DateTime(2018, 07, 31, 0, 0, 0);
            DateTime startdate = viewModel.startdate.Value;
            DateTime enddate = viewModel.enddate.Value;



            List<RequsitionListReportModel> reql = new List<RequsitionListReportModel>();
            viewModel.rd = new List<RequisitionDetailViewModel>();

            reql = APIReport.RequsitionList(token, out error, deptid, startdate  ,enddate);
            


            foreach (RequsitionListReportModel i in reql)
            {
                var result = new RequisitionDetailViewModel();


                result.Deptid = i.Deptid;
                            result.Reqdate = i.Reqdate;
                            result.Status = i.Status;
                            viewModel.rd.Add(result);

            }


            ViewBag.count = viewModel.rd.Count;

            viewModel.rd = viewModel.rd;


            return View(viewModel);
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