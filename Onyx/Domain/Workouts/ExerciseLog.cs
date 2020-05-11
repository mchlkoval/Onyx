using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Workouts
{
    public class ExerciseLog
    {
        public string Id { get; set; }
        public string Reps { get; set; }
        public string Sets { get; set; }
        public int? Weight { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
