using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using LUSSISADTeam10Web.Models.Employee;
using LUSSISADTeam10Web.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            //string error = "";
            //string token = GetToken();
            //UserModel um = GetUser();
            //MonthlyItemUsageViewModel dcpm = new MonthlyItemUsageViewModel();
            //List<SupplierModel> s = new List<SupplierModel>();

            //s = APISupplier.GetAllSuppliers(token, out error);

            //List<string> supname1 = new List<string>();
            //List<string> supname2 = new List<string>();
            //List<string> supname3 = new List<string>();

            //foreach (SupplierModel sm in s)
            //{
            //    supname1.Add(sm.SupName);
            //    supname2.Add(sm.SupName);
            //    supname3.Add(sm.SupName);





            //}

            //ViewBag.supplier1 = supname1;
            //ViewBag.supplier2 = supname2;
            //ViewBag.supplier3 = supname3;
            //ViewBag.supplier = s;




            //return View(new MonthlyItemUsageViewModel());


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
           



            //List<MonthlyItemUsageByClerkModel> vm = new List<MonthlyItemUsageByClerkModel>();
            //MonthlyItemUsageViewModel mv = new MonthlyItemUsageViewModel();


            //vm = APIReport.ItemUsageByClerk(token, out error, viewModel.supplier1, viewModel.supplier2, viewModel.supplier3);

            //System.Collections.IList list = vm;
            //for (int i = 0; i < list.Count; i++)
            //{
            //    MonthlyItemUsageViewModel result = (MonthlyItemUsageViewModel)list[i];
            //    //mv.Item = result.Item;
            //    //mv.UsageItem = result.UsageItem;
            //    //mv.MonthName = result.MonthName;
            //    viewModel.Item = result.Item;
            //    viewModel.UsageItem = result.UsageItem;
            //}


            //return View(viewModel);



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