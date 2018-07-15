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
        //Get All adjustments by item id
        public static List<AdjustmentDetailModel> GetAdjustmentDetailByItemID(int itemid, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            List<AdjustmentDetailModel> adjdm = new List<AdjustmentDetailModel>();
            try
            {
                List<adjustmentdetail> adjds = entities.adjustmentdetails.Where(a => a.itemid == itemid).ToList();                
                foreach (adjustmentdetail adjd in adjds)
                {                    
                    adjdm.Add(ConvertDBtoAPIAdjustDetail(adjd));
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
                adjd.itemid = adjdm.itemid;
                adjd.adjustedqty = adjdm.adjustedqty;
                adjd.reason = adjdm.reason;
                adjd = entities.adjustmentdetails.Add(adjd);
                entities.SaveChanges();
                adjdm = ConvertDBtoAPIAdjustDetail(adjd);
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
                //List<AdjustmentDetailModel> adjdmlist = GetAdjustmentDetailByAdjID(adjdm.adjid, out error);
                adjd = entities.adjustmentdetails.Where(a => a.adjid == adjdm.adjid && a.itemid == adjdm.itemid).First<adjustmentdetail>();
                adjd.reason = adjdm.reason;
                adjd.adjustedqty = adjdm.adjustedqty;               
                adjd = entities.adjustmentdetails.Add(adjd);
                entities.SaveChanges();
                adjdm = ConvertDBtoAPIAdjustDetail(adjd);
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