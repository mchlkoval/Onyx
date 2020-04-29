using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Workouts
{
    public class Exercise
    {
        public string Id { get; set; }
        public string ExerciseGroupId { get; set; }
        public ExerciseGroup ExerciseGroup { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int? Weight {get; set; }
    }
}
