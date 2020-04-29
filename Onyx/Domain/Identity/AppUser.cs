using Microsoft.AspNetCore.Identity;
using Shared.Enumerations;
using System.Collections.Generic;

namespace Domain.Identity
{
    public class AppUser : IdentityUser
    {
        public UserType UserType { get; set; }
        //public ICollection<Message> Messages { get; set; }
    }
}
