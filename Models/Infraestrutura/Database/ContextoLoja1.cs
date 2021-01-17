using System;
using System.IO;
using aula_youtube_tabelas_query_bruta.Models.Dominio;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace aula_youtube_tabelas_query_bruta.Models.Infraestrutura.Database
{
    public class ContextoLoja1: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            optionsBuilder.UseNpgsql(jAppSettings["ConexaoSql"].ToString());
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
            modelBuilder.Entity<Pedido>().HasKey(p => new { p.Id, p.IdCliente });
            modelBuilder.Entity<PedidoProduto>().HasKey(p => new { p.IdPedido, p.IdProduto });
        } 

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
