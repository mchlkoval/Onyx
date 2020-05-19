using Domain.Memberships;
using Domain.Workouts;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Membership;

namespace Application.Commands.Memberships
{
    public class CreateMembershipCommand
    {
        public class Command : MembershipVerboseViewModel, IRequest
        {
            public Command() : base()
            {

            }
        }
        
        public class Handler : IRequestHandler<Command>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            private List<Workout> CreateWorkouts(List<WorkoutViewModel> workouts, string membershipId)
            {
                return workouts.Select(x => new Workout
                {
                    Id = Guid.NewGuid().ToString(),
                    DateOfWorkout = x.DateOfWorkout,
                    Description = x.Description,
                    MembershipId = membershipId,
                    MinReps = x.MinReps,
                    MinSets = x.MinSets,
                    MinWeight = x.MinWeight,
                    Name = x.Name,
                    Exercises = x.Exercises.Select(y => new Exercise
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = y.Name,
                        Description = y.Description,
                        WorkoutId = x.Id
                    }).ToList()
                }).ToList();
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var membershipId = Guid.NewGuid().ToString();
                var workouts = CreateWorkouts(request.Workouts.ToList(), membershipId);
                
                var membership = new Membership
                {
                    Id = membershipId,
                    Cost = request.Cost,
                    Description = request.Description,
                    EndDate = request.EndDate,
                    StartDate = request.StartDate,
                    Name = request.Name
                };

                context.Memberships.Add(membership);
                await context.SaveChangesAsync();

                workouts.ForEach(x =>
                {
                    context.Workout.Add(x);
                    x.Exercises.ForEach(y =>
                    {
                        context.Exercise.Add(y);
                    });
                });

                var success = await context.SaveChangesAsync();
                
                if(success > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Error whilst creating new membership");
            }
        }
        
    }
}
