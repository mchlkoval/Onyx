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
    public class ListAthletesQuery
    {
        public class Query : IRequest<List<ListAthleteViewModel>>
        {
            public bool IsActive { get; set; }

            public Query(bool isActive)
            {
                this.IsActive = isActive;
            }
        }

        public class Handler : IRequestHandler<Query, List<ListAthleteViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<ListAthleteViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await context.Users.Where(x => x.IsActive == request.IsActive
                    && x.UserType == UserType.Athlete)
                    .Select(x => new ListAthleteViewModel
                    {
                         Id = x.Id,
                         DateArchived = x.DateArchived,
                         DateJoined = x.DateJoined,
                         Gender = x.Gender,
                         IsActive = x.IsActive,
                         Name = x.Name
                    })
                    .ToListAsync();
                
                return students;
            }
        }
    }
}
