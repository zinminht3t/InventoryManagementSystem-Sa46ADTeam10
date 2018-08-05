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
            Session["notitype"] = "error";
            Session["notititle"] = "Error";
            Session["notimessage"] = "Oops! Something went wrong. Please Try Again!";
            return RedirectToAction("Index", "Home");
        }
    }
}