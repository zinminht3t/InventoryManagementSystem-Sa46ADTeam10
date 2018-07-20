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

         //Get All InventoryCheckViewModel
        public InventoryCheckViewModel GetInvtCheckVM()
        {
            string token = GetToken();
            UserModel user = GetUser();
            List<InventoryModel> ivmlist = new List<InventoryModel>();
            List<Inventory> ivclist = new List<Inventory>();

            InventoryCheckViewModel invcvm = new InventoryCheckViewModel();

            ivmlist = APIInventory.GetAllInventories(token, out string error);

            foreach (InventoryModel invent in ivmlist)
            {
                CategoryModel cat = APICategory.GetCategoryByItemID(token, invent.Itemid, out error);
                ItemModel item = APIItem.GetItemByItemID(invent.Itemid, token, out error);
                Inventory ivc = new Inventory(invent.Invid, cat.Name, invent.Itemid, invent.ItemDescription, invent.Stock, item.Uom, cat.Shelflocation, cat.Shelflevel);
                ivclist.Add(ivc);
            }

            invcvm.Invs = ivclist;
            invcvm.InvIDs = new List<int>();

            return invcvm;
        }
            //Display All Inventories
        public ActionResult Inventory()
        {
            string token = GetToken();
            UserModel user = GetUser();
            
            InventoryCheckViewModel invcvm = new InventoryCheckViewModel();
            try
            {
                invcvm = GetInvtCheckVM();              
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { error = e.Message });
            }
            return View(invcvm);
        }
       //Get All checked Inventories
        [HttpPost]
        public ActionResult Inventory(List<int> InvID)
            {
            InventoryCheckViewModel ivcvm = GetInvtCheckVM();
            List<Inventory> ivm = ivcvm.Invs;
            List < Inventory > dis = new List<Inventory>();
            foreach (Inventory iv in ivm)
            {
                foreach(int i in InvID)
                {
                    if (iv.InventoryId == i)
                        dis.Add(iv);
                }               
            }
            TempData["discrepancy"] = dis; 
            return RedirectToAction("Adjustment");
        }
        public ActionResult Adjustment()
        {
            List<Inventory> dis = TempData["discrepancy"] as List<Inventory>;           
            return View(dis);

            //to do View
        }


        // End MaHus

        // Start ZMH

        public ActionResult Requisition()
        {
            string token = GetToken();
            UserModel um = GetUser();
            string error = "";

            List<RequisitionModel> reqms = new List<RequisitionModel>();

            reqms = APIRequisition.GetRequisitionByStatus(ConRequisition.Status.PENDING, token, out error);

            ViewBag.Requisitions = reqms;

            return View();
        }

        public ActionResult RequisitionDetail(int id)
        {
            string token = GetToken();
            UserModel um = GetUser();
            string error = "";
            RequisitionModel reqm = new RequisitionModel();
            reqm = APIRequisition.GetRequisitionByReqid(id, token, out error);
            ViewBag.Requisition = reqm;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequisitionDetail(ProcessRequisitionViewModel viewmodel)
        {
            return View();
        }
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
            List<BreakdownByDepartmentModel> bkm = new List<BreakdownByDepartmentModel>();

            List<ShowBD> bkmd = new List<ShowBD>();
            try
            {
                inendetail = APIDisbursement.GetRetriveItemListforClerk(token, out string error);

                bkm = APIDisbursement.GetBreakDown(token, out string errors);

                foreach(BreakdownByDepartmentModel bd in bkm)
                {
                    ShowBD s = new ShowBD();

                    s.ItemID = bd.ItemID;
                    s.ItemDescription = bd.ItemDescription;
                    s.Qty = inendetail.Where(x => x.ItemId == bd.ItemID).FirstOrDefault().Total;
                    s.BDList = bd.BDList;

                    bkmd.Add(s);
                }
                
            }




            catch
            {

            }

            return View(bkmd);
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