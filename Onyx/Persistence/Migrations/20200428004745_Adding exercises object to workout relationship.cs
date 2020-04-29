using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Addingexercisesobjecttoworkoutrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "4dfe23e8-934c-40d4-83ab-dab6c1354425");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "5aea42fe-3a48-4c5c-b0b5-6528d1b46d5a");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "c777269a-fa4e-43bc-b4e1-d26c9da71774");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "c779f3da-5f1e-4520-b843-994cc1281e78");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "cffab7f2-5403-4850-93c6-73a2f3857f3b");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "d6286ac3-4455-4b7f-a872-bc00e4db33de");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Workout",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    WorkoutId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Pace = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    Sets = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 26, 20, 47, 44, 864, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 25, 20, 47, 44, 866, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647",
                column: "DateOfMessage",
                value: new DateTime(2020, 4, 27, 20, 47, 44, 866, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "7baa4d8f-80b8-468d-88ac-7510fb46f75d", new DateTime(2020, 4, 27, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(4578), null, "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik One" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "4439ae99-91c5-4866-bc7d-565a7ec1253b", new DateTime(2020, 4, 28, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6039), null, "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik Two" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "e137e6e9-d68c-42e8-a7e0-0085cd4f1a53", new DateTime(2020, 4, 29, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6096), null, "29ad0121-b184-461b-b2c9-518355e35123", "Gopnik Three" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "eb38554c-57e8-4834-ab1f-c610e4e96659", new DateTime(2020, 4, 27, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6103), null, "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat One" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "2d1bf3d6-a939-4a48-b2a0-b03687c4130c", new DateTime(2020, 4, 28, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6109), null, "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat Two" });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "DateOfWorkout", "Description", "MembershipId", "Name" },
                values: new object[] { "b538b3af-4136-49fe-9edd-24f74fc424cd", new DateTime(2020, 4, 29, 20, 47, 44, 868, DateTimeKind.Local).AddTicks(6117), null, "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", "Squat Three" });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_WorkoutId",
                table: "Exercise",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "2d1bf3d6-a939-4a48-b2a0-b03687c4130c");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "4439ae99-91c5-4866-bc7d-565a7ec1253b");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "7baa4d8f-80b8-468d-88ac-7510fb46f75d");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "b538b3af-4136-49fe-9edd-24f74fc424cd");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "e137e6e9-d68c-42e8-a7e0-0085cd4f1a53");

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: "eb38554c-57e8-4834-ab1f-c610e4e96659");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Workout");

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
        }
    }
}
