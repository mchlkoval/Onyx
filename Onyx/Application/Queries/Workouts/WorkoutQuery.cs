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
    public class WorkoutQuery
    {
        public class Query : IRequest<List<WorkoutsViewModel>>
        {

        }

        public class Handler : IRequestHandler<Query, List<WorkoutsViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<WorkoutsViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var vm = await context.Workout
                    .Select(x => new WorkoutsViewModel
                    {
                        Id = x.Id,
                        DateOfWorkout = x.DateOfWorkout,
                        Description = x.Description,
                        Name = x.Name
                    }).ToListAsync();

                return vm;
            }
        }
    }
}
