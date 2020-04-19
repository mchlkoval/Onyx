using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seed
{
    public class SeedData
    {
        public static async Task Seed(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        UserName = "admin",
                        Email = "admin@admin.com",
                        UserType = UserType.Manager
                    },
                    new AppUser
                    {
                        UserName = "coach",
                        Email = "coach@coach.com",
                        UserType = UserType.Coach
                    },
                    new AppUser
                    {
                        UserName = "athelete",
                        Email = "athelete@athelete.com",
                        UserType = UserType.Athelete
                    }
                };

                foreach(var user in users) {
                   await userManager.CreateAsync(user, "Pa$$w0rd");
               }
            }
        } 
    }
}
