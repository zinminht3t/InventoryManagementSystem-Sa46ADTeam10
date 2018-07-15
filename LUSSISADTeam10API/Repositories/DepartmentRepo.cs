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
                d = entities.departments.Where(p => p.deptid == dm.deptid).First<department>();

                // transfering data from API model to DB Model
                d.deptname = dm.deptname;
                d.deptcontactname = dm.deptcontactname;
                d.deptphone = dm.deptphone;
                d.deptemail = dm.deptemail;

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
                d.deptname = dm.deptname;
                d.deptcontactname = dm.deptcontactname;
                d.deptphone = dm.deptphone;
                d.deptemail = dm.deptemail;
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



    }
}