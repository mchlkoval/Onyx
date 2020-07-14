using Domain.JoinTables;
using Domain.Workouts;
using Microsoft.AspNetCore.Identity;
using Shared.Enumerations;
using System;
using System.Collections.Generic;

namespace Domain.Identity
{
    public class AppUser : IdentityUser
    {
        public UserType UserType { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime? DateArchived { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Organization Organization { get; set; }
        public List<ExerciseLog> ExerciseLogs { get; set; }
        public List<CoachAthlete> AssignedAthletes { get; set; }
        public List<CoachAthlete> AssignedCoaches { get; set; }
        public List<UserTeam> AssignedTeams { get; set; }
        public List<Message> Messages { get; set; }
    }
}
