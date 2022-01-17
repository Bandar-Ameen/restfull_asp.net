
using AstoolTechRestFullAPI.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AstoolTechRestFullAPI.Controllers
{
    public class baciAthuntication: AuthorizationFilterAttribute
    {
        public override  void OnAuthorization(HttpActionContext context)
        {

            string hashedTokenId =  context.Request.Headers.GetValues("bandar").First(); 
            ClientMaster__Rf client = (new ClientMasterRepository()).ValidateClient(hashedTokenId);
            if (!string.IsNullOrEmpty(client.ClientSecret.ToString()))
            {

                if (!client.Active)
                {
                    context.Response = context.Request
                       .CreateResponse(System.Net.HttpStatusCode.NotFound);
                }
                else
                {
                    context.Response = context.Request
                      .CreateResponse(System.Net.HttpStatusCode.OK);
                }
            }
            else
            {
                context.Response = context.Request
                      .CreateResponse(System.Net.HttpStatusCode.NoContent);
            }
                //   string hashedTokenId = Helper.GetHash(context.Token);
                /* using (AuthenticationRepository _repo = new AuthenticationRepository())
                 {
                     var refreshToken = await _repo.FindRefreshToken(hashedTokenId);
                     if (refreshToken != null)
                     {
                         Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(refreshToken.ProtectedTicket), null);
                     }
                 }*/
            }
    }
}