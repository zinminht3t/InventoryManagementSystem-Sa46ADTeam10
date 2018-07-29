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
        public ActionResult Index()
        {
            string token = GetToken();
            UserModel um = GetUser();
            string error = "";
            List<FrequentlyTop5ItemsModel> reportData = new List<FrequentlyTop5ItemsModel>();

            List<AdjustmentModel> adjs = new List<AdjustmentModel>();

            List<SupplierModel> sups = new List<SupplierModel>();

            List<PurchaseOrderModel> pos = new List<PurchaseOrderModel>();

            List<InventoryDetailModel> invs = new List<InventoryDetailModel>();


            try
            {
                reportData = APIReport.FrequentlyItemList(token, out error);

                adjs = APIAdjustment.GetAdjustmentByStatus(token, ConAdjustment.Active.PENDING, out error);
                if(adjs == null)
                {
                    ViewBag.AdjCount = 0;
                }
                else
                {
                    ViewBag.AdjCount = adjs.Where(x => x.Raisedto == um.Userid).Count();
                }

                sups = APISupplier.GetSupplierByStatus(ConSupplier.Active.ACTIVE, token, out error);
                if (sups == null)
                {
                    ViewBag.SupCount = 0;
                }
                else
                {
                    ViewBag.SupCount = sups.Count;
                }

                pos = APIPurchaseOrder.GetPurchaseOrderByStatus(ConPurchaseOrder.Status.PENDING, token, out error);
                if (pos == null)
                {
                    ViewBag.POCount = 0;
                }
                else
                {
                    ViewBag.POCount = pos.Count;
                }

                invs = APIInventory.GetAllInventoryDetails(token, out error);
                if (invs == null)
                {
                    ViewBag.RestockCount = 0;
                }
                else
                {
                    ViewBag.RestockCount = invs.Where(x => x.RecommendedOrderQty > 0).Count();
                }

                return View("Index", reportData);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }
        }
        public List<AdjustmentViewModel> getViewModel(List<AdjustmentModel> adjlist)
        {
            string token = GetToken();
            List<AdjustmentViewModel> advlist = new List<AdjustmentViewModel>();
            SupplierItemModel supp = new SupplierItemModel();

            try
            {
                foreach (AdjustmentModel ad in adjlist)
                {
                    AdjustmentViewModel adv = new AdjustmentViewModel();
                    UserModel user = new UserModel();

                    user = APIUser.GetUserByUserID((int)ad.Raisedto, token, out string error);
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
                            adv.TotalPrice += (double)advdetail.Price;
                        }
                        catch (Exception e)
                        {
                            if (supp == null) advdetail.Price = 0.0;
                        }
                        adv.adjdvm.Add(advdetail);
                    }
                    advlist.Add(adv);
                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return advlist;
        }
        public ActionResult Approve()
        {
            string token = GetToken();
            List<AdjustmentModel> adjlist = new List<AdjustmentModel>();

            try
            {
                adjlist = APIAdjustment.GetAdjustmentByStatus(token, ConAdjustment.Active.PENDING, out string error);
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            ViewBag.manager = ConUser.Role.MANAGER;
            return View(getViewModel(adjlist));
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

            try
            {
                adjlist = APIAdjustment.GetAdjustmentByStatus(token, ConAdjustment.Active.APPROVED, out string error);
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return View(getViewModel(adjlist));
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