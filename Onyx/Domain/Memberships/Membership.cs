using Domain.Workouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Memberships
{
    public class Membership
    {
        public string Id { get; set; }
        public string Name { get; set;}
        public string Description { get; set; }
        public double Cost { get; set; }
        public List<Workout> Workout { get; set; }
    }
}
