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
       
     


        // Convert From Auto Generated DB Model to APIModel
        private static LockerCollectionPointModel ConvertBDLockerCPToAPILockerCP(lockercollectionpoint lcp)
        {
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel(lcp.lockerid, lcp.lockername, lcp.lockersize, lcp.cpid, lcp.status,lcp.collectionpoint.cpname);
            return lcpm;
        }

        // Get the list of all LockerCollectionPoint and will return with error if there is one.
        public static List<LockerCollectionPointModel> GetAllLockerCP(out string error)
        {
            // entites used only by Get Methods
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
            
            LUSSISEntities entities = new LUSSISEntities();
            lockercollectionpoint lcp = new lockercollectionpoint();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            try
            {
                lcp = entities.lockercollectionpoints.Where(p => p.lockerid == lockerid).FirstOrDefault<lockercollectionpoint>();
                lcpm = ConvertBDLockerCPToAPILockerCP(lcp);
            }
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
            return lcpm;
        }


        public static LockerCollectionPointModel GetLockerCPByLockername(string lockername, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to get LockerCollectionPoint By LockerName
            LUSSISEntities entities = new LUSSISEntities();

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
            // entites used only by Get Methods
            LUSSISEntities entities = new LUSSISEntities();
            List<lockercollectionpoint> lcps = new List<lockercollectionpoint>();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            List<LockerCollectionPointModel> lcplm = new List<LockerCollectionPointModel>();

            try
            {
                // get lockercollectionpoint list from database by LockerSize
                lcps = entities.lockercollectionpoints.Where(p => p.lockersize == lockersize).ToList<lockercollectionpoint>();

                // convert the DB Model list to API Model list
                foreach (lockercollectionpoint lcp in lcps)
                {
                    lcplm.Add(ConvertBDLockerCPToAPILockerCP(lcp));
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
            //returning the Lockercollectionpoint List
            return lcplm;
        }



        public static List<LockerCollectionPointModel> GetLockerCPBycpid(int cpid, out string error)
        {
            error = "";
            // entites used only by Get Methods
            LUSSISEntities entities = new LUSSISEntities();
            List<lockercollectionpoint> lcps = new List<lockercollectionpoint>();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            List<LockerCollectionPointModel> lcplm = new List<LockerCollectionPointModel>();
            try
            {
                lcps = entities.lockercollectionpoints.Where(p => p.cpid == cpid).ToList<lockercollectionpoint>();

                foreach (lockercollectionpoint lcp in lcps)
                {
                    lcplm.Add(ConvertBDLockerCPToAPILockerCP(lcp));
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
            //returning the locker collection point 
            return lcplm;
        }

        public static LockerCollectionPointModel UpdateLockerCP(LockerCollectionPointModel lcpm, out string error)
        {
            // Initializing the error variable to return only blank if there is no error
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            lockercollectionpoint lcp = new lockercollectionpoint();
            try
            {
                // finding the lockercollectionpoint by lockerid 
                lcp = entities.lockercollectionpoints.Where(p => p.lockerid == lcpm.Lockerid).First<lockercollectionpoint>();

                // transfering data from API model to DB Model
                lcp.lockername = lcpm.Lockername;
                lcp.lockersize = lcpm.Lockersize;
                lcp.cpid = lcpm.Cpid;
                lcp.status = lcpm.Status;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                lcpm = ConvertBDLockerCPToAPILockerCP(lcp);
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
            //returning the lockercollectionpoint object
            return lcpm;
        }
        public static LockerCollectionPointModel CreateLockerCP(LockerCollectionPointModel lcpm, out string error)
        {
            error = "";
            // entites used only by Get Methods
            LUSSISEntities entities = new LUSSISEntities();
            lockercollectionpoint lcp = new lockercollectionpoint();
            try
            {
                // transfering data from API model to DB Model
                lcp.lockername = lcpm.Lockername;
                lcp.lockersize = lcpm.Lockersize;
                lcp.cpid = lcpm.Cpid;
                lcp.status = lcpm.Status;
                //Add the updated data to DB Model
                lcp = entities.lockercollectionpoints.Add(lcp);
                // saving the update
                entities.SaveChanges();
                //retrieving the LockerColletionPoint By Lockerid
                lcpm = GetLockerCPByLockerid(lcp.lockerid, out error);
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
            //retuning the lockercollectionpoint object
            return lcpm;
        }








        public static List<LockerCollectionPointModel> GetLockerCPByCPName(string cpname, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            List<lockercollectionpoint> lcps = new List<lockercollectionpoint>();
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel();
            List<LockerCollectionPointModel> lcplm = new List<LockerCollectionPointModel>();
            try
            {
                lcps = entities.lockercollectionpoints.Where(p => p.collectionpoint.cpname == cpname).ToList<lockercollectionpoint>();
               
                 foreach (lockercollectionpoint Lcp in lcps)
                {
                    lcplm.Add(ConvertBDLockerCPToAPILockerCP(Lcp));
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
            //retuning the locker collection point list 
            return lcplm;
        }


    }



}








