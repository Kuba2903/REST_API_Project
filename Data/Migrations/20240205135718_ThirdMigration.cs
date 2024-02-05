using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Products_price_id_SKU",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "price_id",
                table: "Prices",
                newName: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Products_ProductId_SKU",
                table: "Prices",
                columns: new[] { "ProductId", "SKU" },
                principalTable: "Products",
                principalColumns: new[] { "Id", "SKU" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Products_ProductId_SKU",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Prices",
                newName: "price_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Products_price_id_SKU",
                table: "Prices",
                columns: new[] { "price_id", "SKU" },
                principalTable: "Products",
                principalColumns: new[] { "Id", "SKU" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
