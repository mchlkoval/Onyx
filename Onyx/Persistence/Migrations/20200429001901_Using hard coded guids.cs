using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Usinghardcodedguids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "22d03bf1-95e0-47d0-bbaf-d022ab892105");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "29360479-462b-4cdf-902b-524ca80a4d44");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "478fa936-6ef4-4a7c-8c70-751a1237b0a8");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "64f49a47-6def-493e-9bf1-cddf81be4715");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "7cb486da-7567-475f-b6fa-71f41dfb380b");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "7fac44cc-e2e9-4647-ac00-55848b658105");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "de758fe9-3276-4757-8561-7f5aafc4a896");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "fc2810f8-df87-44b0-8ac2-72d4aea49fe3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "fc283b61-793b-4f34-9daf-5daa89200712");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "fbc63f06-619a-4002-a676-849fc4e8f4fb", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "d46c92bf-2369-462b-9bc7-da99f788813e", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "77c5b70c-4c90-4ebf-a3b3-3374e913cd3e", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 3, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "42816968-45cc-4f49-aa90-197af1fb3b35", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "7bbb4df8-2a92-4ea5-8ebc-0ec72cfcc9d4", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "47e7b0de-6cd9-4895-9054-1c70c5c423ed", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 3, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "21fee9cb-b38d-4c90-a77d-b3dee444804e", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "5927295e-df92-40e7-b780-9e0ab05fd4c1", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "2dd0782e-a75e-4b45-8422-d20108efab05", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 3, null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 27, 20, 19, 0, 860, DateTimeKind.Local).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 20, 19, 0, 862, DateTimeKind.Local).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 28, 20, 19, 0, 862, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 20, 19, 0, 864, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 20, 19, 0, 864, DateTimeKind.Local).AddTicks(2407));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "21fee9cb-b38d-4c90-a77d-b3dee444804e");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "2dd0782e-a75e-4b45-8422-d20108efab05");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "42816968-45cc-4f49-aa90-197af1fb3b35");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "47e7b0de-6cd9-4895-9054-1c70c5c423ed");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "5927295e-df92-40e7-b780-9e0ab05fd4c1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "77c5b70c-4c90-4ebf-a3b3-3374e913cd3e");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "7bbb4df8-2a92-4ea5-8ebc-0ec72cfcc9d4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "d46c92bf-2369-462b-9bc7-da99f788813e");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "fbc63f06-619a-4002-a676-849fc4e8f4fb");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "29360479-462b-4cdf-902b-524ca80a4d44", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "7fac44cc-e2e9-4647-ac00-55848b658105", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "de758fe9-3276-4757-8561-7f5aafc4a896", null, "2b60f7f4-09c5-403c-882b-eadf0bf912d0", null, 3, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "64f49a47-6def-493e-9bf1-cddf81be4715", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "fc283b61-793b-4f34-9daf-5daa89200712", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "478fa936-6ef4-4a7c-8c70-751a1237b0a8", null, "adf78c99-8106-49df-b0dd-d0b145ddc53e", null, 3, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "fc2810f8-df87-44b0-8ac2-72d4aea49fe3", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "7cb486da-7567-475f-b6fa-71f41dfb380b", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 4, null });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ExerciseGroupId", "Name", "Reps", "Weight" },
                values: new object[] { "22d03bf1-95e0-47d0-bbaf-d022ab892105", null, "ba596bca-7603-4d16-b9bc-aae93a414330", null, 3, null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 27, 20, 16, 28, 353, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 20, 16, 28, 355, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 28, 20, 16, 28, 355, DateTimeKind.Local).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 20, 16, 28, 357, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 20, 16, 28, 357, DateTimeKind.Local).AddTicks(4569));
        }
    }
}
