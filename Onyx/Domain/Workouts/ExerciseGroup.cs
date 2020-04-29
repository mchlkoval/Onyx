﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Workouts
{
    public class ExerciseGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Pace { get; set; }
        public string WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int Sets { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
