﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Athletes;
using Application.Commands.General;
using Application.Queries.Athlete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Route("athletes/{active}")]
        public async Task<ActionResult<List<ListAthleteViewModel>>> ListAthletes(bool active, CancellationToken ct)
        {
            return await Mediator.Send(new ListAthletesQuery.Query(active), ct);
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DetailedAthleteViewModel>> LoadAthlete(string id, CancellationToken ct)
        {
            return await Mediator.Send(new DetailedAthleteQuery.Query(id), ct);
        }

        [Authorize]
        [HttpPut]
        [Route("archive/{athleteId}")]
        public async Task<ActionResult<Unit>> DeactivateAthlete(string athleteId, CancellationToken ct)
        {
            return await Mediator.Send(new UpdateAthleteStatusCommand.Command(athleteId, false), ct);
        }

        [Authorize]
        [HttpPut]
        [Route("reactivate/{athleteId}")]
        public async Task<ActionResult<Unit>> ActivateStudent(string athleteId, CancellationToken ct)
        {
            return await Mediator.Send(new UpdateAthleteStatusCommand.Command(athleteId, true), ct);
        }

        [Authorize]
        [HttpPut]
        [Route("edit")]
        public async Task<ActionResult<Unit>> EditAthlete(CreateEditAthleteCommand.Command command, CancellationToken ct)
        {
            return await Mediator.Send(command, ct);
        }

        [Authorize]
        [HttpPost]
        [Route("message")]
        public async Task<ActionResult<Unit>> MessageAthlete(MessageCommand.Command command, CancellationToken ct)
        {
            return await Mediator.Send(command, ct);
        }

        [Authorize]
        [HttpPost]
        [Route("message/all")]
        public async Task<ActionResult<Unit>> MessageAllAthletes(MessageAllCommand.Command command, CancellationToken ct)
        {
            return await Mediator.Send(command, ct);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Unit>> CreateEditAthlete(CreateEditAthleteCommand.Command command, CancellationToken ct)
        {
            return await Mediator.Send(command, ct);
        }

        [Authorize]
        [HttpGet]
        [Route("availableCoaches/{athleteId}")]
        public async Task<ActionResult<List<AssignedCoachViewModel>>> ListAvailableCoaches(string athleteId, CancellationToken ct)
        {
            return await Mediator.Send(new ListAvailableCoachesQuery.Query(athleteId), ct);
        }
    }
}