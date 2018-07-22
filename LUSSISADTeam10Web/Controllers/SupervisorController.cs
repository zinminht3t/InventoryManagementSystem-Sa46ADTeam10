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
    [Authorize(Roles = "Supervisor")]

    public class SupervisorController : Controller
    {
        // GET: Supervisor
        public ActionResult Index()
        {
            return View("SupervisorDashboard");
        }
        public ActionResult Approve()
        {
            string token = GetToken();
            List<AdjustmentModel> adjlist = new List<AdjustmentModel>();
            List<AdjustmentViewModel> advlist = new List<AdjustmentViewModel>();            
                    
           SupplierItemModel supp = new SupplierItemModel();            

            adjlist = APIAdjustment.GetAdjustmentByStatus(token, ConAdjustment.Active.PENDING, out string error);
            
            foreach(AdjustmentModel ad in adjlist)
            {
                AdjustmentViewModel adv = new AdjustmentViewModel();
                adv.Adjid = ad.Adjid;
                adv.Issueddate = ad.Issueddate;
                adv.Raisedbyname = ad.Raisedbyname;
                adv.RaisedTo = (int)ad.Raisedto;
                adv.RaisedTobyname = ad.Raisedtoname;
                adv.adjdvm = new List<AdjustmentDetailViewModel>();
                                
                foreach(AdjustmentDetailModel adjdm in ad.Adjds)
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
                        //API Supplier Error

                        supp = APISupplier.GetOneSupplierItemByItemId(adjdm.Itemid, token, out error);
                        advdetail.Price = supp.Price * Math.Abs(advdetail.Adjustedqty);
                    }catch (Exception e)
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