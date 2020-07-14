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
    public class DetailedTeamQuery
    {
        public class Query : IRequest<TeamsViewModel>
        {
            public string TeamId { get; set; }
            
            public Query(string id)
            {
                this.TeamId = id;
            }
        }

        public class Handler : IRequestHandler<Query, TeamsViewModel>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<TeamsViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var team = await context.Teams
                    .Include(x => x.TeamMembers)
                    .Where(x => x.Id == request.TeamId)
                    .Select(x => new TeamsViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ArchiveDate = x.ArchiveDate,
                        CreationDate = x.CreationDate,
                        IsActive = x.IsActive,
                        Athletes = x.TeamMembers.Where(x => x.User.UserType == UserType.Athlete)
                        .Select(z => new TeamMembersViewModel 
                        {
                            Id = z.User.Id,
                            Name = z.User.Name,
                            Gender = z.User.Gender,
                        }),
                        Coaches = x.TeamMembers.Where(x => x.User.UserType == UserType.Coach)
                        .Select(z => new TeamMembersViewModel 
                        {
                            Id = z.User.Id,
                            Name = z.User.Name,
                            Gender = z.User.Gender,
                        })
                    }).FirstAsync();
                
                return team;
            }
        }
    }
}
