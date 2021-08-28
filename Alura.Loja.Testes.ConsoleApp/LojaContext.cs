using Microsoft.EntityFrameworkCore;
using System;


namespace Alura.Loja.Testes.ConsoleApp
{
   public class LojaContext : DbContext //cria um contexto que herda da classe DBContex
    {
        public DbSet<Produto> Produtos { get; set; } //a propriedade Produtos diz qual classe será persistidada no banco de dados

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //método de configuração para dizer qual banco vai usar e seu path
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }
    }
}
