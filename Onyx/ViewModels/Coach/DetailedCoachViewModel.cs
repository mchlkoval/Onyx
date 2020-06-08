using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Coach
{
    public class DetailedCoachViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<AssignedAthletesViewModel> AssignedAthletes { get; set; }
    }

    public class AssignedAthletesViewModel
    {
        public string AthleteId { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
