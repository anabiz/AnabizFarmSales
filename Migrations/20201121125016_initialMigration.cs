using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnabizFarmSales.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FarmSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PigType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NoOfPigs = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TotalWeight = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmSales", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmSales");
        }
    }
}
