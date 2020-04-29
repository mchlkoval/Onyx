using Domain;
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
                        Id = "7130588c-82d8-4432-821d-67bc3b1187cd",
                        UserName = "admin",
                        Email = "admin@admin.com",
                        UserType = UserType.Manager
                    },
                    new AppUser
                    {
                        Id = "23a48e56-3e68-4e0e-b9b1-aa0d02cdd425",
                        UserName = "coach",
                        Email = "coach@coach.com",
                        UserType = UserType.Coach
                    },
                    new AppUser
                    {
                        Id = "d8564df2-1464-4547-b418-d1c4c75fe1fc",
                        UserName = "athlete",
                        Email = "athlete@athlete.com",
                        UserType = UserType.Athlete
                    }
                };

                foreach(var user in users) {
                   await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        } 
    }
}
