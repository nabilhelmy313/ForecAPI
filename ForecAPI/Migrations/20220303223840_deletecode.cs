using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecAPI.Migrations
{
    public partial class deletecode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "ForceCode",
                table: "Forces");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "BaseSections");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Bases");

            migrationBuilder.AlterColumn<Guid>(
                name: "Address_For_Delivery",
                table: "MPRs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MPRs_Bases_Address_For_Delivery",
                table: "MPRs",
                column: "Address_For_Delivery",
                principalTable: "Bases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MPRs_Bases_Address_For_Delivery",
                table: "MPRs");

            migrationBuilder.AlterColumn<string>(
                name: "Address_For_Delivery",
                table: "MPRs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForceCode",
                table: "Forces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "BaseSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Bases",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Bases_Code",
                table: "Bases",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_MPRs_Bases_Address_For_Delivery",
                table: "MPRs",
                column: "Address_For_Delivery",
                principalTable: "Bases",
                principalColumn: "Code");
        }
    }
}
