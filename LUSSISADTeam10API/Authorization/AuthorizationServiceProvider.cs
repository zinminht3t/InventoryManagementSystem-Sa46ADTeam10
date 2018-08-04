using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

// Author : Zin Min Htet
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

            UserModel u = UserRepo.ValidateUser(context.UserName, HashPassword(context.Password));

            if (u == null)
            {
                context.SetError("Invalid Credentials", "Wrong username or password");
            }
            else
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, u.Username));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, u.Userid.ToString()));
                context.Validated(identity);
            }
        }

        public string HashPassword(string password)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}