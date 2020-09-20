using System.Collections.Generic;
using CNX.Contracts.DTO;
using CNX.Contracts.Entities;

namespace CNX.Contracts.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
        UserDto GetByParameters(string username);
    }
}
