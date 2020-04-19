using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Users
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login()
        {
            return null;
        }
    }
}
