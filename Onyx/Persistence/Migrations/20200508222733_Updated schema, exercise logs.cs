using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Updatedschemaexerciselogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseLog",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Reps = table.Column<string>(nullable: true),
                    Sets = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    ExerciseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseLog_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseLog_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseLog_AppUserId",
                table: "ExerciseLog",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseLog_ExerciseId",
                table: "ExerciseLog",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseLog");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 1, 21, 3, 41, 426, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 30, 21, 3, 41, 429, DateTimeKind.Local).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 5, 2, 21, 3, 41, 429, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5f2ed3f1-a767-4803-b612-d3f04e508cc1",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 2, 21, 3, 41, 430, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "ba596bca-7603-4d16-b9bc-aae93a414330",
                column: "DateOfWorkout",
                value: new DateTime(2020, 5, 2, 21, 3, 41, 430, DateTimeKind.Local).AddTicks(7281));
        }
    }
}
