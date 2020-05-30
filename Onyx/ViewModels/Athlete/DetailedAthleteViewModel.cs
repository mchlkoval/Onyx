using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Athlete
{
    public class DetailedAthleteViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public UserType UserType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
