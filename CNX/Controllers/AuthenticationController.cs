using CNX.Contracts.DTO;
using CNX.Repositories;
using CNX.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNX.Controllers
{
    [Authorize]
    [Route("v1/authentication")]
    public class AuthenticationController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<UserAuthenticationResponseDto> Authenticate([FromBody] UserAuthenticationRequestDto userRequest)
        {
            var user = UserRepository.Get(userRequest.Username, userRequest.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new UserAuthenticationResponseDto(user.Username, token);
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"{User.Identity.Name}";

    }
}
