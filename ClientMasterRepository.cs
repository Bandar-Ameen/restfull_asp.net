
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AstoolTechRestFullAPI.Models
{
    public class ClientMasterRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        Models.orderapiEntities1 context = new Models.orderapiEntities1();
        //This method is used to check and validate the Client credentials
      
        //This method is used to check and validate the Client credentials
        public ClientMaster__Rf ValidateClient(string ClientID, string ClientSecret)
        {
            return context.ClientMaster__Rf.FirstOrDefault(user =>
             user.ClientID == ClientID
            && user.ClientSecret == ClientSecret);
        }

        public ClientMaster__Rf ValidateClient( string Clientname)
        {
            return context.ClientMaster__Rf.FirstOrDefault(user =>
             
             user.ClientID == Clientname);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}