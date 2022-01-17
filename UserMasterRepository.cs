using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstoolTechRestFullAPI.Models
{
    public class UserMasterRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        Models.orderapiEntities1 context = new Models.orderapiEntities1();
        //This method is used to check and validate the user credentials
        public UserMaster ValidateUser(string username, string password)
        {
            return context.UserMaster.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}