using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace LUSSISADTeam10Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)

            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        string token = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;

                        // token = (string) Session["token"];
                        UserModel user = APIAccount.GetUserProfile(token, out string error);
                        roles = ConUser.CovertRoletoRoleString(user.Role);

                        if(user != null && token != null)
                        {

                        }

                        e.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(user.Fullname, "Forms"), roles.Split(';'));
                    }
                    catch (Exception ex)
                    {
                        var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                        Response.Redirect(urlHelper.Action("Login", "Account"));
                    }
                }
            }
        }
    }
}
