using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CoachToAthletejointable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignedAthletes",
                columns: table => new
                {
                    AthleteId = table.Column<string>(nullable: false),
                    CoachId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedAthletes", x => new { x.AthleteId, x.CoachId });
                    table.ForeignKey(
                        name: "FK_AssignedAthletes_AspNetUsers_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedAthletes_AspNetUsers_CoachId",
                        column: x => x.CoachId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "29ad0121-b184-461b-b2c9-518355e35123",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 7, 7, 15, 55, 54, 714, DateTimeKind.Local).AddTicks(2427), new DateTime(2020, 6, 7, 15, 55, 54, 714, DateTimeKind.Local).AddTicks(1944) });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 7, 7, 15, 55, 54, 714, DateTimeKind.Local).AddTicks(3001), new DateTime(2020, 6, 7, 15, 55, 54, 714, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 6, 6, 15, 55, 54, 710, DateTimeKind.Local).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 6, 5, 15, 55, 54, 712, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 6, 7, 15, 55, 54, 712, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 6, 7, 15, 55, 54, 714, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 6, 7, 15, 55, 54, 714, DateTimeKind.Local).AddTicks(4235));

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAthletes_CoachId",
                table: "AssignedAthletes",
                column: "CoachId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedAthletes");

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "29ad0121-b184-461b-b2c9-518355e35123",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 29, 11, 43, 21, 355, DateTimeKind.Local).AddTicks(8663), new DateTime(2020, 5, 30, 11, 43, 21, 355, DateTimeKind.Local).AddTicks(8126) });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 29, 11, 43, 21, 355, DateTimeKind.Local).AddTicks(9244), new DateTime(2020, 5, 30, 11, 43, 21, 355, DateTimeKind.Local).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 29, 11, 43, 21, 352, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 28, 11, 43, 21, 354, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 30, 11, 43, 21, 354, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 30, 11, 43, 21, 356, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 30, 11, 43, 21, 356, DateTimeKind.Local).AddTicks(539));
        }
    }
}
