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
            List<AdjustmentViewModel> advlist = new List<AdjustmentViewModel>();

            SupplierItemModel supp = new SupplierItemModel();

            adjlist = APIAdjustment.GetAdjustmentByStatus(token, ConAdjustment.Active.PENDING, out string error);

            foreach (AdjustmentModel ad in adjlist)
            {
                AdjustmentViewModel adv = new AdjustmentViewModel();
                UserModel user = new UserModel();

                user = APIUser.GetUserByUserID((int)ad.Raisedto, token, out error);
                adv.Adjid = ad.Adjid;
                adv.Issueddate = ad.Issueddate;
                adv.Raisedbyname = ad.Raisedbyname;
                adv.RaisedToRole = user.Role;
                adv.RaisedTobyname = ad.Raisedtoname;
                adv.adjdvm = new List<AdjustmentDetailViewModel>();

                foreach (AdjustmentDetailModel adjdm in ad.Adjds)
                {
                    AdjustmentDetailViewModel advdetail = new AdjustmentDetailViewModel();
                    advdetail.Adjid = ad.Adjid;
                    advdetail.Adjustedqty = adjdm.Adjustedqty;
                    advdetail.CategoryName = adjdm.CategoryName;
                    advdetail.Itemdescription = adjdm.Itemdescription;
                    advdetail.Reason = adjdm.Reason;
                    advdetail.UOM = adjdm.UOM;

                    try
                    {
                        //Not all items price in database
                        supp = APISupplier.GetOneSupplierItemByItemId(adjdm.Itemid, token, out error);
                        advdetail.Price = supp.Price * Math.Abs(advdetail.Adjustedqty);
                    }
                    catch (Exception e)
                    {
                        if (supp == null) advdetail.Price = 0.0;
                    }
                    adv.adjdvm.Add(advdetail);
                }
                advlist.Add(adv);
            }
            ViewBag.manager = ConUser.Role.MANAGER;
            return View(advlist);
        }
        [HttpPost]
        public ActionResult Approve(int id)
        {
            string token = GetToken();
            AdjustmentModel adj = APIAdjustment.GetAdjustmentbyAdjId(token, id, out string error);
            adj.Status = ConAdjustment.Active.APPROVED;
            APIAdjustment.UpdateAdjustment(token, adj, out error);
            return RedirectToAction("Approve");
        }
        public string GetToken()
        {
            string token = "";
            token = (string)Session["token"];
            return token;
        }
        public UserModel GetUser()
        {
            UserModel user = new UserModel();
            user = (UserModel)Session["user"];
            return user;
        }

    }
}