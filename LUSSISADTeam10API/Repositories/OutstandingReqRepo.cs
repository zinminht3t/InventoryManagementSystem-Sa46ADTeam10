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
            //foreach(outstandingrequisitiondetail ord in outreq.)
            return new OutstandingReqModel(
                    outreq.outreqid,
                    outreq.reqid,
                    outreq.reason,
                    outreq.status

                );
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
                // get department list from database
                List<outstandingrequisition> outreqs = 
                    entities.outstandingrequisitions.ToList();

                // convert the DB Model list to API Model list
                foreach (outstandingrequisition outreq in outreqs)
                {
                    orms.Add(ConvertDBOutReqToAPIOutReq(outreq));
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
            return orms;
        }
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

        public static OutstandingReqModel GetOutstandingReqDetailByReqId(int reqid, out string error)
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
        public static OutstandingReqModel AddOutReq
            (OutstandingReqModel ordm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            OutstandingReqModel outreqm = new OutstandingReqModel();
            outstandingrequisition outreq = new outstandingrequisition();
            try
            {
                // transfering data from API model to DB Model
                outreq.reqid = ordm.ReqId;
                outreq.reason = ordm.Reason;
                outreq.status = ConOutstandingsRequisition.Status.PENDING;

                // adding into DB
                entities.outstandingrequisitions.Add(outreq);
                entities.SaveChanges();

                // return the model 
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