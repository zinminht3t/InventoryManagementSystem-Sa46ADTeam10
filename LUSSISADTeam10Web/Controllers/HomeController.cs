using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.Account;
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
            int Role = -1;
            if (Session["Role"] != null)
                Role = (int)Session["Role"];
            switch (Role)
            {
                case -1:
                    return RedirectToAction("login", "account");
                case ConUser.Role.CLERK:
                    return RedirectToAction("Index", "Clerk");
                case ConUser.Role.SUPERVISOR:
                    return RedirectToAction("Index", "Supervisor");
                case ConUser.Role.DEPARTMENTREP:
                    return RedirectToAction("Index", "DepartmentRep");
                case ConUser.Role.EMPLOYEE:
                    return RedirectToAction("Index", "Employee");
                case ConUser.Role.HOD:
                    return RedirectToAction("Index", "HOD");
                case ConUser.Role.MANAGER:
                    return RedirectToAction("Index", "Supervisor");
            }
            return RedirectToAction("login", "account");
        }
    }
}