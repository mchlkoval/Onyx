using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Teams;
using Application.Queries.Teams;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Teams;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : BaseController
    {
        [Authorize]
        [HttpGet]
        [Route("all/{orgId}")]
        public async Task<ActionResult<List<TeamsViewModel>>> GetTeams(string orgId, CancellationToken ct)
        {
            return await Mediator.Send(new ListTeamsQuery.Query(orgId), ct);
        }

        [Authorize]
        [HttpGet]
        [Route("detailed/{id}")]
        public async Task<ActionResult<TeamsViewModel>> GetDetailedTeam(string id, CancellationToken ct)
        {
            return await Mediator.Send(new DetailedTeamQuery.Query(id), ct);
        }

        [Authorize]
        [HttpGet]
        [Route("availableAthletes/{teamId}/{orgId}")]
        public async Task<ActionResult<List<TeamMembersViewModel>>> GetAvailableAthletesForTeam(string teamId, string orgId, CancellationToken ct)
        {
            return await Mediator.Send(new AvailableTeamMembersQuery.Query(teamId, orgId, false), ct);
        }

        [Authorize]
        [HttpGet]
        [Route("availableCoaches/{teamId}/{orgId}")]
        public async Task<ActionResult<List<TeamMembersViewModel>>> GetAvailableCoachesForTeam(string teamId, string orgId, CancellationToken ct)
        {
            return await Mediator.Send(new AvailableTeamMembersQuery.Query(teamId, orgId, true), ct);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Unit>> CreateTeam(CreateEditTeamCommand.Command command, CancellationToken ct)
        {
            return await Mediator.Send(command, ct);
        }

        [Authorize]
        [HttpPut]
        [Route("activate/{id}")]
        public async Task<ActionResult<Unit>> ActivateTeam(string id, CancellationToken ct)
        {
            return null;
        }

        [Authorize]
        [HttpPut]
        [Route("deactivate/{id}")]
        public async Task<ActionResult<Unit>> DeactivateTeam(string id, CancellationToken ct)
        {
            return null;
        }
    }
}