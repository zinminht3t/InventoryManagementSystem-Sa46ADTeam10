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
    [Authorize]
    public class AccountController : ApiController
    {
        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            UserModel um = UserRepo.GetUserByUserID(Convert.ToInt32(identity.FindFirst(ClaimTypes.NameIdentifier).Value));
            return Ok(um);
        }

        [HttpPost]
        [Route("api/user/update")]
        public IHttpActionResult UpdateUser(UserModel um)
        {
            um = UserRepo.UpdateUser(um);
            return Ok(um);
        }

    }
}
