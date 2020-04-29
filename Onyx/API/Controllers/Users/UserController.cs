using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Users
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserViewModel>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserViewModel>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> CurrentUser()
        {
            return await Mediator.Send(new LoggedUser.Query());
        }
    }
}
