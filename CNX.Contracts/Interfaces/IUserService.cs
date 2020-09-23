using System.Threading.Tasks;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Response;

namespace CNX.Contracts.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByEmailAsync(string username);
        Task<NewUserAddedResponseDto> Create(UserDto dto);
        Task UpdatePassword(int userId, string newPassword);

    }
}
