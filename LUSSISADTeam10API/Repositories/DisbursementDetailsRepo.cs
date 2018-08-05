using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Constants;

// Author : Khin Yadana Phyo | Aung Myo | Zin Min Htet
namespace LUSSISADTeam10API.Repositories
{
    public class DisbursementDetailsRepo
    {
        #region Author : Aung Myo
        private static DisbursementDetailsModel CovertDBDisbursementDetailsstoAPIDisbursementDetails(disbursementdetail disbm)
        {
            DisbursementDetailsModel dism = new DisbursementDetailsModel(disbm.disid, disbm.itemid, disbm.item.description, disbm.qty, disbm.item.category.name, disbm.item.uom);
            return dism;
        }
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
                    ConRequisition.Status.REQUESTPENDING).ToList();

                var groupedBy =
                    outreqdetails.GroupBy(x => x.item)
                    .Select(y => new
                    {
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
                            item.Quantity,
                            item.Item.category.shelflocation,
                            item.Item.category.shelflevel
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
        public static DisbursementDetailsModel CreateDisbursementDetails(DisbursementDetailsModel disdm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            disbursementdetail disdb = new disbursementdetail();
            DisbursementDetailsModel ddm = new DisbursementDetailsModel();
            try
            {
                disdb.disid = disdm.Disid;
                disdb.itemid = disdm.Itemid;
                disdb.qty = disdm.Qty;
                disdb = entities.disbursementdetails.Add(disdb);
                entities.SaveChanges();

                ddm = new DisbursementDetailsModel(disdb.disid, disdb.itemid, disdb.item.description, disdb.qty, disdb.item.category.name, disdb.item.uom);
            }

            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return ddm;
        }
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
            return GetDisbursementDetailsByDisbursementId(ndism.disid, out error);
        }
        #endregion

        #region Author : Zin Min Htet | Khin Yadana Phyo
        public static List<BreakdownByDepartmentModel> GetBreakdownByDepartment(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<BreakdownByDepartmentModel> ois = new List<BreakdownByDepartmentModel>();
            try
            {


                List<int> itemids = entities.disbursementdetails.Where(p => p.disbursement.requisition.status == ConRequisition.Status.REQUESTPENDING).Select(x => x.itemid).Distinct().ToList();

                foreach (int itemid in itemids)
                {

                    var data = entities.disbursementdetails.Where(p => p.itemid == itemid
                    && p.disbursement.requisition.status == ConRequisition.Status.REQUESTPENDING)
                        .GroupBy(x => x.disbursement.requisition.department)
                        .Select(y => new
                        {
                            Department = y.Key,
                            Quantity = y.Sum(x => x.qty)
                        });

                    int totalqty = entities.disbursementdetails.Where(p => p.itemid == itemid
                    && p.disbursement.requisition.status == ConRequisition.Status.REQUESTPENDING)
                    .Sum(x => x.qty);

                    List<BreakDown> bds = new List<BreakDown>();

                    foreach (var item in data)
                    {
                        BreakDown bd = new BreakDown();
                        bd.DeptID = item.Department.deptid;
                        bd.DeptName = item.Department.deptname;
                        bd.Qty = item.Quantity;
                        bds.Add(bd);
                    }

                    BreakdownByDepartmentModel bddm = new BreakdownByDepartmentModel();
                    bddm.TotalQty = totalqty;
                    bddm.ItemID = itemid;
                    bddm.ItemDescription = ItemRepo.GetItemByItemid(itemid, out error).Description;
                    bddm.BDList = bds;
                    ois.Add(bddm);
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
        #endregion

    }


}
