using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace LUSSISADTeam10API.Controllers
{
    public class AccountController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            UserModel um = UserRepo.GetUserByUserID(Convert.ToInt32(identity.FindFirst(ClaimTypes.NameIdentifier).Value));
            return Ok(um);
        }

        [Authorize]
        [HttpPost]
        [Route("api/user/update")]
        public IHttpActionResult UpdateUser(UserModel um)
        {
            um = UserRepo.UpdateUser(um);
            return Ok(um);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetAllUsers()
        {
            var identity = (ClaimsIdentity)User.Identity;
            List<UserModel> ums = UserRepo.GetAllUsers();
            return Ok(ums);
        }

    }
}
