using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasantiasTW.Migrations
{
    /// <inheritdoc />
    public partial class RenameCarreraToCareer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Carrera",
                table: "Students",
                newName: "Career");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Career",
                table: "Students",
                newName: "Carrera");
        }
    }
}
