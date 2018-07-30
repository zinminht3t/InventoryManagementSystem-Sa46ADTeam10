using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.APIModels;
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

            List<DelegationModel> dm = new List<DelegationModel>();

            dm = DelegationRepo.GetDelegationByUserId(um.Userid, out string error);


            if (dm.Count > 0)
            {
                List<DelegationModel> ActiveDM = dm.Where(x => x.Startdate.Value.Date <= DateTime.Today.Date && x.Enddate.Value.Date >= DateTime.Today.Date && x.Active == ConDelegation.Active.ACTIVE).ToList();
                if (ActiveDM.Count > 0)
                {
                    foreach (DelegationModel d in ActiveDM)
                    {
                        if (um.Role == ConUser.Role.EMPLOYEEREP)
                        {
                            um.Role = ConUser.Role.TEMPHOD;
                            um = UserRepo.UpdateUser(um);
                        }
                    }
                }
                else
                {
                    List<DelegationModel> InActiveDM = dm.Where(x => x.Enddate.Value.Date < DateTime.Today.Date && x.Active == ConDelegation.Active.ACTIVE).ToList();
                    if (InActiveDM.Count > 0)
                    {
                        foreach (DelegationModel d in InActiveDM)
                        {
                            if (um.Role == ConUser.Role.TEMPHOD)
                            {
                                DelegationRepo.CancelDelegation(d, out error);
                                um = UserRepo.GetUserByUserID(Convert.ToInt32(identity.FindFirst(ClaimTypes.NameIdentifier).Value));
                            }

                        }
                    }
                }
            }



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
