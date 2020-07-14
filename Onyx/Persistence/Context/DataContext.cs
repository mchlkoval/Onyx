using Domain;
using Domain.Identity;
using Domain.JoinTables;
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

        public DbSet<Organization> Organization { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseLog> ExerciseLog { get; set; }
        public DbSet<CoachAthlete> AssignedAthletes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeam> AssignedTeams { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Organization>()
                .HasMany(x => x.Members)
                .WithOne(x => x.Organization);

            builder.Entity<Membership>()
                .HasMany(x => x.Workout)
                .WithOne(y => y.Membership);

            builder.Entity<Workout>()
                    .HasMany(x => x.Exercises)
                    .WithOne(y => y.Workout);

            builder.Entity<Exercise>()
                .HasMany(x => x.ExerciseLogs)
                .WithOne(y => y.Exercise);

            builder.Entity<Membership>()
                .HasData(
                    new Membership
                    {
                        Cost = 250,
                        Description = "Approved by Boris, loved by Slavs, misunderstood by Americans.",
                        Name = "Gopnik Workout",
                        Id = "29ad0121-b184-461b-b2c9-518355e35123",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(30)
                        
                    },
                    new Membership
                    {
                        Cost = 100,
                        Description = "Simple and effective after you gorged yourself",
                        Name = "Squats and Pull Ups",
                        Id = "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(30)
                        
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
                        Id = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        MinReps = 5,
                        MinSets = 5
                    },
                    new Workout
                    {
                        DateOfWorkout = DateTime.Now,
                        MembershipId = "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                        Description = "Test Description",
                        Name = "Squat One",
                        Id = "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                        MinSets = 2,
                        MinReps = 5
                    }
                );

            builder.Entity<Exercise>()
                .HasData(
                    new Exercise
                    {
                        Id = "cb168e0f-ed08-4588-ae72-1b2fb80daff3",
                        WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Name = "Upper Body",
                        Sets = 5,
                        Reps = 5,
                        Description = "Basic pull ups",
                    },
                    new Exercise
                    {
                        Id = "e3986007-27cf-4abd-86ed-589f99246482",
                        WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Name = "Core Muscles",
                        Sets = 10,
                        Reps = 10,
                        Description = "Basic sit ups",
                    },
                    new Exercise
                    {
                        Id = "cf25e17b-e402-4f39-9a5f-03fdc0cc513a",
                        WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330",
                        Name = "Leg Muscles",
                        Sets = 5,
                        Reps = 10,
                        Weight = 30,
                        Description = "Pushing against weights on the leg machine",
                    }
                );

            builder.Entity<CoachAthlete>()
               .HasKey(sc => new { sc.AthleteId, sc.CoachId });

            builder.Entity<CoachAthlete>()
               .HasOne(x => x.Coach)
               .WithMany(s => s.AssignedAthletes)
               .HasForeignKey(z => z.CoachId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CoachAthlete>()
               .HasOne(x => x.Athlete)
               .WithMany(s => s.AssignedCoaches)
               .HasForeignKey(z => z.AthleteId);

            builder.Entity<UserTeam>()
                .HasKey(x => new { x.TeamId, x.UserId});
            
            builder.Entity<UserTeam>()
                .HasOne(x => x.User)
                .WithMany(y => y.AssignedTeams)
                .HasForeignKey(z => z.UserId);

            builder.Entity<UserTeam>()
                .HasOne(x => x.Team)
                .WithMany(y => y.TeamMembers)
                .HasForeignKey(z => z.TeamId);
        }
    }
}
