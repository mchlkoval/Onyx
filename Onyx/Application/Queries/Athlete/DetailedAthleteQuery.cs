using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Athlete;

namespace Application.Queries.Athlete
{
    public class DetailedAthleteQuery
    {
        public class Query : IRequest<DetailedAthleteViewModel>
        {
            public string Id { get; set; }

            public Query(string id)
            {
                this.Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, DetailedAthleteViewModel>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<DetailedAthleteViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var athlete = await context.Users
                    .Include(x => x.AssignedCoaches)
                    .Where(x => x.Id == request.Id)
                    .Select(x => new DetailedAthleteViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Gender = x.Gender,
                        City = x.City,
                        State = x.State,
                        Country = x.Country,
                        Address = x.Address,
                        Address2 = x.Address2,
                        Weight = x.Weight,
                        Age = x.Age,
                        DateOfBirth = x.DateOfBirth,
                        AssignedCoaches = x.AssignedCoaches.Select(y => new AssignedCoachViewModel
                        {
                            Id = y.CoachId,
                            Name = y.Coach.Name,
                            Gender = y.Coach.Gender
                        })
                    }).SingleAsync();

                return athlete;
            }
        }
    }
}
