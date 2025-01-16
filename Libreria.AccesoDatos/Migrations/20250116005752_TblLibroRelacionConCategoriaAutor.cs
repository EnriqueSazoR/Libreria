using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Biblioteca_.Data.Migrations
{
    /// <inheritdoc />
    public partial class TblLibroRelacionConCategoriaAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categorias_IdCategoria",
                table: "Libro");

            migrationBuilder.DropTable(
                name: "AutorLibro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libro",
                table: "Libro");

            migrationBuilder.RenameTable(
                name: "Libro",
                newName: "Libros");

            migrationBuilder.RenameIndex(
                name: "IX_Libro_IdCategoria",
                table: "Libros",
                newName: "IX_Libros_IdCategoria");

            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libros",
                table: "Libros",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IdAutor",
                table: "Libros",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_IdAutor",
                table: "Libros",
                column: "IdAutor",
                principalTable: "Autores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_IdCategoria",
                table: "Libros",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_IdAutor",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_IdCategoria",
                table: "Libros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libros",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_IdAutor",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "IdAutor",
                table: "Libros");

            migrationBuilder.RenameTable(
                name: "Libros",
                newName: "Libro");

            migrationBuilder.RenameIndex(
                name: "IX_Libros_IdCategoria",
                table: "Libro",
                newName: "IX_Libro_IdCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libro",
                table: "Libro",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "AutorLibro",
                columns: table => new
                {
                    AutoresID = table.Column<int>(type: "int", nullable: false),
                    LibrosID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibro", x => new { x.AutoresID, x.LibrosID });
                    table.ForeignKey(
                        name: "FK_AutorLibro_Autores_AutoresID",
                        column: x => x.AutoresID,
                        principalTable: "Autores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLibro_Libro_LibrosID",
                        column: x => x.LibrosID,
                        principalTable: "Libro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorLibro_LibrosID",
                table: "AutorLibro",
                column: "LibrosID");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categorias_IdCategoria",
                table: "Libro",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
