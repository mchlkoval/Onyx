using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : BaseController
    {
        [HttpGet]
        [Authorize]
        [Route("exercisegroups")]
        public async Task<ActionResult> GetExerciseGroups(CancellationToken ct)
        {
            return null;
        }
    }
}