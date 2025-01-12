using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Biblioteca_.Data.Migrations
{
    /// <inheritdoc />
    public partial class TablaSobreNosotros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SobreNosotros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaActualización = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SobreNosotros", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SobreNosotros");
        }
    }
}
