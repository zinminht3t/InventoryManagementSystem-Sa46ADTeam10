using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public class InventoryTransactionRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        private static InventoryTransactionModel ConvertDBModeltoAPIModel(inventorytransaction invt)
        {
            InventoryTransactionModel invtm = new InventoryTransactionModel(invt.tranid, invt.datetime, invt.invid, invt.itemid, invt.item.description, invt.item.uom, invt.item.category.name, invt.trantype, invt.qty, invt.remark);
            return invtm;
        }
        public static List<InventoryTransactionModel> GetAllInventoryTransactions(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<InventoryTransactionModel> invtms = new List<InventoryTransactionModel>();
            try
            {
                // get inventorytransaction list from database
                List<inventorytransaction> invts = entities.inventorytransactions.ToList<inventorytransaction>();

                // convert the DB Model list to API Model list
                foreach (inventorytransaction invt in invts)
                {
                    invtms.Add(ConvertDBModeltoAPIModel(invt));
                }
            }

            // if inventorytransaction not found, will throw NOTFOUND exception
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
            return invtms;
        }
        public static InventoryTransactionModel GetInventoryTransactionByTransID(int transid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            inventorytransaction invt = new inventorytransaction();
            InventoryTransactionModel invtm = new InventoryTransactionModel();
            try
            {
                invt = entities.inventorytransactions.Where(p => p.tranid == transid).FirstOrDefault<inventorytransaction>();
                invtm = ConvertDBModeltoAPIModel(invt);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invtm;
        }
        public static List<InventoryTransactionModel> GetInventoryTransactionsByInvID(int invid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<inventorytransaction> invts = new List<inventorytransaction>();
            List<InventoryTransactionModel> invtms = new List<InventoryTransactionModel>();
            try
            {
                invts = entities.inventorytransactions.Where(p => p.invid == invid).ToList<inventorytransaction>();
                foreach(inventorytransaction invt in invts)
                {
                    invtms.Add(ConvertDBModeltoAPIModel(invt));
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invtms;
        }
        public static List<InventoryTransactionModel> GetInventoryTransactionsByItemID(int itemid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<inventorytransaction> invts = new List<inventorytransaction>();
            List<InventoryTransactionModel> invtms = new List<InventoryTransactionModel>();
            try
            {
                invts = entities.inventorytransactions.Where(p => p.itemid == itemid).ToList<inventorytransaction>();
                foreach (inventorytransaction invt in invts)
                {
                    invtms.Add(ConvertDBModeltoAPIModel(invt));
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invtms;
        }
        public static List<InventoryTransactionModel> GetInventoryTransactionsByTransType(int transtype, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<inventorytransaction> invts = new List<inventorytransaction>();
            List<InventoryTransactionModel> invtms = new List<InventoryTransactionModel>();
            try
            {
                invts = entities.inventorytransactions.Where(p => p.trantype == transtype).ToList<inventorytransaction>();
                foreach (inventorytransaction invt in invts)
                {
                    invtms.Add(ConvertDBModeltoAPIModel(invt));
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invtms;
        }
        public static List<InventoryTransactionModel> GetInventoryTransactionsByTransDate(DateTime date, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<inventorytransaction> invts = new List<inventorytransaction>();
            List<InventoryTransactionModel> invtms = new List<InventoryTransactionModel>();
            try
            {
                invts = entities.inventorytransactions.Where(p => p.datetime.Date == date.Date).ToList<inventorytransaction>();
                foreach (inventorytransaction invt in invts)
                {
                    invtms.Add(ConvertDBModeltoAPIModel(invt));
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invtms;
        }
        public static List<InventoryTransactionModel> GetInventoryTransactionsByTransDateRange(DateTime startdate, DateTime enddate, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<inventorytransaction> invts = new List<inventorytransaction>();
            List<InventoryTransactionModel> invtms = new List<InventoryTransactionModel>();
            try
            {
                invts = entities.inventorytransactions.Where(p => p.datetime.Date >= startdate.Date && p.datetime.Date <= enddate.Date).ToList<inventorytransaction>();
                foreach (inventorytransaction invt in invts)
                {
                    invtms.Add(ConvertDBModeltoAPIModel(invt));
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invtms;
        }
        public static InventoryTransactionModel UpdateInventoryTransaction(InventoryTransactionModel invtm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            inventorytransaction d = new inventorytransaction();
            try
            {
                // finding the inventorytransaction object using InventoryTransaction API model
                d = entities.inventorytransactions.Where(p => p.tranid == invtm.TranID).First<inventorytransaction>();

                // transfering data from API model to DB Model
                d.datetime = DateTime.Now;
                d.invid = invtm.InvID;
                d.itemid = invtm.ItemID;
                d.trantype = invtm.TransType;
                d.qty = invtm.Qty;
                d.remark = invtm.Remark;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                invtm = ConvertDBModeltoAPIModel(d);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invtm;
        }
        public static InventoryTransactionModel CreateInventoryTransaction(InventoryTransactionModel invtm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            inventorytransaction d = new inventorytransaction();
            try
            {
                d.datetime = DateTime.Now;
                d.invid = invtm.InvID;
                d.itemid = invtm.ItemID;
                d.trantype = invtm.TransType;
                d.qty = invtm.Qty;
                d.remark = invtm.Remark;
                d = entities.inventorytransactions.Add(d);
                entities.SaveChanges();
                invtm = ConvertDBModeltoAPIModel(d);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return invtm;
        }
    }
}