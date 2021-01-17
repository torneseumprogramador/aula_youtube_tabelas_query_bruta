using System;
using System.ComponentModel.DataAnnotations;

namespace aula_youtube_tabelas_query_bruta.Models
{
    public class PedidoProduto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdPedido { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public string Quantidade { get; set; }
    }
}
