using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApp.SQLite;

namespace ProjetoCinemaEFcore.Migrations
{
    [DbContext(typeof(Cinema))]
    [Migration("20160918234830_AlterandoBanco")]
    partial class AlterandoBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("ConsoleApp.SQLite.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Exibicao", b =>
                {
                    b.Property<int>("ExibicaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.Property<int?>("FilmeId");

                    b.Property<string>("Horario");

                    b.Property<int?>("SalaId");

                    b.HasKey("ExibicaoId");

                    b.HasIndex("FilmeId");

                    b.HasIndex("SalaId");

                    b.ToTable("Exibicoes");
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Filme", b =>
                {
                    b.Property<int>("FilmeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoLancamento");

                    b.Property<int?>("CategoriasCategoriaId");

                    b.Property<int>("Duracao");

                    b.Property<string>("Nome");

                    b.Property<string>("Sinopse");

                    b.HasKey("FilmeId");

                    b.HasIndex("CategoriasCategoriaId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacidade");

                    b.Property<string>("Nome");

                    b.Property<int>("TamanhoTela");

                    b.HasKey("SalaId");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Exibicao", b =>
                {
                    b.HasOne("ConsoleApp.SQLite.Filme", "Filme")
                        .WithMany("Exibicoes")
                        .HasForeignKey("FilmeId");

                    b.HasOne("ConsoleApp.SQLite.Sala", "Sala")
                        .WithMany("Exibicoes")
                        .HasForeignKey("SalaId");
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Filme", b =>
                {
                    b.HasOne("ConsoleApp.SQLite.Categoria", "Categorias")
                        .WithMany("Filmes")
                        .HasForeignKey("CategoriasCategoriaId");
                });
        }
    }
}
