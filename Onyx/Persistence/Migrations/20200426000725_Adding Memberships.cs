using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddingMemberships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { "29ad0121-b184-461b-b2c9-518355e35123", 250.0, "Approved by Boris, loved by Slavs, misunderstood by Americans.", "Gopnik Workout" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { "615ca8e5-0124-4ea6-85b4-3badb4a6ec1a", 100.0, "Simple and effective after you gorged yourself", "Squats and Pull Ups" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships");
        }
    }
}
