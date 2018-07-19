using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LUSSISADTeam10Web.Models.Clerk;

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
                    InventoryCheckViewModel ivc = new InventoryCheckViewModel(invent.Invid, cat.name, invent.ItemDescription, invent.Stock, item.Uom);
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