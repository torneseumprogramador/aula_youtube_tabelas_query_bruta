using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aula_youtube_tabelas_query_bruta.Models.Infraestrutura.Database.Repositorios;

namespace aula_youtube_tabelas_query_bruta.Models.Dominio.Entidades
{
    public class Pedido
    {
        public Pedido(){
            this.Data = DateTime.Now;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        // [Required]
        // public int IdCliente { get; set; }

        [Required]
        [Column("IdCliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente {get;private set;}
        // public Cliente Cliente 
        // { 
        //     get
        //     {
        //         return new ClienteRepositorio().BuscaClientePorId(this.ClienteId);
        //     }
        // }
        [Required]
        public double Valor { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
