using Domain;
using Domain.Identity;
using Domain.Workouts;
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
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "admin",
                        Email = "admin@admin.com",
                        UserType = UserType.Manager
                    },
                    new AppUser
                    {
                        Id = "23a48e56-3e68-4e0e-b9b1-aa0d02cdd425",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "coach",
                        Email = "coach@coach.com",
                        UserType = UserType.Coach
                    },
                    new AppUser
                    {
                        Id = "d8564df2-1464-4547-b418-d1c4c75fe1fc",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "athlete",
                        Email = "athlete@athlete.com",
                        UserType = UserType.Athlete
                    }
                };


                var organization = new Organization
                {
                    Id = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                    Members = users,
                    Name = "Test Gym Organization"
                };

                context.Organization.Add(organization);
                await context.SaveChangesAsync();
                
                foreach(var user in users)
                {
                    await userManager.AddPasswordAsync(user, "Pa$$w0rd");
                }

                //var exercises = new List<Exercise>
                //{
                //    new Exercise
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        AppUserId = "d8564df2-1464-4547-b418-d1c4c75fe1fc"
                //    }
                //};
                
            }
        } 
    }
}
