using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using LUSSISADTeam10Web.Models.Clerk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LUSSISADTeam10Web.Controllers
{
    [Authorize(Roles = "Clerk")]
    public class ClerkController : Controller
    {
        // GET: Clerk
        public ActionResult Index()
        {
            return View("ClerkDashboard");
        }

        // Start AM

        // End AM

        // Start TAZ
        public ActionResult ApproveCollectionPoint(int id)
        {
            string token = GetToken();
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel();
            ViewBag.DepartmentCollectionPointModel = dcpm;
            ApproveCollectionPointViewModel viewmodel = new ApproveCollectionPointViewModel();
            List<DepartmentCollectionPointModel> st = new List<DepartmentCollectionPointModel>();
          
           
            try
            {
                dcpm = APICollectionPoint.GetDepartmentCollectionPointByDcpid(token, id ,out string error);
                st = APICollectionPoint.GetDepartmentCollectionPointByStatus(token, 1, out error);
                ViewBag.DepartmentCollectionModel = dcpm;
                ViewBag.DepartmentCollectionModel = st;
                viewmodel.CpID =dcpm.DeptCpID;
                viewmodel.DepName = dcpm.DeptName;
                viewmodel.CpName = dcpm.CpName;
                foreach (DepartmentCollectionPointModel p in st) {
                    viewmodel.OldCpName = p.CpName;
                }
                
                


            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult ApproveCollectionPoint(ApproveCollectionPointViewModel viewmodel)
        {
            string token = GetToken();
            UserModel um = GetUser();
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel();
           

            dcpm = APICollectionPoint.GetDepartmentCollectionPointByDcpid(token, viewmodel.CpID, out string error);

            try
            {
                
                if (!viewmodel.Approve)
                {
                    dcpm = APICollectionPoint.RejectDepartmentCollectionPoint(token, dcpm, out error);

                }

                else if (viewmodel.Approve)
                {
                    dcpm = APICollectionPoint.ConfirmDepartmentCollectionPoint(token, dcpm, out error);

                }
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { error = ex.Message });
            }

        }
        // END TAZ

        // Start Mahsu
        public ActionResult Inventory()
        {
            string token = GetToken();
            UserModel user = GetUser();
           
            List<InventoryModel> ivmlist = new List<InventoryModel>();
            List<InventoryCheckViewModel> ivclist = new List<InventoryCheckViewModel>();
            try
            {
                ivmlist = APIInventory.GetAllInventories(token, out string error);
                
                foreach (InventoryModel invent in ivmlist)
                { 
                    CategoryModel cat = APICategory.GetCategoryByItemID(token, invent.Itemid, out error);
                    ItemModel item = APIItem.GetItemByItemID(invent.Itemid,token,out error);
                    InventoryCheckViewModel ivc = new InventoryCheckViewModel(invent.Invid, cat.Name, invent.ItemDescription, invent.Stock, item.Uom);
                    ivclist.Add(ivc);
                }
            }
            catch (Exception e)
            {

            }
            return View(ivclist);
        }

        // End MaHus

        // Start ZMH

        // End ZMH

        // Start Phyo2

        public ActionResult GetOrderRecommndation()
        {
            string token = GetToken();
            UserModel um = GetUser();

            List<InventoryDetailModel> inendetail = new List<InventoryDetailModel>();

            try
            {
                inendetail = APIInventory.GetAllInventoryDetails(token, out string error);

                if (error != "")
                {
                    return RedirectToAction("Index", "Error", new { error });
                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }

            return View(inendetail);
        }


        public ActionResult StationaryRetrievalForm()
        {
            string token = GetToken();
            UserModel um = GetUser();

            List<OutstandingItemModel> inendetail = new List<OutstandingItemModel>();

            try
            {
                inendetail = APIDisbursement.GetRetriveItemListforClerk(token, out string error);

                if (error != "")
                {
                    return RedirectToAction("Index", "Error", new { error });
                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", "Error", new { error = ex.Message });
            }

            return View(inendetail);
        }


        // End Phyo2

        #region Utilities
        public string GetToken()
        {
            string token = "";
            token = (string)Session["token"];
            return token;
        }
        public UserModel GetUser()
        {
            UserModel um = new UserModel();
            um = (UserModel)Session["user"];
            return um;
        }
        #endregion
    }
}