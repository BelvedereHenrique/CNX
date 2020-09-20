using System;
using CNX.Contracts.DTO;
using CNX.Contracts.Interfaces;
using CNX.Utils;

namespace CNX.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public UserAuthenticationResponseDto Authenticate(string email, string password)
        {

            var user = _userService.GetByEmail(email);

            ValidatePassword(password, user);

            var token = TokenService.GenerateToken(user.Email);

            user.Password = "";

            return new UserAuthenticationResponseDto(user.Email, token);
        }

        private static void ValidatePassword(string password, UserDto userDto)
        {
            var comparePassword = EncryptionUtil.Encrypt(password);

            if (userDto == null || comparePassword != userDto.Password)
            {
                throw new UnauthorizedAccessException("Invalid e-mail or password");
            }
        }
    }
}
