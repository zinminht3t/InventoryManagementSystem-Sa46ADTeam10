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
using LUSSISADTeam10API.Repositories;
using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models;


namespace LUSSISADTeam10API.Controllers
{
    public class UserController : ApiController
    {
        // Start Taz
        // To show users
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetAllUsers()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from userrepo and will insert the error if there is one
            List<UserModel> usr = UserRepo.GetAllUser(out error);

            // if the erorr is not blank or the collectionpoint list is null
            if (error != "" || usr == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "User Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(usr);

        }
        // to get user by user id
        [HttpGet]
        [Route("api/user/{userid}")]
        public IHttpActionResult GetUserByUserid(int userid)
        {
            string error = "";
            UserModel usr = UserRepo.GetUserByUserid(userid, out error);
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
        // End Taz
        // Start Phyo2

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


      
        // End Phyo2


        // Start TAZ
        [HttpGet]
        [Route("api/user/depid/{depid}")]
        public IHttpActionResult GetRequisitionByDepid(int depid)
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

       
        // End TAZ
    }
}
