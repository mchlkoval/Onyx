using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "IsDeleted" },
                values: new object[] { "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78", "Test Message 1", false });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "IsDeleted" },
                values: new object[] { "d1940fcc-f86a-4b48-ad97-3f7ff1321647", "Test Message 2", false });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "IsDeleted" },
                values: new object[] { "b92e0a10-33e1-4108-be76-c1ec87677330", "Test Message 3", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "3a0a646e-2fa8-4ab9-b2dc-3aa2518d4e78");

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "b92e0a10-33e1-4108-be76-c1ec87677330");

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: "d1940fcc-f86a-4b48-ad97-3f7ff1321647");
        }
    }
}
