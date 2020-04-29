using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Addedmissingitemstodbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseGroup_ExerciseGroupId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseGroup_Workout_WorkoutId",
                table: "ExerciseGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Memberships_MembershipId",
                table: "Workout");

            migrationBuilder.DropTable(
                name: "GymClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workout",
                table: "Workout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseGroup",
                table: "ExerciseGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
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

            migrationBuilder.RenameTable(
                name: "Workout",
                newName: "Workouts");

            migrationBuilder.RenameTable(
                name: "ExerciseGroup",
                newName: "ExerciseGroups");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Workout_MembershipId",
                table: "Workouts",
                newName: "IX_Workouts_MembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseGroup_WorkoutId",
                table: "ExerciseGroups",
                newName: "IX_ExerciseGroups_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_ExerciseGroupId",
                table: "Exercises",
                newName: "IX_Exercises_ExerciseGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseGroups",
                table: "ExerciseGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "3ed05cf8-b64a-4af9-ab63-dda3dbd7a4ae", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "8bc0d4fb-26e6-4b41-b490-a50791ab436d", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "c0d31a48-98e5-4d6d-b5d3-610cefc2c1bc", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 3, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "68a4f026-8849-479a-b8ae-0d477667d32a", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "47a712e6-2d2e-4e8c-b527-c234c78d326c", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "b14d407d-ea70-4989-ba86-7dc7355dfa95", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 3, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "860da657-a708-48f1-ad65-54c15b23e736", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "2f3140cc-4149-42c8-a42f-caca2c87cbcc", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "5c976509-bda4-457d-87dc-dfcde786babc", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 3, null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 27, 19, 59, 38, 912, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 19, 59, 38, 915, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 28, 19, 59, 38, 915, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 19, 59, 38, 916, DateTimeKind.Local).AddTicks(8527));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 19, 59, 38, 916, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseGroups_Workouts_WorkoutId",
                table: "ExerciseGroups",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseGroups_ExerciseGroupId",
                table: "Exercises",
                column: "ExerciseGroupId",
                principalTable: "ExerciseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Memberships_MembershipId",
                table: "Workouts",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseGroups_Workouts_WorkoutId",
                table: "ExerciseGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseGroups_ExerciseGroupId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Memberships_MembershipId",
                table: "Workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseGroups",
                table: "ExerciseGroups");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "2f3140cc-4149-42c8-a42f-caca2c87cbcc");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "3ed05cf8-b64a-4af9-ab63-dda3dbd7a4ae");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "47a712e6-2d2e-4e8c-b527-c234c78d326c");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "5c976509-bda4-457d-87dc-dfcde786babc");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "68a4f026-8849-479a-b8ae-0d477667d32a");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "860da657-a708-48f1-ad65-54c15b23e736");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "8bc0d4fb-26e6-4b41-b490-a50791ab436d");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "b14d407d-ea70-4989-ba86-7dc7355dfa95");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "c0d31a48-98e5-4d6d-b5d3-610cefc2c1bc");

            migrationBuilder.RenameTable(
                name: "Workouts",
                newName: "Workout");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameTable(
                name: "ExerciseGroups",
                newName: "ExerciseGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Workouts_MembershipId",
                table: "Workout",
                newName: "IX_Workout_MembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_ExerciseGroupId",
                table: "Exercise",
                newName: "IX_Exercise_ExerciseGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseGroups_WorkoutId",
                table: "ExerciseGroup",
                newName: "IX_ExerciseGroup_WorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workout",
                table: "Workout",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseGroup",
                table: "ExerciseGroup",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GymClass",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ClassName = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfClass = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymClass", x => x.Id);
                });

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

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 19, 33, 58, 533, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 19, 33, 58, 533, DateTimeKind.Local).AddTicks(5554));

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseGroup_ExerciseGroupId",
                table: "Exercise",
                column: "ExerciseGroupId",
                principalTable: "ExerciseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseGroup_Workout_WorkoutId",
                table: "ExerciseGroup",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Memberships_MembershipId",
                table: "Workout",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
