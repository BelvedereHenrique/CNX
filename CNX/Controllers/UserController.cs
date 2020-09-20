using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CNX.Contracts.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNX.Controllers
{
    [Authorize]
    [Route("v1/users")]
    public class UserController : Controller
    {
        public UserController()
        {
            
        }

        [AllowAnonymous]
        public User Get()
        {
            return null;
        }

    }
}
