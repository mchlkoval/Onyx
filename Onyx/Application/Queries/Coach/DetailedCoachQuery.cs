using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Coach;

namespace Application.Queries.Coach
{
    public class DetailedCoachQuery
    {
        public class Query : IRequest<DetailedCoachViewModel>
        {
            public string Id { get; set; }

            public Query(string id)
            {
                this.Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, DetailedCoachViewModel>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }


            public async Task<DetailedCoachViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await context.Users.Where(x => x.Id == request.Id)
                    .Select(x => new DetailedCoachViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Gender = x.Gender,
                        DateHired = x.DateJoined,
                        DateOfBirth = x.DateOfBirth,
                        City = x.City,
                        State = x.State,
                        Address = x.Address,
                        Address2 = x.Address,
                        Country = x.Country,
                        Email = x.Email,
                        AssignedAthletes = x.AssignedAthletes.Select(x => new AssignedAthletesViewModel {
                            AthleteId = x.Athlete.Id,
                            Gender = x.Athlete.Gender,
                            DateJoined = x.Athlete.DateJoined,
                            Name = x.Athlete.Name
                        })
                    }).FirstOrDefaultAsync();

                return data;
            }
        }
    }
}
