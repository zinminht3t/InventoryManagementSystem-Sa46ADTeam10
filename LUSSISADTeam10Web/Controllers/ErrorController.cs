using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Author : Zin Min Htet
namespace LUSSISADTeam10Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string error)
        {
            ViewBag.error = error;
            return View();
        }
    }
}