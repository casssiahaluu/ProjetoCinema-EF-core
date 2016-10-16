using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CinemaDB.Models;

namespace Cinema.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161016221736_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("CinemaDB.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CinemaDB.Models.Exibicao", b =>
                {
                    b.Property<int>("ExibicaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.Property<int>("FilmeId");

                    b.Property<string>("Horario");

                    b.Property<int>("SalaId");

                    b.HasKey("ExibicaoId");

                    b.HasIndex("FilmeId");

                    b.HasIndex("SalaId");

                    b.ToTable("Exibicoes");
                });

            modelBuilder.Entity("CinemaDB.Models.Filme", b =>
                {
                    b.Property<int>("FilmeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoLancamento");

                    b.Property<int>("CategoriaId");

                    b.Property<int>("Duracao");

                    b.Property<string>("Nome");

                    b.Property<string>("Sinopse");

                    b.HasKey("FilmeId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("CinemaDB.Models.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacidade");

                    b.Property<string>("Nome");

                    b.Property<int>("TamanhoTela");

                    b.HasKey("SalaId");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("CinemaDB.Models.Exibicao", b =>
                {
                    b.HasOne("CinemaDB.Models.Filme", "Filme")
                        .WithMany("Exibicoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CinemaDB.Models.Sala", "Sala")
                        .WithMany("Exibicoes")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CinemaDB.Models.Filme", b =>
                {
                    b.HasOne("CinemaDB.Models.Categoria", "Categorias")
                        .WithMany("Filmes")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
