using System;
using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author : Zin Min Htet
namespace LUSSISADTeam10API.Repositories
{
    public static class CollectionPointRepo
    {

        // Convert From Auto Generated DB Model to APIModel
        private static CollectionPointModel CovertDBCptoAPICp(collectionpoint cp)
        {
            CollectionPointModel cpm = new CollectionPointModel(cp.cpid, cp.cpname, cp.cplocation, cp.latitude, cp.longitude);
            return cpm;
        }


        // Get the list of all collectionpoints and will return with error if there is one.
        public static List<CollectionPointModel> GetAllCollectionPoint(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<CollectionPointModel> cpm = new List<CollectionPointModel>();
            try
            {
                // get collection list from database
                List<collectionpoint> cps = entities.collectionpoints.ToList<collectionpoint>();

                // convert the DB Model list to API Model list
                foreach (collectionpoint cp in cps)
                {
                    cpm.Add(CovertDBCptoAPICp(cp));
                }
            }

            // if collectionpoint not found, will throw NOTFOUND exception
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
            return cpm;
        }
        public static CollectionPointModel GetCollectionPointByCpid(int cpid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            collectionpoint cp = new collectionpoint();

            CollectionPointModel cpm = new CollectionPointModel();
            try
            {
                cp = entities.collectionpoints.Where(p => p.cpid == cpid).FirstOrDefault<collectionpoint>();
                cpm = CovertDBCptoAPICp(cp);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return cpm;
        }
        public static List<CollectionPointModel> GetCollectionPointByReqid(int reqid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<requisition> req = new List<requisition>();
            List<CollectionPointModel> cpm = new List<CollectionPointModel>();
            try
            {
                req = entities.requisitions.Where(p => p.reqid == reqid).ToList<requisition>();
                foreach (requisition r in req)
                {
                    cpm.Add(CovertDBCptoAPICp(r.collectionpoint));
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
            return cpm;

        }
        public static List<CollectionPointModel> GetCollectionPointByDeptid(int deptid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<departmentcollectionpoint> dep = new List<departmentcollectionpoint>();
            List<CollectionPointModel> cpm = new List<CollectionPointModel>();
            try
            {
                dep = entities.departmentcollectionpoints.Where(p => p.deptid == deptid).ToList<departmentcollectionpoint>();
                foreach (departmentcollectionpoint d in dep)
                {
                    cpm.Add(CovertDBCptoAPICp(d.collectionpoint));
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
            return cpm;

        }
        public static List<CollectionPointModel> GetCollectionPointByLockerid(int lockerid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<lockercollectionpoint> lcp = new List<lockercollectionpoint>();
            List<CollectionPointModel> cpm = new List<CollectionPointModel>();
            try
            {
                lcp = entities.lockercollectionpoints.Where(p => p.lockerid == lockerid).ToList<lockercollectionpoint>();
                foreach (lockercollectionpoint l in lcp)
                {
                    cpm.Add(CovertDBCptoAPICp(l.collectionpoint));
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
            return cpm;
        }
        public static CollectionPointModel UpdateCollectionPoint(CollectionPointModel cpm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            collectionpoint cp = new collectionpoint();
            try
            {
                // finding the collectionpoint object using CollectionPoint API model
                cp = entities.collectionpoints.Where(p => p.cpid == cpm.Cpid).First<collectionpoint>();

                // transfering data from API model to DB Model
                cp.cpname = cpm.Cpname;
                cp.cplocation = cpm.Cplocation;
                cp.latitude = cpm.Latitude;
                cpm.Longitude = cpm.Longitude;



                // saving the update
                entities.SaveChanges();

                // return the updated model 
                cpm = CovertDBCptoAPICp(cp);

            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return cpm;
        }
        public static CollectionPointModel CreateCollectionPoint(CollectionPointModel cpm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            collectionpoint cp = new collectionpoint();
            try
            {
                cp.cpname = cpm.Cpname;
                cp.cplocation = cpm.Cplocation;
                cp.latitude = cpm.Latitude;
                cpm.Longitude = cpm.Longitude;

                cp = entities.collectionpoints.Add(cp);
                entities.SaveChanges();
                cpm = GetCollectionPointByCpid(cp.cpid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return cpm;
        }
    }
}

