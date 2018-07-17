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
            Session["Role"] = 0;
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