using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Updatedworkoutentityalongwithmembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymClass",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    DateOfClass = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MembershipId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateOfWorkout = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workout_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 25, 19, 19, 5, 160, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 24, 19, 19, 5, 163, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 19, 19, 5, 163, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "MembershipId", "Name" },
                values: new object[] { "4dfe23e8-934c-40d4-83ab-dab6c1354425", new DateTime(2020, 4, 26, 19, 19, 5, 165, DateTimeKind.Local).AddTicks(1370), "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik One" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "MembershipId", "Name" },
                values: new object[] { "d6286ac3-4455-4b7f-a872-bc00e4db33de", new DateTime(2020, 4, 27, 19, 19, 5, 165, DateTimeKind.Local).AddTicks(2798), "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik Two" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "MembershipId", "Name" },
                values: new object[] { "c777269a-fa4e-43bc-b4e1-d26c9da71774", new DateTime(2020, 4, 28, 19, 19, 5, 165, DateTimeKind.Local).AddTicks(2846), "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik Three" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "MembershipId", "Name" },
                values: new object[] { "5aea42fe-3a48-4c5c-b0b5-6528d1b46d5a", new DateTime(2020, 4, 26, 19, 19, 5, 165, DateTimeKind.Local).AddTicks(2852), "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat One" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "MembershipId", "Name" },
                values: new object[] { "cffab7f2-5403-4850-93c6-73a2f3857f3b", new DateTime(2020, 4, 27, 19, 19, 5, 165, DateTimeKind.Local).AddTicks(2858), "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat Two" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "MembershipId", "Name" },
                values: new object[] { "c779f3da-5f1e-4520-b843-994cc1281e78", new DateTime(2020, 4, 28, 19, 19, 5, 165, DateTimeKind.Local).AddTicks(2864), "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat Three" });

            migrationBuilder.CreateIndex(
                name: "IX_Workout_MembershipId",
                table: "Workout",
                column: "MembershipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymClass");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 25, 13, 45, 34, 43, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 24, 13, 45, 34, 45, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 13, 45, 34, 45, DateTimeKind.Local).AddTicks(9521));
        }
    }
}
