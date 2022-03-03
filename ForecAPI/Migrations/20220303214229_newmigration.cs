using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecAPI.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
          
            migrationBuilder.DropColumn(
                name: "BaseCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BaseSectionCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ForceCode",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ForceCode",
                table: "Forces",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "BaseSections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BaseSections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BaseSectionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForceId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BaseId",
                table: "AspNetUsers",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BaseSectionId",
                table: "AspNetUsers",
                column: "BaseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ForceId",
                table: "AspNetUsers",
                column: "ForceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bases_BaseId",
                table: "AspNetUsers",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BaseSections_BaseSectionId",
                table: "AspNetUsers",
                column: "BaseSectionId",
                principalTable: "BaseSections",
                principalColumn: "Id"
               );

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Forces_ForceId",
                table: "AspNetUsers",
                column: "ForceId",
                principalTable: "Forces",
                principalColumn: "Id"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Bases_BaseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BaseSections_BaseSectionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Forces_ForceId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BaseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BaseSectionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ForceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BaseSections");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BaseSectionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ForceId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ForceCode",
                table: "Forces",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "BaseSections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BaseCode",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BaseSectionCode",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForceCode",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Forces_ForceCode",
                table: "Forces",
                column: "ForceCode");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_BaseSections_Code",
                table: "BaseSections",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BaseCode",
                table: "AspNetUsers",
                column: "BaseCode");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BaseSectionCode",
                table: "AspNetUsers",
                column: "BaseSectionCode");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ForceCode",
                table: "AspNetUsers",
                column: "ForceCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bases_BaseCode",
                table: "AspNetUsers",
                column: "BaseCode",
                principalTable: "Bases",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BaseSections_BaseSectionCode",
                table: "AspNetUsers",
                column: "BaseSectionCode",
                principalTable: "BaseSections",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Forces_ForceCode",
                table: "AspNetUsers",
                column: "ForceCode",
                principalTable: "Forces",
                principalColumn: "ForceCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
