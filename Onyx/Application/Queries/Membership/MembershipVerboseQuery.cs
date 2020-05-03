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
                var vm = await context.Memberships.Select(x => new MembershipVerboseViewModel {
                    Description = x.Description,
                    Name = x.Name,
                    Id = x.Id,
                    Cost = x.Cost,
                    //Workouts = x.Workout.Select(y => new WorkoutViewModel
                    //{
                    //    DateOfWorkout = y.DateOfWorkout,
                    //    Id = y.Id,
                    //    Name = y.Name,
                    //    ExerciseGroups = y.ExerciseGroup.Select(z => new ExerciseGroupViewModel
                    //    {
                    //        Id = z.Id,
                    //        Name = z.Name,
                    //        Pace = z.Pace,
                    //        Sets = z.Sets,
                    //        Exercises = z.Exercise.Select(e => new ExerciseViewModel
                    //        {
                    //            Description = e.Description,
                    //            Name = e.Name,
                    //            Reps = e.Reps,
                    //            Weight = e.Weight,
                    //            Id = e.Id
                    //        })
                    //    })
                    //})
                }).ToListAsync();

                return vm;
            }
        }
    }
}
