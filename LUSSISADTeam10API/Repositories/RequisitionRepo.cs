using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Constants;

namespace LUSSISADTeam10API.Repositories
{
    public class RequisitionRepo

    {
        // Convert From Auto Generated DB Model to APIModel for Requsition with Requisition Details data
        private static RequisitionModel CovertDBRequisitiontoAPIRequisitionwithDetails(requisition req)
        {
            List<RequisitionDetailsModel> reqdm = new List<RequisitionDetailsModel>();
            foreach (requisitiondetail rqdm in req.requisitiondetails)
            {
                try
                {
                    reqdm.Add(new RequisitionDetailsModel(rqdm.reqid, rqdm.itemid, rqdm.item.description, rqdm.qty, rqdm.item.category.name, rqdm.item.uom, rqdm.item.inventories.First().stock));
                }
                catch (Exception)
                {
                    reqdm.Add(new RequisitionDetailsModel(rqdm.reqid, rqdm.itemid, rqdm.item.description, rqdm.qty, rqdm.item.category.name, rqdm.item.uom, 0));
                }
            }
            RequisitionModel reqm = new RequisitionModel(req.reqid, req.raisedby, req.user.fullname
                                    , req.approvedby, req.user1.fullname, req.cpid, req.collectionpoint.cpname
                                     , req.deptid, req.department.deptname, req.status, req.reqdate, reqdm);
            return reqm;
        }
        private static RequisitionWithDisbursementModel CovertDBRequisitionDistoAPIRequisitionDiswithDetails(requisition req)
        {
            List<RequisitionDetailsWithDisbursementModel> reqdm = new List<RequisitionDetailsWithDisbursementModel>();
            foreach (requisitiondetail rqdm in req.requisitiondetails)
            {
                try
                {
                    reqdm.Add(new RequisitionDetailsWithDisbursementModel(rqdm.reqid, rqdm.itemid, rqdm.item.description,
                        rqdm.qty, rqdm.item.category.name, rqdm.item.uom,
                        rqdm.requisition.disbursements.First().disbursementdetails.Where(x => x.itemid == rqdm.itemid).First().qty));
                }
                catch (Exception)
                {
                    reqdm.Add(new RequisitionDetailsWithDisbursementModel(rqdm.reqid, rqdm.itemid, rqdm.item.description, rqdm.qty, rqdm.item.category.name, rqdm.item.uom, 0));
                }
            }
            RequisitionWithDisbursementModel reqm = new RequisitionWithDisbursementModel();
            try
            {
                reqm = new RequisitionWithDisbursementModel(req.reqid, req.raisedby, req.user.fullname
                                        , req.approvedby, req.user1.fullname, req.cpid, req.collectionpoint.cpname
                                         , req.deptid, req.department.deptname, req.status, req.reqdate, req.disbursementlockers.First().lockerid, req.disbursementlockers.First().lockercollectionpoint.lockername, reqdm);
            }
            catch (Exception)
            {
                reqm = new RequisitionWithDisbursementModel(req.reqid, req.raisedby, req.user.fullname
                                                  , req.approvedby, req.user1.fullname, req.cpid, req.collectionpoint.cpname
                                                   , req.deptid, req.department.deptname, req.status, req.reqdate, 0, "", reqdm);

            }
            return reqm;
        }
        // Convert From Auto Generated DB Model to APIModel for Requisition
        private static RequisitionModel CovertDBRequisitiontoAPIRequisition(requisition req)
        {
            RequisitionModel reqm = new RequisitionModel(req.reqid, req.raisedby, req.user.fullname
                                    , req.approvedby, req.user1.fullname, req.cpid, req.collectionpoint.cpname
                                     , req.deptid, req.department.deptname, req.status, req.reqdate, new List<RequisitionDetailsModel>());
            return reqm;
        }

        // Get the list of all requisition 
        public static List<RequisitionModel> GetAllRequisition(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionModel> reqm = new List<RequisitionModel>();
            try
            {
                // get inventory list from database
                List<requisition> reqs = entities.requisitions.ToList<requisition>();

                // convert the DB Model list to API Model list
                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitiontoAPIRequisition(req));
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
            return reqm;
        }

        // Get the list of all requisition  with Details
        public static List<RequisitionModel> GetAllRequisitionwithDetails(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionModel> reqm = new List<RequisitionModel>();
            try
            {
                // get inventory list from database
                List<requisition> reqs = entities.requisitions.ToList<requisition>();

                // convert the DB Model list to API Model list
                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitiontoAPIRequisitionwithDetails(req));
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
            return reqm;
        }

        // Get the list of all requisition  with Details
        public static List<RequisitionWithDisbursementModel> GetRequisitionsWithPreparingStatus(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionWithDisbursementModel> reqm = new List<RequisitionWithDisbursementModel>();
            List<requisition> reqs = new List<requisition>();
            try
            {
                reqs = entities.requisitions.Where(p => p.status == ConRequisition.Status.PREPARING).ToList();

                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitionDistoAPIRequisitionDiswithDetails(req));
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
            return reqm;
        }

        // Get the list of all requisition  with Details
        public static List<RequisitionWithDisbursementModel> GetRequisitionsWithDeliveredStatus(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionWithDisbursementModel> reqm = new List<RequisitionWithDisbursementModel>();
            List<requisition> reqs = new List<requisition>();
            try
            {
                reqs = entities.requisitions.Where(p => p.status == ConRequisition.Status.DELIVERED).ToList();

                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitionDistoAPIRequisitionDiswithDetails(req));
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
            return reqm;
        }

        public static RequisitionWithDisbursementModel GetRequisitionWithDisbursementByReqID(int reqid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            RequisitionWithDisbursementModel reqm = new RequisitionWithDisbursementModel();
            requisition reqs = new requisition();
            try
            {
                reqs = entities.requisitions.Where(p => p.reqid == reqid).FirstOrDefault();
                reqm = CovertDBRequisitionDistoAPIRequisitionDiswithDetails(reqs);
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
            return reqm;
        }
        // to get the Requisition by the RequisitionId
        public static RequisitionModel GetRequisitionByRequisitionId(int reqid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            error = "";

            requisition requisition = new requisition();
            RequisitionModel reqm = new RequisitionModel();
            try
            {
                requisition = entities.requisitions.Where(p => p.reqid == reqid).FirstOrDefault<requisition>();
                reqm = CovertDBRequisitiontoAPIRequisitionwithDetails(requisition);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return reqm;
        }

        // to get the Requisition by the Rasisedbyid
        public static List<RequisitionModel> GetRequisitionByRaisedbyid(int raisedid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionModel> reqm = new List<RequisitionModel>();
            try
            {
                // get requisition list from database
                List<requisition> reqs = entities.requisitions.Where(p => p.raisedby == raisedid).ToList<requisition>();

                // convert the DB Model list to API Model list
                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitiontoAPIRequisitionwithDetails(req));
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
        // to get the Requisition by the Approvedbyid
        public static List<RequisitionModel> GetRequisitionByApprovedbyid(int approvedbyid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();


            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionModel> reqm = new List<RequisitionModel>();
            try
            {
                // get requisition list from database
                List<requisition> reqs = entities.requisitions.Where(p => p.approvedby == approvedbyid).ToList<requisition>();

                // convert the DB Model list to API Model list
                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitiontoAPIRequisitionwithDetails(req));
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

        // to get the Requisition by the Depid
        public static List<RequisitionModel> GetRequisitionByDepid(int depid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();



            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionModel> reqm = new List<RequisitionModel>();
            try
            {
                // get requisition list from database
                List<requisition> reqs = entities.requisitions.Where(p => p.deptid == depid).ToList<requisition>();

                // convert the DB Model list to API Model list
                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitiontoAPIRequisitionwithDetails(req));
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
        // to get the Requisition by the Status
        public static List<RequisitionModel> GetRequisitionByStatus(int status, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionModel> reqm = new List<RequisitionModel>();
            try
            {
                // get requisition list from database
                List<requisition> reqs = entities.requisitions.Where(p => p.status == status).ToList<requisition>();

                // convert the DB Model list to API Model list
                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitiontoAPIRequisitionwithDetails(req));
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
        // to get the Requisition by the ReqDate
        public static List<RequisitionModel> GetRequisitionByReqDate(DateTime reqdate, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequisitionModel> reqm = new List<RequisitionModel>();
            try
            {
                // get requisition list from database
                List<requisition> reqs = entities.requisitions.Where(p => p.reqdate == reqdate).ToList<requisition>();

                // convert the DB Model list to API Model list
                foreach (requisition req in reqs)
                {
                    reqm.Add(CovertDBRequisitiontoAPIRequisitionwithDetails(req));
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
        //create the requisition
        public static RequisitionModel CreateRequisition(RequisitionModel req, out string error)
        {
            error = "";
            bool RaisedByTempHOD = true;
            LUSSISEntities entities = new LUSSISEntities();
            requisition reqn = new requisition();
            try
            {
                reqn.raisedby = req.Raisedby;
                if (req.Approvedby == null || req.Approvedby == 0)
                {
                    reqn.approvedby = req.Raisedby;
                    RaisedByTempHOD = false;
                }
                reqn.deptid = req.Depid;
                reqn.cpid = req.Cpid;
                reqn.status = ConRequisition.Status.PENDING;
                reqn.reqdate = DateTime.Now;
                reqn = entities.requisitions.Add(reqn);
                entities.SaveChanges();
                req = GetRequisitionByRequisitionId(reqn.reqid, out error);

                if (!RaisedByTempHOD)
                {
                    NotificationModel nom = new NotificationModel();
                    nom.Deptid = DepartmentRepo.GetDepartmentByUserid(reqn.raisedby ?? default(int), out error).Deptid;
                    nom.Role = ConUser.Role.HOD;
                    nom.Title = "Requisition Approval";
                    nom.NotiType = ConNotification.NotiType.RequisitionApproval;
                    nom.ResID = reqn.reqid;
                    nom.Remark = "A new requisition has been raised by " + req.Rasiedbyname + "!";
                    nom = NotificationRepo.CreatNotification(nom, out error);
                }
                else
                {
                    req.Status = ConRequisition.Status.APPROVED;
                    req = UpdateRequisition(req, out error);
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
            return req;
        }


        // update the Requisition
        public static RequisitionModel UpdateRequisition(RequisitionModel reqm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            requisition req = new requisition();
            try
            {
                // finding the inventory object using Inventory API model
                req = entities.requisitions.Where(p => p.reqid == reqm.Reqid).First<requisition>();

                // transfering data from API model to DB Model
                req.reqid = reqm.Reqid;
                req.raisedby = reqm.Raisedby;
                req.approvedby = reqm.Approvedby;
                req.deptid = reqm.Depid;
                req.status = reqm.Status;
                // saving the update
                entities.SaveChanges();

                if (req.status == ConRequisition.Status.DELIVERED)
                {
                    NotificationModel nom = new NotificationModel();
                    nom.Deptid = reqm.Depid;
                    nom.Role = ConUser.Role.DEPARTMENTREP;
                    nom.Title = "Ready to Collect";
                    nom.NotiType = ConNotification.NotiType.DeliveredRequisition;
                    nom.ResID = reqm.Reqid;
                    nom.Remark = "Requisition is now ready to collect";
                    nom = NotificationRepo.CreatNotification(nom, out error);
                }
                else if (req.status == ConRequisition.Status.APPROVED)
                {
                    NotificationModel nom = new NotificationModel();
                    nom.Deptid = reqm.Depid;
                    nom.Role = ConUser.Role.EMPLOYEEREP;
                    nom.Title = "HOD Requisition";
                    nom.NotiType = ConNotification.NotiType.HODApprovedRequistion;
                    nom.ResID = reqm.Reqid;
                    nom.Remark = "The new requisition has been approved by Head of Department";
                    nom = NotificationRepo.CreatNotification(nom, out error);

                    nom.Deptid = reqm.Depid;
                    nom.Role = ConUser.Role.DEPARTMENTREP;
                    nom.Title = "HOD Requisition";
                    nom.NotiType = ConNotification.NotiType.HODApprovedRequistion;
                    nom.ResID = reqm.Reqid;
                    nom.Remark = "The new requisition has been approved by Head of Department";
                    nom = NotificationRepo.CreatNotification(nom, out error);

                    nom.Deptid = 11;
                    nom.Role = ConUser.Role.CLERK;
                    nom.Title = "New Requisition";
                    nom.NotiType = ConNotification.NotiType.HODApprovedRequistion;
                    nom.ResID = reqm.Reqid;
                    nom.Remark = "The new requisition has been rasied by " + reqm.Depname;
                    nom = NotificationRepo.CreatNotification(nom, out error);
                }
                else if (req.status == ConRequisition.Status.REQUESTPENDING)
                {
                    NotificationModel nom = new NotificationModel();
                    nom.Deptid = reqm.Depid;
                    nom.Role = ConUser.Role.HOD;
                    nom.Title = "Approved Requisition";
                    nom.NotiType = ConNotification.NotiType.ClerkApprovedRequisiton;
                    nom.ResID = reqm.Reqid;
                    nom.Remark = "The new requisition has been approved by the store";
                    nom = NotificationRepo.CreatNotification(nom, out error);

                    nom.Deptid = reqm.Depid;
                    nom.Role = ConUser.Role.TEMPHOD;
                    nom.Title = "Approved Requisition";
                    nom.NotiType = ConNotification.NotiType.ClerkApprovedRequisiton;
                    nom.ResID = reqm.Reqid;
                    nom.Remark = "The new requisition has been approved by the store";
                    nom = NotificationRepo.CreatNotification(nom, out error);
                }
                else if (req.status == ConRequisition.Status.COMPLETED || req.status == ConRequisition.Status.OUTSTANDINGREQUISITION)
                {
                    NotificationModel nom = new NotificationModel();
                    nom.Deptid = 11;
                    nom.Role = ConUser.Role.CLERK;
                    nom.Title = "Items Collected";
                    nom.NotiType = ConNotification.NotiType.CollectedRequistion;
                    nom.ResID = reqm.Reqid;
                    nom.Remark = "The Items in Requisiton has been collected by Department Rep!";
                    nom = NotificationRepo.CreatNotification(nom, out error);
                }
                // return the updated model 
                reqm = CovertDBRequisitiontoAPIRequisition(req);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return reqm;
        }

        // update the Requisition Pending to Preparing
        public static List<RequisitionWithDisbursementModel> UpdateAllRequestStatusToPreparing(out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            List<requisition> reqs = new List<requisition>();
            List<RequisitionWithDisbursementModel> reqdisms = new List<RequisitionWithDisbursementModel>();
            try
            {
                reqs = entities.requisitions.Where(p => p.status == ConRequisition.Status.REQUESTPENDING).ToList();
                List<LockerCollectionPointModel> lcpms = LockerCollectionPointRepo.GetAllLockerCP(out error);
                foreach (requisition req in reqs)
                {

                    req.status = ConRequisition.Status.PREPARING;
                    entities.SaveChanges();

                    DisbursementLockerModel dislm = new DisbursementLockerModel();


                    dislm.DisID = req.disbursements.First().disid;
                    dislm.ReqID = req.reqid;


                    List<DisbursementLockerModel> Currentdislms = new List<DisbursementLockerModel>();
                    Currentdislms = LockerCollectionPointRepo.GetDisbursementLockersByDeptIDAndStatus(req.deptid, 1, out error);

                    if (Currentdislms.Count > 0)
                    {
                        dislm = Currentdislms.First();
                    }
                    else
                    {
                        dislm.DeptID = req.deptid;
                        dislm.ReqID = req.reqid;
                        dislm.DisID = req.disbursements.First().disid;
                        LockerCollectionPointModel lcpm = lcpms.Where(p => p.Cpid == req.cpid && p.Status == ConLockerCollectionPoint.Active.AVAILABLE).FirstOrDefault();
                        if (lcpm == null)
                        {
                            lcpm = new LockerCollectionPointModel();
                            lcpm = lcpms.Where(p => p.Cpid == req.cpid).FirstOrDefault();
                        }
                        dislm.LockerID = lcpm.Lockerid;
                        dislm = LockerCollectionPointRepo.CreateDisbursementLocker(dislm, out error);
                    }

                    reqdisms.Add(CovertDBRequisitionDistoAPIRequisitionDiswithDetails(req));
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
            return reqdisms;
        }
        //Create new Requisition with Detials
        public static RequisitionModel CreateRequisitionwithDetails(RequisitionModel reqm, List<RequisitionDetailsModel> reqd, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            requisition req = new requisition();
            List<requisitiondetail> reqlist = new List<requisitiondetail>();
            try
            {
                req.reqid = reqm.Reqid;
                req.raisedby = reqm.Raisedby;
                req.approvedby = reqm.Approvedby;
                req.deptid = reqm.Depid;
                req.cpid = reqm.Cpid;
                req.status = ConRequisition.Status.PENDING;
                req.reqdate = DateTime.Now;

                req = entities.requisitions.Add(req);
                entities.SaveChanges();

                foreach (RequisitionDetailsModel rdm in reqd)
                {
                    requisitiondetail rqd = new requisitiondetail
                    {
                        reqid = req.reqid,
                        itemid = rdm.Itemid,
                        qty = rdm.Qty
                    };
                    rqd = entities.requisitiondetails.Add(rqd);
                    entities.SaveChanges();
                    reqlist.Add(rqd);
                }

                reqm = GetRequisitionByRequisitionId(req.reqid, out error);



                NotificationModel nom = new NotificationModel();
                nom.Deptid = DepartmentRepo.GetDepartmentByUserid(reqm.Raisedby ?? default(int), out error).Deptid;
                nom.Role = ConUser.Role.HOD;
                nom.Title = "Requisition Approval";
                nom.NotiType = ConNotification.NotiType.RequisitionApproval;
                nom.ResID = reqm.Reqid;
                nom.Remark = "A new requisition has been raised by " + reqm.Rasiedbyname + "!";
                nom = NotificationRepo.CreatNotification(nom, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return reqm;
        }
    }

}
