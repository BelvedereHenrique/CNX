using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNX.Contracts.Entities;
using CNX.Contracts.Interfaces;

namespace CNX.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>()
                {
                        new User {Id = 1, Username = "teste1", Password = "teste1pwd"},
                        new User {Id = 2, Username = "teste2", Password = "teste2"}
                };
        }

        public User Get(string username, string password)
        {
            return _users.FirstOrDefault(x => string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase) && x.Password == password);
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByParameters(string username)
        {
            return _users.Where(x => string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
