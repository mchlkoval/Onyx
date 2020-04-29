using Domain;
using Domain.Identity;
using Domain.Memberships;
using Domain.Workouts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Enumerations;
using System;
using System.Collections.Generic;

namespace Persistence.Context
{
    public class DataContext : IdentityDbContext<AppUser>
    {

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseGroup> ExerciseGroups { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Membership>()
                .HasMany(x => x.Workouts)
                .WithOne(y => y.Membership);

            builder.Entity<Workout>()
                .HasMany(x => x.ExerciseGroups)
                .WithOne(y => y.Workout);

            builder.Entity<ExerciseGroup>()
                .HasMany(y => y.Exercises)
                .WithOne(x => x.ExerciseGroup);
                

            builder.Entity<Message>()
                .HasData(
                    new Message
                    {
                        Id = "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                        Content = "Test Message 1",
                        IsDeleted = false,
                        From = "Anna Runner",
                        DateOfMessage = DateTime.Now.AddDays(-1)
                        //UserId = "d8564df2-1464-4547-b418-d1c4c75fe1fc"
                    },
                    new Message
                    {
                        Id = "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                        Content = "Test Message 2",
                        IsDeleted = false,
                        From = "Michael Kovalsky",
                        DateOfMessage = DateTime.Now
                        //UserId = "d8564df2-1464-4547-b418-d1c4c75fe1fc"
                    },
                    new Message
                    {
                        Id = "b92e0a10-33e1-4108-be76-c1ec87677330",
                        Content = "Test Message 3",
                        IsDeleted = false,
                        From = "Aaron Runner",
                        DateOfMessage = DateTime.Now.AddDays(-2)
                        //UserId = "d8564df2-1464-4547-b418-d1c4c75fe1fc"
                    }
                );

            builder.Entity<Membership>()
                .HasData(
                    new Membership
                    {
                        Cost = 250,
                        Description = "Approved by Boris, loved by Slavs, misunderstood by Americans.",
                        Name = "Gopnik Workout",
                        Id = "29ad0121-b184-461b-b2c9-518355e35123"
                        
                    },
                    new Membership
                    {
                        Cost = 100,
                        Description = "Simple and effective after you gorged yourself",
                        Name = "Squats and Pull Ups",
                        Id = "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a"
                        
                    }
                );

            builder.Entity<Workout>()
                .HasData(
                        new Workout
                        {
                            DateOfWorkout = DateTime.Now,
                            MembershipId = "29ad0121-b184-461b-b2c9-518355e35123",
                            Description = "Regular push ups",
                            Name = "Gopnik One",
                            Id = "ba596bca-7603-4d16-b9bc-aae93a414330"
                        },
                        new Workout
                        {
                            DateOfWorkout = DateTime.Now,
                            MembershipId = "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                            Description = "Test Description",
                            Name = "Squat One",
                            Id = "5f2ed3f1-a767-4803-b612-d3f04e508cc1"
                        }
                );

            builder.Entity<ExerciseGroup>()
                .HasData(
                    new ExerciseGroup
                    {
                        WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Id = "2b60f7f4-09c5-403c-882b-eadf0bf912d0",
                        Pace = "x-safe",
                        Sets = 4,
                        Name = "DB Hang Snatch",
                    },
                    new ExerciseGroup
                    {
                        Id = "adf78c99-8106-49df-b0dd-d0b145ddc53e",
                        WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Pace = "safe-x",
                        Sets = 4,
                        Name = "Goblet Front Squat"
                    },
                    new ExerciseGroup
                    {
                        WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Id = "6bcc3b40-17e5-440a-9f5f-98bdbb73f7f7",
                        Pace = "3-1-x",
                        Sets = 4,
                        Name = "DB RDL"
                    }
                );

            builder.Entity<Exercise>()
                .HasData(
                    new Exercise
                    {
                        ExerciseGroupId = "2b60f7f4-09c5-403c-882b-eadf0bf912d0",
                        Reps = 4,
                        Id = "fbc63f06-619a-4002-a676-849fc4e8f4fb"
                    },
                    new Exercise
                    {
                        ExerciseGroupId = "2b60f7f4-09c5-403c-882b-eadf0bf912d0",
                        Reps = 4,
                        Id = "d46c92bf-2369-462b-9bc7-da99f788813e"
                    },
                    new Exercise
                    {
                        ExerciseGroupId = "2b60f7f4-09c5-403c-882b-eadf0bf912d0",
                        Reps = 3,
                        Id = "77c5b70c-4c90-4ebf-a3b3-3374e913cd3e"
                    },
                    new Exercise
                    {
                        ExerciseGroupId = "adf78c99-8106-49df-b0dd-d0b145ddc53e",
                        Reps = 4,
                        Id = "42816968-45cc-4f49-aa90-197af1fb3b35"
                    },
                    new Exercise
                    {
                        ExerciseGroupId = "adf78c99-8106-49df-b0dd-d0b145ddc53e",
                        Reps = 4,
                        Id = "7bbb4df8-2a92-4ea5-8ebc-0ec72cfcc9d4"
                    },
                    new Exercise
                    {
                        ExerciseGroupId = "adf78c99-8106-49df-b0dd-d0b145ddc53e",
                        Reps = 3,
                        Id = "47e7b0de-6cd9-4895-9054-1c70c5c423ed"
                    },
                    new Exercise
                    {
                        ExerciseGroupId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Reps = 4,
                        Id = "21fee9cb-b38d-4c90-a77d-b3dee444804e"
                    },
                    new Exercise
                    {
                        ExerciseGroupId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Reps = 4,
                        Id = "5927295e-df92-40e7-b780-9e0ab05fd4c1"
                    },
                    new Exercise
                    {
                        ExerciseGroupId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Reps = 3,
                        Id = "2dd0782e-a75e-4b45-8422-d20108efab05"
                    }

                );
        }
    }
}
