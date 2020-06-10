using Domain;
using Domain.Identity;
using Domain.JoinTables;
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
                var admin = new AppUser
                    {
                        Id = "7130588c-82d8-4432-821d-67bc3b1187cd",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "admin",
                        Email = "admin@admin.com",
                        UserType = UserType.Manager,
                        Gender = GenderType.Female,
                        Name = "Anna Runner",
                        DateJoined = DateTime.Now,
                        IsActive = true,
                        City = "Alpharetta",
                        State = "Georgia",
                        Country = "United States of America",
                        Address = "10700 Pinewalk Forest Circle",
                        Address2 = "",
                        Age = 25,
                        DateOfBirth = DateTime.Now.AddYears(-25)

                    };          
                var athlete = new AppUser
                    {
                        Id = "d8564df2-1464-4547-b418-d1c4c75fe1fc",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "athlete",
                        Email = "athlete@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Male,
                        Name = "Michael Kovalsky",
                        DateJoined = DateTime.Now,
                        IsActive = true,
                        City = "Alpharetta",
                        State = "Georgia",
                        Country = "United States of America",
                        Address = "10700 Pinewalk Forest Circle",
                        Address2 = "",
                        Age = 25,
                        DateOfBirth = DateTime.Now.AddYears(-25)
                    };
                var athlete2 = new AppUser
                    {
                        Id = "246f3ff3-a889-4027-9643-0f376eeba4ce",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "athlete2",
                        Email = "athlete2@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Female,
                        Name = "Victoria Kovalsky",
                        DateJoined = DateTime.Now,
                        IsActive = true,
                        City = "Alpharetta",
                        State = "Georgia",
                        Country = "United States of America",
                        Address = "10700 Pinewalk Forest Circle",
                        Address2 = "",
                        Age = 25,
                        DateOfBirth = DateTime.Now.AddYears(-25)
                    };
                var athlete3 = new AppUser
                    {
                        Id = "e36db0a1-4fe9-482c-910c-fc8b87770401",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "disabled",
                        Email = "athlete3@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Male,
                        Name = "Igor Kovalsky",
                        DateJoined = DateTime.Now,
                        IsActive = true,
                        City = "Alpharetta",
                        State = "Georgia",
                        Country = "United States of America",
                        Address = "10700 Pinewalk Forest Circle",
                        Address2 = "",
                        Age = 25,
                        DateOfBirth = DateTime.Now.AddYears(-25)
                    };
                var athlete4 = new AppUser
                    {
                        Id = "61531ff0-2bfe-485a-8e89-cb411d9fc8b0",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "disabled2",
                        Email = "athlete4@athlete.com",
                        UserType = UserType.Athlete,
                        Gender = GenderType.Female,
                        Name = "Anna Kovalsky",
                        DateJoined = DateTime.Now.AddDays(-7),
                        DateArchived = DateTime.Now,
                        IsActive = false,
                        City = "Alpharetta",
                        State = "Georgia",
                        Country = "United States of America",
                        Address = "10700 Pinewalk Forest Circle",
                        Address2 = "",
                        Age = 25,
                        DateOfBirth = DateTime.Now.AddYears(-25)

                    };
                var athlete5 = new AppUser
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
                        IsActive = false,
                        City = "Alpharetta",
                        State = "Georgia",
                        Country = "United States of America",
                        Address = "10700 Pinewalk Forest Circle",
                        Address2 = "",
                        Age = 25,
                        DateOfBirth = DateTime.Now.AddYears(-25)
                    };
                var coach = new AppUser
                    {
                        Id = "23a48e56-3e68-4e0e-b9b1-aa0d02cdd425",
                        OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                        UserName = "coach",
                        Email = "coach@coach.com",
                        UserType = UserType.Coach,
                        Gender = GenderType.Male,
                        Name = "Aaron Runner",
                        DateJoined = DateTime.Now,
                        IsActive = true,
                        City = "Alpharetta",
                        State = "Georgia",
                        Country = "United States of America",
                        Address = "10700 Pinewalk Forest Circle",
                        Address2 = "",
                        Age = 25,
                        DateOfBirth = DateTime.Now.AddYears(-25),
                        AssignedAthletes = new List<CoachAthlete>()
                        {
                            new CoachAthlete
                            {
                                AthleteId = athlete.Id,
                                CoachId = "23a48e56-3e68-4e0e-b9b1-aa0d02cdd425"
                            },
                            new CoachAthlete
                            {
                                AthleteId = athlete2.Id,
                                CoachId = "23a48e56-3e68-4e0e-b9b1-aa0d02cdd425"
                            },
                            new CoachAthlete
                            {
                                AthleteId = athlete3.Id,
                                CoachId = "23a48e56-3e68-4e0e-b9b1-aa0d02cdd425"
                            }
                        }
                    };

                var users = new List<AppUser>
                {
                    admin,
                    coach,
                    athlete,
                    athlete2,
                    athlete3,
                    athlete4,
                    athlete5
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

                //This is where we are going to assign coaches to athletes
                var assignedAthletes = users.Single(x => x.UserName == "coach")
                    .AssignedAthletes.Select(x => x.AthleteId);
                foreach(var user in users.Where(x => assignedAthletes.Contains(x.Id)))
                {
                    user.AssignedCoaches = new List<CoachAthlete>()
                    {
                        new CoachAthlete
                        {
                            CoachId = "23a48e56-3e68-4e0e-b9b1-aa0d02cdd425",
                            AthleteId = user.Id
                        }
                    };

                    Console.WriteLine($"Updating: {user.UserName}");
                    context.Users.Update(user);

                    await context.SaveChangesAsync();
                }
                
            }
        } 
    }
}
