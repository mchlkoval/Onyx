using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Workout;

namespace Application.Queries.Workouts
{
    public class ExerciseQuery
    {
        public class Query : IRequest<List<ExercisesViewModel>>
        {
            public string WorkoutId { get; set; }
            public DateTime DateRecorded { get; set; }

            public Query(string workoutId, DateTime dateRecorded)
            {
                this.WorkoutId = workoutId;
                this.DateRecorded = dateRecorded;
            }

            public class Handler : IRequestHandler<Query, List<ExercisesViewModel>>
            {
                private DataContext context;

                public Handler(DataContext context)
                {
                    this.context = context;
                }

                public async Task<List<ExercisesViewModel>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var vm = await context.Exercise
                        .Include(x => x.ExerciseLogs)
                        .Where(x => x.WorkoutId == request.WorkoutId)
                        .Select(x => new ExercisesViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Sets = x.Sets,
                            Reps = x.Reps,
                            Weight = x.Weight.GetValueOrDefault(),
                            ExerciseLogs = x.ExerciseLogs.Where(x => x.DateRecorded == request.DateRecorded)
                            .Select(z => new ExerciseLogsViewModel
                            {
                                Id = z.Id
                            })
                        }).ToListAsync();
                    
                    return vm;
                }
            }
        }
    }
}
