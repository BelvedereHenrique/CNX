using System.Collections.Generic;
using System.Threading.Tasks;
using CNX.Contracts.Entities;

namespace CNX.Contracts.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        Task<UserModel> GetById(int id);
        Task<UserModel> GetByEmail(string email);
        Task<UserModel> CreateAsync(UserModel model);
        Task UpdatePassword(int userId, string newPassword);
    }
}
