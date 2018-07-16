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
            DelegationModel dgm = new DelegationModel(delegation.delid, delegation.startdate,
                delegation.enddate, delegation.userid,delegation.user.username,delegation.user.role,
                delegation.user.department.deptname,
                delegation.active, delegation.assignedby,delegation.user.username, delegation.user.role,
                delegation.user.department.deptname);
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
        // to get the Disbursement by the UserId
        public static List<DelegationModel> GetDelegationByUserId(int uid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DelegationModel> dism = new List<DelegationModel>();
            try
            {
                // get requisition list from database
                List<delegation> dele = entities.delegations.Where(p => p.userid == uid).ToList<delegation>();

                // convert the DB Model list to API Model list
                foreach (delegation dis in dele)
                {
                    dism.Add(CovertDBDelegationtoAPIUser(dis));
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

        // to get the Disbursement by the Assignedby ID
        public static List<DelegationModel> GetDelegationByassignedby(int asid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DelegationModel> dism = new List<DelegationModel>();
            try
            {
                // get requisition list from database
                List<delegation> dele = entities.delegations.Where(p => p.assignedby == asid).ToList<delegation>();

                // convert the DB Model list to API Model list
                foreach (delegation dis in dele)
                {
                    dism.Add(CovertDBDelegationtoAPIUser(dis));
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
                d.assignedby = dm.assignedbyId;

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

        //create delegation
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
                d.assignedby = del.assignedbyId;
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