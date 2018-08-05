using System;
using System.Threading.Tasks;
using System.Web.Http;
using LUSSISADTeam10API.Authorization;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

// Author : Zin Min Htet

[assembly: OwinStartup(typeof(LUSSISADTeam10API.Startup))]
namespace LUSSISADTeam10API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var myProvider = new AuthorizationServiceProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(10),
                Provider = myProvider
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

        }
    }
}
