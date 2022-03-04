using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecAPI.Migrations
{
    public partial class mprbaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MPRs_Bases_Address_For_Delivery",
                table: "MPRs");

            migrationBuilder.AlterColumn<string>(
                name: "Type_Code",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Reason_For_Purchase",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Method_of_Delivery",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MPR_Number",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_For_Delivery",
                table: "MPRs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create_Date",
                table: "MPRs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Is_Deleted",
                table: "MPRs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Modify_Date",
                table: "MPRs",
                type: "datetime2",
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
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MPRs_Bases_Address_For_Delivery",
                table: "MPRs");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Bases_Code",
                table: "Bases");

            migrationBuilder.DropColumn(
                name: "Create_Date",
                table: "MPRs");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "MPRs");

            migrationBuilder.DropColumn(
                name: "Last_Modify_Date",
                table: "MPRs");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Bases");

            migrationBuilder.AlterColumn<string>(
                name: "Type_Code",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reason_For_Purchase",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Method_of_Delivery",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MPR_Number",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MPRs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Address_For_Delivery",
                table: "MPRs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_MPRs_Bases_Address_For_Delivery",
                table: "MPRs",
                column: "Address_For_Delivery",
                principalTable: "Bases",
                principalColumn: "Id");
        }
    }
}
