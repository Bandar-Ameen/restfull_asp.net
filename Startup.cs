using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;

using System.Web.Http;
using AstoolTechRestFullAPI.customclass;

[assembly: OwinStartup(typeof(AstoolTechRestFullAPI.Startup))]

namespace AstoolTechRestFullAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable CORS (cross origin resource sharing) for making request using browser from different domains
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

        
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //The Path For generating the Toekn
                TokenEndpointPath = new PathString("/token"),
                //Setting the Token Expired Time (30 minutes)
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),//تحديد وقت إنتهاء الاكسس توكن
                //MyAuthorizationServerProvider class will validate the user credentials
                Provider = new MyAuthorizationServerProvider(),
                //For creating the refresh token and regenerate the new access token
                RefreshTokenProvider = new RefreshTokenProvider()
            };
            

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
