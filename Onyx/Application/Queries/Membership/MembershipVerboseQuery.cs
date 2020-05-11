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
        public class Query : IRequest<List<MembershipVerboseViewModel>>
        {

        }

        public class Handler : IRequestHandler<Query, List<MembershipVerboseViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<MembershipVerboseViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var initialFilter = await context.Memberships
                    .Include(x => x.Workout)
                    .ThenInclude(z => z.Exercises)
                    .ToListAsync();

                var vm = initialFilter.Select(x => new MembershipVerboseViewModel {
                    Description = x.Description,
                    Name = x.Name,
                    Id = x.Id,
                    Cost = x.Cost,
                    Workouts = x.Workout.Select(z => new WorkoutViewModel
                    {
                        DateOfWorkout = z.DateOfWorkout,
                        Id = z.Id,
                        Name = x.Name,
                        Exercises = z.Exercises.Select(y => new ExerciseViewModel
                        {
                            Description = y.Description,
                            Id = y.Id,
                            Name = y.Name,
                            Reps = y.Reps,
                            Sets = y.Sets,
                            Weight = y.Weight
                        })
                    })
                }).ToList();

                return vm;
            }
        }
    }
}
