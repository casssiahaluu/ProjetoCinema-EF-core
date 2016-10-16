using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Capacidade = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    TamanhoTela = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    FilmeId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AnoLancamento = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    Duracao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sinopse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.FilmeId);
                    table.ForeignKey(
                        name: "FK_Filmes_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exibicoes",
                columns: table => new
                {
                    ExibicaoId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Data = table.Column<string>(nullable: true),
                    FilmeId = table.Column<int>(nullable: false),
                    Horario = table.Column<string>(nullable: true),
                    SalaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exibicoes", x => x.ExibicaoId);
                    table.ForeignKey(
                        name: "FK_Exibicoes_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "FilmeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exibicoes_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exibicoes_FilmeId",
                table: "Exibicoes",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exibicoes_SalaId",
                table: "Exibicoes",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_CategoriaId",
                table: "Filmes",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exibicoes");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
