using Domain;
using Domain.JoinTables;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Teams;

namespace Application.Commands.Teams
{
    public class CreateEditTeamCommand
    {
        public class Command : TeamsViewModel, IRequest
        {

        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            private async Task EditTeam(Command request)
            {
                var team = await context.Teams.Include(x => x.TeamMembers)
                    .SingleAsync(x => x.Id == request.Id);

                team.Name = request.Name;
                team.IsActive = request.IsActive;
                team.CreationDate = request.CreationDate;
                team.ArchiveDate = request.ArchiveDate;
                team.TeamMembers = request.Athletes.Union(request.Coaches).Select(x => new UserTeam
                {
                    TeamId = team.Id,
                    UserId = x.Id
                }).ToList();

                

                context.Teams.Update(team);
                var result = await context.SaveChangesAsync();

                if (result < 0)
                {
                    throw new Exception("Failed to update team");
                }
            }

            private async Task CreateTeam(Command request)
            {
                var team = new Team();
                team.Id = Guid.NewGuid().ToString();
                team.OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67";
                team.Name = request.Name;
                team.IsActive = request.IsActive;
                team.CreationDate = request.CreationDate;
                team.ArchiveDate = request.ArchiveDate;

                if(request.Athletes == null)
                {
                    request.Athletes = new List<TeamMembersViewModel>();
                }

                if(request.Coaches == null)
                {
                    request.Coaches = new List<TeamMembersViewModel>();
                }

                team.TeamMembers = request.Athletes.Union(request.Coaches).Select(x => new UserTeam
                {
                    TeamId = team.Id,
                    UserId = x.Id
                }).ToList();

                context.Teams.Add(team);
                var result = await context.SaveChangesAsync();

                if (result < 0)
                {
                    throw new Exception("Failed to create team");
                }

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!string.IsNullOrEmpty(request.Id))
                {
                    await EditTeam(request);
                } else
                {
                    await CreateTeam(request);
                }

                return Unit.Value;
            }
        }
    }
}
