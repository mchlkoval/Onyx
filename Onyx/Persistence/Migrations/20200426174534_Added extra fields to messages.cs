using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Addedextrafieldstomessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfMessage",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Messages",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                columns: new[] { "DateOfMessage", "From" },
                values: new object[] { new DateTime(2020, 4, 25, 13, 45, 34, 43, DateTimeKind.Local).AddTicks(2420), "Anna Runner" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                columns: new[] { "DateOfMessage", "From" },
                values: new object[] { new DateTime(2020, 4, 24, 13, 45, 34, 45, DateTimeKind.Local).AddTicks(9559), "Aaron Runner" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                columns: new[] { "DateOfMessage", "From" },
                values: new object[] { new DateTime(2020, 4, 26, 13, 45, 34, 45, DateTimeKind.Local).AddTicks(9521), "Michael Kovalsky" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfMessage",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Messages");
        }
    }
}
