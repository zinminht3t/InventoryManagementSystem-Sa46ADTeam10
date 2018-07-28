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
            LockerCollectionPointModel lcpm = new LockerCollectionPointModel(lcp.lockerid, lcp.lockername, lcp.lockersize, lcp.cpid, lcp.status, lcp.collectionpoint.cpname);
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


        private static DisbursementLockerModel CovertDisLockertoModel(disbursementlocker disl)
        {
            DisbursementLockerModel dislm = new DisbursementLockerModel(disl.disid, disl.reqid, disl.lockerid, disl.delivereddate, disl.collecteddate, disl.status, disl.requisition.deptid);
            return dislm;
        }
        public static DisbursementLockerModel GetDisbursementLockerByDisID(int DisID, out string error)
        {
            error = "";

            LUSSISEntities entities = new LUSSISEntities();
            disbursementlocker disl = new disbursementlocker();
            DisbursementLockerModel dislm = new DisbursementLockerModel();
            try
            {
                disl = entities.disbursementlockers.Where(p => p.disid == DisID).FirstOrDefault();

                dislm = CovertDisLockertoModel(disl);
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
            return dislm;
        }
        public static DisbursementLockerModel GetDisbursementLockerByReqID(int ReqID, out string error)
        {
            error = "";

            LUSSISEntities entities = new LUSSISEntities();
            disbursementlocker disl = new disbursementlocker();
            DisbursementLockerModel dislm = new DisbursementLockerModel();
            try
            {
                disl = entities.disbursementlockers.Where(p => p.reqid == ReqID).FirstOrDefault();

                dislm = CovertDisLockertoModel(disl);
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
            return dislm;
        }
        public static DisbursementLockerModel GetDisbursementLockerByReqIDAndLockerID(int ReqID, int LockerID, out string error)
        {
            error = "";

            LUSSISEntities entities = new LUSSISEntities();
            disbursementlocker disl = new disbursementlocker();
            DisbursementLockerModel dislm = new DisbursementLockerModel();
            try
            {
                disl = entities.disbursementlockers.Where(p => p.reqid == ReqID && p.lockerid == LockerID).FirstOrDefault();

                dislm = CovertDisLockertoModel(disl);
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
            return dislm;
        }
        public static List<DisbursementLockerModel> GetDisbursementLockersByLockerID(int LockerID, out string error)
        {
            error = "";

            LUSSISEntities entities = new LUSSISEntities();
            List<disbursementlocker> disls = new List<disbursementlocker>();
            List<DisbursementLockerModel> dislms = new List<DisbursementLockerModel>();
            try
            {
                disls = entities.disbursementlockers.Where(p => p.reqid == LockerID).ToList();

                foreach (disbursementlocker disl in disls)
                {
                    dislms.Add(CovertDisLockertoModel(disl));
                }
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
            return dislms;
        }
        public static List<DisbursementLockerModel> GetDisbursementLockersByDeptIDAndStatus(int DeptID, int status, out string error)
        {
            error = "";

            LUSSISEntities entities = new LUSSISEntities();
            List<disbursementlocker> disls = new List<disbursementlocker>();
            List<DisbursementLockerModel> dislms = new List<DisbursementLockerModel>();
            try
            {
                disls = entities.disbursementlockers.Where(p => p.reqid == DeptID && p.status == status).ToList();

                foreach (disbursementlocker disl in disls)
                {
                    dislms.Add(CovertDisLockertoModel(disl));
                }
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
            return dislms;
        }
        public static DisbursementLockerModel CreateDisbursementLocker(DisbursementLockerModel lislm, out string error)
        {
            error = "";
            // entites used only by Get Methods
            LUSSISEntities entities = new LUSSISEntities();
            disbursementlocker disl = new disbursementlocker();
            DisbursementLockerModel dislm = new DisbursementLockerModel();
            try
            {
                disl.disid = lislm.DisID;
                disl.reqid = lislm.ReqID;
                disl.lockerid = lislm.LockerID;
                disl.deptid = lislm.DeptID;
                disl.delivereddate = DateTime.Now.AddDays(2);
                disl.collecteddate = DateTime.Now.AddDays(9);
                disl.status = 1;
                entities.disbursementlockers.Add(disl);
                entities.SaveChanges();

                LockerCollectionPointModel lcpm = GetLockerCPByLockerid(disl.lockerid, out error);
                lcpm.Status = ConLockerCollectionPoint.Active.NOTAVAILABLE;
                lcpm = UpdateLockerCP(lcpm, out error);

                dislm = GetDisbursementLockerByReqIDAndLockerID(disl.reqid, disl.lockerid, out error);

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
            return dislm;
        }
        public static DisbursementLockerModel UpdateDisbursementLocker(DisbursementLockerModel lislm, out string error)
        {
            error = "";
            // entites used only by Get Methods
            LUSSISEntities entities = new LUSSISEntities();
            disbursementlocker disl = new disbursementlocker();
            DisbursementLockerModel dislm = new DisbursementLockerModel();
            try
            {
                disl = entities.disbursementlockers.Where(p => p.reqid == lislm.ReqID && p.lockerid == lislm.LockerID).FirstOrDefault();

                disl.collecteddate = DateTime.Now;
                disl.status = lislm.Status;
                entities.SaveChanges();

                dislm = GetDisbursementLockerByReqIDAndLockerID(disl.reqid, disl.lockerid, out error);

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
            return dislm;
        }
        public static DisbursementLockerModel UpdateDisbursementLockerToCollected(DisbursementLockerModel lislm, out string error)
        {
            error = "";
            // entites used only by Get Methods
            LUSSISEntities entities = new LUSSISEntities();
            disbursementlocker disl = new disbursementlocker();
            DisbursementLockerModel dislm = new DisbursementLockerModel();
            try
            {
                disl = entities.disbursementlockers.Where(p => p.reqid == lislm.ReqID && p.lockerid == lislm.LockerID).FirstOrDefault();

                disl.collecteddate = DateTime.Now;
                disl.status = 0;
                entities.SaveChanges();

                lockercollectionpoint lcp = entities.lockercollectionpoints.Where(p => p.lockerid == disl.lockerid).FirstOrDefault();
                lcp.status = ConLockerCollectionPoint.Active.AVAILABLE;

                entities.SaveChanges();


                dislm = GetDisbursementLockerByReqIDAndLockerID(disl.reqid, disl.lockerid, out error);

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
            return dislm;
        }

    }



}








