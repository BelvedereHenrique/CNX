using System.Collections.Generic;
using System.Threading.Tasks;
using CNX.Contracts.Entities;

namespace CNX.Contracts.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel GetByEmail(string email);
        Task<UserModel> CreateAsync(UserModel model);
    }
}
