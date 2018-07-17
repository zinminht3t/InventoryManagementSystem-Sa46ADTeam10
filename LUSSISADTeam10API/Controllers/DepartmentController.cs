using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LUSSISADTeam10API.Controllers
{
    // to allow access only by login user
    [Authorize]
    public class DepartmentController : ApiController
    {
        // to show department list
        [HttpGet]
        [Route("api/departments")]
        public IHttpActionResult GetAllDepartments()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from departmentrepo and will insert the error if there is one
            List<DepartmentModel> dms = DepartmentRepo.GetAllDepartments(out error);

            // if the erorr is not blank or the department list is null
            if (error != "" || dms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Departments Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(dms);

        }

        // to get department by department id
        [HttpGet]
        [Route("api/department/{deptid}")]
        public IHttpActionResult GetDepartmentByDeptid(int deptid)
        {
            string error = "";
            DepartmentModel dm = DepartmentRepo.GetDepartmentByDeptid(deptid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Department Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }

        // to get department by user id
        [HttpGet]
        [Route("api/department/user/{userid}")]
        public IHttpActionResult GetDepartmentByUserid(int userid)
        {
            string error = "";
            DepartmentModel dm = DepartmentRepo.GetDepartmentByUserid(userid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }

        // to get department by collection point id
        [HttpGet]
        [Route("api/department/collectionpoint/{cpid}")]
        public IHttpActionResult GetDepartmentsByCpid(int cpid)
        {
            string error = "";
            List<DepartmentModel> dms = DepartmentRepo.GetDepartmentsByCpid(cpid, out error);
            if (error != "" || dms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Collection Point Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dms);
        }

        // to get department by requisition id
        [HttpGet]
        [Route("api/department/requisition/{reqid}")]
        public IHttpActionResult GetDepartmentByReqid(int reqid)
        {
            string error = "";
            DepartmentModel dm = DepartmentRepo.GetDepartmentByReqid(reqid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Requisition Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }

        // to update department
        [HttpPost]
        [Route("api/department/update")]
        public IHttpActionResult UpdateDepartment(DepartmentModel dept)
        {
            string error = "";
            DepartmentModel dm = DepartmentRepo.UpdateDepartment(dept, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Department Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }



        // to update department collection point
        //[HttpPost]
        //[Route("api/department/collectionpoint/update")]
        //public IHttpActionResult UpdateDepartmentCollectionPoint(DepartmentCollectionPointModel dcpm)
        //{
        //    string error = "";
        //    DepartmentModel dm = DepartmentRepo.UpdateDepartmentCollectionPoint(dcpm, out error);
        //    if (error != "" || dm == null)
        //    {
        //        if (error == ConError.Status.NOTFOUND)
        //        {
        //            return Content(HttpStatusCode.NotFound, "Department or Collection Point Not Found");
        //        }
        //        return Content(HttpStatusCode.BadRequest, error);
        //    }
        //    return Ok(dm);
        //}

        // to create new department
        [HttpPost]
        [Route("api/department/create")]
        public IHttpActionResult CreateDepartment(DepartmentModel dept)
        {
            string error = "";
            DepartmentModel dm = DepartmentRepo.CreateDepartment(dept, out error);
            if (error != "" || dm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }

    }
}
