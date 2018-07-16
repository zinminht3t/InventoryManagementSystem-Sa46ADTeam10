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
                reqdm.Add(new RequisitionDetailsModel(rqdm.reqid, rqdm.itemid ,rqdm.item.description ,rqdm.qty));
            }
            RequisitionModel reqm = new RequisitionModel(req.reqid, req.raisedby, req.user.username
                                    , req.approvedby, req.user.username, req.cpid, req.collectionpoint.cpname
                                     , req.deptid, req.department.deptname, req.status, req.reqdate, reqdm);
            return reqm;
        }


        // Convert From Auto Generated DB Model to APIModel for Requisition
        private static RequisitionModel CovertDBRequisitiontoAPIRequisition(requisition req)
        {
            RequisitionModel reqm = new RequisitionModel(req.reqid , req.raisedby ,req.user.username 
                                    , req.approvedby , req.user.username , req.cpid, req.collectionpoint.cpname
                                     , req.deptid , req.department.deptname ,req.status,req.reqdate, new List<RequisitionDetailsModel>() );
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
            LUSSISEntities entities = new LUSSISEntities();
            requisition reqn = new requisition();
            try
            {
                reqn.raisedby = req.raisedby;
                reqn.approvedby = req.approvedby;
                reqn.deptid = req.depid;
                reqn.cpid = req.cpid;
                reqn.status = req.status;
                reqn.reqdate = req.reqdate;
                reqn = entities.requisitions.Add(reqn);
                entities.SaveChanges();
                req = GetRequisitionByRequisitionId(reqn.reqid , out error);
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
                req = entities.requisitions.Where(p => p.reqid == reqm.reqid).First<requisition>();

                // transfering data from API model to DB Model
                req.reqid = reqm.reqid;
                req.raisedby = reqm.raisedby;
                req.approvedby = reqm.approvedby;
                req.deptid = reqm.depid;
                req.status = reqm.status;
                req.reqdate = reqm.reqdate;
                // saving the update
                entities.SaveChanges();

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
        //Create new Requisition with Detials
        public static RequisitionModel CreateRequisitionwithDetails(RequisitionModel reqm, List<RequisitionDetailsModel> reqd, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            requisition req = new requisition();
            List<requisitiondetail> reqlist = new List<requisitiondetail>();
            try
            {
                req.reqid = reqm.reqid;
                req.raisedby = reqm.raisedby;
                req.approvedby = reqm.approvedby;
                req.deptid = reqm.depid;
                req.cpid = reqm.cpid;
                req.status = reqm.status;
                req.reqdate = reqm.reqdate;

                req = entities.requisitions.Add(req);
                entities.SaveChanges();

                foreach (RequisitionDetailsModel rdm in reqd)
                {
                    requisitiondetail rqd = new requisitiondetail
                    {
                        reqid = req.reqid,
                        itemid = rdm.itemid,
                        qty = rdm.qty
                    };
                    rqd = entities.requisitiondetails.Add(rqd);
                    entities.SaveChanges();
                    reqlist.Add(rqd);
                }

                reqm = GetRequisitionByRequisitionId(req.reqid, out error);
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
