using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoCinemaEFcore.Migrations
{
    public partial class MudandoDeLugar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Categorias_CategoriasCategoriaId",
                table: "Filmes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Salas",
                maxLength: 255,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Sinopse",
                table: "Filmes",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Filmes",
                maxLength: 255,
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriasCategoriaId",
                table: "Filmes",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Categorias_CategoriasCategoriaId",
                table: "Filmes",
                column: "CategoriasCategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Categorias_CategoriasCategoriaId",
                table: "Filmes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Salas",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sinopse",
                table: "Filmes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Filmes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriasCategoriaId",
                table: "Filmes",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Categorias_CategoriasCategoriaId",
                table: "Filmes",
                column: "CategoriasCategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
