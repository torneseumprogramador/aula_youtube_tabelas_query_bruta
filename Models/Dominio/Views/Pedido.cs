using System;
using System.ComponentModel.DataAnnotations;

namespace aula_youtube_tabelas_query_bruta.Models.Dominio.Views
{
    public record Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
