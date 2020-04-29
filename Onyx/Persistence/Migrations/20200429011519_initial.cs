using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    DateOfMessage = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MembershipId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateOfWorkout = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workout_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseGroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Pace = table.Column<string>(nullable: true),
                    WorkoutId = table.Column<string>(nullable: true),
                    Sets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseGroup_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ExerciseGroupId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_ExerciseGroup_ExerciseGroupId",
                        column: x => x.ExerciseGroupId,
                        principalTable: "ExerciseGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { "29ad0121-b184-461b-b2c9-518355e35123", 250.0, "Approved by Boris, loved by Slavs, misunderstood by Americans.", "Gopnik Workout" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", 100.0, "Simple and effective after you gorged yourself", "Squats and Pull Ups" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "DateOfMessage", "From", "IsDeleted" },
                values: new object[] { "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78", "Test Message 1", new DateTime(2020, 4, 27, 21, 15, 19, 531, DateTimeKind.Local).AddTicks(9845), "Anna Runner", false });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "DateOfMessage", "From", "IsDeleted" },
                values: new object[] { "d1940fcc-f86a-4b48-ad97-3f7ff1321647", "Test Message 2", new DateTime(2020, 4, 28, 21, 15, 19, 534, DateTimeKind.Local).AddTicks(3457), "Michael Kovalsky", false });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "DateOfMessage", "From", "IsDeleted" },
                values: new object[] { "b92e0a10-33e1-4108-be76-c1ec87677330", "Test Message 3", new DateTime(2020, 4, 26, 21, 15, 19, 534, DateTimeKind.Local).AddTicks(3495), "Aaron Runner", false });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "ba596bca-7603-4d16-b9bc-aae93a414330", new DateTime(2020, 4, 28, 21, 15, 19, 535, DateTimeKind.Local).AddTicks(8414), "Regular push ups", "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik One" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "5f2ed3f1-a767-4803-b612-d3f04e508cc1", new DateTime(2020, 4, 28, 21, 15, 19, 536, DateTimeKind.Local).AddTicks(630), "Test Description", "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat One" });

            migrationBuilder.InsertData(
                table: "ExerciseGroup",
                columns: new[] { "Id", "Name", "Pace", "Sets", "WorkoutId" },
                values: new object[] { "2b60f7f4-09c5-403c-882b-eadf0bf912d0", "DB Hang Snatch", "x-safe", 4, "ba596bca-7603-4d16-b9bc-aae93a414330" });

            migrationBuilder.InsertData(
                table: "ExerciseGroup",
                columns: new[] { "Id", "Name", "Pace", "Sets", "WorkoutId" },
                values: new object[] { "adf78c99-8106-49df-b0dd-d0b145ddc53e", "Goblet Front Squat", "safe-x", 4, "ba596bca-7603-4d16-b9bc-aae93a414330" });

            migrationBuilder.InsertData(
                table: "ExerciseGroup",
                columns: new[] { "Id", "Name", "Pace", "Sets", "WorkoutId" },
                values: new object[] { "6bcc3b40-17e5-440a-9f5f-98bdbb73f7f7", "DB RDL", "3-1-x", 4, "ba596bca-7603-4d16-b9bc-aae93a414330" });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "fbc63f06-619a-4002-a676-849fc4e8f4fb", "", "2b60f7f4-09c5-403c-882b-eadf0bf912d0", "", 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "d46c92bf-2369-462b-9bc7-da99f788813e", "", "2b60f7f4-09c5-403c-882b-eadf0bf912d0", "", 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "77c5b70c-4c90-4ebf-a3b3-3374e913cd3e", "", "2b60f7f4-09c5-403c-882b-eadf0bf912d0", "", 3, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "42816968-45cc-4f49-aa90-197af1fb3b35", "", "adf78c99-8106-49df-b0dd-d0b145ddc53e", "", 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "7bbb4df8-2a92-4ea5-8ebc-0ec72cfcc9d4", "", "adf78c99-8106-49df-b0dd-d0b145ddc53e", "", 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "47e7b0de-6cd9-4895-9054-1c70c5c423ed", "", "adf78c99-8106-49df-b0dd-d0b145ddc53e", "", 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseGroupId",
                table: "Exercise",
                column: "ExerciseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseGroup_WorkoutId",
                table: "ExerciseGroup",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_MembershipId",
                table: "Workout",
                column: "MembershipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExerciseGroup");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "Memberships");
        }
    }
}
