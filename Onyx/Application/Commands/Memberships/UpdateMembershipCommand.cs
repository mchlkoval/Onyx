using Domain.Memberships;
using Domain.Workouts;
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

namespace Application.Commands.Memberships
{
    public class UpdateMembershipCommand
    {
        public class Command : MembershipVerboseViewModel, IRequest { 
            
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

            private List<Workout> GetWorkouts(List<WorkoutViewModel> workouts, string membershipId)
            {
                return workouts.Select(x => new Workout
                {
                    Id = x.Id,
                    DateOfWorkout = x.DateOfWorkout,
                    Description = x.Description,
                    MembershipId = membershipId,
                    MinReps = x.MinReps,
                    MinSets = x.MinSets,
                    MinWeight = x.MinWeight,
                    Name = x.Name,
                    Exercises = x.Exercises.Select(y => new Exercise
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Description = y.Description,
                        WorkoutId = x.Id
                    }).ToList()
                }).ToList();
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var workouts = request.Workouts.ToList();
                workouts.ForEach(x =>
                {
                    var workoutId = !string.IsNullOrEmpty(x.Id) ? x.Id : Guid.NewGuid().ToString();
                    if(string.IsNullOrEmpty(x.Id))
                    {
                        x.Id = workoutId;
                    }

                    x.Exercises.ToList().ForEach(y =>
                    {
                        if(string.IsNullOrEmpty(y.Id))
                        {
                            y.Id = Guid.NewGuid().ToString();                           
                        }
                    });
                });

                var domainWorkouts = GetWorkouts(workouts, request.Id);

                var membership = new Membership
                {
                    Id = request.Id,
                    Cost = request.Cost,
                    Description = request.Description,
                    EndDate = request.EndDate,
                    StartDate = request.StartDate,
                    Name = request.Name,
                    Workout = domainWorkouts
                };

                membership.Workout.ForEach(x =>
                {
                    var exist = context.Workout.Any(z => z.Id == x.Id);
                    if(exist) {
                        context.Workout.Update(x);
                    } else {
                        context.Workout.Add(x);
                    }

                    x.Exercises.ForEach(e =>
                    {
                        var exerciseExist = context.Exercise.Any(l => l.Id == e.Id);
                        if(exerciseExist)
                        {
                            context.Exercise.Update(e);
                        } else
                        {
                            context.Exercise.Add(e);
                        }
                    });
                });

                context.Memberships.Update(membership);
                var success = await context.SaveChangesAsync();
                
                if(success > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Failed updating membership");
            }
        }
    }
}
