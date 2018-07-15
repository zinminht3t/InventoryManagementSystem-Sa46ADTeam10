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
        // Convert From Auto Generated DB Model to APIModel for Requisition
        private static RequisitionModel CovertDBRequisitiontoAPIRequisition(requisition req)
        {
            RequisitionModel reqm = new RequisitionModel(req.reqid , req.raisedby ,req.user.username 
                                    , req.approvedby , req.user.username , req.cpid, req.collectionpoint.cpname
                                     , req.deptid , req.department.deptname ,req.status,req.reqdate);
            return reqm;
        }


        // Convert From Auto Generated DB Model to APIModel for Requisitiondetail
        private static RequisitionDetailsModel CovertDBRequisitionDetailstoAPIRequisitionDetails(requisitiondetail reqd)
        {
            RequisitionDetailsModel reqdm = new RequisitionDetailsModel(reqd.reqid,reqd.itemid,reqd.item.description,reqd.qty);
            return reqdm;
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
                reqm = CovertDBRequisitiontoAPIRequisition(requisition);
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
                    reqm.Add(CovertDBRequisitiontoAPIRequisition(req));
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
                    reqm.Add(CovertDBRequisitiontoAPIRequisition(req));
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
                    reqm.Add(CovertDBRequisitiontoAPIRequisition(req));
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
                    reqm.Add(CovertDBRequisitiontoAPIRequisition(req));
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
                    reqm.Add(CovertDBRequisitiontoAPIRequisition(req));
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



    }
}