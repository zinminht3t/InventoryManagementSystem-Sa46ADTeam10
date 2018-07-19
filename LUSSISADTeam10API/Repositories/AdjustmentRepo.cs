using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models;

namespace LUSSISADTeam10API.Repositories
{
    public class AdjustmentRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        private static AdjustmentModel ConvertDBtoAPIAdjust(adjustment adj)
        {
            List<AdjustmentDetailModel> adjdm = new List<AdjustmentDetailModel>();            
            foreach(adjustmentdetail adjd in adj.adjustmentdetails) { 
             adjdm.Add(new AdjustmentDetailModel(adjd.adjid, adjd.itemid, adjd.item.description, adjd.adjustedqty, adjd.reason));
            }
            AdjustmentModel adjm = new AdjustmentModel(adj.adjid, adj.raisedby, adj.user.fullname, adj.raisedto, adj.user1.fullname, adj.issueddate,adj.status, adjdm);
            return adjm;
        }
        //Get all adjustment list
        public static List<AdjustmentModel> GetAllAdjustments(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<AdjustmentModel> adjm = new List<AdjustmentModel>();
            try
            {
                // get adjustment list from database
                List<adjustment> adjs = entities.adjustments.ToList<adjustment>();

                // convert the DB Model list to API Model list
                foreach (adjustment adj in adjs)
                {
                    adjm.Add(ConvertDBtoAPIAdjust(adj));
                }
            }

            // if department not found, will throw NOTFOUND exception
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
            return adjm;
        }
        //find Adjusment by id
        public static AdjustmentModel GetAdjustmentByID(int adjid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            adjustment adj = new adjustment();
            AdjustmentModel adjm = new AdjustmentModel();
            try
            {
                adj = entities.adjustments.Where(a => a.adjid == adjid).FirstOrDefault<adjustment>();
                adjm = ConvertDBtoAPIAdjust(adj);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return adjm;
        }       
        //get adjustment greaterprice
        //public static List<AdjustmentModel> GetAdjustmentGreaterPrice(double price, out string error)
        //{
        //    LUSSISEntities entities = new LUSSISEntities();
        //    error = "";
        //    List<AdjustmentModel> greater = new List<AdjustmentModel>();
        //    try
        //    {                
        //        List<AdjustmentModel> alladj = GetAllAdjustments(out error);

        //        foreach (AdjustmentModel adj in alladj)
        //        {
        //            List<AdjustmentDetailModel> adjds = AdjustmentDetailRepo.GetAdjustmentDetailByAdjID(adj.adjid,out error);
        //            foreach(AdjustmentDetailModel adjd in adjds)
        //            {
        //                SupplierItemModel supp = SupplierItemRepo.
        //                double price = supplieritem.
        //                supplieritem.itemid
        //                    adjd.itemid
        //            }
        //        }
        //    }
        //    catch (NullReferenceException)
        //    {
        //        error = ConError.Status.NOTFOUND;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }
        //    return greater;           
        //}
        //find Adjustment by raisedby id
        public static List<AdjustmentModel> GetAdjustmentByRaisedById(int raisedby, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            List<adjustment> adj = new List<adjustment>();
            List<AdjustmentModel> adjm = new List<AdjustmentModel>();
            try
            {
                adj = entities.adjustments.Where(a => a.raisedby == raisedby).ToList<adjustment>();
                foreach(adjustment ad in adj)
                {
                    adjm.Add(ConvertDBtoAPIAdjust(ad));
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
            return adjm;
        }
        //find Adjustment by raisedto id
        public static List<AdjustmentModel> GetAdjustmentByRaisedToId(int raisedto, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            List<adjustment> adj = new List<adjustment>();
            List<AdjustmentModel> adjm = new List<AdjustmentModel>();
            try
            {
                adj = entities.adjustments.Where(a => a.raisedto == raisedto).ToList<adjustment>();
                foreach (adjustment ad in adj)
                {
                    adjm.Add(ConvertDBtoAPIAdjust(ad));
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
            return adjm;
        }
        //find Adjustment by issued date
        public static List<AdjustmentModel> GetAdjustmentByIssuedDate(DateTime date, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            List<adjustment> adj = new List<adjustment>();
            List<AdjustmentModel> adjm = new List<AdjustmentModel>();
            try
            {
                adj = entities.adjustments.Where(a => a.issueddate == date).ToList<adjustment>();
                foreach (adjustment ad in adj)
                {
                    adjm.Add(ConvertDBtoAPIAdjust(ad));
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
            return adjm;
        }
        //find Adjustment by status
        public static List<AdjustmentModel> GetAdjustmentByStatus(int status,out string error)
        {

            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            List<adjustment> adj = new List<adjustment>();
            List<AdjustmentModel> adjm = new List<AdjustmentModel>();
            try
            {
                adj = entities.adjustments.Where(a => a.status == status).ToList<adjustment>();
                foreach (adjustment ad in adj)
                {
                    adjm.Add(ConvertDBtoAPIAdjust(ad));
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
            return adjm;
        }
        //Create new Adjustment
        public static AdjustmentModel CreateAdjustment(AdjustmentModel adjm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            adjustment adj = new adjustment();
            try
            {
                adj.raisedby = adjm.Raisedby;               
                adj.issueddate = adjm.Issueddate;
                adj.status = ConAdjustment.Active.PENDING;
                List<AdjustmentDetailModel> adjds = adjm.Adjds;
               
                //check item price
                foreach (AdjustmentDetailModel adjd in adjds)
                {
                    SupplierItemModel supp = SupplierItemRepo.GetSupplierItemByItemId(adjd.Itemid, out error);
                    double? price = Math.Abs((Int32)adjd.Adjustedqty) * supp.Price;
                    if (price >= (double?)250)
                    {
                        user user = entities.users.Where(u => u.role == ConUser.Role.MANAGER).First();
                        adj.raisedto = user.userid;
                        break;
                    }
                    else
                    {
                        user user = entities.users.Where(u => u.role==ConUser.Role.SUPERVISOR).First();
                        adj.raisedto = user.userid;
                    }                      
                }
                adj = entities.adjustments.Add(adj);                
                entities.SaveChanges();
                                
                foreach (AdjustmentDetailModel adjdm in adjds)
                {
                    adjustmentdetail adjd = new adjustmentdetail
                    {
                        adjid = adj.adjid,
                        itemid = adjdm.Itemid,
                        adjustedqty = adjdm.Adjustedqty,
                        reason = adjdm.Reason
                    };
                    adjd = entities.adjustmentdetails.Add(adjd);
                    entities.SaveChanges();  
                }

                adjm = GetAdjustmentByID(adj.adjid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return adjm;
        }
        //Update Adjustment
        public static AdjustmentModel UpdateAdjustment(AdjustmentModel adjm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            adjustment adj = new adjustment();
             try
            {
                adj = entities.adjustments.Where(a => a.adjid == adjm.Adjid).First<adjustment>();
                adj.raisedby = adjm.Raisedby;
                adj.raisedto = adjm.Raisedto;
                adj.issueddate = adjm.Issueddate;
                adj.status = adjm.Status;
                if (adj.status == ConAdjustment.Active.APPROVED)
                {
                    List<AdjustmentDetailModel> adjustds = AdjustmentDetailRepo.GetAdjustmentDetailByAdjID(adj.adjid, out error);
                    foreach(AdjustmentDetailModel adjustd in adjustds)
                    {
                        InventoryModel inventm = InventoryRepo.GetInventoryByItemid(adjustd.Itemid, out error);
                        inventory invent = entities.inventories.Where(i => i.invid == inventm.Invid).First<inventory>();
                        invent.stock += adjustd.Adjustedqty;

                        InventoryTransactionModel invtm = new InventoryTransactionModel();

                        invtm.InvID = invent.invid;
                        invtm.ItemID = invent.itemid;
                        invtm.Qty = adjustd.Adjustedqty;
                        invtm.TransType = ConInventoryTransaction.TransType.ADJUSTMENT;
                        invtm.TransDate = DateTime.Now;
                        invtm.Remark = adjustd.Reason;

                        invtm = InventoryTransactionRepo.CreateInventoryTransaction(invtm, out error);
                    }    
                    


                }
                
                entities.SaveChanges();
                adjm = ConvertDBtoAPIAdjust(adj);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return adjm;
        }
    }
}