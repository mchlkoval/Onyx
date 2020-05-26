using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdatestoAppUsertoincludemoredata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateArchived",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "29ad0121-b184-461b-b2c9-518355e35123",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 24, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(6070), new DateTime(2020, 5, 25, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(5509) });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 24, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(6701), new DateTime(2020, 5, 25, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(6681) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 24, 20, 26, 32, 652, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 23, 20, 26, 32, 655, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 25, 20, 26, 32, 655, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 25, 20, 26, 32, 657, DateTimeKind.Local).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 25, 20, 26, 32, 656, DateTimeKind.Local).AddTicks(8023));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateArchived",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "29ad0121-b184-461b-b2c9-518355e35123",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 14, 20, 55, 39, 238, DateTimeKind.Local).AddTicks(4375), new DateTime(2020, 5, 15, 20, 55, 39, 238, DateTimeKind.Local).AddTicks(3885) });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 14, 20, 55, 39, 238, DateTimeKind.Local).AddTicks(4916), new DateTime(2020, 5, 15, 20, 55, 39, 238, DateTimeKind.Local).AddTicks(4892) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 14, 20, 55, 39, 234, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 13, 20, 55, 39, 237, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 15, 20, 55, 39, 237, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 15, 20, 55, 39, 238, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 15, 20, 55, 39, 238, DateTimeKind.Local).AddTicks(6310));
        }
    }
}
