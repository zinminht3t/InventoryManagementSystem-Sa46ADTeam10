using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public static class OutstandingReqRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        private static OutstandingReqModel ConvertDBOutReqToAPIOutReq(outstandingrequisition outreq)
        {
            List<OutstandingReqDetailModel> details =
                new List<OutstandingReqDetailModel>();
            foreach (outstandingrequisitiondetail ord in outreq.outstandingrequisitiondetails)
            {
                details.Add(OutstandingReqDetailRepo.ConvertDBOutReqDetailToAPIModel(ord));
            }
            OutstandingReqModel orm = new OutstandingReqModel(
                    outreq.outreqid,
                    outreq.reqid,
                    outreq.reason,
                    outreq.status
                );
            orm.OutReqDetails = details;
            return orm;
        }
        // Get the list of all suppliers and will return with error if there is one.
        public static List<OutstandingReqModel> GetAllOutstandingReq(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<OutstandingReqModel> orms = new List<OutstandingReqModel>();
            try
            {
                // get outstanding req list from database
                List<outstandingrequisition> outreqs =
                    entities.outstandingrequisitions.ToList();

                // convert the DB Model list to API Model list
                foreach (outstandingrequisition outreq in outreqs)
                {
                    orms.Add(ConvertDBOutReqToAPIOutReq(outreq));
                }
            }
            // if outstanding req not found, will throw NOTFOUND exception
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
            return orms;
        }
        // Get Outstanding Req Model by Id number
        public static OutstandingReqModel GetOutstandingReqById(int outreqid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            outstandingrequisition or = new outstandingrequisition();
            OutstandingReqModel orm = new OutstandingReqModel();
            try
            {
                or = entities.outstandingrequisitions
                    .Where(x => x.outreqid == outreqid)
                    .FirstOrDefault();
                orm = ConvertDBOutReqToAPIOutReq(or);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return orm;
        }
        // Get Outstanding Req Model by Id number
        public static bool CheckInventoryStock(int outreq, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            outstandingrequisition or = new outstandingrequisition();
            OutstandingReqModel orm = new OutstandingReqModel();
            List<inventory> invs = new List<inventory>();
            inventory inv = new inventory();
            bool result = false;

            try
            {

                or = entities.outstandingrequisitions.Where(x => x.outreqid == outreq).FirstOrDefault();
                invs = entities.inventories.ToList();
                foreach (outstandingrequisitiondetail ord in or.outstandingrequisitiondetails)
                {
                    inv = invs.Where(x => x.itemid == ord.itemid).FirstOrDefault();
                    if (ord.qty <= inv.stock)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                return result;
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return result;
        }
        //Get Outstanding Req Model by Req Id
        public static OutstandingReqModel GetOutstandingReqByReqId(int reqid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            OutstandingReqModel orm = new OutstandingReqModel();
            outstandingrequisition or = new outstandingrequisition();
            try
            {
                or = entities.outstandingrequisitions
                    .Where(x => x.reqid == reqid)
                    .FirstOrDefault();

                orm = GetOutstandingReqById(or.outreqid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return orm;
        }

        public static RequisitionWithOutstandingModel GetCompletedOutstaingReqByReqID(int reqid, out string error)
        {

            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            RequisitionWithOutstandingModel model = new RequisitionWithOutstandingModel();
            outstandingrequisition req = new outstandingrequisition();

            List<RequisitionDetailsWithOutstandingModel> reqdm = new List<RequisitionDetailsWithOutstandingModel>();

            try
            {
                req = entities.outstandingrequisitions.Where(x => x.reqid == reqid && x.status == ConOutstandingsRequisition.Status.COMPLETE).FirstOrDefault();

                foreach (outstandingrequisitiondetail rqdm in req.outstandingrequisitiondetails)
                {
                    reqdm.Add(new RequisitionDetailsWithOutstandingModel(req.reqid, rqdm.itemid, rqdm.item.description,
                        rqdm.qty, rqdm.item.category.name, rqdm.item.uom,
                        rqdm.qty));
                }
                model = new RequisitionWithOutstandingModel(req.reqid, req.requisition.raisedby, req.requisition.user.fullname
                                        , req.requisition.approvedby, req.requisition.user1.fullname, req.requisition.cpid, req.requisition.collectionpoint.cpname
                                         , req.requisition.deptid, req.requisition.department.deptname, req.status, req.requisition.reqdate, 0, 
                                         "", reqdm);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return model;
        }
        // To Update Outstanding Requisition
        public static OutstandingReqModel UpdateOutReq
            (OutstandingReqModel ordm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            OutstandingReqModel outreqm = new OutstandingReqModel();
            outstandingrequisition outreq = new outstandingrequisition();
            try
            {
                // finding the db object using API model
                outreq = entities.outstandingrequisitions
                    .Where(x => x.outreqid == ordm.OutReqId)
                    .FirstOrDefault();

                // transfering data from API model to DB Model
                outreq.reqid = ordm.ReqId;
                outreq.reason = ordm.Reason;
                var TempStatus = outreq.status;


                outreq.status = ordm.Status;

                // saving the update
                entities.SaveChanges();



                if (TempStatus != ordm.Status && ordm.Status == ConOutstandingsRequisition.Status.DELIVERED)
                {
                    foreach (outstandingrequisitiondetail outrd in outreq.outstandingrequisitiondetails)
                    {

                        InventoryModel invm = InventoryRepo.GetInventoryByItemid(outrd.itemid, out error);
                        invm.Stock -= outrd.qty;
                        invm = InventoryRepo.UpdateInventory(invm, out error);
                        InventoryTransactionModel invtm = new InventoryTransactionModel();
                        invtm.ItemID = outrd.itemid;
                        invtm.InvID = invm.Invid;
                        invtm.Qty = (outrd.qty) * -1;
                        invtm.TransDate = DateTime.Now;
                        invtm.Remark = "Fulfill Outstanding" + outrd.outreqid;
                        invtm.TransType = ConInventoryTransaction.TransType.OUTSTANDING;
                        invtm = InventoryTransactionRepo.CreateInventoryTransaction(invtm, out error);
                    }
                }


                // return the updated model 
                outreqm = ConvertDBOutReqToAPIOutReq(outreq);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return outreqm;
        }
        // To add new outstanding requisition
        public static OutstandingReqModel CreateOutReq
            (OutstandingReqModel ordm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            OutstandingReqModel outreqm = new OutstandingReqModel();
            outstandingrequisition outreq = new outstandingrequisition();
            try
            {
                // transfering data from API model to DB Model
                List<outstandingrequisitiondetail> details =
                    new List<outstandingrequisitiondetail>();
                foreach (OutstandingReqDetailModel ordModel in ordm.OutReqDetails)
                {
                    details.Add(OutstandingReqDetailRepo
                    .ConvertAPIOutReqDetailToDBModel(ordModel));
                }
                outreq.reqid = ordm.ReqId;
                outreq.reason = ordm.Reason;
                outreq.status = ConOutstandingsRequisition.Status.PENDING;
                outreq.outstandingrequisitiondetails = details;

                // adding into DB
                entities.outstandingrequisitions.Add(outreq);
                entities.SaveChanges();

                // return the model 
                outreqm = GetOutstandingReqById(outreq.outreqid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return outreqm;
        }
        // To change the status from pending to complete
        public static OutstandingReqModel Complete
            (OutstandingReqModel ordm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            OutstandingReqModel outreqm = new OutstandingReqModel();
            outstandingrequisition outreq = new outstandingrequisition();
            try
            {
                // finding the db object using API model
                outreq = entities.outstandingrequisitions
                    .Where(x => x.outreqid == ordm.OutReqId)
                    .FirstOrDefault();

                // update the status
                outreq.status = ConOutstandingsRequisition.Status.COMPLETE;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                outreqm = ConvertDBOutReqToAPIOutReq(outreq);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return outreqm;
        }
    }
}