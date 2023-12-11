using AuthTokenManual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthWithToken.UserRepository
{
    public class UserRepo : IDisposable
    {
        TokenAuthEntities dbContext = new TokenAuthEntities();
        public User ValidateUser(string username, string password)
        {
            return dbContext.Users.FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}