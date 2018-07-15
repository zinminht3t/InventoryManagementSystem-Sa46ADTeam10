using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Constants;

namespace LUSSISADTeam10API.Repositories
{
    public class DelegationRepo
    {
        private static LUSSISEntities entities = new LUSSISEntities();
       private static DelegationModel CovertDBDelegationtoAPIUser(delegation delegation)
       {
            DelegationModel dgm = new DelegationModel(delegation.delid, delegation.startdate, delegation.enddate, delegation.userid, delegation.active, delegation.assignedby);
           return dgm;
       }
        public static DelegationModel GetDelegationByDelegationID(int delid , out string error )
        {


            error = "";

            delegation dele = new delegation();
            DelegationModel dm = new DelegationModel();
            try
            {
                dele = entities.delegations.Where(p => p.delid == delid).FirstOrDefault<delegation>();
                dm = CovertDBDelegationtoAPIUser(dele);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dm;
        }
        public static DelegationModel GetDelegationByUserID(int userid, out string error)
        {


            error = "";

            delegation dele = new delegation();
            DelegationModel dm = new DelegationModel();
            try
            {
                dele = entities.delegations.Where(p => p.userid == userid).FirstOrDefault<delegation>();
                dm = CovertDBDelegationtoAPIUser(dele);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dm;
        }
        public static DelegationModel GetDelegationByAssignedbyID(int aid, out string error)
        {


            error = "";

            delegation dele = new delegation();
            DelegationModel dm = new DelegationModel();
            try
            {
                dele = entities.delegations.Where(p => p.assignedby == aid).FirstOrDefault<delegation>();
                dm = CovertDBDelegationtoAPIUser(dele);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dm;
        }

        public static List<DelegationModel> GetAllDelegations()
        {
            List<delegation> delegations = entities.delegations.ToList<delegation>();
            List<DelegationModel> dms = new List<DelegationModel>();
            foreach (delegation delegation in delegations)
            {
                dms.Add(CovertDBDelegationtoAPIUser(delegation));
            }
            return dms;
        }

        public static DelegationModel UpdateDelegation(DelegationModel dm , out String error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            delegation d = new delegation();
            try
            {
                // finding the delegation object using delegation API model
                d = entities.delegations.Where(p => p.delid == dm.delid).First<delegation>();

                // transfering data from API model to DB Model
                d.startdate = dm.startdate;
                d.enddate = dm.enddate;
                d.userid = dm.userid;
                d.active = dm.active;
                d.assignedby = dm.assignedby;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                dm = CovertDBDelegationtoAPIUser(d);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dm;
        }
        public static DelegationModel CreateDelegation(DelegationModel del, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            delegation d = new delegation();
            try
            {
                d.startdate = del.startdate;
                d.enddate = del.enddate;
                d.userid = del.userid;
                d.active = del.active;             
                d.assignedby = del.assignedby;
                d = entities.delegations.Add(d);
                entities.SaveChanges();
                del = CovertDBDelegationtoAPIUser(d);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return del;
        }




    }
}