using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public static class OutstandingReqDetailRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        public static OutstandingReqDetailModel ConvertDBOutReqDetailToAPIModel(outstandingrequisitiondetail outreqdetail)
        {
            return new OutstandingReqDetailModel(
                    outreqdetail.outreqid,
                    outreqdetail.itemid,
                    outreqdetail.item.description,
                    outreqdetail.qty
                );
        }

        // Covert From APIModel to DBModel
        public static outstandingrequisitiondetail ConvertAPIOutReqDetailToDBModel(OutstandingReqDetailModel outreqdetail)
        {
            outstandingrequisitiondetail ord = 
                new outstandingrequisitiondetail();
            ord.outreqid = outreqdetail.OutReqId;
            ord.itemid = outreqdetail.ItemId;
            ord.qty = outreqdetail.Qty;

            return ord;
        }

        // Get the list of all suppliers and will return with error if there is one.
        public static List<OutstandingReqDetailModel> GetAllOutReqDetails(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<OutstandingReqDetailModel> ordms = new List<OutstandingReqDetailModel>();
            try
            {
                // get department list from database
                List<outstandingrequisitiondetail> ouotreqdetails = 
                    entities.outstandingrequisitiondetails.ToList();

                // convert the DB Model list to API Model list
                foreach (outstandingrequisitiondetail outreqdetail in ouotreqdetails)
                {
                    ordms.Add(ConvertDBOutReqDetailToAPIModel(outreqdetail));
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
            return ordms;
        }

        // Get outstanding detail by specific req number and itemid
        public static OutstandingReqDetailModel GetOutstandingReqDetailByIds
            (int outreqid, int itemid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            outstandingrequisitiondetail ord = new outstandingrequisitiondetail();
            OutstandingReqDetailModel ordm = new OutstandingReqDetailModel();
            try
            {
                ord = entities.outstandingrequisitiondetails
                    .Where(x => x.outreqid == outreqid && x.itemid == itemid)
                    .FirstOrDefault();
                ordm = ConvertDBOutReqDetailToAPIModel(ord);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return ordm;
        }
        public static OutstandingReqDetailModel UpdateOutReqDetail
            (OutstandingReqDetailModel ordm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            OutstandingReqDetailModel outreqdetailm = new OutstandingReqDetailModel();
            outstandingrequisitiondetail outreqdetail = new outstandingrequisitiondetail();
            try
            {
                // finding the db object using API model
                outreqdetail = entities.outstandingrequisitiondetails
                    .Where(x => x.outreqid == ordm.OutReqId &&
                    x.itemid == ordm.ItemId).FirstOrDefault();

                // transfering data from API model to DB Model
                outreqdetail.outreqid = ordm.OutReqId;
                outreqdetail.itemid = ordm.ItemId;
                outreqdetail.qty = ordm.Qty;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                outreqdetailm = ConvertDBOutReqDetailToAPIModel(outreqdetail);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return outreqdetailm;
        }
        public static OutstandingReqDetailModel CreateOutReqDetail
            (OutstandingReqDetailModel ordm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            OutstandingReqDetailModel outreqdetailm = new OutstandingReqDetailModel();
            outstandingrequisitiondetail outreqdetail = new outstandingrequisitiondetail();
            try
            {
                // transfering data from API model to DB Model
                outreqdetail.outreqid = ordm.OutReqId;
                outreqdetail.itemid = ordm.ItemId;
                outreqdetail.qty = ordm.Qty;

               // adding into DB
                entities.outstandingrequisitiondetails.Add(outreqdetail);
                entities.SaveChanges();

                outreqdetailm = GetOutstandingReqDetailByIds
                    (outreqdetail.outreqid, outreqdetail.itemid, out error);

               //  return the model 
               // outreqdetailm = ConvertDBOutReqDetailToAPIModel(outreqdetail);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return outreqdetailm;
        }
    }
}