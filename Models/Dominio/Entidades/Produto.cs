using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula_youtube_tabelas_query_bruta.Models.Dominio.Entidades
{
    public class Produto
    {
        public Produto(){
            this.Data = DateTime.Now;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }
        
        [Column(TypeName = "Text")]
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        [Required]
        public DateTime Data { get; set; }

    }
}
