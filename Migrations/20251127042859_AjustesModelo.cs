using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasantiasTW.Migrations
{
    /// <inheritdoc />
    public partial class AjustesModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Practices_Companies_CompanyId",
                table: "Practices");

            migrationBuilder.AddForeignKey(
                name: "FK_Practices_Companies_CompanyId",
                table: "Practices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Practices_Companies_CompanyId",
                table: "Practices");

            migrationBuilder.AddForeignKey(
                name: "FK_Practices_Companies_CompanyId",
                table: "Practices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
