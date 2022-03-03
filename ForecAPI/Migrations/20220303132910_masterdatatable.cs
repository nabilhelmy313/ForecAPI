using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecAPI.Migrations
{
    public partial class masterdatatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_Forces_ForceId",
                table: "Bases");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseSections_Bases_BaseId",
                table: "BaseSections");

            migrationBuilder.DropIndex(
                name: "IX_BaseSections_BaseId",
                table: "BaseSections");

            migrationBuilder.DropIndex(
                name: "IX_Bases_ForceId",
                table: "Bases");

            migrationBuilder.AlterColumn<string>(
                name: "Address_For_Delivery",
                table: "Quotations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type_Code",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MasterDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Master_Data_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterData_Parent_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_Modify_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDatas", x => x.Id);
                });

         
            migrationBuilder.AddForeignKey(
                name: "FK_Bases_Forces_Id",
                table: "Bases",
                column: "Id",
                principalTable: "Forces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseSections_Bases_Id",
                table: "BaseSections",
                column: "Id",
                principalTable: "Bases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_Forces_Id",
                table: "Bases");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseSections_Bases_Id",
                table: "BaseSections");

          
            migrationBuilder.DropTable(
                name: "MasterDatas");


            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Type_Code",
                table: "Quotations");

            migrationBuilder.AlterColumn<string>(
                name: "Address_For_Delivery",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseSections_BaseId",
                table: "BaseSections",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_ForceId",
                table: "Bases",
                column: "ForceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bases_Forces_ForceId",
                table: "Bases",
                column: "ForceId",
                principalTable: "Forces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseSections_Bases_BaseId",
                table: "BaseSections",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
