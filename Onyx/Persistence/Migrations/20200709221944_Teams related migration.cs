using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Teamsrelatedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ArchiveDate = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignedTeams",
                columns: table => new
                {
                    TeamId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTeams", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AssignedTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedTeams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "29ad0121-b184-461b-b2c9-518355e35123",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 8, 8, 18, 19, 44, 44, DateTimeKind.Local).AddTicks(2427), new DateTime(2020, 7, 9, 18, 19, 44, 41, DateTimeKind.Local).AddTicks(9193) });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 8, 8, 18, 19, 44, 44, DateTimeKind.Local).AddTicks(3017), new DateTime(2020, 7, 9, 18, 19, 44, 44, DateTimeKind.Local).AddTicks(2996) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 7, 9, 18, 19, 44, 45, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 7, 9, 18, 19, 44, 45, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTeams_UserId",
                table: "AssignedTeams",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedTeams");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "29ad0121-b184-461b-b2c9-518355e35123",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 7, 23, 19, 42, 32, 125, DateTimeKind.Local).AddTicks(452), new DateTime(2020, 6, 23, 19, 42, 32, 122, DateTimeKind.Local).AddTicks(7038) });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 7, 23, 19, 42, 32, 125, DateTimeKind.Local).AddTicks(1062), new DateTime(2020, 6, 23, 19, 42, 32, 125, DateTimeKind.Local).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 6, 23, 19, 42, 32, 126, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 6, 23, 19, 42, 32, 126, DateTimeKind.Local).AddTicks(2979));
        }
    }
}
