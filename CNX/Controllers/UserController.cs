using System;
using System.Threading.Tasks;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Response;
using CNX.Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNX.Controllers
{
    [Authorize]
    [Route("v1/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get user data based on the Id provided.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("{id}")]
        public async Task<UserDto> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return user;
        }

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// All fields are required, except by the notes.
        /// 
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        "name": "User Name",
        ///        "email": "user.email@domain.com",
        ///        "password": "userpassword",
        ///        "hometown": "User Hometown",
        ///        "notes": [
        ///             {"content":"note 1"},
        ///             {"content":"note 2"},
        ///             {"content":"note 3"}
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Created</response>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<NewUserAddedResponseDto>> Post([FromBody] UserDto dto)
        {
            try
            {
                return await _userService.Create(dto);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
