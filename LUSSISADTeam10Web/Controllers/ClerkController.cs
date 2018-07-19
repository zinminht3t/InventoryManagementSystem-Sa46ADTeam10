using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
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

        // END TAZ

        // Start Mahsu
        public ActionResult Inventory()
        {
            string token = GetToken();
            UserModel user = GetUser();
           
            List<InventoryModel> ivm = new List<InventoryModel>();
            List<InventoryDetailModel> inventory = new List<InventoryDetailModel>();
            try
            {
                ivm = APIInventory.GetAllInventories(token, out string error);
                //foreach (InventoryModel invent in ivm)
                //{
                //    foreach(InventoryDetailModel ivdm in inventory)
                //    {
                       
                //    }
                //}
            }
            catch (Exception e)
            {

            }
            return View(ivm);
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