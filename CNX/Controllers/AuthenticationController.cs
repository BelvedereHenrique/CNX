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
        /// <summary>
        /// Authenticate the user on the app.
        /// </summary>
        /// <param name="userRequest"></param>
        /// <remarks>
        /// Authentication uses JWT Tokens.
        /// 
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        "email": "your_email@domain.com",
        ///        "password": "your_password"
        ///     }
        ///
        /// </remarks>
        /// <returns>The user e-mail and token to use on next requests</returns>
        /// <response code="200">Authenticated</response>
        /// <response code="401">Unauthorized</response>     
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserAuthenticationResponseDto>> Authenticate([FromBody] UserAuthenticationRequestDto userRequest)
        {
            return await _authService.Authenticate(userRequest.Email, userRequest.Password);
        }

        /// <summary>
        /// Get the current token owner.
        /// </summary>
        [HttpPost]
        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"{User.Identity.Name}";

        /// <summary>
        /// Requests the user password reset.
        /// </summary>
        /// <param name="email"></param>
        /// <remarks>
        /// The password reset procedure will be sent to user e-mail
        /// </remarks>
        [HttpGet]
        [Route("reset")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string email)
        {
            await _authService.ResetPasswordRequestAsync(email);
            return Ok();
        }

        /// <summary>
        /// Confirms the user password reset.
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// The password will be reset if the hash is correct.
        ///
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///         "hash":"HASH",
        ///         "email":"your.email@domain.com",
        ///         "newpassword":"your_new_password"
        ///     }
        /// </remarks>
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
