using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Constants;

// Author : Aung Myo | Khin Yadana Phyo | Zin Min Htet
namespace LUSSISADTeam10API.Repositories
{
    public class RequisitionDetailsRepo
    {
        // Convert From Auto Generated DB Model to APIModel for Requisitiondetail
        private static RequisitionDetailsModel CovertDBRequisitionDetailstoAPIRequisitionDetails(requisitiondetail reqd)
        {
            RequisitionDetailsModel reqdm;
            try
            {
                reqdm = new RequisitionDetailsModel(reqd.reqid, reqd.itemid, reqd.item.description, reqd.qty, reqd.item.category.name, reqd.item.uom, reqd.item.inventories.First().stock);
            }
            catch (Exception)
            {
                reqdm = new RequisitionDetailsModel(reqd.reqid, reqd.itemid, reqd.item.description, reqd.qty, reqd.item.category.name, reqd.item.uom, 0);
            }
            return reqdm;
        }

        // Get the list of all requisition Details
        public static List<RequisitionDetailsModel> GetAllRequisitionDetails(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionDetailsModel> reqdm = new List<RequisitionDetailsModel>();
            try
            {
                // get inventory list from database
                List<requisitiondetail> reqs = entities.requisitiondetails.ToList<requisitiondetail>();

                // convert the DB Model list to API Model list
                foreach (requisitiondetail req in reqs)
                {
                    reqdm.Add(CovertDBRequisitionDetailstoAPIRequisitionDetails(req));
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
            return reqdm;
        }
        // to get the RequisitionDetails by the RequisitionId
        public static List<RequisitionDetailsModel> GetRequisitionDetailsByRequisitionId(int reqid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionDetailsModel> reqm = new List<RequisitionDetailsModel>();
            try
            {
                // get requisition list from database
                List<requisitiondetail> reqds = entities.requisitiondetails.Where(p => p.reqid == reqid).ToList<requisitiondetail>();

                // convert the DB Model list to API Model list
                foreach (requisitiondetail reqd in reqds)
                {
                    reqm.Add(CovertDBRequisitionDetailstoAPIRequisitionDetails(reqd));
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
            return reqm;
        }

        // to get the RequisitionDetails by the ItemId
        public static List<RequisitionDetailsModel> GetRequisitionDetailsByItemId(int itemid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionDetailsModel> reqm = new List<RequisitionDetailsModel>();
            try
            {
                // get requisition list from database
                List<requisitiondetail> reqds = entities.requisitiondetails.Where(p => p.itemid == itemid).ToList<requisitiondetail>();

                // convert the DB Model list to API Model list
                foreach (requisitiondetail reqd in reqds)
                {
                    reqm.Add(CovertDBRequisitionDetailstoAPIRequisitionDetails(reqd));
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
            return reqm;
        }

        // create Requistion Details
        public static List<RequisitionDetailsModel> CreateRequisitionDetails(RequisitionDetailsModel reqd, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            requisitiondetail reqdn = new requisitiondetail();
            try
            {
                reqdn.reqid = reqd.Reqid;
                reqdn.itemid = reqd.Itemid;
                reqdn.qty = reqd.Qty;

                reqdn = entities.requisitiondetails.Add(reqdn);
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
            return GetRequisitionDetailsByRequisitionId(reqdn.reqid, out error);
        }
        // update the Requisition Details
        public static RequisitionDetailsModel UpdateRequisitionDetail(RequisitionDetailsModel reqdm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            requisitiondetail reqd = new requisitiondetail();
            try
            {
                // finding the inventory object using Inventory API model
                reqd = entities.requisitiondetails.Where(p => p.reqid == reqdm.Reqid && p.itemid == reqdm.Itemid).FirstOrDefault<requisitiondetail>();

                // transfering data from API model to DB Model
                reqd.reqid = reqdm.Reqid;
                reqd.itemid = reqdm.Itemid;
                reqd.qty = reqdm.Qty;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                reqdm = CovertDBRequisitionDetailstoAPIRequisitionDetails(reqd);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return reqdm;
        }

        public static List<OrderHistoryModel> GerOrderHistory(int deptid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            // List<RequisitionDetailsModel> ordh = new List<RequisitionDetailsModel>();
            List<OrderHistoryModel> orhm = new List<OrderHistoryModel>();
            try
            {


                //List<requisitiondetail> reqdetail = entities.requisitiondetails.Where(p => p.requisition.deptid == deptid).ToList();
                List<requisitiondetail> reqdetail = entities.requisitiondetails.Where(p => p.requisition.status == ConRequisition.Status.COMPLETED && p.requisition.deptid == deptid).Distinct().ToList();


                foreach (var order in reqdetail)
                {
                    OrderHistoryModel o = new OrderHistoryModel();



                    o.Reqdate = order.requisition.reqdate;
                    o.Deptid = order.requisition.deptid;
                    o.Cpname = order.requisition.collectionpoint.cpname;
                    o.Raisename = order.requisition.user.username;
                    o.Deptname = order.requisition.department.deptname;


                    if (order.requisition.status == ConRequisition.Status.COMPLETED)
                    {
                        o.Status = "Completed Order";
                    }

                    orhm.Add(o);

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

            return orhm;

        }






    }
}


