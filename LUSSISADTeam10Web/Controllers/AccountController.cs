using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace LUSSISADTeam10Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Your Login page.";
            return View(new UserModel());
        }

        [HttpPost]
        public ActionResult Login(UserModel um)
        {
            string error = "";

            if (um.Username != "" || um.Password != "")
            {
                string token = APIAccount.getToken(um.Username, um.Password, out error);
                if (error == "")
                {
                    um = APIAccount.GetUserProfile(token, out error);
                    Session["token"] = token;

                    switch (um.Role)
                    {
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
                }

            }
            return View();
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "UserDashboard");
            }
        }

        public ActionResult Forbidden()
        {
            return View();


            string userName = (string)Session["UserName"];
            string[] userRoles = (string[])Session["UserRoles"];

            ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));

            userRoles.ToList().ForEach((role) => identity.AddClaim(new Claim(ClaimTypes.Role, role)));

            identity.AddClaim(new Claim(ClaimTypes.Name, userName));

            AuthenticationManager.SignIn(identity);
        }
    }
}