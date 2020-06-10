using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Coach;
using Application.Queries.Coach;
using MediatR;
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

        [Authorize]
        [HttpGet]
        [Route("detail/{id}")]
        public async Task<ActionResult<DetailedCoachViewModel>> LoadCoach(string id, CancellationToken ct)
        {
            return await Mediator.Send(new DetailedCoachQuery.Query(id), ct);
        }

        [Authorize]
        [HttpGet]
        [Route("archive/{id}")]
        public async Task<ActionResult<Unit>> ArchiveCoach(string id, CancellationToken ct)
        {
            return await Mediator.Send(new UpdateCoachStatusCommand.Command(id, false), ct);
        }

        [Authorize]
        [HttpGet]
        [Route("activate/{id}")]
        public async Task<ActionResult<Unit>> ActivateCoach(string id, CancellationToken ct)
        {
            return await Mediator.Send(new UpdateCoachStatusCommand.Command(id, true), ct);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateCoach(DetailedCoachViewModel vm, CancellationToken ct)
        {
            return null;
        }

        [Authorize]
        [HttpPut]
        [Route("edit")]
        public async Task<ActionResult<Unit>> EditCoach(CreateEditCoachCommand.Command command, CancellationToken ct)
        {
            return await Mediator.Send(command, ct);
        }

        [Authorize]
        [HttpGet]
        [Route("availableStudents/{id}")]
        public async Task<ActionResult> AvailableStudentsToAssign(string id, CancellationToken ct)
        {
            return null;
        }

    }
}