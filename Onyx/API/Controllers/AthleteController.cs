using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Athlete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Athlete;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController : BaseController
    {
        [Authorize]
        [HttpGet]
        [Route("{active}")]
        public async Task<ActionResult<List<ListAthleteViewModel>>> ListAthletes(bool active, CancellationToken ct)
        {
            var converted = active.ToString().ToLower() == "true" ? true : false;
            return await Mediator.Send(new ListAthletesQuery.Query(converted), ct);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> DeactivateAthlete(string athleteId)
        {
            return null;
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> ActivateStudent(string athleteId)
        {
            return null;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> MessageStudent()
        {
            return null;
        }

    }
}