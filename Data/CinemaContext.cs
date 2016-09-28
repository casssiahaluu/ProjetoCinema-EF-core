using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.SQLite
{
    public class Cinema : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Exibicao> Exibicoes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./cinema.db");
        }
    }
}