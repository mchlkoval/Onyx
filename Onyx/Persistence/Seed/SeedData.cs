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
                        UserType = UserType.Manager,
                        Gender = GenderType.Female,
                        Name = "Anna Runner",
                        DateJoined = DateTime.Now,
                        IsActive = true
                    },
                    new AppUser
                    {
                        Id = "23a48e56-3e68-4e0e-b9b1-aa0d02cdd425",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "coach",
                        Email = "coach@coach.com",
                        UserType = UserType.Coach,
                        Gender = GenderType.Male,
                        Name = "Aaron Runner",
                        DateJoined = DateTime.Now,
                        IsActive = true
                    },
                    new AppUser
                    {
                        Id = "d8564df2-1464-4547-b418-d1c4c75fe1fc",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "athlete",
                        Email = "athlete@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Male,
                        Name = "Michael Kovalsky",
                        DateJoined = DateTime.Now,
                        IsActive = true
                    },
                    new AppUser
                    {
                        Id = "246f3ff3-a889-4027-9643-0f376eeba4ce",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "athlete2",
                        Email = "athlete2@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Female,
                        Name = "Victoria Kovalsky",
                        DateJoined = DateTime.Now,
                        IsActive = true
                    },
                    new AppUser
                    {
                        Id = "e36db0a1-4fe9-482c-910c-fc8b87770401",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "athlete3",
                        Email = "athlete3@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Male,
                        Name = "Igor Kovalsky",
                        DateJoined = DateTime.Now,
                        IsActive = true
                    },
                    new AppUser
                    {
                        Id = "61531ff0-2bfe-485a-8e89-cb411d9fc8b0",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "athlete4",
                        Email = "athlete4@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Female,
                        Name = "Anna Kovalsky",
                        DateJoined = DateTime.Now.AddDays(-7),
                        DateArchived = DateTime.Now,
                        IsActive = false

                    },
                    new AppUser
                    {
                        Id = "922029c1-2413-4656-8e90-93eb61067990",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "athlete5",
                        Email = "athlete5@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Male,
                        Name = "Josh Something",
                        DateJoined = DateTime.Now.AddDays(-7),
                        DateArchived = DateTime.Now,
                        IsActive = false
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
