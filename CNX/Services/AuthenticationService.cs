using System;
using AutoMapper;
using CNX.Contracts.DTO;
using CNX.Contracts.Interfaces;
using CNX.Repositories;

namespace CNX.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public UserAuthenticationResponseDto Authenticate(string username, string password)
        {

            var user = _userService.GetByParameters(username);

            if (user == null)
                throw new UnauthorizedAccessException("Usuário ou senha inválidos");

            var token = TokenService.GenerateToken(user.Username);

            user.Password = "";

            return new UserAuthenticationResponseDto(user.Username, token);
        }
    }
}
