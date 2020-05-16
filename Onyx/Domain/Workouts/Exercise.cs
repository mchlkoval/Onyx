using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Workouts
{
    public class Exercise
    {
        public string Id { get; set; }
        public string WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int? Weight {get; set; }

        public List<ExerciseLog> ExerciseLogs { get; set; }
    }
}
