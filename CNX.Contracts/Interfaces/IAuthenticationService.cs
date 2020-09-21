using System.Threading.Tasks;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Request.Authentication;

namespace CNX.Contracts.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserAuthenticationResponseDto> Authenticate(string email, string password);
        Task ResetPasswordRequestAsync(string email);
        Task ResetPasswordConfirmAsync(ResetPasswordRequestDto dto);
    }
}
