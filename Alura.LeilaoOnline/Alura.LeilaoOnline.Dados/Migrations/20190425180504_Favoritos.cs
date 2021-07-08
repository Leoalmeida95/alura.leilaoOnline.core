using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.LeilaoOnline.WebApp.Dados.Migrations
{
    public partial class Favoritos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    IdLeilao = table.Column<int>(nullable: false),
                    IdInteressada = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => new { x.IdLeilao, x.IdInteressada });
                    table.ForeignKey(
                        name: "FK_Favoritos_Interessada_IdInteressada",
                        column: x => x.IdInteressada,
                        principalTable: "Interessada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Leiloes_IdLeilao",
                        column: x => x.IdLeilao,
                        principalTable: "Leiloes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdInteressada",
                table: "Favoritos",
                column: "IdInteressada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");
        }
    }
}
