using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LUSSISADTeam10API.Models.DBModels;


namespace LUSSISADTeam10API.Controllers
{
    // to allow access only by login user
    [Authorize]
    public class UserController : ApiController
    {

        // To show user list
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetAllUsers()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";
            // get the list from userrepo and will insert the error if there is one
            List<UserModel> usr = UserRepo.GetAllUsers();

            // if the erorr is not blank or the user list is null
            if (error != "" || usr == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(usr);
        }
        // to get user by user id
        [HttpGet]
        [Route("api/user/{userid}")]
        public IHttpActionResult GetUserByUserid(int userid)
        {
            string error = "";
            UserModel usr = UserRepo.GetUserByUserID(userid);
            if (error != "" || usr == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(usr);
        }


        [HttpGet]
        [Route("api/user/role/{role}/{deptid}")]
        public IHttpActionResult GetUserByRole(int role,int deptid)
        {
            string error = "";
            List<UserModel> usm = UserRepo.GetUserByRoleandDeptid(role,deptid, out error);
            if (error != "" || usm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(usm);
        }


        [HttpGet]
        [Route("api/user/department/{depid}")]
        public IHttpActionResult GetUserByDepid(int depid)
        {
            string error = "";
            
            List<UserModel> usm = UserRepo.GetUserByDeptid(depid, out error);
            if (error != "" || usm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(usm);
        }


        // new
        [HttpGet]
        [Route("api/user/hod/{deptid}")]
        public IHttpActionResult GetUsersForHOD(int deptid)
        {
            string error = "";
            List<UserModel> usm = UserRepo.GetUsersForHOD(deptid, out error);
            if (error != "" || usm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(usm);
        }
        [HttpPost]
        [Route("api/user/assign/{userid}")]
        public IHttpActionResult AssignDepartmentRep(int userid)
        {
            string error = "";
            UserModel usm = UserRepo.AssignDepRep( userid);
            if (error != "" || usm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(usm);
        }


    }
}
