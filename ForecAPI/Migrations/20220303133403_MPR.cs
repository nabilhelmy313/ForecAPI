using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecAPI.Migrations
{
    public partial class MPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quotations",
                table: "Quotations");

            migrationBuilder.RenameTable(
                name: "Quotations",
                newName: "MPRs");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_Address_For_Delivery",
                table: "MPRs",
                newName: "IX_MPRs_Address_For_Delivery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MPRs",
                table: "MPRs",
                column: "Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MPRs_Bases_Address_For_Delivery",
                table: "MPRs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MPRs",
                table: "MPRs");

            migrationBuilder.RenameTable(
                name: "MPRs",
                newName: "Quotations");

            migrationBuilder.AddPrimaryKey(
              name: "PK_Quotations",
              table: "Quotations",
              column: "Id");


        }
    }
}
