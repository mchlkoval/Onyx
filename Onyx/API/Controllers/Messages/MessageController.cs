using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Messages
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        [Authorize]
        [HttpGet]
        [Route("messages")]
        public async Task<ActionResult<List<Message>>> ListMessages(CancellationToken ct)
        {
            return await Mediator.Send(new MessageQuery.Query(), ct);
        }
    }
}