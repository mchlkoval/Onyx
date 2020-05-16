using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Workout
{
    public class ExercisesViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Reps { get; set;}
        public int Sets { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExerciseLogsViewModel> ExerciseLogs { get; set; }
    }

    public class ExerciseLogsViewModel
    {
        public string Id { get; set; }

    }
}
