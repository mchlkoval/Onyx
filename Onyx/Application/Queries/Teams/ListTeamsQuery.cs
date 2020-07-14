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

namespace Application.Queries.Teams
{
    public class ListTeamsQuery
    {
        public class Query : IRequest<List<TeamsViewModel>>
        {
            public string OrganizationId { get; set; }

            public Query(string orgId)
            {
                this.OrganizationId = orgId;
            }
        }

        public class Handler : IRequestHandler<Query, List<TeamsViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<TeamsViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await context.Teams
                    .Include(x => x.TeamMembers)
                    .Where(x => x.OrganizationId == request.OrganizationId)
                    .Select(x => new TeamsViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ArchiveDate = x.ArchiveDate,
                        CreationDate = x.CreationDate,
                        IsActive = x.IsActive,
                        Athletes = null
                    }).ToListAsync();

                return data;
            }
        }
    }
}
