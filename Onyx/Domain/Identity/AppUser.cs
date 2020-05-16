using Domain.Workouts;
using Microsoft.AspNetCore.Identity;
using Shared.Enumerations;
using System.Collections.Generic;

namespace Domain.Identity
{
    public class AppUser : IdentityUser
    {
        public UserType UserType { get; set; }
        public string OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public List<ExerciseLog> ExerciseLogs { get; set; }
        //public ICollection<Message> Messages { get; set; }
    }
}
