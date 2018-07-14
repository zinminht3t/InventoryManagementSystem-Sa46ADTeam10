using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public class InventoryRepo
    {

        // entites used only by Get Methods
        private static LUSSISEntities entities = new LUSSISEntities();
        // Convert From Auto Generated DB Model to APIModel
        private static InventoryModel CovertDBInventorytoAPIInventory(inventory inv)
        {
            InventoryModel invm = new InventoryModel(inv.invid, inv.itemid, inv.item.description, inv.stock, inv.reorderlevel, inv.reorderqty);
            return invm;
        }
        // Get the list of all invs and will return with error if there is one.
        public static List<InventoryModel> GetAllInventories(out string error)
        {
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<InventoryModel> invms = new List<InventoryModel>();
            try
            {
                // get inventory list from database
                List<inventory> invs = entities.inventories.ToList<inventory>();

                // convert the DB Model list to API Model list
                foreach (inventory inv in invs)
                {
                    invms.Add(CovertDBInventorytoAPIInventory(inv));
                }
            }

            // if inventory not found, will throw NOTFOUND exception
            catch (NullReferenceException)
            {
                // if there is NULL Exception error, error will be 404
                error = ConError.Status.NOTFOUND;
            }

            catch (Exception e)
            {
                // for other exceptions
                error = e.Message;
            }

            //returning the list
            return invms;
        }
        public static InventoryModel GetInventoryByInventoryid(int inventoryid, out string error)
        {
            error = "";

            inventory inventory = new inventory();
            InventoryModel invm = new InventoryModel();
            try
            {
                inventory = entities.inventories.Where(p => p.invid == inventoryid).FirstOrDefault<inventory>();
                invm = CovertDBInventorytoAPIInventory(inventory);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invm;
        }
        public static InventoryModel GetInventoryByItemid(int itemid, out string error)
        {
            error = "";

            inventory inventory = new inventory();
            InventoryModel invm = new InventoryModel();
            try
            {
                inventory = entities.inventories.Where(p => p.itemid == itemid).FirstOrDefault<inventory>();
                invm = CovertDBInventorytoAPIInventory(inventory);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invm;
        }
        public static InventoryModel UpdateInventory(InventoryModel invm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            inventory inv = new inventory();
            try
            {
                // finding the inventory object using Inventory API model
                inv = entities.inventories.Where(p => p.invid == invm.Invid).First<inventory>();

                // transfering data from API model to DB Model
                inv.itemid = invm.Itemid;
                inv.stock = invm.Stock;
                inv.reorderlevel = invm.ReorderLevel;
                inv.reorderqty = invm.ReorderQty;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                invm = CovertDBInventorytoAPIInventory(inv);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invm;
        }
        public static InventoryModel CreateInventory(InventoryModel invm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            inventory inv = new inventory();
            try
            {
                inv.itemid = invm.Itemid;
                inv.stock = invm.Stock;
                inv.reorderlevel = invm.ReorderLevel;
                inv.reorderqty = invm.ReorderQty;
                inv = entities.inventories.Add(inv);
                entities.SaveChanges();
                // retrieving the inserted inventory model by using the GetInventory method
                invm = GetInventoryByInventoryid(inv.invid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invm;
        }
        public static Boolean RemoveInventory(InventoryModel invm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            inventory inv = new inventory();
            try
            {
                if (entities.inventories.Where(p => p.itemid == invm.Itemid).Count() > 0)
                {
                    inv = entities.inventories.Where(p => p.invid == invm.Itemid).First<inventory>();
                    entities.inventories.Remove(inv);
                    entities.SaveChanges();
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
                return false;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            return true;
        }
    }
}