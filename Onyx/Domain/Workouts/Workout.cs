﻿using Domain.Memberships;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Workouts
{
    public class Workout
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string MembershipId { get; set; }
        public string Description { get; set; }
        public Membership Membership { get; set; }
        public string Name { get; set; }
        public DateTime DateOfWorkout { get; set; }
        public int MinSets { get; set; }
        public int MinReps { get; set; }
        public int? MinWeight { get; set; }
        public List<Exercise> Exercises { get; set; }


    }
}
