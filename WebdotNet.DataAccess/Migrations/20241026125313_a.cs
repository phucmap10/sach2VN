using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebdotNet.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Horror" },
                    { 3, 3, "SciFi" },
                    { 4, 4, "History" },
                    { 5, 5, "Comedy" },
                    { 6, 6, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Author", "Category", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Suzanne Collins", "Action", "A dystopian novel set in a post-apocalyptic world.", "9780439023481", 10.99, 9.9900000000000002, 7.9900000000000002, 8.9900000000000002, "The Hunger Games" },
                    { 2, "Bram Stoker", "Horror", "A horror novel about the vampire Count Dracula.", "9780141439846", 8.9900000000000002, 7.9900000000000002, 5.9900000000000002, 6.9900000000000002, "Dracula" },
                    { 3, "Frank Herbert", "SciFi", "A science fiction novel set in a distant future amidst a huge interstellar empire.", "9780441013593", 9.9900000000000002, 8.9900000000000002, 6.9900000000000002, 7.9900000000000002, "Dune" },
                    { 4, "Yuval Noah Harari", "History", "A brief history of humankind.", "9780062316097", 14.99, 13.99, 11.99, 12.99, "Sapiens" },
                    { 5, "Tina Fey", "Comedy", "A comedy memoir by Tina Fey.", "9780316056892", 12.99, 11.99, 9.9900000000000002, 10.99, "Bossypants" },
                    { 6, "Jane Austen", "Romance", "A romance novel by Jane Austen.", "9780141040349", 7.9900000000000002, 6.9900000000000002, 4.9900000000000002, 5.9900000000000002, "Pride and Prejudice" },
                    { 7, "Suzanne Collins", "Action", "The second book in The Hunger Games series.", "9780439023498", 10.99, 9.9900000000000002, 7.9900000000000002, 8.9900000000000002, "Catching Fire" },
                    { 8, "Mary Shelley", "Horror", "A horror novel about a scientist who creates a monster.", "9780141439471", 8.9900000000000002, 7.9900000000000002, 5.9900000000000002, 6.9900000000000002, "Frankenstein" },
                    { 9, "William Gibson", "SciFi", "A science fiction novel that tells the story of a washed-up computer hacker.", "9780441569595", 9.9900000000000002, 8.9900000000000002, 6.9900000000000002, 7.9900000000000002, "Neuromancer" },
                    { 10, "Jared Diamond", "History", "A history book that explores the factors that contributed to the development of human societies.", "9780393354324", 14.99, 13.99, 11.99, 12.99, "Guns, Germs, and Steel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
