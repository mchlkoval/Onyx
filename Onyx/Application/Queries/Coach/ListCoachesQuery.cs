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
using ViewModels.Coach;

namespace Application.Queries.Coach
{
    public class ListCoachesQuery
    {
        public class Query : IRequest<List<ListCoachViewModel>>
        {
            public bool IsActive { get; set; }

            public Query(bool isActive)
            {
                this.IsActive = isActive;
            }
        }

        public class Handler : IRequestHandler<Query, List<ListCoachViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<ListCoachViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await context.Users.Where(x => x.IsActive == request.IsActive
                    && x.UserType == UserType.Coach)
                    .Select(x => new ListCoachViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        DateArchived = x.DateArchived,
                        DateHired = x.DateJoined,
                        IsActive = x.IsActive
                    }).ToListAsync();

                return data;
            }
        }
    }

}
