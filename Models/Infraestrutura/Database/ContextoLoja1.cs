using System;
using System.IO;
using aula_youtube_tabelas_query_bruta.Models.Dominio;
using aula_youtube_tabelas_query_bruta.Models.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace aula_youtube_tabelas_query_bruta.Models.Infraestrutura.Database
{
    public class ContextoLoja1: DbContext
    {
        public ContextoLoja1(DbContextOptions<ContextoLoja1> options): base(options)
        {
        }

        public ContextoLoja1(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            optionsBuilder.UseNpgsql(jAppSettings["ConexaoSql"].ToString());
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
            modelBuilder.Entity<Pedido>().HasKey(p => new { p.Id, p.ClienteId });
            modelBuilder.Entity<PedidoProduto>().HasKey(p => new { p.IdPedido, p.IdProduto });
        } 

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
