using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;

namespace LUSSISADTeam10API.Repositories
{
    public class AdjustmentDetailRepo
    {
        //Changed from DB to APIModel
        public static AdjustmentDetailModel ConvertDBtoAPIAdjustDetail(adjustmentdetail adjd)
        {
            AdjustmentDetailModel adjdm = new AdjustmentDetailModel(adjd.adjid, adjd.itemid,adjd.item.description, adjd.adjustedqty, adjd.reason);
            return adjdm;
        }

        //Get All details by adjustment id
        public static List<AdjustmentDetailModel> GetAdjustmentDetailByAdjID(int adjid, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            List<AdjustmentDetailModel> adjdm = new List<AdjustmentDetailModel>();
            try
            {
                List<adjustmentdetail> adjds = entities.adjustmentdetails.Where(a => a.adjid == adjid).ToList();
                foreach(adjustmentdetail adjd in adjds)
                {
                    adjdm.Add(ConvertDBtoAPIAdjustDetail(adjd));
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch(Exception e)
            {
                error = e.Message;
            }
            return adjdm;
        }       
        //Get All adjustments by item id & adjustment id
        public static AdjustmentDetailModel GetAdjustDetailByItemandAdjustID(int itemid,int adjid, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
           AdjustmentDetailModel adjdm = new AdjustmentDetailModel();
            try
            {
                adjustmentdetail adjd = entities.adjustmentdetails.Where(a => a.itemid == itemid && a.adjid==adjid).First<adjustmentdetail>();                                                 
                    adjdm= ConvertDBtoAPIAdjustDetail(adjd);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return adjdm;
        }
        //Create Adjustmentdetail
        public static AdjustmentDetailModel CreateAdjustmentDetail(AdjustmentDetailModel adjdm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            adjustmentdetail adjd = new adjustmentdetail();
            try
            {
                adjd.adjid = adjdm.Adjid;
                adjd.itemid = adjdm.Itemid;
                adjd.adjustedqty = adjdm.Adjustedqty;
                adjd.reason = adjdm.Reason;
                adjd = entities.adjustmentdetails.Add(adjd);
                entities.SaveChanges();
                adjdm = GetAdjustDetailByItemandAdjustID(adjd.itemid, adjd.adjid, out error);
                    
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return adjdm;
        }
        //Update Adjustmentdetail
        public static AdjustmentDetailModel UpdateAdjustmentDetail(AdjustmentDetailModel adjdm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            adjustmentdetail adjd = new adjustmentdetail ();            
            try
            {
                adjd = entities.adjustmentdetails.Where(a => a.adjid == adjdm.Adjid && a.itemid == adjdm.Itemid).First<adjustmentdetail>();
                //adjd.adjid = adjdm.adjid;
                //adjd.itemid = adjdm.itemid;
                adjd.reason = adjdm.Reason;
                adjd.adjustedqty = adjdm.Adjustedqty;               
               
                entities.SaveChanges();
                adjdm = GetAdjustDetailByItemandAdjustID(adjd.itemid, adjd.adjid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return adjdm;
        }
    }
}