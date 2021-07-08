using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.LeilaoOnline.WebApp.Dados.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interessada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interessada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    LeilaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lance_Interessada_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Interessada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leiloes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Categoria = table.Column<string>(nullable: false),
                    Imagem = table.Column<string>(nullable: false),
                    ValorInicial = table.Column<double>(nullable: false),
                    InicioPregao = table.Column<DateTime>(nullable: false),
                    TerminoPregao = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    GanhadorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leiloes_Lance_GanhadorId",
                        column: x => x.GanhadorId,
                        principalTable: "Lance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lance_ClienteId",
                table: "Lance",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_LeilaoId",
                table: "Lance",
                column: "LeilaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Leiloes_GanhadorId",
                table: "Leiloes",
                column: "GanhadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lance_Leiloes_LeilaoId",
                table: "Lance",
                column: "LeilaoId",
                principalTable: "Leiloes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            #region Inclusão de Leilões de Arte Fictícios

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Arte 1",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Arte e Pintura",
                    "/images/painting1.jpg",
                    859.99,
                    DateTime.Now.AddDays(-2),
                    DateTime.Now.AddDays(2),
                    "LeilaoEmAndamento"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Arte 2",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Arte e Pintura",
                    "/images/painting2.jpg",
                    935.78,
                    DateTime.Now.AddDays(-1),
                    DateTime.Now.AddDays(3),
                    "LeilaoEmAndamento"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Arte 3",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Arte e Pintura",
                    "/images/painting3.jpg",
                    57.90,
                    DateTime.Now.AddDays(3),
                    DateTime.Now.AddDays(7),
                    "LeilaoAntesDoPregao"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Arte 4",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Arte e Pintura",
                    "/images/painting4.jpg",
                    120.0,
                    DateTime.Now.AddDays(5),
                    DateTime.Now.AddDays(15),
                    "LeilaoAntesDoPregao"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Arte 5",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Arte e Pintura",
                    "/images/painting5.jpg",
                    1500.0,
                    DateTime.Now.AddDays(-5),
                    DateTime.Now.AddDays(-1),
                    "LeilaoFinalizado"
                }
            );

            #endregion

            #region Inclusão de Leilões de Carro Fictícios

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Carro 1",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Automóveis",
                    "/images/carro1.jpg",
                    21000.0,
                    DateTime.Now.AddDays(-2),
                    DateTime.Now.AddDays(2),
                    "LeilaoEmAndamento"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Carro 2",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Automóveis",
                    "/images/carro2.jpg",
                    14500.0,
                    DateTime.Now.AddDays(-1),
                    DateTime.Now.AddDays(3),
                    "LeilaoEmAndamento"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Carro 3",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Automóveis",
                    "/images/carro3.jpg",
                    5890.0,
                    DateTime.Now.AddDays(3),
                    DateTime.Now.AddDays(7),
                    "LeilaoAntesDoPregao"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Carro 4",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Automóveis",
                    "/images/carro4.jpg",
                    6700.0,
                    DateTime.Now.AddDays(5),
                    DateTime.Now.AddDays(15),
                    "LeilaoAntesDoPregao"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Carro 5",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Automóveis",
                    "/images/carro5.jpg",
                    15900.0,
                    DateTime.Now.AddDays(-5),
                    DateTime.Now.AddDays(-1),
                    "LeilaoFinalizado"
                }
            );

            #endregion

            #region Includão de Leilões de Instrumentos Fictícios

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Instrumento 1",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Item de Colecionador",
                    "/images/instrumento1.jpg",
                    8259.99,
                    DateTime.Now.AddDays(-2),
                    DateTime.Now.AddDays(2),
                    "LeilaoEmAndamento"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Instrumento 2",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Item de Colecionador",
                    "/images/instrumento2.jpg",
                    6400.37,
                    DateTime.Now.AddDays(-1),
                    DateTime.Now.AddDays(3),
                    "LeilaoEmAndamento"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Instrumento 3",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Item de Colecionador",
                    "/images/instrumento3.jpg",
                    3857.90,
                    DateTime.Now.AddDays(3),
                    DateTime.Now.AddDays(7),
                    "LeilaoAntesDoPregao"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Instrumento 4",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Item de Colecionador",
                    "/images/instrumento4.jpg",
                    17280.0,
                    DateTime.Now.AddDays(5),
                    DateTime.Now.AddDays(15),
                    "LeilaoAntesDoPregao"
                }
            );

            migrationBuilder.InsertData(
                table: "Leiloes",
                columns: new string[] {
                    "Titulo",
                    "Descricao",
                    "Categoria",
                    "Imagem",
                    "ValorInicial",
                    "InicioPregao",
                    "TerminoPregao",
                    "Estado"
                },
                values: new object[] {
                    "Leilão de Instrumento 5",
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    "Item de Colecionador",
                    "/images/instrumento5.jpg",
                    5420.0,
                    DateTime.Now.AddDays(-5),
                    DateTime.Now.AddDays(-1),
                    "LeilaoFinalizado"
                }
            );

            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lance_Interessada_ClienteId",
                table: "Lance");

            migrationBuilder.DropForeignKey(
                name: "FK_Lance_Leiloes_LeilaoId",
                table: "Lance");

            migrationBuilder.DropTable(
                name: "Interessada");

            migrationBuilder.DropTable(
                name: "Leiloes");

            migrationBuilder.DropTable(
                name: "Lance");
        }
    }
}
