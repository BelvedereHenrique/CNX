using System.Collections.Generic;
using System.Threading.Tasks;
using CNX.Contracts.Entities;

namespace CNX.Contracts.Interfaces
{
    public interface IUserRepository
    {
        User Get(int id);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetByParameters(string username);
    }
}
