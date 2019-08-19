using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bsd.Cars.Infraestructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Order",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CarFrame = table.Column<string>(maxLength: 17, nullable: false),
                    Model = table.Column<string>(maxLength: 17, nullable: false),
                    LicensePlate = table.Column<string>(maxLength: 7, nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropSequence(
                name: "Order");
        }
    }
}
