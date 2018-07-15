using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public class LockerCollectionPointRepo
    {
        // entites used only by Get Methods
        private static LUSSISEntities entities = new LUSSISEntities();


        // Convert From Auto Generated DB Model to APIModel
        private static LockerCollectionPointModel ConvertBDLockerCPToAPILockerCP(lockercollectionpoint lcp)
        {
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel(lcp.lockerid, lcp.lockername, lcp.lockersize, lcp.cpid, lcp.status,lcp.collectionpoint.cpname);
            return lcpm;
        }

        // Get the list of all LockerCollectionPoint and will return with error if there is one.
        public static List<LockerCollectionPointModel> GetAllLockerCP(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";

            List<LockerCollectionPointModel> lockercpms = new List<LockerCollectionPointModel>();
            try
            {
                // get lockercollectionpoint list from database
                List<lockercollectionpoint> lockercps = entities.lockercollectionpoints.ToList<lockercollectionpoint>();
               
                // convert the DB Model list to API Model list
                foreach (lockercollectionpoint lockercp in lockercps)
                {
                    lockercpms.Add(ConvertBDLockerCPToAPILockerCP(lockercp));
                }
            }
            // if locker not found, will throw NOTFOUND exception
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
            return lockercpms;
        }

        public static LockerCollectionPointModel GetLockerCPByLockerid(int lockerid, out string error)
        {
            error = "";

            lockercollectionpoint lcp = new lockercollectionpoint();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            try
            {
                lcp = entities.lockercollectionpoints.Where(p => p.lockerid == lockerid).FirstOrDefault<lockercollectionpoint>();
                lcpm = ConvertBDLockerCPToAPILockerCP(lcp);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return lcpm;
        }


        public static LockerCollectionPointModel GetLockerCPByLockername(string lockername, out string error)
        {
            error = "";

            lockercollectionpoint lcp = new lockercollectionpoint();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            try
            {
                lcp = entities.lockercollectionpoints.Where(p => p.lockername == lockername).FirstOrDefault<lockercollectionpoint>();
                lcpm = ConvertBDLockerCPToAPILockerCP(lcp);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return lcpm;
        }


        public static List<LockerCollectionPointModel> GetLockerCPByLockersize(string lockersize, out string error)
        {
            error = "";

            List<lockercollectionpoint> lcps = new List<lockercollectionpoint>();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            List<LockerCollectionPointModel> lcplm = new List<LockerCollectionPointModel>();

            try
            {
                lcps = entities.lockercollectionpoints.Where(p => p.lockersize == lockersize).ToList<lockercollectionpoint>();

                foreach(lockercollectionpoint lcp in lcps)
                {
                    lcplm.Add(ConvertBDLockerCPToAPILockerCP(lcp));
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
            return lcplm;
        }



        public static LockerCollectionPointModel GetLockerCPBycpid(int cpid, out string error)
        {
            error = "";

            lockercollectionpoint lcp = new lockercollectionpoint();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            try
            {
                lcp = entities.lockercollectionpoints.Where(p => p.cpid == cpid).FirstOrDefault<lockercollectionpoint>();
                lcpm = ConvertBDLockerCPToAPILockerCP(lcp);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return lcpm;
        }

        public static LockerCollectionPointModel UpdateLockerCP(LockerCollectionPointModel lcpm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            lockercollectionpoint lcp = new lockercollectionpoint();
            try
            {
                // finding the department object using Department API model
                lcp = entities.lockercollectionpoints.Where(p => p.lockerid == lcpm.lockerid).First<lockercollectionpoint>();

                // transfering data from API model to DB Model
                lcp.lockername = lcpm.lockername;
                lcp.lockersize = lcpm.lockersize;
                lcp.cpid = lcpm.cpid;
                lcp.status = lcpm.status;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                lcpm = ConvertBDLockerCPToAPILockerCP(lcp);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return lcpm;
        }
        public static LockerCollectionPointModel CreateLockerCP(LockerCollectionPointModel lcpm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            lockercollectionpoint lcp = new lockercollectionpoint();
            try
            {
                lcp.lockername = lcpm.lockername;
                lcp.lockersize = lcpm.lockersize;
                lcp.cpid = lcpm.cpid;
                lcp.status = lcpm.status;
                lcp = entities.lockercollectionpoints.Add(lcp);
                entities.SaveChanges();
                lcpm = GetLockerCPByLockerid(lcp.lockerid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return lcpm;
        }








        public static LockerCollectionPointModel GetLockerCPByCPName(string cpname, out string error)
        {
            error = "";

            lockercollectionpoint lcp = new lockercollectionpoint();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            try
            {
                lcp = entities.lockercollectionpoints.Where(p => p.collectionpoint.cpname == cpname).FirstOrDefault<lockercollectionpoint>();
                lcpm = ConvertBDLockerCPToAPILockerCP(lcp);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return lcpm;
        }


    }



}








