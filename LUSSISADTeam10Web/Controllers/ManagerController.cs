using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using LUSSISADTeam10Web.Models.Supervisor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LUSSISADTeam10Web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View("ManagerDashboard");
        }

        public ActionResult Approve()
        {
            string token = GetToken();
            List<AdjustmentModel> adjlist = new List<AdjustmentModel>();
            List<AdjustmentDetailModel> adjdetail = new List<AdjustmentDetailModel>();
            SupplierItemModel supp = new SupplierItemModel();

            try
            {
                //get pending status adjustments
                adjlist = APIAdjustment.GetAdjustmentByStatus(token, ConAdjustment.Active.PENDING, out string error);
                foreach(AdjustmentModel ad in adjlist)
                {
                    //to divide according to raised to user role
                    ad.RaiseToRole = (APIUser.GetUserByUserID((int)ad.Raisedto, token, out error)).Role;
                    foreach (AdjustmentDetailModel adj in ad.Adjds) {
                        try
                        {
                            //to show each item adjusted price and total pirce of adjustment form
                            supp = APISupplier.GetOneSupplierItemByItemId(adj.Itemid, token, out error);
                            adj.Price = supp.Price * Math.Abs(adj.Adjustedqty);
                            ad.TotalPrice += adj.Price;
                        }
                        catch (Exception e)
                        {
                            if (supp == null) ad.TotalPrice += 0;
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            ViewBag.manager = adjlist.Where(x => x.RaiseToRole == ConUser.Role.MANAGER).ToList();
            adjlist = adjlist.Where(x => x.RaiseToRole == ConUser.Role.SUPERVISOR).ToList();
            return View(adjlist);
        }
        [HttpPost]
        public ActionResult Approve(int id)
        {
            string token = GetToken();
            try
            {
                AdjustmentModel adj = APIAdjustment.GetAdjustmentbyAdjId(token, id, out string error);
                adj.Status = ConAdjustment.Active.APPROVED;
                APIAdjustment.UpdateAdjustment(token, adj, out error);
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return RedirectToAction("Approve");
        }
        public ActionResult History()
        {
            string token = GetToken();
            List<AdjustmentModel> adjlist = new List<AdjustmentModel>();
            SupplierItemModel supp = new SupplierItemModel();
            try
            {
                adjlist = APIAdjustment.GetAdjustmentByStatus(token, ConAdjustment.Active.APPROVED, out string error);
                foreach(AdjustmentModel ad in adjlist)
                {
                    foreach(AdjustmentDetailModel add in ad.Adjds)
                    {
                        supp = APISupplier.GetOneSupplierItemByItemId(add.Itemid, token, out error);
                        add.Price = supp.Price * Math.Abs(add.Adjustedqty);
                        ad.TotalPrice += add.Price;
                    }
                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return View(adjlist);
        }
       
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