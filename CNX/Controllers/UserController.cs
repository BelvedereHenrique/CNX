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

        [HttpGet]
        public UserDto Get()
        {
            return null;
        }

        [HttpGet]
        [Route("{id}")]
        public UserDto GetById(int id)
        {
            var user = _userService.GetById(id);
            user.Password = "";
            return user;
        }

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
