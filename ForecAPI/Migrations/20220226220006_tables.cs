using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecAPI.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Modify_Date",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MPR_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total_Estimate_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason_For_Purchase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_For_Delivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method_of_Delivery = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropColumn(
                name: "Last_Modify_Date",
                table: "AspNetUsers");
        }
    }
}
