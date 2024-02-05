using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SKU = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    unit = table.Column<string>(type: "TEXT", nullable: false),
                    qty = table.Column<int>(type: "INTEGER", nullable: false),
                    manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    shippingtime = table.Column<string>(name: "shipping_time", type: "TEXT", nullable: false),
                    shippingcost = table.Column<double>(name: "shipping_cost", type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SKU = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    netprice = table.Column<double>(name: "net_price", type: "REAL", nullable: false),
                    netpriceafterdiscount = table.Column<double>(name: "net_price_after_discount", type: "REAL", nullable: false),
                    vatrate = table.Column<short>(name: "vat_rate", type: "INTEGER", nullable: false),
                    netpriceafterdiscountforlogisticunit = table.Column<double>(name: "net_price_after_discount_for_logistic_unit", type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SKU = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    EAN = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    producername = table.Column<string>(name: "producer_name", type: "TEXT", nullable: false),
                    category = table.Column<string>(type: "TEXT", nullable: false),
                    iswire = table.Column<bool>(name: "is_wire", type: "INTEGER", nullable: false),
                    isavailable = table.Column<bool>(name: "is_available", type: "INTEGER", nullable: false),
                    isvendor = table.Column<bool>(name: "is_vendor", type: "INTEGER", nullable: false),
                    defaultimage = table.Column<string>(name: "default_image", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
