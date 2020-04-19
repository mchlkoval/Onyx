using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Workouts
{
    public class Workout
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfWorkout { get; set; }

    }
}
