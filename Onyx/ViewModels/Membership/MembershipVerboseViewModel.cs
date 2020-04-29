using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Membership
{
    public class MembershipVerboseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public IEnumerable<WorkoutViewModel> Workouts { get; set; }
    }

    public class WorkoutViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfWorkout { get; set; }
        public IEnumerable<ExerciseGroupViewModel> ExerciseGroups { get; set; }
    }

    public class ExerciseGroupViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Pace { get; set; }
        public int Sets { get; set; }
        public IEnumerable<ExerciseViewModel> Exercises { get; set; }

    }

    public class ExerciseViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int? Weight { get; set; }
    }

}
