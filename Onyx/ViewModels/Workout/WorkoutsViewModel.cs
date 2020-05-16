using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Workout
{
    public class WorkoutsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfWorkout { get; set; }
    }
}
