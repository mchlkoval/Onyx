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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<WorkoutViewModel> Workouts { get; set; }
    }

    public class WorkoutViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfWorkout { get; set; }
        public int MinReps { get; set; }
        public int MinSets { get; set; }
        public int? MinWeight { get; set; }
        public IEnumerable<ExerciseViewModel> Exercises { get; set; }
    }

    public class ExerciseViewModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
    }

}
