using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Constants;

namespace LUSSISADTeam10API.Repositories
{
    public class DisbursementRepo
    {


        // Convert From Auto Generated DB Model to APIModel for Requsition with Requisition Details data
        private static DisbursementModel CovertDBDisbursementtoAPIDisbursementwithDetails(disbursement disb)
        {
            List<DisbursementDetailsModel> reqdm = new List<DisbursementDetailsModel>();
            foreach (disbursementdetail rqdm in disb.disbursementdetails)
            {
                reqdm.Add(new DisbursementDetailsModel(rqdm.disid, rqdm.itemid, rqdm.item.description, rqdm.qty));
            }
            DisbursementModel reqm = new DisbursementModel(disb.disid , disb.reqid , disb.ackby , disb.requisition.reqdate ,
                disb.requisition.status, disb.requisition.collectionpoint.cpname, disb.user.username , 
                disb.user.department.deptname ,reqdm );
            return reqm;
        }


        // Convert From Auto Generated DB Model to APIModel for Requisition
        private static DisbursementModel CovertDBDisbursementtoAPIDisbursement(disbursement disb)
        {
            DisbursementModel reqm = new DisbursementModel(disb.disid, disb.reqid, disb.ackby, disb.requisition.reqdate,
                  disb.requisition.status, disb.requisition.collectionpoint.cpname, disb.user.username,
                  disb.user.department.deptname, new List<DisbursementDetailsModel>());
            return reqm;
        }
        // Get the list of all disbursement 
        public static List<DisbursementModel> GetAllDisbursement(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementModel> reqm = new List<DisbursementModel>();
            try
            {
                // get inventory list from database
                List<disbursement> reqs = entities.disbursements.ToList<disbursement>();

                // convert the DB Model list to API Model list
                foreach (disbursement req in reqs)
                {
                    reqm.Add(CovertDBDisbursementtoAPIDisbursement(req));
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
        // Get the list of all disbursement  with Details
    
        public static List<DisbursementModel> GetAllDisbursementwithDetails(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementModel> reqm = new List<DisbursementModel>();
            try
            {
                // get inventory list from database
                List<disbursement> reqs = entities.disbursements.ToList<disbursement>();

                // convert the DB Model list to API Model list
                foreach (disbursement req in reqs)
                {
                    reqm.Add(CovertDBDisbursementtoAPIDisbursementwithDetails(req));
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
        // to get the Disbursement by the DisbursementId
        public static DisbursementModel GetDisbursementByDisbursementId(int disid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            error = "";

            disbursement disbursement = new disbursement();
            DisbursementModel dism = new DisbursementModel();
            try
            {
                disbursement = entities.disbursements.Where(p => p.disid == disid).FirstOrDefault<disbursement>();
                dism = CovertDBDisbursementtoAPIDisbursement(disbursement);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dism;
        }
        // to get the Disbursement by the RequisitionId
        public static List<DisbursementModel> GetDisbursementByRequisitionId(int reqid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementModel> dism = new List<DisbursementModel>();
            try
            {
                // get requisition list from database
                List<disbursement> disb = entities.disbursements.Where(p => p.reqid == reqid).ToList<disbursement>();

                // convert the DB Model list to API Model list
                foreach (disbursement dis in disb)
                {
                    dism.Add(CovertDBDisbursementtoAPIDisbursementwithDetails(dis));
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


        // to get the Disbursement by the ackyby
        public static List<DisbursementModel> GetDisbursementByackyby(int userid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementModel> dism = new List<DisbursementModel>();
            try
            {
                // get requisition list from database
                List<disbursement> disb = entities.disbursements.Where(p => p.ackby == userid).ToList<disbursement>();

                // convert the DB Model list to API Model list
                foreach (disbursement dis in disb)
                {
                    dism.Add(CovertDBDisbursementtoAPIDisbursementwithDetails(dis));
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
        //create the disbursement
        public static DisbursementModel Createdisbursement(DisbursementModel dism, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            disbursement disb = new disbursement();
            try
            {
                disb.reqid = dism.reqid;
                disb.ackby = dism.ackby;
                disb = entities.disbursements.Add(disb);
                entities.SaveChanges();
                dism = GetDisbursementByDisbursementId(disb.disid, out error);
            }

            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dism;
        }
        }

    }
