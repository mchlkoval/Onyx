﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200526002633_Updates to AppUser to include more data")]
    partial class UpdatestoAppUsertoincludemoredata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Domain.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateArchived")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("OrganizationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("OrganizationId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Memberships.Membership", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<double>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Memberships");

                    b.HasData(
                        new
                        {
                            Id = "29ad0121-b184-461b-b2c9-518355e35123",
                            Cost = 250.0,
                            Description = "Approved by Boris, loved by Slavs, misunderstood by Americans.",
                            EndDate = new DateTime(2020, 6, 24, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(6070),
                            Name = "Gopnik Workout",
                            StartDate = new DateTime(2020, 5, 25, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(5509)
                        },
                        new
                        {
                            Id = "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                            Cost = 100.0,
                            Description = "Simple and effective after you gorged yourself",
                            EndDate = new DateTime(2020, 6, 24, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(6701),
                            Name = "Squats and Pull Ups",
                            StartDate = new DateTime(2020, 5, 25, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(6681)
                        });
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfMessage")
                        .HasColumnType("TEXT");

                    b.Property<string>("From")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                            Content = "Test Message 1",
                            DateOfMessage = new DateTime(2020, 5, 24, 20, 26, 32, 652, DateTimeKind.Local).AddTicks(7820),
                            From = "Anna Runner",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                            Content = "Test Message 2",
                            DateOfMessage = new DateTime(2020, 5, 25, 20, 26, 32, 655, DateTimeKind.Local).AddTicks(1520),
                            From = "Michael Kovalsky",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = "b92e0a10-33e1-4108-be76-c1ec87677330",
                            Content = "Test Message 3",
                            DateOfMessage = new DateTime(2020, 5, 23, 20, 26, 32, 655, DateTimeKind.Local).AddTicks(1556),
                            From = "Aaron Runner",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Domain.Organization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Domain.Workouts.Exercise", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Reps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sets")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Weight")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorkoutId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercise");

                    b.HasData(
                        new
                        {
                            Id = "cb168e0f-ed08-4588-ae72-1b2fb80daff3",
                            Description = "Basic pull ups",
                            Name = "Upper Body",
                            Reps = 5,
                            Sets = 5,
                            WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330"
                        },
                        new
                        {
                            Id = "e3986007-27cf-4abd-86ed-589f99246482",
                            Description = "Basic sit ups",
                            Name = "Core Muscles",
                            Reps = 10,
                            Sets = 10,
                            WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330"
                        },
                        new
                        {
                            Id = "cf25e17b-e402-4f39-9a5f-03fdc0cc513a",
                            Description = "Pushing against weights on the leg machine",
                            Name = "Leg Muscles",
                            Reps = 10,
                            Sets = 5,
                            Weight = 30,
                            WorkoutId = "ba596bca-7603-4d16-b9bc-aae93a414330"
                        });
                });

            modelBuilder.Entity("Domain.Workouts.ExerciseLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateRecorded")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExerciseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reps")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sets")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseLog");
                });

            modelBuilder.Entity("Domain.Workouts.Workout", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfWorkout")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("MembershipId")
                        .HasColumnType("TEXT");

                    b.Property<int>("MinReps")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinSets")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MinWeight")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MembershipId");

                    b.ToTable("Workout");

                    b.HasData(
                        new
                        {
                            Id = "ba596bca-7603-4d16-b9bc-aae93a414330",
                            DateOfWorkout = new DateTime(2020, 5, 25, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(8023),
                            Description = "Regular push ups",
                            MembershipId = "29ad0121-b184-461b-b2c9-518355e35123",
                            MinReps = 5,
                            MinSets = 5,
                            Name = "Gopnik One"
                        },
                        new
                        {
                            Id = "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                            DateOfWorkout = new DateTime(2020, 5, 25, 20, 26, 32, 657, DateTimeKind.Local).AddTicks(1471),
                            Description = "Test Description",
                            MembershipId = "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                            MinReps = 5,
                            MinSets = 2,
                            Name = "Squat One"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Identity.AppUser", b =>
                {
                    b.HasOne("Domain.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("Domain.Workouts.Exercise", b =>
                {
                    b.HasOne("Domain.Workouts.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId");
                });

            modelBuilder.Entity("Domain.Workouts.ExerciseLog", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", "AppUser")
                        .WithMany("ExerciseLogs")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Domain.Workouts.Exercise", "Exercise")
                        .WithMany("ExerciseLogs")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("Domain.Workouts.Workout", b =>
                {
                    b.HasOne("Domain.Memberships.Membership", "Membership")
                        .WithMany("Workout")
                        .HasForeignKey("MembershipId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
