using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class seedexercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "AppUserId", "Description", "Name", "Reps", "Sets", "Weight", "WorkoutId" },
                values: new object[] { "cb168e0f-ed08-4588-ae72-1b2fb80daff3", null, "Basic pull ups", "Upper Body", 5, 5, null, "ba596bca-7603-4d16-b9bc-aae93a414330" });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "AppUserId", "Description", "Name", "Reps", "Sets", "Weight", "WorkoutId" },
                values: new object[] { "e3986007-27cf-4abd-86ed-589f99246482", null, "Basic sit ups", "Core Muscles", 10, 10, null, "ba596bca-7603-4d16-b9bc-aae93a414330" });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "AppUserId", "Description", "Name", "Reps", "Sets", "Weight", "WorkoutId" },
                values: new object[] { "cf25e17b-e402-4f39-9a5f-03fdc0cc513a", null, "Pushing against weights on the leg machine", "Leg Muscles", 10, 5, 30, "ba596bca-7603-4d16-b9bc-aae93a414330" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 7, 21, 5, 18, 77, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 6, 21, 5, 18, 80, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 8, 21, 5, 18, 80, DateTimeKind.Local).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 8, 21, 5, 18, 82, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 8, 21, 5, 18, 81, DateTimeKind.Local).AddTicks(8589));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "cb168e0f-ed08-4588-ae72-1b2fb80daff3");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "cf25e17b-e402-4f39-9a5f-03fdc0cc513a");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: "e3986007-27cf-4abd-86ed-589f99246482");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 7, 18, 27, 33, 414, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 6, 18, 27, 33, 417, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 8, 18, 27, 33, 417, DateTimeKind.Local).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 8, 18, 27, 33, 419, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 8, 18, 27, 33, 418, DateTimeKind.Local).AddTicks(9184));
        }
    }
}
