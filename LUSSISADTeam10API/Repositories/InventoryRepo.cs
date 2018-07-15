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
        // Convert From Auto Generated DB Model to APIModel
        private static InventoryModel CovertDBInventorytoAPIInventory(inventory inv)
        {
            InventoryModel invm = new InventoryModel(inv.invid, inv.itemid, inv.item.description, inv.stock, inv.reorderlevel, inv.reorderqty);
            return invm;
        }
        // Convert From Auto Generated DB Model to APIModel for InventoryDetail
        private static InventoryDetailModel CovertDBInventorytoAPIInventoryDet(inventory inv)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // to show the recommended order qty 
            int? recommededorderqty = 0;

            // if the stock is less than or equal reorder level
            if (inv.stock <= inv.reorderlevel)
            {
                // the recommended order qty will be the minimum reorder level and reorder qty
                recommededorderqty = (inv.reorderlevel - inv.stock) + inv.reorderqty;
            }
            InventoryDetailModel invdm = new InventoryDetailModel(inv.invid, inv.itemid, inv.item.description, inv.stock, inv.reorderlevel, inv.reorderqty, inv.item.catid, inv.item.category.name, inv.item.description, inv.item.uom, recommededorderqty);
            return invdm;
        }
        // Get the list of all invs and will return with error if there is one.
        public static List<InventoryModel> GetAllInventories(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

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
            LUSSISEntities entities = new LUSSISEntities();

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
            LUSSISEntities entities = new LUSSISEntities();

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
        public static List<InventoryDetailModel> GetAllInventoryDetails(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<InventoryDetailModel> invdms = new List<InventoryDetailModel>();
            try
            {
                // get inventory list from database
                List<inventory> invs = entities.inventories.ToList<inventory>();

                // convert the DB Model list to API Model list for inv detail
                foreach (inventory inv in invs)
                {
                    invdms.Add(CovertDBInventorytoAPIInventoryDet(inv));
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
            return invdms;
        }
        public static InventoryDetailModel GetInventoryDetailByInventoryid(int inventoryid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            inventory inventory = new inventory();
            InventoryDetailModel invdm = new InventoryDetailModel();
            try
            {
                inventory = entities.inventories.Where(p => p.invid == inventoryid).FirstOrDefault<inventory>();
                invdm = CovertDBInventorytoAPIInventoryDet(inventory);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invdm;
        }
        public static InventoryDetailModel GetInventoryDetailByItemid(int itemid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            inventory inventory = new inventory();
            InventoryDetailModel invdm = new InventoryDetailModel();
            try
            {
                inventory = entities.inventories.Where(p => p.itemid == itemid).FirstOrDefault<inventory>();
                invdm = CovertDBInventorytoAPIInventoryDet(inventory);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invdm;
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