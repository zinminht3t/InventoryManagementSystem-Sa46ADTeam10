using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LUSSISADTeam10Web.Controllers
{
    public class ClerkController : Controller
    {
        // GET: Clerk
        public ActionResult Index()
        {
            return View("ClerkDashboard");
        }
    }
}