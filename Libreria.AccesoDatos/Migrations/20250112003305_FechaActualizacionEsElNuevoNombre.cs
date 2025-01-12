using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Biblioteca_.Data.Migrations
{
    /// <inheritdoc />
    public partial class FechaActualizacionEsElNuevoNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaActualización",
                table: "SobreNosotros",
                newName: "FechaActualizacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaActualizacion",
                table: "SobreNosotros",
                newName: "FechaActualización");
        }
    }
}
