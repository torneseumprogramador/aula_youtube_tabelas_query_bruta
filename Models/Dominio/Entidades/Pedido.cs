using System;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public int IdCliente { get; set; }
        [Required]
        public double Valor { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
