using System.Collections.Generic;
using System.Threading.Tasks;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Response;
using CNX.Contracts.Entities;

namespace CNX.Contracts.Interfaces
{
    public interface IUserService
    {
        UserDto GetById(int id);
        IEnumerable<UserModel> GetAll();
        UserDto GetByEmail(string username);
        Task<NewUserAddedResponseDto> Create(UserDto dto);
    }
}
