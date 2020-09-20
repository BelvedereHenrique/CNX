using System;
using CNX.Contracts.DTO;
using CNX.Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNX.Controllers
{
    [Authorize]
    [Route("v1/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<UserAuthenticationResponseDto> Authenticate([FromBody] UserAuthenticationRequestDto userRequest)
        {
            try
            {
                return _authService.Authenticate(userRequest.Username, userRequest.Password);
            }
            catch (UnauthorizedAccessException e)
            {
                return BadRequest($"Usuário ou senha inválidos: {e.Message}");
            }
            catch (Exception e)
            {
                return Problem($"Houve um erro na requisição: {e.Message}");
            }
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"{User.Identity.Name}";

    }
}
