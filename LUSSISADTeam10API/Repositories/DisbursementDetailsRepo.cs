using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Constants;
namespace LUSSISADTeam10API.Repositories
{
    public class DisbursementDetailsRepo
    {
        // Convert From Auto Generated DB Model to APIModel for Disbursement Details
        private static DisbursementDetailsModel CovertDBDisbursementDetailsstoAPIDisbursementDetails(disbursementdetail disbm)
        {
            DisbursementDetailsModel dism = new DisbursementDetailsModel(disbm.disid, disbm.itemid, disbm.item.description, disbm.qty, disbm.item.category.name, disbm.item.uom);
            return dism;
        }
        // Get the list of all Disbursement Details
        public static List<DisbursementDetailsModel> GetAllDisbursementDetails(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementDetailsModel> disbm = new List<DisbursementDetailsModel>();
            try
            {
                // get inventory list from database
                List<disbursementdetail> dism = entities.disbursementdetails.ToList<disbursementdetail>();

                // convert the DB Model list to API Model list
                foreach (disbursementdetail dis in dism)
                {
                    disbm.Add(CovertDBDisbursementDetailsstoAPIDisbursementDetails(dis));
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
            return disbm;
        }



        // to get the DisbursementDetails by the ItemId
        public static List<DisbursementDetailsModel> GetDisbursementDetailsByItemId(int itemid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementDetailsModel> dism = new List<DisbursementDetailsModel>();
            try
            {
                // get requisition list from database
                List<disbursementdetail> disbm = entities.disbursementdetails.Where(p => p.itemid == itemid).ToList<disbursementdetail>();

                // convert the DB Model list to API Model list
                foreach (disbursementdetail dis in disbm)
                {
                    dism.Add(CovertDBDisbursementDetailsstoAPIDisbursementDetails(dis));
                }
            }

            // if requisition not found, will throw NOTFOUND exception
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
            return dism;
        }

        // to get the DisbursementDetails by the DisbursementId
        public static List<DisbursementDetailsModel> GetDisbursementDetailsByDisbursementId(int disid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementDetailsModel> dism = new List<DisbursementDetailsModel>();
            try
            {
                // get requisition list from database
                List<disbursementdetail> disbm = entities.disbursementdetails.Where(p => p.disid == disid).ToList<disbursementdetail>();

                // convert the DB Model list to API Model list
                foreach (disbursementdetail dis in disbm)
                {
                    dism.Add(CovertDBDisbursementDetailsstoAPIDisbursementDetails(dis));
                }
            }

            // if requisition not found, will throw NOTFOUND exception
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
            return dism;
        }

        //create the disbursement details
        public static List< DisbursementDetailsModel> CreateDisbursementDetails(DisbursementDetailsModel disdm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            disbursementdetail disdb = new disbursementdetail();
           
            try
            {
                disdb.disid = disdm.Disid;
                disdb.itemid = disdm.Itemid;
                disdb.qty = disdm.Qty;
                disdb = entities.disbursementdetails.Add(disdb);
                entities.SaveChanges();
             
            }

            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return GetDisbursementDetailsByDisbursementId(disdb.disid, out error);
        }

        // update the disbursement Details
        public static List<DisbursementDetailsModel> UpdateDisbursementDetails(DisbursementDetailsModel dism, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            disbursementdetail ndism = new disbursementdetail();
            try
            {
                // finding the inventory object using Inventory API model
                ndism = entities.disbursementdetails.Where(p => p.disid == dism.Disid && p.itemid == dism.Itemid).First<disbursementdetail>();

                // transfering data from API model to DB Model
                ndism.disid = dism.Disid;
                ndism.itemid = dism.Itemid;
                ndism.qty = dism.Qty;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
              
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            // return the updated model 
            return GetDisbursementDetailsByDisbursementId(ndism.disid , out error);
        }

        // to get the list for the clerk to retrive items from inventory
        public static List<OutstandingItemModel> GetAllPreparingItems(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<OutstandingItemModel> ois = new List<OutstandingItemModel>();
            try
            {
                // get outstanding details list from database
               
                List<disbursementdetail> outreqdetails =
                    entities.disbursementdetails
                    .Where(x => x.disbursement.requisition.status ==
                    ConRequisition.Status.PREPARING).ToList();

                var groupedBy =
                    outreqdetails.GroupBy(x => x.item)
                    .Select(y => new {
                        Item = y.Key,
                        Quantity = y.Sum(x => x.qty)
                    });

                // convert the DB Model list to API Model list
                foreach (var item in groupedBy)
                {
                    ois.Add(new OutstandingItemModel(
                            item.Item.itemid,
                            item.Item.description,
                            item.Item.uom,
                            item.Item.catid,
                            item.Item.category.name,
                            item.Quantity
                        ));
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
            return ois;
        }
    }


}
