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
using ViewModels.Athlete;

namespace Application.Queries.Athlete
{
    public class ListAvailableCoachesQuery
    {
        public class Query : IRequest<List<AssignedCoachViewModel>>
        {
            public string Id { get; set; }

            public Query(string id)
            {
                this.Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, List<AssignedCoachViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<AssignedCoachViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await context.Users
                    .Include(x => x.AssignedAthletes)
                    .Where(x => x.IsActive)
                    .Where(x => x.UserType == UserType.Coach)
                    .Where(x => !x.AssignedAthletes.Select(z => z.AthleteId).Contains(request.Id))
                    .Select(x => new AssignedCoachViewModel { 
                        Id = x.Id,
                        Name = x.Name,
                        Gender = x.Gender
                     }).ToListAsync();                  

                return data;
            }
        }
    }
}
