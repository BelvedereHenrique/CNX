using System;
using System.Threading.Tasks;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Request.Authentication;
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
        public async Task<ActionResult<UserAuthenticationResponseDto>> Authenticate([FromBody] UserAuthenticationRequestDto userRequest)
        {
            return await _authService.Authenticate(userRequest.Email, userRequest.Password);
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"{User.Identity.Name}";


        [HttpGet]
        [Route("reset")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string email)
        {
            await _authService.ResetPasswordRequestAsync(email);
            return Ok();
        }

        [HttpPost]
        [Route("reset/confirm")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmNewPassword([FromBody] ResetPasswordRequestDto dto)
        {
            await _authService.ResetPasswordConfirmAsync(dto);
            return Ok();
        }
    }
}
