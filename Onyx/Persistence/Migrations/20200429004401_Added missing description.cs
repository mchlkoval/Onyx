using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Addedmissingdescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 27, 20, 44, 1, 33, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 20, 44, 1, 36, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 28, 20, 44, 1, 36, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                columns: new[] { "DateOfWorkout", "Description" },
                values: new object[] { new DateTime(2020, 4, 28, 20, 44, 1, 37, DateTimeKind.Local).AddTicks(8331), "Test Description" });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 20, 44, 1, 37, DateTimeKind.Local).AddTicks(6115));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 27, 20, 23, 31, 287, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 20, 23, 31, 290, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 28, 20, 23, 31, 290, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                columns: new[] { "DateOfWorkout", "Description" },
                values: new object[] { new DateTime(2020, 4, 28, 20, 23, 31, 291, DateTimeKind.Local).AddTicks(9485), "" });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 4, 28, 20, 23, 31, 291, DateTimeKind.Local).AddTicks(7306));
        }
    }
}
