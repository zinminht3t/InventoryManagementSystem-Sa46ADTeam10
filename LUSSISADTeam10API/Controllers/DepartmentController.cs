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
    [Authorize]
    public class DepartmentController : ApiController
    {
        [HttpGet]
        [Route("api/departments")]
        public IHttpActionResult GetAllDepartments()
        {
            string error = "";
            List<DepartmentModel> dms = DepartmentRepo.GetAllDepartments(out error);
            if (error != "" || dms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Departments Not Found");
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dms);

        }

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

        [HttpGet]
        [Route("api/department/collectionpoint/{cpid}")]
        public IHttpActionResult GetDepartmentByCpid(int cpid)
        {
            string error = "";
            DepartmentModel dm = DepartmentRepo.GetDepartmentByCpid(cpid, out error);
            if (error != "" || dm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Collection Point Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(dm);
        }

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
