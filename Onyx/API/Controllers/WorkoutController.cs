using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Workouts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Workout;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : BaseController
    {
        [HttpPost]
        [Authorize]
        [Route("createExercise")]
        public async Task<ActionResult> RecordExerciseData(CancellationToken ct)
        {
            return null;
        }

        [HttpPost]
        [Authorize]
        [Route("createWorkout")]
        public async Task<ActionResult> CreateWorkout(CancellationToken ct)
        {
            return null;
        }

        [HttpPut]
        [Authorize]
        [Route("updateExercise")]
        public async Task<ActionResult> UpdateExercise(CancellationToken ct)
        {
            return null;
        }

        [HttpPut]
        [Authorize]
        [Route("updateWorkout")]
        public async Task<ActionResult> UpdateWorkout(CancellationToken ct)
        {
            return null;
        }

        [HttpGet]
        [Authorize]
        [Route("workouts")]
        public async Task<ActionResult<List<WorkoutsViewModel>>> ListWorksouts(CancellationToken ct)
        {
            return await Mediator.Send(new WorkoutQuery.Query(), ct);
        }

        [HttpGet]
        [Authorize]
        [Route("exercises/{workoutId}/{dateRecorded}")]
        public async Task<ActionResult<List<ExercisesViewModel>>> ListExercises(string workoutId, string dateRecorded, CancellationToken ct)
        {
            var date = DateTime.Parse(dateRecorded);
            return await Mediator.Send(new ExerciseQuery.Query(workoutId, date), ct);
        }
    }
}