using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Membership;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : BaseController
    {

        [Authorize]
        [HttpGet]
        [Route("memberships")]
        public async Task<ActionResult<List<MembershipOverviewViewModel>>> OverviewMemberships(CancellationToken ct)
        {
            return await Mediator.Send(new MembershipOverviewQuery.Query(), ct);
        }

        [Authorize]
        [HttpGet]
        [Route("memberships/full")]
        public async Task<ActionResult<List<MembershipVerboseViewModel>>> VerboseMemberships(CancellationToken ct)
        {
            return await Mediator.Send(new MembershipVerboseQuery.Query(), ct);
        }
    }
}