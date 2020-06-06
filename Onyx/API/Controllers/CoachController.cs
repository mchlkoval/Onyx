using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Coach;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Coach;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : BaseController
    {
        [Authorize]
        [HttpGet]
        [Route("coaches/{active}")]
        public async Task<ActionResult<List<ListCoachViewModel>>> ListCoaches(bool active, CancellationToken ct)
        {
            return await Mediator.Send(new ListCoachesQuery.Query(active), ct);
        }
    }
}