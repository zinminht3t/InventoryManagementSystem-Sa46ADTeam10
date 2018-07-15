using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace LUSSISADTeam10API.Authorization
{
    public class AuthorizationServiceProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            UserModel u = UserRepo.ValidateUser(context.UserName, context.Password);

            if (u.Role == 0)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, u.Username));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, u.Userid.ToString()));
                context.Validated(identity);
            }
            else if (u.Role == 1)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, u.Username));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, u.Userid.ToString()));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Invalid Credentials", "Wrong username or password");
            }
        }
    }
}