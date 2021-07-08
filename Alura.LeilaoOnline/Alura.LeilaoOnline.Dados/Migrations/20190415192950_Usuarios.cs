using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.LeilaoOnline.WebApp.Dados.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    InteressadaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Interessada_InteressadaId",
                        column: x => x.InteressadaId,
                        principalTable: "Interessada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Interessada",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Fulano de Tal" },
                    { 2, "Mariana Mary" },
                    { 3, "Sicrana Silva" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "InteressadaId", "Senha" },
                values: new object[] { 3, "admin@example.org", null, "123" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "InteressadaId", "Senha" },
                values: new object[] { 1, "fulano@example.org", 1, "123" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "InteressadaId", "Senha" },
                values: new object[] { 2, "mariana@example.org", 2, "456" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_InteressadaId",
                table: "Usuarios",
                column: "InteressadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DeleteData(
                table: "Interessada",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interessada",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interessada",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
