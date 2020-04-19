using Microsoft.AspNetCore.Identity;
using Shared.Enumerations;

namespace Domain.Identity
{
    public class AppUser : IdentityUser
    {
        public UserType UserType { get; set; }

    }
}
