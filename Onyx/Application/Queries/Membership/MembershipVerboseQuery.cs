using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Membership;

namespace Application.Queries.Membership
{
    public class MembershipVerboseQuery
    {
        public class Query : IRequest<MembershipVerboseViewModel>
        {
            public string MembershipId { get; set; }

            public Query(string membershipId)
            {
                this.MembershipId = membershipId;
            }
        }

        public class Handler : IRequestHandler<Query, MembershipVerboseViewModel>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<MembershipVerboseViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var initialFilter = await context.Memberships
                    .Include(x => x.Workout)
                    .ThenInclude(z => z.Exercises)
                    .Where(x => x.Id == request.MembershipId)
                    .ToListAsync();

                var vm = initialFilter.Select(x => new MembershipVerboseViewModel {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Cost = x.Cost,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Workouts = x.Workout.Select(z => new WorkoutViewModel
                    {
                        DateOfWorkout = z.DateOfWorkout,
                        Name = z.Name,
                        MinReps = z.MinReps,
                        MinSets = z.MinSets,
                        MinWeight = z.MinWeight,
                        Exercises = z.Exercises.Select(y => new ExerciseViewModel
                        {
                            Description = y.Description,
                            Name = y.Name,
                        })
                    })
                }).First();

                return vm;
            }
        }
    }
}
