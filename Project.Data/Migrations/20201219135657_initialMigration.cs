using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Project.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductName = table.Column<string>(maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Stock = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Price", "ProductName", "Stock" },
                values: new object[] { 1, 7500m, "Cep Telefonu", (short)50 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Price", "ProductName", "Stock" },
                values: new object[] { 2, 12000m, "Bilgisayar", (short)40 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Price", "ProductName", "Stock" },
                values: new object[] { 3, 3000m, "Tablet", (short)10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
