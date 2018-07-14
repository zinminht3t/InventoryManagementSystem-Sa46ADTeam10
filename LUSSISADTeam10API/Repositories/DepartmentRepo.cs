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
        private static LUSSISEntities entities = new LUSSISEntities();
        private static DepartmentModel CovertDBDepttoAPIDept(department dept)
        {
            DepartmentModel dm = new DepartmentModel(dept.deptid, dept.deptname, dept.deptcontactname, dept.deptphone, dept.deptemail);
            return dm;
        }
        public static List<DepartmentModel> GetAllDepartments(out string error)
        {
            error = "";
            List<DepartmentModel> dms = new List<DepartmentModel>();
            try
            {
                List<department> depts = entities.departments.ToList<department>();
                foreach (department dept in depts)
                {
                    dms.Add(CovertDBDepttoAPIDept(dept));
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
        public static DepartmentModel GetDepartmentByDeptid(int deptid, out string error)
        {
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
            error = "";

            department dept = new department();
            user u = new user();
            DepartmentModel dm = new DepartmentModel();
            try
            {
                u = entities.users.Where(p => p.userid == userid).FirstOrDefault<user>();
                dept = u.department;
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
        public static DepartmentModel GetDepartmentByCpid(int cpid, out string error)
        {
            error = "";

            department dept = new department();
            departmentcollectionpoint cp = new departmentcollectionpoint();
            DepartmentModel dm = new DepartmentModel();
            try
            {
                cp = entities.departmentcollectionpoints.Where(p => p.cpid == cpid).FirstOrDefault<departmentcollectionpoint>();
                dept = cp.department;
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
        public static DepartmentModel GetDepartmentByReqid(int reqid, out string error)
        {
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
            LUSSISEntities entities = new LUSSISEntities();
            department d = new department();
            try
            {
                d = entities.departments.Where(p => p.deptid == dm.deptid).First<department>();
                d.deptname = dm.deptname;
                d.deptcontactname = dm.deptcontactname;
                d.deptphone = dm.deptphone;
                d.deptemail = dm.deptemail;
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