using System;
using System.Collections.Generic;
using System.Linq;
using CNX.Contracts.Entities;

namespace CNX.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new User {Id = 1, Username = "teste1", Password = "teste1pwd"},
                new User {Id = 2, Username = "teste2", Password = "teste2"}
            };

            return users.FirstOrDefault(x => string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase) && x.Password == password);
        }
    }
}
