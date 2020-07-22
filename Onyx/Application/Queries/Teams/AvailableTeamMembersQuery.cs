using Domain.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Teams;

namespace Application.Queries.Teams
{
    public class AvailableTeamMembersQuery 
    {
        public class Query : IRequest<List<TeamMembersViewModel>>
        {
            public string TeamId { get; set; }
            public bool IsCoach { get; set; }
            public string OrgId { get; set; }

            public Query(string teamId, string orgId, bool isCoach)
            {
                this.TeamId = teamId;
                this.IsCoach = isCoach;
                this.OrgId = orgId;
            }
        }

        public class Handler : IRequestHandler<Query, List<TeamMembersViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            private async Task<List<TeamMembersViewModel>> AvailableMembers(string teamId, string orgId, UserType type)
            {
                IQueryable<string> currentCoaches = null;
                IQueryable<AppUser> query = context.Users
                    .Where(x => x.OrganizationId == orgId)
                    .Where(x => x.IsActive)
                    .Where(x => x.UserType == type);
                
                if(!string.IsNullOrEmpty(teamId))
                {
                    currentCoaches = context.AssignedTeams
                        .Include(x => x.User)
                        .Where(x => x.TeamId == teamId)
                        .Where(x => x.User.UserType == type)
                        .Where(x => x.User.IsActive)
                        .Select(x => x.UserId);
                    
                    return  await query
                    .Where(x => !currentCoaches.Contains(x.Id))
                    .Select(x => new TeamMembersViewModel
                    {
                        Gender = x.Gender,
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToListAsync();
                }

                return await query
                    .Select(x => new TeamMembersViewModel
                    {
                        Gender = x.Gender,
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToListAsync();
            }

            public async Task<List<TeamMembersViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                if(request.IsCoach)
                {
                    return await AvailableMembers(request.TeamId, request.OrgId, UserType.Coach);
                } else
                {
                    return await AvailableMembers(request.TeamId, request.OrgId, UserType.Athlete);
                }
            }
        }
       
    }


}
