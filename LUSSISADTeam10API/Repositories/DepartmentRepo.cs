using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public static class DepartmentRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        private static DepartmentModel CovertDBDepttoAPIDept(department dept)
        {
            DepartmentModel dm = new DepartmentModel(dept.deptid, dept.deptname, dept.deptcontactname, dept.deptphone, dept.deptemail);
            return dm;
        }

        private static DepartmentCollectionPointModel CovertDBDCPtoAPIDCP(departmentcollectionpoint dcp)
        {
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel(dcp.deptcpid, dcp.deptid, dcp.department.deptname, dcp.cpid, dcp.status, dcp.collectionpoint.cpname, dcp.collectionpoint.cplocation);
            return dcpm;
        }

        // Get the list of all departments and will return with error if there is one.
        public static List<DepartmentModel> GetAllDepartments(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DepartmentModel> dms = new List<DepartmentModel>();
            try
            {
                // get department list from database
                List<department> depts = entities.departments.ToList<department>();

                // convert the DB Model list to API Model list
                foreach (department dept in depts)
                {
                    dms.Add(CovertDBDepttoAPIDept(dept));
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
            return dms;
        }
        public static DepartmentModel GetDepartmentByDeptid(int deptid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            department dept = new department();
            DepartmentModel dm = new DepartmentModel();
            try
            {
                dept = entities.departments.Where(p => p.deptid == deptid).FirstOrDefault<department>();
                dm = CovertDBDepttoAPIDept(dept);
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
        public static DepartmentModel GetDepartmentByUserid(int userid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            department dept = new department();
            user u = new user();
            DepartmentModel dm = new DepartmentModel();
            try
            {
                // get the user first
                u = entities.users.Where(p => p.userid == userid).FirstOrDefault<user>();
                // get the department object from user model
                dept = u.department;
                // convert DB Model to API Model
                dm = CovertDBDepttoAPIDept(dept);
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
        public static List<DepartmentModel> GetDepartmentsByCpid(int cpid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<departmentcollectionpoint> cps = new List<departmentcollectionpoint>();
            List<DepartmentModel> dms = new List<DepartmentModel>();
            try
            {
                cps = entities.departmentcollectionpoints.Where(p => p.cpid == cpid).ToList<departmentcollectionpoint>();
                foreach(departmentcollectionpoint cp in cps)
                {
                    dms.Add(CovertDBDepttoAPIDept(cp.department));
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
            return dms;
        }
        public static DepartmentModel GetDepartmentByReqid(int reqid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            department dept = new department();
            requisition req = new requisition();
            DepartmentModel dm = new DepartmentModel();
            try
            {
                req = entities.requisitions.Where(p => p.reqid == reqid).FirstOrDefault<requisition>();
                dept = req.department;
                dm = CovertDBDepttoAPIDept(dept);
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
        public static DepartmentModel UpdateDepartment(DepartmentModel dm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            department d = new department();
            try
            {
                // finding the department object using Department API model
                d = entities.departments.Where(p => p.deptid == dm.Deptid).First<department>();

                // transfering data from API model to DB Model
                d.deptname = dm.Deptname;
                d.deptcontactname = dm.Deptcontactname;
                d.deptphone = dm.Deptphone;
                d.deptemail = dm.Deptemail;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                dm = CovertDBDepttoAPIDept(d);
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
        public static DepartmentModel CreateDepartment(DepartmentModel dm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            department d = new department();
            try
            {
                d.deptname = dm.Deptname;
                d.deptcontactname = dm.Deptcontactname;
                d.deptphone = dm.Deptphone;
                d.deptemail = dm.Deptemail;
                d = entities.departments.Add(d);
                entities.SaveChanges();
                dm = CovertDBDepttoAPIDept(d);
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
        public static DepartmentCollectionPointModel GetDepartmentCollectionPointByDcpID(int dcpid, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            departmentcollectionpoint dcp = new departmentcollectionpoint();
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel();
            try
            {
                dcp = entities.departmentcollectionpoints.Where(p => p.deptcpid == dcpid).FirstOrDefault<departmentcollectionpoint>();
                dcpm = CovertDBDCPtoAPIDCP(dcp);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dcpm;
        }
        public static DepartmentCollectionPointModel GetActiveDepartmentCollectionPointByDeptID(int deptid, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            departmentcollectionpoint dcp = new departmentcollectionpoint();
            DepartmentCollectionPointModel dcpm = new DepartmentCollectionPointModel();
            try
            {
                dcp = entities.departmentcollectionpoints.Where(p => p.deptid == deptid && p.status == ConDepartmentCollectionPoint.Status.ACTIVE).FirstOrDefault<departmentcollectionpoint>();
                dcpm = CovertDBDCPtoAPIDCP(dcp);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dcpm;
        }
        public static List<DepartmentCollectionPointModel> GetDepartmentCollectionPointsByStatus(int status, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            List<departmentcollectionpoint> dcps = new List<departmentcollectionpoint>();
            List<DepartmentCollectionPointModel> dcpms = new List<DepartmentCollectionPointModel>();

            try
            {
                dcps = entities.departmentcollectionpoints.Where(p => p.status == status).ToList<departmentcollectionpoint>();
                // return the updated model
                foreach(departmentcollectionpoint dcp in dcps)
                {
                    dcpms.Add(CovertDBDCPtoAPIDCP(dcp));
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
            return dcpms;
        }
        public static DepartmentCollectionPointModel AddDepartmentCollectionPoint(DepartmentCollectionPointModel dcpm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            try
            {

                departmentcollectionpoint dcp = new departmentcollectionpoint
                {
                    deptid = dcpm.DeptID,
                    cpid = dcpm.CpID,
                    status = dcpm.Status
                };
                entities.departmentcollectionpoints.Add(dcp);

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                dcpm = GetDepartmentCollectionPointByDcpID(dcp.deptcpid, out error);

                NotificationModel nom = new NotificationModel();
                nom.Deptid = 11;
                nom.Role = ConUser.Role.CLERK;
                nom.Title = "Collection Point Request";
                nom.NotiType = ConNotification.NotiType.CollectionPointChangeRequestApproval;
                nom.ResID = dcpm.DeptCpID;
                nom.Remark = "The new collection point change has been requested!";
                nom = NotificationRepo.CreatNotification(nom, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return dcpm;
        }
        public static DepartmentCollectionPointModel UpdateDepartmentCollectionPoint(DepartmentCollectionPointModel dcpm, out string error)
        {
            error = "";
            // declare and initialize new LUSSISEntities to perform update
            LUSSISEntities entities = new LUSSISEntities();
            departmentcollectionpoint dcp = new departmentcollectionpoint();
            try
            {
                dcp = entities.departmentcollectionpoints.Where(p => p.deptcpid == dcpm.DeptCpID).FirstOrDefault<departmentcollectionpoint>();

                dcp.deptid = dcpm.DeptID;
                dcp.cpid = dcpm.CpID;
                dcp.status = dcpm.Status;
                // saving the update
                entities.SaveChanges();

                // return the updated model 
                dcpm = GetDepartmentCollectionPointByDcpID(dcp.deptcpid, out error);

                if(dcpm.Status == ConDepartmentCollectionPoint.Status.ACTIVE)
                {
                    NotificationModel nom = new NotificationModel();
                    nom.Deptid = dcpm.DeptID;
                    nom.Role = ConUser.Role.HOD;
                    nom.Title = "Approved Collection Point";
                    nom.NotiType = ConNotification.NotiType.ClerkApprovedCollectionPointChange;
                    nom.ResID = dcpm.DeptCpID;
                    nom.Remark = "The new collection point change request has been approved by the store";
                    nom = NotificationRepo.CreatNotification(nom, out error);

                }
                else if(dcpm.Status == ConDepartmentCollectionPoint.Status.REJECTED)
                {
                    NotificationModel nom = new NotificationModel();
                    nom.Deptid = dcpm.DeptID;
                    nom.Role = ConUser.Role.HOD;
                    nom.Title = "Rejected Collection Point";
                    nom.NotiType = ConNotification.NotiType.ClerkRejectedCollectionPointChange;
                    nom.ResID = dcpm.DeptCpID;
                    nom.Remark = "The new collection point change request has been rejected by the store";
                    nom = NotificationRepo.CreatNotification(nom, out error);

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
            return dcpm;
        }
    }
}