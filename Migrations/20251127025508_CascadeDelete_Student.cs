using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasantiasTW.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete_Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Practices_Students_StudentId",
                table: "Practices");

            migrationBuilder.AddForeignKey(
                name: "FK_Practices_Students_StudentId",
                table: "Practices",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Practices_Students_StudentId",
                table: "Practices");

            migrationBuilder.AddForeignKey(
                name: "FK_Practices_Students_StudentId",
                table: "Practices",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
