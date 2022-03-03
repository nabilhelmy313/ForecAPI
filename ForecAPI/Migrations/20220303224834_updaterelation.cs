using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForecAPI.Migrations
{
    public partial class updaterelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_Forces_Id",
                table: "Bases");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseSections_Bases_Id",
                table: "BaseSections");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
