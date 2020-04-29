using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Reworkedhowwehandleworkoutsandtheirexercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Workout_WorkoutId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_WorkoutId",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "2d1bf3d6-a939-4a48-b2a0-b03687c4130c");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "4439ae99-91c5-4866-bc7d-565a7ec1253b");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "7baa4d8f-80b8-468d-88ac-7510fb46f75d");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "b538b3af-4136-49fe-9edd-24f74fc424cd");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "e137e6e9-d68c-42e8-a7e0-0085cd4f1a53");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "eb38554c-57e8-4834-ab1f-c610e4e96659");

            migrationBuilder.DropColumn(
                name: "Pace",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercise",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseGroupId",
                table: "Exercise",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "7a756e3e-253b-4450-b1f7-064b98f31887", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "9461b24d-3dc6-4ca6-8ab4-4f12a70eeec9", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "ee007f23-8324-45a0-a737-3006c3033b0c", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 3, null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 27, 19, 33, 58, 529, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 19, 33, 58, 532, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 28, 19, 33, 58, 532, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "ba596bca-7603-4d16-b9bc-aae93a414330", new DateTime(2020, 4, 28, 19, 33, 58, 533, DateTimeKind.Local).AddTicks(5554), "Regular push ups", "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik One" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "5f2ed3f1-a767-4803-b612-d3f04e508cc1", new DateTime(2020, 4, 28, 19, 33, 58, 533, DateTimeKind.Local).AddTicks(7997), "", "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat One" });

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
                values: new object[] { "ab26f0e7-bae6-4eae-bb22-5e9ef21c516e", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "c926420b-90bb-457f-92cd-0e555c902e17", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "5dfcbf49-29b7-4b76-a9d0-82ad9c30f28a", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 3, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "a1008646-8659-41d7-bed8-cb75b6886c8a", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "8d3de98e-7b24-426e-be1e-584e05ef6eef", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "f09bfd4e-6e79-45ae-843f-d0c349b92ae1", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseGroupId",
                table: "Exercise",
                column: "ExerciseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseGroup_WorkoutId",
                table: "ExerciseGroup",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseGroup_ExerciseGroupId",
                table: "Exercise",
                column: "ExerciseGroupId",
                principalTable: "ExerciseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseGroup_ExerciseGroupId",
                table: "Exercise");

            migrationBuilder.DropTable(
                name: "ExerciseGroup");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_ExerciseGroupId",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "5dfcbf49-29b7-4b76-a9d0-82ad9c30f28a");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "7a756e3e-253b-4450-b1f7-064b98f31887");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "8d3de98e-7b24-426e-be1e-584e05ef6eef");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "9461b24d-3dc6-4ca6-8ab4-4f12a70eeec9");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "a1008646-8659-41d7-bed8-cb75b6886c8a");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "ab26f0e7-bae6-4eae-bb22-5e9ef21c516e");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "c926420b-90bb-457f-92cd-0e555c902e17");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "ee007f23-8324-45a0-a737-3006c3033b0c");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "f09bfd4e-6e79-45ae-843f-d0c349b92ae1");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ExerciseGroupId",
                table: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "Pace",
                table: "Exercise",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Exercise",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkoutId",
                table: "Exercise",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 20, 47, 44, 864, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 25, 20, 47, 44, 866, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 27, 20, 47, 44, 866, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "7baa4d8f-80b8-468d-88ac-7510fb46f75d", new DateTime(2020, 4, 27, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(4578), null, "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik One" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "4439ae99-91c5-4866-bc7d-565a7ec1253b", new DateTime(2020, 4, 28, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6039), null, "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik Two" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "e137e6e9-d68c-42e8-a7e0-0085cd4f1a53", new DateTime(2020, 4, 29, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6096), null, "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik Three" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "eb38554c-57e8-4834-ab1f-c610e4e96659", new DateTime(2020, 4, 27, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6103), null, "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat One" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "2d1bf3d6-a939-4a48-b2a0-b03687c4130c", new DateTime(2020, 4, 28, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6109), null, "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat Two" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "b538b3af-4136-49fe-9edd-24f74fc424cd", new DateTime(2020, 4, 29, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6117), null, "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat Three" });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_WorkoutId",
                table: "Exercise",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Workout_WorkoutId",
                table: "Exercise",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
