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
    public class ListAvailableStudentsQuery
    {
        public class Query : IRequest<List<AssignedAthletesViewModel>>
        {
            public string Id { get; set;}

            public Query(string id)
            {
                this.Id = id;
            }
        }

        public class Handler: IRequestHandler<Query, List<AssignedAthletesViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<AssignedAthletesViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await context.Users
                    .Include(x => x.AssignedCoaches)
                    .Where(x => !x.AssignedCoaches.Select(z => z.CoachId).Contains(request.Id))
                    .Where(x => x.UserType == UserType.Athlete)
                    .Where(x => x.IsActive)
                    .Select(x => new AssignedAthletesViewModel
                    {
                        AthleteId = x.Id,
                        DateJoined = x.DateJoined,
                        Gender = x.Gender,
                        Name = x.Name
                    })
                    .ToListAsync();

                return data;
            }
        }
    }
}
