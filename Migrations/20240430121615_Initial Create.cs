using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product_API_TakeTwo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountInStock = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "AmountInStock", "Category", "Price", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { 1, 10, 0, 15000.00m, "Decent PC", "Gaming PC v1" },
                    { 2, 12, 0, 20000.00m, "Average PC", "Gaming PC v2" },
                    { 3, 8, 0, 25000.00m, "Good PC", "Gaming PC v3" },
                    { 4, 5, 0, 30000.00m, "Very good PC", "Gaming PC v4" },
                    { 5, 20, 2, 300.00m, "Black color", "T-Shirt" },
                    { 6, 15, 2, 600.00m, "Light blue color", "Jeans" },
                    { 7, 10, 2, 700.00m, "White color", "Shirt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
