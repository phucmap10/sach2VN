using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebdotNet.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategory1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "DisplayOrder", "Name" },
                values: new object[] { 6, 6, "Romance" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
