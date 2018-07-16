using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LUSSISADTeam10Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string error = "";
            string token = APIAccount.getToken("admin", "admin", out error);
            ViewBag.token = token;
            Session["token"] = token;

            token = (string)Session["token"];

            List<PurchaseOrderModel> poms = APIPurchaseOrder.GetAllPurchaseOrders(token, out error);

            PurchaseOrderModel pom = APIPurchaseOrder.GetPurchaseOrderByID(token, 1, out error);
            pom.Podate = new DateTime();

            pom = APIPurchaseOrder.CreatePurchaseOrder(token, pom, out error);

            DepartmentModel dm = APIDepartment.GetDepartmentByDeptid(token, 2, out error);
            dm.deptname = "Testing";

            dm = APIDepartment.CreateDepartment(token, dm, out error);
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Haha()
        {
            string error = "";

            string token = (string)Session["token"];
            List<DepartmentModel> dms = APIDepartment.GetAllDepartments(token, out error);
            return View(dms);
        }
      
    }
}